using System;
using System.Collections.Generic;
using System.Text;

using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;

namespace BetConstruct.Integration.Donbest.Models
{
    public class QueueConnection : IDisposable
    {
        private readonly IConnection connection;
        private readonly ISession session;
        private readonly IQueue queue;
        private bool isDisposed = false;

        public QueueConnection(IConnectionFactory connectionFactory, string queueName)
            : this(connectionFactory, queueName, AcknowledgementMode.AutoAcknowledge)
        {
        }

        public QueueConnection(IConnectionFactory connectionFactory, string queueName, AcknowledgementMode acknowledgementMode)
        {
            this.connection = connectionFactory.CreateConnection();
            this.connection.Start();
            this.session = this.connection.CreateSession(acknowledgementMode);
            this.queue = new ActiveMQQueue(queueName);
        }

        public SimpleQueueListener CreateSimpleQueueListener(IMessageProcessor processor)
        {
            IMessageConsumer consumer = this.session.CreateConsumer(this.queue, "2 > 1");
            return new SimpleQueueListener(consumer, processor, this.session);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.session.Dispose();
                this.connection.Stop();
                this.connection.Dispose();
                this.isDisposed = true;
            }
        }

        #endregion
    }
}
