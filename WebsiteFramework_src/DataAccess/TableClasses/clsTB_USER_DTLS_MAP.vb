
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/1/15 10:00:56
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_USER_DTLS_MAP
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

  Public Class clsTB_USER_DTLS_MAP
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngUDM_USER_SRNO As Long
		Private mLngUDM_UCD_ITEM_SRNO As Long
		Private mStrUDM_CONTEXT As String
   
#End Region

#Region "CLASS PROPERTIES"

        Public Property mPrpUDM_USER_SRNO() As Long
            Get
                Return mLngUDM_USER_SRNO
            End Get
            Set(ByVal value As Long)
                mLngUDM_USER_SRNO = value
            End Set
        End Property
        
        Public Property mPrpUDM_UCD_ITEM_SRNO() As Long
            Get
                Return mLngUDM_UCD_ITEM_SRNO
            End Get
            Set(ByVal value As Long)
                mLngUDM_UCD_ITEM_SRNO = value
            End Set
        End Property
        
        Public Property mPrpUDM_CONTEXT() As String
            Get
                Return mStrUDM_CONTEXT
            End Get
            Set(ByVal value As String)
                mStrUDM_CONTEXT = value
            End Set
        End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngUDM_USER_SRNO = 0
	  mLngUDM_UCD_ITEM_SRNO = 0
	  mStrUDM_CONTEXT = String.Empty
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [UDM_USER_SRNO] " & _
        ", [UDM_UCD_ITEM_SRNO] " & _
        ", [UDM_CONTEXT] " & _
        "From [TB_USER_DTLS_MAP] " & _
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
      	"Select Count(*) From [TB_USER_DTLS_MAP]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_USER_DTLS_MAP] (" & _
        "  [UDM_USER_SRNO] " & _
        ", [UDM_UCD_ITEM_SRNO] " & _
        ", [UDM_CONTEXT] " & _
        " ) Values ( " & _
         mLngUDM_USER_SRNO.ToString() & _
        ", " & mLngUDM_UCD_ITEM_SRNO.ToString() & _
        ", " & "'" & mStrUDM_CONTEXT & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_USER_DTLS_MAP] Set " & _
        "  [UDM_USER_SRNO] = " & mLngUDM_USER_SRNO.ToString() & _
        ", UDM_UCD_ITEM_SRNO = " & mLngUDM_UCD_ITEM_SRNO.ToString() & _
        ", UDM_CONTEXT = " & "'" & mStrUDM_CONTEXT & "'" & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_USER_DTLS_MAP] " & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_USER_DTLS_MAP] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [UDM_USER_SRNO] " & _
        ", [UDM_UCD_ITEM_SRNO] " & _
        ", [UDM_CONTEXT] " & _
        "From [TB_USER_DTLS_MAP]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
        mLngUDM_USER_SRNO = mFnPopulate(aObjDataReader,"UDM_USER_SRNO")
        mLngUDM_UCD_ITEM_SRNO = mFnPopulate(aObjDataReader,"UDM_UCD_ITEM_SRNO")
        mStrUDM_CONTEXT = mFnPopulate(aObjDataReader,"UDM_CONTEXT")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngUDM_USER_SRNO = 0
	  mLngUDM_UCD_ITEM_SRNO = 0
	  mStrUDM_CONTEXT = String.Empty
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("UDM_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UDM_UCD_ITEM_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UDM_CONTEXT", GetType(String)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
