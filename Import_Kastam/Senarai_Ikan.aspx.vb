
Partial Class Import_Senarai_Ikan
    Inherits System.Web.UI.Page

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');document.all.TextBox2.value='" & e.Row.DataItem(1).ToString() & "';")
            ' e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='Silver';")
            'e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    
End Class
