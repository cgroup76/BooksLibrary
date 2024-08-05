using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IHubContext<MessageHub> _hubContext;

    public MessagesController(IHubContext<MessageHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] MessageDto messageDto)
    {
        await _hubContext.Clients.User(messageDto.User).SendAsync("ReceiveMessage", messageDto.User, messageDto.Message);
        return Ok();
    }
}

public class MessageDto
{
    public string User { get; set; }
    public string Message { get; set; }
}
