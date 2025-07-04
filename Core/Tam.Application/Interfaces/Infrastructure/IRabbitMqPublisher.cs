using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Interfaces.Infrastructure
{
    public interface IRabbitMqPublisher
    {
        public Task PublishAsync<T>(string queueName, T message);
    }
}
