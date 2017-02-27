
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2010-01-25                                          *'
'*   Synopsis     : System MEssage 数据结构体                           *'
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

Public Class clsSystemMessageStruct
  Inherits clsBaseResponseMessage

#Region "枚举"
  ''' <summary>
  ''' 系统消息类型
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmMessageType
    SYSTEM_INFO = 1
    EXCEPTION_INFO = 2
    USER_INFO = 3
    DEBUG_INFO = 4
  End Enum

  ''' <summary>
  ''' 消息级别
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmMessageLevel
    ALL = 0
    NORMAL = 3
    SYSTEM = 2
    DEBUG = 1
  End Enum
#End Region

  Private mLngSystemMessageSrno As Long
  Private mObjMessageTime As Date
  Private mEnmMessageType As EnmMessageType
  Private mStrSystemMessage As String
  Private mEnmMessageLevel As EnmMessageLevel
  Private mLngCreateUserSrno As Long

  Sub New()
    mLngSystemMessageSrno = 0
    mObjMessageTime = New Date
    mEnmMessageType = EnmMessageType.SYSTEM_INFO
    mStrSystemMessage = String.Empty
    mEnmMessageLevel = EnmMessageLevel.SYSTEM
    mLngCreateUserSrno = 0
  End Sub

#Region "CLASS PROPERTIES"
  <JsonProperty("jsSystemMessageSrno")> _
  Public Property mPrpSystemMessageSrno() As Long
    Get
      Return mLngSystemMessageSrno
    End Get
    Set(ByVal value As Long)
      mLngSystemMessageSrno = value
    End Set
  End Property

  <JsonProperty("jsMessageTime")> _
  Public Property mPrpMessageTime() As Date
    Get
      Return mObjMessageTime
    End Get
    Set(ByVal value As Date)
      mObjMessageTime = value
    End Set
  End Property

  <JsonProperty("jsMessageType")> _
  Public Property mPrpMessageType() As EnmMessageType
    Get
      Return mEnmMessageType
    End Get
    Set(ByVal value As EnmMessageType)
      mEnmMessageType = value
    End Set
  End Property

  <JsonProperty("jsMessageTypeDesc")> _
  Public ReadOnly Property mPrpMessageTypeDesc() As String
    Get
      Return mFnGetTypeDesc(mEnmMessageType)
    End Get
  End Property

  <JsonProperty("jsSystemMessage")> _
  Public Property mPrpSystemMessage() As String
    Get
      Return mStrSystemMessage
    End Get
    Set(ByVal value As String)
      mStrSystemMessage = value
    End Set
  End Property

  <JsonProperty("jsMessageLevel")> _
  Public Property mPrpMessageLevel() As EnmMessageLevel
    Get
      Return mEnmMessageLevel
    End Get
    Set(ByVal value As EnmMessageLevel)
      mEnmMessageLevel = value
    End Set
  End Property

  <JsonProperty("jsMessageLevelDesc")> _
  Public ReadOnly Property mPrpMessageLevelDesc() As String
    Get
      Return mFnGetLevelDesc(mEnmMessageLevel)
    End Get
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
#End Region

  ''' <summary>
  ''' 将类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmMessageType"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetTypeDesc(ByVal aEnmMessageType As EnmMessageType) As String
    Select Case aEnmMessageType
      Case EnmMessageType.SYSTEM_INFO
        Return ToLangDesc("1054", mIntGlobal_Language_Indc)
      Case EnmMessageType.DEBUG_INFO
        Return ToLangDesc("1067|1066", mIntGlobal_Language_Indc)
      Case EnmMessageType.EXCEPTION_INFO
        Return ToLangDesc("1005|1066", mIntGlobal_Language_Indc)
      Case EnmMessageType.USER_INFO
        Return ToLangDesc("1013|1066", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

  ''' <summary>
  ''' 将级别枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmMessageLevel"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetLevelDesc(ByVal aEnmMessageLevel As EnmMessageLevel) As String
    Select Case aEnmMessageLevel
      Case EnmMessageLevel.ALL
        Return ToLangDesc("1036|1069", mIntGlobal_Language_Indc)
      Case EnmMessageLevel.SYSTEM
        Return ToLangDesc("1041|1069", mIntGlobal_Language_Indc)
      Case EnmMessageLevel.DEBUG
        Return ToLangDesc("1067|1069", mIntGlobal_Language_Indc)
      Case EnmMessageLevel.NORMAL
        Return ToLangDesc("1053|1069", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

  ''' <summary>
  ''' 静态方法,将异常数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsSystemMessageStruct)) As String
    Dim lStrRtn As String = String.Empty
    lStrRtn = "{identifier:""jsSystemMessageSrno"","
    lStrRtn = lStrRtn & "totalProperty:" & aArrObject.Count.ToString & ","
    If aArrObject.Count = 0 Then Return lStrRtn & "items:[]}"
    lStrRtn = lStrRtn & "items:["
    For Each lObjSystemMessage As clsSystemMessageStruct In aArrObject
      lStrRtn = lStrRtn & lObjSystemMessage.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]}"
    Return lStrRtn
  End Function

End Class
