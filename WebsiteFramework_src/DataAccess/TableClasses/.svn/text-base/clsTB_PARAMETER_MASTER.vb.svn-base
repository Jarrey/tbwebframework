
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/2 15:28:44
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_PARAMETER_MASTER
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

  Public Class clsTB_PARAMETER_MASTER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngPM_PARAMETER_SRNO As Long
		Private mStrPM_PARAMETER_DESC As String
		Private mStrPM_PARAMETER_NAME As String
		Private mStrPM_PARAMETER_NAME_LANG_SRNO As String
		Private mLngPM_PARAMETER_CATEGORY As Long
		Private mLngPM_VALUE_TYPE As Long
		Private mStrPM_VALUE As String
		Private mStrPM_VALUE_LANG_SRNO As String
		Private mStrPM_OPTIONS As String
		Private mLngPM_CREATE_USER_SRNO As Long
		Private mObjPM_CREATE_DATE_TIME As Date
		Private mLngPM_UPDATE_USER_SRNO As Long
		Private mObjPM_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpPM_PARAMETER_SRNO() As Long
      Get
        Return mLngPM_PARAMETER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngPM_PARAMETER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpPM_PARAMETER_DESC() As String
      Get
        Return mStrPM_PARAMETER_DESC
      End Get
      Set(ByVal value As String)
        mStrPM_PARAMETER_DESC = value
      End Set
    End Property
        
    Public Property mPrpPM_PARAMETER_NAME() As String
      Get
        Return mStrPM_PARAMETER_NAME
      End Get
      Set(ByVal value As String)
        mStrPM_PARAMETER_NAME = value
      End Set
    End Property
        
    Public Property mPrpPM_PARAMETER_NAME_LANG_SRNO() As String
      Get
        Return mStrPM_PARAMETER_NAME_LANG_SRNO
      End Get
      Set(ByVal value As String)
        mStrPM_PARAMETER_NAME_LANG_SRNO = value
      End Set
    End Property
        
    Public Property mPrpPM_PARAMETER_CATEGORY() As Long
      Get
        Return mLngPM_PARAMETER_CATEGORY
      End Get
      Set(ByVal value As Long)
        mLngPM_PARAMETER_CATEGORY = value
      End Set
    End Property
        
    Public Property mPrpPM_VALUE_TYPE() As Long
      Get
        Return mLngPM_VALUE_TYPE
      End Get
      Set(ByVal value As Long)
        mLngPM_VALUE_TYPE = value
      End Set
    End Property
        
    Public Property mPrpPM_VALUE() As String
      Get
        Return mStrPM_VALUE
      End Get
      Set(ByVal value As String)
        mStrPM_VALUE = value
      End Set
    End Property
        
    Public Property mPrpPM_VALUE_LANG_SRNO() As String
      Get
        Return mStrPM_VALUE_LANG_SRNO
      End Get
      Set(ByVal value As String)
        mStrPM_VALUE_LANG_SRNO = value
      End Set
    End Property
        
    Public Property mPrpPM_OPTIONS() As String
      Get
        Return mStrPM_OPTIONS
      End Get
      Set(ByVal value As String)
        mStrPM_OPTIONS = value
      End Set
    End Property
        
    Public Property mPrpPM_CREATE_USER_SRNO() As Long
      Get
        Return mLngPM_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngPM_CREATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpPM_CREATE_DATE_TIME() As Date
      Get
        Return mObjPM_CREATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjPM_CREATE_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpPM_UPDATE_USER_SRNO() As Long
      Get
        Return mLngPM_UPDATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngPM_UPDATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpPM_UPDATE_DATE_TIME() As Date
      Get
        Return mObjPM_UPDATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjPM_UPDATE_DATE_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngPM_PARAMETER_SRNO = 0
	  mStrPM_PARAMETER_DESC = String.Empty
	  mStrPM_PARAMETER_NAME = String.Empty
	  mStrPM_PARAMETER_NAME_LANG_SRNO = String.Empty
	  mLngPM_PARAMETER_CATEGORY = 0
	  mLngPM_VALUE_TYPE = 0
	  mStrPM_VALUE = String.Empty
	  mStrPM_VALUE_LANG_SRNO = String.Empty
	  mStrPM_OPTIONS = String.Empty
	  mLngPM_CREATE_USER_SRNO = 0
	  mObjPM_CREATE_DATE_TIME = New Date
	  mLngPM_UPDATE_USER_SRNO = 0
	  mObjPM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [PM_PARAMETER_SRNO] " & _
        ", [PM_PARAMETER_DESC] " & _
        ", [PM_PARAMETER_NAME] " & _
        ", [PM_PARAMETER_NAME_LANG_SRNO] " & _
        ", [PM_PARAMETER_CATEGORY] " & _
        ", [PM_VALUE_TYPE] " & _
        ", [PM_VALUE] " & _
        ", [PM_VALUE_LANG_SRNO] " & _
        ", [PM_OPTIONS] " & _
        ", [PM_CREATE_USER_SRNO] " & _
        ", [PM_CREATE_DATE_TIME] " & _
        ", [PM_UPDATE_USER_SRNO] " & _
        ", [PM_UPDATE_DATE_TIME] " & _
        "From [TB_PARAMETER_MASTER] " & _
        "Where " & _
        " [PM_PARAMETER_SRNO] = " & mLngPM_PARAMETER_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_PARAMETER_MASTER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([PM_PARAMETER_SRNO]) From [TB_PARAMETER_MASTER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_PARAMETER_MASTER] (" & _
        "  [PM_PARAMETER_SRNO] " & _
        ", [PM_PARAMETER_DESC] " & _
        ", [PM_PARAMETER_NAME] " & _
        ", [PM_PARAMETER_NAME_LANG_SRNO] " & _
        ", [PM_PARAMETER_CATEGORY] " & _
        ", [PM_VALUE_TYPE] " & _
        ", [PM_VALUE] " & _
        ", [PM_VALUE_LANG_SRNO] " & _
        ", [PM_OPTIONS] " & _
        ", [PM_CREATE_USER_SRNO] " & _
        ", [PM_CREATE_DATE_TIME] " & _
        ", [PM_UPDATE_USER_SRNO] " & _
        ", [PM_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngPM_PARAMETER_SRNO.ToString() & _
        ", " & "'" & mStrPM_PARAMETER_DESC & "'" & _
        ", " & "'" & mStrPM_PARAMETER_NAME & "'" & _
        ", " & "'" & mStrPM_PARAMETER_NAME_LANG_SRNO & "'" & _
        ", " & mLngPM_PARAMETER_CATEGORY.ToString() & _
        ", " & mLngPM_VALUE_TYPE.ToString() & _
        ", " & "'" & mStrPM_VALUE & "'" & _
        ", " & "'" & mStrPM_VALUE_LANG_SRNO & "'" & _
        ", " & "'" & mStrPM_OPTIONS & "'" & _
        ", " & mLngPM_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjPM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngPM_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjPM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_PARAMETER_MASTER] Set " & _
        "  [PM_PARAMETER_SRNO] = " & mLngPM_PARAMETER_SRNO.ToString() & _
        ", PM_PARAMETER_DESC = " & "'" & mStrPM_PARAMETER_DESC & "'" & _
        ", PM_PARAMETER_NAME = " & "'" & mStrPM_PARAMETER_NAME & "'" & _
        ", PM_PARAMETER_NAME_LANG_SRNO = " & "'" & mStrPM_PARAMETER_NAME_LANG_SRNO & "'" & _
        ", PM_PARAMETER_CATEGORY = " & mLngPM_PARAMETER_CATEGORY.ToString() & _
        ", PM_VALUE_TYPE = " & mLngPM_VALUE_TYPE.ToString() & _
        ", PM_VALUE = " & "'" & mStrPM_VALUE & "'" & _
        ", PM_VALUE_LANG_SRNO = " & "'" & mStrPM_VALUE_LANG_SRNO & "'" & _
        ", PM_OPTIONS = " & "'" & mStrPM_OPTIONS & "'" & _
        ", PM_CREATE_USER_SRNO = " & mLngPM_CREATE_USER_SRNO.ToString() & _
        ", PM_CREATE_DATE_TIME = " & "'" & mObjPM_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", PM_UPDATE_USER_SRNO = " & mLngPM_UPDATE_USER_SRNO.ToString() & _
        ", PM_UPDATE_DATE_TIME = " & "'" & mObjPM_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [PM_PARAMETER_SRNO] = " & mLngPM_PARAMETER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_PARAMETER_MASTER] " & _
        "Where " & _
        " [PM_PARAMETER_SRNO] = " & mLngPM_PARAMETER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_PARAMETER_MASTER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [PM_PARAMETER_SRNO] " & _
        ", [PM_PARAMETER_DESC] " & _
        ", [PM_PARAMETER_NAME] " & _
        ", [PM_PARAMETER_NAME_LANG_SRNO] " & _
        ", [PM_PARAMETER_CATEGORY] " & _
        ", [PM_VALUE_TYPE] " & _
        ", [PM_VALUE] " & _
        ", [PM_VALUE_LANG_SRNO] " & _
        ", [PM_OPTIONS] " & _
        ", [PM_CREATE_USER_SRNO] " & _
        ", [PM_CREATE_DATE_TIME] " & _
        ", [PM_UPDATE_USER_SRNO] " & _
        ", [PM_UPDATE_DATE_TIME] " & _
        "From [TB_PARAMETER_MASTER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngPM_PARAMETER_SRNO = mFnPopulate(aObjDataReader,"PM_PARAMETER_SRNO")
      mStrPM_PARAMETER_DESC = mFnPopulate(aObjDataReader,"PM_PARAMETER_DESC")
      mStrPM_PARAMETER_NAME = mFnPopulate(aObjDataReader,"PM_PARAMETER_NAME")
      mStrPM_PARAMETER_NAME_LANG_SRNO = mFnPopulate(aObjDataReader,"PM_PARAMETER_NAME_LANG_SRNO")
      mLngPM_PARAMETER_CATEGORY = mFnPopulate(aObjDataReader,"PM_PARAMETER_CATEGORY")
      mLngPM_VALUE_TYPE = mFnPopulate(aObjDataReader,"PM_VALUE_TYPE")
      mStrPM_VALUE = mFnPopulate(aObjDataReader,"PM_VALUE")
      mStrPM_VALUE_LANG_SRNO = mFnPopulate(aObjDataReader,"PM_VALUE_LANG_SRNO")
      mStrPM_OPTIONS = mFnPopulate(aObjDataReader,"PM_OPTIONS")
      mLngPM_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"PM_CREATE_USER_SRNO")
      mObjPM_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"PM_CREATE_DATE_TIME")
      mLngPM_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"PM_UPDATE_USER_SRNO")
      mObjPM_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"PM_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngPM_PARAMETER_SRNO = 0
	  mStrPM_PARAMETER_DESC = String.Empty
	  mStrPM_PARAMETER_NAME = String.Empty
	  mStrPM_PARAMETER_NAME_LANG_SRNO = String.Empty
	  mLngPM_PARAMETER_CATEGORY = 0
	  mLngPM_VALUE_TYPE = 0
	  mStrPM_VALUE = String.Empty
	  mStrPM_VALUE_LANG_SRNO = String.Empty
	  mStrPM_OPTIONS = String.Empty
	  mLngPM_CREATE_USER_SRNO = 0
	  mObjPM_CREATE_DATE_TIME = New Date
	  mLngPM_UPDATE_USER_SRNO = 0
	  mObjPM_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_PARAMETER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_PARAMETER_DESC", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_PARAMETER_NAME", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_PARAMETER_NAME_LANG_SRNO", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_PARAMETER_CATEGORY", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_VALUE_TYPE", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_VALUE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_VALUE_LANG_SRNO", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_OPTIONS", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("PM_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
