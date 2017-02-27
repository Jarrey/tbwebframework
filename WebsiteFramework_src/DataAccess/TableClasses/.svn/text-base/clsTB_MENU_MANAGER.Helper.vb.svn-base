
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2009/11/19 17:42:56
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_MENU_MANAGER
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

  Partial Class clsTB_MENU_MANAGER
    Inherits clsDataAccess

#Region "CLASS ENUM DECLARATION"

    Public Enum enmQueryIndicator
      ALL
      PRIMARY_KEY
      SELECT_CATEGORY '查询符合类型条件的菜单项
    End Enum

#End Region

#Region "CLASS CUSTOMIZED QUERIES"

#Region "SELECT"

    ''' <summary>
    ''' 查询符合类型条件的菜单项
    ''' </summary>
    ''' <param name="aObjDataTarget"></param>
    ''' <param name="aEnmReturnIndc"></param>
    ''' <remarks></remarks>
    Private Sub mPrSelectByCategoryLevel(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [MM_MENU_SRNO] " & _
        ", [MM_MENU_DISPLAY_INDEX] " & _
        ", [MM_MENU_DESC] " & _
        ", [MM_MENU_LANG_SRNO] " & _
        ", [MM_PARENT_SRNO] " & _
        ", [MM_IS_LEAF] " & _
        ", [MM_MENU_CATEGORY] " & _
        ", [MM_URL] " & _
        ", [MM_TARGET] " & _
        ", [MM_CREATE_USER_SRNO] " & _
        ", [MM_CREATE_DATE_TIME] " & _
        ", [MM_UPDATE_USER_SRNO] " & _
        ", [MM_UPDATE_DATE_TIME] " & _
        "From [TB_MENU_MANAGER] " & _
        "Where " & _
        " [MM_MENU_CATEGORY] = " & mLngMM_MENU_CATEGORY.ToString() & _
        " ORDER BY [MM_MENU_DISPLAY_INDEX], [MM_MENU_SRNO]"

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
        Case enmQueryIndicator.SELECT_CATEGORY
          mPrSelectByCategoryLevel(aObjDataReader, enmReturnIndc.DATA_READER)
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
        Case enmQueryIndicator.SELECT_CATEGORY
          mPrSelectByCategoryLevel(aObjDataSet, enmReturnIndc.DATA_SET)
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
        Case enmQueryIndicator.SELECT_CATEGORY
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
