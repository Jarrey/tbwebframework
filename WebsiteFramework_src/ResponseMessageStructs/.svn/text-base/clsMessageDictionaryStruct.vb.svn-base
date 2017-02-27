
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-03                                          *'
'*   Synopsis     : 消息字典数据结构体                                  *'
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

Public Class clsMessageDictionaryStruct
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

  Private mLngMessageSrno As Long
  Private mEnmMessageLang As EnmLanguage
  Private mStrMessageDesc As String

  Sub New()
    mLngMessageSrno = 0
    mEnmMessageLang = EnmLanguage.ZH
    mStrMessageDesc = String.Empty
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsMessageSrno")> _
  Public Property mPrpMessageSrno() As Long
    Get
      Return mLngMessageSrno
    End Get
    Set(ByVal value As Long)
      mLngMessageSrno = value
    End Set
  End Property

  <JsonProperty("jsMessageLang")> _
  Public Property mPrpMessageLang() As EnmLanguage
    Get
      Return mEnmMessageLang
    End Get
    Set(ByVal value As EnmLanguage)
      mEnmMessageLang = value
    End Set
  End Property

  <JsonProperty("jsMessageLangDesc")> _
  Public ReadOnly Property mPrpItemLangDesc() As String
    Get
      Return mFnGetLanguageDesc(mEnmMessageLang)
    End Get
  End Property

  <JsonProperty("jsMessageDesc")> _
  Public Property mPrpMessageDesc() As String
    Get
      Return mStrMessageDesc
    End Get
    Set(ByVal value As String)
      mStrMessageDesc = value
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
