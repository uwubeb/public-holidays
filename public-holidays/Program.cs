using public_holidays.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

// Learn more about configuring Swagger/OpenPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(typeof(Program));
services.ConfigureServices();
services.ConfigureDatabase(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseOpenApi(); 


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

