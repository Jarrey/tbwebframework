
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-04                                          *'
'*   Synopsis     : 日志数据结构体                                      *'
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

Public Class clsLogMessagrStruct
  Inherits clsBaseResponseMessage

#Region "枚举"
  ''' <summary>
  ''' 日志类型
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmLogCategory
    NORMAL = 1
    EXCEPTION = 2
    SYSTEM_INFO = 3
    DEBUG_INFO = 4
  End Enum

  ''' <summary>
  ''' 日志记录级别
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmLogLevel
    ALL = 0
    NORMAL = 3
    SYSTEM = 2
    DEBUG = 1
  End Enum
#End Region

  Private mLngLogFileSrno As Long
  Private mObjDateTime As Date
  Private mEnmLogCategory As EnmLogCategory
  Private mEnmLogLevel As EnmLogLevel
  Private mStrLogFileName As String

  Sub New()
    mLngLogFileSrno = 0
    mObjDateTime = New Date
    mEnmLogCategory = EnmLogCategory.NORMAL
    mEnmLogLevel = EnmLogLevel.ALL
    mStrLogFileName = String.Empty
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsLogFileSrno")> _
  Public Property mPrpLogFileSrno() As Long
    Get
      Return mLngLogFileSrno
    End Get
    Set(ByVal value As Long)
      mLngLogFileSrno = value
    End Set
  End Property

  <JsonProperty("jsDateTime")> _
  Public Property mPrpDateTime() As Date
    Get
      Return mObjDateTime
    End Get
    Set(ByVal value As Date)
      mObjDateTime = value
    End Set
  End Property

  <JsonProperty("jsLogCategory")> _
  Public Property mPrpLogCategory() As EnmLogCategory
    Get
      Return mEnmLogCategory
    End Get
    Set(ByVal value As EnmLogCategory)
      mEnmLogCategory = value
    End Set
  End Property

  <JsonProperty("jsLogCategoryDesc")> _
  Public ReadOnly Property mPrpLogCategoryDesc() As String
    Get
      Return mFnGetCategoryDesc(mEnmLogCategory)
    End Get
  End Property

  <JsonProperty("jsLogLevel")> _
  Public Property mPrpLogLevel() As EnmLogLevel
    Get
      Return mEnmLogLevel
    End Get
    Set(ByVal value As EnmLogLevel)
      mEnmLogLevel = value
    End Set
  End Property

  <JsonProperty("jsLogLevelDesc")> _
  Public ReadOnly Property mPrpLogLevelDesc() As String
    Get
      Return mFnGetLevelDesc(mEnmLogLevel)
    End Get
  End Property

  <JsonProperty("jsLogFileName")> _
  Public Property mPrpLogFileName() As String
    Get
      Return mStrLogFileName
    End Get
    Set(ByVal value As String)
      mStrLogFileName = value
    End Set
  End Property

#End Region

  ''' <summary>
  ''' 静态方法,将日志数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsLogMessagrStruct)) As String
    Dim lStrRtn As String = String.Empty
    lStrRtn = "{identifier:""jsLogFileSrno"","
    lStrRtn = lStrRtn & "totalProperty:" & aArrObject.Count.ToString & ","
    If aArrObject.Count = 0 Then Return lStrRtn & "items:[]}"
    lStrRtn = lStrRtn & "items:["
    For Each lObLog As clsLogMessagrStruct In aArrObject
      lStrRtn = lStrRtn & lObLog.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]}"
    Return lStrRtn
  End Function

  ''' <summary>
  ''' 将日志类型枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmLogCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetCategoryDesc(ByVal aEnmLogCategory As EnmLogCategory) As String
    Select Case aEnmLogCategory
      Case EnmLogCategory.NORMAL
        Return ToLangDesc("1053|1066", mIntGlobal_Language_Indc) '普通
      Case EnmLogCategory.EXCEPTION
        Return ToLangDesc("1005|1066", mIntGlobal_Language_Indc) '异常
      Case EnmLogCategory.SYSTEM_INFO
        Return ToLangDesc("1054", mIntGlobal_Language_Indc) '系统信息
      Case EnmLogCategory.DEBUG_INFO
        Return ToLangDesc("1067|1066", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

  ''' <summary>
  ''' 将日志记录级别枚举值转换成描述值
  ''' </summary>
  ''' <param name="aEnmLogLevel"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetLevelDesc(ByVal aEnmLogLevel As EnmLogLevel) As String
    Select Case aEnmLogLevel
      Case EnmLogLevel.ALL
        Return ToLangDesc("1036", mIntGlobal_Language_Indc)
      Case EnmLogLevel.NORMAL
        Return ToLangDesc("1053|1069", mIntGlobal_Language_Indc) '普通
      Case EnmLogLevel.SYSTEM
        Return ToLangDesc("1041|1069", mIntGlobal_Language_Indc) '系统
      Case EnmLogLevel.DEBUG
        Return ToLangDesc("1067|1069", mIntGlobal_Language_Indc) '调试
      Case Else
        Return String.Empty
    End Select
  End Function

End Class
