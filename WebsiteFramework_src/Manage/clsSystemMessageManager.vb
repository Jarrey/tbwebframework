
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2010-01-25                                          *'
'*   Synopsis     : System Message Manager class                        *'
'*                                                                      *'
'*   Modifications:                                                     *'
'************************************************************************'
'* Date     Author Mod. FTR No. Description                             *'
'* -------- ------ ---- ------- -------------------------------------   *'
'*
'*
'*
'* -------- ------ ---- ------- -------------------------------------   *'
'************************************************************************'
#End Region

Imports DataAccess
Imports Utils
Imports ResponseMessageStructs
Imports RealTimeCommunicationServer
Imports System.Data.SQLite
Imports System.Text.RegularExpressions

Public Class clsSystemMessageManager

  ''' <summary>
  ''' 查询所有系统消息数据
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mPopulateAllSystemMessage() As List(Of clsSystemMessageStruct)
    Dim lArrRtn As New List(Of clsSystemMessageStruct)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblSystemMessage As New TableClass.clsTB_SYSTEM_MESSAGE
    Dim lObjSystemMessage As clsSystemMessageStruct = Nothing

    lObjTblSystemMessage.mPrRetrieveData(lDtDataReader, TableClass.clsTB_SYSTEM_MESSAGE.enmQueryIndicator.ALL)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblSystemMessage.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_SYSTEM_MESSAGE.enmQueryIndicator.ALL)
        lObjSystemMessage = New clsSystemMessageStruct
        With lObjSystemMessage
          .mPrpSystemMessageSrno = lDtDataReader.Item("SM_SYSTEM_MESSAGE_SRNO")
          .mPrpMessageTime = lDtDataReader.Item("SM_MESSAGE_TIME")
          .mPrpMessageType = lDtDataReader.Item("SM_MESSAGE_TYPE")
          .mPrpMessageLevel = lDtDataReader.Item("SM_MESSAGE_LEVEL")
          .mPrpSystemMessage = lDtDataReader.Item("SM_SYSTEM_MESSAGE")
          .mPrpCreateUserSrno = lDtDataReader.Item("SM_CREATE_USER_SRNO")
        End With
        lArrRtn.Add(lObjSystemMessage)
      End While
    End If

    Return lArrRtn
  End Function

  ''' <summary>
  ''' 删除所有数据
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mDeleteAllSystemMessage() As Boolean
    Dim lObjTblSystemMessage As New TableClass.clsTB_SYSTEM_MESSAGE
    Try
      lObjTblSystemMessage.mFnDeleteAll()
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  ''' <summary>
  ''' 静态方法 发布系统消息
  ''' </summary>
  ''' <param name="aEnmMsgType"></param>
  ''' <param name="aStrMsg"></param>
  ''' <remarks></remarks>
  Public Shared Sub mPrPushSystemMessage(ByVal aEnmMsgType As clsSystemMessageStruct.EnmMessageType, _
                                  ByVal aStrMsg As String, _
                                  Optional ByVal aStrUserName As String = "System", _
                                  Optional ByVal aEnmSystemMessageLevel As clsSystemMessageStruct.EnmMessageLevel = clsSystemMessageStruct.EnmMessageLevel.NORMAL)

    Dim lObjMessage As New MessageStruct.clsSystemMessageStruct
    Dim lObjTblSystemMessage As New TableClass.clsTB_SYSTEM_MESSAGE
    Dim lLngSystemMessageSrno As Long = 0
    '获取系统消息最大字符数
    Dim lIntSystenMaxCharCount As Integer = CInt(clsParameterManager.mFnGetParameters(GP_SYSTEM_MESSAGE_CHAR_COUNT))
    '获得系统定义的日志记录级别
    Dim lEnmSystemMessageLevelSetValue As clsSystemMessageStruct.EnmMessageLevel = CInt(clsParameterManager.mFnGetParameters(GP_SYSTEM_MESSAGE_LEVEL))

    If lEnmSystemMessageLevelSetValue <> clsSystemMessageStruct.EnmMessageLevel.ALL And _
       aEnmSystemMessageLevel < lEnmSystemMessageLevelSetValue Then _
      Exit Sub

    Try

      If aStrMsg.Length >= lIntSystenMaxCharCount Then _
        aStrMsg = aStrMsg.Substring(0, lIntSystenMaxCharCount) & " ... (" & _
                  clsMessageDictionaryManager.mFnGetMessageDesc(1013, mIntGlobal_Language_Indc, New String() {lIntSystenMaxCharCount.ToString}) & ")"

      aStrMsg = aStrMsg.Replace("&", "&amp;")
      aStrMsg = aStrMsg.Replace("""", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;")

      '记录数据库日志表
      With lObjTblSystemMessage
        lLngSystemMessageSrno = .mFnMaxId + 1
        .mPrpSM_SYSTEM_MESSAGE_SRNO = lLngSystemMessageSrno
        .mPrpSM_MESSAGE_TIME = Now
        .mPrpSM_MESSAGE_TYPE = aEnmMsgType
        .mPrpSM_MESSAGE_LEVEL = aEnmSystemMessageLevel
        .mPrpSM_CREATE_USER_SRNO = 1
        .mPrpSM_SYSTEM_MESSAGE = aStrMsg
        .mFnInsert()
      End With

      With lObjMessage
        .prpLngSystemMessageSrno = lLngSystemMessageSrno
        .prpStrSystemMessageTime = Now.ToString("yyyy-MM-dd hh:mm:ss")
        .prpStrSystemMessageType = clsSystemMessageStruct.mFnGetTypeDesc(aEnmMsgType)
        .prpStrUserName = aStrUserName
        .prpStrSystemMessage = aStrMsg
        .prpStrMessageLevel = aEnmSystemMessageLevel
      End With

      clsSystemMessageServer.mLstMessage.Add(lObjMessage)

      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.SYSTEM_INFO, " Pushed a System Message : " & aEnmMsgType.ToString & " - " & aStrMsg, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try

  End Sub

End Class
