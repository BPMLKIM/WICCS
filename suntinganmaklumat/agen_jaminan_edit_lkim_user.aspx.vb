Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_edit_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim sqlText As String = "select count(*) from agen_jaminan_bank where kod_agen_pengangkutan='" & kod_agen_pengangkutan.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        sqlText = "UPDATE agen_jaminan_bank set kod_agen_pengangkutan='" & kod_agen_pengangkutan.Text & "', nama_agen_pengangkutan='" & nama_agen_pengangkutan.Text & "', jaminan_bank='" & deposit_semasa.Text & "' WHERE kod_agen_pengangkutan='" & kod_agen_pengangkutan.Text & "'"

        opClass.InsertData(sqlText)

        If opClass.ErrorSignal = False Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                    "alert('Maklumat Telah Selamat Dikemaskini!!!');location.href='agen_jaminan_list_users.aspx';" & _
                                    "</script>"
            Response.Write(popupScript)
            NewUser.Enabled = False
        Else
            Dim popupScript As String = "<script language='javascript'>" & _
                                     "alert('Sistem Error !!! Maklumat Tidak Dapat Dikemaskini!!!');" & _
                                     "</script>"
            Response.Write(popupScript)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlText As String
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        display = "none"

        If Not Page.IsPostBack Then

            sqlText = "SELECT Kod_Agen_Pengangkutan, Nama_Agen_Pengangkutan, jaminan_bank" & _
            " FROM agen_jaminan_bank WHERE Kod_Agen_Pengangkutan='" & Request("user") & "'"
            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                kod_agen_pengangkutan.Text = sqlRdr.GetValue(0).Trim & ("")
                nama_agen_pengangkutan.Text = sqlRdr.GetValue(1).Trim & ("")
                deposit_semasa.Text = sqlRdr.GetValue(2)
                sqlRdr.Close()
                sqlRdr = Nothing
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                               "alert('Agen Tidak Wujud!!!');history.back();" & _
                                               "</script>"
                Response.Write(popupScript)
            End If
            kod_agen_pengangkutan.Enabled = False

        End If


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sqlText As String = "select count(*) from agen_jaminan_bank where kod_agen_pengangkutan='" & kod_agen_pengangkutan.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount < 1 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Maklumat agen Tidak Wujud!!!');" & _
                                         "</script>"
            Response.Write(popupScript)

        Else
            sqlText = "UPDATE agen_jaminan_bank set status='no' WHERE kod_agen_pengangkutan='" & kod_agen_pengangkutan.Text & "'"
            'sqlText = "delete from agen_pengangkutan where kod_agen_pengangkutan='" & kod_agen_pengangkutan.Text & "'"
            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = False Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                        "alert('Maklumat agen Telah Selamat Dihapuskan!!!');location.href='agen_jaminan_list_users.aspx';" & _
                                        "</script>"
                Response.Write(popupScript)
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Sistem Error !!! Maklumat agen Tidak Dapat Dihapuskan!!!');" & _
                                         "</script>"
                Response.Write(popupScript)
            End If
        End If
    End Sub
End Class
