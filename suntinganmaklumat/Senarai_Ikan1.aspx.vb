
Partial Class Senarai_Ikan1
    Inherits System.Web.UI.Page
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');sendValue('" & e.Row.DataItem(0).ToString() & "','" & e.Row.DataItem(1).ToString() & "','" & e.Row.DataItem(2).ToString() & "');")
        End If
    End Sub
End Class
