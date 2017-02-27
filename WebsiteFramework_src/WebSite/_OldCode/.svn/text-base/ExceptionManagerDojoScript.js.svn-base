// Exception Manager Dojo JavaScript File
/*全局设置开始*/
//载入Dojo组件包
dojo.require("dijit.dijit"); // loads the optimized dijit layer
dojo.require("dijit.form.DateTextBox");
dojo.require("dojo.data.ItemFileReadStore");
dojo.require("dojo.data.ItemFileWriteStore");
dojo.require("dijit.form.Button");
dojo.require("dijit.form.FilteringSelect");
dojo.require("dojox.grid.DataGrid");
dojo.require("dijit.form.SimpleTextarea");
dojo.require("dijit.TitlePane");
dojo.require("dojo.io.iframe");
//加载 初始化
dojo.addOnLoad(function(){if(window.pub) window.pub();});
/*全局设置结束*/

/* 数据声明开始 */
/* 数据声明结束 */

var jsObjExceptionManager = {

  evthandles:                        [],   //事件句柄集
  mRequest:                          null,
  mjsonExceptionStatusData:          null,
  mjsonExceptionGridViewStructData:  null,
  mparamsExport:                     null, //导出查询条件
  mintExceptionGridViewSrno:         null, //GridView 序列号
  mstrLstControlsDesc:               null, //列表类控件序列标识
  mstoreExceptionResultrData:        null, //查询结果数据源数据集
  mstoreExceptionStatus:             null, //状态下拉框数据源数据集
  mdtFromDate:                       null, //查询起始日
  mdtToDate:                         null, //查询终止日
  mcboExceptionStatus:               null, //查询用状态下拉框
  mlblExceptionSrno:                 null, //信息显示用异常数据编号
  mlblExceptionDate:                 null, //信息显示用异常数据发生时间
  mcboModyExceptionStatus:           null, //信息显示用状态下拉框
  mlblUpdateUser:                    null, //上次修改用户
  mlblUpdateDatetime:                null, //上次修改时间
  mtxtExceptionContext:              null, //异常内容
  mdgvExceptionResult:               null, //异常数据查询结果DataGrid
  mcmdClear:                         null, //清空按钮
  mcmdSearch:                        null, //查询按钮
  mcmdUpdate:                        null, //更新按钮
  mcmdDelete:                        null, //删除此记录按钮
  mcmdDeleteAll:                     null, //删除所有按钮
  mcmdSave:                          null, //保存按钮
  mcmdPrint:                         null, //打印按钮
  
// Initialize
initialize: function(){
  //实例化成员
  this.mRequest                  = new jsClsRequest("ExceptionManagerServer.aspx", this);
  this.mintExceptionGridViewSrno = GLOBAL_GRID_VIEW_SRNO.GG_EXCEPTION_MANAGER_GRID_VIEW;
  this.mstrLstControlsDesc       = GLOBAL_CODE_MASTER_DESC.GCD_EXCEPTION_STATUS;
  this.mdtFromDate               = dijit.byId("dtFromDate");
  this.mdtToDate                 = dijit.byId("dtToDate");
  this.mcboExceptionStatus       = dijit.byId("cboExceptionStatus");
  this.mlblExceptionSrno         = dojo.byId("lblExceptionSrno");
  this.mlblExceptionDate         = dojo.byId("lblExceptionDate");
  this.mcboModyExceptionStatus   = dijit.byId("cboModyExceptionStatus");
  this.mlblUpdateUser            = dojo.byId("lblUpdateUser");
  this.mlblUpdateDatetime        = dojo.byId("lblUpdateDatetime");
  this.mtxtExceptionContext      = dojo.byId("txtExceptionContext");
  this.mdgvExceptionResult       = dijit.byId("dgvExceptionResult");
  this.mcmdClear                 = dojo.byId("cmdClear");
  this.mcmdSearch                = dojo.byId("cmdSearch");
  this.mcmdUpdate                = dojo.byId("cmdUpdate");
  this.mcmdDelete                = dojo.byId("cmdDelete");
  this.mcmdDeleteAll             = dojo.byId("cmdDeleteAll");
  this.mcmdSave                  = dojo.byId("cmdSave");
  this.mcmdPrint                 = dojo.byId("cmdPrint");
  //事件绑定
  dojo.forEach(this.evthandles, dojo.disconnect);
  this.evthandles.push(dojo.connect(this.mcmdClear ,"onclick",this,this.mEvtOnClick_cmdClear));
  this.evthandles.push(dojo.connect(this.mcmdSearch ,"onclick",this,this.mEvtOnClick_cmdSearch));
  this.evthandles.push(dojo.connect(this.mcmdUpdate,"onclick",this,this.mEvtOnClick_cmdUpdate));
  this.evthandles.push(dojo.connect(this.mcmdDelete,"onclick",this,this.mEvtOnClick_cmdDelete));
  this.evthandles.push(dojo.connect(this.mcmdDeleteAll,"onclick",this,this.mEvtOnClick_cmdDeleteAll));
  this.evthandles.push(dojo.connect(this.mcmdSave,"onclick",this,this.mEvtOnClick_cmdSave));
  this.evthandles.push(dojo.connect(this.mcmdPrint,"onclick",this,this.mEvtOnClick_cmdPrint));
  this.evthandles.push(dojo.connect(this.mdgvExceptionResult,"onRowClick",this,this.mEvtOnRowClick_dgvExceptionResult));
  //初始化控件数据
  this.mFnPopulateCcontrolData();
  
},
  
mFnPopulateCcontrolData: function(){
  //请求 Gird View 构造数据
  var gridViewParams = {prRequestIndc: this.mRequest.CNST_RQ_INDC.RQ_INIT_GRIDVIEW,
                        prGirdViewSrno: this.mintExceptionGridViewSrno,
                        prGridViewCategory: 1};
  this.mRequest.RequestToServer(gridViewParams, function(response){
    this.mjsonExceptionGridViewStructData = response.jsMessageBody[0];
    this.mdgvExceptionResult.attr("structure", this.mjsonExceptionGridViewStructData);
    this.mdgvExceptionResult.attr("rowsPerPage",20);
    this.mdgvExceptionResult.attr("clientSort",true);
    this.mdgvExceptionResult.attr("rowSelector","20px");
    this.mdgvExceptionResult.attr("selectionMode","single");
  });
  //请求下拉列表数据
  var lstControlsParams = {prRequestIndc: this.mRequest.CNST_RQ_INDC.RQ_INIT_LST_CONTROLS,
                           prCodeMasterDesc: this.mstrLstControlsDesc}
  this.mRequest.RequestToServer(lstControlsParams, function(response){
    this.mjsonExceptionStatusData = new dojo.data.ItemFileReadStore({data: response.jsMessageBody[0]});
    this.mcboExceptionStatus.attr("store",this.mjsonExceptionStatusData);
    this.mcboExceptionStatus.attr("searchAttr","jsCodeLabelLangDesc");
    this.mcboExceptionStatus.attr("required",true);
    this.mcboExceptionStatus.attr("query",{"jsCustomQuery": "Q?"});
    this.mcboExceptionStatus.setValue("0");
    this.mcboModyExceptionStatus.attr("store",this.mjsonExceptionStatusData);
    this.mcboModyExceptionStatus.attr("searchAttr","jsCodeLabelLangDesc");
    this.mcboModyExceptionStatus.attr("required",true);
    this.mcboModyExceptionStatus.attr("query",{"jsCustomQuery": "?U"});
    this.mcboModyExceptionStatus.setValue("1");
  });
},

/*事件开始*/
//清空按钮单击事件
mEvtOnClick_cmdClear: function(){
  this.mdgvExceptionResult.setStore(null);
  this.mstoreExceptionResultrData = null;
  this.mparamsExport = null;
  this.mFnCleanControls();
},

//查询按钮单击事件
mEvtOnClick_cmdSearch: function(){
  if (!(this.mcboExceptionStatus.isValid() && this.mdtFromDate.isValid() && this.mdtToDate.isValid())){
    jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1005);
    return;
  };
  if (this.mdtFromDate.value>(new Date())){
    jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1000);
    return;
  };
  //prRequestIndc: 查询请求
  var Params = {prRequestIndc: this.mRequest.CNST_RQ_INDC.RQ_SEARCH,
                prFromDate: this.mRequest.FormatDateTime(this.mdtFromDate.value),
                prToDate: this.mRequest.FormatDateTime(this.mdtToDate.value),
                prExceptionStatus: this.mcboExceptionStatus.attr("value")};
  this.mRequest.RequestToServer(Params, this.mFnPopulateException);
},

//更新按钮单击事件
mEvtOnClick_cmdUpdate: function(){
  if (this.mlblExceptionSrno.innerHTML != null && this.mlblExceptionSrno.innerHTML != ""){
    if (!this.mcboModyExceptionStatus.isValid()){
      jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1005);
      return;
    };
    //prRequestIndc: 更新请求
    var Params = {prRequestIndc: this.mRequest.CNST_RQ_INDC.RQ_UPDATE,
                  prExceptionSrno: this.mlblExceptionSrno.innerHTML,
                  prExceptionStatus: this.mcboModyExceptionStatus.attr("value")};
    this.mRequest.RequestToServer(Params, this.mFnUpdateException);
  }else{
    jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1001);
  };
},

//删除按钮单击事件
mEvtOnClick_cmdDelete: function(){
  if (this.mlblExceptionSrno.innerHTML != null && this.mlblExceptionSrno.innerHTML != ""){
  //prRequestIndc: 删除一条记录请求
  jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1002,null,Ext.Msg.YESNO,Ext.MessageBox.QUESTION,this,function(btn){
    if (btn == "no") return;
    var Params = {prRequestIndc: this.mRequest.CNST_RQ_INDC.RQ_DELETE,
                  prExceptionSrno: this.mlblExceptionSrno.innerHTML}
    this.mRequest.RequestToServer(Params, this.mFnDeleteException)});
  }else{
    jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1001);
  };
},

//删除全部按钮单击事件
mEvtOnClick_cmdDeleteAll: function(){
  //prRequestIndc: 删除一条记录请求
  jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1003,null,Ext.Msg.YESNO,Ext.MessageBox.QUESTION,this,function(btn){
    if (btn == "no") return;
    var Params = {prRequestIndc: this.mRequest.CNST_RQ_INDC.RQ_DELETEALL}
    this.mRequest.RequestToServer(Params, this.mFnDeleteAllException)});
},

//导出网格数据
mEvtOnClick_cmdSave: function(){
  jsObjPrintSave.exportGrid(this.mRequest, this.mparamsExport);
},

//打印网格数据
mEvtOnClick_cmdPrint: function(){

},

//表格单击事件
mEvtOnRowClick_dgvExceptionResult: function(e){
  this.mlblExceptionSrno.innerHTML = e.grid.getItem(e.rowIndex).jsExceptionSrno;
  this.mlblExceptionDate.innerHTML = FormatDateTime(e.grid.getItem(e.rowIndex).jsDateTime[0]);
  this.mcboModyExceptionStatus.setValue(e.grid.getItem(e.rowIndex).jsExceptionStatus);
  this.mlblUpdateUser.innerHTML = e.grid.getItem(e.rowIndex).jsUserSrno;
  this.mlblUpdateDatetime.innerHTML = FormatDateTime(e.grid.getItem(e.rowIndex).jsUpdateDateTime[0]);
  this.mtxtExceptionContext.innerHTML = e.grid.getItem(e.rowIndex).jsContext;
},
/*事件结束*/


//根据返回数据显示所查询的异常结果
mFnPopulateException: function(response){
  if (this.mRequest.ValidateResponse(response)){
    if (response.jsMessageBody[0] != null && response.jsMessageBody[0].items != null){
      this.mstoreExceptionResultrData = new dojo.data.ItemFileWriteStore({data: response.jsMessageBody[0]});
      this.mdgvExceptionResult.setQuery("{jsExceptionSrno: '*'}",null);
      this.mdgvExceptionResult.setStore(this.mstoreExceptionResultrData);
      this.mparamsExport = {prRequestIndc: null,
                            prType: null,
                            prGridViewSrno: this.mintExceptionGridViewSrno,
                            prFromDate: this.mRequest.FormatDateTime(this.mdtFromDate.value),
                            prToDate: this.mRequest.FormatDateTime(this.mdtToDate.value),
                            prExceptionStatus: this.mcboExceptionStatus.attr("value")};
    }else{
      this.mdgvExceptionResult.setStore(null);
      this.mparamsExport = null;
    };
  };
  jsObjMessageBox.showToaster(response.jsMessage);
},

//根据返回数据更新异常表格数据
mFnUpdateException: function(response){
  if (this.mRequest.ValidateResponse(response)){
    var items = this.mdgvExceptionResult.selection.getSelected();
    if(items.length == 1){
      // Iterate through the list of selected items.
      // The current item is available in the variable
      // "selectedItem" within the following function:
      if(items[0] !== null) {
        this.mstoreExceptionResultrData.setValue(items[0], "jsExceptionStatusDesc", response.jsMessageBody[0].jsExceptionStatusDesc);
        this.mstoreExceptionResultrData.setValue(items[0], "jsUpdateDateTime", response.jsMessageBody[0].jsUpdateDateTime);
        this.mstoreExceptionResultrData.save();
        this.mlblUpdateDatetime.innerHTML = FormatDateTime(response.jsMessageBody[0].jsUpdateDateTime);
      }; // end if
    };
  };
  jsObjMessageBox.showToaster(response.jsMessage);
},

//根据返回数据删除消息更新表格数据
mFnDeleteException: function(response){
  if (this.mRequest.ValidateResponse(response)){
    var items = this.mdgvExceptionResult.selection.getSelected();
    if(items.length == 1){
      if(items[0] !== null) {
        this.mstoreExceptionResultrData.deleteItem(items[0]);
        this.mstoreExceptionResultrData.save();
        this.mdgvExceptionResult.selection.clear();
        this.mFnCleanControls();
      };
    };
  };
  jsObjMessageBox.showToaster(response.jsMessage);
},

//根据返回数据删除全部表格数据
mFnDeleteAllException: function(response){
  if (this.mRequest.ValidateResponse(response)){
    this.mdgvExceptionResult.setStore(null);
    this.mstoreExceptionResultrData = null;
    this.mFnCleanControls();
    this.mparamsExport = null;
  };
  jsObjMessageBox.showToaster(response.jsMessage);
},

//清空控件
mFnCleanControls: function(){
  this.mlblExceptionSrno.innerHTML = "";
  this.mlblExceptionDate.innerHTML = "";
  this.mcboModyExceptionStatus.setValue(1);
  this.mlblUpdateUser.innerHTML = "";
  this.mlblUpdateDatetime.innerHTML  = "";
  this.mtxtExceptionContext.innerHTML = "";
}};
//初始化对象
dojo.addOnLoad(jsObjExceptionManager,jsObjExceptionManager.initialize);