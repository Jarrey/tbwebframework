using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 系统消息结构体
 * prpStrSystemMessageTime 消息时间
 * prpStrSystemMessageType 消息类型
 * prpStrSystemMessage 消息内容
 * prpStrMessageLevel 消息级别
 * prpStrUserName 消息发生用户
 * */
namespace RealTimeCommunicationServer.MessageStruct
{

  public class clsSystemMessageStruct
  {
    public long prpLngSystemMessageSrno { get; set; }
    public string prpStrSystemMessageTime { get; set; }
    public string prpStrSystemMessageType { get; set; }
    public string prpStrSystemMessage { get; set; }
    public string prpStrMessageLevel { get; set; }
    public string prpStrUserName { get; set; }
  }
}
