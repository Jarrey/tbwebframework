
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-11-27                                          *'
'*   Synopsis     : 空返回消息结构体                                    *'
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

Public Class clsResponseMessageStruct
  Inherits clsBaseResponseMessage

  Public Enum EnmMessageStatusIndc
    SUCCESS = 0
    FAIL = 1
  End Enum

  Private mIntMessageStatusIndc As EnmMessageStatusIndc
  Private mIntRequestIndc As Integer
  Private mStrMessage As String
  Private mObjMessageBody As String

  Sub New()
    mIntMessageStatusIndc = EnmMessageStatusIndc.SUCCESS
    mIntRequestIndc = 0
    mStrMessage = String.Empty
    mObjMessageBody = "null"
  End Sub

  Sub New(ByVal aEnmMessageStatusIndc As EnmMessageStatusIndc _
        , ByVal aStrMessage As String _
        , ByVal aObjMessageBody As String)
    Me.New()
    mIntMessageStatusIndc = aEnmMessageStatusIndc
    mStrMessage = aStrMessage
    mObjMessageBody = aObjMessageBody
  End Sub

  Sub New(ByVal aStrMessage As String _
        , Optional ByVal aObjMessageBody As String = "null")
    Me.New()
    mStrMessage = aStrMessage
    mObjMessageBody = aObjMessageBody
  End Sub

  Sub New(ByVal aEnmMessageStatusIndc As EnmMessageStatusIndc _
        , Optional ByVal aObjMessageBody As String = "null")
    Me.New()
    mIntMessageStatusIndc = aEnmMessageStatusIndc
    mObjMessageBody = aObjMessageBody
  End Sub

#Region "CLASS PROPERTIES"

  <JsonProperty("jsMessageStatusIndc")> _
  Public Property mPrpMessageStatusIndc() As EnmMessageStatusIndc
    Get
      Return mIntMessageStatusIndc
    End Get
    Set(ByVal value As EnmMessageStatusIndc)
      mIntMessageStatusIndc = value
    End Set
  End Property

  <JsonProperty("jsRequestIndc")> _
  Public Property mPrpRequestIndc() As Integer
    Get
      Return mIntRequestIndc
    End Get
    Set(ByVal value As Integer)
      mIntRequestIndc = value
    End Set
  End Property

  <JsonProperty("jsMessage")> _
  Public Property mPrpMessage() As String
    Get
      Return mStrMessage
    End Get
    Set(ByVal value As String)
      mStrMessage = value
    End Set
  End Property

  <JsonIgnore()> _
  Public Property mPrpMessageBody() As String
    Get
      Return mObjMessageBody
    End Get
    Set(ByVal value As String)
      mObjMessageBody = value
    End Set
  End Property

#End Region

  ''' <summary>
  ''' 重载ToJaonString方法,增加MessageBody块
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Overrides Function ToJsonString() As String
    Dim lStrRtn As String = MyBase.ToJSONString()
    lStrRtn = lStrRtn.Remove(lStrRtn.LastIndexOf("}"), 1) & ",""jsMessageBody"": [" & vbCrLf & mObjMessageBody & vbCrLf & "]}"
    Return lStrRtn
  End Function

End Class
