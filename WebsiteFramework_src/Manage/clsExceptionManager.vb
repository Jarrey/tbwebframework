
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-10-15                                          *'
'*   Synopsis     : Exception Manager class ,processing the exceprions  *'
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

Imports DataAccess
Imports Utils
Imports ResponseMessageStructs
Imports Newtonsoft.Json
Imports System.Web
Imports System.Text.RegularExpressions

Public Class clsExceptionManager

  ''' <summary>
  ''' 根据条件查询异常数据
  ''' </summary>
  ''' <param name="aObjFromDate"></param>
  ''' <param name="aObjToDate"></param>
  ''' <param name="aEnmStstus"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mPopulateException(ByVal aObjFromDate As Date, ByVal aObjToDate As Date, ByVal aEnmStstus As clsExceptionMessageStruct.EnmExceptionStatus) As List(Of clsExceptionMessageStruct)
    Dim lArrRtn As New List(Of clsExceptionMessageStruct)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblExceptionLog As New TableClass.clsTB_EXCEPTION_MANAGER
    Dim lObjException As clsExceptionMessageStruct = Nothing

    lObjTblExceptionLog.mPrpEM_STATUS = aEnmStstus
    lObjTblExceptionLog.mPrpFromDate = aObjFromDate
    lObjTblExceptionLog.mPrpToDate = aObjToDate
    lObjTblExceptionLog.mPrRetrieveData(lDtDataReader, TableClass.clsTB_EXCEPTION_MANAGER.enmQueryIndicator.SELECT_DATE_STATUS)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblExceptionLog.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_EXCEPTION_MANAGER.enmQueryIndicator.SELECT_DATE_STATUS)
        lObjException = New clsExceptionMessageStruct
        With lObjException
          .mPrpExceptionSrno = lDtDataReader.Item("EM_EXCEPTION_SRNO")
          .mPrpDateTime = lDtDataReader.Item("EM_DATE_TIME")
          .mPrpTitle = lDtDataReader.Item("EM_TITLE")
          .mPrpContext = lDtDataReader.Item("EM_CONTEXT")
          .mPrpExceptionStatus = lDtDataReader.Item("EM_STATUS")
          .mPrpUserSrno = IIf(IsDBNull(lDtDataReader.Item("EM_UPDATE_USER_SRNO")), 0, lDtDataReader.Item("EM_UPDATE_USER_SRNO"))
          .mPrpUpdateDateTime = IIf(IsDBNull(lDtDataReader.Item("EM_UPDATE_TIME")), Nothing, lDtDataReader.Item("EM_UPDATE_TIME"))
        End With
        lArrRtn.Add(lObjException)
      End While
    End If

    Return lArrRtn
  End Function

  ''' <summary>
  ''' 根据条件查询异常数据
  ''' </summary>
  ''' <param name="aLngExceptionSrno"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mPopulateException(ByVal aLngExceptionSrno As Long) As clsExceptionMessageStruct
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblExceptionLog As New TableClass.clsTB_EXCEPTION_MANAGER
    Dim lObjException As New clsExceptionMessageStruct

    lObjTblExceptionLog.mPrpEM_EXCEPTION_SRNO = aLngExceptionSrno
    lObjTblExceptionLog.mPrRetrieveData(lDtDataReader, TableClass.clsTB_EXCEPTION_MANAGER.enmQueryIndicator.PRIMARY_KEY)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblExceptionLog.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_EXCEPTION_MANAGER.enmQueryIndicator.PRIMARY_KEY)
        With lObjException
          .mPrpExceptionSrno = lDtDataReader.Item("EM_EXCEPTION_SRNO")
          .mPrpDateTime = lDtDataReader.Item("EM_DATE_TIME")
          .mPrpTitle = lDtDataReader.Item("EM_TITLE")
          .mPrpContext = lDtDataReader.Item("EM_CONTEXT")
          .mPrpExceptionStatus = lDtDataReader.Item("EM_STATUS")
          .mPrpUserSrno = IIf(IsDBNull(lDtDataReader.Item("EM_UPDATE_USER_SRNO")), 0, lDtDataReader.Item("EM_UPDATE_USER_SRNO"))
          .mPrpUpdateDateTime = IIf(IsDBNull(lDtDataReader.Item("EM_UPDATE_TIME")), Nothing, lDtDataReader.Item("EM_UPDATE_TIME"))
        End With
      End While
    End If

    Return lObjException
  End Function

  ''' <summary>
  ''' 更新异常数据
  ''' </summary>
  ''' <param name="aLngExceptionSrno"></param>
  ''' <param name="aEnmStstus"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mUpdateException(ByVal aLngExceptionSrno As Long, ByVal aEnmStstus As clsExceptionMessageStruct.EnmExceptionStatus) As Boolean
    Dim lObjTblExceptionLog As New TableClass.clsTB_EXCEPTION_MANAGER
    lObjTblExceptionLog.mPrpEM_EXCEPTION_SRNO = aLngExceptionSrno
    lObjTblExceptionLog.mPrpEM_STATUS = aEnmStstus
    lObjTblExceptionLog.mPrpEM_UPDATE_TIME = Now
    Try
      lObjTblExceptionLog.mPrUpdateStatus()
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  ''' <summary>
  ''' 删除指定的异常数据
  ''' </summary>
  ''' <param name="aLngExceptionSrno"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mDeleteException(ByVal aLngExceptionSrno As Long) As Boolean
    Dim lObjTblExceptionLog As New TableClass.clsTB_EXCEPTION_MANAGER
    lObjTblExceptionLog.mPrpEM_EXCEPTION_SRNO = aLngExceptionSrno
    Try
      lObjTblExceptionLog.mFnDelete()
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  ''' <summary>
  ''' 删除所有异常数据
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mDeleteAllException() As Boolean
    Dim lObjTblExceptionLog As New TableClass.clsTB_EXCEPTION_MANAGER
    Try
      lObjTblExceptionLog.mFnDeleteAll()
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  ''' <summary>
  ''' 插入新的异常数据
  ''' </summary>
  ''' <param name="aObjException"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mInsertExceptionLog(ByVal aObjException As Exception) As Boolean
    Dim lObjTblExceptionLog As New TableClass.clsTB_EXCEPTION_MANAGER
    lObjTblExceptionLog.mPrpEM_EXCEPTION_SRNO = lObjTblExceptionLog.mFnMaxId() + 1
    lObjTblExceptionLog.mPrpEM_DATE_TIME = Now
    lObjTblExceptionLog.mPrpEM_TITLE = aObjException.Message
    lObjTblExceptionLog.mPrpEM_CONTEXT = aObjException.ToString
    lObjTblExceptionLog.mPrpEM_STATUS = clsExceptionMessageStruct.EnmExceptionStatus.NORMAL
    lObjTblExceptionLog.mPrpEM_UPDATE_USER_SRNO = Nothing
    lObjTblExceptionLog.mPrpEM_UPDATE_TIME = Nothing
    lObjTblExceptionLog.mFnInsert()
    clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.EXCEPTION, aObjException.ToString, clsLogMessagrStruct.EnmLogLevel.SYSTEM)
  End Function

End Class
