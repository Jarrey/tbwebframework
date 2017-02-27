
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/3 13:37:14
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_USER_LOGIN_DTLS
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

  Public Class clsTB_USER_LOGIN_DTLS
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngULD_USER_SRNO As Long
		Private mStrULD_USER_PSW As String
		Private mObjULD_LOGIN_TIME As Date
		Private mObjULD_LAST_LOGIN_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpULD_USER_SRNO() As Long
      Get
        Return mLngULD_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngULD_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpULD_USER_PSW() As String
      Get
        Return mStrULD_USER_PSW
      End Get
      Set(ByVal value As String)
        mStrULD_USER_PSW = value
      End Set
    End Property
        
    Public Property mPrpULD_LOGIN_TIME() As Date
      Get
        Return mObjULD_LOGIN_TIME
      End Get
      Set(ByVal value As Date)
        mObjULD_LOGIN_TIME = value
      End Set
    End Property
        
    Public Property mPrpULD_LAST_LOGIN_TIME() As Date
      Get
        Return mObjULD_LAST_LOGIN_TIME
      End Get
      Set(ByVal value As Date)
        mObjULD_LAST_LOGIN_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngULD_USER_SRNO = 0
	  mStrULD_USER_PSW = String.Empty
	  mObjULD_LOGIN_TIME = New Date
	  mObjULD_LAST_LOGIN_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [ULD_USER_SRNO] " & _
        ", [ULD_USER_PSW] " & _
        ", [ULD_LOGIN_TIME] " & _
        ", [ULD_LAST_LOGIN_TIME] " & _
        "From [TB_USER_LOGIN_DTLS] " & _
        "Where " & _
        " [ULD_USER_SRNO] = " & mLngULD_USER_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_USER_LOGIN_DTLS]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([ULD_USER_SRNO]) From [TB_USER_LOGIN_DTLS]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_USER_LOGIN_DTLS] (" & _
        "  [ULD_USER_SRNO] " & _
        ", [ULD_USER_PSW] " & _
        ", [ULD_LOGIN_TIME] " & _
        ", [ULD_LAST_LOGIN_TIME] " & _
        " ) Values ( " & _
         mLngULD_USER_SRNO.ToString() & _
        ", " & "'" & mStrULD_USER_PSW & "'" & _
        ", " & "'" & mObjULD_LOGIN_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & "'" & mObjULD_LAST_LOGIN_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_USER_LOGIN_DTLS] Set " & _
        "  [ULD_USER_SRNO] = " & mLngULD_USER_SRNO.ToString() & _
        ", ULD_USER_PSW = " & "'" & mStrULD_USER_PSW & "'" & _
        ", ULD_LOGIN_TIME = " & "'" & mObjULD_LOGIN_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", ULD_LAST_LOGIN_TIME = " & "'" & mObjULD_LAST_LOGIN_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [ULD_USER_SRNO] = " & mLngULD_USER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_USER_LOGIN_DTLS] " & _
        "Where " & _
        " [ULD_USER_SRNO] = " & mLngULD_USER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_USER_LOGIN_DTLS] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [ULD_USER_SRNO] " & _
        ", [ULD_USER_PSW] " & _
        ", [ULD_LOGIN_TIME] " & _
        ", [ULD_LAST_LOGIN_TIME] " & _
        "From [TB_USER_LOGIN_DTLS]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngULD_USER_SRNO = mFnPopulate(aObjDataReader,"ULD_USER_SRNO")
      mStrULD_USER_PSW = mFnPopulate(aObjDataReader,"ULD_USER_PSW")
      mObjULD_LOGIN_TIME = mFnPopulate(aObjDataReader,"ULD_LOGIN_TIME")
      mObjULD_LAST_LOGIN_TIME = mFnPopulate(aObjDataReader,"ULD_LAST_LOGIN_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngULD_USER_SRNO = 0
	  mStrULD_USER_PSW = String.Empty
	  mObjULD_LOGIN_TIME = New Date
	  mObjULD_LAST_LOGIN_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("ULD_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("ULD_USER_PSW", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("ULD_LOGIN_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("ULD_LAST_LOGIN_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
