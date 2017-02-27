/* 异步请求类开始 */
function jsClsRequest(server_page){

  this.CNST_RQ_INDC = {
    RQ_SAVE :             100,  //保存文本内容
    RQ_EXPORT_GRID :      101,  //导出网格
    RQ_PRINT :            102,  //打印
    RQ_SEARCH :           1000, //查询请求
    RQ_UPDATE :           1001, //更新请求
    RQ_DELETE :           1002, //删除请求
    RQ_DELETEALL :        1003, //删除全部请求
    RQ_INIT_MENU :        1004, //初始化菜单
    RQ_INIT_GRIDVIEW:     1005, //初始化网格
    RQ_INIT_LST_CONTROLS: 1006, //初始化列表控件
    RQ_INIT_LST_VIEW:     1007, //初始化 List View 列
    RQ_SEARCHALL:         1008  //查询全部请求
  };
  
  this.BlankJsonData = {totalProperty:0,items:[]};
  this.DateFormat = "Y-m-d";       //请求日期格式
  this.TimeFormat = "H:i:s";       //请求时间格式
  this.Server_Page = server_page;  //请求目标页
  
  //JsonReader配置
  this.JsonReaderConfig = {
    totalProperty: 'totalProperty',
    root: 'items',
    id: 'identifier'
  };
  
};

//发送请求至服务器来查询符合时间条件和状态条件的数据
//使用Json作为数据源
jsClsRequest.prototype.RequestToServer = function(params, func){
  Ext.Ajax.request({
    method: 'POST',
    url: this.Server_Page,
    success: func,
    failure: this.ResponseError,
    params: params
  });
};
  
//服务器返回失败,显示消息
jsClsRequest.prototype.ResponseError = function(error){
  Ext.toaster.show({css: "color:red"},GLOBAL_MESSAGE._js1004 + " - " + error.message);
};

//验证Response消息
jsClsRequest.prototype.ValidateResponse = function(data){
  if (data.jsMessageStatusIndc != null){
    if (data.jsMessageStatusIndc == 0){
      return true;
    }else{
      return false;
    };
  }else{
    return false;
  };
};

//格式化请求日期时间
jsClsRequest.prototype.FormatDateTime = function(datetime){
  return Ext.util.Format.date(datetime, this.DateFormat);
};

/* 异步请求类结束 */