using public_holidays.Startup;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.ConfigureServices();
services.ConfigureDatabase(configuration);

var app = builder.Build();
app.ConfigureApp();

app.Run();

