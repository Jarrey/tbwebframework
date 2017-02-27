
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/3 13:37:14
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_COLUMN_MODEL
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

  Public Class clsTB_COLUMN_MODEL
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngCM_COLUMN_SRNO As Long
		Private mLngCM_VIEW_SRNO As Long
		Private mStrCM_COLUMN_NAME As String
		Private mStrCM_COLUMN_LANG_SRNO As String
		Private mLngCM_COLUMN_INDEX As Long
		Private mLngCM_COLUMN_CATEGORY As Long
		Private mStrCM_COLUMN_DATA_INDEX As String
		Private mStrCM_COLUMN_TYPE As String
		Private mDblCM_COLUMN_WIDTH As Double
		Private mLngCM_COLUMN_ALIGN As Long
		Private mStrCM_COLUMN_TOOLTIP As String
		Private mStrCM_COLUMN_CSS As String
		Private mStrCM_COLUMN_TPL As String
		Private mLngCM_COLUMN_SORTABLE As Long
		Private mLngCM_COLUMN_RESIZABLE As Long
		Private mLngCM_COLUMN_EDITABLE As Long
		Private mStrCM_COLUMN_EDITOR As String
		Private mStrCM_COLUMN_RENDERER As String
		Private mStrCM_COLUMN_SCOPE As String
		Private mLngCM_CREATE_USER_SRNO As Long
		Private mObjCM_CREATE_DATE_TIME As Date
		Private mLngCM_UPDATE_USER_SRNO As Long
		Private mObjCM_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpCM_COLUMN_SRNO() As Long
      Get
        Return mLngCM_COLUMN_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCM_COLUMN_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCM_VIEW_SRNO() As Long
      Get
        Return mLngCM_VIEW_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCM_VIEW_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_NAME() As String
      Get
        Return mStrCM_COLUMN_NAME
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_NAME = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_LANG_SRNO() As String
      Get
        Return mStrCM_COLUMN_LANG_SRNO
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_LANG_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_INDEX() As Long
      Get
        Return mLngCM_COLUMN_INDEX
      End Get
      Set(ByVal value As Long)
        mLngCM_COLUMN_INDEX = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_CATEGORY() As Long
      Get
        Return mLngCM_COLUMN_CATEGORY
      End Get
      Set(ByVal value As Long)
        mLngCM_COLUMN_CATEGORY = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_DATA_INDEX() As String
      Get
        Return mStrCM_COLUMN_DATA_INDEX
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_DATA_INDEX = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_TYPE() As String
      Get
        Return mStrCM_COLUMN_TYPE
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_TYPE = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_WIDTH() As Double
      Get
        Return mDblCM_COLUMN_WIDTH
      End Get
      Set(ByVal value As Double)
        mDblCM_COLUMN_WIDTH = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_ALIGN() As Long
      Get
        Return mLngCM_COLUMN_ALIGN
      End Get
      Set(ByVal value As Long)
        mLngCM_COLUMN_ALIGN = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_TOOLTIP() As String
      Get
        Return mStrCM_COLUMN_TOOLTIP
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_TOOLTIP = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_CSS() As String
      Get
        Return mStrCM_COLUMN_CSS
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_CSS = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_TPL() As String
      Get
        Return mStrCM_COLUMN_TPL
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_TPL = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_SORTABLE() As Long
      Get
        Return mLngCM_COLUMN_SORTABLE
      End Get
      Set(ByVal value As Long)
        mLngCM_COLUMN_SORTABLE = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_RESIZABLE() As Long
      Get
        Return mLngCM_COLUMN_RESIZABLE
      End Get
      Set(ByVal value As Long)
        mLngCM_COLUMN_RESIZABLE = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_EDITABLE() As Long
      Get
        Return mLngCM_COLUMN_EDITABLE
      End Get
      Set(ByVal value As Long)
        mLngCM_COLUMN_EDITABLE = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_EDITOR() As String
      Get
        Return mStrCM_COLUMN_EDITOR
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_EDITOR = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_RENDERER() As String
      Get
        Return mStrCM_COLUMN_RENDERER
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_RENDERER = value
      End Set
    End Property
        
    Public Property mPrpCM_COLUMN_SCOPE() As String
      Get
        Return mStrCM_COLUMN_SCOPE
      End Get
      Set(ByVal value As String)
        mStrCM_COLUMN_SCOPE = value
      End Set
    End Property
        
    Public Property mPrpCM_CREATE_USER_SRNO() As Long
      Get
        Return mLngCM_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCM_CREATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCM_CREATE_DATE_TIME() As Date
      Get
        Return mObjCM_CREATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCM_CREATE_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpCM_UPDATE_USER_SRNO() As Long
      Get
        Return mLngCM_UPDATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCM_UPDATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCM_UPDATE_DATE_TIME() As Date
      Get
        Return mObjCM_UPDATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCM_UPDATE_DATE_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngCM_COLUMN_SRNO = 0
	  mLngCM_VIEW_SRNO = 0
	  mStrCM_COLUMN_NAME = String.Empty
	  mStrCM_COLUMN_LANG_SRNO = String.Empty
	  mLngCM_COLUMN_INDEX = 0
	  mLngCM_COLUMN_CATEGORY = 0
	  mStrCM_COLUMN_DATA_INDEX = String.Empty
	  mStrCM_COLUMN_TYPE = String.Empty
	  mDblCM_COLUMN_WIDTH = 0
	  mLngCM_COLUMN_ALIGN = 0
	  mStrCM_COLUMN_TOOLTIP = String.Empty
	  mStrCM_COLUMN_CSS = String.Empty
	  mStrCM_COLUMN_TPL = String.Empty
	  mLngCM_COLUMN_SORTABLE = 0
	  mLngCM_COLUMN_RESIZABLE = 0
	  mLngCM_COLUMN_EDITABLE = 0
	  mStrCM_COLUMN_EDITOR = String.Empty
	  mStrCM_COLUMN_RENDERER = String.Empty
	  mStrCM_COLUMN_SCOPE = String.Empty
	  mLngCM_CREATE_USER_SRNO = 0
	  mObjCM_CREATE_DATE_TIME = New Date
	  mLngCM_UPDATE_USER_SRNO = 0
	  mObjCM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [CM_COLUMN_SRNO] " & _
        ", [CM_VIEW_SRNO] " & _
        ", [CM_COLUMN_NAME] " & _
        ", [CM_COLUMN_LANG_SRNO] " & _
        ", [CM_COLUMN_INDEX] " & _
        ", [CM_COLUMN_CATEGORY] " & _
        ", [CM_COLUMN_DATA_INDEX] " & _
        ", [CM_COLUMN_TYPE] " & _
        ", [CM_COLUMN_WIDTH] " & _
        ", [CM_COLUMN_ALIGN] " & _
        ", [CM_COLUMN_TOOLTIP] " & _
        ", [CM_COLUMN_CSS] " & _
        ", [CM_COLUMN_TPL] " & _
        ", [CM_COLUMN_SORTABLE] " & _
        ", [CM_COLUMN_RESIZABLE] " & _
        ", [CM_COLUMN_EDITABLE] " & _
        ", [CM_COLUMN_EDITOR] " & _
        ", [CM_COLUMN_RENDERER] " & _
        ", [CM_COLUMN_SCOPE] " & _
        ", [CM_CREATE_USER_SRNO] " & _
        ", [CM_CREATE_DATE_TIME] " & _
        ", [CM_UPDATE_USER_SRNO] " & _
        ", [CM_UPDATE_DATE_TIME] " & _
        "From [TB_COLUMN_MODEL] " & _
        "Where " & _
        " [CM_COLUMN_SRNO] = " & mLngCM_COLUMN_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_COLUMN_MODEL]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([CM_COLUMN_SRNO]) From [TB_COLUMN_MODEL]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_COLUMN_MODEL] (" & _
        "  [CM_COLUMN_SRNO] " & _
        ", [CM_VIEW_SRNO] " & _
        ", [CM_COLUMN_NAME] " & _
        ", [CM_COLUMN_LANG_SRNO] " & _
        ", [CM_COLUMN_INDEX] " & _
        ", [CM_COLUMN_CATEGORY] " & _
        ", [CM_COLUMN_DATA_INDEX] " & _
        ", [CM_COLUMN_TYPE] " & _
        ", [CM_COLUMN_WIDTH] " & _
        ", [CM_COLUMN_ALIGN] " & _
        ", [CM_COLUMN_TOOLTIP] " & _
        ", [CM_COLUMN_CSS] " & _
        ", [CM_COLUMN_TPL] " & _
        ", [CM_COLUMN_SORTABLE] " & _
        ", [CM_COLUMN_RESIZABLE] " & _
        ", [CM_COLUMN_EDITABLE] " & _
        ", [CM_COLUMN_EDITOR] " & _
        ", [CM_COLUMN_RENDERER] " & _
        ", [CM_COLUMN_SCOPE] " & _
        ", [CM_CREATE_USER_SRNO] " & _
        ", [CM_CREATE_DATE_TIME] " & _
        ", [CM_UPDATE_USER_SRNO] " & _
        ", [CM_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngCM_COLUMN_SRNO.ToString() & _
        ", " & mLngCM_VIEW_SRNO.ToString() & _
        ", " & "'" & mStrCM_COLUMN_NAME & "'" & _
        ", " & "'" & mStrCM_COLUMN_LANG_SRNO & "'" & _
        ", " & mLngCM_COLUMN_INDEX.ToString() & _
        ", " & mLngCM_COLUMN_CATEGORY.ToString() & _
        ", " & "'" & mStrCM_COLUMN_DATA_INDEX & "'" & _
        ", " & "'" & mStrCM_COLUMN_TYPE & "'" & _
        ", " & mDblCM_COLUMN_WIDTH.ToString() & _
        ", " & mLngCM_COLUMN_ALIGN.ToString() & _
        ", " & "'" & mStrCM_COLUMN_TOOLTIP & "'" & _
        ", " & "'" & mStrCM_COLUMN_CSS & "'" & _
        ", " & "'" & mStrCM_COLUMN_TPL & "'" & _
        ", " & mLngCM_COLUMN_SORTABLE.ToString() & _
        ", " & mLngCM_COLUMN_RESIZABLE.ToString() & _
        ", " & mLngCM_COLUMN_EDITABLE.ToString() & _
        ", " & "'" & mStrCM_COLUMN_EDITOR & "'" & _
        ", " & "'" & mStrCM_COLUMN_RENDERER & "'" & _
        ", " & "'" & mStrCM_COLUMN_SCOPE & "'" & _
        ", " & mLngCM_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngCM_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_COLUMN_MODEL] Set " & _
        "  [CM_COLUMN_SRNO] = " & mLngCM_COLUMN_SRNO.ToString() & _
        ", CM_VIEW_SRNO = " & mLngCM_VIEW_SRNO.ToString() & _
        ", CM_COLUMN_NAME = " & "'" & mStrCM_COLUMN_NAME & "'" & _
        ", CM_COLUMN_LANG_SRNO = " & "'" & mStrCM_COLUMN_LANG_SRNO & "'" & _
        ", CM_COLUMN_INDEX = " & mLngCM_COLUMN_INDEX.ToString() & _
        ", CM_COLUMN_CATEGORY = " & mLngCM_COLUMN_CATEGORY.ToString() & _
        ", CM_COLUMN_DATA_INDEX = " & "'" & mStrCM_COLUMN_DATA_INDEX & "'" & _
        ", CM_COLUMN_TYPE = " & "'" & mStrCM_COLUMN_TYPE & "'" & _
        ", CM_COLUMN_WIDTH = " & mDblCM_COLUMN_WIDTH.ToString() & _
        ", CM_COLUMN_ALIGN = " & mLngCM_COLUMN_ALIGN.ToString() & _
        ", CM_COLUMN_TOOLTIP = " & "'" & mStrCM_COLUMN_TOOLTIP & "'" & _
        ", CM_COLUMN_CSS = " & "'" & mStrCM_COLUMN_CSS & "'" & _
        ", CM_COLUMN_TPL = " & "'" & mStrCM_COLUMN_TPL & "'" & _
        ", CM_COLUMN_SORTABLE = " & mLngCM_COLUMN_SORTABLE.ToString() & _
        ", CM_COLUMN_RESIZABLE = " & mLngCM_COLUMN_RESIZABLE.ToString() & _
        ", CM_COLUMN_EDITABLE = " & mLngCM_COLUMN_EDITABLE.ToString() & _
        ", CM_COLUMN_EDITOR = " & "'" & mStrCM_COLUMN_EDITOR & "'" & _
        ", CM_COLUMN_RENDERER = " & "'" & mStrCM_COLUMN_RENDERER & "'" & _
        ", CM_COLUMN_SCOPE = " & "'" & mStrCM_COLUMN_SCOPE & "'" & _
        ", CM_CREATE_USER_SRNO = " & mLngCM_CREATE_USER_SRNO.ToString() & _
        ", CM_CREATE_DATE_TIME = " & "'" & mObjCM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", CM_UPDATE_USER_SRNO = " & mLngCM_UPDATE_USER_SRNO.ToString() & _
        ", CM_UPDATE_DATE_TIME = " & "'" & mObjCM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [CM_COLUMN_SRNO] = " & mLngCM_COLUMN_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_COLUMN_MODEL] " & _
        "Where " & _
        " [CM_COLUMN_SRNO] = " & mLngCM_COLUMN_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_COLUMN_MODEL] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [CM_COLUMN_SRNO] " & _
        ", [CM_VIEW_SRNO] " & _
        ", [CM_COLUMN_NAME] " & _
        ", [CM_COLUMN_LANG_SRNO] " & _
        ", [CM_COLUMN_INDEX] " & _
        ", [CM_COLUMN_CATEGORY] " & _
        ", [CM_COLUMN_DATA_INDEX] " & _
        ", [CM_COLUMN_TYPE] " & _
        ", [CM_COLUMN_WIDTH] " & _
        ", [CM_COLUMN_ALIGN] " & _
        ", [CM_COLUMN_TOOLTIP] " & _
        ", [CM_COLUMN_CSS] " & _
        ", [CM_COLUMN_TPL] " & _
        ", [CM_COLUMN_SORTABLE] " & _
        ", [CM_COLUMN_RESIZABLE] " & _
        ", [CM_COLUMN_EDITABLE] " & _
        ", [CM_COLUMN_EDITOR] " & _
        ", [CM_COLUMN_RENDERER] " & _
        ", [CM_COLUMN_SCOPE] " & _
        ", [CM_CREATE_USER_SRNO] " & _
        ", [CM_CREATE_DATE_TIME] " & _
        ", [CM_UPDATE_USER_SRNO] " & _
        ", [CM_UPDATE_DATE_TIME] " & _
        "From [TB_COLUMN_MODEL]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngCM_COLUMN_SRNO = mFnPopulate(aObjDataReader,"CM_COLUMN_SRNO")
      mLngCM_VIEW_SRNO = mFnPopulate(aObjDataReader,"CM_VIEW_SRNO")
      mStrCM_COLUMN_NAME = mFnPopulate(aObjDataReader,"CM_COLUMN_NAME")
      mStrCM_COLUMN_LANG_SRNO = mFnPopulate(aObjDataReader,"CM_COLUMN_LANG_SRNO")
      mLngCM_COLUMN_INDEX = mFnPopulate(aObjDataReader,"CM_COLUMN_INDEX")
      mLngCM_COLUMN_CATEGORY = mFnPopulate(aObjDataReader,"CM_COLUMN_CATEGORY")
      mStrCM_COLUMN_DATA_INDEX = mFnPopulate(aObjDataReader,"CM_COLUMN_DATA_INDEX")
      mStrCM_COLUMN_TYPE = mFnPopulate(aObjDataReader,"CM_COLUMN_TYPE")
      mDblCM_COLUMN_WIDTH = mFnPopulate(aObjDataReader,"CM_COLUMN_WIDTH")
      mLngCM_COLUMN_ALIGN = mFnPopulate(aObjDataReader,"CM_COLUMN_ALIGN")
      mStrCM_COLUMN_TOOLTIP = mFnPopulate(aObjDataReader,"CM_COLUMN_TOOLTIP")
      mStrCM_COLUMN_CSS = mFnPopulate(aObjDataReader,"CM_COLUMN_CSS")
      mStrCM_COLUMN_TPL = mFnPopulate(aObjDataReader,"CM_COLUMN_TPL")
      mLngCM_COLUMN_SORTABLE = mFnPopulate(aObjDataReader,"CM_COLUMN_SORTABLE")
      mLngCM_COLUMN_RESIZABLE = mFnPopulate(aObjDataReader,"CM_COLUMN_RESIZABLE")
      mLngCM_COLUMN_EDITABLE = mFnPopulate(aObjDataReader,"CM_COLUMN_EDITABLE")
      mStrCM_COLUMN_EDITOR = mFnPopulate(aObjDataReader,"CM_COLUMN_EDITOR")
      mStrCM_COLUMN_RENDERER = mFnPopulate(aObjDataReader,"CM_COLUMN_RENDERER")
      mStrCM_COLUMN_SCOPE = mFnPopulate(aObjDataReader,"CM_COLUMN_SCOPE")
      mLngCM_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"CM_CREATE_USER_SRNO")
      mObjCM_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"CM_CREATE_DATE_TIME")
      mLngCM_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"CM_UPDATE_USER_SRNO")
      mObjCM_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"CM_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngCM_COLUMN_SRNO = 0
	  mLngCM_VIEW_SRNO = 0
	  mStrCM_COLUMN_NAME = String.Empty
	  mStrCM_COLUMN_LANG_SRNO = String.Empty
	  mLngCM_COLUMN_INDEX = 0
	  mLngCM_COLUMN_CATEGORY = 0
	  mStrCM_COLUMN_DATA_INDEX = String.Empty
	  mStrCM_COLUMN_TYPE = String.Empty
	  mDblCM_COLUMN_WIDTH = 0
	  mLngCM_COLUMN_ALIGN = 0
	  mStrCM_COLUMN_TOOLTIP = String.Empty
	  mStrCM_COLUMN_CSS = String.Empty
	  mStrCM_COLUMN_TPL = String.Empty
	  mLngCM_COLUMN_SORTABLE = 0
	  mLngCM_COLUMN_RESIZABLE = 0
	  mLngCM_COLUMN_EDITABLE = 0
	  mStrCM_COLUMN_EDITOR = String.Empty
	  mStrCM_COLUMN_RENDERER = String.Empty
	  mStrCM_COLUMN_SCOPE = String.Empty
	  mLngCM_CREATE_USER_SRNO = 0
	  mObjCM_CREATE_DATE_TIME = New Date
	  mLngCM_UPDATE_USER_SRNO = 0
	  mObjCM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_VIEW_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_NAME", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_LANG_SRNO", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_INDEX", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_CATEGORY", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_DATA_INDEX", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_TYPE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_WIDTH", GetType(Double)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_ALIGN", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_TOOLTIP", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_CSS", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_TPL", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_SORTABLE", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_RESIZABLE", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_EDITABLE", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_EDITOR", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_RENDERER", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_COLUMN_SCOPE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CM_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
