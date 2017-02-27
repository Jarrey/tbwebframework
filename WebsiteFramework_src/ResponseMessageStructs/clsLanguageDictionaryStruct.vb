
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-03                                          *'
'*   Synopsis     : 字典数据结构体                                      *'
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

Public Class clsLanguageDictionaryStruct
  Inherits clsBaseResponseMessage

#Region "枚举"

  ''' <summary>
  ''' 字典语言类型
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmLanguage
    ZH = 1
    ZH_TW = 2
    EN = 3
  End Enum
#End Region

  Private mLngItemSrno As Long
  Private mEnmItemLang As EnmLanguage
  Private mStrItemDesc As String

  Sub New()
    mLngItemSrno = 0
    mEnmItemLang = EnmLanguage.ZH
    mStrItemDesc = String.Empty
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsItemSrno")> _
  Public Property mPrpItemSrno() As Long
    Get
      Return mLngItemSrno
    End Get
    Set(ByVal value As Long)
      mLngItemSrno = value
    End Set
  End Property

  <JsonProperty("jsItemLang")> _
  Public Property mPrpItemLang() As EnmLanguage
    Get
      Return mEnmItemLang
    End Get
    Set(ByVal value As EnmLanguage)
      mEnmItemLang = value
    End Set
  End Property

  <JsonProperty("jsItemLangDesc")> _
  Public ReadOnly Property mPrpItemLangDesc() As String
    Get
      Return mFnGetLanguageDesc(mEnmItemLang)
    End Get
  End Property

  <JsonProperty("jsItemDesc")> _
  Public Property mPrpItemDesc() As String
    Get
      Return mStrItemDesc
    End Get
    Set(ByVal value As String)
      mStrItemDesc = value
    End Set
  End Property

#End Region

  ''' <summary>
  ''' 将字典语言类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmLanguage"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetLanguageDesc(ByVal aEnmLanguage As EnmLanguage) As String
    Select Case aEnmLanguage
      Case EnmLanguage.ZH_TW
        Return "中文(繁體)"
      Case EnmLanguage.EN
        Return "英文(English)"
      Case EnmLanguage.ZH
        Return "中文(简体)"
      Case Else
        Return "中文(简体)"
    End Select
  End Function

End Class
