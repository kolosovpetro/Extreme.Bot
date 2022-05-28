# ASP NET Core Telegram Bot

## Steps to implement

- Create web api project with controllers and endpoints
- Create tunnel to the localhost using ngrok
- Set webhook to the ngrok url
- Test bot

# Comments

- Crate ngrok tunnel: `ngrok http 53660`
- Set webhook: `https://api.telegram.org/bot{my_bot_token}/setWebhook?url={url_to_send_updates_to}`