
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/3 13:37:14
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_MENU_MANAGER
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

  Public Class clsTB_MENU_MANAGER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngMM_MENU_SRNO As Long
		Private mLngMM_MENU_DISPLAY_INDEX As Long
		Private mStrMM_MENU_DESC As String
		Private mStrMM_MENU_LANG_SRNO As String
		Private mLngMM_PARENT_SRNO As Long
		Private mLngMM_IS_LEAF As Long
		Private mLngMM_MENU_CATEGORY As Long
		Private mStrMM_URL As String
		Private mStrMM_TARGET As String
		Private mLngMM_CREATE_USER_SRNO As Long
		Private mObjMM_CREATE_DATE_TIME As Date
		Private mLngMM_UPDATE_USER_SRNO As Long
		Private mObjMM_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpMM_MENU_SRNO() As Long
      Get
        Return mLngMM_MENU_SRNO
      End Get
      Set(ByVal value As Long)
        mLngMM_MENU_SRNO = value
      End Set
    End Property
        
    Public Property mPrpMM_MENU_DISPLAY_INDEX() As Long
      Get
        Return mLngMM_MENU_DISPLAY_INDEX
      End Get
      Set(ByVal value As Long)
        mLngMM_MENU_DISPLAY_INDEX = value
      End Set
    End Property
        
    Public Property mPrpMM_MENU_DESC() As String
      Get
        Return mStrMM_MENU_DESC
      End Get
      Set(ByVal value As String)
        mStrMM_MENU_DESC = value
      End Set
    End Property
        
    Public Property mPrpMM_MENU_LANG_SRNO() As String
      Get
        Return mStrMM_MENU_LANG_SRNO
      End Get
      Set(ByVal value As String)
        mStrMM_MENU_LANG_SRNO = value
      End Set
    End Property
        
    Public Property mPrpMM_PARENT_SRNO() As Long
      Get
        Return mLngMM_PARENT_SRNO
      End Get
      Set(ByVal value As Long)
        mLngMM_PARENT_SRNO = value
      End Set
    End Property
        
    Public Property mPrpMM_IS_LEAF() As Long
      Get
        Return mLngMM_IS_LEAF
      End Get
      Set(ByVal value As Long)
        mLngMM_IS_LEAF = value
      End Set
    End Property
        
    Public Property mPrpMM_MENU_CATEGORY() As Long
      Get
        Return mLngMM_MENU_CATEGORY
      End Get
      Set(ByVal value As Long)
        mLngMM_MENU_CATEGORY = value
      End Set
    End Property
        
    Public Property mPrpMM_URL() As String
      Get
        Return mStrMM_URL
      End Get
      Set(ByVal value As String)
        mStrMM_URL = value
      End Set
    End Property
        
    Public Property mPrpMM_TARGET() As String
      Get
        Return mStrMM_TARGET
      End Get
      Set(ByVal value As String)
        mStrMM_TARGET = value
      End Set
    End Property
        
    Public Property mPrpMM_CREATE_USER_SRNO() As Long
      Get
        Return mLngMM_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngMM_CREATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpMM_CREATE_DATE_TIME() As Date
      Get
        Return mObjMM_CREATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjMM_CREATE_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpMM_UPDATE_USER_SRNO() As Long
      Get
        Return mLngMM_UPDATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngMM_UPDATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpMM_UPDATE_DATE_TIME() As Date
      Get
        Return mObjMM_UPDATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjMM_UPDATE_DATE_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngMM_MENU_SRNO = 0
	  mLngMM_MENU_DISPLAY_INDEX = 0
	  mStrMM_MENU_DESC = String.Empty
	  mStrMM_MENU_LANG_SRNO = String.Empty
	  mLngMM_PARENT_SRNO = 0
	  mLngMM_IS_LEAF = 0
	  mLngMM_MENU_CATEGORY = 0
	  mStrMM_URL = String.Empty
	  mStrMM_TARGET = String.Empty
	  mLngMM_CREATE_USER_SRNO = 0
	  mObjMM_CREATE_DATE_TIME = New Date
	  mLngMM_UPDATE_USER_SRNO = 0
	  mObjMM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [MM_MENU_SRNO] " & _
        ", [MM_MENU_DISPLAY_INDEX] " & _
        ", [MM_MENU_DESC] " & _
        ", [MM_MENU_LANG_SRNO] " & _
        ", [MM_PARENT_SRNO] " & _
        ", [MM_IS_LEAF] " & _
        ", [MM_MENU_CATEGORY] " & _
        ", [MM_URL] " & _
        ", [MM_TARGET] " & _
        ", [MM_CREATE_USER_SRNO] " & _
        ", [MM_CREATE_DATE_TIME] " & _
        ", [MM_UPDATE_USER_SRNO] " & _
        ", [MM_UPDATE_DATE_TIME] " & _
        "From [TB_MENU_MANAGER] " & _
        "Where " & _
        " [MM_MENU_SRNO] = " & mLngMM_MENU_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_MENU_MANAGER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([MM_MENU_SRNO]) From [TB_MENU_MANAGER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_MENU_MANAGER] (" & _
        "  [MM_MENU_SRNO] " & _
        ", [MM_MENU_DISPLAY_INDEX] " & _
        ", [MM_MENU_DESC] " & _
        ", [MM_MENU_LANG_SRNO] " & _
        ", [MM_PARENT_SRNO] " & _
        ", [MM_IS_LEAF] " & _
        ", [MM_MENU_CATEGORY] " & _
        ", [MM_URL] " & _
        ", [MM_TARGET] " & _
        ", [MM_CREATE_USER_SRNO] " & _
        ", [MM_CREATE_DATE_TIME] " & _
        ", [MM_UPDATE_USER_SRNO] " & _
        ", [MM_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngMM_MENU_SRNO.ToString() & _
        ", " & mLngMM_MENU_DISPLAY_INDEX.ToString() & _
        ", " & "'" & mStrMM_MENU_DESC & "'" & _
        ", " & "'" & mStrMM_MENU_LANG_SRNO & "'" & _
        ", " & mLngMM_PARENT_SRNO.ToString() & _
        ", " & mLngMM_IS_LEAF.ToString() & _
        ", " & mLngMM_MENU_CATEGORY.ToString() & _
        ", " & "'" & mStrMM_URL & "'" & _
        ", " & "'" & mStrMM_TARGET & "'" & _
        ", " & mLngMM_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjMM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngMM_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjMM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_MENU_MANAGER] Set " & _
        "  [MM_MENU_SRNO] = " & mLngMM_MENU_SRNO.ToString() & _
        ", MM_MENU_DISPLAY_INDEX = " & mLngMM_MENU_DISPLAY_INDEX.ToString() & _
        ", MM_MENU_DESC = " & "'" & mStrMM_MENU_DESC & "'" & _
        ", MM_MENU_LANG_SRNO = " & "'" & mStrMM_MENU_LANG_SRNO & "'" & _
        ", MM_PARENT_SRNO = " & mLngMM_PARENT_SRNO.ToString() & _
        ", MM_IS_LEAF = " & mLngMM_IS_LEAF.ToString() & _
        ", MM_MENU_CATEGORY = " & mLngMM_MENU_CATEGORY.ToString() & _
        ", MM_URL = " & "'" & mStrMM_URL & "'" & _
        ", MM_TARGET = " & "'" & mStrMM_TARGET & "'" & _
        ", MM_CREATE_USER_SRNO = " & mLngMM_CREATE_USER_SRNO.ToString() & _
        ", MM_CREATE_DATE_TIME = " & "'" & mObjMM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", MM_UPDATE_USER_SRNO = " & mLngMM_UPDATE_USER_SRNO.ToString() & _
        ", MM_UPDATE_DATE_TIME = " & "'" & mObjMM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [MM_MENU_SRNO] = " & mLngMM_MENU_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_MENU_MANAGER] " & _
        "Where " & _
        " [MM_MENU_SRNO] = " & mLngMM_MENU_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_MENU_MANAGER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [MM_MENU_SRNO] " & _
        ", [MM_MENU_DISPLAY_INDEX] " & _
        ", [MM_MENU_DESC] " & _
        ", [MM_MENU_LANG_SRNO] " & _
        ", [MM_PARENT_SRNO] " & _
        ", [MM_IS_LEAF] " & _
        ", [MM_MENU_CATEGORY] " & _
        ", [MM_URL] " & _
        ", [MM_TARGET] " & _
        ", [MM_CREATE_USER_SRNO] " & _
        ", [MM_CREATE_DATE_TIME] " & _
        ", [MM_UPDATE_USER_SRNO] " & _
        ", [MM_UPDATE_DATE_TIME] " & _
        "From [TB_MENU_MANAGER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngMM_MENU_SRNO = mFnPopulate(aObjDataReader,"MM_MENU_SRNO")
      mLngMM_MENU_DISPLAY_INDEX = mFnPopulate(aObjDataReader,"MM_MENU_DISPLAY_INDEX")
      mStrMM_MENU_DESC = mFnPopulate(aObjDataReader,"MM_MENU_DESC")
      mStrMM_MENU_LANG_SRNO = mFnPopulate(aObjDataReader,"MM_MENU_LANG_SRNO")
      mLngMM_PARENT_SRNO = mFnPopulate(aObjDataReader,"MM_PARENT_SRNO")
      mLngMM_IS_LEAF = mFnPopulate(aObjDataReader,"MM_IS_LEAF")
      mLngMM_MENU_CATEGORY = mFnPopulate(aObjDataReader,"MM_MENU_CATEGORY")
      mStrMM_URL = mFnPopulate(aObjDataReader,"MM_URL")
      mStrMM_TARGET = mFnPopulate(aObjDataReader,"MM_TARGET")
      mLngMM_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"MM_CREATE_USER_SRNO")
      mObjMM_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"MM_CREATE_DATE_TIME")
      mLngMM_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"MM_UPDATE_USER_SRNO")
      mObjMM_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"MM_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngMM_MENU_SRNO = 0
	  mLngMM_MENU_DISPLAY_INDEX = 0
	  mStrMM_MENU_DESC = String.Empty
	  mStrMM_MENU_LANG_SRNO = String.Empty
	  mLngMM_PARENT_SRNO = 0
	  mLngMM_IS_LEAF = 0
	  mLngMM_MENU_CATEGORY = 0
	  mStrMM_URL = String.Empty
	  mStrMM_TARGET = String.Empty
	  mLngMM_CREATE_USER_SRNO = 0
	  mObjMM_CREATE_DATE_TIME = New Date
	  mLngMM_UPDATE_USER_SRNO = 0
	  mObjMM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_MENU_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_MENU_DISPLAY_INDEX", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_MENU_DESC", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_MENU_LANG_SRNO", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_PARENT_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_IS_LEAF", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_MENU_CATEGORY", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_URL", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_TARGET", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("MM_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
