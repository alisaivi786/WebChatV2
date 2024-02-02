
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WebChat.RabbitMQ;

public class RabbitMQProducer(ConnectionFactory connectionFactory): IRabbitMQProducer
{
    private readonly ConnectionFactory factory = connectionFactory;

    public void PublishMessageToRabbitMQ<T>(T message)
    {
        //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
        //var factory = new ConnectionFactory
        //{
        //    HostName = "localhost", // RabbitMQ server host
        //    UserName = "guest",     // RabbitMQ username
        //    Password = "guest"      // RabbitMQ password
        //};

        //Create the RabbitMQ connection using connection factory details as i mentioned above
        var connection = factory.CreateConnection();

        //Here we create channel with session and model
       
        var channel = connection.CreateModel();

        //declare the queue after mentioning name and a few property related to that
        channel.QueueDeclare(queue: "chat_queue",
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);

        //Serialize the message
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        //put the data on to the product queue
        channel.BasicPublish(exchange: "", routingKey: "chat_queue", body: body);
    }
}
