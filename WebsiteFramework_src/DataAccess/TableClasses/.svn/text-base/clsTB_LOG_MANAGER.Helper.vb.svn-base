
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2009/11/19 17:25:32
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_LOG_MANAGER
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

  Partial Class clsTB_LOG_MANAGER
    Inherits clsDataAccess
    
#Region "CLASS ENUM DECLARATION"

    Public Enum enmQueryIndicator
      ALL
      PRIMARY_KEY
      SELECT_DATE_CATEGORY '根据时间类型查询数据
    End Enum

#End Region

#Region "MEMBER VARIABLES"
    Private mObjFromDate As New Date
    Private mObjToDate As New Date
#End Region

#Region "MEMBER PROPERTIES"
    Property mPrpFromDate() As Date
      Get
        Return mObjFromDate
      End Get
      Set(ByVal value As Date)
        mObjFromDate = value
      End Set
    End Property

    Property mPrpToDate() As Date
      Get
        Return mObjToDate
      End Get
      Set(ByVal value As Date)
        mObjToDate = value
      End Set
    End Property
#End Region

#Region "CLASS CUSTOMIZED QUERIES"

#Region "SELECT"

    ''' <summary>
    ''' 查询符合日期条件的日志数据
    ''' </summary>
    ''' <param name="aObjDataTarget"></param>
    ''' <param name="aEnmReturnIndc"></param>
    ''' <remarks></remarks>
    Private Sub mPrSelectByDateCategory(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [LM_LOG_FILE_SRNO] " & _
        ", [LM_DATE_TIME] " & _
        ", [LM_CATEGORY] " & _
        ", [LM_LEVEL] " & _
        ", [LM_LOG_FILE_NAME] " & _
        "From [TB_LOG_MANAGER] " & _
        "Where " & _
        " [LM_DATE_TIME] >= '" & mObjFromDate.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " And [LM_DATE_TIME] < '" & mObjToDate.AddDays(1).ToString(CONST_DATE_TIME_FORMAT) & "'"
      If mLngLM_CATEGORY <> 0 Then '类型为0为查询全部,不加条件限制
        lStrSQLString = lStrSQLString & _
                        " And [LM_CATEGORY] = " & mLngLM_CATEGORY.ToString()
      End If
      lStrSQLString = lStrSQLString & " Order By [LM_LOG_FILE_SRNO]"

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
        Case enmQueryIndicator.SELECT_DATE_CATEGORY
          mPrSelectByDateCategory(aObjDataReader, enmReturnIndc.DATA_READER)
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
        Case enmQueryIndicator.SELECT_DATE_CATEGORY
          mPrSelectByDateCategory(aObjDataSet, enmReturnIndc.DATA_READER)
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
        Case enmQueryIndicator.SELECT_DATE_CATEGORY
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
