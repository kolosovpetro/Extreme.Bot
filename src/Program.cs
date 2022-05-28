using System.Net.Http;
using Extreme.Bot;
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

var httpClient = new HttpClient();

builder.Services.AddHttpClient<HttpClient>();

builder.Services.AddSingleton<ITelegramBotClient>(_ =>
    new TelegramBotClient(
        botConfiguration.BotToken,
        httpClient,
        botConfiguration.BaseUrl));

var app = builder.Build();
app.UseTelegramBotWebhook();

app.UseAuthorization();

app.MapControllers();

app.Run();