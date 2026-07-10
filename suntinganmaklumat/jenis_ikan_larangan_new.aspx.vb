Imports System.Security
Imports secureInfo
Imports system.Data.SqlTypes


Partial Class jenis_ikan_larangan_new
    Inherits System.Web.UI.Page
    Protected myEnc As New Encryption64
    Protected opClass As SQLOperation
    Public jsReader As System.Data.SqlClient.SqlDataReader



    Protected Sub NewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUser.Click



        Dim sqlText As String
        If t_mula.Text = "" Then
            t_mula.Text = "01/01/1900"
        End If
        'Dim tmula1 As Date = CDate(t_mula.Text)
        Dim tmula As String = Format(CDate(t_mula.Text), "MM/dd/yyyy")

        If t_tamat.Text = "" Then
            t_tamat.Text = "01/01/1900"
        End If
        'Dim ttamat1 As Date = CDate(t_tamat.Text)
        Dim ttamat As String = Format(CDate(t_tamat.Text), "MM/dd/yyyy")

        sqlText = "select count(*) from jenis_ikan_larangan where kod_ikan='" & Ikan.Text & "' and t_mula='" & tmula & "' and t_tamat='" & ttamat & "' and status='yes'"
        Dim rcount As Integer = opClass.SingleFieldResults(sqlText)

        If rcount > 0 Then
            Dim popupScript As String = "<script language='javascript'>" & _
                                         "alert('Kod Ikan Sudah Wujud!!!\nPilih Kod Ikan Yang Lain.');" & _
                                         "</script>"
            Response.Write(popupScript)
        Else



            sqlText = "INSERT INTO [w-iccs].[dbo].[jenis_ikan_larangan] " & _
                      "(kod_bkh,kod_ikan, nama_bkh,t_mula, t_tamat,status) values('" & searchKodIkan.Text & "','" & Ikan.Text & "','" & Ikan1.Text & "','" & tmula & _
                      "',   '" & ttamat & "','yes')"


            opClass.InsertData(sqlText)

            If t_mula.Text = "01/01/1900" Then
                t_mula.Text = ""
            End If

            If t_tamat.Text = "01/01/1900" Then
                t_tamat.Text = ""
            End If


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



                'Dim sqlText1 As String
                'sqlText1 = "INSERT INTO [log_pemantauan] " & _
                '  "(user_id, nama_skrin,aktiviti, entry_date) values('" & Session("username") & _
                '  "', 'w_entry_peribadi_new.aspx','Simpan Maklumat Peribadi', getdate())"
                'opClass.InsertData(sqlText1)

            End If
        End If



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlText As String
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()
        Dim kodikan As String = Request.QueryString("kod_ikan")
        Dim nop As String = Request.QueryString("t_mula")
        Dim idp As String = Request.QueryString("idp")


        If Not Page.IsPostBack Then


            sqlText = "SELECT t_mula, t_tamat,catatan from tempoh_larangan WHERE status='A'"

            Dim sqlRdr As System.Data.SqlClient.SqlDataReader
            sqlRdr = opClass.DataReader(sqlText)
            If sqlRdr.HasRows Then
                sqlRdr.Read()
                t_mula.Text = Format(sqlRdr.GetValue(0), "dd/MM/yyyy")
                t_tamat.Text = Format(sqlRdr.GetValue(1), "dd/MM/yyyy")

                If t_mula.Text = "01/01/1900" Then
                    t_mula.Text = ""
                End If

                If t_tamat.Text = "01/01/1900" Then
                    t_tamat.Text = ""
                End If
              


               


            End If
            sqlRdr.Close()
            sqlRdr = Nothing
        End If


        'catatan.Attributes.Add("onKeyPress", "return keyToUpperCase(this, event);")


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        opClass.dbConnection_Close()
    End Sub



End Class
