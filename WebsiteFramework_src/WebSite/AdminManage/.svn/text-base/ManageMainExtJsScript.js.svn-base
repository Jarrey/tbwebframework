// ManageMain ExtJs JavaScript

// 填充图片的本地引用
Ext.BLANK_IMAGE_URL = '../Extjs_lib/resources/images/default/s.gif';
Ext.onReady(function(){Ext.QuickTips.init();}); 

// 创建命名空间
Ext.namespace('ManageMain');

// 创建应用程序
ManageMain.app = function() {

  // 私有变量
  var mRequest                 = new jsClsRequest("ManagerMainServer.aspx"); //Ajax请求对象
  var mndMenuRootNode          = null; //菜单根节点
  var mgrpWindowsGroup         = new Ext.WindowGroup(); //系统消息查看窗体组
  
  // 私有函数
  // 初始化控件
  var initControlsByLocal = function() {
    mpnlTopHeaderPanel = new Ext.BoxComponent({region: 'north',height: 27,el: 'pnlHeader',margins: '0 0 3 0'});
    mpnlMenuTreePanel = new Ext.tree.TreePanel({
      title: GLOBAL_WORD._js1007,
      animate: true,
      autoScroll: true,
      containerScroll: true,
      border: false,
      loader: new Ext.tree.TreeLoader(),
      root: new Ext.tree.TreeNode({text: ''})
    });
    mpnlToolPanel = new Ext.Panel({title: GLOBAL_WORD._js1008,html: '<p>Panel content!</p>',border: false});
    mpnlLeftPanel = new Ext.Panel({
      title: GLOBAL_WORD._js1000,
      layout: 'accordion',
      split:true,
      region: 'west',
      width: 200,
      minSize: 100,
      maxSize: 400,
      collapsible: true,
      margins: '0 0 0 5',
      layoutConfig: {animate: true},
      items: [mpnlMenuTreePanel,mpnlToolPanel]
    });
    mpnlCenterContextPanel = new Ext.Panel({
      region: 'center',
      contentEl: 'pnlContent',
      deferredRender:false,
      border : false,
      margins: '0 5 0 0'
    });
    mpnlBottomSysmsgPanel = new Ext.Panel({
      region: 'south',
      layout: 'fit',
      split: true,
      height: 100,
      minSize: 50,
      maxSize: 300,
      collapsible: true,
      layoutConfig: {animate: true},
      title: GLOBAL_WORD._js1009 + function(){if (PARAMS.SYSTEM_MESSAGE_VIEWER){return " " + mGlobalService.FormatString(MSGS._js1000,"color:red;font-weight:normal;font-size:10px");}else{return "";}}(),
      margins: '0 0 0 0'
    });
    mviwBodyViewport = new Ext.Viewport({
      layout: 'border',
      items: [mpnlTopHeaderPanel,mpnlBottomSysmsgPanel,mpnlLeftPanel,mpnlCenterContextPanel]
    });
  };
  
  var initControlsByServer = function(){
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_INIT_MENU,
       prMenuCategory: 1},
      function(response){
        mndMenuRootNode = new Ext.tree.AsyncTreeNode(Ext.util.JSON.decode(response.responseText).jsMessageBody[0]);
        mpnlMenuTreePanel.setRootNode(mndMenuRootNode);
        mpnlMenuTreePanel.render();
        mndMenuRootNode.expand();
      }
    );
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_INIT_LST_VIEW,
       prListViewSrno: GLOBAL_GRID_LIST_VIEW_SRNO.GGL_SYSTEM_MESSAGE,
       prListViewCategory: 1}, 
      function(response){
        var responseData = Ext.util.JSON.decode(response.responseText);
        mdsStoreSystemMessage = new Ext.data.Store({
          proxy: new Ext.data.MemoryProxy(null),
          reader: new Ext.data.ArrayReader({},responseData.jsMessageBody[1])
        });
        this.mlstSystemMessage = new Ext.list.ListView({
          id: "lst_sysmsg",
          autoScroll: true,
          reserveScrollOffset: true,
          multiSelect: false,
          columnSort: false,
          store: mdsStoreSystemMessage,
          columns: responseData.jsMessageBody[0],
          anchor: '100% 100%',
          hideHeaders: false,
          listeners: {
            'dblclick': mEvtListViewSystemMessage_OnDoubleClick,
            scope: this
          }
        });
        this.mpnlBottomSysmsgPanel.add(this.mlstSystemMessage);
        this.mpnlBottomSysmsgPanel.doLayout();
        // Initialise the SystemMessage - this will take the Dojo comet object, 
        // handshake with the server
        // and then subscribe to the /SystemMessage channel
        cometDConfig.init({cometd: dojox.cometd, 
                           userId: "foobar", 
                           channelName: 'SystemMessage',
                           maxConnections: PARAMS._js1002
                         });
      }
    );
  };
  
  //控件事件
  //双击网格查看消息事件
  var mEvtListViewSystemMessage_OnDoubleClick = function(DataView,index,node,e){
    if (PARAMS.SYSTEM_MESSAGE_VIEWER == false) return;
    var rowData = mdsStoreSystemMessage.getAt(index).data;
    var winId = 'winSysMsgViewer_' + rowData.jsSystemMessageSrno;
    if (mgrpWindowsGroup.get(winId) == undefined){
      var mwinSysMsgViewer = new Ext.Window({
        id: winId,
        width: 350,
        height: 250,
        title: GLOBAL_WORD._js1009 + '-' + rowData.jsSystemMessageTime + ' ' + rowData.jsSystemMessageType,
        maximizable: true,
        closeAction: 'close',
        constrainHeader: true,
        resizeble: true,
        modal: false,
        buttonAlign: 'left',
        buttons: [{text: GLOBAL_WORD._js1005, handler: function(Button,e){mwinSysMsgViewer.close();mwinSysMsgViewer = null;}}],
        autoScroll: true,
        html: rowData.jsSystemMessage,
        margins: '3 3 3 3',
        padding: '3 3 3 3',
        manager: mgrpWindowsGroup
      });
      mwinSysMsgViewer.show();
    }else{
      Ext.toaster.show({css: "color:red"},GLOBAL_MESSAGE._js1007);
      //Ext.MessageBox.alert(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1007);
      return;
    };
  };
  

  // 公共空间
  return {
    // 公共的属性
    mviwBodyViewport          : null, //基础面板
    mpnlLeftPanel             : null, //左侧伸缩面板
    mpnlCenterContextPanel    : null, //中间内容面板
    mpnlBottomSysmsgPanel     : null, //下部面板
    mpnlTopHeaderPanel        : null, //上部面板
    mpnlMenuTreePanel         : null, //菜单面板
    mpnlToolPanel             : null, //工具面板
    mlstSystemMessage         : null, //系统消息列表
    mdsStoreSystemMessage     : null, //系统消息实时数据源
    
    // 公共方法
    //初始化页面
    init: function(){
      initControlsByLocal();
      initControlsByServer();
      // Ensure we disconnect appropriately
      dojo.addOnUnload(dojox.cometd, cometDConfig.leave);
    },
    
    //cometD服务回调处理函数
    //comet : 消息体
    handleIncomingMessage: function(comet){
      var dataRecord = null;
      if (comet.data.jsMessageType == GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR){
        dataRecord = new mdsStoreSystemMessage.recordType({
          jsSystemMessageTime: comet.data.jsMessageTime,
          jsSystemMessageType: mGlobalService.FormatString(GLOBAL_MESSAGE._js1009,"color:blue"),
          jsSystemMessage: comet.data.jsMessageBody.jsMessage
        });
      }else if (comet.data.jsMessageType == GLOBAL_SERVER_SYSTEM_MESSAGE_INDICATOR){
        dataRecord = new mdsStoreSystemMessage.recordType({
          jsSystemMessageTime: comet.data.jsMessageBody.jsSystemMessageTime,
          jsSystemMessageType: mGlobalService.FormatString(comet.data.jsMessageBody.jsSystemMessageType,"color:green"),
          jsSystemMessage: comet.data.jsMessageBody.jsSystemMessage
        });
      }
      mdsStoreSystemMessage.insert(0,dataRecord);
      mdsStoreSystemMessage.load();
    }
  };
}();
Ext.onReady(ManageMain.app.init, ManageMain.app);
