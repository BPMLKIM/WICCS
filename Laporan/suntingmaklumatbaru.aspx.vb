Imports System
Imports System.Data
Imports System.Data.SQLClient
Imports System.Configuration
Imports System.IO
Imports System.Text

Partial Class suntingmaklumat
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If (DropDownList1.SelectedIndex <> 0) Then
            If DropDownList1.SelectedItem.Value = "01" Then
                Server.Transfer("laporan1.aspx")
            ElseIf DropDownList1.SelectedItem.Value = "02" Then
                Server.Transfer("laporan2.aspx")
            ElseIf DropDownList1.SelectedItem.Value = "03" Then
                Server.Transfer("laporan3.aspx")
            ElseIf DropDownList1.SelectedItem.Value = "04" Then
                Server.Transfer("laporan4.aspx")
            ElseIf DropDownList1.SelectedItem.Value = "05" Then
                Server.Transfer("logPalang.aspx")
        
            Else

            End If
            DropDownList1.Enabled = False

        End If
    End Sub

    Protected Sub list5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles list5.SelectedIndexChanged
        Label6.Text = DropDownList1.SelectedItem.Value
        If list4.SelectedIndex <> 0 Then
            If list5.SelectedItem.Value = "02.1" Then
                Server.Transfer("bentuk_ikan1.aspx")

            ElseIf list5.SelectedItem.Value = "02.2" Then
                Server.Transfer("bentuk_ikan2.aspx")

            ElseIf list5.SelectedItem.Value = "02.3" Then
                Server.Transfer("bentuk_ikan3.aspx")

            ElseIf list5.SelectedItem.Value = "02.4" Then
                Server.Transfer("bentuk_ikan4.aspx")

            ElseIf list5.SelectedItem.Value = "02.5" Then
                Server.Transfer("bentuk_ikan5.aspx")
            Else
            End If
        End If
    End Sub
End Class


