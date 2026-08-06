using BTDS.DTOs;
using BTDS.DTOs.Auth;
using BTDS.Interface;
using BTDS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace BTDS.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return new ApiResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Invalid Email or Password.",
                    Data = null,
                    Errors = new List<string>
                     {
                         "Invalid Email or Password."
                    }
                };
            }
            var result = await _signinManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded)
            {
                return new ApiResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Invalid Email or Password.",
                    Data = null,
                    Errors = new List<string>
                    {
                         "Invalid Email or Password."
                    }
                };
            }

            var accessToken=GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime= DateTime.UtcNow.AddDays(7);

           var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return new ApiResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Unable to update refresh token.",
                    Data = null,
                    Errors = updateResult.Errors.Select(x => x.Description).ToList()
                };
            }
            return new ApiResponse<LoginResponseDto>
            {
                Success = true,
                Message = "Login successful.",
                Data = new LoginResponseDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    Expiration = DateTime.UtcNow.AddMinutes(
            Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"]))
                },
                Errors = new List<string>()
            };
        }

        public async Task<ApiResponse<RegisterResponseDto>> RegisterAsync(RegisterDto dto)
        {
            _logger.LogInformation("Registration start");
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return new ApiResponse<RegisterResponseDto>
                {
                    Success = false,
                    Message = "Email already exists.",
                    Data = null,
                    Errors = new List<string>
                    {
                      "Email already exists."
                    }
                };
            }
            var user = new AppUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Email,
                TenantId = dto.TenantId,
                CreatedOn = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return new ApiResponse<RegisterResponseDto>
                {
                    Success = false,
                    Message = "Registration failed.",
                    Data = null,
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };
            }
           return new ApiResponse<RegisterResponseDto>
            {
                Success = true,
                Message = "User registered successfully.",
                Data = new RegisterResponseDto
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Email = user.Email!,
                    TenantId = user.TenantId
                },
                Errors = new List<string>()
            };
        }


        public string GenerateJwtToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim("TenantId",user.TenantId.ToString())
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
           Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"])),
            signingCredentials: credentials
                 );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public async Task<ApiResponse<RefreshTokenResponseDto>> RefreshTokenAsync(RefreshTokenDto dto)
        {
            var principal = GetPrincipalFromExpiredToken(dto.AccessToken);

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return new ApiResponse<RefreshTokenResponseDto>
                {
                    Success = false,
                    Message = "Invalid access token.",
                    Data = null,
                    Errors = new List<string>
                    {
                        "Invalid access token."
                     }
                };
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new ApiResponse<RefreshTokenResponseDto>
                {
                    Success = false,
                    Message = "User not found.",
                    Data = null,
                    Errors = new List<string>
                    {
                         "User not found."
                    }
                };
            }

            if (user.RefreshToken != dto.RefreshToken ||user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new ApiResponse<RefreshTokenResponseDto>
                {
                    Success = false,
                    Message = "Invalid refresh token.",
                    Data = null,
                    Errors = new List<string>
                    {
                       "Invalid refresh token."
                    }
                };
            }
            var newAccessToken = GenerateJwtToken(user);

            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;

            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);
            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return new ApiResponse<RefreshTokenResponseDto>
                {
                    Success = false,
                    Message = "Failed to update refresh token.",
                    Data = null,
                    Errors = updateResult.Errors.Select(x => x.Description).ToList()
                };
            }

            return new ApiResponse<RefreshTokenResponseDto>
            {
                Success = true,
                Message = "Token refreshed successfully.",
                Data = new RefreshTokenResponseDto
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                    Expiration = DateTime.UtcNow.AddMinutes(
            Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"]))
                },
                Errors = new List<string>()
            };
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false, 

                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(
                token,
                tokenValidationParameters,
                out SecurityToken securityToken);

            var jwtToken = securityToken as JwtSecurityToken;

            if (jwtToken == null ||
                !jwtToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
