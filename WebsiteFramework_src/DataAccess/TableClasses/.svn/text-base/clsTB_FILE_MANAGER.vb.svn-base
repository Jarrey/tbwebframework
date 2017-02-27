
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar.Bob
'*   Date         : 2010/1/15 10:00:56
'*   Synopsis     : Table Class for Table 
'*                          DB / TB_FILE_MANAGER
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

  Public Class clsTB_FILE_MANAGER
    Inherits clsDataAccess
    
#Region "CLASS DATABASE COLUMNS"

		Private mLngFM_FILE_SRNO As Long
		Private mObjFM_DATE_TIME As Date
		Private mStrFM_FILE_NAME As String
		Private mStrFM_FILE_PATH As String
		Private mStrFM_FILE_CATEGORY As String
		Private mLngFM_STATUS As Long
		Private mLngFM_UPDATE_USER_SRNO As Long
		Private mObjFM_UPDATE_TIME As Date
   
#End Region

#Region "CLASS PROPERTIES"

        Public Property mPrpFM_FILE_SRNO() As Long
            Get
                Return mLngFM_FILE_SRNO
            End Get
            Set(ByVal value As Long)
                mLngFM_FILE_SRNO = value
            End Set
        End Property
        
        Public Property mPrpFM_DATE_TIME() As Date
            Get
                Return mObjFM_DATE_TIME
            End Get
            Set(ByVal value As Date)
                mObjFM_DATE_TIME = value
            End Set
        End Property
        
        Public Property mPrpFM_FILE_NAME() As String
            Get
                Return mStrFM_FILE_NAME
            End Get
            Set(ByVal value As String)
                mStrFM_FILE_NAME = value
            End Set
        End Property
        
        Public Property mPrpFM_FILE_PATH() As String
            Get
                Return mStrFM_FILE_PATH
            End Get
            Set(ByVal value As String)
                mStrFM_FILE_PATH = value
            End Set
        End Property
        
        Public Property mPrpFM_FILE_CATEGORY() As String
            Get
                Return mStrFM_FILE_CATEGORY
            End Get
            Set(ByVal value As String)
                mStrFM_FILE_CATEGORY = value
            End Set
        End Property
        
        Public Property mPrpFM_STATUS() As Long
            Get
                Return mLngFM_STATUS
            End Get
            Set(ByVal value As Long)
                mLngFM_STATUS = value
            End Set
        End Property
        
        Public Property mPrpFM_UPDATE_USER_SRNO() As Long
            Get
                Return mLngFM_UPDATE_USER_SRNO
            End Get
            Set(ByVal value As Long)
                mLngFM_UPDATE_USER_SRNO = value
            End Set
        End Property
        
        Public Property mPrpFM_UPDATE_TIME() As Date
            Get
                Return mObjFM_UPDATE_TIME
            End Get
            Set(ByVal value As Date)
                mObjFM_UPDATE_TIME = value
            End Set
        End Property
        
    
#End Region
   
#Region "CLASS CONSTRUCTOR"

    Public Sub New()
      mPrpConnectionDB = clsConnectionManager.enmConnectionDB.SYSTEM_DB
      mPrInitializeData()
    End Sub

    Private Sub mPrInitializeData()
	  mLngFM_FILE_SRNO = 0
	  mObjFM_DATE_TIME = New Date
	  mStrFM_FILE_NAME = String.Empty
	  mStrFM_FILE_PATH = String.Empty
	  mStrFM_FILE_CATEGORY = String.Empty
	  mLngFM_STATUS = 0
	  mLngFM_UPDATE_USER_SRNO = 0
	  mObjFM_UPDATE_TIME = New Date
    End Sub

#End Region

#Region "CLASS MEMBER FUNCTIONS"

#Region "SELECT"

    Private Sub mPrSelect(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String
      lStrSQLString = _
        "Select " & _
        "  [FM_FILE_SRNO] " & _
        ", [FM_DATE_TIME] " & _
        ", [FM_FILE_NAME] " & _
        ", [FM_FILE_PATH] " & _
        ", [FM_FILE_CATEGORY] " & _
        ", [FM_STATUS] " & _
        ", [FM_UPDATE_USER_SRNO] " & _
        ", [FM_UPDATE_TIME] " & _
        "From [TB_FILE_MANAGER] " & _
        "Where " & _
        " [FM_FILE_SRNO] = " & mLngFM_FILE_SRNO.ToString() & _
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
      	"Select Count(*) From [TB_FILE_MANAGER]"
      	
      Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "MAX ID"

		Public Function mFnMaxId() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
      	"Select Max([FM_FILE_SRNO]) From [TB_FILE_MANAGER]"

      If IsDbNull(mFnExecuteScalar(lStrSQLString)) Then Return 0 Else Return mFnExecuteScalar(lStrSQLString)
    End Function

#End Region

#Region "INSERT"

    Public Function mFnInsert() As Integer
      Dim lStrSQLString As String

      lStrSQLString = _
        "Insert Into [TB_FILE_MANAGER] (" & _
        "  [FM_FILE_SRNO] " & _
        ", [FM_DATE_TIME] " & _
        ", [FM_FILE_NAME] " & _
        ", [FM_FILE_PATH] " & _
        ", [FM_FILE_CATEGORY] " & _
        ", [FM_STATUS] " & _
        ", [FM_UPDATE_USER_SRNO] " & _
        ", [FM_UPDATE_TIME] " & _
        " ) Values ( " & _
         mLngFM_FILE_SRNO.ToString() & _
        ", " & "'" & mObjFM_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", " & "'" & mStrFM_FILE_NAME & "'" & _
        ", " & "'" & mStrFM_FILE_PATH & "'" & _
        ", " & "'" & mStrFM_FILE_CATEGORY & "'" & _
        ", " & mLngFM_STATUS.ToString() & _
        ", " & mLngFM_UPDATE_USER_SRNO.ToString() & _
        ", " & "'" & mObjFM_UPDATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ")"

      Return mFnExecuteNonQuery(lStrSQLString)
    End Function

#End Region

#Region "UPDATE"

    Public Function mFnUpdate() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Update [TB_FILE_MANAGER] Set " & _
        "  [FM_FILE_SRNO] = " & mLngFM_FILE_SRNO.ToString() & _
        ", FM_DATE_TIME = " & "'" & mObjFM_DATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        ", FM_FILE_NAME = " & "'" & mStrFM_FILE_NAME & "'" & _
        ", FM_FILE_PATH = " & "'" & mStrFM_FILE_PATH & "'" & _
        ", FM_FILE_CATEGORY = " & "'" & mStrFM_FILE_CATEGORY & "'" & _
        ", FM_STATUS = " & mLngFM_STATUS.ToString() & _
        ", FM_UPDATE_USER_SRNO = " & mLngFM_UPDATE_USER_SRNO.ToString() & _
        ", FM_UPDATE_TIME = " & "'" & mObjFM_UPDATE_TIME.ToString(CONST_DATE_TIME_FORMAT) & "'" & _
        " Where " & _
        " [FM_FILE_SRNO] = " & mLngFM_FILE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE"

    Public Function mFnDelete() As Integer

      Dim lStrSQLString As String
      lStrSQLString = _
        "Delete From [TB_FILE_MANAGER] " & _
        "Where " & _
        " [FM_FILE_SRNO] = " & mLngFM_FILE_SRNO.ToString() & _
        ""

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function

#End Region

#Region "DELETE ALL"

    Public Function mFnDeleteAll() As Integer

      Dim lStrSQLString As String

      lStrSQLString = "Delete from [TB_FILE_MANAGER] "

      Return mFnExecuteNonQuery(lStrSQLString)

    End Function
#End Region

#Region "SELECT ALL"

    Private Sub mPrSelectAll(ByRef aObjDataTarget As Object, Optional ByVal aEnmReturnIndc As enmReturnIndc = enmReturnIndc.DATA_SET)

      Dim lStrSQLString As String

      lStrSQLString = _
        "Select " & _
        "  [FM_FILE_SRNO] " & _
        ", [FM_DATE_TIME] " & _
        ", [FM_FILE_NAME] " & _
        ", [FM_FILE_PATH] " & _
        ", [FM_FILE_CATEGORY] " & _
        ", [FM_STATUS] " & _
        ", [FM_UPDATE_USER_SRNO] " & _
        ", [FM_UPDATE_TIME] " & _
        "From [TB_FILE_MANAGER]"

      If aEnmReturnIndc = enmReturnIndc.DATA_SET Then
        aObjDataTarget = mFnExecuteQueryAsDataSet(lStrSQLString)
      ElseIf aEnmReturnIndc = enmReturnIndc.DATA_READER Then
        aObjDataTarget = mFnExecuteQueryAsDataReader(lStrSQLString)
      End If

    End Sub

#End Region

#Region "POPULATE ALL"

    Private Sub mPrPopulateAll(ByVal aObjDataReader As SQLiteDataReader)
        mLngFM_FILE_SRNO = mFnPopulate(aObjDataReader,"FM_FILE_SRNO")
        mObjFM_DATE_TIME = mFnPopulate(aObjDataReader,"FM_DATE_TIME")
        mStrFM_FILE_NAME = mFnPopulate(aObjDataReader,"FM_FILE_NAME")
        mStrFM_FILE_PATH = mFnPopulate(aObjDataReader,"FM_FILE_PATH")
        mStrFM_FILE_CATEGORY = mFnPopulate(aObjDataReader,"FM_FILE_CATEGORY")
        mLngFM_STATUS = mFnPopulate(aObjDataReader,"FM_STATUS")
        mLngFM_UPDATE_USER_SRNO = mFnPopulate(aObjDataReader,"FM_UPDATE_USER_SRNO")
        mObjFM_UPDATE_TIME = mFnPopulate(aObjDataReader,"FM_UPDATE_TIME")
    End Sub

#End Region

#Region "CLEAR DB ENTITIES"

    Public Sub mPrClearDBEntities()
	  mLngFM_FILE_SRNO = 0
	  mObjFM_DATE_TIME = New Date
	  mStrFM_FILE_NAME = String.Empty
	  mStrFM_FILE_PATH = String.Empty
	  mStrFM_FILE_CATEGORY = String.Empty
	  mLngFM_STATUS = 0
	  mLngFM_UPDATE_USER_SRNO = 0
	  mObjFM_UPDATE_TIME = New Date
    End Sub

#End Region

#Region "GET DATA TABLE"

    Public Function mFnGetEmptyDataTable() As DataTable
      Dim lObjRtnDataTable As DataTable = New DataTable
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_FILE_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_DATE_TIME", GetType(Date)))
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_FILE_NAME", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_FILE_PATH", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_FILE_CATEGORY", GetType(String)))
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_STATUS", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_UPDATE_USER_SRNO", GetType(Long)))
			lObjRtnDataTable.Columns.Add(New DataColumn("FM_UPDATE_TIME", GetType(Date)))
      Return lObjRtnDataTable
    End Function
    
#End Region

#End Region

  End Class

End Namespace
