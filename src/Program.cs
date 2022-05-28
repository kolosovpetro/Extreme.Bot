using System.Net.Http;
using Extreme.Bot.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

var botConfiguration = ConfigurationService.CreateConfiguration();
builder.Services.AddSingleton(_ => botConfiguration);

builder.Services.AddScoped<HandleUpdateService>();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient<HttpClient>();

builder.Services.AddSingleton<ITelegramBotClient>(_ => new TelegramBotClient(token: botConfiguration.BotToken));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();