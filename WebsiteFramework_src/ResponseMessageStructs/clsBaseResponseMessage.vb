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
  ''' ���������л���Json�ṹ
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Overridable Function ToJSONString() As String Implements IResponseMessage.ToJSONString
    Dim lStrRtn As String = String.Empty
    If IsNothing(Me) Then Return "null"
    lStrRtn = JsonConvert.SerializeObject(Me)
    '���Json.Net���°汾ʹ���������Datetime��ʽ: \/Date(Ticks+/-Timezone)\/
    'ת��ΪJson�ܹ�ʶ��� new Date(Ticks)��ʽ
    Return Text.RegularExpressions.Regex.Replace(Text.RegularExpressions.Regex.Replace(lStrRtn, "\""\\\/Date\(", "new Date("), "[\+|\-]{1}[\d]{4}\)\\\/\""", ")")
  End Function

  ''' <summary>
  ''' json�ж�������ȥ����������˫����
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
  ''' Ϊ��Ϣ�����ʹ�õ�����
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
