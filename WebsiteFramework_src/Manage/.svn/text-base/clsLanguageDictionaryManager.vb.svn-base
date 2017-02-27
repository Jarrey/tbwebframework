
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-03                                          *'
'*   Synopsis     : Language Manager class                              *'
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

Public Class clsLanguageDictionaryManager

  ''' <summary>
  ''' 获得指定序列号和语言种类的字段值
  ''' 静态函数
  ''' </summary>
  ''' <param name="aStrItemSrno"></param>
  ''' <param name="aEnmLang"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetLanguageDesc(ByVal aStrItemSrno As String, Optional ByVal aEnmLang As clsLanguageDictionaryStruct.EnmLanguage = clsLanguageDictionaryStruct.EnmLanguage.ZH) As String
    Dim lArrItemSrno As String() = aStrItemSrno.Split("|")
    Dim lStrRtn As String = String.Empty

    For Each lStrItemSrno As String In lArrItemSrno
      If IsNumeric(lStrItemSrno) Then
        If IsNothing(clsSharedMemory.mDtLanguageDictionary) OrElse clsSharedMemory.mDtLanguageDictionary.Rows.Count = 0 Then

          Dim lObjTblLanguageDictionary As New TableClass.clsTB_LANG_DICTIONARY
          Dim lObjDataReader As SQLiteDataReader = Nothing

          With lObjTblLanguageDictionary
            .mPrpLD_ITEM_SRNO = CLng(lStrItemSrno)
            .mPrpLD_ITEM_LANG = aEnmLang
            .mPrRetrieveData(lObjDataReader, TableClass.clsTB_LANG_DICTIONARY.enmQueryIndicator.SELECT_SRNO_LANG)


            If lObjDataReader IsNot Nothing Then
              While .mFnRetrieveNextRecord(lObjDataReader, TableClass.clsTB_LANG_DICTIONARY.enmQueryIndicator.SELECT_SRNO_LANG)
                lStrRtn = lStrRtn & lObjDataReader.Item("LD_DESC").ToString
              End While
            End If
          End With

          mPrLoadLanguageDictionary(clsSharedMemory.mDtLanguageDictionary)

        Else

          Dim lObjRows() As DataRow = clsSharedMemory.mDtLanguageDictionary.Select("LD_ITEM_SRNO = '" & lStrItemSrno & "' And LD_ITEM_LANG = " & aEnmLang)

          For Each lObjRow As DataRow In lObjRows
            lStrRtn = lStrRtn & lObjRow.Item("LD_DESC").ToString
          Next

        End If
      End If
    Next

    Return lStrRtn
  End Function

  ''' <summary>
  ''' 载入字典数据
  ''' </summary>
  ''' <param name="aDtLanguageDictionaryDataTable"></param>
  ''' <remarks></remarks>
  Public Shared Sub mPrLoadLanguageDictionary(ByRef aDtLanguageDictionaryDataTable As DataTable, Optional ByVal aEnmLang As clsLanguageDictionaryStruct.EnmLanguage = Nothing)
    Dim lObjTblLanguageDictionary As New TableClass.clsTB_LANG_DICTIONARY
    Dim lObjDataSet As New DataSet
    If IsNothing(aDtLanguageDictionaryDataTable) Then aDtLanguageDictionaryDataTable = New DataTable
    If IsNothing(aEnmLang) OrElse aEnmLang = 0 Then
      lObjTblLanguageDictionary.mPrRetrieveData(lObjDataSet, TableClass.clsTB_LANG_DICTIONARY.enmQueryIndicator.ALL)
    Else
      lObjTblLanguageDictionary.mPrpLD_ITEM_LANG = aEnmLang
      lObjTblLanguageDictionary.mPrRetrieveData(lObjDataSet, TableClass.clsTB_LANG_DICTIONARY.enmQueryIndicator.SELECT_LANG)
    End If
    aDtLanguageDictionaryDataTable.Clear()
    aDtLanguageDictionaryDataTable = lObjDataSet.Tables(0)
  End Sub

End Class
