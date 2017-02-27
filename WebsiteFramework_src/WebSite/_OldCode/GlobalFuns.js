dojo.require("dojo.parser");
dojo.require("dijit.form.Button");
dojo.require("dijit.Dialog");
dojo.require("dojo.date.locale");
dojo.require("dojox.widget.Toaster");
dojo.require("dijit.form.CheckBox");
dojo.require("dojo.io.iframe");

/* 消息框开始 */
var jsObjMessageBox = {

msgMessageToaster: null,
dlgLogFileViewer:  null,

//显示消息框
//func: 用户点击确定后执行的函数
//image: 0 警告图标
//       1 询问图标 
//       2 消息图标 - 默认为消息图标
//       3 错误图标                    
showDialog: function(message,title,buttons,icon,object,func){
  if (title == null) title = GLOBAL_WORD._js1000;
  if (buttons == null) buttons = Ext.Msg.OK;
  if (icon == null) icon = Ext.MessageBox.INFO;
  if (object == null || func == null){fn = null;}else{fn = dojo.hitch(object, func)};
  Ext.Msg.show({
    title: title,
    msg: message,
    buttons: buttons,
    fn: fn,
    icon: icon
  });
},

//显示消息小标题
//type :  fatal - default
//        error
//        warning
//        message
showToaster: function(message,type){
  if (this.msgMessageToaster === null) this.msgMessageToaster = new dojox.widget.Toaster();
  if (type == null) type = "fatal";
  this.msgMessageToaster.positionDirection = "tr-left";
  this.msgMessageToaster.setContent(message, type);
  this.msgMessageToaster.show();
},

//显示文本文件查看框
showLogFileViewer: function(href){
  var IFrame = "<iframe src='" + href + "'width = '100%' height='500' frameborder='0' " +
               "style='border-right: silver 1px solid;border-bottom: gray 1px solid;border-top: silver 1px solid;border-left: silver 1px solid;'></iframe>"
  var Button = "<br /><div align=\"center\"><button dojoType=\"dijit.form.Button\" type=\"submit\">" + GLOBAL_WORD._js1005 + "</button></div>";
  if (this.dlgLogFileViewer === null) this.dlgLogFileViewer = new dijit.Dialog({title: GLOBAL_WORD._js1004, style: "width: 500px"});
  this.dlgLogFileViewer.attr("content",IFrame + Button);
  this.dlgLogFileViewer.show();
}
};
/* 消息框结束 */

/* ToolTip Start */
var jsObjToolTip = {
connect: function(connectId,label,posotion,labelColor){
  if (connectId == null) return;
  if (label == null || label == "") return;
  if (posotion == null) posotion = ["above", "below"];
  if (labelColor == null) labelColor = "Black"
  new dijit.Tooltip({
            connectId: connectId,
            label: "<div style='color:" + labelColor + "'>" + label + "</div>",
            position: posotion});
}
};
/* End of ToolTip */

/* 打印导出服务开始 */
var jsObjPrintSave = {
 
dlgExport:    null,

exportGrid: function(requestObject, paramsExport){
  this.requestObject = requestObject;
  this.paramsExport = paramsExport;
  if (this.paramsExport == null){
    jsObjMessageBox.showDialog(GLOBAL_MESSAGE._js1006);
    return;
  };
  if (this.dlgExport === null) this.dlgExport = new dijit.Dialog({title: GLOBAL_WORD._js1006, style: "width: 500px"});
  var radioSelect = "<form id=\"SelectType\"><input type=\"radio\" dojoType=\"dijit.form.RadioButton\" name=\"SelectType\" id=\"SelectExcelXml\" value=\"ExcelXml\" />" +
                    "<label for=\"SelectExcelXml\">Xml</label><br />" +
                    "<input type=\"radio\" dojoType=\"dijit.form.RadioButton\" name=\"SelectType\" id=\"SelectCsv\" value=\"Csv\" />" +
                    "<label for=\"SelectCsv\">Csv</label></form>"
  var Bottons = "<div align=\"center\"><button dojoType=\"dijit.form.Button\" type=\"submit\">" + GLOBAL_WORD._js1002 + "</button>" +
                "<button dojoType=\"dijit.form.Button\" onClick=\"jsObjPrintSave.dlgExport.hide();\">" + GLOBAL_WORD._js1003 + "</button></div>";
  this.dlgExport.execute = dojo.hitch(this, function(values){
    this.paramsExport.prRequestIndc = this.requestObject.CNST_RQ_INDC.RQ_EXPORT_GRID;
    this.paramsExport.prType = values.SelectType;
    this.requestObject.RequestToServer(this.paramsExport, function(response){
      dojo.io.iframe.create("","",response);
      
    },"text");
  });
  this.dlgExport.attr("content",radioSelect + Bottons);
  this.dlgExport.show();
 
},

print: function(){

},

save: function(){

}
};
/* 打印导出服务结束 */

/* 格式化开始 */
function FormatDateTime(datetime){return Ext.util.Format.date(datetime, PARAMS._js1000 + PARAMS._js1001);};
function FormatDate(date){return Ext.util.Format.date(date, PARAMS._js1000);};
function FormatTime(time){return Ext.util.Format.date(time, PARAMS._js1001);};
/* 格式化结束 */