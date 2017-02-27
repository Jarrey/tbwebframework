
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-12-03                                          *'
'*   Synopsis     : Code Master Manager class                           *'
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

Public Class clsCodeMasterManager

  ''' <summary>
  ''' 根据 Code Master Desc 来查询和生成 Code Master 的 Json 结构
  ''' </summary>
  ''' <param name="aStrCodeDesc"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function mInitLstCodeStuct(ByVal aStrCodeDesc As String, ByVal aStrCustomQuery As String) As List(Of clsCodeMasterStruct)
    Dim lArrRtn As New List(Of clsCodeMasterStruct)
    Dim lDtDataReader As SQLite.SQLiteDataReader = Nothing
    Dim lObjTblCodeMaster As New TableClass.clsTB_CODE_MASTER
    Dim lObjCodeMaster As clsCodeMasterStruct = Nothing

    lObjTblCodeMaster.mPrpCMS_CODE_DESC = aStrCodeDesc
    lObjTblCodeMaster.mPrpCMS_CUSTOM_QUERY = aStrCustomQuery
    lObjTblCodeMaster.mPrRetrieveData(lDtDataReader, TableClass.clsTB_CODE_MASTER.enmQueryIndicator.SELECT_DESC_CUSTOM_QUERY)
    If IsNothing(lDtDataReader) = False Then
      While lObjTblCodeMaster.mFnRetrieveNextRecord(lDtDataReader, TableClass.clsTB_CODE_MASTER.enmQueryIndicator.SELECT_DESC_CUSTOM_QUERY)
        lObjCodeMaster = New clsCodeMasterStruct
        With lObjCodeMaster
          .mPrpCodeSrno = lDtDataReader.Item("CMS_CODE_SRNO")
          .mPrpCodeDesc = lDtDataReader.Item("CMS_CODE_DESC")
          .mPrpCodeName = lDtDataReader.Item("CMS_CODE_NAME")
          .mPrpCodeLabel = lDtDataReader.Item("CMS_CODE_LABEL")
          .mPrpCodeLabelLangSrno = IIf(IsDBNull(lDtDataReader.Item("CMS_CODE_LABEL_LANG_SRNO")), "0", lDtDataReader.Item("CMS_CODE_LABEL_LANG_SRNO"))
          .mPrpCodeCategory = lDtDataReader.Item("CMS_CODE_CATEGORY")
          .mPrpCodeValue = lDtDataReader.Item("CMS_CODE_VALUE")
          .mPrpCodeValueLangSrno = IIf(IsDBNull(lDtDataReader.Item("CMS_CODE_VALUE_LANG_SRNO")), 0, lDtDataReader.Item("CMS_CODE_VALUE_LANG_SRNO"))
          .mPrpCustomQuery = IIf(IsDBNull(lDtDataReader.Item("CMS_CUSTOM_QUERY")), String.Empty, lDtDataReader.Item("CMS_CUSTOM_QUERY"))
          .mPrpCreateUserSrno = lDtDataReader.Item("CMS_CREATE_USER_SRNO")
          .mPrpCreateDateTime = lDtDataReader.Item("CMS_CREATE_DATE_TIME")
          .mPrpUpdateUserSrno = IIf(IsDBNull(lDtDataReader.Item("CMS_UPDATE_USER_SRNO")), 0, lDtDataReader.Item("CMS_UPDATE_USER_SRNO"))
          .mPrpUpdateDateTime = IIf(IsDBNull(lDtDataReader.Item("CMS_UPDATE_DATE_TIME")), Nothing, lDtDataReader.Item("CMS_UPDATE_DATE_TIME"))
        End With
        lArrRtn.Add(lObjCodeMaster)
      End While
    End If
    Return lArrRtn
  End Function

End Class
