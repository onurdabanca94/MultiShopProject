using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace MultiShopProject.RabbitMQMessageApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMessage()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = connectionFactory.CreateConnection();

        var channel = connection.CreateModel();

        channel.QueueDeclare("Kuyruk1", false, false, false, arguments: null);

        var message = "Merhaba bu bir RabbitMQ kuyruk mesajıdır.";

        var byteMessageContent = Encoding.UTF8.GetBytes(message);


        channel.BasicPublish(exchange: "", routingKey: "Kuyruk1", basicProperties: null, body: byteMessageContent);

        return Ok("Mesajınız kuyruğa alınmıştır.");
    }
}
