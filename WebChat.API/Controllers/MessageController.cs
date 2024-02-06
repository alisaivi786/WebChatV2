using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Swashbuckle.AspNetCore.Annotations;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Application.Response;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.Common.Enums.API;
using WebChat.Common.IBaseResponse;
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
            var response = await unitOfWork.MessageRepository.GetMessageDetailsAsync(reqest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await unitOfWork.MessageRepository.GetSingleMessageDetailsAsync(id);
            return Ok(response);
        }

        [HttpPost("AddMessage")]
        public async Task<IActionResult> Post([FromBody] AddMessageReqDto reqest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var response = await unitOfWork.MessageRepository.AddMessageAsync(reqest);
            return Ok(response);
        }

        [HttpPost("AddBulkMessage")]
        public async Task<IActionResult> AddBulkMessage([FromBody] List<AddBulkMessageReqDto> reqest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            var response = await unitOfWork.MessageRepository.AddBulkMessageAsync(reqest);
            return Ok(response);
        }

        [HttpPost("UpdateMessage")]
        public async Task<IActionResult> Put([FromBody] UpdateMessageReqDto reqest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }
            var response = await unitOfWork.MessageRepository.UpdateMessageAsync(reqest);
            return Ok(response);
        }

        [HttpPost("DeleteMessage")]
        public async Task<IActionResult> Delete(DeleteMessageReqDto request)
        {
            var response = await unitOfWork.MessageRepository.DeleteMessageAsync(request);
            return Ok(response);
        }
    }
}