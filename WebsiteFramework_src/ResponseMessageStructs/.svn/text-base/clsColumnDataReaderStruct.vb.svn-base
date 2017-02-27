
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-16                                          *'
'*   Synopsis     : Column Data Reader 数据结构体                       *'
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

Public Class clsColumnDataReaderStruct
  Inherits clsBaseResponseMessage

  Private mLngColumnSrno As Long
  Private mLngViewSrno As Long
  Private mStrDataIndexName As String
  Private mStrMapping As String
  Private mLngCreateUserSrno As Long
  Private mObjCreateDateTime As Date
  Private mLngUpdateUserSrno As Long
  Private mObjUpdateDateTime As Date

  Sub New()
    mLngColumnSrno = 0
    mLngViewSrno = 0
    mStrDataIndexName = String.Empty
    mStrMapping = String.Empty
    mLngCreateUserSrno = 0
    mObjCreateDateTime = New Date
    mLngUpdateUserSrno = 0
    mObjUpdateDateTime = New Date
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsColumnSrno")> _
  Public Property mPrpColumnSrno() As Long
    Get
      Return mLngColumnSrno
    End Get
    Set(ByVal value As Long)
      mLngColumnSrno = value
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

  <JsonProperty("jsDataIndexName")> _
  Public Property mPrpDataIndexName() As String
    Get
      Return mStrDataIndexName
    End Get
    Set(ByVal value As String)
      mStrDataIndexName = value
    End Set
  End Property

  <JsonProperty("jsMapping")> _
  Public Property mPrpMapping() As String
    Get
      Return mStrMapping
    End Get
    Set(ByVal value As String)
      mStrMapping = value
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

Public Class clsColumnDataReaderJsonStruct
  Inherits clsBaseResponseMessage

  Private mObjColumnDataReader As clsColumnDataReaderStruct

  Sub New()
    mObjColumnDataReader = New clsColumnDataReaderStruct
  End Sub

#Region "CLASS PROPERTIES"

  <JsonIgnore()> _
  Public Property mPrpColumnDataReader() As clsColumnDataReaderStruct
    Get
      Return mObjColumnDataReader
    End Get
    Set(ByVal value As clsColumnDataReaderStruct)
      mObjColumnDataReader = value
    End Set
  End Property

  <JsonProperty("name")> _
  Public ReadOnly Property mPrpName() As String
    Get
      Return mObjColumnDataReader.mPrpDataIndexName
    End Get
  End Property

  <JsonProperty("mapping")> _
  Public ReadOnly Property mPrpMapping() As String
    Get
      Return mObjColumnDataReader.mPrpMapping
    End Get
  End Property

#End Region

  ''' <summary>
  ''' 静态方法,将数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsColumnDataReaderJsonStruct)) As String
    Dim lStrRtn As String = String.Empty
    If aArrObject.Count = 0 Then Return "null"
    lStrRtn = "["
    For Each lObjColumnDataReaderJson As clsColumnDataReaderJsonStruct In aArrObject
      lStrRtn = lStrRtn & lObjColumnDataReaderJson.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]"
    Return lStrRtn
  End Function

End Class