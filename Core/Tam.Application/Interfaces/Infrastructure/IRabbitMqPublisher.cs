using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Interfaces.Infrastructure
{
    public interface IRabbitMqPublisher
    {
        void Publish<T>(string queueName, T message);
    }
}
