
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/1/15 10:00:56
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_MESSAGE_DICTIONARY
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

  Public Class clsTB_MESSAGE_DICTIONARY
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngMD_MESSAGE_SRNO As Long
		Private mLngMD_MESSAGE_LANG As Long
		Private mStrMD_MESSAGE_DESC As String
   
#End Region

#Region "CLASS PROPERTIES"

        Public Property mPrpMD_MESSAGE_SRNO() As Long
            Get
                Return mLngMD_MESSAGE_SRNO
            End Get
            Set(ByVal value As Long)
                mLngMD_MESSAGE_SRNO = value
            End Set
        End Property
        
        Public Property mPrpMD_MESSAGE_LANG() As Long
            Get
                Return mLngMD_MESSAGE_LANG
            End Get
            Set(ByVal value As Long)
                mLngMD_MESSAGE_LANG = value
            End Set
        End Property
        
        Public Property mPrpMD_MESSAGE_DESC() As String
            Get
                Return mStrMD_MESSAGE_DESC
            End Get
            Set(ByVal value As String)
                mStrMD_MESSAGE_DESC = value
            End Set
        End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngMD_MESSAGE_SRNO = 0
	  mLngMD_MESSAGE_LANG = 0
	  mStrMD_MESSAGE_DESC = String.Empty
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [MD_MESSAGE_SRNO] " & _
        ", [MD_MESSAGE_LANG] " & _
        ", [MD_MESSAGE_DESC] " & _
        "From [TB_MESSAGE_DICTIONARY] " & _
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
      	"Select Count(*) From [TB_MESSAGE_DICTIONARY]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_MESSAGE_DICTIONARY] (" & _
        "  [MD_MESSAGE_SRNO] " & _
        ", [MD_MESSAGE_LANG] " & _
        ", [MD_MESSAGE_DESC] " & _
        " ) Values ( " & _
         mLngMD_MESSAGE_SRNO.ToString() & _
        ", " & mLngMD_MESSAGE_LANG.ToString() & _
        ", " & "'" & mStrMD_MESSAGE_DESC & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_MESSAGE_DICTIONARY] Set " & _
        "  [MD_MESSAGE_SRNO] = " & mLngMD_MESSAGE_SRNO.ToString() & _
        ", MD_MESSAGE_LANG = " & mLngMD_MESSAGE_LANG.ToString() & _
        ", MD_MESSAGE_DESC = " & "'" & mStrMD_MESSAGE_DESC & "'" & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_MESSAGE_DICTIONARY] " & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_MESSAGE_DICTIONARY] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [MD_MESSAGE_SRNO] " & _
        ", [MD_MESSAGE_LANG] " & _
        ", [MD_MESSAGE_DESC] " & _
        "From [TB_MESSAGE_DICTIONARY]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
        mLngMD_MESSAGE_SRNO = mFnPopulate(aObjDataReader,"MD_MESSAGE_SRNO")
        mLngMD_MESSAGE_LANG = mFnPopulate(aObjDataReader,"MD_MESSAGE_LANG")
        mStrMD_MESSAGE_DESC = mFnPopulate(aObjDataReader,"MD_MESSAGE_DESC")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngMD_MESSAGE_SRNO = 0
	  mLngMD_MESSAGE_LANG = 0
	  mStrMD_MESSAGE_DESC = String.Empty
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("MD_MESSAGE_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MD_MESSAGE_LANG", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MD_MESSAGE_DESC", GetType(String)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
