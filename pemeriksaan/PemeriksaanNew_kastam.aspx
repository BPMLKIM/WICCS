<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PemeriksaanNew_kastam.aspx.vb" Inherits="pemeriksaan_PemeriksaanNew" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PEMERIKSAAN</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">

function Tambah()
{
var dataItem = document.form1.items;
var myString;
var strReplace;
var elementsName;
var alasan;

if (document.form1.DropDownList1.value ==''){alert('Sila pilih status pemeriksaan');return false;}
if (document.form1.DropDownList1.value =='0')
{
    if (document.form1.DropDownList2.value =='')
        {
            alert('Sila pilih status tindakan');return false;
        }
        
     if (document.form1.Text1.value =='')
        {
            alert('Sila masukkan alasan untuk tindakan di atas.');return false;
        }
               
}


 if (document.form1.checkbox.length==undefined)
    {
		   
		    var strBorang = document.all.arrayVal.value;
            var strBorang1 = strBorang.split("~");  
            var i               
       
	        var newRow = document.all("tblGridImporter").insertRow();
	        var oCell = newRow.insertCell();
	        var myString = strBorang1[0]+ "~";
		    var dataItem1 = document.all.DropDownList1;
		    var dataItem2 = document.all.DropDownList2;
		    var strBorangDetail  = strBorang1[0].split("`");

	        var newRow = document.all("Table1").insertRow();	
	        var oCell = newRow.insertCell();
       		elementsName="checkbox" + String(i);
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strBorangDetail[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = dataItem1.options[dataItem1.selectedIndex].text;	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = dataItem2.options[dataItem2.selectedIndex].text;	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = document.form1.Text1.value;

       	   	document.form1.arrayValT.value=strBorangDetail[0]+ '`' +dataItem1.options[dataItem1.selectedIndex].value + '`' + dataItem1.options[dataItem1.selectedIndex].text + '`' + dataItem2.options[dataItem2.selectedIndex].text + '`' + document.form1.Text1.value;
       
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
		
		var dataItem1 = document.all.DropDownList1;
		var dataItem2 = document.all.DropDownList2;
		
		if(document.form1.checkbox(i).checked)
		{
	   	strReplace = document.form1.checkbox(i).value;
	   	var strSkpi = strReplace.split("`");   
	   	//alert(strReplace);
	   	document.form1.arrayVal.value=myString.replace(strReplace,"");	   	
	   	
	   	var tmpArrayValT = document.form1.arrayValT.value;
	   	tmpArrayValT = strSkpi[0] + '`' + dataItem1.options[dataItem1.selectedIndex].value + '`' + dataItem1.options[dataItem1.selectedIndex].text + '`' + dataItem2.options[dataItem2.selectedIndex].text + '`' + document.form1.Text1.value + '~' + tmpArrayValT;
	   	document.form1.arrayValT.value = tmpArrayValT;
	   
	//    alert(document.form1.arrayValT.value)
		}
		
	}//end for
		refreshTableGridImporter();
		refreshTableGridImporter1();

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
       
	       var newRow = document.all("Table1").insertRow();
	       var oCell = newRow.insertCell();
	       var myString = strBorang1[0]+ "~";
		   var strBorangDetail  = strBorang1[0].split("`");

	        var newRow = document.all("tblGridImporter").insertRow();	
	        var oCell = newRow.insertCell();
       		elementsName="checkbox" + String(0);
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = strBorangDetail[0];
       	   	document.form1.arrayVal.value=document.form1.arrayValT.value;       
	        document.form1.arrayValT.value=" ";	        
	     	refreshTableGridImporter1();
   
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
	   	var strTmpStr = strSKPI[0] + '`````~';
	   	document.form1.arrayVal.value=document.form1.arrayVal.value+strTmpStr;
	//	alert(document.form1.arrayVal.value)
   
		}
		
	}//end for
		refreshTableGridImporter();
		refreshTableGridImporter1();
	
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


function refreshTableGridImporter()
{
    
    var totalRows;
    
    if (document.all("tblGridImporter").rows.length==undefined)
    {
        totalRows=-1;
    }
    else
    {
        totalRows=document.all("tblGridImporter").rows.length;
    }
       
      //clear tables rows for current importer fish declaration    
    var i=0;
    for(i=1;i<totalRows;i++)
    {
        document.all("tblGridImporter").deleteRow(1);
    }        
    
     //Load Importer declaration information   
        
          var strImporter = document.all.arrayVal.value;    
          var arrImporter = strImporter.split("~");
//alert(strImporter);
          
    for (i=0;i<arrImporter.length-1; i++)
        {
            var myString = arrImporter[i]+ "~";
            var arrImporterInfoDetails  = arrImporter[i].split("`");            
            var arrImporterDetails = arrImporterInfoDetails[i];
            
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("tblGridImporter").insertRow();	
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        //end of new row inserted	   
  
           
          
        }//end for
  
  
}      


function refreshTableGridImporter1()
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
        
          var strImporter = document.all.arrayValT.value;    
          var arrImporter = strImporter.split("~");
       
          
    for (i=0;i<arrImporter.length-1; i++)
        {
            var myString = arrImporter[i]+ "~";
            var arrImporterInfoDetails  = arrImporter[i].split("`");            
            var arrImporterDetails = arrImporterInfoDetails[i];
            
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("Table1").insertRow();	
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[2];	
	        oCell = newRow.insertCell();
            oCell.innerHTML = arrImporterInfoDetails[3];	
            oCell = newRow.insertCell();
            oCell.innerHTML = arrImporterInfoDetails[4];
 
	        //end of new row inserted     
	    
        }//end for        
}                 
</script>

<body id="body1">
    <form id="form1" runat="server">
    <div><br /><br />
        <table style="width: 100%">
            <tr>
                <td  style="background:#6600ff; height: 15px;" colspan="4">
                    <strong>&nbsp;<asp:Label ID="tittle" runat="server" ForeColor="White"></asp:Label><font color="White"> KASTAM</font><span style="color: #ffffff"></span></strong></td>
            </tr>
            <tr>
                <td style="width: 176px">
                </td>
                <td style="width: 206px">
                </td>
                <td style="width: 86px">
                </td>
                <td style="width: 308px">
                </td>
            </tr>
            <tr>
                <td style="width: 176px">
                    <strong>&nbsp;No Barcode Kastam</strong></td>
                <td style="width: 206px">
                    <asp:TextBox ID="Barcode" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
                <td style="width: 86px">
                    <strong>&nbsp;Jenis Urusan</strong></td>
                <td style="width: 308px">
                    <asp:TextBox ID="jenis_urusan" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 176px; height: 23px">
                    &nbsp;<strong>No. Kenderaan</strong></td>
                <td style="width: 206px; height: 23px">
                    <asp:TextBox ID="noKenderaan" runat="server" ReadOnly="True" Width="93px"></asp:TextBox></td>
                <td style="width: 86px; height: 23px">
                </td>
                <td style="width: 308px; height: 23px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 17px">
                    <hr />
                </td>
            </tr>
        </table>
    
    </div>
        <table style="width: 100%" runat="server">
            <tr>
                <td style="width: 163px; height: 21px">
                    <b>Status Pemeriksaan</b></td>
                <td style="width: 580px; height: 21px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
	           <asp:ListItem Value="" selected=true></asp:ListItem>
                        <asp:ListItem Value="1">Sah</asp:ListItem>
                        <asp:ListItem Value="0">Tidak Sah</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr id="a1" runat="server" style="display: none">
                <td style="width: 163px; height: 24px">
                    <strong>Tindakan</strong></td>
                <td style="width: 580px; height: 24px">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="Mahkamah">Mahkamah</asp:ListItem>
                        <asp:ListItem Value="Isytihar Semula">Isytihar Semula</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr id="a2" runat="server" style="Display : none">
                <td style="width: 163px; height: 56px">
                    <b>Alasan</b></td>
                <td style="width: 580px; height: 56px">
                    <input id="Text1" style="width: 248px; height: 64px" type="text" /></td>
            </tr>
        </table>
        <asp:HiddenField ID="urusan" runat="server" /><asp:HiddenField ID="arrayVal" runat="server" />
        &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Senarai SKPI untuk status Sah ( Pemeriksaan Rambang ) dan Sah ( Pemeriksaan 100%) "
            Width="680px" Font-Underline="True"></asp:Label><br />
        <br />
        <table id="tblGridImporter" runat="server" border="0">
            <tr style="background:#6600ff;">
                <td style="width: 127px; height: 21px;">
                    </td>
                <td style="width: 295px; height: 21px;">
                    <b>&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="White"></asp:Label></b></td>
                <td style="width: 669px; height: 21px;">&nbsp;</td>
            </tr>
        </table>
        <input id="Button3" onclick="Tambah();" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Tambah" /><br />
        <br />
        <asp:HiddenField ID="arrayValT" runat="server" />
        &nbsp;
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Senarai SKPI untuk status pemeriksaan Tidak Sah"
            Width="472px" Font-Underline="True"></asp:Label><br />
        <br />
        
       <table id="Table1" runat="server" border="0">
            <tr style="background:#6600ff">
                <td style="width: 324px; height: 21px;">
                </td>
                <td style="width: 1071px; height: 21px;">
                    <b>&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="White"></asp:Label></b></td>
                <td style="width: 802px; height: 21px">
                    &nbsp;<font color="white"><b>Status</b></font></td>
                <td style="width: 761px; height: 21px">
                    &nbsp;<font color="white"><b>Tindakan</b></font></td>
                <td style="width: 669px; height: 21px">
                    &nbsp;<font color="white"><b>Alasan</b></font></td>
            </tr>
        </table>
        <input id="Button2" type="button" onclick="Tolak();" value="   Batal   " runat="server"  style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"/>
        <br />
        <br />
        <br />
        <input id="Button4" type="button" value="BARU"  style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" runat="server" /><asp:Button ID="Simpan" runat="server" Text="SIMPAN" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClick="SIMPAN_Click"/>
        <input id="Button6" type="button" value="KELUAR" runat="server"  style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"/><br />        
        
    </form>
    
    
   <script language="javascript" type="text/javascript">
    refreshTableGridImporter()
    refreshTableGridImporter1()
</script>   
</body>
</html>
