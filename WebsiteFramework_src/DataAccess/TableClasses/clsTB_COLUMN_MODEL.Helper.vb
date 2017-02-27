
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob@gmail.com
'*   Date         : 2010-1-24 22:56:09
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_COLUMN_MODEL
'*
'*   Modifications:
'************************************************************************'
'* Date       Author Mod. FTR No. Description                           *'
'* ---------- ------ ---- ------- ------------------------------------- *'
'*
'*
'* ---------- ------ ---- ------- ------------------------------------- *'
'************************************************************************'
#End Region

#Region "SYSTEM NAMESPACES"
Imports System.Data.Common
Imports System.Data.SQLite
#End Region

Namespace TableClass

  Partial Class clsTB_COLUMN_MODEL
    Inherits clsDataAccess
    
#Region "CLASS ENUM DECLARATION"

    Public Enum enmQueryIndicator
      ALL
      PRIMARY_KEY
      SELECT_VIEW_SRNO_CATEGORY '根据 View Srno 和类型来查询数据
    End Enum

#End Region

#Region "CLASS CUSTOMIZED QUERIES"

#Region "SELECT"

    ''' <summary>
    ''' 根据View Srno和类型来查询数据
    ''' </summary>
    ''' <param name="aObjDataTarget"></param>
    ''' <param name="aEnmReturnIndc"></param>
    ''' <remarks></remarks>
    Private Sub mPrSelectByViewSrnoCategory(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
              "Select " & _
              "  [CM_COLUMN_SRNO] " & _
              ", [CM_VIEW_SRNO] " & _
              ", [CM_COLUMN_NAME] " & _
              ", [CM_COLUMN_LANG_SRNO] " & _
              ", [CM_COLUMN_INDEX] " & _
              ", [CM_COLUMN_CATEGORY] " & _
              ", [CM_COLUMN_DATA_INDEX] " & _
              ", [CM_COLUMN_TYPE] " & _
              ", [CM_COLUMN_WIDTH] " & _
              ", [CM_COLUMN_ALIGN] " & _
              ", [CM_COLUMN_TOOLTIP] " & _
              ", [CM_COLUMN_CSS] " & _
              ", [CM_COLUMN_TPL] " & _
              ", [CM_COLUMN_SORTABLE] " & _
              ", [CM_COLUMN_RESIZABLE] " & _
              ", [CM_COLUMN_EDITABLE] " & _
              ", [CM_COLUMN_EDITOR] " & _
              ", [CM_COLUMN_RENDERER] " & _
              ", [CM_COLUMN_SCOPE] " & _
              ", [CM_CREATE_USER_SRNO] " & _
              ", [CM_CREATE_DATE_TIME] " & _
              ", [CM_UPDATE_USER_SRNO] " & _
              ", [CM_UPDATE_DATE_TIME] " & _
              "From [TB_COLUMN_MODEL] " & _
              "Where " & _
              " [CM_VIEW_SRNO] = " & mLngCM_VIEW_SRNO.ToString() & _
              " And [CM_COLUMN_CATEGORY] = " & mLngCM_COLUMN_CATEGORY.ToString() & _
              " Order By [CM_COLUMN_INDEX]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "INSERT"

#End Region

#Region "UPDATE"

#End Region

#Region "DELETE"

#End Region

#Region "TRANSACTION"
   
#End Region

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "RETRIEVE"

    Public Sub mPrRetrieveData _
                    (ByRef aObjDataReader As SQLiteDataReader _
                   , ByVal aenmQueryIndicator As enmQueryIndicator)

      Select Case (aenmQueryIndicator)
        Case enmQueryIndicator.ALL
          mPrSelectAll(aObjDataReader, enmReturnIndc.DATA_READER)
        Case enmQueryIndicator.PRIMARY_KEY
          mPrSelect(aObjDataReader, enmReturnIndc.DATA_READER)
        Case enmQueryIndicator.SELECT_VIEW_SRNO_CATEGORY
          mPrSelectByViewSrnoCategory(aObjDataReader, enmReturnIndc.DATA_READER)
        Case Else
      End Select

    End Sub

    Public Sub mPrRetrieveData _
                    (ByRef aObjDataSet As DataSet _
                   , ByVal aenmQueryIndicator As enmQueryIndicator)

      Select Case (aenmQueryIndicator)
        Case enmQueryIndicator.ALL
          mPrSelectAll(aObjDataSet, enmReturnIndc.DATA_SET)
        Case enmQueryIndicator.PRIMARY_KEY
          mPrSelect(aObjDataSet, enmReturnIndc.DATA_SET)
        Case enmQueryIndicator.SELECT_VIEW_SRNO_CATEGORY
          mPrSelectByViewSrnoCategory(aObjDataSet, enmReturnIndc.DATA_SET)
        Case Else
      End Select

    End Sub

#End Region

#Region "RETRIEVE NEXT RECORD"

    Public Function mFnRetrieveNextRecord _
                    (ByVal aObjDataReader As SQLiteDataReader _
                   , ByVal aenmQueryIndicator As enmQueryIndicator) As Boolean

      Dim lBlnRecordExists As Boolean = True

      If Not aObjDataReader.Read = True Then
        lBlnRecordExists = False
        aObjDataReader.Close()
      Else
        mPrPopulateData(aObjDataReader, aenmQueryIndicator)
      End If

      Return lBlnRecordExists
    End Function

#End Region

#Region "POPULATE DATA"

    Private Sub mPrPopulateData _
                    (ByVal aObjDataReader As SQLiteDataReader _
                   , ByVal aenmQueryIndicator As enmQueryIndicator)
      Select Case (aenmQueryIndicator)
        Case enmQueryIndicator.ALL
          mPrPopulateAll(aObjDataReader)
        Case enmQueryIndicator.PRIMARY_KEY
          mPrPopulateAll(aObjDataReader)
        Case enmQueryIndicator.SELECT_VIEW_SRNO_CATEGORY
          mPrPopulateAll(aObjDataReader)
        Case Else
      End Select
    End Sub

#End Region

#Region "CUSTOM POPULATE DATA"

#End Region

#End Region

  End Class

End Namespace
