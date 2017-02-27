
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2009/12/3 14:22:59
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_CODE_MASTER
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

  Partial Class clsTB_CODE_MASTER
    Inherits clsDataAccess
    
#Region "CLASS ENUM DECLARATION"

    Public Enum enmQueryIndicator
      ALL
      PRIMARY_KEY
      SELECT_DESC_CUSTOM_QUERY '根据CodeMaster Desc来查询数据
    End Enum

#End Region

#Region "CLASS CUSTOMIZED QUERIES"

#Region "SELECT"

    ''' <summary>
    ''' 根据CodeMaster Desc 和 CustomQuery 来查询数据
    ''' </summary>
    ''' <param name="aObjDataTarget"></param>
    ''' <param name="aEnmReturnIndc"></param>
    ''' <remarks></remarks>
    Private Sub mPrSelectByDescCustomQuery(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [CMS_CODE_SRNO] " & _
        ", [CMS_CODE_DESC] " & _
        ", [CMS_CODE_NAME] " & _
        ", [CMS_CODE_LABEL] " & _
        ", [CMS_CODE_LABEL_LANG_SRNO] " & _
        ", [CMS_CODE_CATEGORY] " & _
        ", [CMS_CODE_VALUE] " & _
        ", [CMS_CODE_VALUE_LANG_SRNO] " & _
        ", [CMS_CUSTOM_QUERY] " & _
        ", [CMS_CREATE_USER_SRNO] " & _
        ", [CMS_CREATE_DATE_TIME] " & _
        ", [CMS_UPDATE_USER_SRNO] " & _
        ", [CMS_UPDATE_DATE_TIME] " & _
        "From [TB_CODE_MASTER] " & _
        "Where " & _
        " [CMS_CODE_DESC] = '" & mStrCMS_CODE_DESC & "'" & _
        " And [CMS_CUSTOM_QUERY] like '" & mStrCMS_CUSTOM_QUERY & "'" & _
        " Order By [CMS_CODE_SRNO]"

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
        Case enmQueryIndicator.SELECT_DESC_CUSTOM_QUERY
          mPrSelectByDescCustomQuery(aObjDataReader, enmReturnIndc.DATA_READER)
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
        Case enmQueryIndicator.SELECT_DESC_CUSTOM_QUERY
          mPrSelectByDescCustomQuery(aObjDataSet, enmReturnIndc.DATA_SET)
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
        Case enmQueryIndicator.SELECT_DESC_CUSTOM_QUERY
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
