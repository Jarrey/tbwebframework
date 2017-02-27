
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-16                                          *'
'*   Synopsis     : Column Filter 数据结构体                            *'
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

Imports Newtonsoft.Json
Imports System.Text.RegularExpressions
Imports Utils
Imports DataAccess

Public Class clsColumnFilterStruct
  Inherits clsBaseResponseMessage

  Private mLngFilterSrno As Long
  Private mLngViewSrno As Long
  Private mLngColumnIndex As Long
  Private mStrFilterType As String
  Private mStrFilterDataIndex As String
  Private mBlnFilterDisabled As Boolean
  Private mStrFilterCodeDesc As String
  Private mStrFilterCodeQuery As String
  Private mLngCreateUserSrno As Long
  Private mObjCreateDateTime As Date
  Private mLngUpdateUserSrno As Long
  Private mObjUpdateDateTime As Date

  Sub New()
    mLngFilterSrno = 0
    mLngViewSrno = 0
    mLngColumnIndex = 0
    mStrFilterType = String.Empty
    mStrFilterDataIndex = String.Empty
    mBlnFilterDisabled = False
    mStrFilterCodeDesc = String.Empty
    mStrFilterCodeQuery = String.Empty
    mLngCreateUserSrno = 0
    mObjCreateDateTime = New Date
    mLngUpdateUserSrno = 0
    mObjUpdateDateTime = New Date
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsFilterSrno")> _
  Public Property mPrpFilterSrno() As Long
    Get
      Return mLngFilterSrno
    End Get
    Set(ByVal value As Long)
      mLngFilterSrno = value
    End Set
  End Property

  <JsonProperty("jsViewSrno")> _
  Public Property mPrpViewSrno() As Long
    Get
      Return mLngViewSrno
    End Get
    Set(ByVal value As Long)
      mLngViewSrno = value
    End Set
  End Property

  <JsonProperty("jsColumnIndex")> _
  Public Property mPrpColumnIndex() As Long
    Get
      Return mLngColumnIndex
    End Get
    Set(ByVal value As Long)
      mLngColumnIndex = value
    End Set
  End Property

  <JsonProperty("jsFilterType")> _
  Public Property mPrpFilterType() As String
    Get
      Return mStrFilterType
    End Get
    Set(ByVal value As String)
      mStrFilterType = value
    End Set
  End Property

  <JsonProperty("jsFilterDataIndex")> _
  Public Property mPrpFilterDataIndex() As String
    Get
      Return mStrFilterDataIndex
    End Get
    Set(ByVal value As String)
      mStrFilterDataIndex = value
    End Set
  End Property

  <JsonProperty("jsFilterDisabled")> _
  Public Property mPrpFilterDisabled() As Boolean
    Get
      Return mBlnFilterDisabled
    End Get
    Set(ByVal value As Boolean)
      mBlnFilterDisabled = value
    End Set
  End Property

  <JsonProperty("jsFilterCodeDesc")> _
  Public Property mPrpFilterCodeDesc() As String
    Get
      Return mStrFilterCodeDesc
    End Get
    Set(ByVal value As String)
      mStrFilterCodeDesc = value
    End Set
  End Property

  <JsonProperty("jsFilterCodeQuery")> _
  Public Property mPrpFilterCodeQuery() As String
    Get
      Return mStrFilterCodeQuery
    End Get
    Set(ByVal value As String)
      mStrFilterCodeQuery = value
    End Set
  End Property

  <JsonProperty("jsCreateUserSrno")> _
  Public Property mPrpCreateUserSrno() As Long
    Get
      Return mLngCreateUserSrno
    End Get
    Set(ByVal value As Long)
      mLngCreateUserSrno = value
    End Set
  End Property

  <JsonProperty("jsCreateDateTime")> _
  Public Property mPrpCreateDateTime() As Date
    Get
      Return mObjCreateDateTime
    End Get
    Set(ByVal value As Date)
      mObjCreateDateTime = value
    End Set
  End Property

  <JsonProperty("jsUpdateUserSrno")> _
  Public Property mPrpUpdateUserSrno() As Long
    Get
      Return mLngUpdateUserSrno
    End Get
    Set(ByVal value As Long)
      mLngUpdateUserSrno = value
    End Set
  End Property

  <JsonProperty("jsUpdateDateTime")> _
  Public Property mPrpUpdateDateTime() As Date
    Get
      Return mObjUpdateDateTime
    End Get
    Set(ByVal value As Date)
      mObjUpdateDateTime = value
    End Set
  End Property

#End Region

End Class

Public Class clsColumnFilterJsonStruct
  Inherits clsBaseResponseMessage

  Private mObjColumnFilter As clsColumnFilterStruct

  Sub New()
    mObjColumnFilter = New clsColumnFilterStruct
  End Sub

#Region "CLASS PROPERTIES"

  <JsonIgnore()> _
  Public Property mPrpColumnFilter() As clsColumnFilterStruct
    Get
      Return mObjColumnFilter
    End Get
    Set(ByVal value As clsColumnFilterStruct)
      mObjColumnFilter = value
    End Set
  End Property

  <JsonProperty("type")> _
  Public ReadOnly Property mPrpType() As String
    Get
      Return mObjColumnFilter.mPrpFilterType
    End Get
  End Property

  <JsonProperty("dataIndex")> _
  Public ReadOnly Property mPrpDataIndex() As String
    Get
      Return mObjColumnFilter.mPrpFilterDataIndex
    End Get
  End Property

  <JsonProperty("disabled")> _
  Public ReadOnly Property mPrpDisabled() As Boolean
    Get
      Return mObjColumnFilter.mPrpFilterDisabled
    End Get
  End Property

  <JsonProperty("options")> _
  Public ReadOnly Property mPrpOptions() As String()
    Get
      If mObjColumnFilter.mPrpFilterType = "list" Then
        Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
        Dim lObjTblCodeMaster As New TableClass.clsTB_CODE_MASTER
        Dim lObjCodeMaster As clsCodeMasterStruct = Nothing
        Dim lArrCodeDesces As New ArrayList
        Dim lArrRtn As String() = Nothing

        lObjTblCodeMaster.mPrpCMS_CODE_DESC = mObjColumnFilter.mPrpFilterCodeDesc
        lObjTblCodeMaster.mPrpCMS_CUSTOM_QUERY = mObjColumnFilter.mPrpFilterCodeQuery
        lObjTblCodeMaster.mPrRetrieveData(lDtDataReader, TableClass.clsTB_CODE_MASTER.enmQueryIndicator.SELECT_DESC_CUSTOM_QUERY)
        If IsNothing(lDtDataReader) = False Then
          While lObjTblCodeMaster.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_CODE_MASTER.enmQueryIndicator.SELECT_DESC_CUSTOM_QUERY)
            Dim lStrCodeDesc As String = ToLangDesc(IIf(IsDBNull(lDtDataReader.Item("CMS_CODE_LABEL_LANG_SRNO")), "0", lDtDataReader.Item("CMS_CODE_LABEL_LANG_SRNO")), mIntGlobal_Language_Indc)
            If lStrCodeDesc.Trim = String.Empty Then lStrCodeDesc = lDtDataReader.Item("CMS_CODE_LABEL")
            lArrCodeDesces.Add(lStrCodeDesc)
          End While
          ReDim lArrRtn(lArrCodeDesces.Count - 1)
          lArrCodeDesces.CopyTo(lArrRtn)
        End If
        Return lArrRtn
      Else
        Return Nothing
      End If
    End Get
  End Property
#End Region

  ''' <summary>
  ''' 静态方法,将数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsColumnFilterJsonStruct)) As String
    Dim lStrRtn As String = String.Empty
    If aArrObject.Count = 0 Then Return "null"
    lStrRtn = "["
    For Each lObjColumnFilterJson As clsColumnFilterJsonStruct In aArrObject
      lStrRtn = lStrRtn & lObjColumnFilterJson.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]"
    Return lStrRtn
  End Function

End Class