<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/AdminManage/Manager.Master" CodeBehind="SystemMessageMonitor.aspx.vb" Inherits="WebSite.SystemMessageMonitor" %>
<%@ Import Namespace="Manage" %>
<%@ Import Namespace="Utils" %>
    
<asp:Content ID="modLogContent" ContentPlaceHolderID="modContentPlaceHolder" runat="server">

<link href="../../Style/GlobalStyle.css" rel="stylesheet" type="text/css" />
<link href="../../Images/shared/silk_icons.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="../../JScript/Language/<% =mStrGlobal_Language %>/dictionary.js"></script>
<script language="javascript">
var LANG = {
  _js1000: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1065", mIntGlobal_Language_Indc) %>", //系统消息
  _js1001: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1062", mIntGlobal_Language_Indc) %>", //导出
  _js1002: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1056", mIntGlobal_Language_Indc) %>", //打印  
  _js1003: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1003|1015|1065", mIntGlobal_Language_Indc) %>", //删除所有记录
  _js1004: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1076", mIntGlobal_Language_Indc) %>", //过滤 
  _js1005: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1077", mIntGlobal_Language_Indc) %>"  //刷新 
};
var PARAMS = {};
var MSGS = {
  _js1000: "<% =clsMessageDictionaryManager.mFnGetMessageDesc(1012, mIntGlobal_Language_Indc)%>" //双击查看系统消息内容
};
</script>

<!-- ExtJs 模块引用开始 -->
<!-- 样式表引用 -->
<link rel="stylesheet" type="text/css" href="../../Extjs_lib/resources/css/ext-all.css" />  
<link rel="stylesheet" type="text/css" href="../../Extjs_lib/resources/css/xtheme-<% =clsParameterManager.mFnGetParameters(GP_EXTJS_THEMES) %>.css" />
<link rel="stylesheet" type="text/css" href="../../Extjs_lib/ux/gridfilters/css/GridFilters.css" /> 
<link rel="stylesheet" type="text/css" href="../../Extjs_lib/ux/gridfilters/css/RangeMenu.css" />
<!-- GC -->
<!-- 公共资源变量 -->
<script type="text/javascript" src="../../JScript/WebToolKit/WebToolKit.Base64.js"></script>
<script type="text/javascript" src="../../JScript/GridListViewSrno.js"></script>
<script type="text/javascript" src="../../JScript/CodeMasterDesc.js"></script>

<!-- LIBS -->
<script type="text/javascript" src="../../Extjs_lib/adapter/ext/ext-base.js"></script>
<script type="text/javascript" src="../../Extjs_lib/ext-all.js"></script>
<!-- ENDLIBS -->
<script type="text/javascript" src="../../Extjs_lib/src/locale/ext-lang-<% =mStrGlobal_Language %>.js"></script>
<!-- extensions -->
<!-- Grid 分页 分组 过滤插件库 -->
<script type="text/javascript" src="../../Extjs_lib/ux/PagingMemoryProxy.js"></script>
<script type="text/javascript" src="../../Extjs_lib/ux/RowExpander.js"></script>
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/menu/RangeMenu.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/menu/ListMenu.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/GridFilters.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/filter/Filter.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/filter/StringFilter.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/filter/DateFilter.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/filter/ListFilter.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/filter/NumericFilter.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/ux/gridfilters/filter/BooleanFilter.js"></script> 
<script type="text/javascript" src="../../Extjs_lib/OverrideJs/Ext_Data_Store.js"></script>
<script type="text/javascript" src="../../Extjs_lib/OverrideJs/Ext_Grid_GridPanel.js"></script>
<script type="text/javascript" src="../../JScript/ExtJsGlobalService.js"></script>
<script type="text/javascript" src="../../JScript/ExtJsRequest.js"></script>
<!-- 私有ExtJs模块 -->
<script type="text/javascript" src="SystemMessageMonitorExtJsScript.js"></script>
<!-- ExtJs 模块结束 -->
<script language="javascript">
var mGlobalService = new jsClsGlobalService({
  DateFormat: PARAMS._js1000,
  TimeFormat: PARAMS._js1001
});
</script>
</asp:Content>