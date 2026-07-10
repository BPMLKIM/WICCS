
Partial Class UserManagement_AGEN_list_users
    Inherits System.Web.UI.Page
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');location.href='edit_Agen_user.aspx?user=" & e.Row.DataItem(5).ToString() & "&agentCode=" & e.Row.DataItem(0) & "';")
        End If
    End Sub
End Class
