
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-11-27                                          *'
'*   Synopsis     : 异常数据结构体                                      *'
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

Public Class clsExceptionMessageStruct
  Inherits clsBaseResponseMessage

#Region "枚举"
  ''' <summary>
  ''' 异常状态
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmExceptionStatus
    ALL = 0
    NORMAL = 1
    FIXED = 2
    EXIGENT = 3
    INESSENTIAL = 4
  End Enum
#End Region

  Private mLngExceptionSrno As Long
  Private mObjDateTime As Date
  Private mStrTitle As String
  Private mStrContext As String
  Private mLngExceptionStatus As Long
  Private mLngUserSrno As Long
  Private mObjUpdateDateTime As Date

  Public Sub New()
    mLngExceptionSrno = 0
    mObjDateTime = New Date
    mStrTitle = String.Empty
    mStrContext = String.Empty
    mLngExceptionStatus = 0
    mLngUserSrno = 0
    mObjUpdateDateTime = New Date
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsExceptionSrno")> _
  Public Property mPrpExceptionSrno() As Long
    Get
      Return mLngExceptionSrno
    End Get
    Set(ByVal value As Long)
      mLngExceptionSrno = value
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

  <JsonProperty("jsTitle")> _
  Public Property mPrpTitle() As String
    Get
      Return mStrTitle
    End Get
    Set(ByVal value As String)
      mStrTitle = value
    End Set
  End Property

  <JsonProperty("jsContext")> _
  Public Property mPrpContext() As String
    Get
      Return mStrContext
    End Get
    Set(ByVal value As String)
      mStrContext = value
    End Set
  End Property

  <JsonProperty("jsExceptionStatus")> _
  Public Property mPrpExceptionStatus() As Long
    Get
      Return mLngExceptionStatus
    End Get
    Set(ByVal value As Long)
      mLngExceptionStatus = value
    End Set
  End Property

  <JsonProperty("jsExceptionStatusDesc")> _
  Public ReadOnly Property mPrpExceptionStatusDesc() As String
    Get
      Return mFnGetStatusDesc(mLngExceptionStatus)
    End Get
  End Property

  <JsonProperty("jsUserSrno")> _
  Public Property mPrpUserSrno() As Long
    Get
      Return mLngUserSrno
    End Get
    Set(ByVal value As Long)
      mLngUserSrno = value
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
  ''' 静态方法,将异常数据组序列化成Json数组
  ''' </summary>
  ''' <param name="aArrObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function ToJSONArray(ByVal aArrObject As System.Collections.Generic.List(Of clsExceptionMessageStruct)) As String
    Dim lStrRtn As String = String.Empty
    lStrRtn = "{identifier:""jsExceptionSrno"","
    lStrRtn = lStrRtn & "totalProperty:" & aArrObject.Count.ToString & ","
    If aArrObject.Count = 0 Then Return lStrRtn & "items:[]}"
    lStrRtn = lStrRtn & "items:["
    For Each lObjException As clsExceptionMessageStruct In aArrObject
      lStrRtn = lStrRtn & lObjException.ToJSONString & ","
    Next
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf(","), 1) & "]}"
    Return lStrRtn
  End Function

  ''' <summary>
  ''' 将状态枚举值转换成描述值
  ''' </summary>
  ''' <param name="aLngStatus"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetStatusDesc(ByVal aLngStatus As EnmExceptionStatus) As String
    Select Case aLngStatus
      Case EnmExceptionStatus.NORMAL
        Return ToLangDesc("1037", mIntGlobal_Language_Indc)
      Case EnmExceptionStatus.FIXED
        Return ToLangDesc("1038", mIntGlobal_Language_Indc)
      Case EnmExceptionStatus.EXIGENT
        Return ToLangDesc("1039", mIntGlobal_Language_Indc)
      Case EnmExceptionStatus.INESSENTIAL
        Return ToLangDesc("1040", mIntGlobal_Language_Indc)
      Case Else
        Return String.Empty
    End Select
  End Function

End Class

