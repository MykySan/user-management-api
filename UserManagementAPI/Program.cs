using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<UserManagementAPI.Services.UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<UserManagementAPI.Middleware.ErrorHandlingMiddleware>();
app.UseMiddleware<UserManagementAPI.Middleware.AuthenticationMiddleware>();
app.UseMiddleware<UserManagementAPI.Middleware.LoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();

