var jsClsGlobalService = function(Params){
  if (Ext.isDefined(Params.DateFormat)) {this._DateFormat = Params.DateFormat;}else{this._DateFormat = CNST_DATE_FORMAT;};
  if (Ext.isDefined(Params.TimeFormat)) {this._TimeFormat = Params.TimeFormat;}else{this._TimeFormat = CNST_TIME_FORMAT;};
};
/* 格式化方法开始 */
jsClsGlobalService.prototype.FormatDateTime = function(datetime){return Ext.util.Format.date(datetime, this._DateFormat + " " + this._TimeFormat);};
jsClsGlobalService.prototype.FormatDate = function(date){return Ext.util.Format.date(date, this._DateFormat);};
jsClsGlobalService.prototype.FormatTime = function(time){return Ext.util.Format.date(time, this._TimeFormat);};
jsClsGlobalService.prototype.FormatString = function(str,style){return "<SPAN style=\'" + style + "\'>" + str + "</SPAN>";};
/* 格式化方法结束 */

/* 全局常量 */
GLOBAL_CONST_LOCAL_SYSTEM_MESSAGE_INDICATOR = 1; //本地系统消
GLOBAL_SERVER_SYSTEM_MESSAGE_INDICATOR = 2;      //服务端系统消息

/* 小消息提示框 */
Ext.toaster = function(){
  var msgCt;

  function createBox(s,css){
    return ["<div class=\"msg\"><div class=\"x-box-mc\" style=\"", css, "\">", s, "</div></div>"].join('');
  }
  
  return {
    show : function(options,format){
      if (options.css === undefined) options.css = "";
      if(!msgCt){
          msgCt = Ext.DomHelper.insertFirst(document.body, {id:'msg-div'}, true);
      }
      msgCt.alignTo(document, 'tr-tr');
      var s = String.format.apply(String, Array.prototype.slice.call(arguments, 1));
      var m = Ext.DomHelper.append(msgCt, {html:createBox(s,options.css)}, true);
      m.slideIn('r').pause(2).ghost("r", {remove:true});
    },

    init : function(){}
  };
}();
Ext.onReady(Ext.toaster.init, Ext.toaster);