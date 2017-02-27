
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/1/15 10:00:56
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_EXCEPTION_MANAGER
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

  Public Class clsTB_EXCEPTION_MANAGER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngEM_EXCEPTION_SRNO As Long
		Private mObjEM_DATE_TIME As Date
		Private mStrEM_TITLE As String
		Private mStrEM_CONTEXT As String
		Private mLngEM_STATUS As Long
		Private mLngEM_UPDATE_USER_SRNO As Long
		Private mObjEM_UPDATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

        Public Property mPrpEM_EXCEPTION_SRNO() As Long
            Get
                Return mLngEM_EXCEPTION_SRNO
            End Get
            Set(ByVal value As Long)
                mLngEM_EXCEPTION_SRNO = value
            End Set
        End Property
        
        Public Property mPrpEM_DATE_TIME() As Date
            Get
                Return mObjEM_DATE_TIME
            End Get
            Set(ByVal value As Date)
                mObjEM_DATE_TIME = value
            End Set
        End Property
        
        Public Property mPrpEM_TITLE() As String
            Get
                Return mStrEM_TITLE
            End Get
            Set(ByVal value As String)
                mStrEM_TITLE = value
            End Set
        End Property
        
        Public Property mPrpEM_CONTEXT() As String
            Get
                Return mStrEM_CONTEXT
            End Get
            Set(ByVal value As String)
                mStrEM_CONTEXT = value
            End Set
        End Property
        
        Public Property mPrpEM_STATUS() As Long
            Get
                Return mLngEM_STATUS
            End Get
            Set(ByVal value As Long)
                mLngEM_STATUS = value
            End Set
        End Property
        
        Public Property mPrpEM_UPDATE_USER_SRNO() As Long
            Get
                Return mLngEM_UPDATE_USER_SRNO
            End Get
            Set(ByVal value As Long)
                mLngEM_UPDATE_USER_SRNO = value
            End Set
        End Property
        
        Public Property mPrpEM_UPDATE_TIME() As Date
            Get
                Return mObjEM_UPDATE_TIME
            End Get
            Set(ByVal value As Date)
                mObjEM_UPDATE_TIME = value
            End Set
        End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngEM_EXCEPTION_SRNO = 0
	  mObjEM_DATE_TIME = New Date
	  mStrEM_TITLE = String.Empty
	  mStrEM_CONTEXT = String.Empty
	  mLngEM_STATUS = 0
	  mLngEM_UPDATE_USER_SRNO = 0
	  mObjEM_UPDATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [EM_EXCEPTION_SRNO] " & _
        ", [EM_DATE_TIME] " & _
        ", [EM_TITLE] " & _
        ", [EM_CONTEXT] " & _
        ", [EM_STATUS] " & _
        ", [EM_UPDATE_USER_SRNO] " & _
        ", [EM_UPDATE_TIME] " & _
        "From [TB_EXCEPTION_MANAGER] " & _
        "Where " & _
        " [EM_EXCEPTION_SRNO] = " & mLngEM_EXCEPTION_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_EXCEPTION_MANAGER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([EM_EXCEPTION_SRNO]) From [TB_EXCEPTION_MANAGER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_EXCEPTION_MANAGER] (" & _
        "  [EM_EXCEPTION_SRNO] " & _
        ", [EM_DATE_TIME] " & _
        ", [EM_TITLE] " & _
        ", [EM_CONTEXT] " & _
        ", [EM_STATUS] " & _
        ", [EM_UPDATE_USER_SRNO] " & _
        ", [EM_UPDATE_TIME] " & _
        " ) Values ( " & _
         mLngEM_EXCEPTION_SRNO.ToString() & _
        ", " & "'" & mObjEM_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & "'" & mStrEM_TITLE & "'" & _
        ", " & "'" & mStrEM_CONTEXT & "'" & _
        ", " & mLngEM_STATUS.ToString() & _
        ", " & mLngEM_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjEM_UPDATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_EXCEPTION_MANAGER] Set " & _
        "  [EM_EXCEPTION_SRNO] = " & mLngEM_EXCEPTION_SRNO.ToString() & _
        ", EM_DATE_TIME = " & "'" & mObjEM_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", EM_TITLE = " & "'" & mStrEM_TITLE & "'" & _
        ", EM_CONTEXT = " & "'" & mStrEM_CONTEXT & "'" & _
        ", EM_STATUS = " & mLngEM_STATUS.ToString() & _
        ", EM_UPDATE_USER_SRNO = " & mLngEM_UPDATE_USER_SRNO.ToString() & _
        ", EM_UPDATE_TIME = " & "'" & mObjEM_UPDATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [EM_EXCEPTION_SRNO] = " & mLngEM_EXCEPTION_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_EXCEPTION_MANAGER] " & _
        "Where " & _
        " [EM_EXCEPTION_SRNO] = " & mLngEM_EXCEPTION_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_EXCEPTION_MANAGER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [EM_EXCEPTION_SRNO] " & _
        ", [EM_DATE_TIME] " & _
        ", [EM_TITLE] " & _
        ", [EM_CONTEXT] " & _
        ", [EM_STATUS] " & _
        ", [EM_UPDATE_USER_SRNO] " & _
        ", [EM_UPDATE_TIME] " & _
        "From [TB_EXCEPTION_MANAGER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
        mLngEM_EXCEPTION_SRNO = mFnPopulate(aObjDataReader,"EM_EXCEPTION_SRNO")
        mObjEM_DATE_TIME = mFnPopulate(aObjDataReader,"EM_DATE_TIME")
        mStrEM_TITLE = mFnPopulate(aObjDataReader,"EM_TITLE")
        mStrEM_CONTEXT = mFnPopulate(aObjDataReader,"EM_CONTEXT")
        mLngEM_STATUS = mFnPopulate(aObjDataReader,"EM_STATUS")
        mLngEM_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"EM_UPDATE_USER_SRNO")
        mObjEM_UPDATE_TIME = mFnPopulate(aObjDataReader,"EM_UPDATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngEM_EXCEPTION_SRNO = 0
	  mObjEM_DATE_TIME = New Date
	  mStrEM_TITLE = String.Empty
	  mStrEM_CONTEXT = String.Empty
	  mLngEM_STATUS = 0
	  mLngEM_UPDATE_USER_SRNO = 0
	  mObjEM_UPDATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("EM_EXCEPTION_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("EM_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("EM_TITLE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("EM_CONTEXT", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("EM_STATUS", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("EM_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("EM_UPDATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
