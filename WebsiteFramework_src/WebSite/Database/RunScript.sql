PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [TB_FILE_MANAGER](
[FM_FILE_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[FM_DATE_TIME] datetime NOT NULL
,[FM_FILE_NAME] text NOT NULL
,[FM_FILE_PATH] text NOT NULL
,[FM_FILE_CATEGORY] text NOT NULL
,[FM_STATUS] integer NOT NULL
,[FM_UPDATE_USER_SRNO] integer
,[FM_UPDATE_TIME] datetime
  
);
CREATE TABLE "TB_USER_CUSTOM_DTLS"(
[UCD_ITEM_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[UCD_ITEM_CODE] text UNIQUE NOT NULL
,[UCD_ITEM_NAME] text NOT NULL
,[UCD_ITEM_CATEGORY] integer NOT NULL
,[UCD_ITEM_STATUS] integer NOT NULL
,[UCD_CREATE_USER_SRNO] integer NOT NULL
,[UCD_CREATE_DATE_TIME] datetime NOT NULL
,[UCD_UPDATE_USER_SRNO] integer
,[UCD_UPDATE_DATE_TIME] datetime
  
);
CREATE TABLE [TB_USER_DTLS_MAP](
[UDM_USER_SRNO] integer NOT NULL
,[UDM_UCD_ITEM_SRNO] integer NOT NULL
,[UDM_CONTEXT] text
  
);
CREATE TABLE "TB_USER_DTLS"(
[UD_USER_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[UD_USER_NAME] text NOT NULL
,[UD_USER_SEX] integer NOT NULL
,[UD_USER_BIRTHDAY] datetime
,[UD_USER_BLOOD_TYPE] integer
,[UD_USER_TEL] text
,[UD_USER_MOBLIE] text
,[UD_USER_EMAIL] text
,[UD_USER_ADDRS] text
,[UD_USER_COUNTRY] text
,[UD_USER_DESC] text
,[UD_USER_CATEGORY] integer
,[UD_USER_STATUS] integer NOT NULL
,[UD_CREATE_USER_SRNO] integer NOT NULL
,[UD_CREATE_DATE_TIME] datetime NOT NULL
,[UD_UPDAET_USER_SRNO] integer
,[UD_UPDATE_DATE_TIME] datetime
  
);
CREATE TABLE "TB_USER_LOGIN_DTLS"(
[ULD_USER_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[ULD_USER_PSW] text NOT NULL
,[ULD_LOGIN_TIME] datetime
,[ULD_LAST_LOGIN_TIME] datetime
  
);
CREATE TABLE "TB_LANG_DICTIONARY"(
[LD_ITEM_SRNO] integer NOT NULL
,[LD_ITEM_LANG] integer NOT NULL
,[LD_DESC] text NOT NULL
  
);
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1001,1,'查询');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1001,2,'查詢');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1001,3,' Search');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1002,1,'更新');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1002,2,'更新');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1002,3,' Update');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1003,1,'删除');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1003,2,'刪除');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1003,3,' Delete');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1004,1,'清空');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1004,2,'清空');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1004,3,' Clear');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1005,1,'异常');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1005,2,'異常');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1005,3,' Exception');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1006,1,'编号');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1006,2,'編號');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1006,3,' No.');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1007,1,'记录');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1007,2,'記錄');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1007,3,' Record(s)');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1008,1,'此记录');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1008,2,'此記錄');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1008,3,' This Record');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1009,1,'时间');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1009,2,'時間');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1009,3,' Time');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1010,1,'日期');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1010,2,'日期');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1010,3,' Date');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1011,1,'状态');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1011,2,'狀態');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1011,3,' Status');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1012,1,'修改');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1012,2,'修改');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1012,3,' Modify');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1013,1,'用户');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1013,2,'用戶');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1013,3,' User');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1015,1,'所有');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1015,2,'所有');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1015,3,' All');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1019,1,'操作');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1019,2,'操作');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1019,3,' Operation');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1016,1,'从');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1016,2,'從');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1016,3,' From');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1017,1,'到');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1017,2,'到');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1017,3,' To');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1018,1,'发生');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1018,2,'發生');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1018,3,' Occured');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1020,1,'配置');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1020,2,'配置');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1020,3,' Settings');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1021,1,'注销');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1021,2,'註銷');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1021,3,' Logout');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1022,1,'菜单');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1022,2,'菜單');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1022,3,' Menu');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1023,1,'工具');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1023,2,'工具');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1023,3,' Tool');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1024,1,'管理中心');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1024,2,'管理中心');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1024,3,' Management Center');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1025,1,'管理中心首页');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1025,2,'管理中心首頁');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1025,3,' Management Center Home');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1026,1,'用户管理');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1026,2,'用戶管理');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1026,3,' User Management');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1027,1,'日志管理');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1027,2,'日誌管理');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1027,3,' Log Management');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1028,1,'异常管理');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1028,2,'異常管理');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1028,3,' Exception Management');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1029,1,'系统设置');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1029,2,'系統設置');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1029,3,' System Settings');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1030,1,'参数设置');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1030,2,'參數設置');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1030,3,' Preferences');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1014,1,'内容');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1014,2,'内容');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1014,3,' Context');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1032,1,'异常编号');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1032,2,'異常編號');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1032,3,' Exception No.');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1033,1,'异常发生时间');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1033,2,'異常發生時間');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1033,3,' Exception Occured Time');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1034,1,'最终修改用户');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1034,2,'最終修改用戶');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1034,3,' Last Modify User');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1035,1,'最终修改时间');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1035,2,'最終修改時間');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1035,3,' Last Modify Time');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1036,1,'全部');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1037,1,'正常');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1038,1,'解决');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1039,1,'紧急');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1040,1,'无关紧要');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1036,2,'全部');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1037,2,'正常');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1038,2,'解決');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1039,2,'緊急');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1040,2,'無關緊要');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1036,3,' All');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1037,3,' Normal');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1038,3,' Fixed');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1039,3,' Exigent');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1040,3,' Inessential');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1041,1,'系统');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1041,2,'系統');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1041,3,' System');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1042,1,'自定义');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1042,2,'自定義');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1042,3,' Custom');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1043,1,'图像');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1044,1,'数字');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1045,1,'链接');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1046,1,'文本');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1043,2,'圖像');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1044,2,'數字');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1045,2,'鏈接');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1046,2,'文本');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1044,3,' Numeric');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1045,3,' Link');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1046,3,' Text');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1043,3,' Image');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1047,1,'标题');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1047,2,'標題');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1047,3,' Title');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1048,1,'日志');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1048,2,'日誌');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1048,3,' Log');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1049,1,'日志文件编号');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1050,1,'日志创建时间');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1051,1,'日志文件名');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1049,2,'日誌文件編號');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1050,2,'日誌創建時間');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1051,2,'日誌文件名');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1049,3,' Log File Serial No.');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1050,3,' Log Date Time');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1051,3,' Log File Name');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1052,1,'日志类型');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1052,2,'日誌類型');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1052,3,' Log Categgory');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1053,1,'普通');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1053,2,'普通');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1053,3,' Normal');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1054,1,'系统信息');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1054,2,'系統信息');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1054,3,' System Information');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1055,1,'保存');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1056,1,'打印');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1055,2,'保存');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1056,2,'打印');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1055,3,' Save');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1056,3,' Print');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1057,1,'请选择');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1057,2,'請選擇');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1057,3,' Please Select');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(101,1,'Y-m-d');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(101,2,'Y/m/d');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(101,3,'d-M-Y');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(102,1,'H:i:s');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(102,2,'H:i:s');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(102,3,'H:i:s');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1058,1,'注意');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1058,2,'注意');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1058,3,' Attention');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1059,1,'左对齐');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1060,1,'居中');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1061,1,'右对齐');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1059,2,'左對齊');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1060,2,'居中');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1061,2,'右對齊');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1059,3,' Left');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1060,3,' Center');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1061,3,' Right');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1062,1,'导出');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1062,3,' Export');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1062,2,'導出');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1063,1,'消息时间');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1063,2,'消息時間');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1063,3,' Message Time');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1064,1,'消息类型');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1064,2,'消息類型');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1064,3,' Message Type');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1065,1,'系统消息');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1065,2,'系統消息');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1065,3,' System Message');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1066,1,'信息');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1066,2,'信息');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1066,3,' Information');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1067,1,'调试');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1067,2,'調試');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1068,1,'日志级别');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1068,2,'日誌級別');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1068,3,' Log Level');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1069,2,'級別');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1069,1,'级别');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1069,3,' Level');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1070,1,'布尔');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1070,2,'布爾');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1070,3,' Boolean');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1071,1,'系统消息监控');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1071,3,' System Message Monitor');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1071,2,'系統消息監控');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1072,1,'系统消息编号');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1072,2,'系統消息編號');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1072,3,' System Message Serial No.');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1073,1,'系统消息时间');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1073,2,'系統消息時間');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1073,3,' System Message Time');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1074,1,'系统消息类型');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1074,2,'系統消息類型');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1074,3,' System Message Type');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1075,1,'系统消息级别');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1075,2,'系統消息級別');
INSERT INTO "TB_LANG_DICTIONARY" VALUES(1075,3,' System Message Level');
CREATE TABLE "TB_MESSAGE_DICTIONARY"(
[MD_MESSAGE_SRNO] integer NOT NULL
,[MD_MESSAGE_LANG] integer NOT NULL
,[MD_MESSAGE_DESC] text NOT NULL
  
);
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1000,2,'無數據!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1000,3,'No Data!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1001,1,'无效的请求标识!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1001,2,'無效的請求標識!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1001,3,'Invalid Request Indicate!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1002,1,'查询了 %p1 条数据!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1002,2,'查詢了 %p1 條數據!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1002,3,'Query %p1 Records!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1003,1,'更新失败!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1003,2,'更新失敗!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1003,3,'Update Failed!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1004,1,'更新成功!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1004,2,'更新成功!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1004,3,'Update Successful!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1005,1,'删除成功!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1005,2,'刪除成功!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1005,3,'Delete Successfully!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1006,1,'删除失败!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1006,2,'刪除失敗!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1006,3,'Delete Failed!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1007,1,'初始化失败!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1007,2,'初始化失敗!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1007,3,'Initialization Failed!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1008,1,'日志数据在生成 %p1 天后会自动删除!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1008,2,'日誌數據在生成 %p1 天后會自動刪除!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1008,3,'Log data will be automatically deleted after %p1 days!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1009,1,'异常数据在生成 %p1 天后会自动删除!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1009,2,'異常數據在生成 %p1 天后會自動刪除!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1009,3,'Exception data will be automatically deleted after %p1 days!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1000,1,'无数据!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1010,1,'输入的数据无效!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1010,2,'輸入的數據無效!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1010,3,'The value inputted is invalid!');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1011,1,'双击查看日志内容');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1011,2,'雙擊查看日之内容');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1011,3,'Double click to view the log file');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1012,1,'双击查看系统消息内容');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1012,2,'雙擊查看系統消息内容');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1012,3,'Double click to view the system message');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1013,1,'消息过长，系统截取了前 %p1 个字符');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1013,3,'Message is too long, the system intercepted the top %p1 characters');
INSERT INTO "TB_MESSAGE_DICTIONARY" VALUES(1013,2,'消息過長，系統截取了前 %p1 個字符');
CREATE TABLE [TB_CODE_MASTER](
[CMS_CODE_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[CMS_CODE_DESC] text NOT NULL
,[CMS_CODE_NAME] text NOT NULL
,[CMS_CODE_LABEL] text NOT NULL
,[CMS_CODE_LABEL_LANG_SRNO] integer
,[CMS_CODE_CATEGORY] integer NOT NULL
,[CMS_CODE_VALUE] text NOT NULL
,[CMS_CODE_VALUE_LANG_SRNO] integer
,[CMS_CUSTOM_QUERY] text
,[CMS_CREATE_USER_SRNO] integer NOT NULL
,[CMS_CREATE_DATE_TIME] datetime NOT NULL
,[CMS_UPDATE_USER_SRNO] integer
,[CMS_UPDATE_DATE_TIME] datetime
  
);
INSERT INTO "TB_CODE_MASTER" VALUES(1,'EXCEPTION_STATUS','ALL','全部',1036,1,'0',NULL,'Q-',1,'2009-12-03 17:26:29',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(2,'EXCEPTION_STATUS','NORMAL','正常',1037,1,'1',NULL,'QU',1,'2009-12-03 15:47:53',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(3,'EXCEPTION_STATUS','FIXED','解决',1038,1,'2',NULL,'QU',1,'2009-12-03 15:48:30',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(4,'EXCEPTION_STATUS','EXIGENT','紧急',1039,1,'3',NULL,'QU',1,'2009-12-03 15:49:08',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(5,'EXCEPTION_STATUS','INESSENTIAL','无关紧要',1040,1,'4',NULL,'QU',1,'2009-12-03 15:49:36',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(7,'LOG_CATEGORY','ALL','全部',1036,1,'0',NULL,'Q-',1,'2009-12-07 17:43:57',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(8,'LOG_CATEGORY','NORMAL','普通',1053,1,'1',NULL,'QU',1,'2009-12-07 17:43:57',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(10,'LOG_CATEGORY','EXCEPTION','异常',1005,1,'2',NULL,'QU',1,'2009-12-07 17:43:57',NULL,NULL);
INSERT INTO "TB_CODE_MASTER" VALUES(11,'LOG_CATEGORY','SYSTEM_INFO','系统信息',1054,1,'3',NULL,'QU',1,'2009-12-09 16:41:25',NULL,NULL);
CREATE TABLE "TB_EXCEPTION_MANAGER"(
[EM_EXCEPTION_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[EM_DATE_TIME] datetime NOT NULL
,[EM_TITLE] text NOT NULL
,[EM_CONTEXT] text NOT NULL
,[EM_STATUS] integer NOT NULL
,[EM_UPDATE_USER_SRNO] integer
,[EM_UPDATE_TIME] datetime
  
);
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(1,'2010-01-28 18:21:25','Cannot unsubscribe when not already subscribed','System.ArgumentException: Cannot unsubscribe when not already subscribed
   在 AspComet.Client.UnsubscribeFrom(String subscription)
   在 AspComet.MessageHandlers.MetaUnsubscribeHandler.HandleMessage(Message request)
   在 AspComet.MessagesProcessor.Process(Message message)
   在 AspComet.MessagesProcessor.Process(IEnumerable`1 messages)
   在 AspComet.MessageBus.CreateProcessorAndProcess(IEnumerable`1 messages)
   在 AspComet.MessageBus.HandleMessages(Message[] messages, CometAsyncResult asyncResult)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContextBase context, AsyncCallback callback, Object asyncState)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContext context, AsyncCallback callback, Object asyncState)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   在 System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)',1,0,'0001-01-01 00:00:00');
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(2,'2010-01-28 19:39:32','Cannot unsubscribe when not already subscribed','System.ArgumentException: Cannot unsubscribe when not already subscribed
   在 AspComet.Client.UnsubscribeFrom(String subscription)
   在 AspComet.MessageHandlers.MetaUnsubscribeHandler.HandleMessage(Message request)
   在 AspComet.MessagesProcessor.Process(Message message)
   在 AspComet.MessagesProcessor.Process(IEnumerable`1 messages)
   在 AspComet.MessageBus.CreateProcessorAndProcess(IEnumerable`1 messages)
   在 AspComet.MessageBus.HandleMessages(Message[] messages, CometAsyncResult asyncResult)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContextBase context, AsyncCallback callback, Object asyncState)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContext context, AsyncCallback callback, Object asyncState)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   在 System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)',1,0,'0001-01-01 00:00:00');
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(3,'2010-01-28 19:49:13','Cannot unsubscribe when not already subscribed','System.ArgumentException: Cannot unsubscribe when not already subscribed
   在 AspComet.Client.UnsubscribeFrom(String subscription)
   在 AspComet.MessageHandlers.MetaUnsubscribeHandler.HandleMessage(Message request)
   在 AspComet.MessagesProcessor.Process(Message message)
   在 AspComet.MessagesProcessor.Process(IEnumerable`1 messages)
   在 AspComet.MessageBus.CreateProcessorAndProcess(IEnumerable`1 messages)
   在 AspComet.MessageBus.HandleMessages(Message[] messages, CometAsyncResult asyncResult)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContextBase context, AsyncCallback callback, Object asyncState)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContext context, AsyncCallback callback, Object asyncState)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   在 System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)',1,0,'0001-01-01 00:00:00');
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(4,'2010-02-01 16:16:53','Error during serialization or deserialization using the JSON JavaScriptSerializer. The length of the string exceeds the value set on the maxJsonLength property.','System.InvalidOperationException: Error during serialization or deserialization using the JSON JavaScriptSerializer. The length of the string exceeds the value set on the maxJsonLength property.
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, StringBuilder output, SerializationFormat serializationFormat)
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, SerializationFormat serializationFormat)
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj)
   在 AspComet.MessageConverter.ToJson[TModel](TModel model)
   在 AspComet.Transports.LongPollingTransport.SendMessages(HttpResponseBase response, IEnumerable`1 messages)
   在 AspComet.CometAsyncResult.SendAwaitingMessages()
   在 AspComet.CometHttpHandler.EndProcessRequest(IAsyncResult result)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)',1,0,'0001-01-01 00:00:00');
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(5,'2010-02-01 16:16:54','Error during serialization or deserialization using the JSON JavaScriptSerializer. The length of the string exceeds the value set on the maxJsonLength property.','System.InvalidOperationException: Error during serialization or deserialization using the JSON JavaScriptSerializer. The length of the string exceeds the value set on the maxJsonLength property.
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, StringBuilder output, SerializationFormat serializationFormat)
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, SerializationFormat serializationFormat)
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj)
   在 AspComet.MessageConverter.ToJson[TModel](TModel model)
   在 AspComet.Transports.LongPollingTransport.SendMessages(HttpResponseBase response, IEnumerable`1 messages)
   在 AspComet.CometAsyncResult.SendAwaitingMessages()
   在 AspComet.CometHttpHandler.EndProcessRequest(IAsyncResult result)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)',1,0,'0001-01-01 00:00:00');
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(6,'2010-02-01 16:24:03','Error during serialization or deserialization using the JSON JavaScriptSerializer. The length of the string exceeds the value set on the maxJsonLength property.','System.InvalidOperationException: Error during serialization or deserialization using the JSON JavaScriptSerializer. The length of the string exceeds the value set on the maxJsonLength property.
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, StringBuilder output, SerializationFormat serializationFormat)
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, SerializationFormat serializationFormat)
   在 System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj)
   在 AspComet.MessageConverter.ToJson[TModel](TModel model)
   在 AspComet.Transports.LongPollingTransport.SendMessages(HttpResponseBase response, IEnumerable`1 messages)
   在 AspComet.CometAsyncResult.SendAwaitingMessages()
   在 AspComet.CometHttpHandler.EndProcessRequest(IAsyncResult result)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.OnAsyncHandlerCompletion(IAsyncResult ar)',1,0,'0001-01-01 00:00:00');
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(7,'2010-02-01 17:41:32','Cannot unsubscribe when not already subscribed','System.ArgumentException: Cannot unsubscribe when not already subscribed
   在 AspComet.Client.UnsubscribeFrom(String subscription)
   在 AspComet.MessageHandlers.MetaUnsubscribeHandler.HandleMessage(Message request)
   在 AspComet.MessagesProcessor.Process(Message message)
   在 AspComet.MessagesProcessor.Process(IEnumerable`1 messages)
   在 AspComet.MessageBus.CreateProcessorAndProcess(IEnumerable`1 messages)
   在 AspComet.MessageBus.HandleMessages(Message[] messages, CometAsyncResult asyncResult)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContextBase context, AsyncCallback callback, Object asyncState)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContext context, AsyncCallback callback, Object asyncState)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   在 System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)',1,0,'0001-01-01 00:00:00');
INSERT INTO "TB_EXCEPTION_MANAGER" VALUES(8,'2010-02-01 17:41:44','Cannot unsubscribe when not already subscribed','System.ArgumentException: Cannot unsubscribe when not already subscribed
   在 AspComet.Client.UnsubscribeFrom(String subscription)
   在 AspComet.MessageHandlers.MetaUnsubscribeHandler.HandleMessage(Message request)
   在 AspComet.MessagesProcessor.Process(Message message)
   在 AspComet.MessagesProcessor.Process(IEnumerable`1 messages)
   在 AspComet.MessageBus.CreateProcessorAndProcess(IEnumerable`1 messages)
   在 AspComet.MessageBus.HandleMessages(Message[] messages, CometAsyncResult asyncResult)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContextBase context, AsyncCallback callback, Object asyncState)
   在 AspComet.CometHttpHandler.BeginProcessRequest(HttpContext context, AsyncCallback callback, Object asyncState)
   在 System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   在 System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)',1,0,'0001-01-01 00:00:00');
CREATE TABLE "TB_COLUMN_DATA_READER"(
[CDR_COLUMN_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[CDR_VIEW_SRNO] integer NOT NULL
,[CDR_DATA_INDEX_NAME] text NOT NULL
,[CDR_MAPPING] text
,[CDR_CREATE_USER_SRNO] integer NOT NULL
,[CDR_CREATE_DATE_TIME] datetime NOT NULL
,[CDR_UPDATE_USER_SRNO] integer
,[CDR_UPDATE_DATE_TIME] datetime
  
);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(1,1000,'jsExceptionSrno','jsExceptionSrno',1,'2009-12-17 14:29:32',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(2,1000,'jsDateTime','jsDateTime',1,'2009-12-17 14:29:45',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(3,1000,'jsTitle','jsTitle',1,'2009-12-17 14:29:48',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(4,1000,'jsExceptionStatusDesc','jsExceptionStatusDesc',1,'2009-12-17 14:30:05',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(5,1000,'jsUserSrno','jsUserSrno',1,'2009-12-17 14:30:08',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(6,1000,'jsUpdateDateTime','jsUpdateDateTime',1,'2009-12-17 14:30:30',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(7,1000,'jsExceptionStatus','jsExceptionStatus',1,'2009-12-25 09:28:31',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(8,1000,'jsContext','jsContext',1,'2009-12-25 09:28:49',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(9,1001,'jsLogFileSrno','jsLogFileSrno',1,'2010-01-21 16:25:50',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(10,1001,'jsDateTime','jsDateTime',1,'2010-01-21 16:26:09',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(11,1001,'jsLogFileName','jsLogFileName',1,'2010-01-21 16:26:43',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(12,1001,'jsLogCategoryDesc','jsLogCategoryDesc',1,'2010-01-21 16:26:56',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(13,1001,'jsLogCategory','jsLogCategory',1,'2010-01-21 16:27:40',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(14,5000,'jsSystemMessageTime','jssystemMessageTime',1,'2010-01-22 16:23:18',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(16,5000,'jsSystemMessageType','jsSystemMessageType',1,'2010-01-22 16:23:00',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(17,5000,'jsSystemMessage','jsSystemMessage',1,'2010-01-22 16:23:41',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(18,1001,'jsLogLevelDesc','jsLogLevelDesc',1,'2010-01-26 16:10:33',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(19,5000,'jsSystemMessageSrno','jsSystemMessageSrno',1,'2010-01-26 17:58:24',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(20,1002,'jsSystemMessageSrno','jsSystemMessageSrno',1,'2010-01-29 16:13:52',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(21,1002,'jsMessageTime','jsMessageTime',1,'2010-01-29 16:14:21',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(22,1002,'jsMessageTypeDesc','jsMessageTypeDesc',1,'2010-01-29 16:14:38',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(23,1002,'jsMessageLevelDesc','jsMessageLevelDesc',1,'2010-01-29 16:14:56',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(24,1002,'jsCreateUserSrno','jsCreateUserSrno',1,'2010-01-29 16:15:09',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(25,1002,'jsSystemMessage','jsSystemMessage',1,'2010-01-29 16:15:59',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(26,5000,'jsSystemMessageLevel','jsSystemMessageLevel',1,'2010-01-29 16:21:19',NULL,NULL);
INSERT INTO "TB_COLUMN_DATA_READER" VALUES(27,5000,'jsSystemMessageUser','jsSystemMessageUser',1,'2010-01-29 16:21:31',NULL,NULL);
CREATE TABLE "TB_COLUMN_MODEL"(
[CM_COLUMN_SRNO] integer UNIQUE NOT NULL
,[CM_VIEW_SRNO] integer NOT NULL
,[CM_COLUMN_NAME] text NOT NULL
,[CM_COLUMN_LANG_SRNO] integer
,[CM_COLUMN_INDEX] integer NOT NULL
,[CM_COLUMN_CATEGORY] integer NOT NULL
,[CM_COLUMN_DATA_INDEX] text NOT NULL
,[CM_COLUMN_TYPE] text
,[CM_COLUMN_WIDTH] float
,[CM_COLUMN_ALIGN] integer
,[CM_COLUMN_TOOLTIP] text
,[CM_COLUMN_CSS] text
,[CM_COLUMN_TPL] text
,[CM_COLUMN_SORTABLE] integer
,[CM_COLUMN_RESIZABLE] integer
,[CM_COLUMN_EDITABLE] integer
,[CM_COLUMN_EDITOR] text
,[CM_COLUMN_RENDERER] text
,[CM_COLUMN_SCOPE] text
,[CM_CREATE_USER_SRNO] integer NOT NULL
,[CM_CREATE_DATE_TIME] datetime NOT NULL
,[CM_UPDATE_USER_SRNO] integer
,[CM_UPDATE_DATE_TIME] datetime
  
);
INSERT INTO "TB_COLUMN_MODEL" VALUES(1,1000,'异常编号',1032,1,1,'jsExceptionSrno','integer',10.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2009-12-16 18:00:47',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(2,1000,'异常发生时间',1033,2,1,'jsDateTime','date',15.0,1,'%p',NULL,NULL,1,1,0,NULL,'mGlobalService.FormatDateTime','mGlobalService',1,'2009-12-17 14:26:19',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(3,1000,'标题',1047,3,1,'jsTitle','string',40.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2009-12-17 14:26:55',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(4,1000,'状态',1011,4,1,'jsExceptionStatusDesc','string',10.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2009-12-17 14:27:34',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(5,1000,'最终修改用户',1034,5,1,'jsUserSrno','string',10.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2009-12-17 14:28:09',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(6,1000,'最终修改时间',1035,6,1,'jsUpdateDateTime','date',15.0,1,'%p',NULL,NULL,1,1,0,NULL,'mGlobalService.FormatDateTime','mGlobalService',1,'2009-12-17 14:28:47',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(7,1001,'日志文件编号',1049,1,1,'jsLogFileSrno','integer',15.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-21 16:19:39',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(8,1001,'日志创建时间',1050,2,1,'jsDateTime','date',20.0,1,'%p',NULL,NULL,1,1,0,NULL,'mGlobalService.FormatDateTime','mGlobalService',1,'2010-01-21 16:20:25',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(9,1001,'日志文件名',1051,3,1,'jsLogFileName','string',45.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-21 16:22:24',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(10,1001,'日志类型',1052,4,1,'jsLogCategoryDesc','string',10.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-21 16:23:31',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(11,5000,'消息时间',1063,1,1,'jsSystemMessageTime','string',0.15,1,NULL,NULL,'<div ext:qtip="{jsSystemMessageTime}">{jsSystemMessageTime}</div>',0,1,0,NULL,NULL,NULL,1,'2010-01-22 16:25:00',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(12,5000,'消息类型',1064,2,1,'jsSystemMessageType','string',0.15,1,NULL,NULL,'<div ext:qtip="{jsSystemMessageType}">{jsSystemMessageType}</div>',0,1,0,NULL,NULL,NULL,1,'2010-01-22 16:27:21',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(13,5000,'系统消息',1065,3,1,'jsSystemMessage','string',0.7,1,NULL,NULL,'<div ext:qtip="{jsSystemMessage}">{jsSystemMessage}</div>',0,1,0,NULL,NULL,NULL,1,'2010-01-22 16:28:14',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(14,1001,'日志记级别',1068,5,1,'jsLogLevelDesc','string',10.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-26 16:03:56',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(15,1002,'系统消息编号',1072,1,1,'jsSystemMessageSrno','integer',10.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-29 15:55:57',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(16,1002,'系统消息时间',1073,2,1,'jsMessageTime','date',25.0,1,'%p',NULL,NULL,1,1,0,NULL,'mGlobalService.FormatDateTime','mGlobalService',1,'2010-01-29 15:56:53',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(17,1002,'系统消息类型',1074,3,1,'jsMessageTypeDesc','string',20.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-29 15:57:58',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(18,1002,'系统消息级别',1075,4,1,'jsMessageLevelDesc','string',20.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-29 15:59:25',NULL,NULL);
INSERT INTO "TB_COLUMN_MODEL" VALUES(19,1002,'用户',1013,5,1,'jsCreateUserSrno','string',25.0,1,'%p',NULL,NULL,1,1,0,NULL,NULL,NULL,1,'2010-01-29 16:00:33',NULL,NULL);
CREATE TABLE "TB_LOG_MANAGER"(
[LM_LOG_FILE_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[LM_DATE_TIME] datetime NOT NULL
,[LM_CATEGORY] integer NOT NULL
,[LM_LEVEL] integer NOT NULL
,[LM_LOG_FILE_NAME] text
  
);
CREATE TABLE "TB_MENU_MANAGER"(
[MM_MENU_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[MM_MENU_DISPLAY_INDEX] integer NOT NULL
,[MM_MENU_DESC] text NOT NULL
,[MM_MENU_LANG_SRNO] integer NOT NULL
,[MM_PARENT_SRNO] integer NOT NULL
,[MM_IS_LEAF]  NOT NULL
,[MM_MENU_CATEGORY] integer NOT NULL
,[MM_URL] text
,[MM_TARGET] text
,[MM_CREATE_USER_SRNO] integer NOT NULL
,[MM_CREATE_DATE_TIME] datetime NOT NULL
,[MM_UPDATE_USER_SRNO] integer
,[MM_UPDATE_DATE_TIME] datetime
  
);
INSERT INTO "TB_MENU_MANAGER" VALUES(1,1,'管理中心',1024,0,'0',1,'ManageSubFrame.aspx','_InnerPage',1,'2009-11-20 09:41:41',NULL,NULL);
INSERT INTO "TB_MENU_MANAGER" VALUES(2,2,'管理中心首页',1025,1,'1',1,'ManageSubFrame.aspx','_InnerPage',1,'2009-12-02 12:23:19',NULL,NULL);
INSERT INTO "TB_MENU_MANAGER" VALUES(3,3,'用户管理',1026,1,'1',1,'WebForm1.aspx','_InnerPage',1,'2009-11-20 09:42:19',NULL,NULL);
INSERT INTO "TB_MENU_MANAGER" VALUES(4,4,'日志管理',1027,1,'1',1,'LogManager/LogManager.aspx','_InnerPage',1,'2009-11-20 09:43:01',NULL,NULL);
INSERT INTO "TB_MENU_MANAGER" VALUES(5,5,'异常管理',1028,1,'1',1,'ExceptionManager/ExceptionManager.aspx','_InnerPage',1,'2009-11-23 14:18:00',NULL,NULL);
INSERT INTO "TB_MENU_MANAGER" VALUES(6,10,'系统设置',1029,1,'0',1,'WebForm1.aspx','_InnerPage',1,'2009-11-23 14:19:38',NULL,NULL);
INSERT INTO "TB_MENU_MANAGER" VALUES(7,11,'参数设置',1030,6,'1',1,'WebForm1.aspx','_InnerPage',1,'2009-11-23 14:20:18',NULL,NULL);
INSERT INTO "TB_MENU_MANAGER" VALUES(8,6,'系统消息监控',1071,1,'1',1,'SystemMessageMonitor/SystemMessageMonitor.aspx','_InnerPage',1,'2010-01-28 19:34:19',NULL,NULL);
CREATE TABLE "TB_SYSTEM_MESSAGE"(
[SM_SYSTEM_MESSAGE_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[SM_MESSAGE_TIME] datetime NOT NULL
,[SM_MESSAGE_TYPE] integer NOT NULL
,[SM_SYSTEM_MESSAGE] text NOT NULL
,[SM_MESSAGE_LEVEL] integer NOT NULL
,[SM_CREATE_USER_SRNO] integer NOT NULL
  
);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(1,'2010-02-01 18:02:26',4,' Response Context : {&quot;jsMessageStatusIndc&quot;:0,&quot;jsRequestIndc&quot;:1005,&quot;jsMessage&quot;:&quot;&quot;,&quot;jsMessageBody&quot;: [
[{&quot;id&quot;:&quot;jsSystemMessageSrno&quot;,&quot;header&quot;:&quot;系统消息编号&quot;,&quot;dataIndex&quot;:&quot;jsSystemMessageSrno&quot;,&quot;type&quot;:&quot;integer&quot;,&quot;width&quot;:10.0,&quot;align&quot;:&quot;left&quot;,&quot;tooltip&quot;:&quot;系统消息编号&quot;,&quot;css&quot;:&quot;&quot;,&quot;sortable&quot;:true,&quot;resizable&quot;:true,&quot;editable&quot;:false,&quot;editor&quot;:&quot;&quot;},{&quot;id&quot;:&quot;jsMessageTime&quot;,&quot;header&quot;:&quot;系统消息时间&quot;,&quot;dataIndex&quot;:&quot;jsMessageTime&quot;,&quot;type&quot;:&quot;date&quot;,&quot;width&quot;:25.0,&quot;align&quot;:&quot;left&quot;,&quot;tooltip&quot;:&quot;系统消息时间&quot;,&quot;css&quot;:&quot;&quot;,&quot;sortable&quot;:true,&quot;resizable&quot;:true,&quot;editable&quot;: ... (消息过长，系统截取了前 500 个字符)',1,1);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(2,'2010-02-01 18:02:26',4,' Response Status : 200 OK',1,1);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(3,'2010-02-01 18:02:26',4,' Response Context : {&quot;jsMessageStatusIndc&quot;:0,&quot;jsRequestIndc&quot;:1008,&quot;jsMessage&quot;:&quot;查询了 2 条数据!&quot;,&quot;jsMessageBody&quot;: [
{identifier:&quot;jsSystemMessageSrno&quot;,totalProperty:2,items:[{&quot;jsSystemMessageSrno&quot;:1,&quot;jsMessageTime&quot;:new Date(1265018546000),&quot;jsMessageType&quot;:4,&quot;jsMessageTypeDesc&quot;:&quot;调试信息&quot;,&quot;jsSystemMessage&quot;:&quot; Response Context : {&quot;jsMessageStatusIndc&quot;:0,&quot;jsRequestIndc&quot;:1005,&quot;jsMessage&quot;:&quot;&quot;,&quot;jsMessageBody&quot;: [\r\n[{&quot;id&quot;:&quot;jsSystemMessageSrno&quot;,& ... (消息过长，系统截取了前 500 个字符)',1,1);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(4,'2010-02-01 18:02:26',4,' Response Status : 200 OK',1,1);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(5,'2010-02-01 18:03:06',4,' Response Context : {&quot;jsMessageStatusIndc&quot;:0,&quot;jsRequestIndc&quot;:1005,&quot;jsMessage&quot;:&quot;&quot;,&quot;jsMessageBody&quot;: [
[{&quot;id&quot;:&quot;jsSystemMessageSrno&quot;,&quot;header&quot;:&quot;系统消息编号&quot;,&quot;dataIndex&quot;:&quot;jsSystemMessageSrno&quot;,&quot;type&quot;:&quot;integer&quot;,&quot;width&quot;:10.0,&quot;align&quot;:&quot;left&quot;,&quot;tooltip&quot;:&quot;系统消息编号&quot;,&quot;css&quot;:&quot;&quot;,&quot;sortable&quot;:true,&quot;resizable&quot;:true,&quot;editable&quot;:false,&quot;editor&quot;:&quot;&quot;},{&quot;id&quot;:&quot;jsMessageTime&quot;,&quot;header&quot;:&quot;系统消息时间&quot;,&quot;dataIndex&quot;:&quot;jsMessageTime&quot;,&quot;type&quot;:&quot;date&quot;,&quot;width&quot;:25.0,&quot;align&quot;:&quot;left&quot;,&quot;tooltip&quot;:&quot;系统消息时间&quot;,&quot;css&quot;:&quot;&quot;,&quot;sortable&quot;:true,&quot;resizable&quot;:true,&quot;editable&quot;: ... (消息过长，系统截取了前 500 个字符)',1,1);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(6,'2010-02-01 18:03:06',4,' Response Status : 200 OK',1,1);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(7,'2010-02-01 18:03:07',4,' Response Context : {&quot;jsMessageStatusIndc&quot;:0,&quot;jsRequestIndc&quot;:1008,&quot;jsMessage&quot;:&quot;查询了 6 条数据!&quot;,&quot;jsMessageBody&quot;: [
{identifier:&quot;jsSystemMessageSrno&quot;,totalProperty:6,items:[{&quot;jsSystemMessageSrno&quot;:1,&quot;jsMessageTime&quot;:new Date(1265018546000),&quot;jsMessageType&quot;:4,&quot;jsMessageTypeDesc&quot;:&quot;调试信息&quot;,&quot;jsSystemMessage&quot;:&quot; Response Context : {&quot;jsMessageStatusIndc&quot;:0,&quot;jsRequestIndc&quot;:1005,&quot;jsMessage&quot;:&quot;&quot;,&quot;jsMessageBody&quot;: [\r\n[{&quot;id&quot;:&quot;jsSystemMessageSrno&quot;,& ... (消息过长，系统截取了前 500 个字符)',1,1);
INSERT INTO "TB_SYSTEM_MESSAGE" VALUES(8,'2010-02-01 18:03:07',4,' Response Status : 200 OK',1,1);
CREATE TABLE "TB_PARAMETER_MASTER"(
[PM_PARAMETER_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[PM_PARAMETER_DESC] text UNIQUE NOT NULL
,[PM_PARAMETER_NAME] text
,[PM_PARAMETER_NAME_LANG_SRNO] integer
,[PM_PARAMETER_CATEGORY] integer NOT NULL
,[PM_VALUE_TYPE] integer NOT NULL
,[PM_VALUE] text NOT NULL
,[PM_VALUE_LANG_SRNO] integer
,[PM_OPTIONS] text
,[PM_CREATE_USER_SRNO] integer NOT NULL
,[PM_CREATE_DATE_TIME] datetime NOT NULL
,[PM_UPDATE_USER_SRNO] integer
,[PM_UPDATE_DATE_TIME] datetime
  
);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(1,'WEB_SITE_NAME','站点名称',NULL,1,2,'管理中心',1024,NULL,1,'2009-11-20 13:38:25',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(2,'SITE_MAP_SEPARATOR_CHAR','站点导航分隔字符',NULL,1,2,'>',NULL,NULL,1,'2009-11-20 17:23:24',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(3,'DOJO_LIB_PATH','Dojo库路径',NULL,1,2,'http://ajax.googleapis.com/ajax/libs/dojo/1.4/',NULL,NULL,1,'2009-11-27 09:33:19',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(4,'RESPONSE_CONENT_TYPE','回复数据类型',NULL,1,2,'text/html',NULL,NULL,1,'2009-12-01 14:12:00',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(5,'LANGUAGE','语言',NULL,1,5,'1',NULL,'|zh_CN|zh_TW|en',1,'2009-12-02 14:40:01',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(6,'DATA_SAVED_TIME','数据默认保存时间',NULL,1,1,'10',NULL,NULL,1,'2009-12-07 14:30:50',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(7,'WEB_ROOT_SITE','网站根地址',NULL,1,2,'http://localhost:63002',NULL,NULL,1,'2009-12-09 17:28:38',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(8,'EXTJS_THEMES','ExtJs皮肤主题',NULL,1,5,'1',NULL,'|blue|gray',1,'2009-12-11 16:36:22',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(9,'COMETD_MAX_CONNECTION','cometD最大连接数',NULL,1,1,'99',NULL,NULL,1,'2010-01-24 00:41:09',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(10,'LOG_LEVEL','日志记录级别',NULL,1,5,'3',NULL,'0|1|2|3',1,'2010-01-26 15:29:16',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(11,'SYSTEM_MESSAGE_LEVEL','系统消息显示级别',NULL,1,5,'1',NULL,'0|1|2|3',1,'2010-01-26 16:40:59',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(12,'SYSTEM_MESSAGE_VIEWER','是否允许查看详细系统消息',NULL,1,6,'1',NULL,NULL,1,'2010-01-26 17:43:18',NULL,NULL);
INSERT INTO "TB_PARAMETER_MASTER" VALUES(13,'SYSTEM_MESSAGE_CHAR_COUNT','系统消息最大字符数',NULL,1,1,'500',NULL,NULL,1,'2010-02-01 17:17:15',NULL,NULL);
COMMIT;
