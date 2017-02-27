Public Class frmCssViewer

  Public mStrOutput As String = String.Empty

  Private Sub frmCssViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    txtOutput.Text = mStrOutput
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub

  Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
    Dim lObjSaveDialg As New SaveFileDialog
    Dim lObjStreamWriter As IO.StreamWriter
    Dim lStrFilePath As String
    With lObjSaveDialg
      .InitialDirectory = Environment.CurrentDirectory
      .OverwritePrompt = True
      .Filter = "CSS样式表|*.css"
      .DefaultExt = ".css"
      .FileName = "icons"
      If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
      lObjStreamWriter = New IO.StreamWriter(.OpenFile())
      lStrFilePath = .FileName
    End With
    lObjStreamWriter.WriteLine(mStrOutput.Trim)
    lObjStreamWriter.Close()
    MessageBox.Show("保存成功 - " & lStrFilePath, "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
  End Sub
End Class