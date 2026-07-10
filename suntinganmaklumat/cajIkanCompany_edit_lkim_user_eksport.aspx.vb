Imports System.Security
Imports secureInfo
Partial Class UserManagement_LKIM_edit_lkim_user_eksport
    Inherits System.Web.UI.Page

    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Protected hakAkses As String
    Protected display As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlText As String
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        display = "none"

        If Not Page.IsPostBack Then

            sqlText = "SELECT Kategori_ikan,kadar_peti_kecil,kadar_peti_besar,kadar_ekor,kadar_kuantiti,tarikh_mula,tarikh_tamat,id" & _
            " FROM company_ikan_caj_eksport WHERE id='" & Request("user") & "'"
            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                Label1.Text = sqlRdr.GetValue(0).Trim & ("")
                Label2.Text = sqlRdr.GetValue(1)
                Label3.Text = sqlRdr.GetValue(2)
                Label4.Text = sqlRdr.GetValue(3)
                Label5.Text = sqlRdr.GetValue(4)
                Label6.Text = sqlRdr.GetValue(5)
                Label7.Text = sqlRdr.GetValue(6)
                Label8.Text = sqlRdr.GetValue(7)
                Label9.Text = sqlRdr.GetValue(7)
                'Label10.Text = sqlRdr.GetValue(8)
                sqlRdr.Close()
                sqlRdr = Nothing
            Else
                Dim popupScript As String = "<script language='javascript'>" & _
                                               "alert('company_ikan_caj Tidak Wujud!!!');history.back();" & _
                                               "</script>"
                Response.Write(popupScript)
            End If

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub

    Protected Sub Batal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Batal.Click

        Dim sqlText As String = "select count(*) from company_ikan_caj_eksport where id='" & Label8.Text & "'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        sqlText = "update company_ikan_caj_eksport set status='No' where id='" & Label8.Text & "'"
        'sqlText = "delete from bentuk_ikan_4 where kod_bentuk_ikan_4='" & Label1.Text & "'"
        opClass.InsertData(sqlText)

        If opClass.ErrorSignal = False Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                    "alert('Maklumat company ikan caj Telah Selamat Dihapuskan!!!');location.href='cajIkanCompanyEksport.aspx';" & _
                                    "</script>"
            Response.Write(popupScript)
        Else
            Dim popupScript As String = "<script language='javascript'>" & _
                                     "alert('Sistem Error !!! Maklumat company ikan caj Tidak Dapat Dihapuskan!!!');" & _
                                     "</script>"
            Response.Write(popupScript)
        End If
        'End If
    End Sub

    Protected Sub papar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles papar.Click
        Server.Transfer("cajIkanCompanyEksport.aspx")
    End Sub
End Class
