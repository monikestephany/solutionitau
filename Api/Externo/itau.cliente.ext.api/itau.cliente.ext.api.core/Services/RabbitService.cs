using FluentValidation;
using itau.cliente.ext.api.core.Contracts;
using itau.cliente.ext.api.core.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.ext.api.core.Services
{
    public class RabbitService : IRabbitService
    {
        private readonly IRabbitConfiguration rabbitConfiguration;
        private readonly IValidator<Cliente> validator;
        public RabbitService(IRabbitConfiguration settings, IValidator<Cliente> validator)
        {
            rabbitConfiguration = settings;
            this.validator = validator;
        }
        public bool AddQueue(Cliente cliente)
        {
            validator.Validate(cliente);

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

                string message = JsonConvert.SerializeObject(cliente);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: rabbitConfiguration.RoutingKey,
                                     basicProperties: null,
                                     body: body);
            }
            return true;
        }
    }
}
