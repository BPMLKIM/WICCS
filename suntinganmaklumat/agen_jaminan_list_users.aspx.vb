Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_list_users
    Inherits System.Web.UI.Page

    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String

    Public Function Bin_To_Dec(ByVal Bin As String) 'function to convert a binary number to decimal
        Dim dec As Double = Nothing
        Dim length As Integer = Len(Bin)
        Dim temp As Integer = Nothing
        Dim x As Integer = Nothing
        For x = 1 To length
            temp = Val(Mid(Bin, length, 1))
            length = length - 1
            If temp <> "0" Then
                dec += (2 ^ (x - 1))
            End If
        Next
        Return dec
    End Function

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','#cc3333');location.href='agen_jaminan_edit_lkim_user.aspx?user=" & e.Row.DataItem(0).ToString() & "';")
            'Response.Write("location.href='edit_lkim_user.aspx?user=" & e.Row.DataItem(1).ToString() & "';")
        End If
    End Sub
End Class
