
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/1/15 10:00:56
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_LANG_DICTIONARY
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

  Public Class clsTB_LANG_DICTIONARY
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngLD_ITEM_SRNO As Long
		Private mLngLD_ITEM_LANG As Long
		Private mStrLD_DESC As String
   
#End Region

#Region "CLASS PROPERTIES"

        Public Property mPrpLD_ITEM_SRNO() As Long
            Get
                Return mLngLD_ITEM_SRNO
            End Get
            Set(ByVal value As Long)
                mLngLD_ITEM_SRNO = value
            End Set
        End Property
        
        Public Property mPrpLD_ITEM_LANG() As Long
            Get
                Return mLngLD_ITEM_LANG
            End Get
            Set(ByVal value As Long)
                mLngLD_ITEM_LANG = value
            End Set
        End Property
        
        Public Property mPrpLD_DESC() As String
            Get
                Return mStrLD_DESC
            End Get
            Set(ByVal value As String)
                mStrLD_DESC = value
            End Set
        End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngLD_ITEM_SRNO = 0
	  mLngLD_ITEM_LANG = 0
	  mStrLD_DESC = String.Empty
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [LD_ITEM_SRNO] " & _
        ", [LD_ITEM_LANG] " & _
        ", [LD_DESC] " & _
        "From [TB_LANG_DICTIONARY] " & _
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
      	"Select Count(*) From [TB_LANG_DICTIONARY]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_LANG_DICTIONARY] (" & _
        "  [LD_ITEM_SRNO] " & _
        ", [LD_ITEM_LANG] " & _
        ", [LD_DESC] " & _
        " ) Values ( " & _
         mLngLD_ITEM_SRNO.ToString() & _
        ", " & mLngLD_ITEM_LANG.ToString() & _
        ", " & "'" & mStrLD_DESC & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_LANG_DICTIONARY] Set " & _
        "  [LD_ITEM_SRNO] = " & mLngLD_ITEM_SRNO.ToString() & _
        ", LD_ITEM_LANG = " & mLngLD_ITEM_LANG.ToString() & _
        ", LD_DESC = " & "'" & mStrLD_DESC & "'" & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_LANG_DICTIONARY] " & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_LANG_DICTIONARY] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [LD_ITEM_SRNO] " & _
        ", [LD_ITEM_LANG] " & _
        ", [LD_DESC] " & _
        "From [TB_LANG_DICTIONARY]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
        mLngLD_ITEM_SRNO = mFnPopulate(aObjDataReader,"LD_ITEM_SRNO")
        mLngLD_ITEM_LANG = mFnPopulate(aObjDataReader,"LD_ITEM_LANG")
        mStrLD_DESC = mFnPopulate(aObjDataReader,"LD_DESC")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngLD_ITEM_SRNO = 0
	  mLngLD_ITEM_LANG = 0
	  mStrLD_DESC = String.Empty
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("LD_ITEM_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("LD_ITEM_LANG", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("LD_DESC", GetType(String)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
