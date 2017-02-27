
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-03                                          *'
'*   Synopsis     : Message Language Manager class                      *'
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
Imports System.Data.SQLite

Public Class clsMessageDictionaryManager

  ''' <summary>
  ''' 获得指定序列号和语言种类的字段值
  ''' 静态函数
  ''' </summary>
  ''' <param name="aLngMessageSrno"></param>
  ''' <param name="aEnmLang"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetMessageDesc(ByVal aLngMessageSrno As Long, Optional ByVal aEnmLang As clsMessageDictionaryStruct.EnmLanguage = clsMessageDictionaryStruct.EnmLanguage.ZH, Optional ByVal aArrPram() As String = Nothing) As String
    Dim lStrRtn As String = String.Empty

    If IsNothing(clsSharedMemory.mDtMessageDictionary) OrElse clsSharedMemory.mDtMessageDictionary.Rows.Count = 0 Then

      Dim lObjTblMessageDictionary As New TableClass.clsTB_MESSAGE_DICTIONARY
      Dim lObjDataReader As SQLiteDataReader = Nothing

      With lObjTblMessageDictionary
        .mPrpMD_MESSAGE_SRNO = aLngMessageSrno
        .mPrpMD_MESSAGE_LANG = aEnmLang
        .mPrRetrieveData(lObjDataReader, TableClass.clsTB_MESSAGE_DICTIONARY.enmQueryIndicator.SELECT_SRNO_LANG)


        If lObjDataReader IsNot Nothing Then
          While .mFnRetrieveNextRecord(lObjDataReader, TableClass.clsTB_MESSAGE_DICTIONARY.enmQueryIndicator.SELECT_SRNO_LANG)
            lStrRtn = lObjDataReader.Item("MD_MESSAGE_DESC").ToString
          End While
        End If
      End With

      mPrLoadMessageDictionary(clsSharedMemory.mDtMessageDictionary)

    Else

      Dim lObjRows() As DataRow = clsSharedMemory.mDtMessageDictionary.Select("MD_MESSAGE_SRNO = '" & aLngMessageSrno & "' And MD_MESSAGE_LANG = " & aEnmLang)

      For Each lObjRow As DataRow In lObjRows
        lStrRtn = lObjRow.Item("MD_MESSAGE_DESC").ToString
      Next

    End If

    If Not IsNothing(aArrPram) Then
      If lStrRtn.Trim.Length > 0 Then
        For i As Integer = 1 To aArrPram.Length
          lStrRtn = Replace(lStrRtn, "%p" + (i).ToString, aArrPram(i - 1))
        Next
      End If
    End If

    Return lStrRtn
  End Function

  ''' <summary>
  ''' 载入字典数据
  ''' </summary>
  ''' <param name="aDtMessageDictionaryDataTable"></param>
  ''' <remarks></remarks>
  Public Shared Sub mPrLoadMessageDictionary(ByRef aDtMessageDictionaryDataTable As DataTable, Optional ByVal aEnmLang As clsMessageDictionaryStruct.EnmLanguage = Nothing)
    Dim lObjTblMessageDictionary As New TableClass.clsTB_MESSAGE_DICTIONARY
    Dim lObjDataSet As New DataSet
    If IsNothing(aDtMessageDictionaryDataTable) Then aDtMessageDictionaryDataTable = New DataTable
    If IsNothing(aEnmLang) OrElse aEnmLang = 0 Then
      lObjTblMessageDictionary.mPrRetrieveData(lObjDataSet, TableClass.clsTB_MESSAGE_DICTIONARY.enmQueryIndicator.ALL)
    Else
      lObjTblMessageDictionary.mPrpMD_MESSAGE_LANG = aEnmLang
      lObjTblMessageDictionary.mPrRetrieveData(lObjDataSet, TableClass.clsTB_MESSAGE_DICTIONARY.enmQueryIndicator.SELECT_LANG)
    End If
    aDtMessageDictionaryDataTable.Clear()
    aDtMessageDictionaryDataTable = lObjDataSet.Tables(0)
  End Sub

End Class
