
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/2/3 13:37:14
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_USER_DTLS
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

  Public Class clsTB_USER_DTLS
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngUD_USER_SRNO As Long
		Private mStrUD_USER_NAME As String
		Private mLngUD_USER_SEX As Long
		Private mObjUD_USER_BIRTHDAY As Date
		Private mLngUD_USER_BLOOD_TYPE As Long
		Private mStrUD_USER_TEL As String
		Private mStrUD_USER_MOBLIE As String
		Private mStrUD_USER_EMAIL As String
		Private mStrUD_USER_ADDRS As String
		Private mStrUD_USER_COUNTRY As String
		Private mStrUD_USER_DESC As String
		Private mLngUD_USER_CATEGORY As Long
		Private mLngUD_USER_STATUS As Long
		Private mLngUD_CREATE_USER_SRNO As Long
		Private mObjUD_CREATE_DATE_TIME As Date
		Private mLngUD_UPDAET_USER_SRNO As Long
		Private mObjUD_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

    Public Property mPrpUD_USER_SRNO() As Long
      Get
        Return mLngUD_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngUD_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_NAME() As String
      Get
        Return mStrUD_USER_NAME
      End Get
      Set(ByVal value As String)
        mStrUD_USER_NAME = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_SEX() As Long
      Get
        Return mLngUD_USER_SEX
      End Get
      Set(ByVal value As Long)
        mLngUD_USER_SEX = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_BIRTHDAY() As Date
      Get
        Return mObjUD_USER_BIRTHDAY
      End Get
      Set(ByVal value As Date)
        mObjUD_USER_BIRTHDAY = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_BLOOD_TYPE() As Long
      Get
        Return mLngUD_USER_BLOOD_TYPE
      End Get
      Set(ByVal value As Long)
        mLngUD_USER_BLOOD_TYPE = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_TEL() As String
      Get
        Return mStrUD_USER_TEL
      End Get
      Set(ByVal value As String)
        mStrUD_USER_TEL = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_MOBLIE() As String
      Get
        Return mStrUD_USER_MOBLIE
      End Get
      Set(ByVal value As String)
        mStrUD_USER_MOBLIE = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_EMAIL() As String
      Get
        Return mStrUD_USER_EMAIL
      End Get
      Set(ByVal value As String)
        mStrUD_USER_EMAIL = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_ADDRS() As String
      Get
        Return mStrUD_USER_ADDRS
      End Get
      Set(ByVal value As String)
        mStrUD_USER_ADDRS = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_COUNTRY() As String
      Get
        Return mStrUD_USER_COUNTRY
      End Get
      Set(ByVal value As String)
        mStrUD_USER_COUNTRY = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_DESC() As String
      Get
        Return mStrUD_USER_DESC
      End Get
      Set(ByVal value As String)
        mStrUD_USER_DESC = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_CATEGORY() As Long
      Get
        Return mLngUD_USER_CATEGORY
      End Get
      Set(ByVal value As Long)
        mLngUD_USER_CATEGORY = value
      End Set
    End Property
        
    Public Property mPrpUD_USER_STATUS() As Long
      Get
        Return mLngUD_USER_STATUS
      End Get
      Set(ByVal value As Long)
        mLngUD_USER_STATUS = value
      End Set
    End Property
        
    Public Property mPrpUD_CREATE_USER_SRNO() As Long
      Get
        Return mLngUD_CREATE_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngUD_CREATE_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpUD_CREATE_DATE_TIME() As Date
      Get
        Return mObjUD_CREATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjUD_CREATE_DATE_TIME = value
      End Set
    End Property
        
    Public Property mPrpUD_UPDAET_USER_SRNO() As Long
      Get
        Return mLngUD_UPDAET_USER_SRNO
      End Get
      Set(ByVal value As Long)
        mLngUD_UPDAET_USER_SRNO = value
      End Set
    End Property
        
    Public Property mPrpUD_UPDATE_DATE_TIME() As Date
      Get
        Return mObjUD_UPDATE_DATE_TIME
      End Get
      Set(ByVal value As Date)
        mObjUD_UPDATE_DATE_TIME = value
      End Set
    End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngUD_USER_SRNO = 0
	  mStrUD_USER_NAME = String.Empty
	  mLngUD_USER_SEX = 0
	  mObjUD_USER_BIRTHDAY = New Date
	  mLngUD_USER_BLOOD_TYPE = 0
	  mStrUD_USER_TEL = String.Empty
	  mStrUD_USER_MOBLIE = String.Empty
	  mStrUD_USER_EMAIL = String.Empty
	  mStrUD_USER_ADDRS = String.Empty
	  mStrUD_USER_COUNTRY = String.Empty
	  mStrUD_USER_DESC = String.Empty
	  mLngUD_USER_CATEGORY = 0
	  mLngUD_USER_STATUS = 0
	  mLngUD_CREATE_USER_SRNO = 0
	  mObjUD_CREATE_DATE_TIME = New Date
	  mLngUD_UPDAET_USER_SRNO = 0
	  mObjUD_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [UD_USER_SRNO] " & _
        ", [UD_USER_NAME] " & _
        ", [UD_USER_SEX] " & _
        ", [UD_USER_BIRTHDAY] " & _
        ", [UD_USER_BLOOD_TYPE] " & _
        ", [UD_USER_TEL] " & _
        ", [UD_USER_MOBLIE] " & _
        ", [UD_USER_EMAIL] " & _
        ", [UD_USER_ADDRS] " & _
        ", [UD_USER_COUNTRY] " & _
        ", [UD_USER_DESC] " & _
        ", [UD_USER_CATEGORY] " & _
        ", [UD_USER_STATUS] " & _
        ", [UD_CREATE_USER_SRNO] " & _
        ", [UD_CREATE_DATE_TIME] " & _
        ", [UD_UPDAET_USER_SRNO] " & _
        ", [UD_UPDATE_DATE_TIME] " & _
        "From [TB_USER_DTLS] " & _
        "Where " & _
        " [UD_USER_SRNO] = " & mLngUD_USER_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_USER_DTLS]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([UD_USER_SRNO]) From [TB_USER_DTLS]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_USER_DTLS] (" & _
        "  [UD_USER_SRNO] " & _
        ", [UD_USER_NAME] " & _
        ", [UD_USER_SEX] " & _
        ", [UD_USER_BIRTHDAY] " & _
        ", [UD_USER_BLOOD_TYPE] " & _
        ", [UD_USER_TEL] " & _
        ", [UD_USER_MOBLIE] " & _
        ", [UD_USER_EMAIL] " & _
        ", [UD_USER_ADDRS] " & _
        ", [UD_USER_COUNTRY] " & _
        ", [UD_USER_DESC] " & _
        ", [UD_USER_CATEGORY] " & _
        ", [UD_USER_STATUS] " & _
        ", [UD_CREATE_USER_SRNO] " & _
        ", [UD_CREATE_DATE_TIME] " & _
        ", [UD_UPDAET_USER_SRNO] " & _
        ", [UD_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngUD_USER_SRNO.ToString() & _
        ", " & "'" & mStrUD_USER_NAME & "'" & _
        ", " & mLngUD_USER_SEX.ToString() & _
        ", " & "'" & mObjUD_USER_BIRTHDAY.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngUD_USER_BLOOD_TYPE.ToString() & _
        ", " & "'" & mStrUD_USER_TEL & "'" & _
        ", " & "'" & mStrUD_USER_MOBLIE & "'" & _
        ", " & "'" & mStrUD_USER_EMAIL & "'" & _
        ", " & "'" & mStrUD_USER_ADDRS & "'" & _
        ", " & "'" & mStrUD_USER_COUNTRY & "'" & _
        ", " & "'" & mStrUD_USER_DESC & "'" & _
        ", " & mLngUD_USER_CATEGORY.ToString() & _
        ", " & mLngUD_USER_STATUS.ToString() & _
        ", " & mLngUD_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjUD_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngUD_UPDAET_USER_SRNO.ToString() & _
        ", " & "'" & mObjUD_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_USER_DTLS] Set " & _
        "  [UD_USER_SRNO] = " & mLngUD_USER_SRNO.ToString() & _
        ", UD_USER_NAME = " & "'" & mStrUD_USER_NAME & "'" & _
        ", UD_USER_SEX = " & mLngUD_USER_SEX.ToString() & _
        ", UD_USER_BIRTHDAY = " & "'" & mObjUD_USER_BIRTHDAY.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", UD_USER_BLOOD_TYPE = " & mLngUD_USER_BLOOD_TYPE.ToString() & _
        ", UD_USER_TEL = " & "'" & mStrUD_USER_TEL & "'" & _
        ", UD_USER_MOBLIE = " & "'" & mStrUD_USER_MOBLIE & "'" & _
        ", UD_USER_EMAIL = " & "'" & mStrUD_USER_EMAIL & "'" & _
        ", UD_USER_ADDRS = " & "'" & mStrUD_USER_ADDRS & "'" & _
        ", UD_USER_COUNTRY = " & "'" & mStrUD_USER_COUNTRY & "'" & _
        ", UD_USER_DESC = " & "'" & mStrUD_USER_DESC & "'" & _
        ", UD_USER_CATEGORY = " & mLngUD_USER_CATEGORY.ToString() & _
        ", UD_USER_STATUS = " & mLngUD_USER_STATUS.ToString() & _
        ", UD_CREATE_USER_SRNO = " & mLngUD_CREATE_USER_SRNO.ToString() & _
        ", UD_CREATE_DATE_TIME = " & "'" & mObjUD_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", UD_UPDAET_USER_SRNO = " & mLngUD_UPDAET_USER_SRNO.ToString() & _
        ", UD_UPDATE_DATE_TIME = " & "'" & mObjUD_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [UD_USER_SRNO] = " & mLngUD_USER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_USER_DTLS] " & _
        "Where " & _
        " [UD_USER_SRNO] = " & mLngUD_USER_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_USER_DTLS] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [UD_USER_SRNO] " & _
        ", [UD_USER_NAME] " & _
        ", [UD_USER_SEX] " & _
        ", [UD_USER_BIRTHDAY] " & _
        ", [UD_USER_BLOOD_TYPE] " & _
        ", [UD_USER_TEL] " & _
        ", [UD_USER_MOBLIE] " & _
        ", [UD_USER_EMAIL] " & _
        ", [UD_USER_ADDRS] " & _
        ", [UD_USER_COUNTRY] " & _
        ", [UD_USER_DESC] " & _
        ", [UD_USER_CATEGORY] " & _
        ", [UD_USER_STATUS] " & _
        ", [UD_CREATE_USER_SRNO] " & _
        ", [UD_CREATE_DATE_TIME] " & _
        ", [UD_UPDAET_USER_SRNO] " & _
        ", [UD_UPDATE_DATE_TIME] " & _
        "From [TB_USER_DTLS]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
      mLngUD_USER_SRNO = mFnPopulate(aObjDataReader,"UD_USER_SRNO")
      mStrUD_USER_NAME = mFnPopulate(aObjDataReader,"UD_USER_NAME")
      mLngUD_USER_SEX = mFnPopulate(aObjDataReader,"UD_USER_SEX")
      mObjUD_USER_BIRTHDAY = mFnPopulate(aObjDataReader,"UD_USER_BIRTHDAY")
      mLngUD_USER_BLOOD_TYPE = mFnPopulate(aObjDataReader,"UD_USER_BLOOD_TYPE")
      mStrUD_USER_TEL = mFnPopulate(aObjDataReader,"UD_USER_TEL")
      mStrUD_USER_MOBLIE = mFnPopulate(aObjDataReader,"UD_USER_MOBLIE")
      mStrUD_USER_EMAIL = mFnPopulate(aObjDataReader,"UD_USER_EMAIL")
      mStrUD_USER_ADDRS = mFnPopulate(aObjDataReader,"UD_USER_ADDRS")
      mStrUD_USER_COUNTRY = mFnPopulate(aObjDataReader,"UD_USER_COUNTRY")
      mStrUD_USER_DESC = mFnPopulate(aObjDataReader,"UD_USER_DESC")
      mLngUD_USER_CATEGORY = mFnPopulate(aObjDataReader,"UD_USER_CATEGORY")
      mLngUD_USER_STATUS = mFnPopulate(aObjDataReader,"UD_USER_STATUS")
      mLngUD_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"UD_CREATE_USER_SRNO")
      mObjUD_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"UD_CREATE_DATE_TIME")
      mLngUD_UPDAET_USER_SRNO = mFnPopulate(aObjDataReader,"UD_UPDAET_USER_SRNO")
      mObjUD_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"UD_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngUD_USER_SRNO = 0
	  mStrUD_USER_NAME = String.Empty
	  mLngUD_USER_SEX = 0
	  mObjUD_USER_BIRTHDAY = New Date
	  mLngUD_USER_BLOOD_TYPE = 0
	  mStrUD_USER_TEL = String.Empty
	  mStrUD_USER_MOBLIE = String.Empty
	  mStrUD_USER_EMAIL = String.Empty
	  mStrUD_USER_ADDRS = String.Empty
	  mStrUD_USER_COUNTRY = String.Empty
	  mStrUD_USER_DESC = String.Empty
	  mLngUD_USER_CATEGORY = 0
	  mLngUD_USER_STATUS = 0
	  mLngUD_CREATE_USER_SRNO = 0
	  mObjUD_CREATE_DATE_TIME = New Date
	  mLngUD_UPDAET_USER_SRNO = 0
	  mObjUD_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_NAME", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_SEX", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_BIRTHDAY", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_BLOOD_TYPE", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_TEL", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_MOBLIE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_EMAIL", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_ADDRS", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_COUNTRY", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_DESC", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_CATEGORY", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_USER_STATUS", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_UPDAET_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UD_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
