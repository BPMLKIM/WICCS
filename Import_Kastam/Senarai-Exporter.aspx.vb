
Partial Class Exporter_Ikan
    Inherits System.Web.UI.Page



    'Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
    '    Dim val1 As String
    '    Dim val2 As String
    '    Dim val3 As String


    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        if e.Row.DataItem = 
    '            val1 = e.Row.DataItem(0).ToString()
    '            val2 = e.Row.DataItem(1).ToString()
    '            val3 = e.Row.DataItem(2).ToString()

    '            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');document.all.TextBox2.value='" & val2 & "';")
    '        End If
    'End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');sendValue('" & e.Row.DataItem(0).ToString() & "','" & e.Row.DataItem(1).ToString() & "');window.close();")
        End If
    End Sub

End Class
