Imports NUnit.Framework
Imports DataAccess
Imports Utils

Namespace Manage.Test

  ''' <summary>
  ''' Tests for the clsParameterManager Class 
  ''' </summary>
  ''' <remarks></remarks>
  <TestFixture()> _
  Public Class clsParameterManagerTest

    Private mObjclsParameterManager As clsParameterManager

#Region "SETUP\CLEANUP"

    ''' <summary>
    ''' Code that is run once for a suite of tests
    ''' </summary>
    <TestFixtureSetUp()> _
    Public Sub mPrTestFixtureSetup()
      '数据库目录
      clsConnectionManager.mPrpSystemDBPath = "C:\Users\810124.CFETS-3245\Desktop\tbwebframework\Framework\WebSite\Database\DB.dat"
    End Sub

    ''' <summary>
    ''' Code that is run once after a suite of tests has finished executing
    ''' </summary>
    <TestFixtureTearDown()> _
    Public Sub mPrTestFixtureTearDown()

    End Sub

    ''' <summary>
    ''' Code that is run before each test
    ''' </summary>
    ''' <remarks></remarks>
    <SetUp()> _
    Public Sub mPrInitialize()
      'New instance of clsParameterManager
      mObjclsParameterManager = New clsParameterManager
    End Sub

    ''' <summary>
    ''' Code that is run after each test
    ''' </summary>
    ''' <remarks></remarks>
    <TearDown()> _
    Public Sub mPrCleanup()
      'TODO: Put dispose in here for clsCommonServices or delete this line
    End Sub
#End Region

    <Test()> _
    Public Sub mPrTestPopulateParameter()

      Assert.AreEqual("管理中心", clsParameterManager.mFnGetParameters(GP_WEB_SITE_NAME))

    End Sub

  End Class

End Namespace
