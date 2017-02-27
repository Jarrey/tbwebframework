
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-11-30                                          *'
'*   Synopsis     : 参数数据结构体                                      *'
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

Public Class clsParametersMessageStruct
  Inherits clsBaseResponseMessage

#Region "枚举"

  ''' <summary>
  ''' 参数类型
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmParameterCategory
    SYSTEM = 1
    CUSTOM = 2
  End Enum

  ''' <summary>
  ''' 参数值类型
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmParameterValueType
    NUMERIC = 1
    TEXT = 2
    LINK = 3
    IMAGE = 4
    OPTIONS = 5
    BOOL = 6
  End Enum

#End Region

  Private mLngParameterSrno As Long
  Private mStrParameterDesc As String
  Private mStrParameterName As String
  Private mStrParameterNameLangSrno As String
  Private mLngParameterCategory As Long
  Private mLngParameterValueSrno As Long
  Private mLngValueType As Long
  Private mStrValue As String
  Private mStrValueLangSrno As String
  Private mStrValueOptions As String

  Sub New()
    mLngParameterSrno = 0
    mStrParameterDesc = String.Empty
    mStrParameterName = String.Empty
    mStrParameterNameLangSrno = "0"
    mLngParameterCategory = 0
    mLngParameterValueSrno = 0
    mLngValueType = 0
    mStrValue = String.Empty
    mStrValueLangSrno = "0"
    mStrValueOptions = String.Empty
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsParameterSrno")> _
  Public Property mPrpParameterSrno() As Long
    Get
      Return mLngParameterSrno
    End Get
    Set(ByVal value As Long)
      mLngParameterSrno = value
    End Set
  End Property

  <JsonProperty("jsParameterDesc")> _
  Public Property mPrpParameterDesc() As String
    Get
      Return mStrParameterDesc
    End Get
    Set(ByVal value As String)
      mStrParameterDesc = value
    End Set
  End Property

  <JsonProperty("ParameterName")> _
  Public Property mPrpParameterName() As String
    Get
      Return mStrParameterName
    End Get
    Set(ByVal value As String)
      mStrParameterName = value
    End Set
  End Property

  <JsonProperty("jsParameterNameLangSrno")> _
  Public Property mPrpParameterNameLangSrno() As String
    Get
      Return mStrParameterNameLangSrno
    End Get
    Set(ByVal value As String)
      mStrParameterNameLangSrno = value
    End Set
  End Property

  <JsonProperty("jsParameterNameLangDesc")> _
  Public ReadOnly Property mPrpParameterNameLangDesc() As String
    Get
      If mStrParameterNameLangSrno.Trim <> 0 Then
        Return ToLangDesc(mStrParameterNameLangSrno, mIntGlobal_Language_Indc)
      Else
        Return mStrParameterName
      End If
    End Get
  End Property

  <JsonProperty("jsParameterCategory")> _
  Public Property mPrpParameterCategory() As Long
    Get
      Return mLngParameterCategory
    End Get
    Set(ByVal value As Long)
      mLngParameterCategory = value
    End Set
  End Property

  <JsonProperty("jsParameterCategoryDesc")> _
  Public ReadOnly Property mPrpParameterCategoryDesc() As String
    Get
      Return mFnGetCategoryDesc(mLngParameterCategory)
    End Get
  End Property

  <JsonProperty("jsParameterValueSrno")> _
  Public Property mPrpParameterValueSrno() As Long
    Get
      Return mLngParameterValueSrno
    End Get
    Set(ByVal value As Long)
      mLngParameterValueSrno = value
    End Set
  End Property

  <JsonProperty("jsValueLangSrno")> _
  Public Property mPrpValueLangSrno() As String
    Get
      Return mStrValueLangSrno
    End Get
    Set(ByVal value As String)
      mStrValueLangSrno = value
    End Set
  End Property

  <JsonProperty("jsValueLangDesc")> _
  Public ReadOnly Property mPrpValueLangDesc() As String
    Get
      Return ToLangDesc(mStrValueLangSrno, mIntGlobal_Language_Indc)
    End Get
  End Property

  <JsonProperty("jsValueType")> _
  Public Property mPrpValueType() As Long
    Get
      Return mLngValueType
    End Get
    Set(ByVal value As Long)
      mLngValueType = value
    End Set
  End Property

  <JsonProperty("jsValueTypeDesc")> _
  Public ReadOnly Property mPrpValueTypeDesc() As String
    Get
      Return mFnGetValueTypeDesc(mLngValueType)
    End Get
  End Property

  <JsonProperty("jsValue")> _
  Public Property mPrpValue() As String
    Get
      Return mStrValue
    End Get
    Set(ByVal value As String)
      mStrValue = value
    End Set
  End Property

  <JsonProperty("jsValueOptions")> _
  Public Property mPrpValueOptions() As String
    Get
      Return mStrValueOptions
    End Get
    Set(ByVal value As String)
      mStrValueOptions = value
    End Set
  End Property

#End Region

  ''' <summary>
  ''' 将参数类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aLngParameterCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetCategoryDesc(ByVal aLngParameterCategory As EnmParameterCategory) As String
    Select Case aLngParameterCategory
      Case EnmParameterCategory.CUSTOM
        Return ToLangDesc("1042", mIntGlobal_Language_Indc)
      Case EnmParameterCategory.SYSTEM
        Return ToLangDesc("1041", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

  ''' <summary>
  ''' 将参数值类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aLngParameterValueType"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetValueTypeDesc(ByVal aLngParameterValueType As EnmParameterValueType) As String
    Select Case aLngParameterValueType
      Case EnmParameterValueType.IMAGE
        Return ToLangDesc("1043", mIntGlobal_Language_Indc)
      Case EnmParameterValueType.LINK
        Return ToLangDesc("1045", mIntGlobal_Language_Indc)
      Case EnmParameterValueType.NUMERIC
        Return ToLangDesc("1044", mIntGlobal_Language_Indc)
      Case EnmParameterValueType.TEXT
        Return ToLangDesc("1046", mIntGlobal_Language_Indc)
      Case EnmParameterValueType.BOOL
        Return ToLangDesc("1070", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

End Class
