
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-02-11                                          *'
'*   Synopsis     : This class is defined for interface between         *'
'*                  Database and Table Classes                          *'
'*                                                                      *'
'*   Modifications:                                                     *'
'************************************************************************'
'* Date       Author Mod. FTR No. Description                           *'
'* ---------- ------ ---- ------- ------------------------------------- *'
'* 2009/04/28 Jar                  增加对于二进制数据表的操作
'* 2009/10/15 Jar                  增加事务更新方法 mFnTransactionExecuteQuery
'* ---------- ------ ---- ------- ------------------------------------- *'
'************************************************************************'
#End Region

#Region "SYSTEM NAMESPACES"
Imports System.Data.Common
Imports System.Data.SQLite
#End Region

#Region "CLASS NAMESPACES"

#End Region

#Region "CLASS DEFINITION"
Public Class clsDataAccess
  Implements IDataAccess

#Region "CLASS ENUM DECLARATION"

  ''' <summary>
  ''' 返回类型选项
  ''' DATA_SET 返回 DataSet 类型,用于整个记录表查询
  ''' DATA_READER 返回 DataReader 类型,用于逐条检索
  ''' </summary>
  ''' <remarks></remarks>
  Protected Enum enmReturnIndc
    DATA_SET
    DATA_READER
  End Enum

#End Region

#Region "MEMBER VARIABLES"
  Private mObjConnectionDB As clsConnectionManager.enmConnectionDB
  Private mStrDataBaseFilePath As String

  Protected Const CONST_ZERO As Integer = 0
  Protected Const CONST_DATE_TIME_FORMAT As String = "yyyy-MM-dd HH:mm:ss"
  Protected Const CONST_DATE_FORMAT As String = "yyyy-MM-dd"
#End Region

#Region "MEMBER PROPERTIES"
  ''' <summary>
  ''' 数据库连接器标识
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property mPrpConnectionDB() As clsConnectionManager.enmConnectionDB
    Get
      Return mObjConnectionDB
    End Get
    Set(ByVal value As clsConnectionManager.enmConnectionDB)
      mObjConnectionDB = value
    End Set
  End Property

  ''' <summary>
  ''' 数据库文件路径
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property mPrpDataBaseFilePath() As String
    Get
      Return mStrDataBaseFilePath
    End Get
    Set(ByVal value As String)
      mStrDataBaseFilePath = value
    End Set
  End Property
#End Region

#Region "MEMBER FUNCTIONS"

  ''' <summary>
  ''' Execute SQL and Return DataTable
  ''' 执行SQL语句并返回DataTable
  ''' </summary>
  ''' <param name="aStrQuery">SQL语句</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnExecuteQueryAsDataSet(ByVal aStrQuery As String) As DataSet Implements IDataAccess.mFnExecuteQueryAsDataSet
    Dim lObjDataSet As New DataSet
    Dim lObjConnection As SQLiteConnection
    Dim lObjDataAdapter As SQLiteDataAdapter = Nothing

    If mObjConnectionDB = clsConnectionManager.enmConnectionDB.USER_DB Then
      lObjConnection = clsConnectionManager.mFnGetUserDBConnection(mStrDataBaseFilePath)
    Else
      lObjConnection = clsConnectionManager.mFnGetDbConnection()
    End If

    Try
      lObjDataAdapter = New SQLiteDataAdapter(aStrQuery, lObjConnection)
      lObjDataAdapter.Fill(lObjDataSet)
      lObjDataAdapter.Dispose()
      lObjDataAdapter = Nothing
    Catch ex As Exception
      Throw ex
    Finally
      If Not IsNothing(lObjDataAdapter) Then
        lObjDataAdapter.Dispose()
        lObjDataAdapter = Nothing
      End If
    End Try

    Return lObjDataSet
  End Function

  ''' <summary>
  ''' 执行查询返回DataReader
  ''' </summary>
  ''' <param name="aStrQuery"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnExecuteQueryAsDataReader(ByVal aStrQuery As String) As DbDataReader Implements IDataAccess.mFnExecuteQueryAsDataReader
    Dim lObjConnection As SQLiteConnection
    Dim lObjCommand As SQLiteCommand = Nothing

    If mObjConnectionDB = clsConnectionManager.enmConnectionDB.USER_DB Then
      lObjConnection = clsConnectionManager.mFnGetUserDBConnection(mStrDataBaseFilePath)
    Else
      lObjConnection = clsConnectionManager.mFnGetDbConnection()
    End If

    Try
      lObjCommand = New SQLiteCommand(aStrQuery, lObjConnection)
      Try
        Return lObjCommand.ExecuteReader(CommandBehavior.Default)
      Catch ex As Exception
        Return Nothing
      End Try
    Catch ex As Exception
      Throw ex
    Finally
      If Not IsNothing(lObjCommand) Then
        lObjCommand.Dispose()
        lObjCommand = Nothing
      End If
    End Try

  End Function

  ''' <summary>
  ''' 执行无数据返回的SQL语句
  ''' </summary>
  ''' <param name="aStrQuery">SQL语句</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnExecuteNonQuery(ByVal aStrQuery As String) As Integer Implements IDataAccess.mFnExecuteNonQuery
    Dim lObjConnection As SQLiteConnection
    Dim lObjCommand As SQLiteCommand = Nothing

    If mObjConnectionDB = clsConnectionManager.enmConnectionDB.USER_DB Then
      lObjConnection = clsConnectionManager.mFnGetUserDBConnection(mStrDataBaseFilePath)
    Else
      lObjConnection = clsConnectionManager.mFnGetDbConnection()
    End If

    Try
      lObjCommand = New SQLiteCommand(aStrQuery, lObjConnection)
      Return lObjCommand.ExecuteNonQuery()
    Catch ex As Exception
      Throw ex
    Finally
      If Not IsNothing(lObjCommand) Then
        lObjCommand.Dispose()
        lObjCommand = Nothing
      End If
    End Try
  End Function

  ''' <summary>
  ''' 执行数据库命令行
  ''' </summary>
  ''' <param name="aObjCommand">命令行</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnExecuteCommand(ByVal aObjCommand As SQLiteCommand) As Integer
    Return aObjCommand.ExecuteNonQuery()
  End Function

  ''' <summary>
  ''' 执行查询，并返回查询所返回的结果集中第一行的第一列。所有其他的列和行将被忽略。
  ''' 用于例如 Count() Avg() 等只有一个字段值输出的查询
  ''' </summary>
  ''' <param name="aStrSQLQuery"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnExecuteScalar(ByVal aStrSQLQuery As String) As Object
    Dim lObjConnection As SQLiteConnection
    Dim lObjCommand As SQLiteCommand = Nothing

    If mObjConnectionDB = clsConnectionManager.enmConnectionDB.USER_DB Then
      lObjConnection = clsConnectionManager.mFnGetUserDBConnection(mStrDataBaseFilePath)
    Else
      lObjConnection = clsConnectionManager.mFnGetDbConnection()
    End If

    Try
      lObjCommand = New SQLiteCommand(aStrSQLQuery, lObjConnection)
      Return lObjCommand.ExecuteScalar
    Catch ex As Exception
      Throw ex
    Finally
      If Not IsNothing(lObjCommand) Then
        lObjCommand.Dispose()
        lObjCommand = Nothing
      End If
    End Try
  End Function

  ''' <summary>
  ''' 向数据库中插入/更新二进制数据
  ''' </summary>
  ''' <param name="aStrQuery"></param>
  ''' <param name="aObjData">二进制数据</param>
  ''' <param name="aStrDataFieldName">二进制数据字段名</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnExecuteNonQueryForBin( _
                        ByVal aStrQuery As String, _
                        ByVal aObjData As Byte(), _
                        Optional ByVal aStrDataFieldName As String = "Data") As Integer

    Dim lObjConnection As SQLiteConnection
    Dim lObjCommand As SQLiteCommand = Nothing

    If mObjConnectionDB = clsConnectionManager.enmConnectionDB.USER_DB Then
      lObjConnection = clsConnectionManager.mFnGetUserDBConnection(mStrDataBaseFilePath)
    Else
      lObjConnection = clsConnectionManager.mFnGetDbConnection()
    End If

    Try
      lObjCommand = New SQLiteCommand(aStrQuery, lObjConnection)
      lObjCommand.Parameters.AddWithValue("@" & aStrDataFieldName, aObjData)
      Return lObjCommand.ExecuteNonQuery()
    Catch ex As Exception
      Throw ex
    Finally
      If Not IsNothing(lObjCommand) Then
        lObjCommand.Dispose()
        lObjCommand = Nothing
      End If
    End Try
  End Function

  ''' <summary>
  ''' 事务更新数据库
  ''' </summary>
  ''' <param name="aStrQuery">SQL语句，将所有语句组合成字符串数组</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnTransactionExecuteQuery(ByVal aStrQuery As ArrayList) As Integer
    Dim lObjConnection As SQLiteConnection
    Dim lObjTansaction As SQLiteTransaction = Nothing
    Dim lObjCommand As SQLiteCommand = Nothing

    If mObjConnectionDB = clsConnectionManager.enmConnectionDB.USER_DB Then
      lObjConnection = clsConnectionManager.mFnGetUserDBConnection(mStrDataBaseFilePath)
    Else
      lObjConnection = clsConnectionManager.mFnGetDbConnection()
    End If

    Try
      lObjTansaction = lObjConnection.BeginTransaction
      lObjCommand = New SQLiteCommand(lObjConnection)
      For Each lStrQuery As String In aStrQuery
        lObjCommand.CommandText = lStrQuery
        lObjCommand.ExecuteNonQuery()
      Next
      lObjTansaction.Commit()
      Return 1
    Catch ex As Exception
      Throw ex
      lObjTansaction.Rollback()
    Finally
      If Not IsNothing(lObjCommand) Then
        lObjCommand.Dispose()
        lObjCommand = Nothing
      End If
    End Try

  End Function

  ''' <summary>
  ''' 向子类提供从DataReader读取数据的方法
  ''' </summary>
  ''' <param name="aObjDataReader"></param>
  ''' <param name="aStrFieldName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Protected Function mFnPopulate(ByVal aObjDataReader As SQLiteDataReader, ByVal aStrFieldName As String) As Object
    Try
      Dim lObjObject As Object = aObjDataReader.Item(aStrFieldName)
      If Not IsDBNull(lObjObject) Then
        Return lObjObject
      Else
        Return Nothing
      End If
    Catch ex As Exception
      Throw ex
      Return Nothing
    End Try
  End Function

#End Region

End Class
#End Region
