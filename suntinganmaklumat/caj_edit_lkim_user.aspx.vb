Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_edit_lkim_user
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String


    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click

        Dim sqlText As String = "select count(*) from IKAN_CAJ where id='" & textbox1.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        sqlText = "UPDATE ikan_caj set kategori_ikan = '" & textbox2.Text & "', jenis_urusan = '" & TextBox3.Text & "', kadar_peti_kecil = " & TextBox4.Text & ", kadar_peti_besar = " & TextBox5.Text & ", kadar_ekor = " & TextBox6.Text & ", kadar_kuantiti = " & TextBox7.Text & " where id ='" & textbox1.Text & "'"
        'Response.Write("UPDATE IKAN_CAJ set id='" & textbox1.Text & "', Kategori_Ikan ='" & textbox2.Text & "', Jenis_Urusan  ='" & TextBox3.Text & "', Kadar_Peti_Kecil ='" & TextBox4.Text & "', Kadar_Peti_besar ='" & TextBox5.Text & "', Kadar_ekor ='" & TextBox6.Text & "', Kadar_Kuantiti ='" & TextBox7.Text & "' WHERE id='" & textbox1.Text & "'")
        opClass.InsertData(sqlText)

        If opClass.ErrorSignal = False Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                    "alert('Maklumat Telah Selamat Dikemaskini!!!');location.href='caj.aspx';" & _
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

            sqlText = "SELECT ID , Kategori_Ikan , Jenis_Urusan , Kadar_Peti_Kecil , Kadar_Peti_Besar , Kadar_Ekor , Kadar_Kuantiti FROM IKAN_CAJ WHERE id='" & Request("user") & "'"
            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                textbox1.Text = sqlRdr.GetValue(0)
                textbox2.Text = sqlRdr.GetValue(1).Trim & ("")
                TextBox3.Text = sqlRdr.GetValue(2).Trim & ("")
                TextBox4.Text = CInt(sqlRdr.GetValue(3))
                TextBox5.Text = CInt(sqlRdr.GetValue(4))
                TextBox6.Text = CInt(sqlRdr.GetValue(5))
                TextBox7.Text = CInt(sqlRdr.GetValue(6))
                sqlRdr.Close()
                sqlRdr = Nothing
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                               "alert('caj ikan Tidak Wujud!!!');history.back();" & _
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

        Dim sqlText As String = "select count(*) from ikan_caj where id='" & textbox1.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount < 1 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Maklumat Tidak Wujud!!!');" & _
                                         "</script>"
            Response.Write(popupScript)

        Else
            sqlText = "update ikan_caj set status='no' where id='" & textbox1.Text & "'"
            'sqlText = "delete from ikan_caj where id='" & textbox1.Text & "'"
            opClass.InsertData(sqlText)

            If opClass.ErrorSignal = False Then
                Dim popupScript As String = "<script language='javascript'>" & _
                                        "alert('Maklumat Telah Selamat Dihapuskan!!!');location.href='caj.aspx';" & _
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
