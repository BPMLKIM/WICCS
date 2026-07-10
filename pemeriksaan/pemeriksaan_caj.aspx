<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pemeriksaan_caj.aspx.vb" Inherits="pemeriksaan_pemeriksaan_caj" %>

<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PEMERIKSAAN</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">


function printReport()
{
var winTitle;

winTitle = "SALINAN LKIM-BUKIT KAYU HITAM";
var str ="<%=filetransfer%>?print_status=" + document.all.print_status.value + "&barcode="+ document.all.txtRujukan.value +"&SalinanMs="+ escape(winTitle);
//var str ="http://quest2003/reportw-iccs/pembayaran/<%=filetransfer%>?print_status=" + document.all.print_status.value + "&Urusan=" + document.all.Urusan.value + "&barcode="+ document.all.txtRujukan.value +"&SalinanMs="+ escape(winTitle);

window.open(str,'iResitG2b1','');
}

    function selection_item()
    
    {
        var a = document.form1.DropDownList1.value
        var b =  a.split(';');
        var i =0;    
        
        var dataItem4 = document.all.Exporter;
                
        for(i=0;i<b.length;i++)
            {
                document.form1.TextBox2.value = b[3]
                document.form1.TextBox1.value = b[1]
                document.form1.selectionvalue.value = b[0]       
            }                  
    }



function display()
{
if (document.form1.DropDownList2.options[document.form1.DropDownList2.selectedIndex].text=='CEK') 
    {document.all.no_cek.style.display='block';} 
if (document.form1.DropDownList2.options[document.form1.DropDownList2.selectedIndex].text=='TUNAI')
    {document.all.no_cek.style.display='none';document.form1.TextBox3.value='';}

}

function Tambah()
 
 {
       document.form1.arrayVal.value = document.form1.arrayVal.value + document.form1.selectionvalue.value 
       + '`' + document.form1.TextBox1.value + '`' + document.all.DropDownList2.options[document.all.DropDownList2.selectedIndex].text + '`' + document.form1.TextBox3.value + '`'+ document.form1.TextBox2.value + '~';
      refreshTableGridImporter()       

 }



function Tolak()
{
var dataItem = document.form1.items;
var myString;
var strReplace;
var elementsName;
var alasan;


 if (document.form1.checkbox.length==undefined)
    {

        document.form1.arrayVal.value=" ";	 
	        
	     	refreshTableGridImporter();
   
 }
 
else

{

if(document.form1.checkbox.length>1)
{
	for (i=0;i<document.form1.checkbox.length;i++)
	{
		myString = document.form1.arrayVal.value;
		elementsName="checkbox" + String(i);	
		if(document.form1.checkbox(i).checked)
		{
	   	strReplace = document.form1.checkbox(i).value;
	   	document.form1.arrayVal.value=myString.replace(strReplace,"");	   	
		}
		
	}//end for
		refreshTableGridImporter();
}
else
{
 	
 	if(document.form1.checkbox.checked)
	{
	   myString = document.form1.arrayVal.value;
       strReplace = document.form1.checkbox.value;
	   document.form1.arrayVal.value=myString.replace(strReplace,"");	   

	}
	refreshTableGridImporter();
}
refreshTableGridImporter();

}
}


function refreshTableGridImporter()
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

          //alert(arrImporter.length);
          
    for (i=0;i<arrImporter.length-1; i++)
        {
            var myString = arrImporter[i]+ "~";
            var arrImporterInfoDetails  = arrImporter[i].split("`");            
           
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("Table1").insertRow();	
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[1];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[2];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[3];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[4];	        	
	        
	        k = parseInt(arrImporterInfoDetails[1]);
	        
	        if ((arrImporterInfoDetails[2])=='CEK')
	        { strCek = strCek + parseFloat(arrImporterInfoDetails[1]); }
	        
	        if ((arrImporterInfoDetails[2])=='TUNAI')
	        { strTunai = strTunai + parseFloat(arrImporterInfoDetails[1]); }	        
	                  
        }//end for
 
       document.form1.txtTunai.value = strTunai;
       document.form1.txtKredit.value = strCek;
       
       document.form1.txtTotal.value = parseFloat(document.form1.txtTunai.value) + parseFloat(document.form1.txtKredit.value);
 
 
}      


</script>


<body>
    <form id="form1" runat="server">
 
        <br />
        <br />
        <table width="90%">
            <tr  style="height: 15px;">
                <td align="left" colspan="2" style="height: 11px" valign="top" ;>
                    <asp:Label ID="title" runat="server" Font-Bold="True"
                        Font-Underline="True"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                </td>
                <td align="left" style="width: 619px; height: 5px" valign="top">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                    &nbsp;Nombor Barcode :</td>
                <td align="left" style="width: 619px; height: 5px" valign="top">
                    &nbsp;<asp:Label ID="strBarcode" runat="server"></asp:Label>&nbsp;
                    <asp:TextBox ID="txtRujukan" runat="server" ReadOnly="True" Height="1px" Width="1px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" style="width: 230px; height: 5px" valign="top">
                    &nbsp;No./Nama Kapal/Penerbangan/Kenderaan :</td>
                <td align="left" style="width: 619px; height: 5px" valign="top">
                    <asp:Label ID="no_kenderaan" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                    &nbsp;Pembayaran Caj :</td>
                <td align="left" style="width: 619px; height: 5px" valign="top">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="Nama_Caj" DataValueField="Kod_Caj" OnClick="selection_item();">
                    </asp:DropDownList>&nbsp;
                    <asp:HiddenField ID="selectionvalue" runat="server" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                        SelectCommand="SELECT Nama_Caj + ';' + CAST(Kadar_Caj AS varchar) + ';' + Cara_Pembayaran + ';' + Dicaj_Oleh AS 'Kod_Caj', Nama_Caj FROM CAJ_PERKHIDMATAN">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 179px; height: 15px">
                    &nbsp;Nilai Caj :</td>
                <td style="width: 619px; height: 15px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 179px; height: 15px">
                    &nbsp;Cara Pembayaran :</td>
                <td style="width: 619px; height: 15px">
                    <asp:DropDownList ID="DropDownList2" runat="server" onClick="display();">
                        <asp:ListItem value="TUNAI" Selected="True">TUNAI</asp:ListItem>
                        <asp:ListItem value="CEK">CEK</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr style="Display : None;" id="no_cek">
                <td style="width: 179px; height: 15px">
                    &nbsp;No Cek :</td>
                <td style="width: 619px; height: 15px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
            <tr>
                <td style="width: 179px; height: 15px">
                    &nbsp;Dicaj Oleh :</td>
                <td style="width: 619px; height: 15px">
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 179px; height: 15px">
                </td>
                <td style="width: 619px; height: 15px">
                    <input id="Button1" runat="server" style="border-right: #333333 1px ridge; padding-right: 1px;
                        border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                        border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                        font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
                        value="TAMBAH" onClick="Tambah();" /><input id="Button5" runat="server" style="border-right: #333333 1px ridge;
                            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                            type="button" value="BATAL" onClick="Tolak();" /></td>
            </tr>
        </table>
        <br />
        &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Caj-Caj Yang Dikenakan"
            Width="184px" Font-Underline="True"></asp:Label>
        <asp:HiddenField ID="arrayVal" runat="server" /><asp:HiddenField ID="urusan" runat="server" />
        &nbsp;&nbsp;
        <br /><br />
        <table style="width: 700px" id="Table1">
            <tr style="background:#6600ff">
                <td style="width: 26px; height: 14px">
                </td>
                <td style="width: 192px; height: 14px">
                    <font color="white"><b>Item</b></font></td>
                <td style="width: 64px; height: 14px">
                    <font color="white"><b>Caj (RM)</b></font></td>
                <td style="width: 60px; height: 14px">
                    <font color="white"><b>Cara Pembayaran</b></font></td>
                <td style="width: 60px; height: 14px">
                    <font color="white"><b>No Cek</b></font></td>
                <td style="height: 14px; width: 160px;">
                    <font color="white"><b>DiCaj Oleh</b></font></td>
            </tr>
        </table>
        <br />
        <div align="left"  ><hr style="width: 700px" /></div>
        <table style="width: 80%">
            <tr>
                <td style="width: 263px; height: 15px">
                    Jumlah Tunai</td>
                <td style="width: 324px; height: 15px">
                    :
                    <asp:TextBox ID="txtTunai" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                    Jumlah Kredit</td>
                <td style="width: 486px; height: 15px">
                    :
                    <asp:TextBox ID="txtKredit" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 263px; height: 15px">
                    Jumlah Caj</td>
                <td style="width: 324px; height: 15px">
                    :
                    <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                </td>
                <td style="width: 486px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 263px; height: 15px">
                </td>
                <td style="width: 324px; height: 15px">
                </td>
                <td style="width: 486px; height: 15px">
                </td>
                <td style="width: 486px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 263px; height: 15px">
                </td>
                <td style="width: 324px; height: 15px">
                    <asp:Button ID="cmdBayar" runat="server" OnClick="BAYAR_Click" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="BAYAR" />
                    <input id="Button2" onclick="self.location.href='verifikasi_cajLain.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="BARU" />
                    <input
                        id="cmdResit" runat="server" onclick="printReport();" style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1; width: 88px;"
                        type="button" value="PAPAR RESIT" /></td>
                <td style="width: 486px; height: 15px">
                </td>
                <td style="width: 486px; height: 15px">
                </td>
            </tr>
        </table>
        <br />
        &nbsp;&nbsp;<br />
        &nbsp;
        <br />
        <asp:HiddenField ID="selectpay" runat="server" />
        <asp:HiddenField ID="Kod_Jenis_Urusan" runat="server" />
        <br />
        &nbsp;
        <asp:HiddenField ID="print_status" runat="server" />
        <asp:HiddenField ID="printer_name" runat="server" />
    </form>

<script language="javascript" type="text/javascript">
    refreshTableGridImporter() 
</script>   

</body>
</html>
