<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pembayaranNew.aspx.vb" Inherits="pembayaran_pembayaranNew" %>
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
var str ="cetakResit.aspx?Urusan=" + document.all.Urusan.value + "&barcode="+ document.all.txtRujukan.value +"&SalinanMs="+ escape(winTitle);
window.open(str,'iResitG1a','');

winTitle = "SALINAN LKIM-BUKIT KAYU HITAM";
str ="cetakResit1.aspx?Urusan=" + document.all.Urusan.value + "&barcode="+ document.all.txtRujukan.value +"&SalinanMs="+ escape(winTitle);
window.open(str,'iResitG2b','');


}

function display()
{
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='CEK') 
    {document.all.no_cek.style.display='block';} 
if (document.form1.cara_pembayaran.options[document.form1.cara_pembayaran.selectedIndex].text=='TUNAI')
    {document.all.no_cek.style.display='none';document.form1.txtCek.value='';} 
}

function Tambah()
{
var dataItem = document.form1.items;
var myString;
var strReplace;
var elementsName;
var alasan;

 if (document.form1.checkbox.length==undefined)
    {
		   var strIkan = document.all.arrayVal.value;
           var strIkan1 = strIkan.split("~");                 
       
	       var newRow = document.all("Table1").insertRow();
	       var oCell = newRow.insertCell();
	       var myString = strIkan1[i]+ "~";
		   var dataItem1 = document.all.cara_pembayaran;
		   var dataItem2 = document.all.txtCek;
		   var strIkanDetail  = strIkan1[i].split("`");

	        var newRow = document.all("Table2").insertRow();	
	        var oCell = newRow.insertCell();
       		elementsName="checkbox" + String(i);
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
 	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[2];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[3];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[4];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[5];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = dataItem1.options[dataItem1.selectedIndex].text;
   	        oCell = newRow.insertCell();
	        oCell.innerHTML = dataItem2.value;
	        
	        document.form1.arrayVal.value=" ";	 
	        
	     	refreshIkan();
   
 }
 
else

{
if(document.form1.checkbox.length>1)
{
	for (i=0;i<document.form1.checkbox.length;i++)
	{
		myString = document.form1.arrayVal.value;
		elementsName="checkbox" + String(i);
	//	document.all.DropDownList1 ="alasan" + String(i);
		
		//zue
		var dataItem1 = document.all.cara_pembayaran;
		var dataItem2 = document.all.txtCek;
		//end
		
		if(document.form1.checkbox(i).checked)
		{
	   	  //alert(document.form1.checkbox(i).value);
	   	  //alert(document.form1.Text1.value)
	   	
	   	strReplace = document.form1.checkbox(i).value;
	   	document.form1.arrayVal.value=myString.replace(strReplace,"");	   	
	   	document.form1.arrayValT.value=document.form1.arrayValT.value+dataItem1.options[dataItem1.selectedIndex].text + '`' + dataItem2.value + '`' + strReplace;
		}
		
	}//end for
		refreshIkan();
		refreshIkan1();	
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
	   	var strTmpStr = strSKPI[2] + '`' + strSKPI[3] + '`' + strSKPI[4] + '`' + strSKPI[5];
	   	document.form1.arrayVal.value=document.form1.arrayVal.value+strTmpStr;
   
		}
		
	}//end for
		refreshIkan();
		refreshIkan1();
	
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
	       
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
            oCell = newRow.insertCell();
            oCell.innerHTML = strIkanDetail[0];
            oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[1];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[2];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strIkanDetail[3];
      
	    }
	    
}      


function refreshIkan1()
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
	        oCell.innerHTML = arrImporterInfoDetails[2];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[3];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[4];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[5];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[1];
	        oCell = newRow.insertCell();
	        
   	        if (arrImporterInfoDetails[0]=='TUNAI')
	        { strTunai = parseFloat(strTunai) + parseFloat(arrImporterInfoDetails[3]);
	        }
	        
            if (arrImporterInfoDetails[0]=='CEK')
	        { strCek = parseFloat(strCek) + parseFloat(arrImporterInfoDetails[3]);
	        }

         
        }//end for
        
        document.form1.txtTunai.value = strTunai;
        document.form1.txtKredit.value = strCek;
        
}      


</script>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <br />
        <table  style="width: 90%">
            <tr>
                <td style="width: 612px; height: 18px; background-color:#6600ff; ">
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="LKIM Pembayaran Caj" Width="344px" Font-Bold="True" ForeColor="White"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 612px">
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 608px">
            <tr>
                <td colspan="2" style="height: 15px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Maklumat Pembayaran"
                        Width="176px"></asp:Label></td>
                <td colspan="1" style="height: 15px; width: 191px;">
                </td>
                <td colspan="1" style="height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 235px; height: 15px">
                </td>
                <td style="width: 481px; height: 15px">
                </td>
                <td style="width: 191px; height: 15px">
                </td>
                <td style="width: 604px; height: 15px">&nbsp;
                    </td>
            </tr>
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
        </table>
        <br />
        &nbsp;<br />
        <asp:HiddenField
            ID="arrayVal" runat="server" />
        <asp:HiddenField ID="totalikan" runat="server" />
        <table id="Table1" style="width: 90% ;">
            <tr style="width: 100% ; background-color:#6600ff;">
                <td style="width: 152px; height: 15px">
                </td>
                <td style="width: 823px; height: 15px">
                    <strong><span style="color: #ffffff">Item</span></strong></td>
                <td style="width: 823px; height: 15px">
                    <span style="color: #ffffff"><strong>Caj (RM)</strong></span></td>
                <td style="width: 803px; height: 15px">
                    <span style="color: #ffffff"><strong>DiCaj Oleh</strong></span></td>
                <td style="width: 595px; height: 15px">
                    <span style="color: #ffffff"><strong>Tempat Isytihar</strong></span></td>
            </tr>
        </table>
        <br />
        <table style="width: 90% ;" >
            <tr>
                <td style="width: 118px" >
                    Cara Pembayaran</td>
                <td >
                    <asp:DropDownList ID="cara_pembayaran" runat="server" onClick="display();">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                        <asp:ListItem Value="CEK">CEK</asp:ListItem>
                        <asp:ListItem Value="TUNAI">TUNAI</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr style="Display : None;" id="no_cek">
                <td style="width: 118px" >
                    Nombor Cek</td>
                <td >
                    <asp:TextBox ID="txtCek" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 118px; height: 15px">
                </td>
                <td style="height: 15px">
                </td>
            </tr>
            <tr >
                <td style="width: 118px; height: 15px">
                </td>
                <td style="height: 15px"><input id="tambah" onclick="Tambah();" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" runat="server" value="TAMBAH" />
                </td>
            </tr>
        </table>
    </div>
        <br />
        &nbsp;<asp:HiddenField
            ID="arrayValT" runat="server" />
        <asp:HiddenField ID="Kod_Agen" runat="server" /><asp:HiddenField ID="Urusan" runat="server" />
        <asp:HiddenField ID="selectpay" runat="server" />
        <asp:HiddenField ID="Kod_Jenis_Urusan" runat="server" />
        

        <table id="Table2" style="width: 90% ;">
            <tr style="width: 100% ; background-color:#6600ff;">
                <td style="width: 424px; height: 15px">
                </td>
                <td style="width: 908px; height: 15px">
                    <strong><span style="color: #ffffff">Item</span></strong></td>
                <td style="width: 823px; height: 15px">
                    <span style="color: #ffffff"><strong>Caj (RM)</strong></span></td>
                <td style="width: 803px; height: 15px">
                    <span style="color: #ffffff"><strong>DiCaj Oleh</strong></span></td>
                <td style="width: 595px; height: 15px">
                    <span style="color: #ffffff"><strong>Tempat Isytihar</strong></span></td>
                <td style="width: 595px; height: 15px">
                    <span style="color: #ffffff"><strong>Cara Pembayaran</strong></span></td>
                <td style="width: 595px; height: 15px">
                    <strong><span style="color: #ffffff">No Cek</span></strong></td>
            </tr>
        </table>
        <br />
   <br /><asp:Button ID="cmdBayar" runat="server" Text="BAYAR" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; 
                    BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: 
                    #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClick="BAYAR_Click"/>
                    <input id="cmdResit" runat="server" type="button" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; 
                    BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: 
                    #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" value="CETAK RESIT" OnClick="printReport();" disabled="disabled" />
        <input id="tolak" onclick="Tolak();" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" runat="server" value="TOLAK" />
        <hr id="HR1" style="width: 700px" />
        <br />
        <br />
        <table style="width: 80%">
            <tr>
                <td style="width: 263px; height: 15px">
                    Jumlah Tunai ( RM )</td>
                <td style="width: 324px; height: 15px">
                    <asp:TextBox ID="txtTunai" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                    Jumlah Kredit (RM)</td>
                <td style="width: 486px; height: 15px">
                    <asp:TextBox ID="txtKredit" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 263px; height: 15px">
                    Status Pembayaran</td>
                <td style="width: 324px; height: 15px">
                    <asp:TextBox ID="lblStatusPembayaran" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 486px; height: 15px">
                    Deposit Semasa (RM)</td>
                <td style="width: 486px; height: 15px">
                    <asp:TextBox ID="lbldepositagen" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
  
   
   
   
   <script language="javascript" type="text/javascript">
    refreshIkan()
    refreshIkan1()
   </script>   
  </form>

</body>
</html>
