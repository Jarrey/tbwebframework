// Exception Manager ExtJs JavaScript

// 填充图片的本地引用
Ext.BLANK_IMAGE_URL = '../../Extjs_lib/resources/images/default/s.gif';
Ext.onReady(function(){Ext.QuickTips.init()}); 

// 创建命名空间
Ext.namespace('ExceptionManager');

// 创建应用程序
ExceptionManager.app = function() {

  // 私有变量
  var mRequest                     = new jsClsRequest("ExceptionManagerServer.aspx"); //Ajax请求对象
  var mdsStoreGrid                 = null; //Grid数据源
  var mdsSrStoreStatusComboBox     = null; //查询状态ComoBox数据源
  var mdsMoStoreStatusComboBox     = null; //修改状态ComoBox数据源
    
  // 私有函数
  // 初始化
  var initControlsByLocal = function(){
    //输入控件初始化
    this.mtxtFromDate = new Ext.form.DateField({
      fieldLabel: LANG._js1001,
      emptyText: LANG._js1016,
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
      emptyText: LANG._js1016,
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
    this.mcmbSrExceptionStatus = new Ext.form.ComboBox({
      fieldLabel: LANG._js1003,
      emptyText: LANG._js1016,
      displayField: GLOBAL_CODE_MASTER_DISPLAY_FIELD,
      valueField: GLOBAL_CODE_MASTER_VALUE_FIELD,
      triggerAction: 'all',
      selectOnFocus: true,
      allowBlank: false,
      resizable: true,
      anchor: '95%',
      disabled: true
    });
    this.mlblExceptionSrno = new Ext.form.Label({fieldLabel: LANG._js1006, anchor: '95%'});
    this.mlblExceptionDate = new Ext.form.Label({fieldLabel: LANG._js1007, anchor: '95%'});
    this.mcmbMoExceptionStatus = new Ext.form.ComboBox({
      fieldLabel: LANG._js1003,
      emptyText: LANG._js1016,
      displayField: GLOBAL_CODE_MASTER_DISPLAY_FIELD,
      valueField: GLOBAL_CODE_MASTER_VALUE_FIELD,
      triggerAction: 'all',
      selectOnFocus: true,
      allowBlank: false,
      resizable: true,
      anchor: '95%',
      disabled: true
    });
    this.mlblUpdateUserName = new Ext.form.Label({fieldLabel: LANG._js1008, anchor: '95%'});
    this.mlblUpdateDateTime = new Ext.form.Label({fieldLabel: LANG._js1009, anchor: '95%'});
    this.mlblTitle = new Ext.form.Label({fieldLabel: LANG._js1017, anchor: '95%'});
    this.mtxtExceptionContext = new Ext.form.TextArea({anchor: '100%', height: 60, readOnly: true});
    
    //面板初始化
    this.mpnlSearchPanel = new Ext.form.FieldSet({
      title: LANG._js1000,
      layout: 'column',
      titleCollapse: true,
      collapsible: true,
      animCollapse: true,
      anchor: '100% 15%',
      items: [
        {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mtxtFromDate]},
        {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mtxtToDate]},
        {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mcmbSrExceptionStatus]},
        {border: false, layout: 'form', columnWidth: .125, items: [{xtype: 'button', text: LANG._js1000, iconCls: 'silk_find', anchor: '95%', handler: mEvtCmdSeaarch_OnClick, scope: this}]},
        {border: false, layout: 'form', columnWidth: .125, items: [{xtype: 'button', text: LANG._js1004, anchor: '95%', handler: mEvtCmdClear_OnClick, scope: this}]}
      ]
    });
    this.mpnlOperationPanel = new Ext.form.FieldSet({
      title: LANG._js1005,
      layout: 'form',
      titleCollapse: true,
      collapsible: true,
      animCollapse: true,
      anchor: '100% 40%',
      items: [{
        border: false,
        layout: 'column',
        anchor: '100%',
        items: [
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .15, items: [this.mlblExceptionSrno]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mlblExceptionDate]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .2, items: [this.mcmbMoExceptionStatus]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .15, items: [this.mlblUpdateUserName]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .25, items: [this.mlblUpdateDateTime]}
        ]
      },{
        border: false,
        layout: 'form',
        anchor: '100%',
        items: [
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: 1, items: [this.mlblTitle]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: 1, items: [this.mtxtExceptionContext]}
        ]
      },{
        border: false,
        layout: 'column',
        anchor: '100%',
        items: [
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .55, items: [new Ext.form.Label({text: MSGS._js1000, style: {color: 'red'}})]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .15, items: [{xtype: 'button', text: LANG._js1010, iconCls: 'silk_delete', anchor: '95%', handler: mEvtCmdDeleteAll_OnClick, scope: this}]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .15, items: [{xtype: 'button', text: LANG._js1011, iconCls: 'silk_delete', anchor: '95%', handler: mEvtCmdDelete_OnClick, scope: this}]},
          {border: false, labelAlign: 'right', layout: 'form', columnWidth: .15, items: [{xtype: 'button', text: LANG._js1012, iconCls: 'silk_arrow_up', anchor: '95%', handler: mEvtCmdUpdate_OnClick, scope: this}]}
        ]
      }]
    });
    this.mpnlGridPanel = new Ext.form.FieldSet({
      title: LANG._js1013,
      titleCollapse: true,
      collapsible: true,
      animCollapse: true,
      anchor: '100% 45%'
    });
    this.mviwBodyViewport = new Ext.Viewport({
      layout: 'fit',
      items:[{
        layout: 'anchor',
        title: SiteMap,
        frame: true,
        items: [this.mpnlSearchPanel,this.mpnlOperationPanel,this.mpnlGridPanel]
      }]
    });
  };
  
  //向服务器请求控件结构数据
  var initControlsByServer = function(){
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_INIT_LST_CONTROLS,
       prCodeMasterDesc: GLOBAL_CODE_MASTER_DESC.GCD_EXCEPTION_STATUS + '|' + GLOBAL_CODE_MASTER_DESC.GCD_EXCEPTION_STATUS,
       prCustomQuery: 'Q%|QU'},
      function(response){
        mdsSrStoreStatusComboBox = new Ext.data.Store({
          proxy: new Ext.data.MemoryProxy(Ext.util.JSON.decode(response.responseText).jsMessageBody[0]),
          reader: new Ext.data.JsonReader(mRequest.JsonReaderConfig,GLOBAL_CODE_MASTER_ARRAY_READER)
        });
        mdsSrStoreStatusComboBox.load();
        this.mcmbSrExceptionStatus.store = mdsSrStoreStatusComboBox;
        this.mcmbSrExceptionStatus.setValue('0');
        this.mcmbSrExceptionStatus.enable();
        mdsMoStoreStatusComboBox = new Ext.data.Store({
          proxy: new Ext.data.MemoryProxy(Ext.util.JSON.decode(response.responseText).jsMessageBody[1]),
          reader: new Ext.data.JsonReader(mRequest.JsonReaderConfig,GLOBAL_CODE_MASTER_ARRAY_READER)
        });
        mdsMoStoreStatusComboBox.load();
        this.mcmbMoExceptionStatus.store = mdsMoStoreStatusComboBox;
        this.mcmbMoExceptionStatus.setValue('1');
        this.mcmbMoExceptionStatus.enable();
      }
    );
    mRequest.RequestToServer(
      {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_INIT_GRIDVIEW,
       prGirdViewSrno: GLOBAL_GRID_LIST_VIEW_SRNO.GGL_EXCEPTION_MANAGER_GRID_VIEW,
       prGridViewCategory: 1}, 
      function(response){
        var responseData = Ext.util.JSON.decode(response.responseText);
        mdsStoreGrid = new Ext.data.Store({
          proxy: new Ext.data.PagingMemoryProxy(mRequest.BlankJsonData),
          reader: new Ext.data.JsonReader(mRequest.JsonReaderConfig,responseData.jsMessageBody[1])
        });
        this.mgrdExceptionGrid = new Ext.grid.GridPanel({
          stripeRows: true,
          store: mdsStoreGrid,
          cm: new Ext.grid.ColumnModel(responseData.jsMessageBody[0]),
          sm: new Ext.grid.RowSelectionModel({singleSelect: true}),
          anchor: '100% 100%',
          loadMask: true,
          border : true,
          viewConfig: {forceFit: true},
          bbar: new Ext.PagingToolbar({
            pageSize: 20,
            store: mdsStoreGrid,
            displayInfo: true
          }),
          tbar: new Ext.Toolbar({
            items: [
              {xtype: 'button', text: LANG._js1014, tooltip: LANG._js1014, iconCls: 'silk_table_save'},
              {xtype: 'button', text: LANG._js1015, tooltip: LANG._js1015, iconCls: 'silk_printer'}
            ]
          }),
          listeners: {
            'rowclick': mEvtExceptionGrid_OnRowClick,
            scope: this
          }         
        });
        this.mpnlGridPanel.add(this.mgrdExceptionGrid);
        this.mpnlGridPanel.doLayout();
      }
    );
  };
  
  //控件事件
  //单击查询按钮事件
  var mEvtCmdSeaarch_OnClick = function(Button,e){
    if (!(this.mtxtFromDate.isValid(true) && this.mtxtToDate.isValid(true) && this.mcmbSrExceptionStatus.isValid(true))){
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
       prExceptionStatus: this.mcmbSrExceptionStatus.getValue()},
       mFnPopulateException
    );
  };
  //单击更新按钮事件
  var mEvtCmdUpdate_OnClick = function(Button,e){
    if (this.mlblExceptionSrno.text !== undefined && this.mlblExceptionSrno.text != ''){
      if (!this.mcmbMoExceptionStatus.isValid(true)){
        Ext.MessageBox.alert(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1005);
        return;
      };
      //prRequestIndc: 更新请求
      mRequest.RequestToServer(
        {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_UPDATE,
         prExceptionSrno: this.mlblExceptionSrno.text,
         prExceptionStatus: this.mcmbMoExceptionStatus.getValue()},
         mFnUpdateException
      );
    }else{
      Ext.MessageBox.alert(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1001);
    };
  };
  //单击删除按钮事件
  var mEvtCmdDelete_OnClick = function(Button,e){
    if (this.mlblExceptionSrno.text !== undefined && this.mlblExceptionSrno.text != ''){
      Ext.MessageBox.confirm(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1002,
        function(btn){
          if (btn == 'yes'){
            mRequest.RequestToServer(
              {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_DELETE,
               prExceptionSrno: this.mlblExceptionSrno.text},
               mFnDeleteException
            );
          }else{return;};
        }
     );
   }else{
     Ext.MessageBox.alert(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1001);
   };
  };
  //单击删除全部按钮事件
  var mEvtCmdDeleteAll_OnClick = function(Button,e){
    Ext.MessageBox.confirm(GLOBAL_WORD._js1000,GLOBAL_MESSAGE._js1003,
      function(btn){
        if (btn == 'yes'){
          mRequest.RequestToServer(
            {prRequestIndc: mRequest.CNST_RQ_INDC.RQ_DELETEALL},
             mFnDeleteAllException
          );
        }else{return;};
      }
    );
  };
  //单击清空按钮事件
  var mEvtCmdClear_OnClick = function(Button,e){
    mResetOperationContorls();
    mdsStoreGrid.proxy = new Ext.data.PagingMemoryProxy(mRequest.BlankJsonData);
    mdsStoreGrid.load({params: {start: 0, limit: 20}});
  };
  //单击一行事件
  var mEvtExceptionGrid_OnRowClick = function(Grid,rowIndex,e){
    var rowData = mdsStoreGrid.getAt(rowIndex).data;
    this.mlblExceptionSrno.setText(rowData.jsExceptionSrno);
    this.mlblExceptionDate.setText(mGlobalService.FormatDateTime(rowData.jsDateTime));
    this.mcmbMoExceptionStatus.setValue(rowData.jsExceptionStatus);
    this.mlblUpdateUserName.setText(rowData.jsUserSrno);
    this.mlblUpdateDateTime.setText(mGlobalService.FormatDateTime(rowData.jsUpdateDateTime));
    this.mlblTitle.setText(rowData.jsTitle);
    this.mtxtExceptionContext.setValue(rowData.jsContext);
  };
  
  //私有方法
  //根据查询的数据插入Grid
  var mFnPopulateException = function(response){
    var responseJsonData = Ext.util.JSON.decode(response.responseText);
    if (mRequest.ValidateResponse(responseJsonData)){
      var mjsonDataGrid = responseJsonData.jsMessageBody[0];
      if (mjsonDataGrid != null){
        mdsStoreGrid.proxy = new Ext.data.PagingMemoryProxy(mjsonDataGrid);
      }else{
        mdsStoreGrid.proxy = new Ext.data.PagingMemoryProxy(mRequest.BlankJsonData);
      };
      mdsStoreGrid.load({params: {start: 0, limit: 20}});
    };
    Ext.toaster.show({},responseJsonData.jsMessage);
  };
  //更新Grid数据
  var mFnUpdateException = function(response){
    var responseJsonData = Ext.util.JSON.decode(response.responseText);
    if (mRequest.ValidateResponse(responseJsonData)){
      var updateDataRecord = mdsStoreGrid.getAt(mdsStoreGrid.find("jsExceptionSrno",responseJsonData.jsMessageBody[0].jsExceptionSrno));
      updateDataRecord.set('jsExceptionStatusDesc',responseJsonData.jsMessageBody[0].jsExceptionStatusDesc);
      updateDataRecord.set('jsUserSrno',responseJsonData.jsMessageBody[0].jsUserSrno);
      updateDataRecord.set('jsUpdateDateTime',responseJsonData.jsMessageBody[0].jsUpdateDateTime);
      this.mcmbMoExceptionStatus.setValue(responseJsonData.jsMessageBody[0].jsExceptionStatus);
      this.mlblUpdateUserName.setText(responseJsonData.jsMessageBody[0].jsUserSrno);
      this.mlblUpdateDateTime.setText(mGlobalService.FormatDateTime(responseJsonData.jsMessageBody[0].jsUpdateDateTime));
      mdsStoreGrid.commitChanges();
    }
    Ext.toaster.show({},responseJsonData.jsMessage);
  };
  //删除一条记录
  var mFnDeleteException = function(response){
    var responseJsonData = Ext.util.JSON.decode(response.responseText);
    if (mRequest.ValidateResponse(responseJsonData)){
      var deleteDataRecordIndex = mdsStoreGrid.find("jsExceptionSrno",responseJsonData.jsMessageBody[0].jsId);
      mdsStoreGrid.removeAt(deleteDataRecordIndex);
      mgrdExceptionGrid.getBottomToolbar().updateInfo();
      mResetOperationContorls();
    }
    Ext.toaster.show({},responseJsonData.jsMessage);
  };
  //删除所有记录
  var mFnDeleteAllException = function(response){
    var responseJsonData = Ext.util.JSON.decode(response.responseText);
    if (mRequest.ValidateResponse(responseJsonData)){
      mdsStoreGrid.removeAll();
      mgrdExceptionGrid.getBottomToolbar().updateInfo();
      mResetOperationContorls();
    }
    Ext.toaster.show({},responseJsonData.jsMessage);
  };
  
  //清空异常操作控件
  var mResetOperationContorls = function(){
    this.mlblExceptionSrno.setText('');
    this.mlblExceptionDate.setText('');
    this.mcmbMoExceptionStatus.setValue('1');
    this.mlblUpdateUserName.setText('');
    this.mlblUpdateDateTime.setText('');
    this.mlblTitle.setText('');
    this.mtxtExceptionContext.setValue('');
  };
  
  // 公共空间
  return {
    // 公共属性
    mviwBodyViewport              : null, //基础面板
    mpnlGridPanel                 : null, //查询结果面板
    mpnlSearchPanel               : null, //查询面板
    mpnlOperationPanel            : null, //操作面板
    mtxtFromDate                  : null, //起始日
    mtxtToDate                    : null, //终止日
    mcmbSrExceptionStatus         : null, //查询异常状态
    mgrdExceptionGrid             : null, //异常Grid
    mlblExceptionSrno             : null, //异常编号
    mlblExceptionDate             : null, //异常发生时间
    mcmbMoExceptionStatus         : null, //修改异常状态
    mlblUpdateUserName            : null, //更新用户名
    mlblUpdateDateTime            : null, //更新时间
    mlblTitle                     : null, //异常标题
    mtxtExceptionContext          : null, //异常内容
    
    // 公共方法
    init: function(){
      initControlsByLocal();
      initControlsByServer();
    }
  };
}();
Ext.onReady(ExceptionManager.app.init, ExceptionManager.app); 