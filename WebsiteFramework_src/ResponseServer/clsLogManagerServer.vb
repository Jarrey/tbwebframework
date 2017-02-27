Imports ResponseMessageStructs
Imports Manage
Imports Utils
Imports System.Web

''' <summary>
''' ��־����������˴�����
''' </summary>
''' <remarks></remarks>
Public Class clsLogManagerServer
  Inherits clsBaseServer

  ''' <summary>
  ''' ע�ᴦ����
  ''' </summary>
  ''' <remarks></remarks>
  Sub New()
    MyBase.New()
    ResponseServerRegister(EnmRequestIndc.RQ_INIT_GRIDVIEW, New mDlgProcessFunction(AddressOf MyBase.mPrProcessInitGridView))
    ResponseServerRegister(EnmRequestIndc.RQ_INIT_LST_CONTROLS, New mDlgProcessFunction(AddressOf MyBase.mPrProcessInitLstControls))
    ResponseServerRegister(EnmRequestIndc.RQ_SEARCH, New mDlgProcessFunction(AddressOf mPrProcessSerachLog))
    ResponseServerRegister(EnmRequestIndc.RQ_DELETEALL, New mDlgProcessFunction(AddressOf mPrProcessDeleteAllLog))
  End Sub

  Private mObjLogManager As New clsLogManager

  ''' <summary>
  ''' �����첽��ѯ����,��������
  ''' ������������ Json ����
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessSerachLog(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '����
    Dim lObjFromDate As New Date
    Dim lObjToDate As New Date
    Dim lEnmLogCategory As clsLogMessagrStruct.EnmLogCategory
    Dim lObjList As New List(Of clsLogMessagrStruct)

    Try
      '�����������
      If IsDate(aObjRequest("prFromDate")) Then lObjFromDate = CDate(aObjRequest("prFromDate"))
      If IsDate(aObjRequest("prToDate")) Then lObjToDate = CDate(aObjRequest("prToDate"))
      If IsNumeric(aObjRequest("prLogCategory")) Then lEnmLogCategory = aObjRequest("prLogCategory")

      '���ɻظ�ֵ
      lObjList = mObjLogManager.mPopulateLog(lObjFromDate, lObjToDate, lEnmLogCategory)
      If lObjList.Count = 0 Then
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1000, mIntGlobal_Language_Indc)
      Else
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1002, mIntGlobal_Language_Indc, New String() {lObjList.Count.ToString})
      End If
      mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.SUCCESS
      mObjResponseMessage.mPrpMessageBody = clsLogMessagrStruct.ToJSONArray(lObjList)
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

  ''' <summary>
  ''' �����첽ɾ��ȫ������,����ɾ����� ������������ Json ����
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessDeleteAllLog(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)
    Try
      '��������
      If mObjLogManager.mDeleteAllLog() Then
        '���ɻظ�ֵ
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
