using Apache.NMS;

namespace BetConstruct.Integration.Donbest.Models

{
    public interface IMessageProcessor
    {
        bool ReceiveMessage(ITextMessage message);
    }
}
