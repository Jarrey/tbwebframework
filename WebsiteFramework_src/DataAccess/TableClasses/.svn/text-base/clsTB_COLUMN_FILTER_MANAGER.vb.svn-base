
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/3 13:37:14
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_COLUMN_FILTER_MANAGER
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

  Public Class clsTB_COLUMN_FILTER_MANAGER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngCFM_FILTER_SRNO As Long
		Private mLngCFM_VIEW_SRNO As Long
		Private mLngCFM_COLUMN_INDEX As Long
		Private mStrCFM_FILTER_TYPE As String
		Private mStrCFM_FILTER_DATA_INDEX As String
		Private mLngCFM_FILTER_DISABLED As Long
		Private mStrCFM_FILTER_CODE_DESC As String
		Private mStrCFM_FILTER_CODE_QUERY As String
		Private mLngCFM_CREATE_USER_SRNO As Long
		Private mObjCFM_CREATE_DATE_TIME As Date
		Private mLngCFM_UPDATE_USER_SRNO As Long
		Private mObjCFM_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpCFM_FILTER_SRNO() As Long
      Get
        Return mLngCFM_FILTER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCFM_FILTER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCFM_VIEW_SRNO() As Long
      Get
        Return mLngCFM_VIEW_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCFM_VIEW_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCFM_COLUMN_INDEX() As Long
      Get
        Return mLngCFM_COLUMN_INDEX
      End Get
      Set(ByVal value As Long)
        mLngCFM_COLUMN_INDEX = value
      End Set
    End Property
        
    Public Property mPrpCFM_FILTER_TYPE() As String
      Get
        Return mStrCFM_FILTER_TYPE
      End Get
      Set(ByVal value As String)
        mStrCFM_FILTER_TYPE = value
      End Set
    End Property
        
    Public Property mPrpCFM_FILTER_DATA_INDEX() As String
      Get
        Return mStrCFM_FILTER_DATA_INDEX
      End Get
      Set(ByVal value As String)
        mStrCFM_FILTER_DATA_INDEX = value
      End Set
    End Property
        
    Public Property mPrpCFM_FILTER_DISABLED() As Long
      Get
        Return mLngCFM_FILTER_DISABLED
      End Get
      Set(ByVal value As Long)
        mLngCFM_FILTER_DISABLED = value
      End Set
    End Property
        
    Public Property mPrpCFM_FILTER_CODE_DESC() As String
      Get
        Return mStrCFM_FILTER_CODE_DESC
      End Get
      Set(ByVal value As String)
        mStrCFM_FILTER_CODE_DESC = value
      End Set
    End Property
        
    Public Property mPrpCFM_FILTER_CODE_QUERY() As String
      Get
        Return mStrCFM_FILTER_CODE_QUERY
      End Get
      Set(ByVal value As String)
        mStrCFM_FILTER_CODE_QUERY = value
      End Set
    End Property
        
    Public Property mPrpCFM_CREATE_USER_SRNO() As Long
      Get
        Return mLngCFM_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCFM_CREATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCFM_CREATE_DATE_TIME() As Date
      Get
        Return mObjCFM_CREATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCFM_CREATE_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpCFM_UPDATE_USER_SRNO() As Long
      Get
        Return mLngCFM_UPDATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCFM_UPDATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCFM_UPDATE_DATE_TIME() As Date
      Get
        Return mObjCFM_UPDATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCFM_UPDATE_DATE_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngCFM_FILTER_SRNO = 0
	  mLngCFM_VIEW_SRNO = 0
	  mLngCFM_COLUMN_INDEX = 0
	  mStrCFM_FILTER_TYPE = String.Empty
	  mStrCFM_FILTER_DATA_INDEX = String.Empty
	  mLngCFM_FILTER_DISABLED = 0
	  mStrCFM_FILTER_CODE_DESC = String.Empty
	  mStrCFM_FILTER_CODE_QUERY = String.Empty
	  mLngCFM_CREATE_USER_SRNO = 0
	  mObjCFM_CREATE_DATE_TIME = New Date
	  mLngCFM_UPDATE_USER_SRNO = 0
	  mObjCFM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [CFM_FILTER_SRNO] " & _
        ", [CFM_VIEW_SRNO] " & _
        ", [CFM_COLUMN_INDEX] " & _
        ", [CFM_FILTER_TYPE] " & _
        ", [CFM_FILTER_DATA_INDEX] " & _
        ", [CFM_FILTER_DISABLED] " & _
        ", [CFM_FILTER_CODE_DESC] " & _
        ", [CFM_FILTER_CODE_QUERY] " & _
        ", [CFM_CREATE_USER_SRNO] " & _
        ", [CFM_CREATE_DATE_TIME] " & _
        ", [CFM_UPDATE_USER_SRNO] " & _
        ", [CFM_UPDATE_DATE_TIME] " & _
        "From [TB_COLUMN_FILTER_MANAGER] " & _
        "Where " & _
        " [CFM_FILTER_SRNO] = " & mLngCFM_FILTER_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_COLUMN_FILTER_MANAGER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([CFM_FILTER_SRNO]) From [TB_COLUMN_FILTER_MANAGER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_COLUMN_FILTER_MANAGER] (" & _
        "  [CFM_FILTER_SRNO] " & _
        ", [CFM_VIEW_SRNO] " & _
        ", [CFM_COLUMN_INDEX] " & _
        ", [CFM_FILTER_TYPE] " & _
        ", [CFM_FILTER_DATA_INDEX] " & _
        ", [CFM_FILTER_DISABLED] " & _
        ", [CFM_FILTER_CODE_DESC] " & _
        ", [CFM_FILTER_CODE_QUERY] " & _
        ", [CFM_CREATE_USER_SRNO] " & _
        ", [CFM_CREATE_DATE_TIME] " & _
        ", [CFM_UPDATE_USER_SRNO] " & _
        ", [CFM_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngCFM_FILTER_SRNO.ToString() & _
        ", " & mLngCFM_VIEW_SRNO.ToString() & _
        ", " & mLngCFM_COLUMN_INDEX.ToString() & _
        ", " & "'" & mStrCFM_FILTER_TYPE & "'" & _
        ", " & "'" & mStrCFM_FILTER_DATA_INDEX & "'" & _
        ", " & mLngCFM_FILTER_DISABLED.ToString() & _
        ", " & "'" & mStrCFM_FILTER_CODE_DESC & "'" & _
        ", " & "'" & mStrCFM_FILTER_CODE_QUERY & "'" & _
        ", " & mLngCFM_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCFM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngCFM_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCFM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_COLUMN_FILTER_MANAGER] Set " & _
        "  [CFM_FILTER_SRNO] = " & mLngCFM_FILTER_SRNO.ToString() & _
        ", CFM_VIEW_SRNO = " & mLngCFM_VIEW_SRNO.ToString() & _
        ", CFM_COLUMN_INDEX = " & mLngCFM_COLUMN_INDEX.ToString() & _
        ", CFM_FILTER_TYPE = " & "'" & mStrCFM_FILTER_TYPE & "'" & _
        ", CFM_FILTER_DATA_INDEX = " & "'" & mStrCFM_FILTER_DATA_INDEX & "'" & _
        ", CFM_FILTER_DISABLED = " & mLngCFM_FILTER_DISABLED.ToString() & _
        ", CFM_FILTER_CODE_DESC = " & "'" & mStrCFM_FILTER_CODE_DESC & "'" & _
        ", CFM_FILTER_CODE_QUERY = " & "'" & mStrCFM_FILTER_CODE_QUERY & "'" & _
        ", CFM_CREATE_USER_SRNO = " & mLngCFM_CREATE_USER_SRNO.ToString() & _
        ", CFM_CREATE_DATE_TIME = " & "'" & mObjCFM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", CFM_UPDATE_USER_SRNO = " & mLngCFM_UPDATE_USER_SRNO.ToString() & _
        ", CFM_UPDATE_DATE_TIME = " & "'" & mObjCFM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [CFM_FILTER_SRNO] = " & mLngCFM_FILTER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_COLUMN_FILTER_MANAGER] " & _
        "Where " & _
        " [CFM_FILTER_SRNO] = " & mLngCFM_FILTER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_COLUMN_FILTER_MANAGER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [CFM_FILTER_SRNO] " & _
        ", [CFM_VIEW_SRNO] " & _
        ", [CFM_COLUMN_INDEX] " & _
        ", [CFM_FILTER_TYPE] " & _
        ", [CFM_FILTER_DATA_INDEX] " & _
        ", [CFM_FILTER_DISABLED] " & _
        ", [CFM_FILTER_CODE_DESC] " & _
        ", [CFM_FILTER_CODE_QUERY] " & _
        ", [CFM_CREATE_USER_SRNO] " & _
        ", [CFM_CREATE_DATE_TIME] " & _
        ", [CFM_UPDATE_USER_SRNO] " & _
        ", [CFM_UPDATE_DATE_TIME] " & _
        "From [TB_COLUMN_FILTER_MANAGER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngCFM_FILTER_SRNO = mFnPopulate(aObjDataReader,"CFM_FILTER_SRNO")
      mLngCFM_VIEW_SRNO = mFnPopulate(aObjDataReader,"CFM_VIEW_SRNO")
      mLngCFM_COLUMN_INDEX = mFnPopulate(aObjDataReader,"CFM_COLUMN_INDEX")
      mStrCFM_FILTER_TYPE = mFnPopulate(aObjDataReader,"CFM_FILTER_TYPE")
      mStrCFM_FILTER_DATA_INDEX = mFnPopulate(aObjDataReader,"CFM_FILTER_DATA_INDEX")
      mLngCFM_FILTER_DISABLED = mFnPopulate(aObjDataReader,"CFM_FILTER_DISABLED")
      mStrCFM_FILTER_CODE_DESC = mFnPopulate(aObjDataReader,"CFM_FILTER_CODE_DESC")
      mStrCFM_FILTER_CODE_QUERY = mFnPopulate(aObjDataReader,"CFM_FILTER_CODE_QUERY")
      mLngCFM_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"CFM_CREATE_USER_SRNO")
      mObjCFM_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"CFM_CREATE_DATE_TIME")
      mLngCFM_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"CFM_UPDATE_USER_SRNO")
      mObjCFM_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"CFM_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngCFM_FILTER_SRNO = 0
	  mLngCFM_VIEW_SRNO = 0
	  mLngCFM_COLUMN_INDEX = 0
	  mStrCFM_FILTER_TYPE = String.Empty
	  mStrCFM_FILTER_DATA_INDEX = String.Empty
	  mLngCFM_FILTER_DISABLED = 0
	  mStrCFM_FILTER_CODE_DESC = String.Empty
	  mStrCFM_FILTER_CODE_QUERY = String.Empty
	  mLngCFM_CREATE_USER_SRNO = 0
	  mObjCFM_CREATE_DATE_TIME = New Date
	  mLngCFM_UPDATE_USER_SRNO = 0
	  mObjCFM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_FILTER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_VIEW_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_COLUMN_INDEX", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_FILTER_TYPE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_FILTER_DATA_INDEX", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_FILTER_DISABLED", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_FILTER_CODE_DESC", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_FILTER_CODE_QUERY", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CFM_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
