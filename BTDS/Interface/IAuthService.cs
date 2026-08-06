using BTDS.DTOs;
using BTDS.DTOs.Auth;

namespace BTDS.Interface
{
    public interface IAuthService
    {
        Task<ApiResponse<RegisterResponseDto>> RegisterAsync(RegisterDto dto);
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto);
        Task<ApiResponse<RefreshTokenResponseDto>>RefreshTokenAsync(RefreshTokenDto dto);
    }
}
