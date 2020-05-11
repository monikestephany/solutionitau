using itau.mqconsumer.ws.core.Model;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.mqconsumer.ws.data
{
    class Context : IPooledObjectPolicy<IModel>
    {
        private readonly ServiceConfigurations _options;

        private readonly IConnection _connection;

        public Context(IOptions<ServiceConfigurations> optionsAccs)
        {
            _options = optionsAccs.Value ;
            _connection = GetConnection();
        }
        private IConnection GetConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _options.RabbitMq.Host,
                UserName = _options.RabbitMq.User,
                Password = _options.RabbitMq.Password,
                Port = _options.RabbitMq.Port
            };

            return factory.CreateConnection();
        }
        public IModel Create()
        {
            return _connection.CreateModel();
        }
        public bool Return(IModel obj)
        {
            if (obj.IsOpen)
            {
                return true;
            }
            else
            {
                obj?.Dispose();
                return false;
            }
        }
    }
}
