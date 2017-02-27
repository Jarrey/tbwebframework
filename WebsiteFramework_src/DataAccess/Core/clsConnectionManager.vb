
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-02-11                                          *'
'*   Synopsis     : This class is defined for interface between         *'
'*                  Database and clsDataAccess                          *'
'*                                                                      *'
'*   Modifications:                                                     *'
'************************************************************************'
'* Date     Author Mod. FTR No. Description                             *'
'* -------- ------ ---- ------- -------------------------------------   *'
'* 20090211  Jar  DataAccess      Add Connection for User Define DataBase
'* 20091015  Jar                  增加数据库配置类和配置文件，解决发布后无法定义数据库路径问题
'*
'* -------- ------ ---- ------- -------------------------------------   *'
'************************************************************************'
#End Region

#Region "SYSTEM NAMESPACES"
Imports System.Data.Common
Imports System.Windows.Forms
Imports System.Data.SQLite
#End Region

#Region "CLASS NAMESPACES"
Imports Utils
#End Region

#Region "CLASS DEFINITION"

Public NotInheritable Class clsConnectionManager
  Implements IDisposable

#Region "ENUM DECLARATION"
  Public Enum enmConnectionDB
    SYSTEM_DB
    USER_DB
  End Enum
#End Region

#Region "MEMBER VARIABLES"
  Private Shared mObjDBConnection As SQLiteConnection
  Private Shared mObjUserDBConnection As SQLiteConnection
  Private Shared mStrUserDBPath As String = String.Empty
  Private Shared mStrSystemDBPath As String = String.Empty
  ''' <summary>
  ''' 数据库配置操作对象
  ''' </summary>
  ''' <remarks></remarks>
  Private Shared mObjXMLConfig As New clsXMLConfig(Utils.clsSharedMemory.mStrApplicationPath & "\bin\DbConfig.xml")
#End Region

#Region "CLASS MEMBER PROPERTIES"

  Public Shared ReadOnly Property mPrpUserDBPath() As String
    Get
      Return mStrUserDBPath
    End Get
  End Property

  Public Shared WriteOnly Property mPrpSystemDBPath() As String
    Set(ByVal value As String)
      mStrSystemDBPath = value
    End Set
  End Property

#End Region

#Region "MEMBER FUNCTIONS"

  Private Sub New()

  End Sub

  Public Sub Dispose() Implements IDisposable.Dispose

  End Sub

  Public Shared Sub mPrDispose()
    mObjDBConnection.Close()
    mObjDBConnection = Nothing
  End Sub

  ''' <summary>
  ''' Get DataBase Connection
  ''' 获得数据库联接
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetDbConnection() As SQLiteConnection

    Dim lObjDbConnection As SQLiteConnection = Nothing
    Dim lObjDBConnStr As New SQLiteConnectionStringBuilder

    If mObjDBConnection Is Nothing Then
      With lObjDBConnStr
        If mStrSystemDBPath = String.Empty Or IO.File.Exists(mStrSystemDBPath) = False Then
          '调用数据库配置类来获得数据库路径
          .DataSource = mObjXMLConfig.mFnReadConfig("DBFilePath") & mObjXMLConfig.mFnReadConfig("DBFileName")
        Else
          .DataSource = mStrSystemDBPath
        End If
        .FailIfMissing = True
        '.Password=""
      End With
      mObjDBConnection = New SQLiteConnection(lObjDBConnStr.ToString)
      Try
        mObjDBConnection.Open()
      Catch ex As Exception
        mObjDBConnection.Dispose()
        mObjDBConnection = Nothing
        Throw ex
      End Try
    End If

    If mFnBooleanCheckConnection(enmConnectionDB.SYSTEM_DB) = False Then
      mObjDBConnection.Open()
    End If

    lObjDbConnection = mObjDBConnection

    Return lObjDbConnection
  End Function

  ''' <summary>
  ''' 获得用户自定义数据库联接
  ''' </summary>
  ''' <param name="aStrDBFilePath">用户自定义数据库路径</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetUserDBConnection(ByVal aStrDBFilePath As String) As SQLiteConnection

    Dim lObjDbConnection As SQLiteConnection = Nothing
    Dim lObjDBConnStr As New SQLiteConnectionStringBuilder

    If mObjUserDBConnection Is Nothing Then
      mStrUserDBPath = aStrDBFilePath
      With lObjDBConnStr
        .DataSource = mStrUserDBPath
        '.Password=""
      End With
      Try
        mObjUserDBConnection = New SQLiteConnection(lObjDBConnStr.ToString)
        mObjUserDBConnection.Open()
      Catch ex As Exception
        mObjUserDBConnection = Nothing
      End Try
    Else
      If mStrUserDBPath <> aStrDBFilePath Then
        mPrCloseUserDBConnection()
        mStrUserDBPath = aStrDBFilePath
        With lObjDBConnStr
          .DataSource = mStrUserDBPath
          '.Password=""
        End With
        Try
          mObjUserDBConnection = New SQLiteConnection(lObjDBConnStr.ToString)
          mObjUserDBConnection.Open()
        Catch ex As Exception
          mObjUserDBConnection = Nothing
        End Try
      End If
    End If

    If Not IsNothing(mObjUserDBConnection) Then
      If mObjUserDBConnection.State = ConnectionState.Closed Then
        Try
          mObjUserDBConnection.Open()
        Catch ex As Exception
          mObjUserDBConnection = Nothing
        End Try
      End If
    Else
      Try
        mObjUserDBConnection.Open()
      Catch ex As Exception
        mObjUserDBConnection = Nothing
      End Try
    End If

    lObjDbConnection = mObjUserDBConnection
    Return lObjDbConnection
  End Function

  ''' <summary>
  ''' Check The DataBase Connection State
  ''' 检测数据库联接
  ''' </summary>
  ''' <param name="aEnmConnectionDB">DataBase Type 数据库类型</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Shared Function mFnBooleanCheckConnection(ByVal aEnmConnectionDB As enmConnectionDB) As Boolean

    Dim lBlnIsConnectionOpen As Boolean = True

    If aEnmConnectionDB = enmConnectionDB.SYSTEM_DB Then
      'System DB
      If Not IsNothing(mObjDBConnection) Then
        If mObjDBConnection.State = ConnectionState.Closed Then
          lBlnIsConnectionOpen = False
        End If
      Else
        lBlnIsConnectionOpen = False
      End If
    ElseIf aEnmConnectionDB = enmConnectionDB.USER_DB Then
      'User DB
      If Not IsNothing(mObjUserDBConnection) Then
        If mObjUserDBConnection.State = ConnectionState.Closed Then
          lBlnIsConnectionOpen = False
        End If
      Else
        lBlnIsConnectionOpen = False
      End If
    End If

    Return lBlnIsConnectionOpen
  End Function

  ''' <summary>
  ''' Close System Setup DataBase
  ''' 关闭系统数据库
  ''' </summary>
  ''' <remarks></remarks>
  Public Shared Sub mPrCloseSysSetDBConnection()
    If mFnBooleanCheckConnection(enmConnectionDB.SYSTEM_DB) Then
      If Not IsNothing(mObjDBConnection) Then
        mObjDBConnection.Close()
        mObjDBConnection = Nothing
      End If
    End If
  End Sub

  ''' <summary>
  ''' Close User DataBase 关闭用户自定义数据库
  ''' </summary>
  ''' <remarks></remarks>
  Public Shared Sub mPrCloseUserDBConnection()
    If mFnBooleanCheckConnection(enmConnectionDB.USER_DB) Then
      If Not IsNothing(mObjUserDBConnection) Then
        mObjUserDBConnection.Close()
        mObjUserDBConnection = Nothing
      End If
    End If
  End Sub
#End Region

End Class
#End Region
