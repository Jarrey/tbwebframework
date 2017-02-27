// Author  : jar.bob@gmail.com
// Date    : 2010/1/29 15:34:14
// Synopsis: The ExtJs JavaScript for System Message Monitor

// 填充图片的本地引用
Ext.BLANK_IMAGE_URL = '../../Extjs_lib/resources/images/default/s.gif';
Ext.onReady(function(){Ext.QuickTips.init()}); 

// 创建命名空间
Ext.namespace('SystemMessageMonitor');

// 创建应用程序
SystemMessageMonitor.app = function() {
  
  // 私有变量
  var mRequest                     = new jsClsRequest("SystemMessageMonitorServer.aspx"); //Ajax请求对象
  var mdsStoreSystemMessage        = null; //Grid数据源
  var mctlExpander                 = null;
  var mctlGridFilter               = null; //Grid过滤器 
  var mgrpWindowsGroup             = new Ext.WindowGroup(); //系统消息查看窗体组
    
  // 私有函数
  // 初始化
  var initControlsByLocal = function(){
  
    //面板初始化
    this.mpnlGridPanel = new Ext.Panel({
      layout: 'anchor',
      title: SiteMap,
      frame: true
    });
    this.mviwBodyViewport = new Ext.Viewport({
      layout: 'fit',
      items:[this.mpnlGridPanel]
    });
    this.mctlExpander = new Ext.ux.grid.RowExpander({
      tpl : new Ext.Template(
        '<p><b>',
        LANG._js1000,
        ':</b></p><p style=\'margin-left: 15px;margin-right: 15px;\'>{jsSystemMessage}</p>'
      )
    });
  };
  
  //向服务器请求控件结构数据
  var initControlsByServer = function(){
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_INIT_GRIDVIEW,
       prGirdViewSrno: GLOBAL_GRID_LIST_VIEW_SRNO.GGL_SYSTEM_MESSAGE_GRID_VIEW,
       prGridViewCategory: 1}, 
      function(response){
        var responseData = Ext.util.JSON.decode(response.responseText);
        responseData.jsMessageBody[0].unshift(this.mctlExpander);
        mdsStoreSystemMessage = new Ext.data.Store({
          proxy: new Ext.data.PagingMemoryProxy(mRequest.BlankJsonData),
          reader: new Ext.data.JsonReader(mRequest.JsonReaderConfig,responseData.jsMessageBody[1])
        });
        this.mctlGridFilter = new Ext.ux.grid.GridFilters({
          encode: false, 
          local: true,   
          filters: responseData.jsMessageBody[2]
        });
        this.mgrdSysMsgGrid = new Ext.grid.GridPanel({
          stripeRows: true,
          store: mdsStoreSystemMessage,
          cm: new Ext.grid.ColumnModel({
            columns: responseData.jsMessageBody[0],
            defaults: {
              filterable: true
            }
          }),
          sm: new Ext.grid.RowSelectionModel({singleSelect: true}),
          anchor: '100% 100%',
          loadMask: true,
          border : true,
          viewConfig: {forceFit: true},
          bbar: new Ext.PagingToolbar({
            pageSize: 30,
            store: mdsStoreSystemMessage,
            displayInfo: true
          }),
          tbar: new Ext.Toolbar({
            items: [
              {
                xtype: 'button', text: LANG._js1001, tooltip: LANG._js1001, iconCls: 'silk_table_save', enableToggle: undefined,
                menu: {
                  items: [
                    {
                      text: GLOBAL_WORD._js1013, iconCls: "silk_page_excel", 
                      handler: function(){  
                        var vExportContent = mgrdSysMsgGrid.getExcelXml();  
                        if (Ext.isIE6 || Ext.isIE7 || Ext.isIE8 || Ext.isSafari || Ext.isSafari2 || Ext.isSafari3 || Ext.isSafari4) {  
                          if (! Ext.fly('frmDummy')) {  
                            var frm = document.createElement('form');  
                            frm.id = 'frmDummy';  
                            frm.name = id;  
                            frm.className = 'x-hidden';  
                            document.body.appendChild(frm);  
                          }  
                            Ext.Ajax.request({  
                              url: '/exportexcel.php',  
                              method: 'POST',  
                              form: Ext.fly('frmDummy'),  
                              callback: function(o, s, r) {  
                                  //alert(r.responseText);  
                              },  
                              isUpload: true,  
                              params: {exportContent: vExportContent}  
                          })  
                        }else{  
                          document.location = 'data:application/vnd.ms-excel;base64,' + Base64.encode(vExportContent);  
                        }
                      },
                      scope: this
                    },
                    {text: GLOBAL_WORD._js1014, iconCls: "silk_page"}
                  ]
                }
              },
              {xtype: 'button', text: LANG._js1002, tooltip: LANG._js1002, iconCls: 'silk_printer'},
              '-',
              {xtype: 'button', text: LANG._js1005, tooltip: LANG._js1005, iconCls: 'silk_arrow_refresh', handler: mFnPopulateGrid, scope: this},
              {xtype: 'button', text: LANG._js1003, tooltip: LANG._js1003, iconCls: 'silk_delete', handler: mEvtCmdDeleteAll_OnClick, scope: this},
              '->',
              {xtype: 'label', text: MSGS._js1000, style: {color: 'red'}}
            ]
          }),
          listeners: {
            'rowdblclick': mEvtGridViewSystemMessage_OnDoubleClick,
            scope: this
          },
          plugins: [this.mctlExpander,this.mctlGridFilter]
        });
        this.mpnlGridPanel.add(this.mgrdSysMsgGrid);
        this.mpnlGridPanel.doLayout();
        mFnPopulateGrid();
      }
    );
  };
  
  //控件事件
  //删除全部按钮
  var mEvtCmdDeleteAll_OnClick = function(Button,e){
    Ext.MessageBox.confirm(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1003,
      function(btn){
        if (btn == 'yes'){
          mRequest.RequestToServer(
            {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_DELETEALL},
             mFnDeleteAllMessage
          );
        }else{return;};
      }
    );
  };
  //双击网格查看消息事件
  var mEvtGridViewSystemMessage_OnDoubleClick = function(DataView,rowIndex,e){
    var rowData = mdsStoreSystemMessage.getAt(rowIndex).data;
    var winId = 'winSysMsgMonitorViewer_' + rowData.jsSystemMessageSrno;
    if (mgrpWindowsGroup.get(winId) == undefined){
      var mwinSysMsgViewer = new Ext.Window({
        id: winId,
        width: 550,
        height: 250,
        title: GLOBAL_WORD._js1009 + ' - ' + mGlobalService.FormatDateTime(rowData.jsMessageTime) + ' [' + rowData.jsMessageTypeDesc + '] - [' + rowData.jsMessageLevelDesc + ']',
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
      return;
    };
  };
    
  //私有方法
  //查询并载入所有系统消息
  var mFnPopulateGrid = function(){
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_SEARCHALL}, 
      function(response){
        var responseJsonData = Ext.util.JSON.decode(response.responseText);
        if (mRequest.ValidateResponse(responseJsonData)){
          var mjsonDataGrid = responseJsonData.jsMessageBody[0];
          if (mjsonDataGrid != null){
            mdsStoreSystemMessage.proxy = new Ext.data.PagingMemoryProxy(mjsonDataGrid);
          }else{
            mdsStoreSystemMessage.proxy = new Ext.data.PagingMemoryProxy(mRequest.BlankJsonData);
          };
          mdsStoreSystemMessage.load({params: {start: 0, limit: 30}});
        };
        Ext.toaster.show({},responseJsonData.jsMessage);
      }
    );
  };
  //删除所有记录
  var mFnDeleteAllMessage = function(response){
    var responseJsonData = Ext.util.JSON.decode(response.responseText);
    if (mRequest.ValidateResponse(responseJsonData)){
      mdsStoreSystemMessage.removeAll();
      mgrdSysMsgGrid.getBottomToolbar().updateInfo();
    }
    Ext.toaster.show({},responseJsonData.jsMessage);
  };
  
  // 公共空间
  return {
    // 公共属性
    mviwBodyViewport              : null, //基础面板
    mgrdSysMsgGrid                : null, //系统消息Grid
    mpnlGridPanel                 : null, //表格面板
    
    // 公共方法
    init: function(){
      initControlsByLocal();
      initControlsByServer();
    }
  };
}();
Ext.onReady(SystemMessageMonitor.app.init, SystemMessageMonitor.app);