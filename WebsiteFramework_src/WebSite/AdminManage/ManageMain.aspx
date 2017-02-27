<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ManageMain.aspx.vb" Inherits="WebSite.ManageMain" %>
<%@ Import Namespace="Manage" %>
<%@ Import Namespace="Utils" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
  <title><% =clsParameterManager.mFnGetParameters(GP_WEB_SITE_NAME)%></title>
  
  <link href="../Style/GlobalStyle.css" rel="stylesheet" type="text/css" />
  
  <script type="text/javascript" src="../JScript/Language/<% =mStrGlobal_Language %>/dictionary.js"></script>
  <script language="javascript">
  var LANG = {};
  var PARAMS = {
    _js1000: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("101", mIntGlobal_Language_Indc) %>", //日期格式
    _js1001: "<% =clsLanguageDictionaryManager.mFnGetLanguageDesc("102", mIntGlobal_Language_Indc) %>", //时间格式
    _js1002: <% =clsParameterManager.mFnGetParameters(GP_COMETD_MAX_CONNECTION) %>, //cometD最大连接数
    SYSTEM_MESSAGE_VIEWER: <% =iif(clsParameterManager.mFnGetParameters(GP_SYSTEM_MESSAGE_VIEWER),"true","false") %> //是否允许查看详细系统消息
  };
  var MSGS = {
    _js1000: "<% =clsMessageDictionaryManager.mFnGetMessageDesc(1012, mIntGlobal_Language_Indc)%>" //双击查看系统消息内容
  };
  if (PARAMS._js1002 == undefined || PARAMS._js1002 == null || PARAMS._js1002 <= 1) PARAMS._js1002 = 99;
  </script>
  
  <!-- ExtJs 模块引用开始 -->
  <!-- 样式表引用 -->
  <link rel="stylesheet" type="text/css" href="../Extjs_lib/resources/css/ext-all.css" />  
  <% ="<link rel=""stylesheet"" type=""text/css"" href=""../Extjs_lib/resources/css/xtheme-" & clsParameterManager.mFnGetParameters(GP_EXTJS_THEMES) & ".css"" />"%>
  <!-- GC -->
  <script type="text/javascript" src="../JScript/GridListViewSrno.js"></script>
  <!-- LIBS -->
  <script type="text/javascript" src="../Extjs_lib/adapter/ext/ext-base.js"></script>
  <script type="text/javascript" src="../Extjs_lib/ext-all-debug.js"></script> 
  <!-- ENDLIBS -->
  <script type="text/javascript" src="../Extjs_lib/src/locale/ext-lang-<% =mStrGlobal_Language %>.js"></script>
  <script type="text/javascript" src="../JScript/ExtJsGlobalService.js"></script>
  <!-- Load the Dojo library --> 
	<script type="text/javascript" src="<% =clsParameterManager.mFnGetParameters(GP_DOJO_LIB_PATH) %>dojo/dojo.xd.js" 
        djConfig="parseOnLoad:true,isDebug:false,locale:'<% =mStrGlobal_Language %>',bindEncoding:'UTF-8',useCommentedJson:true"></script>
	<!-- Load the core Cometd library -->
	<script type="text/javascript" src="../JScript/CometD/cometd.js"></script>
	<script type="text/javascript" src="../JScript/CometD/dojox.cometd.js"></script>
	<script type="text/javascript" src="../JScript/CometD/cometDConfig.js"></script>
	
  <script type="text/javascript" src="../JScript/ExtJsRequest.js"></script>
  <script type="text/javascript" src="ManageMainExtJsScript.js"></script>
  <!-- ExtJs 模块结束 -->
  
  <script language="javascript">
  //初始化全局服务类
  var mGlobalService = new jsClsGlobalService({
    DateFormat: PARAMS._js1000,
    TimeFormat: PARAMS._js1001
  });
  //指定时事通讯回调处理函数
  function handleIncomingMessage(comet){
    ManageMain.app.handleIncomingMessage(comet);
  };
  </script>
</head>
<body>
  <!-- 标题栏 -->
  <div id="pnlHeader" style="background-image: url('../Images/hd-bg.gif');color: White" align="center">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 98%;">
      <tr>
        <td valign="middle" align="left" style="width: 80%;">
          <img src="../Images/logo.png" border="0"/>
        </td>
        <td valign="middle" align="right" style="width: 20%;">
          <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Text="UserName" CssClass="UserName"></asp:Label>
          |
          <asp:HyperLink ID="lnkConfig" runat="server" style="color:White" NavigateUrl="#"><% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1020", mIntGlobal_Language_Indc)%></asp:HyperLink>
          |
          <asp:HyperLink ID="lnkSignOut" runat="server" style="color:White" NavigateUrl="#"><% =clsLanguageDictionaryManager.mFnGetLanguageDesc("1021", mIntGlobal_Language_Indc)%></asp:HyperLink>
          </td>
      </tr>
    </table>
  </div>
  
  <!-- 内容页面 使用嵌入式框架 -->
  <div id="pnlContent" style="height: 100%">
    <iframe frameborder="0" name="_InnerPage" id="InnerPage" width="100%" height="100%" scrolling="auto" src="ManageSubFrame.aspx"></iframe>
  </div>
  
</body>
</html>