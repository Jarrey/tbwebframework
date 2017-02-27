using System;

namespace AspComet.MessageHandlers
{
    public class ExceptionHandler : IMessageHandler
    {
        public string ErrorMessage { get; private set; }

        public ExceptionHandler(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        public MessageHandlerResult HandleMessage(Message request)
        {
          Message[] message = 
          { new Message
            {
                id = request.id,
                channel = request.channel,
                error = this.ErrorMessage
            }
          };
            return new MessageHandlerResult
            {
              Message = message,
              ShouldWait = false
            };
        }
    }
}