Partial Public Class _Default
  Inherits System.Web.UI.Page

  Private mObjDataTable As New DataTable

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      Response.Redirect("AdminManage/ManageMain.aspx")
    End If
  End Sub

End Class