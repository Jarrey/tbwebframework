// Log Manager ExtJs JavaScript

// 填充图片的本地引用
Ext.BLANK_IMAGE_URL = '../../Extjs_lib/resources/images/default/s.gif';
Ext.onReady(function(){Ext.QuickTips.init()}); 

// 创建命名空间
Ext.namespace('LogManager');

// 创建应用程序
LogManager.app = function() {

  // 私有变量
  var mRequest                     = new jsClsRequest("LogManagerServer.aspx"); //Ajax请求对象
  var mdsStoreGrid                 = null; //Grid数据源
  var mdsLogTypeComboBox           = null; //日志类型ComoBox数据源
  var mgrpWindowsGroup             = new Ext.WindowGroup(); //日志查看窗体组
  
  // 私有函数
  // 初始化
  var initControlsByLocal = function(){
    //输入控件初始化
    this.mtxtFromDate = new Ext.form.DateField({
      fieldLabel: LANG._js1001,
      emptyText: LANG._js1009,
      format: PARAMS._js1000,
      allowBlank: false,
      anchor: '95%',
      value: new Date(),
      listeners: {
        'change': function(field,newValue,oldValue){
          this.mtxtToDate.setMinValue(newValue);
        },
        scope: this
      }
    });
    this.mtxtToDate = new Ext.form.DateField({
      fieldLabel: LANG._js1002,
      emptyText: LANG._js1009,
      format: PARAMS._js1000,
      allowBlank: false,
      anchor: '95%',
      value: new Date(),
      listeners: {
        'change': function(field,newValue,oldValue){
          this.mtxtFromDate.setMaxValue(newValue);
        },
        scope: this
      }
    });
    this.mcmbLogType = new Ext.form.ComboBox({
      fieldLabel: LANG._js1003,
      emptyText: LANG._js1009,
      displayField: GLOBAL_CODE_MASTER_DISPLAY_FIELD,
      valueField: GLOBAL_CODE_MASTER_VALUE_FIELD,
      triggerAction: 'all',
      selectOnFocus: true,
      allowBlank: false,
      resizable: true,
      anchor: '95%',
      disabled: true
    });
    
    //面板初始化
    this.mpnlSearchOperationPanel = new Ext.form.FieldSet({
      title: LANG._js1000,
      layout: 'form',
      titleCollapse: true,
      collapsible: true,
      animCollapse: true,
      anchor: '100% 20%',
      items: [{
        border: false,
        layout: 'column',
        anchor: '100%',
        items: [
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mtxtFromDate]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mtxtToDate]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mcmbLogType]},
          {border: false, layout: 'form', columnWidth: .125, items: [{xtype: 'button', text: LANG._js1005, iconCls: 'silk_find', anchor: '95%', handler: mEvtCmdSeaarch_OnClick, scope: this}]},
          {border: false, layout: 'form', columnWidth: .125, items: [{xtype: 'button', text: LANG._js1004, iconCls: 'silk_delete', anchor: '95%', handler: mEvtCmdDeleteAll_OnClick, scope: this}]}
        ]
      },{
        border: false,
        layout: 'column',
        anchor: '100%',
        items: [
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .7, items: [new Ext.form.Label({text: MSGS._js1000, style: {color: 'red'}})]}
        ]
      }]
    });
    this.mpnlGridPanel = new Ext.form.FieldSet({
      title: LANG._js1006,
      titleCollapse: true,
      collapsible: true,
      animCollapse: true,
      anchor: '100% 80%'
    });
    this.mviwBodyViewport = new Ext.Viewport({
      layout: 'fit',
      items:[{
        layout: 'anchor',
        title: SiteMap,
        frame: true,
        items: [this.mpnlSearchOperationPanel,this.mpnlGridPanel]
      }]
    });
  };
  
  //向服务器请求控件结构数据
  var initControlsByServer = function(){
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_INIT_LST_CONTROLS,
       prCodeMasterDesc: GLOBAL_CODE_MASTER_DESC.GCD_LOG_CATEGORY,
       prCustomQuery: 'Q%'},
      function(response){
        mdsLogTypeComboBox = new Ext.data.Store({
          proxy: new Ext.data.MemoryProxy(Ext.util.JSON.decode(response.responseText).jsMessageBody[0]),
          reader: new Ext.data.JsonReader(mRequest.JsonReaderConfig,GLOBAL_CODE_MASTER_ARRAY_READER)
        });
        mdsLogTypeComboBox.load();
        this.mcmbLogType.store = mdsLogTypeComboBox;
        this.mcmbLogType.setValue('0');
        this.mcmbLogType.enable();
      }
    );
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_INIT_GRIDVIEW,
       prGirdViewSrno: GLOBAL_GRID_LIST_VIEW_SRNO.GGL_LOG_MANAGER_GRID_VIEW,
       prGridViewCategory: 1}, 
      function(response){
        var responseData = Ext.util.JSON.decode(response.responseText);
        mdsStoreGrid = new Ext.data.Store({
          proxy: new Ext.data.PagingMemoryProxy(mRequest.BlankJsonData),
          reader: new Ext.data.JsonReader(mRequest.JsonReaderConfig,responseData.jsMessageBody[1])
        });
        this.mgrdLogGrid = new Ext.grid.GridPanel({
          stripeRows: true,
          store: mdsStoreGrid,
          cm: new Ext.grid.ColumnModel(responseData.jsMessageBody[0]),
          sm: new Ext.grid.RowSelectionModel({singleSelect: true}),
          anchor: '100% 100%',
          loadMask: true,
          border : true,
          viewConfig: {forceFit: true},
          bbar: new Ext.PagingToolbar({
            pageSize: 30,
            store: mdsStoreGrid,
            displayInfo: true
          }),
          tbar: new Ext.Toolbar({
            items: [
              {xtype: 'button', text: LANG._js1007, tooltip: LANG._js1007, iconCls: 'silk_table_save'},
              {xtype: 'button', text: LANG._js1008, tooltip: LANG._js1008, iconCls: 'silk_printer'},
              '->',
              {xtype: 'label', text: MSGS._js1001, style: {color: 'red'}}
            ]
          }),
          listeners: {
            'rowdblclick': mEvtLogGrid_OnRowDoubleClick,
            scope: this
          }         
        });
        this.mpnlGridPanel.add(this.mgrdLogGrid);
        this.mpnlGridPanel.doLayout();
      }
    );
  };
  
  //控件事件
  //单击查询按钮事件
  var mEvtCmdSeaarch_OnClick = function(Button,e){
    if (!(this.mtxtFromDate.isValid(true) && this.mtxtToDate.isValid(true) && this.mcmbLogType.isValid(true))){
      Ext.MessageBox.alert(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1005);
      return;
    };
    if (this.mtxtFromDate.getValue()>(new Date())){
      Ext.MessageBox.alert(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1000);
      return;
    };
    //prRequestIndc: 查询请求
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_SEARCH,
       prFromDate: mRequest.FormatDateTime(this.mtxtFromDate.getValue()),
       prToDate: mRequest.FormatDateTime(this.mtxtToDate.getValue()),
       prLogCategory: this.mcmbLogType.getValue()},
       mFnPopulateLog
    );
  };
  //单击删除全部按钮事件
  var mEvtCmdDeleteAll_OnClick = function(Button,e){
    Ext.MessageBox.confirm(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1003,
      function(btn){
        if (btn == 'yes'){
          mRequest.RequestToServer(
            {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_DELETEALL},
             mFnDeleteAllLog
          );
        }else{return;};
      }
    );
  };
  //双击一行事件
  //显示日志内容
  var mEvtLogGrid_OnRowDoubleClick = function(Grid,rowIndex,e){
    var rowData = mdsStoreGrid.getAt(rowIndex).data;
    var winId = 'winLogViewer_' + rowData.jsLogFileSrno;
    if (mgrpWindowsGroup.get(winId) == undefined){
      var mwinLogViewer = new Ext.Window({
        id: winId,
        width: 450,
        height: 500,
        title: GLOBAL_WORD._js1004 + '-' + rowData.jsLogFileName,
        maximizable: true,
        closeAction: 'close',
        constrainHeader: true,
        resizeble: true,
        modal: true,
        buttonAlign: 'left',
        buttons: [{text: GLOBAL_WORD._js1005, handler: function(Button,e){mwinLogViewer.close();}}],
        html: "<iframe frameborder='0' name='_LogPage' id='LogPage' width='100%' height='100%' scrolling='auto' src='../../Logs/" + rowData.jsLogFileName + "'></iframe>",
        manager: mgrpWindowsGroup
      });
      mwinLogViewer.show();
    }else{
      Ext.toaster.show({css: "color:red"},GLOBAL_MESSAGE._js1007);
      return;
    };
  };
  
  //私有方法
  //根据返回数据显示所查询的结果
  var mFnPopulateLog = function(response){
    var responseJsonData = Ext.util.JSON.decode(response.responseText);
    if (mRequest.ValidateResponse(responseJsonData)){
      var mjsonDataGrid = responseJsonData.jsMessageBody[0];
      if (mjsonDataGrid != null){
        mdsStoreGrid.proxy = new Ext.data.PagingMemoryProxy(mjsonDataGrid);
      }else{
        mdsStoreGrid.proxy = new Ext.data.PagingMemoryProxy(mRequest.BlankJsonData);
      };
      mdsStoreGrid.load({params: {start: 0, limit: 30}});
    };
    Ext.toaster.show({},responseJsonData.jsMessage);
  };
  //删除所有记录
  var mFnDeleteAllLog = function(response){
    var responseJsonData = Ext.util.JSON.decode(response.responseText);
    if (mRequest.ValidateResponse(responseJsonData)){
      mdsStoreGrid.removeAll();
      mgrdLogGrid.getBottomToolbar().updateInfo();
    }
    Ext.toaster.show({},responseJsonData.jsMessage);
  };
  
  // 公共空间
  return {
    // 公共属性
    mviwBodyViewport              : null, //基础面板
    mpnlGridPanel                 : null, //查询结果面板
    mpnlSearchOperationPanel      : null, //查询操作面板
    mtxtFromDate                  : null, //起始日
    mtxtToDate                    : null, //终止日
    mcmbLogType                   : null, //日志类型
    mgrdLogGrid                   : null, //日志Grid
    
    // 公共方法
    init: function(){
      initControlsByLocal();
      initControlsByServer();
    }
  };
}();
Ext.onReady(LogManager.app.init, LogManager.app); 