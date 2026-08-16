using CH_Manage.EF_Configurations;
using CH_Manage.MapGroupFold;
using CH_Manage.OperationsLogin;
using CH_Manage.OperationsModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the CRUD and Login operations services
builder.Services.AddScoped<User_OpCrud>();
builder.Services.AddScoped<Project_OpCrud>();
builder.Services.AddScoped<Option_OpCrud>();
builder.Services.AddScoped<ClientConfiguration_OpCrud>();
builder.Services.AddScoped<ConfigurationOption_OpCrud>();
builder.Services.AddScoped<User_Login>();
builder.Services.AddScoped<ForgotPassword>();


var app = builder.Build();

// Automatically apply database migrations on startup.
// This is a common pattern for development and Docker environments.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Map the endpoints
app.MapUserApi();
app.MapProjectApi();
app.MapOptionApi();
app.MapClientConfigurationApi();
app.MapConfigurationOptionApi();
app.MapLoginApi();

app.Run();
