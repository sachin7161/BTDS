using Serilog;
using BTDS.Interface;
using BTDS.Middleware;
using BTDS.Models;
using BTDS.Services;
using Microsoft.EntityFrameworkCore;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<BtdsdbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Mycon"));
});
builder.Services.AddScoped<IStagesService, StageServices>();
builder.Services.AddScoped<ICardsService, CardServices>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();