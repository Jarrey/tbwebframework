<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/AdminManage/Manager.Master" CodeBehind="LogManager.aspx.vb" Inherits="WebSite.LogManager" %>
<%@ Import Namespace="Manage" %>
<%@ Import Namespace="Utils" %>
<asp:Content ID="modLogContent" ContentPlaceHolderID="modContentPlaceHolder" runat="server">

<link href="../../Style/GlobalStyle.css" rel="stylesheet" type="text/css" />
<link href="../../Images/shared/silk_icons.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="../../JScript/Language/<% =mStrGlobal_Language %>/dictionary.js"></script>
<script language="javascript">
var LANG = {
  _js1000: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1001", mIntGlobal_Language_Indc) & "/" & _
                clsLanguageDictionaryManager.mFnGetLanguageDesc("1019", mIntGlobal_Language_Indc) %>", //查询/操作
  _js1001: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1050|1016", mIntGlobal_Language_Indc) %>", //日志记录时间从
  _js1002: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1017", mIntGlobal_Language_Indc) %>", //到
  _js1003: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1052", mIntGlobal_Language_Indc) %>", //日志类型
  _js1004: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1003|1015|1048", mIntGlobal_Language_Indc) %>", //删除所有日志
  _js1005: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1001", mIntGlobal_Language_Indc) %>", //查询
  _js1006: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1048|1007", mIntGlobal_Language_Indc) %>", //日志记录
  _js1007: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1062", mIntGlobal_Language_Indc) %>", //导出
  _js1008: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1056", mIntGlobal_Language_Indc) %>", //打印
  _js1009: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1057", mIntGlobal_Language_Indc) %>"  //请选择
};
var PARAMS = {
  _js1000: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("101", mIntGlobal_Language_Indc) %>", //日期格式
  _js1001: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("102", mIntGlobal_Language_Indc) %>"  //时间格式
};
var MSGS = {
  _js1000: "*<% =clsMessageDictionaryManager.mFnGetMessageDesc(1008, mIntGlobal_Language_Indc, New String() {clsParameterManager.mFnGetParameters(GP_DATA_SAVED_TIME).ToString})%>", //日志数据在生成**天后会自动删除!
  _js1001: "<% =clsMessageDictionaryManager.mFnGetMessageDesc(1011, mIntGlobal_Language_Indc)%>" //双击查看日志内容
};
</script>

<!-- ExtJs 模块引用开始 -->
<!-- 样式表引用 -->
<link rel="stylesheet" type="text/css" href="../../Extjs_lib/resources/css/ext-all.css"/>  
<link rel="stylesheet" type="text/css" href="../../Extjs_lib/resources/css/xtheme-<% =clsParameterManager.mFnGetParameters(GP_EXTJS_THEMES) %>.css"/>
<!-- GC -->
<!-- 公共资源变量 -->
<script type="text/javascript" src="../../JScript/GridListViewSrno.js"></script>
<script type="text/javascript" src="../../JScript/CodeMasterDesc.js"></script>
<!-- LIBS -->
<script type="text/javascript" src="../../Extjs_lib/adapter/ext/ext-base.js"></script>
<script type="text/javascript" src="../../Extjs_lib/ext-all.js"></script>
<!-- ENDLIBS -->
<script type="text/javascript" src="../../Extjs_lib/src/locale/ext-lang-<% =mStrGlobal_Language %>.js"></script>
<script type="text/javascript" src="../../Extjs_lib/ux/PagingMemoryProxy.js"></script>
<script type="text/javascript" src="../../Extjs_lib/OverrideJs/Ext_Data_Store.js"></script>
<script type="text/javascript" src="../../JScript/ExtJsGlobalService.js"></script>
<script type="text/javascript" src="../../JScript/ExtJsRequest.js"></script>
<!-- 私有ExtJs模块 -->
<script type="text/javascript" src="LogManagerExtJsScript.js"></script>
<!-- ExtJs 模块结束 -->
<script language="javascript">
var mGlobalService = new jsClsGlobalService({
  DateFormat: PARAMS._js1000,
  TimeFormat: PARAMS._js1001
});
</script>
</asp:Content>
