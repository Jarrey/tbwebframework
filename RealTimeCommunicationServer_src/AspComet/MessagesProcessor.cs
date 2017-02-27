using System.Collections.Generic;

namespace AspComet
{
    public class MessagesProcessor : IMessagesProcessor
    {
        private readonly IMessageHandlerFactory messageHandlerFactory;
        private readonly List<Message> response = new List<Message>();

        public MessagesProcessor(IMessageHandlerFactory messageHandlerFactory)
        {
            this.messageHandlerFactory = messageHandlerFactory;
        }

        public bool ShouldSendResultStraightBackToClient { get; private set; }
        public IEnumerable<Message> Result { get { return this.response; } }

        public void Process(IEnumerable<Message> messages)
        {
            foreach (Message message in messages)
            {
              if (message != null)
                this.Process(message);
            }
        }

        private void Process(Message message)
        {
            IMessageHandler handler = this.messageHandlerFactory.GetMessageHandler(message.channel);
            MessageHandlerResult handlerResult = handler.HandleMessage(message);
            foreach (Message eachMessage in handlerResult.Message)
            {
              this.response.Add(eachMessage);
            }
            this.ShouldSendResultStraightBackToClient |= !handlerResult.ShouldWait;
        }
    }
}