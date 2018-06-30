using System;
using System.Collections.Generic;
using System.Text;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Transport;

namespace BetConstruct.Integration.Donbest.Models
{
    public class SimpleQueueListener : IDisposable
    {
        private readonly IMessageConsumer consumer;
        private bool isDisposed = false;
        private readonly IMessageProcessor processor;
        private readonly ISession session;

        public SimpleQueueListener(IMessageConsumer consumer, IMessageProcessor processor, ISession session)
        {
            this.consumer = consumer;
            MessageConsumer activeMqConsumer = this.consumer as MessageConsumer;
            if (activeMqConsumer != null)
            {
                activeMqConsumer.RedeliveryPolicy.MaximumRedeliveries = 3;
                
            }
            this.consumer.Listener += new MessageListener(OnMessage);
            this.processor = processor;
            this.session = session;
        }

        public void OnMessage(IMessage message)
        {
            ITextMessage textMessage = message as ITextMessage;

            if (this.processor.ReceiveMessage(textMessage))
            {
                this.session.Commit();
            }
            else
            {
                Console.WriteLine("Error - returning message to queue.");
                this.session.Rollback();
            }
        }
        #region IDisposable Members

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.consumer.Dispose();
                this.isDisposed = true;
            }
        }

        #endregion
    }
}
