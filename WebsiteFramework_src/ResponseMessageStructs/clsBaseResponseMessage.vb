Imports Newtonsoft.Json
Imports System.Data.sqlite
Imports System.Text.RegularExpressions
Imports DataAccess
Imports Utils

Public Class clsBaseResponseMessage
  Implements IResponseMessage

  Public Overrides Function toString() As String
    Return ToJSONString()
  End Function

  ''' <summary>
  ''' 将对象序列化成Json结构
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Overridable Function ToJSONString() As String Implements IResponseMessage.ToJSONString
    Dim lStrRtn As String = String.Empty
    If IsNothing(Me) Then Return "null"
    lStrRtn = JsonConvert.SerializeObject(Me)
    '解决Json.Net最新版本使用了特殊的Datetime格式: \/Date(Ticks+/-Timezone)\/
    '转换为Json能够识别的 new Date(Ticks)格式
    Return Text.RegularExpressions.Regex.Replace(Text.RegularExpressions.Regex.Replace(lStrRtn, "\""\\\/Date\(", "new Date("), "[\+|\-]{1}[\d]{4}\)\\\/\""", ")")
  End Function

  ''' <summary>
  ''' json中对象引用去除对象名的双引号
  ''' </summary>
  ''' <param name="aStrValue"></param>
  ''' <param name="aStrProperties"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Shared Function ReplaceObjectReference(ByVal aStrValue As String, ByVal aStrProperties As String) As String
    Dim lStrRtn As String = aStrValue
    Dim lArrProperty() As String = aStrProperties.Split("|")
    For Each lStrProperty As String In lArrProperty
      If Regex.IsMatch(lStrRtn, "\,\""" & lStrProperty & "\""\:\""null\""") Then lStrRtn = Regex.Replace(lStrRtn, "\,\""" & lStrProperty & "\""\:\""null\""", String.Empty)
      lStrRtn = Regex.Replace(lStrRtn, "\""" & lStrProperty & "\""\:\""[\w\.]*\""", Regex.Match(lStrRtn, "\""" & lStrProperty & "\""\:\""[\w\.]*\""").Value.ToString.Replace("""", String.Empty))
    Next
    Return lStrRtn
  End Function

  ''' <summary>
  ''' 为消息翻译成使用的语言
  ''' </summary>
  ''' <param name="aStrItemSrno"></param>
  ''' <param name="aIntLangIndc"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Shared Function ToLangDesc(ByVal aStrItemSrno As String, ByVal aIntLangIndc As Integer) As String
    Dim lArrItemSrno As String() = aStrItemSrno.Split("|")
    Dim lStrRtn As String = String.Empty

    For Each lStrItemSrno As String In lArrItemSrno
      If IsNumeric(lStrItemSrno) Then
        If IsNothing(clsSharedMemory.mDtLanguageDictionary) OrElse clsSharedMemory.mDtLanguageDictionary.Rows.Count = 0 Then

          Dim lObjTblLanguageDictionary As New TableClass.clsTB_LANG_DICTIONARY
          Dim lObjDataReader As SQLiteDataReader = Nothing

          With lObjTblLanguageDictionary
            .mPrpLD_ITEM_SRNO = CLng(lStrItemSrno)
            .mPrpLD_ITEM_LANG = aIntLangIndc
            .mPrRetrieveData(lObjDataReader, TableClass.clsTB_LANG_DICTIONARY.enmQueryIndicator.SELECT_SRNO_LANG)


            If lObjDataReader IsNot Nothing Then
              While .mFnRetrieveNextRecord(lObjDataReader, TableClass.clsTB_LANG_DICTIONARY.enmQueryIndicator.SELECT_SRNO_LANG)
                lStrRtn = lStrRtn & lObjDataReader.Item("LD_DESC").ToString
              End While
            End If
          End With

        Else

          Dim lObjRows() As DataRow = clsSharedMemory.mDtLanguageDictionary.Select("LD_ITEM_SRNO = '" & lStrItemSrno & "' And LD_ITEM_LANG = " & aIntLangIndc)

          For Each lObjRow As DataRow In lObjRows
            lStrRtn = lStrRtn & lObjRow.Item("LD_DESC").ToString
          Next

        End If
      End If
    Next

    Return lStrRtn
  End Function

End Class
