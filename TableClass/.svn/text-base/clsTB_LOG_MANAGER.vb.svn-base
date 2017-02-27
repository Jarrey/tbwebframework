
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/3 13:37:14
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

  Public Class clsTB_LOG_MANAGER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngLM_LOG_FILE_SRNO As Long
		Private mObjLM_DATE_TIME As Date
		Private mLngLM_CATEGORY As Long
		Private mLngLM_LEVEL As Long
		Private mStrLM_LOG_FILE_NAME As String
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpLM_LOG_FILE_SRNO() As Long
      Get
        Return mLngLM_LOG_FILE_SRNO
      End Get
      Set(ByVal value As Long)
        mLngLM_LOG_FILE_SRNO = value
      End Set
    End Property
        
    Public Property mPrpLM_DATE_TIME() As Date
      Get
        Return mObjLM_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjLM_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpLM_CATEGORY() As Long
      Get
        Return mLngLM_CATEGORY
      End Get
      Set(ByVal value As Long)
        mLngLM_CATEGORY = value
      End Set
    End Property
        
    Public Property mPrpLM_LEVEL() As Long
      Get
        Return mLngLM_LEVEL
      End Get
      Set(ByVal value As Long)
        mLngLM_LEVEL = value
      End Set
    End Property
        
    Public Property mPrpLM_LOG_FILE_NAME() As String
      Get
        Return mStrLM_LOG_FILE_NAME
      End Get
      Set(ByVal value As String)
        mStrLM_LOG_FILE_NAME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngLM_LOG_FILE_SRNO = 0
	  mObjLM_DATE_TIME = New Date
	  mLngLM_CATEGORY = 0
	  mLngLM_LEVEL = 0
	  mStrLM_LOG_FILE_NAME = String.Empty
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

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
        " [LM_LOG_FILE_SRNO] = " & mLngLM_LOG_FILE_SRNO.ToString() & _
        ""

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "COUNT RECORDS"

		Public Function mFnCount() As Integer
      Dim lStrSQLString As String
      
      lStrSQLString = _
      	"Select Count(*) From [TB_LOG_MANAGER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([LM_LOG_FILE_SRNO]) From [TB_LOG_MANAGER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_LOG_MANAGER] (" & _
        "  [LM_LOG_FILE_SRNO] " & _
        ", [LM_DATE_TIME] " & _
        ", [LM_CATEGORY] " & _
        ", [LM_LEVEL] " & _
        ", [LM_LOG_FILE_NAME] " & _
        " ) Values ( " & _
         mLngLM_LOG_FILE_SRNO.ToString() & _
        ", " & "'" & mObjLM_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngLM_CATEGORY.ToString() & _
        ", " & mLngLM_LEVEL.ToString() & _
        ", " & "'" & mStrLM_LOG_FILE_NAME & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_LOG_MANAGER] Set " & _
        "  [LM_LOG_FILE_SRNO] = " & mLngLM_LOG_FILE_SRNO.ToString() & _
        ", LM_DATE_TIME = " & "'" & mObjLM_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", LM_CATEGORY = " & mLngLM_CATEGORY.ToString() & _
        ", LM_LEVEL = " & mLngLM_LEVEL.ToString() & _
        ", LM_LOG_FILE_NAME = " & "'" & mStrLM_LOG_FILE_NAME & "'" & _
        " Where " & _
        " [LM_LOG_FILE_SRNO] = " & mLngLM_LOG_FILE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_LOG_MANAGER] " & _
        "Where " & _
        " [LM_LOG_FILE_SRNO] = " & mLngLM_LOG_FILE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_LOG_MANAGER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [LM_LOG_FILE_SRNO] " & _
        ", [LM_DATE_TIME] " & _
        ", [LM_CATEGORY] " & _
        ", [LM_LEVEL] " & _
        ", [LM_LOG_FILE_NAME] " & _
        "From [TB_LOG_MANAGER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngLM_LOG_FILE_SRNO = mFnPopulate(aObjDataReader,"LM_LOG_FILE_SRNO")
      mObjLM_DATE_TIME = mFnPopulate(aObjDataReader,"LM_DATE_TIME")
      mLngLM_CATEGORY = mFnPopulate(aObjDataReader,"LM_CATEGORY")
      mLngLM_LEVEL = mFnPopulate(aObjDataReader,"LM_LEVEL")
      mStrLM_LOG_FILE_NAME = mFnPopulate(aObjDataReader,"LM_LOG_FILE_NAME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngLM_LOG_FILE_SRNO = 0
	  mObjLM_DATE_TIME = New Date
	  mLngLM_CATEGORY = 0
	  mLngLM_LEVEL = 0
	  mStrLM_LOG_FILE_NAME = String.Empty
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("LM_LOG_FILE_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("LM_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("LM_CATEGORY", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("LM_LEVEL", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("LM_LOG_FILE_NAME", GetType(String)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
