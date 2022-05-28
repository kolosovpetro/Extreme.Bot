namespace Extreme.Bot;

public class BotConfiguration
{
    public string BotToken { get; }
    public string BaseUrl { get; }

    public BotConfiguration(string botToken, string baseUrl)
    {
        BotToken = botToken;
        BaseUrl = baseUrl;
    }

    public BotConfiguration()
    {
    }
}