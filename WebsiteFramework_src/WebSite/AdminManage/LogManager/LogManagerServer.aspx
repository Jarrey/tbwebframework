<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LogManagerServer.aspx.vb" Inherits="WebSite.LogManagerServer" %>
<%@ Import Namespace="Manage" %>
<%@ Import Namespace="ResponseServer" %>
<% 
  Dim lObjclsLogManagerServer As New clsLogManagerServer
  lObjclsLogManagerServer.mProcessRequest(Request, Response)
%>
