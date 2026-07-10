Imports System.Security
Imports secureInfo
Partial Class tempoh_larangan_ikan
    Inherits System.Web.UI.Page
    Protected opClass As SQLOperation
    Protected myEnc As New Encryption64
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onClick", "HighLightTR('#c9cc99','cc3333');location.href='tempoh_larangan_ikan_edit.aspx?user=" & e.Row.DataItem(0).ToString() & "';")
            'Response.Write("location.href='lesen_lkim_user.aspx?user=" & e.Row.DataItem(0).ToString() & "';")
        End If
    End Sub

    Protected Sub Kembali_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Server.Transfer("suntingmaklumat.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myEnc = New Encryption64()
        opClass = New SQLOperation()
        opClass.dbConnection()

        'Dim sqlText As String
        'sqlText = "INSERT INTO [log_pemantauan] " & _
        '          "(user_id, nama_skrin,aktiviti, entry_date) values('" & Session("username") & _
        '          "', 'w_entry_peribadi.aspx','Senarai Peribadi', getdate())"
        'opClass.InsertData(sqlText)

        If Session("viewas") = "V" Then
            NewUser.Visible = False
        Else
            NewUser.Visible = True
        End If

    End Sub

End Class
