using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Swashbuckle.AspNetCore.Annotations;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Application.Response;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.Common.Enums.API;
using WebChat.Hubs;
using WebChat.RabbitMQ;

namespace WebChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
      
        [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
        [HttpPost("GetMessages")]
        public async Task<IActionResult> GetMessageDetails(GetMessageReqDto reqest)
        {
            var messages = await unitOfWork.MessageRepository.GetMessageDetailsAsync(reqest);
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var message = await unitOfWork.MessageRepository.GetSingleMessageDetailsAsync(id);
            return Ok(message);
        }

        [HttpPost("AddMessage")]
        public async Task<IActionResult> Post([FromBody] AddMessageReqDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var response = await unitOfWork.MessageRepository.AddMessageAsync(messageDto);
            return Ok(response);
        }

        [HttpPost("UpdateMessage")]
        public async Task<IActionResult> Put([FromBody] UpdateMessageReqDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }
            var updatedMessage = await unitOfWork.MessageRepository.UpdateMessageAsync(messageDto);
            return Ok(updatedMessage);
        }

        [HttpPost("DeleteMessage")]
        public async Task<IActionResult> Delete(DeleteMessageReqDto request)
        {
            var deletedMessage = await unitOfWork.MessageRepository.DeleteMessageAsync(request);
            return Ok(deletedMessage);
        }
    }
}