namespace WebChat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    // GET api/message
    [HttpGet("GetMessages")]
    public async Task<IActionResult> GetMessageDetails()
    {
        var messages = await unitOfWork.MessageRepository.GetMessageDetailsAsync();
        return Ok(messages);
    }

    // GET api/message/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var message = await unitOfWork.MessageRepository.GetSingleMessageDetailsAsync(id);
        return Ok(message);
    }

    // POST api/message
    [HttpPost("AddMessage")]
    public async Task<IActionResult> Post([FromBody] AddMessageDto messageDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }

        var response = await unitOfWork.MessageRepository.AddMessageAsync(messageDto);
        return Ok(response);
    }

    // PUT api/message/5
    [HttpPut("UpdateMessage")]
    public async Task<IActionResult> Put([FromBody] UpdateMessageDto messageDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }
        var updatedMessage = await unitOfWork.MessageRepository.UpdateMessageAsync(messageDto);
        return Ok(updatedMessage);
    }

    // DELETE api/message/5
    [HttpDelete("DeleteMessage")]
    public async Task<IActionResult> Delete(DeleteMessageDto request)
    {
        var deletedMessage = await unitOfWork.MessageRepository.DeleteMessageAsync(request);
        return Ok(deletedMessage);
    }
}
