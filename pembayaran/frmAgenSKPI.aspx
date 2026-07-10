<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAgenSKPI.aspx.vb" Inherits="pembayaran_frmAgenSKPI" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PEMERIKSAAN</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="windowfiles/dhtmlwindow.css" type="text/css" />

    <!-- #include file="library/validation.htm" -->

</head>

<script type="text/javascript" src="windowfiles/dhtmlwindow.js">

/***********************************************
* DHTML Window Widget- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for legal use.
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/

</script>

 <script language="javascript" type="text/javascript" src="popcalendar.js"></script>
 
 <script language="javascript" type="text/javascript">

// Check All for checkbox

function checkAll(checkbox, exby) {
  for (i = 0; i < checkbox.length; i++)
  checkbox[i].checked = exby.checked? true:false
}


// show senarai agen
function showSenaraiAgen()
{
agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "http://localhost/w-iccs/pembayaran/senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
}

// end coded


function printReport()
{
var winTitle = "SALINAN LKIM-BUKIT KAYU HITAM";
var str ="<%=filetransfer%>?print_status=" + document.all.print_status.value + "&kod_agen=" + document.all.kod_agen.value + "&arrayValT=" + document.all.listbarcode.value + "&SalinanMs="+ escape(winTitle);
window.open(str,'LKIM','');

}

function cetakReport()
{
if (document.all.printer_name.value == '')
{alert('Sila Pilih Printer');}
else
{
var str ="<%=filetransfer%>?printer_name=" + document.all.printer_name.value + "&print_status=Y&kod_agen=" + document.all.kod_agen.value + "&arrayValT=" + document.all.listbarcode.value;
//var str ="http://quest2003/reportw-iccs/pembayaran/<%=filetransfer%>?printer_name=" + document.all.printer_name.value + "&print_status=" + document.all.print_status.value + "&kod_agen=" + document.all.kod_agen.value + "&arrayValT=" + document.all.listbarcode.value;
window.open(str,'LKIM','');
}

}


// show senarai printer
function showSenaraiprinter()
{
  window.open('senarai-printer.aspx','test','width=310,height=420,status=yes');  
}

// end coded


function display()
{
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK') 
    {document.all.no_cek.style.display='block';document.all.id_tunai.style.display='none';document.all.id_cek.style.display='none';} 
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='TUNAI')
    {document.all.no_cek.style.display='none';document.form1.txtCek.value='';document.form1.itemTunai.value='';document.form1.itemCek.value='';document.all.id_tunai.style.display='none';document.all.id_cek.style.display='none';}
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK / TUNAI')
   {document.all.no_cek.style.display='block';document.all.id_tunai.style.display='block';document.all.id_cek.style.display='block';} 
    
}


function Tambah()
{
var dataItem = document.form1.items;
var myString;
var strReplace;
var elementsName;
var alasan;
var strIkan = document.all.arrayVal.value;
var strIkan1 = strIkan.split("~");                 
       
var newRow = document.all("Table1").insertRow();
var oCell = newRow.insertCell();
var myString = strIkan1[i]+ "~";
var dataItem1 = document.all.cara_pembayaran;
var dataItem2 = document.all.txtCek;
var dataItem3 = document.all.itemTunai;
var dataItem4 = document.all.itemCek;
	   
var strIkanDetail  = strIkan1[i].split("`");


if (document.form1.cara_pembayaran.value =='0'){alert('Sila pilih cara pembayaran');return false;}
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK / TUNAI')
{if ((document.form1.txtCek.value =='') || (document.form1.itemTunai.value =='')|| (document.form1.itemCek.value =='')){alert('Sila masukkan jumlah Tunai, Cek dan nombor Cek.');return false;}}

// validation untuk cara pembayaran CEK / TUNAI 
     var j=0;
     for (i=0;i<document.form1.checkbox.length;i++)
	     {
	       if(document.form1.checkbox(i).checked)
	           { 
	              j = j+1;
	              if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK / TUNAI')
                  { 
                  
                  if (j>1){alert('Cara untuk pembayaran secara CEK dan TUNAI hanya sah untuk satu barcode sahaja.');return false;}
                   
                  if ((parseFloat(document.form1.itemTunai.value) + parseFloat(document.form1.itemCek.value))!= strIkanDetail[2])
                   {alert("Jumlah Cek dan Tunai tidak sama");return false;}  
                       
                  }
               }	
					
	     }//end for

// end coded


if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK')
{if (document.form1.txtCek.value =='') {alert('Sila masukkan nombor Cek.');return false;}}




 if (document.form1.checkbox.length==undefined)
    {
		  
	        var newRow = document.all("Table2").insertRow();	
	        var oCell = newRow.insertCell();
       		elementsName="checkbox" + String(i);
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
            oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[1];
	        oCell = newRow.insertCell();
	        if (dataItem1.options[dataItem1.selectedIndex].text=='CEK / TUNAI')
	        {oCell.innerHTML = centPlace(document.form1.itemTunai.value);}else
   	        {if (dataItem1.options[dataItem1.selectedIndex].text=='TUNAI')
	        {oCell.innerHTML = centPlace(strIkanDetail[2]);}else
	        {oCell.innerHTML = "NONE";}}	        
	        oCell = newRow.insertCell();
	        if (dataItem1.options[dataItem1.selectedIndex].text=='CEK / TUNAI')
	        {oCell.innerHTML = centPlace(document.form1.itemCek.value);}else
            {if (dataItem1.options[dataItem1.selectedIndex].text=='CEK')
	        {oCell.innerHTML = centPlace(strIkanDetail[2]);}else	        
	        {oCell.innerHTML = "NONE";}}
	        oCell = newRow.insertCell();
	        oCell.innerHTML = dataItem1.options[dataItem1.selectedIndex].text;
   	        oCell = newRow.insertCell();
   	        if (dataItem1.options[dataItem1.selectedIndex].text=='CEK / TUNAI')
	        {oCell.innerHTML = dataItem2.value;}else
            {if (dataItem1.options[dataItem1.selectedIndex].text=='CEK')
	        {oCell.innerHTML = dataItem2.value;}else	        
	        {oCell.innerHTML = "NONE";}}   	                
	        
            document.form1.arrayValT.value=dataItem1.options[dataItem1.selectedIndex].text + '`' + dataItem2.value + '`' + dataItem3.value + '`' + dataItem4.value + '`' + document.form1.arrayVal.value;
	        document.form1.arrayVal.value=" ";
	        
	        if (dataItem1.options[dataItem1.selectedIndex].text=='CEK / TUNAI')
	        {document.form1.txtTunai.value = centPlace(document.form1.itemTunai.value);}
	        
   	        if (dataItem1.options[dataItem1.selectedIndex].text=='TUNAI')
	        {document.form1.txtTunai.value = centPlace(strIkanDetail[2]);}
	        
	        if (dataItem1.options[dataItem1.selectedIndex].text=='CEK / TUNAI')
	        {document.form1.txtKredit.value = centPlace(document.form1.itemCek.value);}
	        
            if (dataItem1.options[dataItem1.selectedIndex].text=='CEK')
	        {document.form1.txtKredit.value = centPlace(strIkanDetail[2]);}
	         
           
	     	refreshBorang();
   
 }
 
else

{


if(document.form1.checkbox.length>1)
{
	for (i=0;i<document.form1.checkbox.length;i++)
	{
		myString = document.form1.arrayVal.value;
		elementsName="checkbox" + String(i);
		
		var dataItem1 = document.all.cara_pembayaran;
		var dataItem2 = document.all.txtCek;
		var dataItem3 = document.all.itemTunai;
		var dataItem4 = document.all.itemCek;
	
		if(document.form1.checkbox(i).checked)
		{
   	   	strReplace = document.form1.checkbox(i).value;
	   	document.form1.arrayVal.value=myString.replace(strReplace,"");	   	
	   	document.form1.arrayValT.value=document.form1.arrayValT.value+dataItem1.options[dataItem1.selectedIndex].text + '`' + dataItem2.value + '`' + dataItem3.value + '`' + dataItem4.value + '`' + strReplace;
		}
		
	}//end for
		refreshBorang();
		refreshBorang1();	
}
else
{
 	
 	if(document.form1.checkbox.checked)
	{
	   myString = document.form1.arrayVal.value;
       strReplace = document.form1.checkbox.value;
	   document.form1.arrayVal.value=myString.replace(strReplace,"");	   
	} 
	
}
}
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
    
		   var strBorang = document.all.arrayValT.value;
           var strBorang1 = strBorang.split("~");                 
       
	       var newRow = document.all("Table2").insertRow();
	       var oCell = newRow.insertCell();
	       var myString = strBorang1[i]+ "~";
		   var strBorangDetail  = strBorang1[i].split("`");

	        var newRow = document.all("Table1").insertRow();	
	        var oCell = newRow.insertCell();
       		elementsName="checkbox" + String(i);
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
            oCell = newRow.insertCell();
	        oCell.innerHTML = strBorangDetail[2];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strBorangDetail[3];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strBorangDetail[4];
	        
	        var strSKPI = strBorang1[i].split("`")
	   	    var strTmpStr = strSKPI[4] + '`' + strSKPI[5] + '`' + strSKPI[6];
        
            document.form1.arrayVal.value=strTmpStr;	        
            document.form1.arrayValT.value=" ";
	        
	     	refreshBorang1();
   
 }
 
else

{


if(document.form1.checkbox.length>1)
{
	for (i=0;i<document.form1.checkbox.length;i++)
	{
		myString = document.form1.arrayValT.value;
		elementsName="checkbox" + String(i);
		
		var dataItem1 = document.all.DropDownList1;
		var dataItem2 = document.all.DropDownList2;
		
		if(document.form1.checkbox(i).checked)
		{

	   	strReplace = document.form1.checkbox(i).value;
	   	document.form1.arrayValT.value=myString.replace(strReplace,"");	   	
	   	var strSKPI = strReplace.split("`")
	   	var strTmpStr = strSKPI[4] + '`' + strSKPI[5] + '`' + strSKPI[6];
	   	document.form1.arrayVal.value=document.form1.arrayVal.value+strTmpStr;
  
		}
		
	}//end for
		refreshBorang();
		refreshBorang1();
	
}
else
{
 	if(document.form1.checkbox.checked)
	{
	   myString = document.form1.arrayValT.value;
       strReplace = document.form1.checkbox.value;
	   document.form1.arrayValT.value=myString.replace(strReplace,"");	   
	} 
	
}

}
}

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

 function refreshBorang()
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
                 
    //add a row to the rows collection and get a reference to the newly added row
            
        for (i=0;i<strIkan1.length-1; i++)
        {
           var strIkanDetail  = strIkan1[i].split("`");
	       var newRow = document.all("Table1").insertRow();
	       var oCell = newRow.insertCell();
	       var myString = strIkan1[i]+ "~";

	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
            oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[1];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = centPlace(strIkanDetail[2]);
	       
	    }    

}      
  

function refreshBorang1()
{
    
    var totalRows;
    
    if (document.all("Table2").rows.length==undefined)
    {
        totalRows=-1;
    }
    else
    {
        totalRows=document.all("Table2").rows.length;
    }
      
         //clear tables rows for current importer fish declaration    
    var i=0;
    for(i=1;i<totalRows;i++)
    {
        document.all("Table2").deleteRow(1);
    }        
  
     //Load Importer declaration information   
        
          var strImporter = document.all.arrayValT.value;
          var arrImporter = strImporter.split("~");
          var strTunai = 0;
          var strCek = 0;
         
       
    for (i=0;i<arrImporter.length-1; i++)
    
        {
            var myString = arrImporter[i]+ "~";
            var arrImporterInfoDetails  = arrImporter[i].split("`");            
            var arrImporterDetails = arrImporterInfoDetails[i];
             
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("Table2").insertRow();	
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[4];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[5];	
	        oCell = newRow.insertCell();
	        if (arrImporterInfoDetails[0]=='CEK / TUNAI')
	        {oCell.innerHTML = centPlace(arrImporterInfoDetails[2]);}else
   	        {if (arrImporterInfoDetails[0]=='TUNAI')
	        {oCell.innerHTML = centPlace(arrImporterInfoDetails[6]);}else
	        {oCell.innerHTML = "NONE";}}
	        
	        oCell = newRow.insertCell();
	        
	        if (arrImporterInfoDetails[0]=='CEK / TUNAI')
	        {oCell.innerHTML = centPlace(arrImporterInfoDetails[3]);}else
   	        {if (arrImporterInfoDetails[0]=='CEK')
	        {oCell.innerHTML = centPlace(arrImporterInfoDetails[6]);}else
	        {oCell.innerHTML = "NONE";}}
        
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        
	        oCell = newRow.insertCell();
   	        if (arrImporterInfoDetails[0]=='CEK / TUNAI')
	        {oCell.innerHTML = arrImporterInfoDetails[1];}else
            {if (arrImporterInfoDetails[0]=='CEK')
	        {oCell.innerHTML = arrImporterInfoDetails[1];}else	        
	        {oCell.innerHTML = "NONE";}}
	        
	        
	        if (arrImporterInfoDetails[0]=='CEK / TUNAI')
	        {strTunai = parseFloat(strTunai) + parseFloat(arrImporterInfoDetails[2]);}
	        
   	        if (arrImporterInfoDetails[0]=='TUNAI')
	        {strTunai = parseFloat(strTunai) + parseFloat(arrImporterInfoDetails[6]);}
	        
	        if (arrImporterInfoDetails[0]=='CEK / TUNAI')
	        {strCek = parseFloat(strCek) + parseFloat(arrImporterInfoDetails[3]);}
	        
            if (arrImporterInfoDetails[0]=='CEK')
	        {strCek = parseFloat(strCek) + parseFloat(arrImporterInfoDetails[6]);}	               

         
        }//end for
        
        document.form1.txtTunai.value = centPlace(strTunai);
        document.form1.txtKredit.value = centPlace(strCek);
        
}      



</script>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <br />
        <table style="width: 90%">
            <tr>
                <td colspan="2" style="height: 18px; background-color: #6600ff">
                    &nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White"
                        Text="Pembayaran SKPI Melalui Agen" Width="344px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 257px; height: 15px;">
                </td>
                <td style="width: 612px; height: 15px;">
                </td>
            </tr>
            <tr>
                <td style="width: 257px">
                    Tarikh</td>
                <td style="width: 612px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><img height="17"
                        onclick="javascript:popUpCalendar(this,TextBox2,'dd/mm/yyyy');return false;"
                        src="../Image/calendar.jpg" width="14" />
                </td>
            </tr>
            <tr>
                <td style="width: 257px">
                    Jenis Urusan</td>
                <td style="width: 612px">
                    <asp:DropDownList ID="urusan" runat="server">
                        <asp:ListItem Value="I">IMPORT</asp:ListItem>
                        <asp:ListItem Value="E">EKSPORT</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 257px">
                    Kod Agen Pengangkutan</td>
                <td style="width: 612px">
                    <asp:TextBox ID="kod_agen" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Open"  style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; 
                    BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: 
                    #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;"/>
                </td>
            </tr>
            <tr id="id_nameagen" runat="server" style="display: none">
                <td style="width: 257px; height: 15px;">
                    Nama Agen Pengangkutan</td>
                <td style="width: 612px; height: 15px;">
                    <asp:Label ID="name_agen" runat="server"></asp:Label></td>
            </tr>           
            
        </table>
        <asp:HiddenField ID="arrayVal" runat="server" />
        <br />
  <table id="Table1" style="width: 90% ;">
    <tr style="width: 100% ; background-color:#6600ff;">
        <td style="width: 220px; height: 13px"><input id="Checkbox" type="checkbox" onclick="checkAll(document.form1.checkbox,this)" />
        </td>
        <td style="width: 2748px; height: 13px;">
            <span style="color: #ffffff"><b>No Barcode</b></span></td>
        <td style="width: 2646px; height: 13px;">
            <span style="color: #ffffff"><strong>No Invois</strong></span></td>
        <td style="width: 2573px; height: 13px">
            <strong><span style="color: #ffffff">Caj (RM)</span></strong></td>
    </tr>
</table>
        <table style="width: 90%">
            <tr>
                <td style="width: 138px; height: 22px">
                    Cara Pembayaran</td>
                <td style="width: 710px; height: 22px">
                    <asp:DropDownList ID="cara_pembayaran" runat="server" onclick="display();">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                        <asp:ListItem Value="CEK">CEK</asp:ListItem>
                        <asp:ListItem Value="TUNAI">TUNAI</asp:ListItem>
                        <asp:ListItem Value="CEK/TUNAI">CEK / TUNAI</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="no_cek" style="display: none">
                <td style="width: 138px; height: 6px">
                    Nombor Cek</td>
                <td style="width: 710px; height: 6px">
                    <asp:TextBox ID="txtCek" runat="server"></asp:TextBox></td>
            </tr>
            <tr id="id_tunai" runat="server" style="display: none">
                <td style="width: 138px; height: 4px">
                    Jumlah Tunai ( RM )</td>
                <td style="width: 710px; height: 4px">
                    <asp:TextBox ID="itemTunai" runat="server" onChange="checkDecimal('form1','itemTunai','Caj Tunai');document.form1.itemTunai.value=centPlace(document.form1.itemTunai.value);"></asp:TextBox></td>
            </tr>
            <tr id="id_cek" runat="server" style="display: none">
                <td style="width: 138px; height: 8px">
                    Nilai Cek (RM)</td>
                <td style="width: 710px; height: 8px">
                    <asp:TextBox ID="itemCek" runat="server" onChange="checkDecimal('form1','itemCek','Caj Cek');document.form1.itemCek.value=centPlace(document.form1.itemCek.value);"></asp:TextBox></td>
            </tr>
            <tr runat="server" id="Tr1">
                <td style="width: 138px; height: 8px">
                </td>
                <td style="width: 710px; height: 8px">
                    <input id="tambah" onclick="Tambah();" style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        type="button" runat="server" value="TAMBAH" /></td>
            </tr>
        </table>
        <br />
        <asp:HiddenField ID="arrayValT" runat="server" />
        <table id="Table2" style="width: 90% ;">
            <tr style="width: 100% ; height: 13px ;background-color:#6600ff;">
                <td style="width: 220px; height: 18px">
                </td>
                <td style="width: 4220px; height: 18px">
                    <strong><span style="color: #ffffff">No Barcode</span></strong></td>
                <td style="width: 4135px; height: 18px;">
                    <span style="color: #ffffff"><strong>No Invois</strong></span></td>
                <td style="width: 5640px; height: 18px;">
                    <span style="color: #ffffff"><strong>Caj Tunai (RM)</strong></span></td>
                <td style="width: 5274px; height: 18px">
                    <strong><span style="color: #ffffff">Nilai Cek&nbsp; (RM)</span></strong></td>
                <td style="width: 3499px; height: 18px">
                    <strong><span style="color: #ffffff">Cara Pembayaran</span></strong></td>
                <td style="width: 2573px; height: 18px">
                    <strong><span style="color: #ffffff">No Cek</span></strong></td>
            </tr>
        </table>
        <br />
<asp:Button ID="cmdBayar" runat="server" Text="BAYAR" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; 
                    BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: 
                    #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClick="BAYAR_Click"/><input id="tolak" onclick="Tolak();" style="border-right: #333333 1px ridge; padding-right: 1px;
            border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
            border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
            font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
            value="TOLAK" runat="server" /><input id="cmdResit" runat="server" onclick="printReport();"
                style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
                padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
                color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
                background-color: #f1f1f1" type="button" value="PAPAR RESIT" /><input id="Button7"
                    runat="server" onclick="cetakReport();" style="border-right: #333333 1px ridge;
                    padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                    padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                    border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                    type="button" value="CETAK RESIT" /><input id="Button3" runat="server" onclick="showSenaraiprinter();"
                        style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
                        padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
                        color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
                        background-color: #f1f1f1" type="button" value="PILIH PRINTER" /><input id="Button2" style="border-right: #333333 1px ridge; padding-right: 1px;
            border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
            border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
            font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
            value="BARU" runat="server" onClick="self.location.href='frmAgenSKPI.aspx?type=borang';"/><br />
        <br />
        <table style="width: 80%">
            <tr>
                <td style="width: 263px; height: 15px">
                    Jumlah Tunai</td>
                <td style="width: 324px; height: 15px">
                    <asp:TextBox ID="txtTunai" runat="server" onChange="checkDecimal('form1','txtTunai','Jumlah Tunai');document.form1.txtTunai.value=centPlace(document.form1.txtTunai.value);"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                    Jumlah Kredit</td>
                <td style="width: 486px; height: 15px">
                    <asp:TextBox ID="txtKredit" runat="server" onChange="checkDecimal('form1','txtKredit','Jumlah Kredit');document.form1.txtKredit.value=centPlace(document.form1.txtKredit.value);"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 263px; height: 15px">
                    Status Pembayaran</td>
                <td style="width: 324px; height: 15px">
                    <asp:TextBox ID="statuspembayaran" runat="server"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                    </td>
                <td style="width: 486px; height: 15px">
                    </td>
            </tr>
        </table>
        &nbsp;
        <asp:HiddenField ID="print_status" runat="server" />
        <asp:HiddenField ID="printer_name" runat="server" />
        <asp:HiddenField ID="listbarcode" runat="server" />
    </div>
  </form>
   <script language="javascript" type="text/javascript">
    refreshBorang()
    refreshBorang1()
   </script>   
</body>
</html>