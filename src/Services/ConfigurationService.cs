using System;

namespace Extreme.Bot.Services;

public static class ConfigurationService
{
    public static BotConfiguration CreateConfiguration()
    {
        var botToken = Environment.GetEnvironmentVariable("RAZUMOVSKY_BOT_API_KEY")
                       ?? throw new InvalidOperationException(
                           "RAZUMOVSKY_BOT_API_KEY environment variable is not set.");

        const string baseUrl = "https://868f-178-37-169-122.eu.ngrok.io/api/webhook";
        var botConfig = new BotConfiguration(botToken, baseUrl);

        return botConfig;
    }
}