
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-03                                          *'
'*   Synopsis     : Code Master 数据结构体                              *'
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
Imports Utils

Public Class clsCodeMasterStruct
  Inherits clsBaseResponseMessage

#Region "枚举"
  ''' <summary>
  ''' 类型
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmCodeMasterCategory
    SYSTEM = 1
    CUSTOM = 2
  End Enum

#End Region

  Private mLngCodeSrno As Long
  Private mStrCodeDesc As String
  Private mStrCodeName As String
  Private mStrCodeLabel As String
  Private mStrCodeLabelLangSrno As String
  Private mEnmCodeCategory As EnmCodeMasterCategory
  Private mStrCodeValue As String
  Private mStrCodeValueLangSrno As String
  Private mStrCustomQuery As String
  Private mLngCreateUserSrno As Long
  Private mObjCreateDateTime As Date
  Private mLngUpdateUserSrno As Long
  Private mObjUpdateDateTime As Date

  Sub New()
    mLngCodeSrno = 0
    mStrCodeDesc = String.Empty
    mStrCodeName = String.Empty
    mStrCodeLabel = String.Empty
    mStrCodeLabelLangSrno = "0"
    mEnmCodeCategory = EnmCodeMasterCategory.SYSTEM
    mStrCodeValue = String.Empty
    mStrCodeValueLangSrno = "0"
    mStrCustomQuery = String.Empty
    mLngCreateUserSrno = 0
    mObjCreateDateTime = New Date
    mLngUpdateUserSrno = 0
    mObjUpdateDateTime = New Date
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsCodeSrno")> _
  Public Property mPrpCodeSrno() As Long
    Get
      Return mLngCodeSrno
    End Get
    Set(ByVal value As Long)
      mLngCodeSrno = value
    End Set
  End Property

  <JsonProperty("jsCodeDesc")> _
  Public Property mPrpCodeDesc() As String
    Get
      Return mStrCodeDesc
    End Get
    Set(ByVal value As String)
      mStrCodeDesc = value
    End Set
  End Property

  <JsonProperty("jsCodeName")> _
  Public Property mPrpCodeName() As String
    Get
      Return mStrCodeName
    End Get
    Set(ByVal value As String)
      mStrCodeName = value
    End Set
  End Property

  <JsonProperty("jsCodeLabel")> _
  Public Property mPrpCodeLabel() As String
    Get
      Return mStrCodeLabel
    End Get
    Set(ByVal value As String)
      mStrCodeLabel = value
    End Set
  End Property

  <JsonProperty("jsCodeLabelLangSrno")> _
  Public Property mPrpCodeLabelLangSrno() As String
    Get
      Return mStrCodeLabelLangSrno
    End Get
    Set(ByVal value As String)
      mStrCodeLabelLangSrno = value
    End Set
  End Property

  <JsonProperty("jsCodeLabelLangDesc")> _
  Public ReadOnly Property mPrpCodeLabelLangDesc() As String
    Get
      If mStrCodeLabelLangSrno.Trim <> "0" Then
        Return ToLangDesc(mStrCodeLabelLangSrno, mIntGlobal_Language_Indc)
      Else
        Return mStrCodeLabel
      End If
    End Get
  End Property

  <JsonProperty("jsCodeCategory")> _
  Public Property mPrpCodeCategory() As EnmCodeMasterCategory
    Get
      Return mEnmCodeCategory
    End Get
    Set(ByVal value As EnmCodeMasterCategory)
      mEnmCodeCategory = value
    End Set
  End Property

  <JsonProperty("jsCodeCategoryDesc")> _
  Public ReadOnly Property mPrpCodeCategoryDesc() As String
    Get
      Return mFnGetCategoryDesc(mEnmCodeCategory)
    End Get
  End Property

  <JsonProperty("jsCodeValue")> _
  Public Property mPrpCodeValue() As String
    Get
      Return mStrCodeValue
    End Get
    Set(ByVal value As String)
      mStrCodeValue = value
    End Set
  End Property

  <JsonProperty("jsCodeValueLangSrno")> _
  Public Property mPrpCodeValueLangSrno() As String
    Get
      Return mStrCodeValueLangSrno
    End Get
    Set(ByVal value As String)
      mStrCodeValueLangSrno = value
    End Set
  End Property

  <JsonProperty("jsCodeValueLangDesc")> _
  Public ReadOnly Property mPrpCodeValueLangDesc() As String
    Get
      If mStrCodeValueLangSrno.Trim <> "0" Then
        Return ToLangDesc(mStrCodeValueLangSrno, mIntGlobal_Language_Indc)
      Else
        Return mStrCodeValue
      End If
    End Get
  End Property

  <JsonProperty("jsCustomQuery")> _
  Public Property mPrpCustomQuery() As String
    Get
      Return mStrCustomQuery
    End Get
    Set(ByVal value As String)
      mStrCustomQuery = value
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

  ''' <summary>
  ''' 静态方法,将数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsCodeMasterStruct)) As String
    Dim lStrRtn As String = String.Empty
    lStrRtn = "{identifier:""jsCodeValue"","
    lStrRtn = lStrRtn & "label:""jsCodeLabelLangDesc"","
    If aArrObject.Count = 0 Then Return lStrRtn & "items:null}"
    lStrRtn = lStrRtn & "items:["
    For Each lObjCodeMaster As clsCodeMasterStruct In aArrObject
      lStrRtn = lStrRtn & lObjCodeMaster.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]}"
    Return lStrRtn
  End Function

  ''' <summary>
  ''' 将类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmCodeCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetCategoryDesc(ByVal aEnmCodeCategory As EnmCodeMasterCategory) As String
    Select Case aEnmCodeCategory
      Case EnmCodeMasterCategory.CUSTOM
        Return ToLangDesc("1042", mIntGlobal_Language_Indc)
      Case EnmCodeMasterCategory.SYSTEM
        Return ToLangDesc("1041", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

End Class
