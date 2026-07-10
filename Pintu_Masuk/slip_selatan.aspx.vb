Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalLibrary

Partial Class _Default
    Inherits System.Web.UI.Page

    Private crSKPI As ReportDocument
    Private masterSheet1 As ReportDocument
    Private masterSheet2 As ReportDocument
    Private masterSheet3 As ReportDocument
    Private masterSheet4 As ReportDocument

    Protected opClass As SQLOperation


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        opClass = New SQLOperation()
        opClass.dbConnection()

        Dim barcodeEntry As String = Request("barcode")



        Dim sqlText As String = ""
        
        '=====================================================================
        'Ready To Load Report Processing
        '=====================================================================


        Dim formula As String = "{PENDAFTARAN_PINTU.Nombor_Barcode} = '" & Request("barcode") & "'"


      

        If Request("cetak") = "1" Then

            Dim m As Integer = 0
            For m = 1 To 3
                cetak.Value = Request("cetak")
                Dim namaPrinter As String = Request("pname").Replace("/", "\") 'printer_name.Value '"KONICA MINOLTA 7145/IP-432" '
                'Response.Write(printer_name.Value)

                Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
                myConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings("dbname")
                myConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings("userid")
                myConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings("dbpassword")
                myConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings("servername")

                crSKPI = New ReportDocument()

                Dim reportPath As String = Server.MapPath("rpt/slip_selatan.rpt")

                crSKPI.Load(reportPath)

                If m = 1 Then
                    crSKPI.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN AGEN PENGANGKUTAN'"
                ElseIf m = 2 Then
                    crSKPI.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN KOMPLEKS/PPI LKIM'"
                ElseIf m = 3 Then
                    crSKPI.DataDefinition.FormulaFields("MS_Salinan").Text = "'SALINAN AGEN LKIM'"
                End If

                Dim selectFormula As String = formula '"{PENGISYTIHARAN_I.No_Barcode} = '" & Request("barcode") & "' AND {PENGISYTIHARAN_I.Status} = 'A'"
                crSKPI.DataDefinition.RecordSelectionFormula = selectFormula
                opClass.SetDBLogonForReport(myConnectionInfo, crSKPI)
                crSKPI.PrintOptions.PrinterName = namaPrinter
                crSKPI.PrintToPrinter(1, False, 0, 0)
            Next

           
        End If

    End Sub
 


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        crSKPI.Close()
        crSKPI.Dispose()
        'masterSheet1.Close()
        'masterSheet1.Dispose()
        'masterSheet2.Close()
        'masterSheet2.Dispose()
        'masterSheet3.Close()
        'masterSheet3.Dispose()
        'masterSheet4.Close()
        'masterSheet4.Dispose()
        GC.SuppressFinalize(True)
        GC.Collect()
        
    End Sub
End Class
