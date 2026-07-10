<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PemeriksaanNew.aspx.vb" Inherits="pemeriksaan_PemeriksaanNew" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>

<script languange="javascript">


// Add skpi for each importer in the below table


function RemoveArray()
{
var dataItem = document.form1.items;
var myString;
var strReplace;
var elementsName;

if(document.form1.checkbox.length>1)
{
	for (i=0;i<document.form1.checkbox.length;i++)
	{
		myString = document.form1.arrayVal.value;
		elementsName="checkbox" + String(i);
		if(document.form1.checkbox(i).checked)
		{
	   	//alert(document.form1.checkbox(i).value);
	   	strReplace = document.form1.checkbox(i).value;
	   	
	   	document.form1.arrayVal.value=myString.replace(strReplace,"");
	   
	   	
	   	document.form1.arrayValT.value=document.form1.arrayValT.value+strReplace;
	   	
	   	//showHint(document.form1.arrayVal.value);
		}
	}//end for
		refreshTableGridImporter();
		refreshTableGridImporter1();
	alert("arrayVal="+document.form1.arrayVal.value);
	alert("arrayValT="+document.form1.arrayValT.value);
	
	
}
else
{
 	if(document.form1.checkbox.checked)
	{
	   myString = document.form1.arrayVal.value;
	   strReplace = document.form1.checkbox.value;
	   document.form1.arrayVal.value=myString.replace(strReplace,"");	   
	  // showHint(document.form1.arrayVal.value);	  
	  //refreshTableGridImporter1() 
	} 
	
}

}

function HighLightTR(backColor,textColor){  
if(typeof(preEl)!='undefined') {
preEl.bgColor=orgBColor; 
try{ChangeTextColor(preEl,orgTColor);}catch(e){;}
} 
var el = event.srcElement;
el = el.parentElement;
orgBColor = el.bgColor;
orgTColor = el.style.color;
el.bgColor=backColor;

try{ChangeTextColor(el,textColor);}catch(e){;}
preEl = el; 
}

function ChangeTextColor(a_obj,a_color){  ;
for (i=0;i<a_obj.cells.length;i++){//put condition before increase!!!!!
a_obj.cells(i).style.color=a_color; 
document.all.currentImporter.value=a_obj.cells(i).innerHTML;
}
}



function makeEventFunc( param1, param2 )
{
return function()
{  
  HighLightTR(param1,param2); 
 // refreshTableGridImporter();
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
          //alert(arrImporter.length);
          
    for (i=0;i<arrImporter.length-1; i++)
        {
            var myString = arrImporter[i]+ "~";
            var arrImporterInfoDetails  = arrImporter[i].split("`");            
            var arrImporterDetails = arrImporterInfoDetails[i];
        //    var arrImporterData = arrImporterDetails.split("|");            
            
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("tblGridImporter").insertRow();	
	        newRow.attachEvent("onclick", makeEventFunc('#c9cc99','cc3333'));
	        //newRow.bgColor="#c9cc99";
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
    	    //oCell.innerHTML = "<img src=\"../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');removeRow(this);\" />"+ document.all.Kod_BKH.value;				    
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[1];	
	      //  oCell = newRow.insertCell();
	       // oCell.innerHTML = arrImporterInfoDetails[2];	
	       // oCell = newRow.insertCell();
	       // oCell.innerHTML = arrImporterInfoDetails[5];
	        //oCell = newRow.insertCell();
	        //oCell.innerHTML = arrImporterData[0];	    
	        //end of new row inserted	      
	    
	        //set currentImporter value
	         // document.all.currentImporter.value = arrImporterData[0];	    
	        //  
            
          
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
          alert(arrImporter.length);
          
    for (i=0;i<arrImporter.length-1; i++)
        {
            var myString = arrImporter[i]+ "~";
            var arrImporterInfoDetails  = arrImporter[i].split("`");            
            var arrImporterDetails = arrImporterInfoDetails[i];
        //    var arrImporterData = arrImporterDetails.split("|");            
            
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("Table1").insertRow();	
	        newRow.attachEvent("onclick", makeEventFunc('#c9cc99','cc3333'));
	        //newRow.bgColor="#c9cc99";
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
    	    //oCell.innerHTML = "<img src=\"../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');removeRow(this);\" />"+ document.all.Kod_BKH.value;				    
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[1];	
	      //  oCell = newRow.insertCell();
	       // oCell.innerHTML = arrImporterInfoDetails[2];	
	       // oCell = newRow.insertCell();
	       // oCell.innerHTML = arrImporterInfoDetails[5];
	        //oCell = newRow.insertCell();
	        //oCell.innerHTML = arrImporterData[0];	    
	        //end of new row inserted	      
	    
	        //set currentImporter value
	         // document.all.currentImporter.value = arrImporterData[0];	    
	        //  
            
          
        }//end for
  
  
}      




</script>

<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%">
            <tr>
                <td bgcolor="#6600ff" colspan="4" style="height: 18px">
                    <strong>&nbsp;<span style="color: #ffffff">PEMERIKSAAN IKAN</span></strong></td>
            </tr>
            <tr>
                <td style="width: 97px">
                </td>
                <td style="width: 177px">
                </td>
                <td style="width: 86px">
                </td>
                <td style="width: 308px">
                </td>
            </tr>
            <tr>
                <td style="width: 97px">
                    <strong>&nbsp;#Barcode</strong></td>
                <td style="width: 177px">
                    <asp:TextBox ID="Barcode" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
                <td style="width: 86px">
                    <strong>&nbsp;Jenis Urusan</strong></td>
                <td style="width: 308px">
                    <asp:TextBox ID="jenis_urusan" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 97px; height: 23px">
                    &nbsp;<strong>No. Kenderaan</strong></td>
                <td style="width: 177px; height: 23px">
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
                <td style="width: 594px; height: 21px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1">Sah ( Pemeriksaan Rambang )</asp:ListItem>
                        <asp:ListItem Value="1">Sah ( Pemeriksaan 100% )</asp:ListItem>
                        <asp:ListItem Value="0">Tidak Sah</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr id="a1" runat="server" style="display: none">
                <td style="width: 163px; height: 24px">
                    <strong>Tindakan</strong></td>
                <td style="width: 594px; height: 24px">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Mahkamah</asp:ListItem>
                        <asp:ListItem>Isytihar Semula</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 163px; height: 56px">
                    <b>Alasan</b></td>
                <td style="width: 594px; height: 56px">
                    <input id="Text1" style="width: 248px; height: 64px" type="text" /></td>
            </tr>
        </table>
        <asp:HiddenField ID="arrayVal" runat="server" />
        &nbsp;
        <table id="tblGridImporter" runat="server" border="0">
            <tr>
                <td style="width: 300px; height: 21px;">
                    No.</td>
                <td style="width: 408px; height: 21px;">
                    No SKPI</td>
                <td style="width: 669px; height: 21px;">
                    Pengimport</td>
            </tr>
        </table>
        <input id="Button3" onclick="RemoveArray();" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Tambah" />
        <br />
        <br />
        <asp:HiddenField ID="arrayValT" runat="server" />
        <br />
        <br />
        
       <table id="Table1" runat="server" border="0">
            <tr>
                <td style="width: 300px; height: 21px;">
                    No.</td>
                <td style="width: 408px; height: 21px;">
                    No SKPI</td>
                <td style="width: 669px; height: 21px;">
                    Pengimport</td>
            </tr>
        </table>
        <input id="Button2" onclick="RemoveArray1();" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Tambah" />
        <br />
        <br />
        <br />
        <br />        
        
    </form>
    
    
   <script language="javascript" type="text/javascript">
    //showHint(document.all.arrayVal.value,"Load_ImporterInfo.aspx");
    refreshTableGridImporter()
    refreshTableGridImporter1()
    //refreshTableGridIkan();
    //showHint2(document.all.arrayFishVal.value,"Load_ImporterFishInfo.aspx");
</script>   
</body>
</html>
