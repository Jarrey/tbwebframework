
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/1/15 10:00:56
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_USER_CUSTOM_DTLS
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

  Public Class clsTB_USER_CUSTOM_DTLS
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngUCD_ITEM_SRNO As Long
		Private mStrUCD_ITEM_CODE As String
		Private mStrUCD_ITEM_NAME As String
		Private mLngUCD_ITEM_CATEGORY As Long
		Private mLngUCD_ITEM_STATUS As Long
		Private mLngUCD_CREATE_USER_SRNO As Long
		Private mObjUCD_CREATE_DATE_TIME As Date
		Private mLngUCD_UPDATE_USER_SRNO As Long
		Private mObjUCD_UPDATE_DATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

        Public Property mPrpUCD_ITEM_SRNO() As Long
            Get
                Return mLngUCD_ITEM_SRNO
            End Get
            Set(ByVal value As Long)
                mLngUCD_ITEM_SRNO = value
            End Set
        End Property
        
        Public Property mPrpUCD_ITEM_CODE() As String
            Get
                Return mStrUCD_ITEM_CODE
            End Get
            Set(ByVal value As String)
                mStrUCD_ITEM_CODE = value
            End Set
        End Property
        
        Public Property mPrpUCD_ITEM_NAME() As String
            Get
                Return mStrUCD_ITEM_NAME
            End Get
            Set(ByVal value As String)
                mStrUCD_ITEM_NAME = value
            End Set
        End Property
        
        Public Property mPrpUCD_ITEM_CATEGORY() As Long
            Get
                Return mLngUCD_ITEM_CATEGORY
            End Get
            Set(ByVal value As Long)
                mLngUCD_ITEM_CATEGORY = value
            End Set
        End Property
        
        Public Property mPrpUCD_ITEM_STATUS() As Long
            Get
                Return mLngUCD_ITEM_STATUS
            End Get
            Set(ByVal value As Long)
                mLngUCD_ITEM_STATUS = value
            End Set
        End Property
        
        Public Property mPrpUCD_CREATE_USER_SRNO() As Long
            Get
                Return mLngUCD_CREATE_USER_SRNO
            End Get
            Set(ByVal value As Long)
                mLngUCD_CREATE_USER_SRNO = value
            End Set
        End Property
        
        Public Property mPrpUCD_CREATE_DATE_TIME() As Date
            Get
                Return mObjUCD_CREATE_DATE_TIME
            End Get
            Set(ByVal value As Date)
                mObjUCD_CREATE_DATE_TIME = value
            End Set
        End Property
        
        Public Property mPrpUCD_UPDATE_USER_SRNO() As Long
            Get
                Return mLngUCD_UPDATE_USER_SRNO
            End Get
            Set(ByVal value As Long)
                mLngUCD_UPDATE_USER_SRNO = value
            End Set
        End Property
        
        Public Property mPrpUCD_UPDATE_DATE_TIME() As Date
            Get
                Return mObjUCD_UPDATE_DATE_TIME
            End Get
            Set(ByVal value As Date)
                mObjUCD_UPDATE_DATE_TIME = value
            End Set
        End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngUCD_ITEM_SRNO = 0
	  mStrUCD_ITEM_CODE = String.Empty
	  mStrUCD_ITEM_NAME = String.Empty
	  mLngUCD_ITEM_CATEGORY = 0
	  mLngUCD_ITEM_STATUS = 0
	  mLngUCD_CREATE_USER_SRNO = 0
	  mObjUCD_CREATE_DATE_TIME = New Date
	  mLngUCD_UPDATE_USER_SRNO = 0
	  mObjUCD_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [UCD_ITEM_SRNO] " & _
        ", [UCD_ITEM_CODE] " & _
        ", [UCD_ITEM_NAME] " & _
        ", [UCD_ITEM_CATEGORY] " & _
        ", [UCD_ITEM_STATUS] " & _
        ", [UCD_CREATE_USER_SRNO] " & _
        ", [UCD_CREATE_DATE_TIME] " & _
        ", [UCD_UPDATE_USER_SRNO] " & _
        ", [UCD_UPDATE_DATE_TIME] " & _
        "From [TB_USER_CUSTOM_DTLS] " & _
        "Where " & _
        " [UCD_ITEM_SRNO] = " & mLngUCD_ITEM_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_USER_CUSTOM_DTLS]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([UCD_ITEM_SRNO]) From [TB_USER_CUSTOM_DTLS]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_USER_CUSTOM_DTLS] (" & _
        "  [UCD_ITEM_SRNO] " & _
        ", [UCD_ITEM_CODE] " & _
        ", [UCD_ITEM_NAME] " & _
        ", [UCD_ITEM_CATEGORY] " & _
        ", [UCD_ITEM_STATUS] " & _
        ", [UCD_CREATE_USER_SRNO] " & _
        ", [UCD_CREATE_DATE_TIME] " & _
        ", [UCD_UPDATE_USER_SRNO] " & _
        ", [UCD_UPDATE_DATE_TIME] " & _
        " ) Values ( " & _
         mLngUCD_ITEM_SRNO.ToString() & _
        ", " & "'" & mStrUCD_ITEM_CODE & "'" & _
        ", " & "'" & mStrUCD_ITEM_NAME & "'" & _
        ", " & mLngUCD_ITEM_CATEGORY.ToString() & _
        ", " & mLngUCD_ITEM_STATUS.ToString() & _
        ", " & mLngUCD_CREATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjUCD_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & mLngUCD_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjUCD_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_USER_CUSTOM_DTLS] Set " & _
        "  [UCD_ITEM_SRNO] = " & mLngUCD_ITEM_SRNO.ToString() & _
        ", UCD_ITEM_CODE = " & "'" & mStrUCD_ITEM_CODE & "'" & _
        ", UCD_ITEM_NAME = " & "'" & mStrUCD_ITEM_NAME & "'" & _
        ", UCD_ITEM_CATEGORY = " & mLngUCD_ITEM_CATEGORY.ToString() & _
        ", UCD_ITEM_STATUS = " & mLngUCD_ITEM_STATUS.ToString() & _
        ", UCD_CREATE_USER_SRNO = " & mLngUCD_CREATE_USER_SRNO.ToString() & _
        ", UCD_CREATE_DATE_TIME = " & "'" & mObjUCD_CREATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", UCD_UPDATE_USER_SRNO = " & mLngUCD_UPDATE_USER_SRNO.ToString() & _
        ", UCD_UPDATE_DATE_TIME = " & "'" & mObjUCD_UPDATE_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [UCD_ITEM_SRNO] = " & mLngUCD_ITEM_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_USER_CUSTOM_DTLS] " & _
        "Where " & _
        " [UCD_ITEM_SRNO] = " & mLngUCD_ITEM_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_USER_CUSTOM_DTLS] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [UCD_ITEM_SRNO] " & _
        ", [UCD_ITEM_CODE] " & _
        ", [UCD_ITEM_NAME] " & _
        ", [UCD_ITEM_CATEGORY] " & _
        ", [UCD_ITEM_STATUS] " & _
        ", [UCD_CREATE_USER_SRNO] " & _
        ", [UCD_CREATE_DATE_TIME] " & _
        ", [UCD_UPDATE_USER_SRNO] " & _
        ", [UCD_UPDATE_DATE_TIME] " & _
        "From [TB_USER_CUSTOM_DTLS]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
        mLngUCD_ITEM_SRNO = mFnPopulate(aObjDataReader,"UCD_ITEM_SRNO")
        mStrUCD_ITEM_CODE = mFnPopulate(aObjDataReader,"UCD_ITEM_CODE")
        mStrUCD_ITEM_NAME = mFnPopulate(aObjDataReader,"UCD_ITEM_NAME")
        mLngUCD_ITEM_CATEGORY = mFnPopulate(aObjDataReader,"UCD_ITEM_CATEGORY")
        mLngUCD_ITEM_STATUS = mFnPopulate(aObjDataReader,"UCD_ITEM_STATUS")
        mLngUCD_CREATE_USER_SRNO = mFnPopulate(aObjDataReader,"UCD_CREATE_USER_SRNO")
        mObjUCD_CREATE_DATE_TIME = mFnPopulate(aObjDataReader,"UCD_CREATE_DATE_TIME")
        mLngUCD_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"UCD_UPDATE_USER_SRNO")
        mObjUCD_UPDATE_DATE_TIME = mFnPopulate(aObjDataReader,"UCD_UPDATE_DATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngUCD_ITEM_SRNO = 0
	  mStrUCD_ITEM_CODE = String.Empty
	  mStrUCD_ITEM_NAME = String.Empty
	  mLngUCD_ITEM_CATEGORY = 0
	  mLngUCD_ITEM_STATUS = 0
	  mLngUCD_CREATE_USER_SRNO = 0
	  mObjUCD_CREATE_DATE_TIME = New Date
	  mLngUCD_UPDATE_USER_SRNO = 0
	  mObjUCD_UPDATE_DATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_ITEM_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_ITEM_CODE", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_ITEM_NAME", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_ITEM_CATEGORY", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_ITEM_STATUS", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_CREATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_CREATE_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("UCD_UPDATE_DATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
