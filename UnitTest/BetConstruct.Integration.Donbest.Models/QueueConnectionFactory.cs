using System;
using System.Collections.Generic;
using System.Text;

using Apache.NMS;

namespace BetConstruct.Integration.Donbest.Models
{
    public class QueueConnectionFactory
    {
        private readonly IConnectionFactory connectionFactory;

        public QueueConnectionFactory(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public QueueConnection CreateConnection(string queueName)
        {
            return new QueueConnection(this.connectionFactory, queueName);
        }

        public QueueConnection CreateTransactedConnection(string queueName)
        {
            return new QueueConnection(this.connectionFactory, queueName, AcknowledgementMode.Transactional);
        }
    }
}
