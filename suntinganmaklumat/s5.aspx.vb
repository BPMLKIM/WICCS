
Partial Class UserManagement_LKIM_list_users
    Inherits System.Web.UI.Page
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');location.href='s5_edit_lkim_user.aspx?user=" & e.Row.DataItem(1).ToString() & "';")
            'Response.Write("location.href='lesen_lkim_user.aspx?user=" & e.Row.DataItem(0).ToString() & "';")
        End If
    End Sub

    Protected Sub Kembali_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Server.Transfer("suntingmaklumat.aspx")
    End Sub

End Class
