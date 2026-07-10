Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text
Partial Class index_homepage
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If (DropDownList1.SelectedIndex <> 0) Then
            If DropDownList1.SelectedItem.Value = "01" Then
                Server.Transfer("index.aspx")
            End If
        End If
    End Sub
End Class
