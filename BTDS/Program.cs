using Serilog;
using Scalar.AspNetCore;
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
builder.Services.AddScoped<ICardsService, CardsService>();
builder.Services.AddScoped<IGateService, GateService>();
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<IDifficultyLevelService, DifficultyLevelService>();
builder.Services.AddScoped<ICardTypeService, CardTypeService>();    
builder.Services.AddScoped<ICardTaskService,CardTaskService>(); 
builder.Services.AddScoped<IResourceTypeService,ResourceTypeService>();
builder.Services.AddScoped<ICardResourceService, CardResourceService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IExamInstructionService,ExamInstrictionService>();
builder .Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionOptionService, QuestionOptionService>();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/swagger/v1/swagger.json");
    });
}
//app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();