
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-04                                          *'
'*   Synopsis     : column Defination Manager class                     *'
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
Imports Newtonsoft.Json
Imports System.Web

Public Class clsColumnDefinationManager

  ''' <summary>
  ''' 根据 GridView/ListView Srno 来查询和生成 Column 的 Json 结构
  ''' </summary>
  ''' <typeparam name="T"></typeparam>
  ''' <param name="aLngViewSrno"></param>
  ''' <param name="aIntGridListViewCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mInitColumnModelStruct(Of T As {clsColumnModelJsonBaseStruct, New})(ByVal aLngViewSrno As Long, ByVal aIntGridListViewCategory As Integer) As List(Of T)
    Dim lArrRtn As New List(Of T)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblColumnModel As New TableClass.clsTB_COLUMN_MODEL
    Dim lObjColumnModel As clsColumnModelStruct = Nothing
    Dim lObjColumnModelJson As T = Nothing

    lObjTblColumnModel.mPrpCM_VIEW_SRNO = aLngViewSrno
    lObjTblColumnModel.mPrpCM_COLUMN_CATEGORY = aIntGridListViewCategory
    lObjTblColumnModel.mPrRetrieveData(lDtDataReader, TableClass.clsTB_COLUMN_MODEL.enmQueryIndicator.SELECT_VIEW_SRNO_CATEGORY)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblColumnModel.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_COLUMN_MODEL.enmQueryIndicator.SELECT_VIEW_SRNO_CATEGORY)
        lObjColumnModelJson = New T
        lObjColumnModel = New clsColumnModelStruct
        With lObjColumnModel
          .mPrpColumnSrno = lDtDataReader.Item("CM_COLUMN_SRNO")
          .mPrpViewSrno = lDtDataReader.Item("CM_VIEW_SRNO")
          .mPrpColumnName = lDtDataReader.Item("CM_COLUMN_NAME")
          .mPrpColumnLangSrno = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_LANG_SRNO")), "0", lDtDataReader.Item("CM_COLUMN_LANG_SRNO"))
          .mPrpColumnIndex = lDtDataReader.Item("CM_COLUMN_INDEX")
          .mPrpColumnCategory = lDtDataReader.Item("CM_COLUMN_CATEGORY")
          .mPrpColumnDataIndex = lDtDataReader.Item("CM_COLUMN_DATA_INDEX")
          .mPrpColumnType = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_TYPE")), String.Empty, lDtDataReader.Item("CM_COLUMN_TYPE"))
          .mPrpColumnWidth = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_WIDTH")), String.Empty, lDtDataReader.Item("CM_COLUMN_WIDTH"))
          .mPrpColumnAlign = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_ALIGN")), clsColumnModelStruct.EnmColumnAlign.LEFT, lDtDataReader.Item("CM_COLUMN_ALIGN"))
          .mPrpColumnToolTip = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_TOOLTIP")), String.Empty, lDtDataReader.Item("CM_COLUMN_TOOLTIP"))
          .mPrpColumnCSS = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_CSS")), String.Empty, lDtDataReader.Item("CM_COLUMN_CSS"))
          .mPrpColumnTpl = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_TPL")), String.Empty, lDtDataReader.Item("CM_COLUMN_TPL"))
          .mPrpColumnSortable = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_SORTABLE")), True, lDtDataReader.Item("CM_COLUMN_SORTABLE"))
          .mPrpColumnResizable = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_RESIZABLE")), True, lDtDataReader.Item("CM_COLUMN_RESIZABLE"))
          .mPrpColumnEditable = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_EDITABLE")), True, lDtDataReader.Item("CM_COLUMN_EDITABLE"))
          .mPrpColumnEditor = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_EDITOR")), String.Empty, lDtDataReader.Item("CM_COLUMN_EDITOR"))
          .mPrpRenderer = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_RENDERER")), String.Empty, lDtDataReader.Item("CM_COLUMN_RENDERER"))
          .mPrpScope = IIf(IsDBNull(lDtDataReader.Item("CM_COLUMN_SCOPE")), String.Empty, lDtDataReader.Item("CM_COLUMN_SCOPE"))
          .mPrpCreateUserSrno = lDtDataReader.Item("CM_CREATE_USER_SRNO")
          .mPrpCreateDateTime = lDtDataReader.Item("CM_CREATE_DATE_TIME")
          .mPrpUpdateUserSrno = IIf(IsDBNull(lDtDataReader.Item("CM_UPDATE_USER_SRNO")), 0, lDtDataReader.Item("CM_UPDATE_USER_SRNO"))
          .mPrpUpdateDateTime = IIf(IsDBNull(lDtDataReader.Item("CM_UPDATE_DATE_TIME")), Nothing, lDtDataReader.Item("CM_UPDATE_DATE_TIME"))
        End With
        lObjColumnModelJson.mPrpColumnModel = lObjColumnModel
        lArrRtn.Add(lObjColumnModelJson)
      End While
    End If
    Return lArrRtn
  End Function

  ''' <summary>
  ''' 根据 GridView/ListView Srno 来查询和生成 Column Data Reader 的 Json 结构
  ''' </summary>
  ''' <param name="aLngViewSrno"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mInitColumnDataReaderStuct(ByVal aLngViewSrno As Long) As List(Of clsColumnDataReaderJsonStruct)
    Dim lArrRtn As New List(Of clsColumnDataReaderJsonStruct)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblColumnDataReader As New TableClass.clsTB_COLUMN_DATA_READER
    Dim lObjColumnDataReader As clsColumnDataReaderStruct = Nothing
    Dim lObjColumnDataReaderJson As clsColumnDataReaderJsonStruct = Nothing

    lObjTblColumnDataReader.mPrpCDR_VIEW_SRNO = aLngViewSrno
    lObjTblColumnDataReader.mPrRetrieveData(lDtDataReader, TableClass.clsTB_COLUMN_DATA_READER.enmQueryIndicator.SELECT_VIEW_SRNO)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblColumnDataReader.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_COLUMN_DATA_READER.enmQueryIndicator.SELECT_VIEW_SRNO)
        lObjColumnDataReaderJson = New clsColumnDataReaderJsonStruct
        lObjColumnDataReader = New clsColumnDataReaderStruct
        With lObjColumnDataReader
          .mPrpColumnSrno = lDtDataReader.Item("CDR_COLUMN_SRNO")
          .mPrpViewSrno = lDtDataReader.Item("CDR_VIEW_SRNO")
          .mPrpDataIndexName = lDtDataReader.Item("CDR_DATA_INDEX_NAME")
          .mPrpMapping = IIf(IsDBNull(lDtDataReader.Item("CDR_MAPPING")), String.Empty, lDtDataReader.Item("CDR_MAPPING"))
          .mPrpCreateUserSrno = lDtDataReader.Item("CDR_CREATE_USER_SRNO")
          .mPrpCreateDateTime = lDtDataReader.Item("CDR_CREATE_DATE_TIME")
          .mPrpUpdateUserSrno = IIf(IsDBNull(lDtDataReader.Item("CDR_UPDATE_USER_SRNO")), 0, lDtDataReader.Item("CDR_UPDATE_USER_SRNO"))
          .mPrpUpdateDateTime = IIf(IsDBNull(lDtDataReader.Item("CDR_UPDATE_DATE_TIME")), Nothing, lDtDataReader.Item("CDR_UPDATE_DATE_TIME"))
        End With
        lObjColumnDataReaderJson.mPrpColumnDataReader = lObjColumnDataReader
        lArrRtn.Add(lObjColumnDataReaderJson)
      End While
    End If
    Return lArrRtn
  End Function

  ''' <summary>
  ''' 根据 GridView Srno 来查询和生成 Column Filter 的 Json 结构
  ''' </summary>
  ''' <param name="aLngViewSrno"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mInitColumnFilterStruct(ByVal aLngViewSrno As Long) As List(Of clsColumnFilterJsonStruct)
    Dim lArrRtn As New List(Of clsColumnFilterJsonStruct)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblColumnFilter As New TableClass.clsTB_COLUMN_FILTER_MANAGER
    Dim lObjColumnFilter As clsColumnFilterStruct = Nothing
    Dim lObjColumnFilterJson As clsColumnFilterJsonStruct = Nothing

    lObjTblColumnFilter.mPrpCFM_VIEW_SRNO = aLngViewSrno
    lObjTblColumnFilter.mPrRetrieveData(lDtDataReader, TableClass.clsTB_COLUMN_FILTER_MANAGER.enmQueryIndicator.SELECT_VIEW_SRNO)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblColumnFilter.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_COLUMN_FILTER_MANAGER.enmQueryIndicator.SELECT_VIEW_SRNO)
        lObjColumnFilter = New clsColumnFilterStruct
        lObjColumnFilterJson = New clsColumnFilterJsonStruct
        With lObjColumnFilter
          .mPrpFilterSrno = lDtDataReader.Item("CFM_FILTER_SRNO")
          .mPrpViewSrno = lDtDataReader.Item("CFM_VIEW_SRNO")
          .mPrpColumnIndex = lDtDataReader.Item("CFM_COLUMN_INDEX")
          .mPrpFilterType = lDtDataReader.Item("CFM_FILTER_TYPE")
          .mPrpFilterDataIndex = lDtDataReader.Item("CFM_FILTER_DATA_INDEX")
          .mPrpFilterDisabled = IIf(IsDBNull(lDtDataReader.Item("CFM_FILTER_DISABLED")), False, lDtDataReader.Item("CFM_FILTER_DISABLED"))
          .mPrpFilterCodeDesc = IIf(IsDBNull(lDtDataReader.Item("CFM_FILTER_CODE_DESC")), String.Empty, lDtDataReader.Item("CFM_FILTER_CODE_DESC"))
          .mPrpFilterCodeQuery = IIf(IsDBNull(lDtDataReader.Item("CFM_FILTER_CODE_QUERY")), String.Empty, lDtDataReader.Item("CFM_FILTER_CODE_QUERY"))
          .mPrpCreateUserSrno = lDtDataReader.Item("CFM_CREATE_USER_SRNO")
          .mPrpCreateDateTime = lDtDataReader.Item("CFM_CREATE_DATE_TIME")
          .mPrpUpdateUserSrno = IIf(IsDBNull(lDtDataReader.Item("CFM_UPDATE_USER_SRNO")), 0, lDtDataReader.Item("CFM_UPDATE_USER_SRNO"))
          .mPrpUpdateDateTime = IIf(IsDBNull(lDtDataReader.Item("CFM_UPDATE_DATE_TIME")), Nothing, lDtDataReader.Item("CFM_UPDATE_DATE_TIME"))
        End With
        lObjColumnFilterJson.mPrpColumnFilter = lObjColumnFilter
        lArrRtn.Add(lObjColumnFilterJson)
      End While
    End If
    Return lArrRtn
  End Function
End Class
