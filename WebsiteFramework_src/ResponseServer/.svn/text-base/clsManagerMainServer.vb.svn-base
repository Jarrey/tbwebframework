Imports ResponseMessageStructs
Imports Manage
Imports Utils
Imports System.Web

''' <summary>
''' 主管理页服务端处理类
''' </summary>
''' <remarks></remarks>
Public Class clsManagerMainServer
  Inherits clsBaseServer

  ''' <summary>
  ''' 注册处理方法
  ''' </summary>
  ''' <remarks></remarks>
  Sub New()
    MyBase.New()
    ResponseServerRegister(EnmRequestIndc.RQ_INIT_MENU, New mDlgProcessFunction(AddressOf mPrProcessInitMenu))
    ResponseServerRegister(EnmRequestIndc.RQ_INIT_LST_VIEW, New mDlgProcessFunction(AddressOf MyBase.mPrProcessInitListView))
  End Sub

  Private mObjMenuManager As New clsMeunManager

  ''' <summary>
  ''' 处理异步初始化菜单请求,返回菜单数据,返回类型Json
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessInitMenu(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)
    '声明
    Dim lIntMenuCategory As Integer
    Dim lObjList As New List(Of clsMenuMessageStructJsonStruct)
  
    Try
      '获得请求数据
      If IsNumeric(aObjRequest("prMenuCategory")) Then lIntMenuCategory = CInt(aObjRequest("prMenuCategory"))

      '生成回复值
      lObjList = mObjMenuManager.mPopulateMenu(lIntMenuCategory)
      If lObjList.Count = 0 Then
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1007, mIntGlobal_Language_Indc)
      Else
        mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.SUCCESS
        mObjResponseMessage.mPrpMessageBody = clsMenuMessageStructJsonStruct.ToJSONArray(lObjList)
      End If
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

End Class
