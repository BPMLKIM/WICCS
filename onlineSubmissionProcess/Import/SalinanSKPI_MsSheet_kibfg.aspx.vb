Imports System
Imports System.Data
Imports System.Collections
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class Laporan_Papar_Laporan_kibfg
    Inherits System.Web.UI.Page
    Protected opClass As SQLOperation


    Protected Sub redisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles redisplay.Click

        'If redisplay.Page.IsPostBack Then
        If Trim(sender.Id) = "redisplay" Then

            Dim sqlText As String = ""
            Dim SQLReader As System.Data.SqlClient.SqlDataReader

            Dim ImEx As Integer = 0
            Dim invois_id As Integer

            sqlText = "select pengisytiharan_i_kibfg.status,no_invois.no_invois from pengisytiharan_i_kibfg inner join no_invois on no_invois.no_barcode=pengisytiharan_i_kibfg.no_barcode where pengisytiharan_i_kibfg.no_barcode = '" & Trim(txtNoBarcode.Text) & "'"
            '"' and no_skpi = '" & Trim(txtNoSkpi.Text) & "'"
            ' Response.Write(sqlText)

            SQLReader = opClass.DataReader(sqlText)
            If SQLReader.HasRows Then
                SQLReader.Read()
                ImEx = 1
                invois_id = SQLReader.GetValue(1)
            End If
            SQLReader.Close()

            'If ImEx = 0 Then
            '    sqlText = "select pengisytiharan_e.status,no_invois_eksport.no_invois from pengisytiharan_e inner join no_invois_eksport on no_invois_eksport.no_barcode=pengisytiharan_e.no_barcode where pengisytiharan_e.no_barcode = '" & Trim(txtNoBarcode.Text) & "'"
            '    '"' and no_skpe = '" & Trim(txtNoSkpi.Text) & "'"
            '    ' Response.Write(sqlText)

            '    SQLReader = opClass.DataReader(sqlText)
            '    If SQLReader.HasRows Then
            '        SQLReader.Read()
            '        ImEx = 2
            '        invois_id = SQLReader.GetValue(1)
            '    End If
            '    SQLReader.Close()
            'End If

            If ImEx > 0 Then

                Dim strUrl As String = ""
                If pilihan.SelectedValue = "SLIP REBAT" Then

                    If ImEx = 1 Then
                        strUrl = "'eskpi_kibfg1.aspx?barcode=" & txtNoBarcode.Text & "&skpi=" & Trim(txtNoSkpi.Text) & "'"
                        'load skpi
                        Response.Write("<script>window.open(" & strUrl & ");</script>")
                        Response.Write("<script>self.location.href='SalinanSKPI_MsSheet_kibfg.aspx'</script>")
                        'ElseIf ImEx = 2 Then
                        '    strUrl = "'eskpe.aspx?barcode=" & txtNoBarcode.Text & "&skpi=" & Trim(txtNoSkpi.Text) & "'"
                        '    'load skpi
                        '    Response.Write("<script>window.open(" & strUrl & ");</script>")
                        '    Response.Write("<script>self.location.href='SalinanSKPI_MsSheet.aspx'</script>")
                    End If

                ElseIf pilihan.SelectedValue = "MasterSheet" Then
                    If ImEx = 1 Then
                        strUrl = "'crMasterSheetImport_kibfg1.aspx?barcode=" & txtNoBarcode.Text & "&invois_id=" & invois_id & "&SalinanMS=SALINAN-BUKIT KAYU HITAM'"
                        'load skpi
                        Response.Write("<script>window.open(" & strUrl & ");</script>")
                        Response.Write("<script>self.location.href='SalinanSKPI_MsSheet_kibfg.aspx'</script>")
                        'ElseIf ImEx = 2 Then
                        '    strUrl = "'crMasterSheetEksport.aspx?barcode=" & txtNoBarcode.Text & "&invois_id=" & invois_id & "&SalinanMS=SALINAN-BUKIT KAYU HITAM'"
                        '    'load skpi
                        '    Response.Write("<script>window.open(" & strUrl & ");</script>")
                        '    Response.Write("<script>self.location.href='SalinanSKPI_MsSheet.aspx'</script>")
                    End If

                End If
            Else
                Response.Write("<script>alert('No Barcode & SKPI Tidak Wujud!!!!');</script>")
            End If

            SQLReader = Nothing

        End If
    End Sub

    Protected Sub returnmenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Write("<script language=javascript>location.href='Laporan.aspx';</script>")
    End Sub

    Protected Sub Laporan_Papar_Laporan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        opClass = New SQLOperation()
        opClass.dbConnection()
    End Sub


End Class


