
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/3 13:37:14
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_SYSTEM_MESSAGE
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

  Public Class clsTB_SYSTEM_MESSAGE
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngSM_SYSTEM_MESSAGE_SRNO As Long
		Private mObjSM_MESSAGE_TIME As Date
		Private mLngSM_MESSAGE_TYPE As Long
		Private mStrSM_SYSTEM_MESSAGE As String
		Private mLngSM_MESSAGE_LEVEL As Long
		Private mLngSM_CREATE_USER_SRNO As Long
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpSM_SYSTEM_MESSAGE_SRNO() As Long
      Get
        Return mLngSM_SYSTEM_MESSAGE_SRNO
      End Get
      Set(ByVal value As Long)
        mLngSM_SYSTEM_MESSAGE_SRNO = value
      End Set
    End Property
        
    Public Property mPrpSM_MESSAGE_TIME() As Date
      Get
        Return mObjSM_MESSAGE_TIME
      End Get
      Set(ByVal value As Date)
        mObjSM_MESSAGE_TIME = value
      End Set
    End Property
        
    Public Property mPrpSM_MESSAGE_TYPE() As Long
      Get
        Return mLngSM_MESSAGE_TYPE
      End Get
      Set(ByVal value As Long)
        mLngSM_MESSAGE_TYPE = value
      End Set
    End Property
        
    Public Property mPrpSM_SYSTEM_MESSAGE() As String
      Get
        Return mStrSM_SYSTEM_MESSAGE
      End Get
      Set(ByVal value As String)
        mStrSM_SYSTEM_MESSAGE = value
      End Set
    End Property
        
    Public Property mPrpSM_MESSAGE_LEVEL() As Long
      Get
        Return mLngSM_MESSAGE_LEVEL
      End Get
      Set(ByVal value As Long)
        mLngSM_MESSAGE_LEVEL = value
      End Set
    End Property
        
    Public Property mPrpSM_CREATE_USER_SRNO() As Long
      Get
        Return mLngSM_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngSM_CREATE_USER_SRNO = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngSM_SYSTEM_MESSAGE_SRNO = 0
	  mObjSM_MESSAGE_TIME = New Date
	  mLngSM_MESSAGE_TYPE = 0
	  mStrSM_SYSTEM_MESSAGE = String.Empty
	  mLngSM_MESSAGE_LEVEL = 0
	  mLngSM_CREATE_USER_SRNO = 0
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [SM_SYSTEM_MESSAGE_SRNO] " & _
        ", [SM_MESSAGE_TIME] " & _
        ", [SM_MESSAGE_TYPE] " & _
        ", [SM_SYSTEM_MESSAGE] " & _
        ", [SM_MESSAGE_LEVEL] " & _
        ", [SM_CREATE_USER_SRNO] " & _
        "From [TB_SYSTEM_MESSAGE] " & _
        "Where " & _
        " [SM_SYSTEM_MESSAGE_SRNO] = " & mLngSM_SYSTEM_MESSAGE_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_SYSTEM_MESSAGE]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([SM_SYSTEM_MESSAGE_SRNO]) From [TB_SYSTEM_MESSAGE]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_SYSTEM_MESSAGE] (" & _
        "  [SM_SYSTEM_MESSAGE_SRNO] " & _
        ", [SM_MESSAGE_TIME] " & _
        ", [SM_MESSAGE_TYPE] " & _
        ", [SM_SYSTEM_MESSAGE] " & _
        ", [SM_MESSAGE_LEVEL] " & _
        ", [SM_CREATE_USER_SRNO] " & _
        " ) Values ( " & _
         mLngSM_SYSTEM_MESSAGE_SRNO.ToString() & _
        ", " & "'" & mObjSM_MESSAGE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngSM_MESSAGE_TYPE.ToString() & _
        ", " & "'" & mStrSM_SYSTEM_MESSAGE & "'" & _
        ", " & mLngSM_MESSAGE_LEVEL.ToString() & _
        ", " & mLngSM_CREATE_USER_SRNO.ToString() & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_SYSTEM_MESSAGE] Set " & _
        "  [SM_SYSTEM_MESSAGE_SRNO] = " & mLngSM_SYSTEM_MESSAGE_SRNO.ToString() & _
        ", SM_MESSAGE_TIME = " & "'" & mObjSM_MESSAGE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", SM_MESSAGE_TYPE = " & mLngSM_MESSAGE_TYPE.ToString() & _
        ", SM_SYSTEM_MESSAGE = " & "'" & mStrSM_SYSTEM_MESSAGE & "'" & _
        ", SM_MESSAGE_LEVEL = " & mLngSM_MESSAGE_LEVEL.ToString() & _
        ", SM_CREATE_USER_SRNO = " & mLngSM_CREATE_USER_SRNO.ToString() & _
        " Where " & _
        " [SM_SYSTEM_MESSAGE_SRNO] = " & mLngSM_SYSTEM_MESSAGE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_SYSTEM_MESSAGE] " & _
        "Where " & _
        " [SM_SYSTEM_MESSAGE_SRNO] = " & mLngSM_SYSTEM_MESSAGE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_SYSTEM_MESSAGE] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [SM_SYSTEM_MESSAGE_SRNO] " & _
        ", [SM_MESSAGE_TIME] " & _
        ", [SM_MESSAGE_TYPE] " & _
        ", [SM_SYSTEM_MESSAGE] " & _
        ", [SM_MESSAGE_LEVEL] " & _
        ", [SM_CREATE_USER_SRNO] " & _
        "From [TB_SYSTEM_MESSAGE]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngSM_SYSTEM_MESSAGE_SRNO = mFnPopulate(aObjDataReader,"SM_SYSTEM_MESSAGE_SRNO")
      mObjSM_MESSAGE_TIME = mFnPopulate(aObjDataReader,"SM_MESSAGE_TIME")
      mLngSM_MESSAGE_TYPE = mFnPopulate(aObjDataReader,"SM_MESSAGE_TYPE")
      mStrSM_SYSTEM_MESSAGE = mFnPopulate(aObjDataReader,"SM_SYSTEM_MESSAGE")
      mLngSM_MESSAGE_LEVEL = mFnPopulate(aObjDataReader,"SM_MESSAGE_LEVEL")
      mLngSM_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"SM_CREATE_USER_SRNO")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngSM_SYSTEM_MESSAGE_SRNO = 0
	  mObjSM_MESSAGE_TIME = New Date
	  mLngSM_MESSAGE_TYPE = 0
	  mStrSM_SYSTEM_MESSAGE = String.Empty
	  mLngSM_MESSAGE_LEVEL = 0
	  mLngSM_CREATE_USER_SRNO = 0
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("SM_SYSTEM_MESSAGE_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("SM_MESSAGE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("SM_MESSAGE_TYPE", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("SM_SYSTEM_MESSAGE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("SM_MESSAGE_LEVEL", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("SM_CREATE_USER_SRNO", GetType(Long)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
