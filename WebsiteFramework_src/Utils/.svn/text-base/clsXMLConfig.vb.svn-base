
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-10-15                                          *'
'*   Synopsis     : This class is defined for reading Database config   *'
'*                                                                      *'
'*                                                                      *'
'*   Modifications:                                                     *'
'************************************************************************'
'* Date     Author Mod. FTR No. Description                             *'
'* -------- ------ ---- ------- -------------------------------------   *'
'* 
'*
'* -------- ------ ---- ------- -------------------------------------   *'
'************************************************************************'
#End Region

#Region "CLASS DEFINITION"

Public Class clsXMLConfig

#Region "MEMBER VARIABLES"
  Private mObjXMLDocument As Xml.XmlDocument
  Private mObjLastModifyTime As New Date
  Private mStrConfigFile As String '配置文件路径
#End Region

#Region "CLASS MEMBER PROPERTIES"

  Public Property mPrpConfigFile() As String
    Get
      Return mStrConfigFile
    End Get
    Set(ByVal value As String)
      mStrConfigFile = value
    End Set
  End Property

#End Region

#Region "MEMBER FUNCTIONS"

  Public Sub New(ByVal aStrConfigFile As String)
    mStrConfigFile = aStrConfigFile
  End Sub

  ''' <summary>
  ''' 获得数据库XML配置文件对象
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub mFnGetXMLDocument()
    Try
      If mObjXMLDocument Is Nothing Then
        mObjXMLDocument = New System.Xml.XmlDocument
        mObjXMLDocument.Load(mStrConfigFile)
        mObjLastModifyTime = IO.File.GetLastWriteTime(mStrConfigFile)
      End If

      If mObjLastModifyTime <> IO.File.GetLastWriteTime(mStrConfigFile) Then
        mObjXMLDocument.Load(mStrConfigFile)
        mObjLastModifyTime = IO.File.GetLastWriteTime(mStrConfigFile)
      End If
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

  ''' <summary>
  ''' 读取配置文件数据
  ''' </summary>
  ''' <param name="aStrElementName">节点名</param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  Public Function mFnReadConfig(ByVal aStrElementName As String) As String
    Try
      mFnGetXMLDocument()
      Return mObjXMLDocument.DocumentElement.Item(aStrElementName).InnerText
    Catch ex As Exception
      Throw ex
      Return String.Empty
    End Try
  End Function

  ''' <summary>
  ''' 保存配置文件数据
  ''' </summary>
  ''' <param name="aStrElementName">节点名</param>
  ''' <param name="aObjValue">参数值</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mFnWriteConfig(ByVal aStrElementName As String, ByVal aObjValue As Object) As Boolean
     Try
      mFnGetXMLDocument()
      mObjXMLDocument.DocumentElement.Item(aStrElementName).InnerText = aObjValue.ToString
      mObjXMLDocument.Save(mStrConfigFile)
      Return True
    Catch ex As Exception
      Throw ex
      Return False
    End Try
  End Function

#End Region

End Class

#End Region
