
#Region "CLASS HEADER INFORMATION"
'************************************************************************'
'*                H E A D E R  I N F O R M A T I O N  B O X             *'
'************************************************************************'
'************************************************************************'
'*   Author       : Jar Bob                           				          *'
'*   Date         : 2009-11-20                                          *'
'*   Synopsis     : Parameters Manager class                            *'
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
Imports System.Data.SQLite

Public Class clsParameterManager

  ''' <summary>
  ''' 获得指定类型和名称的参数值
  ''' 静态函数
  ''' </summary>
  ''' <param name="aStrPrmtDesc"></param>
  ''' <param name="aEnmPrmtCategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnGetParameters(ByVal aStrPrmtDesc As String _
                                        , Optional ByRef aStrOptionaIndc As Integer = 0 _
                                        , Optional ByVal aEnmPrmtCategory As clsParametersMessageStruct.EnmParameterCategory = clsParametersMessageStruct.EnmParameterCategory.SYSTEM) As Object
    If IsNothing(clsSharedMemory.mDtParameterDataTable) OrElse clsSharedMemory.mDtParameterDataTable.Rows.Count = 0 Then

      Dim lObjTblParameter As New TableClass.clsTB_PARAMETER_MASTER
      Dim lObjDataReader As SQLiteDataReader = Nothing

      With lObjTblParameter
        .mPrpPM_PARAMETER_DESC = aStrPrmtDesc
        .mPrpPM_PARAMETER_CATEGORY = aEnmPrmtCategory
        .mPrRetrieveData(lObjDataReader, TableClass.clsTB_PARAMETER_MASTER.enmQueryIndicator.SELECT_PRMT_VALUE)

        If lObjDataReader IsNot Nothing Then
          While .mFnRetrieveNextRecord(lObjDataReader, TableClass.clsTB_PARAMETER_MASTER.enmQueryIndicator.SELECT_PRMT_VALUE)
            Select Case lObjDataReader.Item("PM_VALUE_TYPE")
              Case clsParametersMessageStruct.EnmParameterValueType.TEXT
                If lObjDataReader.Item("PM_VALUE_LANG_SRNO").ToString.Trim <> String.Empty Then
                  Return clsLanguageDictionaryManager.mFnGetLanguageDesc(lObjDataReader.Item("PM_VALUE_LANG_SRNO"), mIntGlobal_Language_Indc)
                Else
                  Return lObjDataReader.Item("PM_VALUE").ToString
                End If
              Case clsParametersMessageStruct.EnmParameterValueType.NUMERIC
                If IsNumeric(lObjDataReader.Item("PM_VALUE")) Then
                  Return CDbl(lObjDataReader.Item("PM_VALUE"))
                Else
                  Return DBNull.Value
                End If
              Case clsParametersMessageStruct.EnmParameterValueType.BOOL
                Return CBool(lObjDataReader.Item("PM_VALUE"))
              Case clsParametersMessageStruct.EnmParameterValueType.LINK
                Return lObjDataReader.Item("PM_VALUE").ToString
              Case clsParametersMessageStruct.EnmParameterValueType.IMAGE
                Return Nothing
              Case clsParametersMessageStruct.EnmParameterValueType.OPTIONS
                aStrOptionaIndc = CInt(lObjDataReader.Item("PM_VALUE"))
                Return lObjDataReader.Item("PM_OPTIONS").ToString.Split("|")(CInt(lObjDataReader.Item("PM_VALUE")))
              Case Else
                Return lObjDataReader.Item("PM_VALUE")
            End Select
          End While
        End If
      End With

      mPrLoadParameters(clsSharedMemory.mDtParameterDataTable)

    Else

      Dim lObjRows() As DataRow = clsSharedMemory.mDtParameterDataTable.Select("PM_PARAMETER_DESC = '" & aStrPrmtDesc & "' And PM_PARAMETER_CATEGORY = " & aEnmPrmtCategory)

      For Each lObjRow As DataRow In lObjRows
        Select Case lObjRow.Item("PM_VALUE_TYPE")
          Case clsParametersMessageStruct.EnmParameterValueType.TEXT
            If lObjRow.Item("PM_VALUE_LANG_SRNO").ToString.Trim <> String.Empty Then
              Return clsLanguageDictionaryManager.mFnGetLanguageDesc(lObjRow.Item("PM_VALUE_LANG_SRNO"), mIntGlobal_Language_Indc)
            Else
              Return lObjRow.Item("PM_VALUE").ToString
            End If
          Case clsParametersMessageStruct.EnmParameterValueType.NUMERIC
            If IsNumeric(lObjRow.Item("PM_VALUE")) Then
              Return CDbl(lObjRow.Item("PM_VALUE"))
            Else
              Return DBNull.Value
            End If
          Case clsParametersMessageStruct.EnmParameterValueType.BOOL
            Return CBool(lObjRow.Item("PM_VALUE"))
          Case clsParametersMessageStruct.EnmParameterValueType.LINK
            Return lObjRow.Item("PM_VALUE").ToString
          Case clsParametersMessageStruct.EnmParameterValueType.IMAGE
            Return Nothing
          Case clsParametersMessageStruct.EnmParameterValueType.OPTIONS
            aStrOptionaIndc = CInt(lObjRow.Item("PM_VALUE"))
            Return lObjRow.Item("PM_OPTIONS").ToString.Split("|")(CInt(lObjRow.Item("PM_VALUE")))
          Case Else
            Return lObjRow.Item("PM_VALUE")
        End Select
      Next

    End If

    Return Nothing
  End Function

  ''' <summary>
  ''' 载入全部参数
  ''' </summary>
  ''' <param name="aDtParameterDataTable"></param>
  ''' <remarks></remarks>
  Public Shared Sub mPrLoadParameters(ByRef aDtParameterDataTable As DataTable)
    Dim lObjTblParameter As New TableClass.clsTB_PARAMETER_MASTER
    Dim lObjDataSet As New DataSet
    If IsNothing(aDtParameterDataTable) Then aDtParameterDataTable = New DataTable
    lObjTblParameter.mPrRetrieveData(lObjDataSet, TableClass.clsTB_PARAMETER_MASTER.enmQueryIndicator.ALL)
    aDtParameterDataTable.Clear()
    aDtParameterDataTable = lObjDataSet.Tables(0)
  End Sub

End Class
