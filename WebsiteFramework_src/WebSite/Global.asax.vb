Imports System.Web.SessionState

Imports DataAccess
Imports Utils
Imports Manage

Public Class Global_asax
  Inherits System.Web.HttpApplication

  Private mObjRealTimeCommunicationServer As New RealTimeCommunicationServer.ServerConfig

  Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
    ' 应用程序启动时激发
    ' 设置站点启动物理路径
    clsSharedMemory.mStrApplicationPath = Server.MapPath("~")
    '日志目录
    clsLogManager.mPrpUserLogsPath = clsSharedMemory.mStrApplicationPath & "\Logs"
    '数据库目录
    clsConnectionManager.mPrpSystemDBPath = clsSharedMemory.mStrApplicationPath & "\Database\DB.dat"
    '将参数表载入内存,提高性能
    clsParameterManager.mPrLoadParameters(clsSharedMemory.mDtParameterDataTable)
    '将字典表载入内存,提高性能
    mStrGlobal_Language = clsParameterManager.mFnGetParameters(GP_LANGUAGE, mIntGlobal_Language_Indc)
    clsLanguageDictionaryManager.mPrLoadLanguageDictionary(clsSharedMemory.mDtLanguageDictionary, mIntGlobal_Language_Indc)
    clsMessageDictionaryManager.mPrLoadMessageDictionary(clsSharedMemory.mDtMessageDictionary, mIntGlobal_Language_Indc)

    '初始化时事通讯服务模块
    mObjRealTimeCommunicationServer.ServerConfigStart()

  End Sub

  Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    ' 会话启动时激发
  End Sub

  Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
    ' 每个请求开始时激发
  End Sub

  Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
    ' 尝试验证用户身份时激发
  End Sub

  Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    ' 发生错误时激发
    Dim ex As Exception = Server.GetLastError()
    If Not TypeOf ex Is HttpException Then
      ' Stop error from displaying on the client browser
      Context.ClearError()
      clsExceptionManager.mInsertExceptionLog(ex)
    End If
  End Sub

  Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    ' 会话结束时激发
  End Sub

  Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    ' 应用程序结束时激发
    mObjRealTimeCommunicationServer.ServerConfigEnd()
  End Sub

End Class