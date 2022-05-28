using System.Threading.Tasks;
using Extreme.Bot.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace Extreme.Bot.Controllers;

public class WebhookController : ControllerBase
{
    [HttpPost("api/webhook")]
    public async Task<IActionResult> Post(
        [FromServices] HandleUpdateService handleUpdateService,
        [FromBody] Update update)
    {
        await handleUpdateService.EchoAsync(update);
        return Ok();
    }
}