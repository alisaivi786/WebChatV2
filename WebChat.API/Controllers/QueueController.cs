using WebChat.RabbitMQ;

namespace WebChat.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Queue")]
    [ApiController]
    public class QueueController (IRabbitMQConsumer RabbitMQConsumer) : ControllerBase
    {
        #region Declaring private fields
        private readonly IRabbitMQConsumer RabbitMQConsumer = RabbitMQConsumer;
        #endregion

        #region GetMessageDetails
        [MapToApiVersion(1)]
        [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<string>))]
        [HttpPost("ConsumeQueue")]
        public async Task<IActionResult> ConsumeQueue()
        {
            await RabbitMQConsumer.StartConsuming(queueName: "chat_queue");

            return Ok();
        }
        #endregion
    }
}