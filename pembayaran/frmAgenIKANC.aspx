<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAgenIKANC.aspx.vb" Inherits="pembayaran_frmAgenIKANC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PEMBAYARAN AGEN IKAN</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="windowfiles/dhtmlwindow.css" type="text/css" />

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

 <script language="javascript" type="text/javascript" src="popcalendar.js"></script>
 
 <script type="text/javascript" src="windowfiles/dhtmlwindow.js">

/***********************************************
* DHTML Window Widget- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for legal use.
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/

</script>
 
 <script language="javascript" type="text/javascript">
 
function printReport()
{
var str ="cetakResitA.aspx?print_status=" + document.all.print_status.value + "&kod_agen=" + document.all.kod_agen.value + "&arrayValT=" + document.all.arrayVal.value;
//var str ="http://quest2003/reportw-iccs/pembayaran/cetakResitA.aspx?print_status=" + document.all.print_status.value + "&kod_agen=" + document.all.kod_agen.value + "&arrayValT=" + document.all.arrayVal.value;

window.open(str,'LKIM','');

}

function cetakReport()
{
if (document.all.printer_name.value == '')
{alert('Sila Pilih Printer');}
else
{
var str ="cetakResitA.aspx?printer_name=" + document.all.printer_name.value + "&print_status=Y&kod_agen=" + document.all.kod_agen.value + "&arrayValT=" + document.all.arrayVal.value;
//var str ="http://quest2003/reportw-iccs/pembayaran/cetakResitA.aspx?printer_name=" + document.all.printer_name.value + "&print_status=" + document.all.print_status.value + "&kod_agen=" + document.all.kod_agen.value + "&arrayValT=" + document.all.arrayVal.value;

window.open(str,'LKIM','');
}

}


// show senarai agen
function showSenaraiAgen()
{
agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "http://wiccs.lkim.gov.my/pembayaran/senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
}

// end coded


// show senarai printer
function showSenaraiprinter()
{
  window.open('senarai-printer.aspx','test','width=310,height=420,status=yes');  
}

// end coded


function refreshIkan()
{
    
    var totalRows;
 
    if (document.all("Table1").rows.length==undefined)
    {
        totalRows=-1;
    }
    else
    {
        totalRows=document.all("Table1").rows.length;
    }
      
         //clear tables rows for current importer fish declaration    
    var i=0;
    for(i=1;i<totalRows;i++)
    {
        document.all("Table1").deleteRow(1);
    }        
  
     //Load Importer declaration information   
        
          var strImporter = document.all.arrayVal.value;
          var arrImporter = strImporter.split("~");
          var strTunai = 0;
          var strCek = 0;
          
                  
      for (i=0;i<arrImporter.length-1; i++)
    
        {
        
            var myString = arrImporter[i]+ "~";
            var arrImporterInfoDetails  = arrImporter[i].split("`");            
            var arrImporterDetails = arrImporterInfoDetails[i];
             
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("Table1").insertRow();	
	     //   var oCell = newRow.insertCell();
	    
	     //   oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[1];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = centPlace(arrImporterInfoDetails[2]);
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[3];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[4];
	        
	                  
   	        if (arrImporterInfoDetails[3]=='TUNAI')
	        {strTunai = parseFloat(strTunai) + parseFloat(arrImporterInfoDetails[2]);}
	        
        
            if (arrImporterInfoDetails[3]=='CEK')
	        {strCek = parseFloat(strCek) + parseFloat(arrImporterInfoDetails[2]);}	  
         
        }//end for
        
        document.form1.txtTunai.value = centPlace(strTunai);
        document.form1.txtKredit.value = centPlace(strCek);
        
}      


</script>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table  style="width: 90%">
            <tr>
                <td colspan="2" style="height: 18px; background-color: #6600ff">
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Cetak pembayaran CAJ Melalui Agen" Width="344px" Font-Bold="True" ForeColor="White"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 257px">
                </td>
                <td style="width: 612px">
                </td>
            </tr>
            <tr>
                <td style="width: 257px">
                    Tarikh</td>
                <td style="width: 612px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><img src="../Image/calendar.jpg" width="14" height="17" onclick="javascript:popUpCalendar(this,TextBox2,'dd/mm/yyyy');return false;" /> </td>
            </tr>
            <tr>
                <td style="width: 257px">
                    Kod Agen Pengangkutan</td>
                <td style="width: 612px">
                    <asp:TextBox ID="kod_agen" runat="server"></asp:TextBox>
                    <input id="calender2" runat="server" class="textbox" name="choose2" onclick="showSenaraiAgen(); return false;"
                        style="border-left-color: white; background-image: url(../images/search.gif);
                        border-bottom-color: white; width: 18px; cursor: hand; border-top-style: none;
                        border-top-color: white; border-right-style: none; border-left-style: none; height: 22px;
                        background-color: white; border-right-color: white; border-bottom-style: none"
                        type="button" value=" " visible="true" />
                    <asp:Button ID="Button1" runat="server" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; 
                    BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: 
                    #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" Text="Open" /></td>
            </tr>
            <tr id="id_nameagen" runat="server" style="display: none">
                <td style="width: 257px; height: 15px;">
                    Nama Agen Pengangkutan</td>
                <td style="width: 612px; height: 15px;">
                    <asp:Label ID="name_agen" runat="server"></asp:Label></td>
            </tr>
            
            <tr>
                <td style="width: 257px">
                </td>
                <td style="width: 612px">
                </td>
            </tr>
        </table>
        &nbsp; &nbsp;
        &nbsp;
        &nbsp;&nbsp;
        <br />
        <table id="Table1" style="width: 100% ;">
            <tr style="width: 100% ; background-color:#6600ff;">
                <td style="width: 6156px; height: 13px">
                    <strong><span style="color: #ffffff">No Barcode</span></strong></td>
                <td style="width: 6769px; height: 13px;">
                    <span style="color: #ffffff"><b>No Invois</b></span></td>
                <td style="width: 5513px; height: 13px;">
                    <span style="color: #ffffff"><strong>Caj&nbsp; (RM)</strong></span></td>
                <td style="width: 4356px; height: 13px;">
                    <span style="color: #ffffff"><strong>Cara Pembayaran</strong></span></td>
                <td style="width: 4356px; height: 13px">
                    <strong><span style="color: #ffffff">No Cek</span></strong></td>
            </tr>
        </table>
        <br />
        <input id="Button4" runat="server" onclick="self.location.href='verifikasi_bayar.aspx?type=ikan';"
            style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" type="button" value="BARU" /><input id="cmdResit" runat="server"
                onclick="printReport();" style="border-right: #333333 1px ridge; padding-right: 1px;
                border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
                value="PAPAR RESIT" /><input id="Button7" runat="server" onclick="cetakReport();"
                    style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
                    padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
                    color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
                    background-color: #f1f1f1" type="button" value="CETAK RESIT" /><input id="Button2" runat="server" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" type="button" onclick="showSenaraiprinter();" value="PILIH PRINTER" /><br />
        <br />
        <table style="width: 80% ;">
            <tr>
                <td style="width: 263px; height: 15px">
                    Jumlah Tunai</td>
                <td style="width: 324px; height: 15px">
                    <asp:TextBox ID="txtTunai" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                    Jumlah Kredit</td>
                <td style="width: 486px; height: 15px">
                    <asp:TextBox ID="txtKredit" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 263px; height: 15px">
                    Status Pembayaran</td>
                <td style="width: 324px; height: 15px">
                    <asp:TextBox ID="lblStatusPembayaran" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                    Deposit Semasa</td>
                <td style="width: 486px; height: 15px">
                    <asp:TextBox ID="lbldepositagen" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 263px; height: 15px">
                    Jumlah Kredit Individual</td>
                <td style="width: 324px; height: 15px">
                    <asp:TextBox ID="kreditIn" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                </td>
                <td style="width: 486px; height: 15px">
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;<asp:HiddenField ID="arrayVal" runat="server" />
        <asp:HiddenField ID="print_status" runat="server" />
        <asp:HiddenField ID="printer_name" runat="server" /></div>
  
   <script language="javascript" type="text/javascript">
      refreshIkan();
   </script> 
  
  </form>
  
  

</body>
</html>
