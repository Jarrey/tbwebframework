
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob@gmail.com
'*   Date         : 2010-1-24 22:56:09
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_COLUMN_DATA_READER
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

  Public Class clsTB_COLUMN_DATA_READER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngCDR_COLUMN_SRNO As Long
		Private mLngCDR_VIEW_SRNO As Long
		Private mStrCDR_DATA_INDEX_NAME As String
		Private mStrCDR_MAPPING As String
		Private mLngCDR_CREATE_USER_SRNO As Long
		Private mObjCDR_CREATE_DATE_TIME As Date
		Private mLngCDR_UPDATE_USER_SRNO As Long
		Private mObjCDR_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpCDR_COLUMN_SRNO() As Long
      Get
        Return mLngCDR_COLUMN_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCDR_COLUMN_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCDR_VIEW_SRNO() As Long
      Get
        Return mLngCDR_VIEW_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCDR_VIEW_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCDR_DATA_INDEX_NAME() As String
      Get
        Return mStrCDR_DATA_INDEX_NAME
      End Get
      Set(ByVal value As String)
        mStrCDR_DATA_INDEX_NAME = value
      End Set
    End Property
        
    Public Property mPrpCDR_MAPPING() As String
      Get
        Return mStrCDR_MAPPING
      End Get
      Set(ByVal value As String)
        mStrCDR_MAPPING = value
      End Set
    End Property
        
    Public Property mPrpCDR_CREATE_USER_SRNO() As Long
      Get
        Return mLngCDR_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCDR_CREATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCDR_CREATE_DATE_TIME() As Date
      Get
        Return mObjCDR_CREATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCDR_CREATE_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpCDR_UPDATE_USER_SRNO() As Long
      Get
        Return mLngCDR_UPDATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCDR_UPDATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCDR_UPDATE_DATE_TIME() As Date
      Get
        Return mObjCDR_UPDATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCDR_UPDATE_DATE_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngCDR_COLUMN_SRNO = 0
	  mLngCDR_VIEW_SRNO = 0
	  mStrCDR_DATA_INDEX_NAME = String.Empty
	  mStrCDR_MAPPING = String.Empty
	  mLngCDR_CREATE_USER_SRNO = 0
	  mObjCDR_CREATE_DATE_TIME = New Date
	  mLngCDR_UPDATE_USER_SRNO = 0
	  mObjCDR_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [CDR_COLUMN_SRNO] " & _
        ", [CDR_VIEW_SRNO] " & _
        ", [CDR_DATA_INDEX_NAME] " & _
        ", [CDR_MAPPING] " & _
        ", [CDR_CREATE_USER_SRNO] " & _
        ", [CDR_CREATE_DATE_TIME] " & _
        ", [CDR_UPDATE_USER_SRNO] " & _
        ", [CDR_UPDATE_DATE_TIME] " & _
        "From [TB_COLUMN_DATA_READER] " & _
        "Where " & _
        " [CDR_COLUMN_SRNO] = " & mLngCDR_COLUMN_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_COLUMN_DATA_READER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([CDR_COLUMN_SRNO]) From [TB_COLUMN_DATA_READER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_COLUMN_DATA_READER] (" & _
        "  [CDR_COLUMN_SRNO] " & _
        ", [CDR_VIEW_SRNO] " & _
        ", [CDR_DATA_INDEX_NAME] " & _
        ", [CDR_MAPPING] " & _
        ", [CDR_CREATE_USER_SRNO] " & _
        ", [CDR_CREATE_DATE_TIME] " & _
        ", [CDR_UPDATE_USER_SRNO] " & _
        ", [CDR_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngCDR_COLUMN_SRNO.ToString() & _
        ", " & mLngCDR_VIEW_SRNO.ToString() & _
        ", " & "'" & mStrCDR_DATA_INDEX_NAME & "'" & _
        ", " & "'" & mStrCDR_MAPPING & "'" & _
        ", " & mLngCDR_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCDR_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngCDR_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCDR_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_COLUMN_DATA_READER] Set " & _
        "  [CDR_COLUMN_SRNO] = " & mLngCDR_COLUMN_SRNO.ToString() & _
        ", CDR_VIEW_SRNO = " & mLngCDR_VIEW_SRNO.ToString() & _
        ", CDR_DATA_INDEX_NAME = " & "'" & mStrCDR_DATA_INDEX_NAME & "'" & _
        ", CDR_MAPPING = " & "'" & mStrCDR_MAPPING & "'" & _
        ", CDR_CREATE_USER_SRNO = " & mLngCDR_CREATE_USER_SRNO.ToString() & _
        ", CDR_CREATE_DATE_TIME = " & "'" & mObjCDR_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", CDR_UPDATE_USER_SRNO = " & mLngCDR_UPDATE_USER_SRNO.ToString() & _
        ", CDR_UPDATE_DATE_TIME = " & "'" & mObjCDR_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [CDR_COLUMN_SRNO] = " & mLngCDR_COLUMN_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_COLUMN_DATA_READER] " & _
        "Where " & _
        " [CDR_COLUMN_SRNO] = " & mLngCDR_COLUMN_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_COLUMN_DATA_READER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [CDR_COLUMN_SRNO] " & _
        ", [CDR_VIEW_SRNO] " & _
        ", [CDR_DATA_INDEX_NAME] " & _
        ", [CDR_MAPPING] " & _
        ", [CDR_CREATE_USER_SRNO] " & _
        ", [CDR_CREATE_DATE_TIME] " & _
        ", [CDR_UPDATE_USER_SRNO] " & _
        ", [CDR_UPDATE_DATE_TIME] " & _
        "From [TB_COLUMN_DATA_READER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngCDR_COLUMN_SRNO = mFnPopulate(aObjDataReader,"CDR_COLUMN_SRNO")
      mLngCDR_VIEW_SRNO = mFnPopulate(aObjDataReader,"CDR_VIEW_SRNO")
      mStrCDR_DATA_INDEX_NAME = mFnPopulate(aObjDataReader,"CDR_DATA_INDEX_NAME")
      mStrCDR_MAPPING = mFnPopulate(aObjDataReader,"CDR_MAPPING")
      mLngCDR_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"CDR_CREATE_USER_SRNO")
      mObjCDR_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"CDR_CREATE_DATE_TIME")
      mLngCDR_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"CDR_UPDATE_USER_SRNO")
      mObjCDR_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"CDR_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngCDR_COLUMN_SRNO = 0
	  mLngCDR_VIEW_SRNO = 0
	  mStrCDR_DATA_INDEX_NAME = String.Empty
	  mStrCDR_MAPPING = String.Empty
	  mLngCDR_CREATE_USER_SRNO = 0
	  mObjCDR_CREATE_DATE_TIME = New Date
	  mLngCDR_UPDATE_USER_SRNO = 0
	  mObjCDR_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_COLUMN_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_VIEW_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_DATA_INDEX_NAME", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_MAPPING", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CDR_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
