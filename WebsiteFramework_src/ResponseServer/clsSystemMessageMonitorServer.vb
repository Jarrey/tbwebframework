Imports ResponseMessageStructs
Imports Manage
Imports Utils
Imports System.Web

''' <summary>
''' ϵͳ��Ϣ��ط���˴�����
''' </summary>
''' <remarks></remarks>
Public Class clsSystemMessageMonitorServer
  Inherits clsBaseServer

  ''' <summary>
  ''' ע�ᴦ����
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
  ''' �����첽��ѯ����,��������
  ''' ������������ Json ����
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessSerachAllSystemMessage(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '����
    Dim lObjList As New List(Of clsSystemMessageStruct)

    Try
      '���ɻظ�ֵ
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
  ''' �����첽ɾ��ȫ������,����ɾ����� ������������ Json ����
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Private Sub mPrProcessDeleteAllSystemMessage(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)
    Try
      '��������
      If mObjSystemMessageManager.mDeleteAllSystemMessage() Then
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
