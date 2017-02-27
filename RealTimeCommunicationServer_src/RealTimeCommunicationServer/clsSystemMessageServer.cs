using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AspComet.Eventing;
using AspComet;

namespace RealTimeCommunicationServer
{
  public class clsSystemMessageServer
  {
    private readonly IClientRepository clientRepository;
    private const string strChannelName = "/SystemMessage";

    public static List<MessageStruct.clsSystemMessageStruct> mLstMessage = new List<MessageStruct.clsSystemMessageStruct>();

    public clsSystemMessageServer(IClientRepository clientRepository)
    {
      this.clientRepository = clientRepository;
    }

    public void mSendSystemMessage(ConnectingEvent ev)
    {
      if (mLstMessage.Count == 0) return;

      ev.Cancel = true;

      Client sender = this.clientRepository.GetByID(ev.Message[0].clientId);
      ArrayList messageList = new ArrayList();

      Dictionary<string, object> messagedata = null;

      foreach (MessageStruct.clsSystemMessageStruct lObjMessage in mLstMessage)
      {
        messagedata = new Dictionary<string, object>
        {
          {"jsMessageTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")},
          {"jsMessageType", MessageIndicator.clsMessageIndicator.MSG_INDC_SERVER_SYSTEM_MESSAGE},
          {"jsMessageBody", new Dictionary<string,object>
            {
              {"jsSystemMessageSrno", lObjMessage.prpLngSystemMessageSrno},
              {"jsSystemMessageTime", lObjMessage.prpStrSystemMessageTime},
              {"jsSystemMessageType", "[" + lObjMessage.prpStrSystemMessageType + "]"},
              {"jsSystemMessage", lObjMessage.prpStrUserName + " : " + lObjMessage.prpStrSystemMessage},
              {"jsSystemMessageLevel", lObjMessage.prpStrMessageLevel},
              {"jsSystemMessageUser", lObjMessage.prpStrUserName}
            }
          }
        };
                
        Message message = new Message
        {
          channel = strChannelName,
          data = messagedata
        };
        messageList.Add(message);
      }
      mLstMessage.Clear();

      ev.Message = new Message[messageList.Count];
      messageList.CopyTo(ev.Message);

      foreach (Client subscriber in this.clientRepository.WhereSubscribedTo(strChannelName).Where(c => c.ID != sender.ID))
      {
        subscriber.Enqueue(ev.Message);
        subscriber.FlushQueue();
      }
    }

  }

}
