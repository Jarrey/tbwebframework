
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-16                                          *'
'*   Synopsis     : Column Model 数据结构体                             *'
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

Public Class clsColumnModelStruct
  Inherits clsBaseResponseMessage

#Region "枚举"
  ''' <summary>
  ''' GridView Column Category
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmColumnCategory
    SYSTEM = 1
    CUSTOM = 2
  End Enum

  ''' <summary>
  ''' GridView Column Align
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmColumnAlign
    LEFT = 1
    CENTER = 2
    RIGHT = 3
  End Enum
#End Region

  Private mLngColumnSrno As Long
  Private mLngViewSrno As Long
  Private mStrColumnName As String
  Private mStrColumnLangSrno As String
  Private mIntColumnIndex As Integer
  Private mEnmColumnCategory As EnmColumnCategory
  Private mStrColumnDataIndex As String
  Private mStrColumnType As String
  Private mDblColumnWidth As Double
  Private mEnmColumnAlign As EnmColumnAlign
  Private mStrColumnToolTip As String
  Private mStrColumnCSS As String
  Private mStrColumnTpl As String
  Private mBlnColumnSortable As Boolean
  Private mBlnColumnResizable As Boolean
  Private mBlnColumnEditable As Boolean
  Private mStrColumnEditor As String
  Private mStrRenderer As String
  Private mStrScope As String
  Private mLngCreateUserSrno As Long
  Private mObjCreateDateTime As Date
  Private mLngUpdateUserSrno As Long
  Private mObjUpdateDateTime As Date

  Sub New()
    mLngColumnSrno = 0
    mLngViewSrno = 0
    mStrColumnName = String.Empty
    mStrColumnLangSrno = "0"
    mIntColumnIndex = 0
    mEnmColumnCategory = EnmColumnCategory.SYSTEM
    mStrColumnDataIndex = String.Empty
    mStrColumnType = String.Empty
    mDblColumnWidth = 0
    mEnmColumnAlign = EnmColumnAlign.LEFT
    mStrColumnToolTip = String.Empty
    mStrColumnCSS = String.Empty
    mStrColumnTpl = String.Empty
    mBlnColumnSortable = True
    mBlnColumnResizable = True
    mBlnColumnEditable = False
    mStrColumnEditor = String.Empty
    mStrRenderer = String.Empty
    mStrScope = String.Empty
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
  Public Property mPrpColumnLangSrno() As String
    Get
      Return mStrColumnLangSrno
    End Get
    Set(ByVal value As String)
      mStrColumnLangSrno = value
    End Set
  End Property

  <JsonProperty("jsColumnLangDesc")> _
  Public ReadOnly Property mPrpColumnLangDesc() As String
    Get
      If mStrColumnLangSrno.Trim <> "0" Then
        Return ToLangDesc(mStrColumnLangSrno, mIntGlobal_Language_Indc)
      Else
        Return mStrColumnName
      End If
    End Get
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

  <JsonProperty("jsColumnDataIndex")> _
  Public Property mPrpColumnDataIndex() As String
    Get
      Return mStrColumnDataIndex
    End Get
    Set(ByVal value As String)
      mStrColumnDataIndex = value
    End Set
  End Property

  <JsonProperty("jsColumnType")> _
  Public Property mPrpColumnType() As String
    Get
      Return mStrColumnType
    End Get
    Set(ByVal value As String)
      mStrColumnType = value
    End Set
  End Property

  <JsonProperty("jsColumnWidth")> _
  Public Property mPrpColumnWidth() As Double
    Get
      Return mDblColumnWidth
    End Get
    Set(ByVal value As Double)
      mDblColumnWidth = value
    End Set
  End Property

  <JsonProperty("jsColumnAlign")> _
  Public Property mPrpColumnAlign() As EnmColumnAlign
    Get
      Return mEnmColumnAlign
    End Get
    Set(ByVal value As EnmColumnAlign)
      mEnmColumnAlign = value
    End Set
  End Property

  <JsonProperty("jsColumnAlignDesc")> _
  Public ReadOnly Property mPrpColumnAlignDesc() As String
    Get
      Return mFnGetColumnAlignDesc(mEnmColumnAlign)
    End Get
  End Property

  <JsonProperty("jsColumnToolTip")> _
  Public Property mPrpColumnToolTip() As String
    Get
      Return mStrColumnToolTip
    End Get
    Set(ByVal value As String)
      mStrColumnToolTip = value
    End Set
  End Property

  <JsonProperty("jsColumnCSS")> _
  Public Property mPrpColumnCSS() As String
    Get
      Return mStrColumnCSS
    End Get
    Set(ByVal value As String)
      mStrColumnCSS = value
    End Set
  End Property

  <JsonProperty("jsColumnTpl")> _
  Public Property mPrpColumnTpl() As String
    Get
      Return mStrColumnTpl
    End Get
    Set(ByVal value As String)
      mStrColumnTpl = value
    End Set
  End Property

  <JsonProperty("jsColumnSortable")> _
  Public Property mPrpColumnSortable() As Boolean
    Get
      Return mBlnColumnSortable
    End Get
    Set(ByVal value As Boolean)
      mBlnColumnSortable = value
    End Set
  End Property

  <JsonProperty("jsColumnResizable")> _
  Public Property mPrpColumnResizable() As Boolean
    Get
      Return mBlnColumnResizable
    End Get
    Set(ByVal value As Boolean)
      mBlnColumnResizable = value
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

  <JsonProperty("jsColumnEditor")> _
  Public Property mPrpColumnEditor() As String
    Get
      Return mStrColumnEditor
    End Get
    Set(ByVal value As String)
      mStrColumnEditor = value
    End Set
  End Property

  <JsonProperty("jsRenderer")> _
  Public Property mPrpRenderer() As String
    Get
      If mStrRenderer = String.Empty Then
        Return "null"
      Else
        Return mStrRenderer
      End If
    End Get
    Set(ByVal value As String)
      mStrRenderer = value
    End Set
  End Property

  <JsonProperty("jsScope")> _
  Public Property mPrpScope() As String
    Get
      If mStrScope = String.Empty Then
        Return "null"
      Else
        Return mStrScope
      End If
    End Get
    Set(ByVal value As String)
      mStrScope = value
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
  Public Shared Function mFnGetColumnCategoryDesc(ByVal aEnmColumnCategory As EnmColumnCategory) As String
    Select Case aEnmColumnCategory
      Case EnmColumnCategory.CUSTOM
        Return ToLangDesc("1042", mIntGlobal_Language_Indc)
      Case EnmColumnCategory.SYSTEM
        Return ToLangDesc("1041", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

  ''' <summary>
  ''' 将列对齐方式枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmColumnAlign"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetColumnAlignDesc(ByVal aEnmColumnAlign As EnmColumnAlign) As String
    Select Case aEnmColumnAlign
      Case EnmColumnAlign.LEFT
        Return ToLangDesc("1059", mIntGlobal_Language_Indc)
      Case EnmColumnAlign.CENTER
        Return ToLangDesc("1060", mIntGlobal_Language_Indc)
      Case EnmColumnAlign.RIGHT
        Return ToLangDesc("1061", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

End Class

Public Class clsColumnModelJsonBaseStruct
  Inherits clsBaseResponseMessage

  Protected mObjColumnModel As clsColumnModelStruct

  Sub New()
    mObjColumnModel = New clsColumnModelStruct
  End Sub

  <JsonIgnore()> _
  Public Property mPrpColumnModel() As clsColumnModelStruct
    Get
      Return mObjColumnModel
    End Get
    Set(ByVal value As clsColumnModelStruct)
      mObjColumnModel = value
    End Set
  End Property

End Class

Public Class clsGridColumnModelJsonStruct
  Inherits clsColumnModelJsonBaseStruct

#Region "CLASS PROPERTIES"

  <JsonProperty("id")> _
  Public ReadOnly Property mPrpId() As String
    Get
      Return mObjColumnModel.mPrpColumnDataIndex
    End Get
  End Property

  <JsonProperty("header")> _
  Public ReadOnly Property mPrpHeader() As String
    Get
      Return mObjColumnModel.mPrpColumnLangDesc
    End Get
  End Property

  <JsonProperty("dataIndex")> _
  Public ReadOnly Property mPrpDataIndex() As String
    Get
      Return mObjColumnModel.mPrpColumnDataIndex
    End Get
  End Property

  <JsonProperty("type")> _
  Public ReadOnly Property mPrpType() As String
    Get
      Return mObjColumnModel.mPrpColumnType
    End Get
  End Property

  <JsonProperty("width")> _
  Public ReadOnly Property mPrpWidth() As Double
    Get
      Return mObjColumnModel.mPrpColumnWidth
    End Get
  End Property

  <JsonProperty("align")> _
  Public ReadOnly Property mPrpAlign() As String
    Get
      Select Case mObjColumnModel.mPrpColumnAlign
        Case clsColumnModelStruct.EnmColumnAlign.LEFT
          Return "left"
        Case clsColumnModelStruct.EnmColumnAlign.CENTER
          Return "center"
        Case clsColumnModelStruct.EnmColumnAlign.RIGHT
          Return "right"
        Case Else
          Return "left"
      End Select
    End Get
  End Property

  <JsonProperty("tooltip")> _
  Public ReadOnly Property mPrpToolTip() As String
    Get
      Return mObjColumnModel.mPrpColumnToolTip.Replace("%p", mObjColumnModel.mPrpColumnLangDesc)
    End Get
  End Property

  <JsonProperty("css")> _
  Public ReadOnly Property mPrpCSS() As String
    Get
      Return mObjColumnModel.mPrpColumnCSS
    End Get
  End Property

  <JsonProperty("sortable")> _
  Public ReadOnly Property mPrpSortable() As Boolean
    Get
      Return mObjColumnModel.mPrpColumnSortable
    End Get
  End Property

  <JsonProperty("resizable")> _
  Public ReadOnly Property mPrpResizable() As Boolean
    Get
      Return mObjColumnModel.mPrpColumnResizable
    End Get
  End Property

  <JsonProperty("editable")> _
  Public ReadOnly Property mPrpEditable() As Boolean
    Get
      Return mObjColumnModel.mPrpColumnEditable
    End Get
  End Property

  <JsonProperty("editor")> _
  Public ReadOnly Property mPrpEditor() As String
    Get
      Return mObjColumnModel.mPrpColumnEditor
    End Get
  End Property

  <JsonProperty("renderer")> _
  Public ReadOnly Property mPrpRenderer() As String
    Get
      Return mObjColumnModel.mPrpRenderer
    End Get
  End Property

  <JsonProperty("scope")> _
  Public ReadOnly Property mPrpScope() As String
    Get
      Return mObjColumnModel.mPrpScope
    End Get
  End Property

#End Region

  ''' <summary>
  ''' 静态方法,将数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsGridColumnModelJsonStruct)) As String
    Dim lStrRtn As String = String.Empty
    If aArrObject.Count = 0 Then Return "null"
    lStrRtn = "["
    For Each lObjGridColumnModelJson As clsGridColumnModelJsonStruct In aArrObject
      lStrRtn = lStrRtn & lObjGridColumnModelJson.ToJSONString & ","
      '对于函数的应用 需要去除引号
      lStrRtn = ReplaceObjectReference(lStrRtn, "renderer|scope")
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]"
    Return lStrRtn
  End Function

End Class

Public Class clsListColumnModelJsonStruct
  Inherits clsColumnModelJsonBaseStruct

#Region "CLASS PROPERTIES"

  <JsonProperty("header")> _
  Public ReadOnly Property mPrpHeader() As String
    Get
      Return mObjColumnModel.mPrpColumnLangDesc
    End Get
  End Property

  <JsonProperty("dataIndex")> _
  Public ReadOnly Property mPrpDataIndex() As String
    Get
      Return mObjColumnModel.mPrpColumnDataIndex
    End Get
  End Property

  <JsonProperty("width")> _
  Public ReadOnly Property mPrpWidth() As Double
    Get
      Return mObjColumnModel.mPrpColumnWidth
    End Get
  End Property

  <JsonProperty("align")> _
  Public ReadOnly Property mPrpAlign() As String
    Get
      Select Case mObjColumnModel.mPrpColumnAlign
        Case clsColumnModelStruct.EnmColumnAlign.LEFT
          Return "left"
        Case clsColumnModelStruct.EnmColumnAlign.CENTER
          Return "center"
        Case clsColumnModelStruct.EnmColumnAlign.RIGHT
          Return "right"
        Case Else
          Return "left"
      End Select
    End Get
  End Property

  <JsonProperty("tpl")> _
  Public ReadOnly Property mPrpTpl() As String
    Get
      Return mObjColumnModel.mPrpColumnTpl
    End Get
  End Property

#End Region

  ''' <summary>
  ''' 静态方法,将数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsListColumnModelJsonStruct)) As String
    Dim lStrRtn As String = String.Empty
    If aArrObject.Count = 0 Then Return "null"
    lStrRtn = "["
    For Each lObjListColumnModelJson As clsListColumnModelJsonStruct In aArrObject
      lStrRtn = lStrRtn & lObjListColumnModelJson.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]"
    Return lStrRtn
  End Function

End Class