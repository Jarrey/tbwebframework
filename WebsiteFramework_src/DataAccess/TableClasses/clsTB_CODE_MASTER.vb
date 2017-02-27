
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/2 15:28:44
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_CODE_MASTER
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

  Public Class clsTB_CODE_MASTER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngCMS_CODE_SRNO As Long
		Private mStrCMS_CODE_DESC As String
		Private mStrCMS_CODE_NAME As String
		Private mStrCMS_CODE_LABEL As String
		Private mStrCMS_CODE_LABEL_LANG_SRNO As String
		Private mLngCMS_CODE_CATEGORY As Long
		Private mStrCMS_CODE_VALUE As String
		Private mStrCMS_CODE_VALUE_LANG_SRNO As String
		Private mStrCMS_CUSTOM_QUERY As String
		Private mLngCMS_CREATE_USER_SRNO As Long
		Private mObjCMS_CREATE_DATE_TIME As Date
		Private mLngCMS_UPDATE_USER_SRNO As Long
		Private mObjCMS_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpCMS_CODE_SRNO() As Long
      Get
        Return mLngCMS_CODE_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCMS_CODE_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCMS_CODE_DESC() As String
      Get
        Return mStrCMS_CODE_DESC
      End Get
      Set(ByVal value As String)
        mStrCMS_CODE_DESC = value
      End Set
    End Property
        
    Public Property mPrpCMS_CODE_NAME() As String
      Get
        Return mStrCMS_CODE_NAME
      End Get
      Set(ByVal value As String)
        mStrCMS_CODE_NAME = value
      End Set
    End Property
        
    Public Property mPrpCMS_CODE_LABEL() As String
      Get
        Return mStrCMS_CODE_LABEL
      End Get
      Set(ByVal value As String)
        mStrCMS_CODE_LABEL = value
      End Set
    End Property
        
    Public Property mPrpCMS_CODE_LABEL_LANG_SRNO() As String
      Get
        Return mStrCMS_CODE_LABEL_LANG_SRNO
      End Get
      Set(ByVal value As String)
        mStrCMS_CODE_LABEL_LANG_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCMS_CODE_CATEGORY() As Long
      Get
        Return mLngCMS_CODE_CATEGORY
      End Get
      Set(ByVal value As Long)
        mLngCMS_CODE_CATEGORY = value
      End Set
    End Property
        
    Public Property mPrpCMS_CODE_VALUE() As String
      Get
        Return mStrCMS_CODE_VALUE
      End Get
      Set(ByVal value As String)
        mStrCMS_CODE_VALUE = value
      End Set
    End Property
        
    Public Property mPrpCMS_CODE_VALUE_LANG_SRNO() As String
      Get
        Return mStrCMS_CODE_VALUE_LANG_SRNO
      End Get
      Set(ByVal value As String)
        mStrCMS_CODE_VALUE_LANG_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCMS_CUSTOM_QUERY() As String
      Get
        Return mStrCMS_CUSTOM_QUERY
      End Get
      Set(ByVal value As String)
        mStrCMS_CUSTOM_QUERY = value
      End Set
    End Property
        
    Public Property mPrpCMS_CREATE_USER_SRNO() As Long
      Get
        Return mLngCMS_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCMS_CREATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCMS_CREATE_DATE_TIME() As Date
      Get
        Return mObjCMS_CREATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCMS_CREATE_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpCMS_UPDATE_USER_SRNO() As Long
      Get
        Return mLngCMS_UPDATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngCMS_UPDATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpCMS_UPDATE_DATE_TIME() As Date
      Get
        Return mObjCMS_UPDATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjCMS_UPDATE_DATE_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngCMS_CODE_SRNO = 0
	  mStrCMS_CODE_DESC = String.Empty
	  mStrCMS_CODE_NAME = String.Empty
	  mStrCMS_CODE_LABEL = String.Empty
	  mStrCMS_CODE_LABEL_LANG_SRNO = String.Empty
	  mLngCMS_CODE_CATEGORY = 0
	  mStrCMS_CODE_VALUE = String.Empty
	  mStrCMS_CODE_VALUE_LANG_SRNO = String.Empty
	  mStrCMS_CUSTOM_QUERY = String.Empty
	  mLngCMS_CREATE_USER_SRNO = 0
	  mObjCMS_CREATE_DATE_TIME = New Date
	  mLngCMS_UPDATE_USER_SRNO = 0
	  mObjCMS_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [CMS_CODE_SRNO] " & _
        ", [CMS_CODE_DESC] " & _
        ", [CMS_CODE_NAME] " & _
        ", [CMS_CODE_LABEL] " & _
        ", [CMS_CODE_LABEL_LANG_SRNO] " & _
        ", [CMS_CODE_CATEGORY] " & _
        ", [CMS_CODE_VALUE] " & _
        ", [CMS_CODE_VALUE_LANG_SRNO] " & _
        ", [CMS_CUSTOM_QUERY] " & _
        ", [CMS_CREATE_USER_SRNO] " & _
        ", [CMS_CREATE_DATE_TIME] " & _
        ", [CMS_UPDATE_USER_SRNO] " & _
        ", [CMS_UPDATE_DATE_TIME] " & _
        "From [TB_CODE_MASTER] " & _
        "Where " & _
        " [CMS_CODE_SRNO] = " & mLngCMS_CODE_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_CODE_MASTER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([CMS_CODE_SRNO]) From [TB_CODE_MASTER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_CODE_MASTER] (" & _
        "  [CMS_CODE_SRNO] " & _
        ", [CMS_CODE_DESC] " & _
        ", [CMS_CODE_NAME] " & _
        ", [CMS_CODE_LABEL] " & _
        ", [CMS_CODE_LABEL_LANG_SRNO] " & _
        ", [CMS_CODE_CATEGORY] " & _
        ", [CMS_CODE_VALUE] " & _
        ", [CMS_CODE_VALUE_LANG_SRNO] " & _
        ", [CMS_CUSTOM_QUERY] " & _
        ", [CMS_CREATE_USER_SRNO] " & _
        ", [CMS_CREATE_DATE_TIME] " & _
        ", [CMS_UPDATE_USER_SRNO] " & _
        ", [CMS_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngCMS_CODE_SRNO.ToString() & _
        ", " & "'" & mStrCMS_CODE_DESC & "'" & _
        ", " & "'" & mStrCMS_CODE_NAME & "'" & _
        ", " & "'" & mStrCMS_CODE_LABEL & "'" & _
        ", " & "'" & mStrCMS_CODE_LABEL_LANG_SRNO & "'" & _
        ", " & mLngCMS_CODE_CATEGORY.ToString() & _
        ", " & "'" & mStrCMS_CODE_VALUE & "'" & _
        ", " & "'" & mStrCMS_CODE_VALUE_LANG_SRNO & "'" & _
        ", " & "'" & mStrCMS_CUSTOM_QUERY & "'" & _
        ", " & mLngCMS_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCMS_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngCMS_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjCMS_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_CODE_MASTER] Set " & _
        "  [CMS_CODE_SRNO] = " & mLngCMS_CODE_SRNO.ToString() & _
        ", CMS_CODE_DESC = " & "'" & mStrCMS_CODE_DESC & "'" & _
        ", CMS_CODE_NAME = " & "'" & mStrCMS_CODE_NAME & "'" & _
        ", CMS_CODE_LABEL = " & "'" & mStrCMS_CODE_LABEL & "'" & _
        ", CMS_CODE_LABEL_LANG_SRNO = " & "'" & mStrCMS_CODE_LABEL_LANG_SRNO & "'" & _
        ", CMS_CODE_CATEGORY = " & mLngCMS_CODE_CATEGORY.ToString() & _
        ", CMS_CODE_VALUE = " & "'" & mStrCMS_CODE_VALUE & "'" & _
        ", CMS_CODE_VALUE_LANG_SRNO = " & "'" & mStrCMS_CODE_VALUE_LANG_SRNO & "'" & _
        ", CMS_CUSTOM_QUERY = " & "'" & mStrCMS_CUSTOM_QUERY & "'" & _
        ", CMS_CREATE_USER_SRNO = " & mLngCMS_CREATE_USER_SRNO.ToString() & _
        ", CMS_CREATE_DATE_TIME = " & "'" & mObjCMS_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", CMS_UPDATE_USER_SRNO = " & mLngCMS_UPDATE_USER_SRNO.ToString() & _
        ", CMS_UPDATE_DATE_TIME = " & "'" & mObjCMS_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [CMS_CODE_SRNO] = " & mLngCMS_CODE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_CODE_MASTER] " & _
        "Where " & _
        " [CMS_CODE_SRNO] = " & mLngCMS_CODE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_CODE_MASTER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [CMS_CODE_SRNO] " & _
        ", [CMS_CODE_DESC] " & _
        ", [CMS_CODE_NAME] " & _
        ", [CMS_CODE_LABEL] " & _
        ", [CMS_CODE_LABEL_LANG_SRNO] " & _
        ", [CMS_CODE_CATEGORY] " & _
        ", [CMS_CODE_VALUE] " & _
        ", [CMS_CODE_VALUE_LANG_SRNO] " & _
        ", [CMS_CUSTOM_QUERY] " & _
        ", [CMS_CREATE_USER_SRNO] " & _
        ", [CMS_CREATE_DATE_TIME] " & _
        ", [CMS_UPDATE_USER_SRNO] " & _
        ", [CMS_UPDATE_DATE_TIME] " & _
        "From [TB_CODE_MASTER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngCMS_CODE_SRNO = mFnPopulate(aObjDataReader,"CMS_CODE_SRNO")
      mStrCMS_CODE_DESC = mFnPopulate(aObjDataReader,"CMS_CODE_DESC")
      mStrCMS_CODE_NAME = mFnPopulate(aObjDataReader,"CMS_CODE_NAME")
      mStrCMS_CODE_LABEL = mFnPopulate(aObjDataReader,"CMS_CODE_LABEL")
      mStrCMS_CODE_LABEL_LANG_SRNO = mFnPopulate(aObjDataReader,"CMS_CODE_LABEL_LANG_SRNO")
      mLngCMS_CODE_CATEGORY = mFnPopulate(aObjDataReader,"CMS_CODE_CATEGORY")
      mStrCMS_CODE_VALUE = mFnPopulate(aObjDataReader,"CMS_CODE_VALUE")
      mStrCMS_CODE_VALUE_LANG_SRNO = mFnPopulate(aObjDataReader,"CMS_CODE_VALUE_LANG_SRNO")
      mStrCMS_CUSTOM_QUERY = mFnPopulate(aObjDataReader,"CMS_CUSTOM_QUERY")
      mLngCMS_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"CMS_CREATE_USER_SRNO")
      mObjCMS_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"CMS_CREATE_DATE_TIME")
      mLngCMS_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"CMS_UPDATE_USER_SRNO")
      mObjCMS_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"CMS_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngCMS_CODE_SRNO = 0
	  mStrCMS_CODE_DESC = String.Empty
	  mStrCMS_CODE_NAME = String.Empty
	  mStrCMS_CODE_LABEL = String.Empty
	  mStrCMS_CODE_LABEL_LANG_SRNO = String.Empty
	  mLngCMS_CODE_CATEGORY = 0
	  mStrCMS_CODE_VALUE = String.Empty
	  mStrCMS_CODE_VALUE_LANG_SRNO = String.Empty
	  mStrCMS_CUSTOM_QUERY = String.Empty
	  mLngCMS_CREATE_USER_SRNO = 0
	  mObjCMS_CREATE_DATE_TIME = New Date
	  mLngCMS_UPDATE_USER_SRNO = 0
	  mObjCMS_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_DESC", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_NAME", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_LABEL", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_LABEL_LANG_SRNO", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_CATEGORY", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_VALUE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CODE_VALUE_LANG_SRNO", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CUSTOM_QUERY", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("CMS_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
