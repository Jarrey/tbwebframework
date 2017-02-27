using System;
using AspComet.Eventing;

namespace AspComet.MessageHandlers
{
    public class MetaUnsubscribeHandler : IMessageHandler
    {
        private readonly IClientRepository clientRepository;

        public MetaUnsubscribeHandler(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public MessageHandlerResult HandleMessage(Message request)
        {
            Client client = clientRepository.GetByID(request.clientId);

            client.UnsubscribeFrom(request.subscription);

            var e = new UnsubscribedEvent(client, request.subscription);
            EventHub.Publish(e);

            Message[] message =
              {
                new Message
                {
                    id = request.id,
                    channel = request.channel,
                    successful = true,
                    clientId = client.ID,
                    subscription = request.subscription
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