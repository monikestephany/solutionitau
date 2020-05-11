using FluentValidation;
using itau.doc.ext.api.core.Contracts;
using itau.doc.ext.api.core.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.ext.api.core.Services
{
    public class RabbitService : IRabbitService
    {
        private readonly IRabbitConfiguration rabbitConfiguration;
        private readonly IValidator<Doc> validator;
        public RabbitService(IRabbitConfiguration settings, IValidator<Doc> validator)
        {
            rabbitConfiguration = settings;
            this.validator = validator;
        }
        public bool AddQueue(Doc doc)
        {
            validator.Validate(doc);

            var factory = new ConnectionFactory()
            {
                HostName = rabbitConfiguration.Host,
                UserName = rabbitConfiguration.User,
                Password = rabbitConfiguration.Password,
                VirtualHost = rabbitConfiguration.User
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: rabbitConfiguration.Queue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(doc);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: rabbitConfiguration.Exchange,
                                     routingKey: rabbitConfiguration.RoutingKey,
                                     basicProperties: null,
                                     body: body);
            }
            return true;
        }
    }
}
