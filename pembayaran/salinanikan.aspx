<%@ Page Language="VB" AutoEventWireup="false" CodeFile="salinanikan.aspx.vb" Inherits="salinanikan" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PEMERIKSAAN</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
    <!-- #include file="library/validation.htm" -->
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">
 
// show senarai printer
function showSenaraiprinter()
{
  window.open('senarai-printer.aspx','test','width=310,height=420,status=yes');  
}

function cetakReport()
{
if (document.form1.txtRujukan.value == '')
{alert('Sila masukkan nombor barcode');return false;}

if (document.all.printer_name.value == '')
{alert('Sila Pilih Printer');return false;}
else
{
var str ="cetakResit.aspx?printer_name=" + document.all.printer_name.value + "&print_status=Y&barcode="+ document.all.txtRujukan.value;
window.open(str,'iResitG1a','');
}
}

function cetakReport1()
{
if (document.form1.txtRujukan.value == '')
{alert('Sila masukkan nombor barcode');return false;}

if (document.all.printer_name.value == '')
{alert('Sila Pilih Printer');return false;}
else
{
var str ="cetakResit_kibfg.aspx?printer_name=" + document.all.printer_name.value + "&print_status=Y&barcode="+ document.all.txtRujukan.value;
window.open(str,'iResitG1a_kibfg','');
}

}

// end coded
</script>
<body style="color: #000000">
    <form id="form1" runat="server" method="post">
    <div>
        <br />
        <table style="width: 90%">
            <tr>
                <td bgcolor="#996666" colspan="2" style="width: 682px; text-align: center">
                    <strong><span style="color: #ffffff">SALINAN CAJ PERKHIDMATAN IKAN UNTUK BAYARAN INDIVIDU</span></strong></td>
            </tr>
        </table>
        <br />
        <table style="width: 608px">
            <tr>
                <td style="width: 235px; height: 15px">
                    No Barcode</td>
                <td style="width: 481px; height: 15px">
                    :
                    <asp:TextBox ID="txtRujukan" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 235px; height: 15px">
                </td>
                <td style="width: 481px; height: 15px">
                    :
                    <input id="Button7" runat="server" onclick="cetakReport();" style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        type="button" value="CETAK RESIT" />
                    <input id="Button3" runat="server" onclick="showSenaraiprinter();" style="border-right: #333333 1px ridge;
                            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                            type="button" value="PILIH PRINTER" />
                    <input id="Button1" runat="server" onclick="cetakReport1();" style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        type="button" value="CETAK RESIT REBAT" /></td>
            </tr>
        </table>
        &nbsp;&nbsp;
        <asp:HiddenField ID="printer_name" runat="server" />
   
       <br />
        <table style="width: 90%">
            <tr>
                <td bgcolor="#996666" colspan="2" style="width: 682px; height: 16px; text-align: center">
                    <strong><span style="color: #ffffff">&nbsp;</span></strong></td>
            </tr>
        </table>
    </div>
  </form>

</body>
</html>
