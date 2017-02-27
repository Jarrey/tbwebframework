Imports ResponseMessageStructs
Imports Manage
Imports Utils
Imports System.Web
Imports Newtonsoft.Json

''' <summary>
''' 异常管理服务端处理类
''' </summary>
''' <remarks></remarks>
Public Class clsExceptionManagerServer
  Inherits clsBaseServer

  ''' <summary>
  ''' 注册处理方法
  ''' </summary>
  ''' <remarks></remarks>
  Sub New()
    MyBase.New()
    ResponseServerRegister(EnmRequestIndc.RQ_SEARCH, New mDlgProcessFunction(AddressOf mPrProcessSerachException))
    ResponseServerRegister(EnmRequestIndc.RQ_UPDATE, New mDlgProcessFunction(AddressOf mPrProcessUpdateException))
    ResponseServerRegister(EnmRequestIndc.RQ_DELETE, New mDlgProcessFunction(AddressOf mPrProcessDeleteException))
    ResponseServerRegister(EnmRequestIndc.RQ_DELETEALL, New mDlgProcessFunction(AddressOf mPrProcessDeleteAllException))
    ResponseServerRegister(EnmRequestIndc.RQ_INIT_GRIDVIEW, New mDlgProcessFunction(AddressOf MyBase.mPrProcessInitGridView))
    ResponseServerRegister(EnmRequestIndc.RQ_INIT_LST_CONTROLS, New mDlgProcessFunction(AddressOf MyBase.mPrProcessInitLstControls))
  End Sub

  Private mObjExceptionManager As New clsExceptionManager

  ''' <summary>
  ''' 处理异步查询请求,返回数据
  ''' 返回数据类型 Json 数据
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessSerachException(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '声明
    Dim lObjFromDate As New Date
    Dim lObjToDate As New Date
    Dim lEnmStatus As clsExceptionMessageStruct.EnmExceptionStatus
    Dim lObjList As New List(Of clsExceptionMessageStruct)

    Try
      '获得请求数据
      If IsDate(aObjRequest("prFromDate")) Then lObjFromDate = CDate(aObjRequest("prFromDate"))
      If IsDate(aObjRequest("prToDate")) Then lObjToDate = CDate(aObjRequest("prToDate"))
      If IsNumeric(aObjRequest("prExceptionStatus")) Then lEnmStatus = CInt(aObjRequest("prExceptionStatus"))

      '生成回复值
      lObjList = mObjExceptionManager.mPopulateException(lObjFromDate, lObjToDate, lEnmStatus)
      If lObjList.Count = 0 Then
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1000, mIntGlobal_Language_Indc)
      Else
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1002, mIntGlobal_Language_Indc, New String() {lObjList.Count.ToString})
      End If
      mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.SUCCESS
      mObjResponseMessage.mPrpMessageBody = clsExceptionMessageStruct.ToJSONArray(lObjList)
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

  ''' <summary>
  ''' 处理异步更新请求,返回更新结果 返回数据类型 Json 类型
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessUpdateException(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '声明
    Dim lLngExceptionSrno As Long = 0
    Dim lEnmStatus As clsExceptionMessageStruct.EnmExceptionStatus

    Try
      '获得请求数据
      If IsNumeric(aObjRequest("prExceptionSrno")) Then lLngExceptionSrno = CLng(aObjRequest("prExceptionSrno"))
      If IsNumeric(aObjRequest("prExceptionStatus")) Then lEnmStatus = CInt(aObjRequest("prExceptionStatus"))

      '更新数据
      If mObjExceptionManager.mUpdateException(lLngExceptionSrno, lEnmStatus) Then
        '生成回复值
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1004, mIntGlobal_Language_Indc)
        mObjResponseMessage.mPrpMessageBody = mObjExceptionManager.mPopulateException(lLngExceptionSrno).ToJSONString
      Else
        mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.FAIL
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1003, mIntGlobal_Language_Indc)
      End If
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

  ''' <summary>
  ''' 处理异步删除请求,返回删除结果 返回数据类型 Json 类型
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessDeleteException(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '声明
    Dim lLngExceptionSrno As Long = 0

    Try
      '获得请求数据
      If IsNumeric(aObjRequest("prExceptionSrno")) Then lLngExceptionSrno = CLng(aObjRequest("prExceptionSrno"))

      '更新数据
      If mObjExceptionManager.mDeleteException(lLngExceptionSrno) Then
        '生成回复值
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1005, mIntGlobal_Language_Indc)
        mObjResponseMessage.mPrpMessageBody = "{jsId:" & lLngExceptionSrno.ToString & "}"
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

  ''' <summary>
  ''' 处理异步删除全部请求,返回删除结果 返回数据类型 Json 类型
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessDeleteAllException(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)
    Try
      '更新数据
      If mObjExceptionManager.mDeleteAllException() Then
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