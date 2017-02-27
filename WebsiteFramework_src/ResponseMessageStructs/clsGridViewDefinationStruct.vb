
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-03                                          *'
'*   Synopsis     : GridView Defination 数据结构体                      *'
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

Public Class clsGridViewDefinationStruct
  Inherits clsBaseResponseMessage

#Region "枚举"
  ''' <summary>
  ''' GridVie Column Category
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmColumnCategory
    SYSTEM = 1
    CUSTOM = 2
  End Enum
#End Region

  Private mLngGridViewColumnSrno As Long
  Private mLngGridViewSrno As Long
  Private mStrColumnName As String
  Private mLngColumnLangSrno As Long
  Private mEnmColumnCategory As EnmColumnCategory
  Private mStrColumnField As String
  Private mIntColumnIndex As Integer
  Private mStrColumnWidth As String
  Private mBlnColumnHidden As Boolean
  Private mStrColumnStyle As String
  Private mStrColumnCellType As String
  Private mStrColumnOptions As String
  Private mBlnColumnEditable As Boolean
  Private mStrColumnFormatter As String
  Private mStrColumnGet As String
  Private mLngCreateUserSrno As Long
  Private mObjCreateDateTime As Date
  Private mLngUpdateUserSrno As Long
  Private mObjUpdateDateTime As Date

  Sub New()
    mLngGridViewColumnSrno = 0
    mLngGridViewSrno = 0
    mStrColumnName = String.Empty
    mLngColumnLangSrno = 0
    mEnmColumnCategory = EnmColumnCategory.SYSTEM
    mStrColumnField = 0
    mIntColumnIndex = 0
    mStrColumnWidth = String.Empty
    mBlnColumnHidden = False
    mStrColumnStyle = String.Empty
    mStrColumnCellType = String.Empty
    mStrColumnOptions = String.Empty
    mBlnColumnEditable = False
    mStrColumnFormatter = String.Empty
    mStrColumnGet = String.Empty
    mLngCreateUserSrno = 0
    mObjCreateDateTime = New Date
    mLngUpdateUserSrno = 0
    mObjUpdateDateTime = New Date
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsGridViewColumnSrno")> _
  Public Property mPrpGridViewColumnSrno() As Long
    Get
      Return mLngGridViewColumnSrno
    End Get
    Set(ByVal value As Long)
      mLngGridViewColumnSrno = value
    End Set
  End Property

  <JsonProperty("jsGridViewSrno")> _
  Public Property mPrpGridViewSrno() As Long
    Get
      Return mLngGridViewSrno
    End Get
    Set(ByVal value As Long)
      mLngGridViewSrno = value
    End Set
  End Property

  <JsonProperty("jsColumnName")> _
  Public Property mPrpColumnName() As String
    Get
      Return mStrColumnName
    End Get
    Set(ByVal value As String)
      mStrColumnName = value
    End Set
  End Property

  <JsonProperty("jsColumnLangSrno")> _
  Public Property mPrpColumnLangSrno() As Long
    Get
      Return mLngColumnLangSrno
    End Get
    Set(ByVal value As Long)
      mLngColumnLangSrno = value
    End Set
  End Property

  <JsonProperty("jsColumnLangDesc")> _
  Public ReadOnly Property mPrpColumnLangDesc() As String
    Get
      Return ToLangDesc(mLngColumnLangSrno, mIntGlobal_Language_Indc)
    End Get
  End Property

  <JsonProperty("jsColumnCategory")> _
  Public Property mPrpColumnCategory() As EnmColumnCategory
    Get
      Return mEnmColumnCategory
    End Get
    Set(ByVal value As EnmColumnCategory)
      mEnmColumnCategory = value
    End Set
  End Property

  <JsonProperty("jsColumnCategoryDesc")> _
  Public ReadOnly Property mPrpColumnCategoryDesc() As String
    Get
      Return mFnGetColumnCategoryDesc(mEnmColumnCategory)
    End Get
  End Property

  <JsonProperty("jsColumnField")> _
  Public Property mPrpColumnField() As String
    Get
      Return mStrColumnField
    End Get
    Set(ByVal value As String)
      mStrColumnField = value
    End Set
  End Property

  <JsonProperty("jsColumnIndex")> _
  Public Property mPrpColumnIndex() As Integer
    Get
      Return mIntColumnIndex
    End Get
    Set(ByVal value As Integer)
      mIntColumnIndex = value
    End Set
  End Property

  <JsonProperty("jsColumnWidth")> _
  Public Property mPrpColumnWidth() As String
    Get
      Return mStrColumnWidth
    End Get
    Set(ByVal value As String)
      mStrColumnWidth = value
    End Set
  End Property

  <JsonProperty("jsColumnHidden")> _
  Public Property mPrpColumnHidden() As Boolean
    Get
      Return mBlnColumnHidden
    End Get
    Set(ByVal value As Boolean)
      mBlnColumnHidden = value
    End Set
  End Property

  <JsonProperty("jsColumnStyle")> _
  Public Property mPrpColumnStyle() As String
    Get
      Return mStrColumnStyle
    End Get
    Set(ByVal value As String)
      mStrColumnStyle = value
    End Set
  End Property

  <JsonProperty("jsColumnCellType")> _
  Public Property mPrpColumnCellType() As String
    Get
      Return mStrColumnCellType
    End Get
    Set(ByVal value As String)
      mStrColumnCellType = value
    End Set
  End Property

  <JsonProperty("jsColumnOptions")> _
  Public Property mPrpColumnOptions() As String
    Get
      Return mStrColumnOptions
    End Get
    Set(ByVal value As String)
      mStrColumnOptions = value
    End Set
  End Property

  <JsonProperty("jsColumnEditable")> _
  Public Property mPrpColumnEditable() As Boolean
    Get
      Return mBlnColumnEditable
    End Get
    Set(ByVal value As Boolean)
      mBlnColumnEditable = value
    End Set
  End Property

  <JsonProperty("jsColumnFormatter")> _
  Public Property mPrpColumnFormatter() As String
    Get
      Return mStrColumnFormatter
    End Get
    Set(ByVal value As String)
      If value = String.Empty Then
        mStrColumnFormatter = "null"
      Else
        mStrColumnFormatter = value
      End If
    End Set
  End Property

  <JsonProperty("jsColumnGet")> _
  Public Property mPrpColumnGet() As String
    Get
      Return mStrColumnGet
    End Get
    Set(ByVal value As String)
      If value = String.Empty Then
        mStrColumnGet = "null"
      Else
        mStrColumnGet = value
      End If
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
  ''' 将列类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmColumnCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function mFnGetColumnCategoryDesc(ByVal aEnmColumnCategory As EnmColumnCategory) As String
    Select Case aEnmColumnCategory
      Case EnmColumnCategory.CUSTOM
        Return ToLangDesc(1042, mIntGlobal_Language_Indc)
      Case EnmColumnCategory.SYSTEM
        Return ToLangDesc(1041, mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

End Class

Public Class clsGridViewJsonStruct
  Inherits clsBaseResponseMessage

  Private mObjGridViewDefination As clsGridViewDefinationStruct

  Sub New()
    mObjGridViewDefination = New clsGridViewDefinationStruct
  End Sub

#Region "CLASS PROPERTIES"

  <JsonIgnore()> _
  Public Property mPrpGridViewDefination() As clsGridViewDefinationStruct
    Get
      Return mObjGridViewDefination
    End Get
    Set(ByVal value As clsGridViewDefinationStruct)
      mObjGridViewDefination = value
    End Set
  End Property

  <JsonProperty("field")> _
  Public ReadOnly Property mPrpField() As String
    Get
      Return mObjGridViewDefination.mPrpColumnField
    End Get
  End Property

  <JsonProperty("name")> _
  Public ReadOnly Property mPrpName() As String
    Get
      If IsNumeric(mObjGridViewDefination.mPrpColumnLangSrno) AndAlso mObjGridViewDefination.mPrpColumnLangDesc <> String.Empty Then
        Return mObjGridViewDefination.mPrpColumnLangDesc
      Else
        Return mObjGridViewDefination.mPrpColumnName
      End If
    End Get
  End Property

  <JsonProperty("width")> _
  Public ReadOnly Property mPrpWidth() As String
    Get
      Return mObjGridViewDefination.mPrpColumnWidth
    End Get
  End Property

  <JsonProperty("style")> _
  Public ReadOnly Property mPrpStyle() As String
    Get
      Return mObjGridViewDefination.mPrpColumnStyle
    End Get
  End Property

  <JsonProperty("formatter")> _
  Public ReadOnly Property mPrpFormatter() As String
    Get
      Return mObjGridViewDefination.mPrpColumnFormatter
    End Get
  End Property

  <JsonProperty("get")> _
  Public ReadOnly Property mPrpGet() As String
    Get
      Return mObjGridViewDefination.mPrpColumnGet
    End Get
  End Property

  <JsonProperty("hidden")> _
  Public ReadOnly Property mPrpHidden() As Boolean
    Get
      Return mObjGridViewDefination.mPrpColumnHidden
    End Get
  End Property

  <JsonProperty("celltype")> _
  Public ReadOnly Property mPrpCellType() As String
    Get
      Return mObjGridViewDefination.mPrpColumnCellType
    End Get
  End Property

  <JsonProperty("editable")> _
  Public ReadOnly Property mPrpEditable() As Boolean
    Get
      Return mObjGridViewDefination.mPrpColumnEditable
    End Get
  End Property

  <JsonProperty("options")> _
  Public ReadOnly Property mPrpOptions() As String
    Get
      Return mObjGridViewDefination.mPrpColumnOptions
    End Get
  End Property

#End Region

  ''' <summary>
  ''' 静态方法,将数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsGridViewJsonStruct)) As String
    Dim lStrRtn As String = String.Empty
    If aArrObject.Count = 0 Then Return "{cells:null}"
    lStrRtn = "{cells:["
    For Each lObjGridViewJson As clsGridViewJsonStruct In aArrObject
      lStrRtn = lStrRtn & lObjGridViewJson.ToJSONString & ","
      '对于函数的应用 需要去除引号
      lStrRtn = Regex.Replace(lStrRtn, "\""formatter\""\:\""\w*\""", Regex.Match(lStrRtn, "\""formatter\""\:\""\w*\""").Value.ToString.Replace("""", String.Empty))
      lStrRtn = Regex.Replace(lStrRtn, "\""get\""\:\""\w*\""", Regex.Match(lStrRtn, "\""get\""\:\""\w*\""").Value.ToString.Replace("""", String.Empty))
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]}"
    Return lStrRtn
  End Function

End Class
