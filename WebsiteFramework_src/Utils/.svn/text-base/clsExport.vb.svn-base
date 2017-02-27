'* http://www.carlosag.net/Tools/ExcelXmlWriter/
'* This library allows you to generate Excel Workbooks using XML, 
'* it is built 100% in C# and does not requires Excel installed at all to generate the files. 
'* It exposes a simple object model to generate the XML Workbooks.
'* Note: This library is free, you can distribute it and use it at your own will and risk, 
'*       it is not supported by any company including Microsoft or any other company, it does not belong to any company.
Imports CarlosAg.ExcelXmlWriter

Public Class clsExport

  ''' <summary>
  ''' 导出数据保存为Excel可读的Xml格式 静态方法
  ''' </summary>
  ''' <param name="aObjDataTable"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnExportAsExcelXml(ByVal aObjDataTable As DataTable) As String
    Dim lObjWorkBook As New Workbook
    Dim lObjWorkSheet As Worksheet
    Dim lObjWorkSheetRow As New WorksheetRow
    Dim lIntClumIndex As Integer = 0
    Dim lIntRowIndex As Integer = 0
    Dim lStrValue As String = String.Empty
    Dim lStrFileName As String = "tmp_ExportGrid.xml"

    lObjWorkSheet = lObjWorkBook.Worksheets.Add("Sheet1")

    'EXPORT FOR TABLE HEADER
    For lIntClumIndex = 0 To aObjDataTable.Columns.Count - 1
      lObjWorkSheet.Table.Columns.Add(New WorksheetColumn)
      lObjWorkSheetRow.Cells.Add(New WorksheetCell(aObjDataTable.Columns(lIntClumIndex).ColumnName))
    Next
    lObjWorkSheet.Table.Rows.Insert(0, lObjWorkSheetRow)

    'EXPORT FOR TABLE BODY
    For lIntRowIndex = 0 To aObjDataTable.Rows.Count - 1
      lObjWorkSheetRow = New WorksheetRow
      For lIntClumIndex = 0 To aObjDataTable.Columns.Count - 1  'for column
        lStrValue = aObjDataTable.Rows(lIntRowIndex).Item(lIntClumIndex).ToString
        If lStrValue = String.Empty Or IsNumeric(lStrValue) = False Then
          lObjWorkSheetRow.Cells.Add(lStrValue)
        Else
          lObjWorkSheetRow.Cells.Add(lStrValue, DataType.Number, Nothing)
        End If
      Next
      lObjWorkSheet.Table.Rows.Add(lObjWorkSheetRow)
    Next

    lObjWorkBook.Save(clsSharedMemory.mStrApplicationPath & "/ExportFile/" & lStrFileName)

    Return lStrFileName
  End Function

  ''' <summary>
  ''' 导出数据保存为Excel可读的Csv格式 静态方法
  ''' </summary>
  ''' <param name="aObjDataTable"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function mFnExportAsCsv(ByVal aObjDataTable As DataTable) As Boolean

  End Function

End Class
