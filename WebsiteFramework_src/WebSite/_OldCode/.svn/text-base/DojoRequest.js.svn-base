/* 异步请求类开始 */
function jsClsRequest(server_page, request_object){

  this.CNST_RQ_INDC = {
    RQ_SAVE :             100, //保存文本内容
    RQ_EXPORT_GRID :      101, //导出网格
    RQ_PRINT :            102, //打印
    RQ_SEARCH :           1000,
    RQ_UPDATE :           1001,
    RQ_DELETE :           1002,
    RQ_DELETEALL :        1003,
    RQ_INIT_MENU :        1004, //初始化菜单
    RQ_INIT_GRIDVIEW:     1005, //初始化网格
    RQ_INIT_LST_CONTROLS: 1006 //初始化列表控件
  };
  
  this.DateFormat = "yyyy-MM-dd";       //请求日期格式
  this.TimeFormat = "HH:mm:ss";         //请求时间格式
  this.Server_Page = server_page;       //请求目标页
  this.Request_Object = request_object; //请求对象
};

//发送请求至服务器来查询符合时间条件和状态条件的数据
//使用Json作为数据源
jsClsRequest.prototype.RequestToServer = function(params, func, handleAs){
  if (handleAs == null) handleAs = "json-comment-optional";
  dojo.xhrPost({
    url: this.Server_Page,
    handleAs: handleAs,
    timeout: 10000,
    preventCache: true,
    content: params,
    load: dojo.hitch(this.Request_Object, func),
    error: this.ResponseError
    });
  };
  
//服务器返回失败,显示消息
jsClsRequest.prototype.ResponseError = function(error){
  jsObjMessageBox.showToaster(GLOBAL_MESSAGE._js1004 + " - " + error.message,"error");
};

//验证Response消息
jsClsRequest.prototype.ValidateResponse = function(response){
  if (response.jsMessageStatusIndc != null){
    if (response.jsMessageStatusIndc == 0){
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
  return dojo.date.locale.format(datetime, {datePattern:this.DateFormat, timePattern:this.TimeFormat});
};

/* 异步请求类结束 */
