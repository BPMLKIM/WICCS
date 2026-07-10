<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pembayaranNewI.aspx.vb" Inherits="pembayaran_pembayaranNewI" %>
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
</head>

<script language="javascript" type="text/javascript">

function keyToUpperCase(field, evt) {
  if (document.all) {
    var c = event.keyCode;
    var C = String.fromCharCode(c).toUpperCase().charCodeAt(); 
    event.keyCode = C;
    return true;
  }
  else 
    return true;
}

// show senarai printer
function showSenaraiprinter()
{
  window.open('senarai-printer.aspx','test','width=310,height=420,status=yes');  
}

// end coded


function printReport()
{
var winTitle;

winTitle = "SALINAN LKIM-BUKIT KAYU HITAM";
var str ="<%=filetransfer%>?print_status=" + document.all.print_status.value + "&Urusan=" + document.all.Urusan.value + "&barcode="+ document.all.txtRujukan.value +"&SalinanMs="+ escape(winTitle);
//var str ="http://quest2003/reportw-iccs/pembayaran/<%=filetransfer%>?print_status=" + document.all.print_status.value + "&Urusan=" + document.all.Urusan.value + "&barcode="+ document.all.txtRujukan.value +"&SalinanMs="+ escape(winTitle);
window.open(str,'iResitG1a','');
}


function cetakReport()
{
if (document.all.printer_name.value == '')
{alert('Sila Pilih Printer');}
else
{
//var str ="http://quest2003/reportw-iccs/pembayaran/cetakResit.aspx?printer_name=" + document.all.printer_name.value + "&print_status=Y&Urusan=" + document.all.Urusan.value + "&barcode="+ document.all.txtRujukan.value;
var str ="<%=filetransfer%>?printer_name=" + document.all.printer_name.value + "&print_status=" + document.all.print_status.value + "&Urusan=" + document.all.Urusan.value + "&barcode="+ document.all.txtRujukan.value;
window.open(str,'iResitG1a','');
}

}


function display()
{
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK') 
    {document.all.no_cek.style.display='block';document.all.id_tunai.style.display='none';document.all.id_cek.style.display='none';} 
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='TUNAI')
    {document.all.no_cek.style.display='none';document.form1.txtCek.value='';document.all.id_tunai.style.display='none';document.all.id_cek.style.display='none';}
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK / TUNAI')
   {document.all.no_cek.style.display='block';document.all.id_tunai.style.display='block';document.all.id_cek.style.display='block';} 
    
}

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
           
          //Load caj ikan information   
        
          var strIkan = document.all.arrayVal.value;    
          var strIkan1 = strIkan.split("~");
          //alert(strIkan);
          
            //add a row to the rows collection and get a reference to the newly added row
            
        for (i=0;i<strIkan1.length-1; i++)
        {
           var strIkanDetail  = strIkan1[i].split("`");
	       var newRow = document.all("Table1").insertRow();
	       var oCell = newRow.insertCell();
	       var myString = strIkan1[i]+ "~";
	       
           oCell.innerHTML = strIkanDetail[0];
           oCell = newRow.insertCell();
           oCell.innerHTML = centPlace(strIkanDetail[1]);
	       oCell = newRow.insertCell();
	       oCell.innerHTML = strIkanDetail[2];
	       oCell = newRow.insertCell();
	       oCell.innerHTML = strIkanDetail[3]; 
	        oCell = newRow.insertCell();
	       oCell.innerHTML = strIkanDetail[4];  
	        oCell = newRow.insertCell();
	       oCell.innerHTML = strIkanDetail[5]; 
	       oCell = newRow.insertCell();
	       oCell.innerHTML = strIkanDetail[6]; 
	       oCell = newRow.insertCell();
	       oCell.innerHTML = strIkanDetail[7];       
      
	    }
	    
}      


 


</script>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <br />
        <table  style="width: 90%">
            <tr>
                <td style="width: 612px; height: 18px; background-color:#6600ff; ">
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Width="344px" Font-Bold="True" ForeColor="White"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table style="width: 608px">
            <tr>
                <td style="width: 235px; height: 15px">
                    No Barcode</td>
                <td style="width: 481px; height: 15px">
                    :
                    <asp:TextBox ID="txtRujukan" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 191px; height: 15px">
                    No./Nama Kapal/Penerbangan/Kenderaan</td>
                <td style="width: 604px; height: 15px">
                    :
                    <asp:TextBox ID="lblnokenderaan" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 235px; height: 15px">
                </td>
                <td style="width: 481px; height: 15px">
                </td>
                <td style="width: 191px; height: 15px">
                </td>
                <td style="width: 604px; height: 15px">
                </td>
            </tr>
        </table>
        <asp:HiddenField
            ID="arrayVal" runat="server" />
        <asp:HiddenField ID="totalikan" runat="server" />
        <table id="Table1" style="width: 90% ;">
            <tr style="width: 100%; background-color: #6600ff;">
                <td style="width: 982px; height: 15px">
                    <strong><span style="color: #ffffff">Item</span></strong></td>
                <td style="width: 316px; height: 15px">
                    <span style="color: #ffffff"><strong>Caj(RM)</strong></span></td>
                  <%--  edited by shah for caj GST--%>
                <td style="width: 204px; height: 15px">
                    <span style="color: #ffffff"><strong>Gst(RM)</strong></span></td>
                <td style="width: 314px; height: 15px">
                    <span style="color: #ffffff"><strong>Jumlah Caj Slps Gst(RM)</strong></span></td>
                     <td style="width: 219px; height: 15px">
                    <span style="color: #ffffff"><strong>Pelarasan</strong></span></td>
                     <td style="width: 219px; height: 15px">
                    <span style="color: #ffffff"><strong>Jum. Caj Slps Pelarasan(RM)</strong></span></td>
                  <%--  end of edited by shah for caj GST--%>  
                <td style="width: 605px; height: 15px">
                    <span style="color: #ffffff"><strong>DiCaj Oleh</strong></span></td>
                <td style="width: 595px; height: 15px">
                    <span style="color: #ffffff"><strong>Tempat Isytihar</strong></span></td>
            </tr>
        </table>
        <br />
        <table style="width: 90% ;" >
            <tr>
                <td style="width: 138px; height: 22px;" >
                    Cara Pembayaran</td>
                <td style="height: 22px" >
                    <asp:DropDownList ID="cara_pembayaran" runat="server" onClick="display();">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                        <asp:ListItem Value="CEK">CEK</asp:ListItem>
                        <asp:ListItem Value="TUNAI">TUNAI</asp:ListItem>
                        <asp:ListItem Value="CEK/TUNAI">CEK / TUNAI</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr style="Display : None;" id="no_cek">
                <td style="width: 138px; height: 6px;" >
                    Nombor Cek</td>
                <td style="height: 6px" >
                    <asp:TextBox ID="txtCek" runat="server"></asp:TextBox></td>
            </tr>

            <tr style="display: none" id="id_cek" runat="server">
                <td style="width: 138px; height: 8px">
                    Nilai Cek (RM)</td>
                <td style="height: 8px">
                    <asp:TextBox ID="itemCek" runat="server" onChange="checkDecimal('form1','itemCek','Caj Cek');document.form1.itemCek.value=centPlace(document.form1.itemCek.value);"></asp:TextBox></td>
            </tr>
            
            <tr style="display: none" id="id_tunai" runat="server">
            
                <td style="width: 138px; height: 4px">
                    Jumlah Tunai ( RM )</td>
                <td style="height: 4px">
                    <asp:TextBox ID="itemTunai" runat="server" onChange="checkDecimal('form1','itemTunai','Caj Tunai');document.form1.itemTunai.value=centPlace(document.form1.itemTunai.value);"></asp:TextBox></td>
            </tr>                       

            
            <tr>
                <td style="width: 138px; height: 8px">
                    Deposit Semasa (RM)</td>
                <td style="height: 8px">
                    <asp:TextBox ID="lbldepositagen" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 138px; height: 8px">
                    Status Pembayaran</td>
                <td style="height: 8px">
                    <asp:TextBox ID="lblStatusPembayaran" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
        </table>
    </div>
        <asp:HiddenField
            ID="arrayValT" runat="server" />
        <asp:HiddenField ID="Kod_Agen" runat="server" /><asp:HiddenField ID="Urusan" runat="server" />
        <asp:HiddenField ID="selectpay" runat="server" />
        <asp:HiddenField ID="Kod_Jenis_Urusan" runat="server" />
        <asp:HiddenField ID="print_status" runat="server" /><asp:HiddenField ID="printer_name" runat="server" />
        <br /> 

   <br /><asp:Button ID="cmdBayar" runat="server" Text="BAYAR" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; 
                    BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: 
                    #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClick="BAYAR_Click"/><input
                        id="cmdResit" runat="server" onclick="printReport();" style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        type="button" value="PAPAR RESIT" /><input id="Button7" runat="server" onclick="cetakReport();"
                            style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
                            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
                            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
                            background-color: #f1f1f1" type="button" value="CETAK RESIT" /><input id="Button3" runat="server" onclick="showSenaraiprinter();" style="border-right: #333333 1px ridge;
                 padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                 padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                 border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                 type="button" value="PILIH PRINTER" disabled="disabled" />
        <asp:Button ID="strbuttonL" runat="server" Text="PELEPASAN" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; 
                    BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: 
                    #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClick="BAYAR_Click"/>
        &nbsp;
           
   
   <script language="javascript" type="text/javascript">
    refreshIkan()
   </script>   
  </form>

</body>
</html>
