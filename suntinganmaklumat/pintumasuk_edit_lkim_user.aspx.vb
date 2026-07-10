Imports System.Security
Imports secureInfo

Partial Class UserManagement_LKIM_edit_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String

    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        'Dim sqlText As String = "select count(*) from pintu_masuk_sistem_q where Kod_ppi='" & DropDownList1.Text & "'"
        'Dim rcount As Integer = opClass.SingleFieldResults(sqlText)
        'If rcount > 0 Then
        '    'Dim popupScript As String = "<script language='javascript'>" & _
        '    '                             "alert('Pintu Masuk Pengimport Suduh dipilih');" & _
        '    '                             "</script>"
        '    'Response.Write(popupScript)
        '    'Label1.Visible = True
        '    Label1.Text = "Pintu Masuk Suduh Wujud."

        'Else
        Dim sqlText As String = "select count(*) from pintu_masuk_sistem_q where Kod_Pengimport='" & Label2.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)
        If rcount = 6 Then
            'Dim popupScript As String = "<script language='javascript'>" & _
            '                             "alert('Hanya 6 pintu Masuk dibenarkan untuk satu Pengimport');" & _
            '                             "</script>"
            'Response.Write(popupScript)
            Label1.Visible = True
            Label1.Text = "Pintu Masuk Suduh melebihi had. Hanya 6 pintu Masuk dibenarkan untuk satu Pengimport"

        Else
            sqlText = "INSERT INTO [W-ICCS].[dbo].[pintu_masuk_sistem_q] (Kod_Pengimport , kod_ppi)" & _
            "VALUES('" & Label2.Text & "','" & DropDownList1.Text & "')"
            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = False Then
                Response.AppendHeader("Refresh", "0;")
            End If
        End If
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlText As String
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        display = "none"

        sqlText = "SELECT Kod_Pengimport , Nama_Syarikat_Import from pengimport WHERE kod_pengimport='" & Request("user") & "'"
        Dim sqlRdr As System.Data.SqlClient.SqlDataReader
        sqlRdr = opClass.DataReader(sqlText)
        If sqlRdr.HasRows Then
            sqlRdr.Read()
            Label2.Text = sqlRdr.GetValue(0).Trim & ("")
            Label3.Text = sqlRdr.GetValue(1).Trim & ("")
            sqlRdr.Close()
            sqlRdr = Nothing
        Else
            Dim popupScript As String = "<script language='javascript'>" & _
                                           "alert('pengimport Tidak Wujud!!!');history.back();" & _
                                           "</script>"
            Response.Write(popupScript)
        End If
        ' textbox1.ReadOnly = True
        ' textbox2.ReadOnly = True

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    Protected Sub reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles reset.Click
        Server.Transfer("pintumasuk_edit_lkim_user.aspx")
    End Sub
End Class
