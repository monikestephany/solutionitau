using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using itau.mqconsumer.ws.core.Contracts;
using itau.mqconsumer.ws.core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace itau.mqconsumer.ws.application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ServiceConfigurations serviceConfiguration;
        private readonly IRestService _clienteService;
        public Worker(ILogger<Worker> logger, IConfiguration configuration , IRestService clienteService)
        {
            _logger = logger;
            serviceConfiguration = new ServiceConfigurations();
            _clienteService = clienteService;
            new ConfigureFromConfigurationOptions<ServiceConfigurations>(
                configuration.GetSection("ServiceConfigurations"))
                    .Configure(serviceConfiguration);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var resultado = new Log();
                resultado.Horario =
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                resultado.Host = serviceConfiguration.RabbitMq.Host;
                _logger.LogInformation("Iniciando o consumidor MqCliente: {time}", DateTimeOffset.Now);
                try
                {
                    var factory = new ConnectionFactory()
                    {
                        HostName = serviceConfiguration.RabbitMq.Host,
                        UserName = serviceConfiguration.RabbitMq.User,
                        Password = serviceConfiguration.RabbitMq.Password,
                        VirtualHost = serviceConfiguration.RabbitMq.User
                    };

                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: serviceConfiguration.RabbitMq.Queue,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                       // var consumer = new EventingBasicConsumer(channel);
                       // consumer.Received += Consumer_Received;
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (ch, ea) =>
                        {

                            var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                            // negatively acknowledge, the message will
                            // be discarded
                            var tag = _clienteService.Post(serviceConfiguration.APIRest, message);
                            if (tag)
                            {
                                channel.BasicAck(ea.DeliveryTag,false );
                            }
                            else
                            {
                                channel.BasicNack(ea.DeliveryTag, true, true);
                            }
                         
                            _logger.LogInformation("Mensagem lida :{mensagem} ás {time}", message, DateTimeOffset.Now);
                        };

                        channel.BasicConsume(queue: serviceConfiguration.RabbitMq.Queue,
                             autoAck: false,
                             consumer: consumer);
                        var mensagem = Console.ReadKey(); 
                    }
                }
                catch (Exception ex)
                {
                    resultado.Status = "Exception";
                    resultado.Exception = ex;
                }

                string jsonResultado =
                     JsonConvert.SerializeObject(resultado);
                if (resultado.Exception == null)
                    _logger.LogInformation(jsonResultado);
                else
                    _logger.LogError(jsonResultado);


                await Task.Delay(serviceConfiguration.Intervalo, stoppingToken);
            }
        }     
    }
}
