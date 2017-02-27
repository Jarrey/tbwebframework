
#Region "INTERFACE HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-02-11                                          *'
'*   Synopsis     : 提供给不同数据库访问类的接口                        *'
'*                                                                      *'
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

#Region "INTERFACE DEFINITION"
Public Interface IDataAccess

  ''' <summary>
  ''' Execute SQL and Return DataTable
  ''' 执行SQL语句并返回DataTable
  ''' </summary>
  ''' <param name="aStrQuery"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Function mFnExecuteQueryAsDataSet(ByVal aStrQuery As String) As DataSet

  ''' <summary>
  ''' 执行查询返回DataReader
  ''' </summary>
  ''' <param name="aStrQuery"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Function mFnExecuteQueryAsDataReader(ByVal aStrQuery As String) As DbDataReader

  ''' <summary>
  '''  执行无数据返回的SQL语句
  ''' </summary>
  ''' <param name="aStrQuery"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Function mFnExecuteNonQuery(ByVal aStrQuery As String) As Integer

End Interface
#End Region
