
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-11-18                                          *'
'*   Synopsis     : Meun Manager class                                  *'
'*                                                                      *'
'*   Modifications:                                                     *'
'************************************************************************'
'* Date     Author Mod. FTR No. Description                             *'
'* -------- ------ ---- ------- -------------------------------------   *'
'*
'*
'*
'* -------- ------ ---- ------- -------------------------------------   *'
'************************************************************************'
#End Region

Imports DataAccess
Imports Utils
Imports ResponseMessageStructs
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Data.SQLite

Public Class clsMeunManager

  ''' <summary>
  ''' 获取所有的菜单项
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function mPopulateMeun() As DataTable
    Dim lObjDataSet As DataSet = Nothing
    Dim lObjTblMeunManager As New DataAccess.TableClass.clsTB_MENU_MANAGER

    lObjTblMeunManager.mPrRetrieveData(lObjDataSet, TableClass.clsTB_MENU_MANAGER.enmQueryIndicator.ALL)
    Return lObjDataSet.Tables(0)
  End Function

  ''' <summary>
  ''' 获取指定类型的菜单项
  ''' </summary>
  ''' <param name="aEnmMeunCategory">菜单项类型</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function mPopulateMeun(ByVal aEnmMeunCategory As clsMenuMessageStruct.EnmMenuCategory) As DataTable
    Dim lObjDataSet As DataSet = Nothing
    Dim lObjTblMeunManager As New DataAccess.TableClass.clsTB_MENU_MANAGER

    lObjTblMeunManager.mPrpMM_MENU_CATEGORY = aEnmMeunCategory
    lObjTblMeunManager.mPrRetrieveData(lObjDataSet, TableClass.clsTB_MENU_MANAGER.enmQueryIndicator.SELECT_CATEGORY)
    Return lObjDataSet.Tables(0)
  End Function

  ''' <summary>
  ''' 获取指定编号的菜单项
  ''' </summary>
  ''' <param name="aIntMenuSrno"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function mPopulateMeun(ByVal aIntMenuSrno As Integer) As DataTable
    Dim lObjDataSet As DataSet = Nothing
    Dim lObjTblMeunManager As New DataAccess.TableClass.clsTB_MENU_MANAGER

    lObjTblMeunManager.mPrpMM_MENU_SRNO = aIntMenuSrno
    lObjTblMeunManager.mPrRetrieveData(lObjDataSet, TableClass.clsTB_MENU_MANAGER.enmQueryIndicator.PRIMARY_KEY)
    Return lObjDataSet.Tables(0)
  End Function

  ''' <summary>
  ''' 获取指定编号的菜单项
  ''' </summary>
  ''' <param name="aStrMenuSrno"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mGetMenu(ByVal aStrMenuSrno As String) As clsMenuMessageStruct
    Dim lIntMenuSrno As Integer
    Dim lObjMenu As New ResponseMessageStructs.clsMenuMessageStruct
    Dim lDtDataTable As DataTable = Nothing
    If IsNumeric(aStrMenuSrno) Then lIntMenuSrno = CInt(aStrMenuSrno)
    lDtDataTable = mPopulateMeun(lIntMenuSrno)
    If IsNothing(lDtDataTable) = False Then
      For Each lObjRow As DataRow In lDtDataTable.Rows
        With lObjMenu
          .mPrpMenuSrno = lObjRow.Item("MM_MENU_SRNO")
          .mPrpMenuDesc = lObjRow.Item("MM_MENU_DESC")
          .mPrpMenuLangSrno = lObjRow.Item("MM_MENU_LANG_SRNO")
          .mPrpParentSrno = lObjRow.Item("MM_PARENT_SRNO")
          .mPrpIsLeaf = lObjRow.Item("MM_IS_LEAF")
          .mPrpMenuCategory = lObjRow.Item("MM_MENU_CATEGORY")
          .mPrpURL = IIf(IsDBNull(lObjRow.Item("MM_URL")), "#", lObjRow.Item("MM_URL"))
          .mPrpTarget = IIf(IsDBNull(lObjRow.Item("MM_TARGET")), String.Empty, lObjRow.Item("MM_TARGET"))
        End With
      Next
    End If
    Return lObjMenu
  End Function

  ''' <summary>
  ''' 创建站点地图
  ''' </summary>
  ''' <param name="aStrMenuSrno"></param>
  ''' <remarks></remarks>
  Public Function mCreateSiteMap(ByVal aStrMenuSrno As String) As String
    Dim lStrRtn As String = String.Empty
    Dim lIntMenuSrno As Integer
    Dim lObjDataTable As DataTable = mPopulateMeun()
    Dim lObjSiteMap As New List(Of HyperLink)
    If IsNumeric(aStrMenuSrno) Then lIntMenuSrno = aStrMenuSrno
    mCreateMenuReverseRecursive(lObjSiteMap, lObjDataTable, lIntMenuSrno)
    For Each lObjHyperLink As HyperLink In lObjSiteMap
      lStrRtn = lStrRtn & lObjHyperLink.Text & clsParameterManager.mFnGetParameters(GP_SITE_MAP_SEPARATOR_CHAR)
    Next
    Return lStrRtn
  End Function

  ''' <summary>
  ''' 从下向上建立菜单项
  ''' 用于建立站点地图索引
  ''' </summary>
  ''' <param name="aObjItems"></param>
  ''' <param name="aObjDataTable"></param>
  ''' <param name="aIntMenuSrno"></param>
  ''' <remarks></remarks>
  Private Sub mCreateMenuReverseRecursive(ByRef aObjItems As List(Of HyperLink), ByVal aObjDataTable As DataTable, ByVal aIntMenuSrno As Integer)
    Dim lObjRows() As DataRow = aObjDataTable.Select("MM_MENU_SRNO=" & aIntMenuSrno)
    Dim lObjItem As HyperLink = Nothing
    For Each lObjRow As DataRow In lObjRows
      lObjItem = New HyperLink
      lObjItem.Text = clsLanguageDictionaryManager.mFnGetLanguageDesc(lObjRow("MM_MENU_LANG_SRNO"), mIntGlobal_Language_Indc)
      lObjItem.NavigateUrl = IIf(IsDBNull(lObjRow("MM_URL")), "#", lObjRow("MM_URL")) & "?MenuSrno=" & lObjRow("MM_MENU_SRNO")
      lObjItem.Target = IIf(IsDBNull(lObjRow("MM_TARGET")), String.Empty, lObjRow("MM_TARGET"))
      aObjItems.Insert(0, lObjItem)
      mCreateMenuReverseRecursive(aObjItems, aObjDataTable, lObjRow("MM_PARENT_SRNO"))
      aObjDataTable.Rows.Remove(lObjRow)
    Next
  End Sub

  ''' <summary>
  ''' 从上向下建立菜单项,生成菜单结构List
  ''' 可用于生成Json消息给与js使用
  ''' </summary>
  ''' <param name="aObjList"></param>
  ''' <param name="aObjDataTable"></param>
  ''' <param name="aIntParentSrno"></param>
  ''' <remarks></remarks>
  Private Sub mCreateMenuListRecursive(ByRef aObjList As List(Of clsMenuMessageStructJsonStruct), ByVal aObjDataTable As DataTable, ByVal aIntParentSrno As Integer)
    Dim lObjRows() As DataRow = aObjDataTable.Select("MM_PARENT_SRNO=" & aIntParentSrno)
    Dim lObjMenu As clsMenuMessageStruct = Nothing
    Dim lObjMenuJson As clsMenuMessageStructJsonStruct = Nothing

    For Each lObjRow As DataRow In lObjRows
      lObjMenu = New clsMenuMessageStruct
      lObjMenuJson = New clsMenuMessageStructJsonStruct
      mCreateMenuListRecursive(lObjMenuJson.mPrpChildren, aObjDataTable, lObjRow("MM_MENU_SRNO"))
      With lObjMenu
        .mPrpMenuSrno = lObjRow("MM_MENU_SRNO")
        .mPrpMenuDesc = lObjRow("MM_MENU_DESC")
        .mPrpMenuLangSrno = lObjRow("MM_MENU_LANG_SRNO")
        .mPrpParentSrno = lObjRow("MM_PARENT_SRNO")
        .mPrpIsLeaf = lObjRow("MM_IS_LEAF")
        .mPrpMenuCategory = lObjRow("MM_MENU_CATEGORY")
        .mPrpURL = IIf(IsDBNull(lObjRow("MM_URL")), "#", lObjRow("MM_URL")) & "?MenuSrno=" & lObjRow("MM_MENU_SRNO")
        .mPrpTarget = IIf(IsDBNull(lObjRow("MM_TARGET")), String.Empty, lObjRow("MM_TARGET"))
        .mPrpCreateUserSrno = lObjRow("MM_CREATE_USER_SRNO")
        .mPrpCreateDateTime = lObjRow("MM_CREATE_DATE_TIME")
        .mPrpUpdateUserSrno = IIf(IsDBNull(lObjRow("MM_UPDATE_USER_SRNO")), 0, lObjRow("MM_UPDATE_USER_SRNO"))
        .mPrpUpdateDateTime = IIf(IsDBNull(lObjRow("MM_UPDATE_DATE_TIME")), Nothing, lObjRow("MM_UPDATE_DATE_TIME"))
      End With
      lObjMenuJson.mPrpMenuMessage = lObjMenu
      aObjList.Add(lObjMenuJson)
      aObjDataTable.Rows.Remove(lObjRow)
    Next
  End Sub

  ''' <summary>
  ''' 根据类型查询菜单项
  ''' 用于生成Json数据
  ''' </summary>
  ''' <param name="aEnmMeunCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mPopulateMenu(ByVal aEnmMeunCategory As clsMenuMessageStruct.EnmMenuCategory) As List(Of clsMenuMessageStructJsonStruct)
    Dim lArrRtn As New List(Of clsMenuMessageStructJsonStruct)
    Dim lObjDataTable As DataTable = mPopulateMeun(aEnmMeunCategory)
    mCreateMenuListRecursive(lArrRtn, lObjDataTable, 0)
    Return lArrRtn
  End Function

End Class

#Region "遗留代码"

'''' <summary>
'''' 创建菜单
'''' </summary>
'''' <param name="aMenuItems"></param>
'''' <param name="aEnmMeunCategory"></param>
'''' <remarks></remarks>
'Public Sub mCreateMenu(ByRef aMenuItems As MenuItemCollection, ByVal aEnmMeunCategory As clsMenuMessageStruct.EnmMenuCategory)
'  Dim lObjDataTable As DataTable = mPopulateMeun(aEnmMeunCategory)
'  mCreateMenuRecursive(aMenuItems, lObjDataTable, 0)
'End Sub

'''' <summary>
'''' 创建菜单树
'''' </summary>
'''' <param name="aTreeNodes"></param>
'''' <param name="aEnmMeunCategory"></param>
'''' <remarks></remarks>
'Public Sub mCreateMenu(ByRef aTreeNodes As TreeNodeCollection, ByVal aEnmMeunCategory As clsMenuMessageStruct.EnmMenuCategory)
'  Dim lObjDataTable As DataTable = mPopulateMeun(aEnmMeunCategory)
'  mCreateMenuRecursive(aTreeNodes, lObjDataTable, 0)
'End Sub

'''' <summary>
'''' 从上向下建立菜单项
'''' </summary>
'''' <param name="aObjItems"></param>
'''' <param name="aObjDataTable"></param>
'''' <param name="aIntParentSrno"></param>
'''' <remarks></remarks>
'Private Sub mCreateMenuRecursive(ByRef aObjItems As Object, ByVal aObjDataTable As DataTable, ByVal aIntParentSrno As Integer)
'  Dim lObjRows() As DataRow = aObjDataTable.Select("MM_PARENT_SRNO=" & aIntParentSrno)
'  Dim lObjItem As Object = Nothing
'  For Each lObjRow As DataRow In lObjRows
'    If TypeOf aObjItems Is TreeNodeCollection Then
'      lObjItem = New TreeNode
'      mCreateMenuRecursive(lObjItem.ChildNodes, aObjDataTable, lObjRow("MM_MENU_SRNO"))
'    ElseIf TypeOf aObjItems Is MenuItemCollection Then
'      lObjItem = New MenuItem
'      mCreateMenuRecursive(lObjItem.ChildItems, aObjDataTable, lObjRow("MM_MENU_SRNO"))
'    End If
'    lObjItem.Value = lObjRow("MM_MENU_SRNO")
'    lObjItem.NavigateUrl = IIf(IsDBNull(lObjRow("MM_URL")), "#", lObjRow("MM_URL")) & "?MenuSrno=" & lObjRow("MM_MENU_SRNO")
'    lObjItem.Target = IIf(IsDBNull(lObjRow("MM_TARGET")), String.Empty, lObjRow("MM_TARGET"))
'    lObjItem.Text = clsLanguageDictionaryManager.mFnGetLanguageDesc(lObjRow("MM_MENU_LANG_SRNO"), mIntGlobal_Language_Indc)
'    aObjItems.Add(lObjItem)
'    aObjDataTable.Rows.Remove(lObjRow)
'  Next
'End Sub

#End Region