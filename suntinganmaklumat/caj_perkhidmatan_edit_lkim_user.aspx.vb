Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_edit_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim sqlText As String = "select count(*) from caj_perkhidmatan where kod_caj='" & textbox1.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        sqlText = "UPDATE caj_perkhidmatan set kod_caj='" & textbox1.Text & "', nama_caj='" & textbox2.Text & "', kadar_caj='" & TextBox3.Text & "', cara_pembayaran='" & TextBox4.Text & "', dicaj_oleh='" & TextBox5.Text & "' WHERE kod_caj='" & textbox1.Text & "'"

        opClass.InsertData(sqlText)

        If opClass.ErrorSignal = False Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                    "alert('Maklumat Telah Selamat Dikemaskini!!!');location.href='caj_perkhidmatan.aspx';" & _
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

            sqlText = "SELECT kod_caj, Nama_caj, kadar_caj, cara_pembayaran, dicaj_oleh" & _
            " FROM caj_perkhidmatan WHERE Nama_caj='" & Request("user") & "'"
            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                textbox1.Text = sqlRdr.GetValue(0).Trim & ("")
                textbox2.Text = sqlRdr.GetValue(1).Trim & ("")
                TextBox3.Text = sqlRdr.GetValue(2)
                TextBox4.Text = sqlRdr.GetValue(3).Trim & ("")
                TextBox5.Text = sqlRdr.GetValue(4).Trim & ("")
                sqlRdr.Close()
                sqlRdr = Nothing
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                               "alert('caj perkhidmatan Tidak Wujud!!!');history.back();" & _
                                               "</script>"
                Response.Write(popupScript)
            End If
            textbox1.Enabled = False

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sqlText As String = "select count(*) from caj_perkhidmatan where kod_caj='" & textbox1.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount < 1 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Maklumat Tidak Wujud!!!');" & _
                                         "</script>"
            Response.Write(popupScript)

        Else
            sqlText = "update caj_perkhidmatan set status='no' where kod_caj='" & textbox1.Text & "'"
            'sqlText = "delete from caj_perkhidmatan where kod_caj='" & textbox1.Text & "'"
            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = False Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                        "alert('Maklumat Telah Selamat Dihapuskan!!!');location.href='caj_perkhidmatan.aspx';" & _
                                        "</script>"
                Response.Write(popupScript)
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Sistem Error !!! Maklumat Tidak Dapat Dihapuskan!!!');" & _
                                         "</script>"
                Response.Write(popupScript)
            End If
        End If
    End Sub
End Class
