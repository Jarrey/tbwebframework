Imports ResponseMessageStructs
Imports Manage
Imports Utils
Imports System.Web

''' <summary>
''' 系统消息监控服务端处理类
''' </summary>
''' <remarks></remarks>
Public Class clsSystemMessageMonitorServer
  Inherits clsBaseServer

  ''' <summary>
  ''' 注册处理方法
  ''' </summary>
  ''' <remarks></remarks>
  Sub New()
    MyBase.New()
    ResponseServerRegister(EnmRequestIndc.RQ_INIT_GRIDVIEW, New mDlgProcessFunction(AddressOf MyBase.mPrProcessInitGridView))
    ResponseServerRegister(EnmRequestIndc.RQ_SEARCHALL, New mDlgProcessFunction(AddressOf mPrProcessSerachAllSystemMessage))
    ResponseServerRegister(EnmRequestIndc.RQ_DELETEALL, New mDlgProcessFunction(AddressOf mPrProcessDeleteAllSystemMessage))
  End Sub

  Private mObjSystemMessageManager As New clsSystemMessageManager

  ''' <summary>
  ''' 处理异步查询请求,返回数据
  ''' 返回数据类型 Json 数据
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessSerachAllSystemMessage(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '声明
    Dim lObjList As New List(Of clsSystemMessageStruct)

    Try
      '生成回复值
      lObjList = mObjSystemMessageManager.mPopulateAllSystemMessage()
      If lObjList.Count = 0 Then
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1000, mIntGlobal_Language_Indc)
      Else
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1002, mIntGlobal_Language_Indc, New String() {lObjList.Count.ToString})
      End If
      mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.SUCCESS
      mObjResponseMessage.mPrpMessageBody = clsSystemMessageStruct.ToJSONArray(lObjList)
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

  ''' <summary>
  ''' 处理异步删除全部请求,返回删除结果 返回数据类型 Json 类型
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessDeleteAllSystemMessage(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)
    Try
      '更新数据
      If mObjSystemMessageManager.mDeleteAllSystemMessage() Then
        '生成回复值
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1005, mIntGlobal_Language_Indc)
      Else
        mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.FAIL
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1006, mIntGlobal_Language_Indc)
      End If
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

End Class
