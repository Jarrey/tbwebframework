/*
    This uses the libraries from cometd-javascript 1.0.0
    http://downloads.dojotoolkit.org/cometd/
    Modified from Aspcomet project sample - chat.js
    http://aspcomet.googlecode.com/svn/trunk/src/Samples/Chat/chat.js
    Jar.bob@gmail.com on 2010-01-22
*/

var cometDConfig = function(){
    var _subscription = null;
    var _metaSubscriptions = []; //订阅对象集合
    var _cometd;                 //cometD对象
    var _userId = "";            //用户编号
    var _channelName = "";       //频道名
    var _disconnecting = false;  //断开标识
    var _connected = false;      //连接标识

    return {
      //初始化类
      init: function(configuration){

        var _maxConnections = configuration.maxConnections || 2;
        var _backoffIncrement = configuration.backoffIncrement || 1000;
        var _maxBackoff = configuration.maxBackoff || 60000;
        var _logLevel = configuration.logLevel || 'info';
        var _reverseIncomingExtensions = configuration.reverseIncomingExtensions !== false;
        var _maxNetworkDelay = configuration.maxNetworkDelay || 10000;
        var _requestHeaders = configuration.requestHeaders || {};
        
        // Store the initialisation parameters    
        _cometd = configuration.cometd;
        _userId = configuration.userId;
        _channelName = configuration.channelName;
        
        // Subscribe to the meta channels
        _metaSubscribe();

        // Configure the connection
        _cometd.configure({url: 'cometdServer.do', 
                           maxConnection: _maxConnections, 
                           backoffIncrement: _backoffIncrement,
                           maxBackoff: _maxBackoff,
                           logLevel: _reverseIncomingExtensions,
                           reverseIncomingExtensions: _reverseIncomingExtensions,
                           maxNetworkDelay: _maxNetworkDelay,
                           requestHeaders: _requestHeaders
                         });

        // And handshake - with authentication, as described at
        // http://cometd.org/documentation/howtos/authentication
        _cometd.handshake({
          ext: {
            authentication: {user: _userId}
          }
        });
      },
      
      leave: function(){
        
        if (!_userId) return;
        
        _cometd.startBatch();
        _cometd.publish('/' + _channelName, {
          jsMessageTime: Ext.util.Format.date(new Date(), CNST_DATE_FORMAT + " " + CNST_TIME_FORMAT),
          jsMessageType: GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR,
          jsMessageBody: {
            jsMessage: '&quot;' + _userId + '&quot; ' + GLOBAL_MESSAGE._js1008 + " - " + _channelName
          }
        });
        _unsubscribe();
        _cometd.endBatch();
        
        _cometd.disconnect();

        _metaUnsubscribe();
        _disconnecting = true;
      }

    };

    //与频道注销订阅关系
    function _unsubscribe(){
      if (_subscription) _cometd.unsubscribe(_subscription);
      _subscription = null;
    };
    
    //与频道建立订阅关系
    function _subscribe(){
        _unsubscribe();
        _subscription = _cometd.subscribe('/' + _channelName, this, handleIncomingMessage);
    };
    
    //与cometD系统频道注销订阅关系
    function _metaUnsubscribe(){
      for (var subNumber = 0; subNumber < _metaSubscriptions.length; subNumber ++){
        _cometd.removeListener(_metaSubscriptions[subNumber]);
      }
      _metaSubscriptions = [];
    };
    
    //与cometD系统频道建立订阅关系
    function _metaSubscribe(){
      _metaUnsubscribe();
      _metaSubscriptions.push(_cometd.addListener('/meta/handshake', this, _metaHandshake));
      _metaSubscriptions.push(_cometd.addListener('/meta/connect', this, _metaConnect));
      _metaSubscriptions.push(_cometd.addListener('/meta/unsuccessful', this, _metaUnsuccessful));
    };
    
    //与服务器进行握手
    function _metaHandshake(message){
      _connected = false;
      _chatSubscription = null;
      handleIncomingMessage({
        data: {
          jsMessageTime: Ext.util.Format.date(new Date(), CNST_DATE_FORMAT + " " + CNST_TIME_FORMAT),
          jsMessageType: GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR,
          jsMessageBody: {
            jsMessage: GLOBAL_MESSAGE._js1010 + " " + (message.successful?GLOBAL_WORD._js1011:GLOBAL_WORD._js1012)
          }
        }
      });
    };

    //与服务器建立连接
    function _connectionEstablished(){
      handleIncomingMessage({
        data: {
          jsMessageTime: Ext.util.Format.date(new Date(), CNST_DATE_FORMAT + " " + CNST_TIME_FORMAT),
          jsMessageType: GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR,
          jsMessageBody: {
            jsMessage: GLOBAL_MESSAGE._js1011
          }
        }
      });
      _cometd.startBatch();
      _subscribe();
      _cometd.publish('/' + _channelName,{
        jsMessageTime: Ext.util.Format.date(new Date(), CNST_DATE_FORMAT + " " + CNST_TIME_FORMAT),
        jsMessageType: GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR,
        jsMessageBody: {
          jsMessage: '&quot;' + _userId + '&quot; ' + GLOBAL_MESSAGE._js1012 + " - " + _channelName
        }
      });
      _cometd.endBatch();
    }

    //链接异常
    function _connectionBroken(){
      handleIncomingMessage({
        data: {
          jsMessageTime: Ext.util.Format.date(new Date(), CNST_DATE_FORMAT + " " + CNST_TIME_FORMAT),
          jsMessageType: GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR,
          jsMessageBody: {
            jsMessage: GLOBAL_MESSAGE._js1013
          }
        }
      });
    };

    //链接关闭
    function _connectionClosed(){
      handleIncomingMessage({
        data: {
          jsMessageTime: Ext.util.Format.date(new Date(), CNST_DATE_FORMAT + " " + CNST_TIME_FORMAT),
          jsMessageType: GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR,
          jsMessageBody: {
            jsMessage: GLOBAL_MESSAGE._js1014
          }
        }
      });
    };

    //链接服务器
    function _metaConnect(message){
      if (_disconnecting) {
        _connected = false;
        _connectionClosed();
      }else {
        var wasConnected = _connected;
        _connected = message.successful === true;
        if (!wasConnected && _connected) {
          _connectionEstablished();
        }
        else if (wasConnected && !_connected) {
          _connectionBroken();
        }
      }
    };

    //失败处理函数
    function _metaUnsuccessful(message){
      _connected = false;
      handleIncomingMessage({
        data: {
          jsMessageTime: Ext.util.Format.date(new Date(), CNST_DATE_FORMAT + " " + CNST_TIME_FORMAT),
          jsMessageType: GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR,
          jsMessageBody: {
            jsMessage: GLOBAL_MESSAGE._js1015 + " " + message.channel + " " + GLOBAL_WORD._js1012 + ": " + (message.error == undefined ? GLOBAL_MESSAGE._js1016 : message.error)
          }
        }
      });
    };

}();
