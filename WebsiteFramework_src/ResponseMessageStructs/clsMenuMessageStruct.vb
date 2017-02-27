
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-11-30                                          *'
'*   Synopsis     : 菜单数据结构体                                      *'
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

Public Class clsMenuMessageStruct
  Inherits clsBaseResponseMessage

#Region "枚举"
  ''' <summary>
  ''' 菜单项类型
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmMenuCategory
    SYSTEM = 1
    CUSTOM = 2
  End Enum
#End Region

  Private mLngMenuSrno As Long
  Private mLngMenuDisplayIndex As Long
  Private mStrMenuDesc As String
  Private mStrMenuLangSrno As String
  Private mLngParentSrno As Long
  Private mBlnIsLeaf As Boolean
  Private mEnmMenuCategory As EnmMenuCategory
  Private mStrURL As String
  Private mStrTarget As String
  Private mLngCreateUserSrno As Long
  Private mObjCreateDateTime As Date
  Private mLngUpdateUserSrno As Long
  Private mObjUpdateDateTime As Date

  Public Sub New()
    mLngMenuSrno = 0
    mLngMenuDisplayIndex = 0
    mStrMenuDesc = String.Empty
    mStrMenuLangSrno = "0"
    mLngParentSrno = 0
    mBlnIsLeaf = False
    mEnmMenuCategory = 0
    mStrURL = String.Empty
    mStrTarget = String.Empty
    mLngCreateUserSrno = 0
    mObjCreateDateTime = New Date
    mLngUpdateUserSrno = 0
    mObjUpdateDateTime = New Date
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsMenuSrno")> _
  Public Property mPrpMenuSrno() As Long
    Get
      Return mLngMenuSrno
    End Get
    Set(ByVal value As Long)
      mLngMenuSrno = value
    End Set
  End Property

  <JsonProperty("jsMenuDisplayIndex")> _
  Public Property mPrpMenuDisplayIndex() As Long
    Get
      Return mLngMenuDisplayIndex
    End Get
    Set(ByVal value As Long)
      mLngMenuDisplayIndex = value
    End Set
  End Property

  <JsonProperty("jsMenuDesc")> _
  Public Property mPrpMenuDesc() As String
    Get
      Return mStrMenuDesc
    End Get
    Set(ByVal value As String)
      mStrMenuDesc = value
    End Set
  End Property

  <JsonProperty("jsMenuLangSrno")> _
  Public Property mPrpMenuLangSrno() As String
    Get
      Return mStrMenuLangSrno
    End Get
    Set(ByVal value As String)
      mStrMenuLangSrno = value
    End Set
  End Property

  <JsonProperty("jsMenuLangDesc")> _
  Public ReadOnly Property mPrpMenuLangDesc() As String
    Get
      If mStrMenuLangSrno.Trim <> "0" Then
        Return ToLangDesc(mStrMenuLangSrno, mIntGlobal_Language_Indc)
      Else
        Return mStrMenuDesc
      End If
    End Get
  End Property

  <JsonProperty("jsParentSrno")> _
  Public Property mPrpParentSrno() As Long
    Get
      Return mLngParentSrno
    End Get
    Set(ByVal value As Long)
      mLngParentSrno = value
    End Set
  End Property

  <JsonProperty("jsIsLeaf")> _
  Public Property mPrpIsLeaf() As Boolean
    Get
      Return mBlnIsLeaf
    End Get
    Set(ByVal value As Boolean)
      mBlnIsLeaf = value
    End Set
  End Property

  <JsonProperty("jsMenuCategory")> _
  Public Property mPrpMenuCategory() As EnmMenuCategory
    Get
      Return mEnmMenuCategory
    End Get
    Set(ByVal value As EnmMenuCategory)
      mEnmMenuCategory = value
    End Set
  End Property

  <JsonProperty("jsMenuCategoryDesc")> _
  Public ReadOnly Property mPrpMenuCategoryDesc() As String
    Get
      Return mFnGetCategoryDesc(mEnmMenuCategory)
    End Get
  End Property

  <JsonProperty("jsURL")> _
  Public Property mPrpURL() As String
    Get
      Return mStrURL
    End Get
    Set(ByVal value As String)
      mStrURL = value
    End Set
  End Property

  <JsonProperty("jsTarget")> _
  Public Property mPrpTarget() As String
    Get
      Return mStrTarget
    End Get
    Set(ByVal value As String)
      mStrTarget = value
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
  ''' 静态方法,将菜单数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsMenuMessageStruct)) As String
    Dim lStrRtn As String = String.Empty
    lStrRtn = "{identifier:""jsMenuSrno"","
    lStrRtn = lStrRtn & "label:""jsMenuLangDesc"","
    If aArrObject.Count = 0 Then Return lStrRtn & "items:null}"
    lStrRtn = lStrRtn & "items:["
    For Each lObjException As clsMenuMessageStruct In aArrObject
      lStrRtn = lStrRtn & lObjException.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]}"
    Return lStrRtn
  End Function

  ''' <summary>
  ''' 将菜单类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmMenuCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetCategoryDesc(ByVal aEnmMenuCategory As EnmMenuCategory) As String
    Select Case aEnmMenuCategory
      Case EnmMenuCategory.CUSTOM
        Return ToLangDesc("1042", mIntGlobal_Language_Indc)
      Case EnmMenuCategory.SYSTEM
        Return ToLangDesc("1041", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

End Class


Public Class clsMenuMessageStructJsonStruct
  Inherits clsBaseResponseMessage

  Private mObjMenuMessage As clsMenuMessageStruct
  Private mLstChilden As List(Of clsMenuMessageStructJsonStruct)

  Sub New()
    mObjMenuMessage = New clsMenuMessageStruct
    mLstChilden = New List(Of clsMenuMessageStructJsonStruct)
  End Sub

#Region "CLASS PROPERTIES"

  <JsonIgnore()> _
  Public Property mPrpMenuMessage() As clsMenuMessageStruct
    Get
      Return mObjMenuMessage
    End Get
    Set(ByVal value As clsMenuMessageStruct)
      mObjMenuMessage = value
    End Set
  End Property

  <JsonProperty("text")> _
  Public ReadOnly Property mPrpText() As String
    Get
      Return mObjMenuMessage.mPrpMenuLangDesc
    End Get
  End Property

  <JsonProperty("qtip")> _
  Public ReadOnly Property mPrpQtip() As String
    Get
      Return mObjMenuMessage.mPrpMenuLangDesc
    End Get
  End Property

  <JsonProperty("leaf")> _
  Public ReadOnly Property mPrpLeaf() As Boolean
    Get
      Return mObjMenuMessage.mPrpIsLeaf
    End Get
  End Property

  <JsonProperty("href")> _
  Public ReadOnly Property mPrpHref() As String
    Get
      Return mObjMenuMessage.mPrpURL
    End Get
  End Property

  <JsonProperty("hrefTarget")> _
  Public ReadOnly Property mPrpHrefTarget() As String
    Get
      Return mObjMenuMessage.mPrpTarget
    End Get
  End Property

  <JsonProperty("children")> _
  Public Property mPrpChildren() As List(Of clsMenuMessageStructJsonStruct)
    Get
      Return mLstChilden
    End Get
    Set(ByVal value As List(Of clsMenuMessageStructJsonStruct))
      mLstChilden = value
    End Set
  End Property

#End Region

  ''' <summary>
  ''' 静态方法,将数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsMenuMessageStructJsonStruct)) As String
    Dim lStrRtn As String = String.Empty
    If aArrObject.Count = 0 Then Return "null"
    For Each lObjMenuMessageStructJson As clsMenuMessageStructJsonStruct In aArrObject
      lStrRtn = lStrRtn & lObjMenuMessageStructJson.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1)
    Return lStrRtn
  End Function

End Class
