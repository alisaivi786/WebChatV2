using WebChat.RabbitMQ;

namespace WebChat.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Queue")]
    [ApiController]
    public class QueueController(IRabbitMQConsumer RabbitMQConsumer) : ControllerBase
    {
        #region Declaring private fields
        private readonly IRabbitMQConsumer RabbitMQConsumer = RabbitMQConsumer;
        #endregion

        #region ConsumeMessagesQueue
        [MapToApiVersion(1)]
        [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<string>))]
        [HttpPost("ConsumeMessagesQueue")]
        public async Task<IActionResult> ConsumeMessagesQueue()
        {
            //  await RabbitMQConsumer.StartConsuming(queueNamePattern: "chat_queue*");
                await RabbitMQConsumer.StartConsuming(queueNamePattern: "destination_queue_*");

            return Ok();
        }
        #endregion

        #region ConsumeDisconnectedUsersQueue
        [MapToApiVersion(1)]
        [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<string>))]
        [HttpPost("ConsumeDisconnectedUsersQueue")]
        public async Task<IActionResult> ConsumeDisconnectedUsersQueue()
        {
            await RabbitMQConsumer.StartConsumingDisconnectedUsers(queueName: "DisconnectedUsers_queue");

            return Ok();
        }
        #endregion
    }
}