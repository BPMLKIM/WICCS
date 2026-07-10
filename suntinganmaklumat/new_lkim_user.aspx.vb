Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_new_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim sqlText As String

        sqlText = "select count(*) from agen_pengangkutan where kod_agen_pengangkutan='" & kod_agen_pengangkutan.Text & "' or nama_agen_pengangkutan='" & nama_agen_pengangkutan.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount > 0 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Kod agen atau Nama Agen Sudah Wujud!!!\nPilih Yang Lain.');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else
            sqlText = "INSERT INTO [W-ICCS].[dbo].[agen_pengangkutan] (kod_agen_pengangkutan ,nama_agen_pengangkutan, alamat_agen_pengangkutan, deposit_semasa, transaksi_semasa)" & _
            "VALUES('" & kod_agen_pengangkutan.Text & "','" & nama_agen_pengangkutan.Text & "','" & alamat_agen_pengangkutan.Text & "','0','0')"

            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = True Then
                Response.Write(opClass.ErrorList(0).ToString())
                Dim popupScript As String = "<script language='javascript'>" & _
                                            "alert('Sistem Error !!! Maklumat Tidak Dapat Disimpan!!!');history.back();" & _
                                            "</script>"
                Response.Write(popupScript)
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                            "alert('Maklumat Telah Selamat Disimpan!!!');" & _
                                            "</script>"
                Response.Write(popupScript)
                NewUser.Enabled = False
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub
End Class
