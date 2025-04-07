﻿using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShopProject.RabbitMQMessageApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateMessage()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = connectionFactory.CreateConnection();

        var channel = connection.CreateModel();

        channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);

        var message = "Merhaba bugün o gün başaracağım!";

        var byteMessageContent = Encoding.UTF8.GetBytes(message);


        channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

        return Ok("Mesajınız kuyruğa alınmıştır.");
    }

    private static string message;

    [HttpGet]
    public IActionResult ReadMessage()
    {
        var factory = new ConnectionFactory();

        factory.HostName = "localhost";

        var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, x) =>
        {
            var byteMessage = x.Body.ToArray();
            message = Encoding.UTF8.GetString(byteMessage);
        };

        channel.BasicConsume(queue: "Kuyruk2", autoAck: false, consumer: consumer);

        if (string.IsNullOrEmpty(message))
        {
            return NoContent();
        }
        else
        {
            return Ok(message);
        }
    }
}
