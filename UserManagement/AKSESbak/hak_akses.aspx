<%@ Page Language="VB" AutoEventWireup="false" CodeFile="hak_akses.aspx.vb" Inherits="pemeriksaan_pemeriksaan_caj" %>

<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PEMERIKSAAN</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">

    function Tambah() 
 {
 
  if (document.form1.hak_akses.value=='0'){alert('Sila pilih hak akses');return false;}
  if (document.form1.hak_akses.value)
  if (document.form1.group_name.value)
  
 
 document.form1.arrayVal.value = document.form1.arrayVal.value + '`' 
 + document.form1.group_name.value + '`' 
 + document.all.hak_akses.options[document.all.hak_akses.selectedIndex].text + '~' ;
 
     else  
     
 alert('Sila isi nama group sebelum membuat tambahan')      
 refreshTableGridhakakses() 
 document.form1.group_name.disabled = true;
 
}

function Tolak()
{
document.form1.group_name.disabled = false;
var dataItem = document.form1.items;
var myString;
var strReplace;
var elementsName;
var alasan;


 if (document.form1.checkbox.length==undefined)
    {

        document.form1.arrayVal.value=" ";	 
	        
	     	refreshTableGridhakakses();
   
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
		refreshTableGridhakakses();
}
else
{
 	
 	if(document.form1.checkbox.checked)
	{
	   myString = document.form1.arrayVal.value;
       strReplace = document.form1.checkbox.value;
	   document.form1.arrayVal.value=myString.replace(strReplace,"");	   

	}
	refreshTableGridhakakses();
}
refreshTableGridhakakses();

}
}


function refreshTableGridhakakses()
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
  
 
      //Load akses declaration information   
        
          var strakses = document.all.arrayVal.value;    
          var arrakses = strakses.split("~");
          var strTunai = 0;
          var strCek = 0;

          //alert(arrakses.length);
          
    for (i=0;i<arrakses.length-1; i++)
        {
            var myString = arrakses[i]+ "~";
            var arraksesInfoDetails  = arrakses[i].split("`");            
           
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("Table1").insertRow();	
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arraksesInfoDetails[1];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arraksesInfoDetails[2];	         		       
	        	        	                  
        }//end for      
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
                </td>
                <td align="left" style="width: 619px; height: 5px" valign="top">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                    <strong>Group Name</strong></td>
                <td align="left" style="width: 619px; height: 5px" valign="top">
                    <asp:TextBox ID="group_name" runat="server" Width="131px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                    <strong>Hak Akses</strong></td>
                <td align="left" style="width: 619px; height: 5px" valign="top">
                    <asp:DropDownList ID="hak_akses" runat="server">                      
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 179px; height: 15px">
                </td>
                <td style="width: 619px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 179px; height: 15px">
                </td>
                <td style="width: 619px; height: 15px">
                    <input id="Button1" runat="server" style="border-right: #333333 1px ridge; padding-right: 1px;
                        border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                        border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                        font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
                        value="Tambah" onClick="Tambah();" /><input id="Button5" runat="server" style="border-right: #333333 1px ridge;
                            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                            type="button" value="Batal" onClick="Tolak();" /><asp:Button ID="reset" runat="server"
                                CausesValidation="False" Style="border-right: #333333 1px ridge; padding-right: 1px;
                                border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                                border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                                font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Reset" /></td>
            </tr>
        </table>
        &nbsp; &nbsp;&nbsp;
        <br />
        <table style="width: 700px" id="Table1">
            <tr style="background:#000000">
                <td style="width: 26px; height: 14px">
                </td>
                <td style="width: 70px; height: 14px">
                    <font color="white"><b>Group Name</b></font></td>
                <td style="width: 300px; height: 14px">
                    <font color="white"><b>Hak Akses</b></font></td>
            </tr>
        </table>
        <br />
        <div align="left"  ><hr style="width: 700px" /></div>
                    <asp:Button ID="cmdBayar" runat="server" OnClick="BAYAR_Click" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="Simpan" /><input id="Button2" onclick="window.close();" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Baru" />&nbsp;<br />
        &nbsp;
        <br />
        <asp:HiddenField ID="arrayVal" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        &nbsp;&nbsp;<br />
        &nbsp;
    </form>

<script language="javascript" type="text/javascript">
    refreshTableGridhakakses() 
</script>   

</body>
</html>
