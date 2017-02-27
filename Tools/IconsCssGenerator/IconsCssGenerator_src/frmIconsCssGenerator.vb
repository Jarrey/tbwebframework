Public Class frmIconsCssGenerator

  Private Const CONST_STR_CSS_TEMPLATE As String = ".%FileName% {background-image: url(../images/%FileName%%FileFormat%) !important; background-repeat: no-repeat;}"
  Private mStrIconsFolder As String = String.Empty
  Private mArrIconFormats As New ArrayList(New String() {"ALL", ".bmp", ".png", ".gif", ".jpg", ".ico"})

  Private Sub frmIconsCssGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    txtCssStyle.Text = CONST_STR_CSS_TEMPLATE
    mStrIconsFolder = Environment.CurrentDirectory
    txtIconsFolder.Text = mStrIconsFolder
    cmbIconsFormat.DataSource = mArrIconFormats
    cmbIconsFormat.SelectedIndex = 0
  End Sub

  Private Sub cmdIconsFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIconsFolder.Click
    Dim lObjFolderDialg As New FolderBrowserDialog
    With lObjFolderDialg
      .Description = "请选择包含图标文件的目录..."
      .SelectedPath = txtIconsFolder.Text
      .ShowNewFolderButton = False
      If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
      mStrIconsFolder = .SelectedPath
    End With
    txtIconsFolder.Text = mStrIconsFolder
  End Sub

  Private Sub cmdGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerate.Click
    If txtIconsFolder.Text.Trim = String.Empty Then
      MessageBox.Show("请选择目录！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    Dim lStrCssTemplate As String
    Dim lStrOutput As String = String.Empty
    Dim lArrOutput As New ArrayList
    lArrOutput.Clear()

    For Each lStrFile As String In IO.Directory.GetFiles(mStrIconsFolder)
      Dim lObjFileInfo As New IO.FileInfo(lStrFile)
      lStrCssTemplate = txtCssStyle.Text.Trim
      If UCase(cmbIconsFormat.SelectedValue.Trim) = "ALL" Then
        If mArrIconFormats.Contains(lObjFileInfo.Extension) Then
          lStrCssTemplate = lStrCssTemplate.Replace("%FileName%", lObjFileInfo.Name.Remove(lObjFileInfo.Name.LastIndexOf(lObjFileInfo.Extension)))
          lStrCssTemplate = lStrCssTemplate.Replace("%FileFormat%", lObjFileInfo.Extension)
          lArrOutput.Add(lStrCssTemplate)
        End If
      Else
        If lObjFileInfo.Extension = cmbIconsFormat.SelectedValue.Trim Then
          lStrCssTemplate = lStrCssTemplate.Replace("%FileName%", lObjFileInfo.Name.Remove(lObjFileInfo.Name.LastIndexOf(lObjFileInfo.Extension)))
          lStrCssTemplate = lStrCssTemplate.Replace("%FileFormat%", lObjFileInfo.Extension)
          lArrOutput.Add(lStrCssTemplate)
        End If
      End If
    Next

    For Each lStrCss As String In lArrOutput
      lStrOutput = lStrOutput & lStrCss & vbCrLf
    Next

    If lStrOutput.Trim = String.Empty Then Exit Sub
    frmCssViewer.mStrOutput = lStrOutput
    frmCssViewer.ShowDialog()
  End Sub
End Class
