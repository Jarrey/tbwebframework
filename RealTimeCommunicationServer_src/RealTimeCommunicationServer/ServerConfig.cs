using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AspComet.Eventing;
using Autofac;
using Microsoft.Practices.ServiceLocation;

namespace RealTimeCommunicationServer
{
  public class ServerConfig
  {
    private static IContainer container;

    public void ServerConfigStart()
    {

      ContainerBuilder builder = new ContainerBuilder();

      // Let AspComet put its registrations into the container
      foreach (AspComet.ServiceMetadata metadata in AspComet.ServiceMetadata.GetMinimumSet())
      {
        if (metadata.IsPerRequest)
          builder.RegisterType(metadata.ActualType).As(metadata.ServiceType);
        else
          builder.RegisterType(metadata.ActualType).As(metadata.ServiceType).SingleInstance();
      }

      // Add our own stuff to the container
      builder.RegisterType<AuthenticatedClientFactory>().As<AspComet.IClientFactory>().SingleInstance();
      builder.RegisterType<clsSystemMessageServer>().SingleInstance();

      //builder.RegisterType<HandshakeAuthenticator>().SingleInstance();
      //builder.RegisterType<BadLanguageBlocker>().SingleInstance();
      //builder.RegisterType<SubscriptionChecker>().SingleInstance();

      // Set up the common service locator
      container = builder.Build();


      ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

      //服务器推入系统消息
      EventHub.Subscribe<ConnectingEvent>(container.Resolve<clsSystemMessageServer>().mSendSystemMessage);
      //EventHub.Subscribe<HandshakingEvent>(container.Resolve<HandshakeAuthenticator>().CheckHandshake);
      //EventHub.Subscribe<PublishingEvent>(container.Resolve<BadLanguageBlocker>().CheckMessage);
      //EventHub.Subscribe<SubscribingEvent>(container.Resolve<SubscriptionChecker>().CheckSubscription);
    }

    public void ServerConfigEnd()
    {
      if (container != null)
      {
        container.Dispose();
        container = null;
      }
    }
  }
}
