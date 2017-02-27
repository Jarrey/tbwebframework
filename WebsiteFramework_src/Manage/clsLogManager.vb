
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-10-21                                          *'
'*   Synopsis     : log Manager class                                   *'
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
Imports Newtonsoft.Json
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class clsLogManager

#Region "CLASS MEMBER VARIABLES"
  Private Shared mStrUserLogsPath As String = String.Empty
#End Region

#Region "CLASS MEMBER PROPERTIES"
  Public Shared Property mPrpUserLogsPath() As String
    Get
      Return mStrUserLogsPath
    End Get
    Set(ByVal value As String)
      mStrUserLogsPath = value
    End Set
  End Property
#End Region

  ''' <summary>
  ''' 根据条件查询异常数据
  ''' </summary>
  ''' <param name="aObjFromDate"></param>
  ''' <param name="aObjToDate"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mPopulateLog(ByVal aObjFromDate As Date, ByVal aObjToDate As Date, ByVal aEnmLogCategory As clsLogMessagrStruct.EnmLogCategory) As List(Of clsLogMessagrStruct)
    Dim lArrRtn As New List(Of clsLogMessagrStruct)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblLogManager As New TableClass.clsTB_LOG_MANAGER
    Dim lObjLog As clsLogMessagrStruct = Nothing

    lObjTblLogManager.mPrpFromDate = aObjFromDate
    lObjTblLogManager.mPrpToDate = aObjToDate
    lObjTblLogManager.mPrpLM_CATEGORY = aEnmLogCategory
    lObjTblLogManager.mPrRetrieveData(lDtDataReader, TableClass.clsTB_LOG_MANAGER.enmQueryIndicator.SELECT_DATE_CATEGORY)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblLogManager.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_LOG_MANAGER.enmQueryIndicator.SELECT_DATE_CATEGORY)
        lObjLog = New clsLogMessagrStruct
        With lObjLog
          .mPrpLogFileSrno = lDtDataReader.Item("LM_LOG_FILE_SRNO")
          .mPrpDateTime = lDtDataReader.Item("LM_DATE_TIME")
          .mPrpLogCategory = lDtDataReader.Item("LM_CATEGORY")
          .mPrpLogLevel = lDtDataReader.Item("LM_LEVEL")
          .mPrpLogFileName = lDtDataReader.Item("LM_LOG_FILE_NAME")
        End With
        lArrRtn.Add(lObjLog)
      End While
    End If

    Return lArrRtn
  End Function

  ''' <summary>
  ''' 查询所有的异常数据
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mPopulateAllLog() As List(Of clsLogMessagrStruct)
    Dim lArrRtn As New List(Of clsLogMessagrStruct)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblLogManager As New TableClass.clsTB_LOG_MANAGER
    Dim lObjLog As clsLogMessagrStruct = Nothing

    lObjTblLogManager.mPrRetrieveData(lDtDataReader, TableClass.clsTB_LOG_MANAGER.enmQueryIndicator.ALL)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblLogManager.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_LOG_MANAGER.enmQueryIndicator.ALL)
        lObjLog = New clsLogMessagrStruct
        With lObjLog
          .mPrpLogFileSrno = lDtDataReader.Item("LM_LOG_FILE_SRNO")
          .mPrpDateTime = lDtDataReader.Item("LM_DATE_TIME")
          .mPrpLogCategory = lDtDataReader.Item("LM_CATEGORY")
          .mPrpLogLevel = lDtDataReader.Item("LM_LEVEL")
          .mPrpLogFileName = lDtDataReader.Item("LM_LOG_FILE_NAME")
        End With
        lArrRtn.Add(lObjLog)
      End While
    End If

    Return lArrRtn
  End Function

  ''' <summary>
  ''' 删除所有异常数据
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mDeleteAllLog() As Boolean
    Dim lObjTblLogManager As New TableClass.clsTB_LOG_MANAGER
    Try
      For Each lObjLogMessagrStruct As clsLogMessagrStruct In mPopulateAllLog()
        IO.File.Delete(clsSharedMemory.mStrApplicationPath & "\Logs\" & lObjLogMessagrStruct.mPrpLogFileName)
      Next
      lObjTblLogManager.mFnDeleteAll()
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  ''' <summary>
  ''' 静态方法 记录日志
  ''' </summary>
  ''' <param name="aEnmMsgType"></param>
  ''' <param name="aStrMsg"></param>
  ''' <remarks></remarks>
  Public Shared Sub mPrLogAppInfo(ByVal aEnmMsgType As clsLogMessagrStruct.EnmLogCategory, _
                                  ByVal aStrMsg As String, _
                                  Optional ByVal aEnmLogLevel As clsLogMessagrStruct.EnmLogLevel = clsLogMessagrStruct.EnmLogLevel.NORMAL)

    Dim lStrLogsPath As String = mStrUserLogsPath
    Dim lStrBuilder As New StringBuilder
    Dim lStrLogFileName As String = String.Empty
    Dim lObjFileStream As FileStream = Nothing

    '获得系统定义的日志记录级别
    Dim lEnmLogLevelSetValue As clsLogMessagrStruct.EnmLogLevel = CInt(clsParameterManager.mFnGetParameters(GP_LOG_LEVEL))

    If lEnmLogLevelSetValue <> clsLogMessagrStruct.EnmLogLevel.ALL And _
       aEnmLogLevel < lEnmLogLevelSetValue Then _
      Exit Sub

    Select Case aEnmMsgType
      Case clsLogMessagrStruct.EnmLogCategory.EXCEPTION
        lStrLogFileName = Now.ToString("yyyyMMdd") & ".Exception_Log_" & aEnmLogLevel.ToString & ".html"
      Case clsLogMessagrStruct.EnmLogCategory.NORMAL
        lStrLogFileName = Now.ToString("yyyyMMdd") & ".Normal_Log_" & aEnmLogLevel.ToString & ".html"
      Case clsLogMessagrStruct.EnmLogCategory.SYSTEM_INFO
        lStrLogFileName = Now.ToString("yyyyMMdd") & ".System_Info_Log_" & aEnmLogLevel.ToString & ".html"
      Case clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO
        lStrLogFileName = Now.ToString("yyyyMMdd") & ".Debug_Info_Log_" & aEnmLogLevel.ToString & ".html"
    End Select
    lStrLogsPath = lStrLogsPath & "\" & lStrLogFileName

    If Not File.Exists(lStrLogsPath) Then
      lObjFileStream = File.Create(lStrLogsPath)
      lObjFileStream.Close()
      '记录数据库日志表
      Dim lObjTblLogManager As New TableClass.clsTB_LOG_MANAGER
      With lObjTblLogManager
        .mPrpLM_LOG_FILE_SRNO = lObjTblLogManager.mFnMaxId + 1
        .mPrpLM_DATE_TIME = Now
        .mPrpLM_CATEGORY = aEnmMsgType
        .mPrpLM_LEVEL = aEnmLogLevel
        .mPrpLM_LOG_FILE_NAME = lStrLogFileName
        .mFnInsert()
      End With
    End If

    Using lObjStreamWriter As StreamWriter = File.AppendText(lStrLogsPath)
      lStrBuilder.Append("<div style=""fonst-size:10px;width: 100%""><p style=""font-style: italic"">" & Now.ToString("yyyy-MM-dd hh:mm:ss") & "</p>")
      Select Case aEnmMsgType
        Case clsLogMessagrStruct.EnmLogCategory.EXCEPTION
          lStrBuilder.Append("<p style=""color: red"">[EXCEPTION]</p>")
        Case clsLogMessagrStruct.EnmLogCategory.NORMAL
          lStrBuilder.Append("<p style=""color: blue"">[NORMAL]</p>")
        Case clsLogMessagrStruct.EnmLogCategory.SYSTEM_INFO
          lStrBuilder.Append("<p style=""color: orange"">[SYSTEM_INFO]</p>")
        Case clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO
          lStrBuilder.Append("<p style=""color: orange"">[DEBUG_INFO]</p>")
      End Select
      lStrBuilder.Append(aStrMsg & "</div>")
      lStrBuilder.Append("-----------------------------")
      lObjStreamWriter.WriteLine(lStrBuilder.ToString())
    End Using

  End Sub

End Class
