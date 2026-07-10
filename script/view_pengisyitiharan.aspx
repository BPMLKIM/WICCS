<%@ Page Language="VB" AutoEventWireup="false" CodeFile="view_pengisyitiharan.aspx.vb" Inherits="Export_pengisyitiharan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>[WICCS]-Pengisytiharan Eksport</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>


<script language="javascript" type="text/javascript">
var searchKodImporter = new Array();
var KodImporter = new Array();
var NamaImporter = new Array();

var searchKodExporter = new Array();
var KodExporter = new Array();
var NamaExporter = new Array();

var KodBKHNew = new Array();
var KodIkan = new Array();
var NamaIkan = new Array();
var KodBKH = new Array();
var txtNilaiKadar = new Array();

var preEl ;
var orgBColor;
var orgTColor;


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

document.onkeyup = KeyCheck;       

function KeyCheck(e)
{
   var KeyID = (window.event) ? event.keyCode : e.keyCode;
   
   //alert(KeyID);
   if (KeyID == 17)
   {
        
        //reset details ikan value    
        document.all.Kod_BKH.value="";
        document.all.Nama_Ikan.value="";
        document.all.Kod8_Digit.value="";    
        document.all.txtPetiKecil.value=0;
        document.all.txtKuantitiKecil.value=0;
        document.all.txtPetiBesar.value=0;
        document.all.txtKuantitiBesar.value=0;
        document.all.txtNilai.value=0;
        document.all.txtNilai.value=0;
        document.all.txtJumlahNilai.value=0;   
        //
    
        //validate input
        if (document.all.currentImporter.value=="")
        {
            alert('Sila Masukkan Maklumat Pengimport & Pengeksport Terlebih Dahulu !!!');               
        }
        else
        {
            MM_openBrWindow('Senarai-Ikan.aspx','test','width=310,height=420,status=yes');   
        }
   }
   
}

function resetForms()
{
   
    location.href="pengisyitiharan.aspx?barcode="+document.all.Barcodes.value;
}

function printReport()
{
var str ="eSKPe.aspx?barcode="+document.all.Barcodes.value;
window.open(str,'eSKPI','');
//MM_openBrWindow(str,'eSKPI',''); 
var winTitle;

winTitle = "(SALINAN LKIM-BUKIT KAYU HITAM)";
str ="crMasterSheetEksport.aspx?item=1&barcode="+ document.all.Barcodes.value +"&invois_id="+document.all.Invois_Id.value+"&SalinanMs="+ escape(winTitle);
window.open(str,'LKIM','');

winTitle = "(SALINAN AGEN PENGANGKUTAN)";
str ="crMasterSheetEksport.aspx?item=2&barcode="+ document.all.Barcodes.value +"&invois_id="+document.all.Invois_Id.value+"&SalinanMs="+ escape(winTitle);
window.open(str,'AGEN','');

winTitle = "(SALINAN PERSATUAN NELAYAN NEGERI KEDAH-NEKAD)";
str ="crMasterSheetEksport.aspx?item=3&barcode="+ document.all.Barcodes.value +"&invois_id="+document.all.Invois_Id.value+"&SalinanMs="+ escape(winTitle);
window.open(str,'PERSATUAN','');



//for (i=1; i<=3; i++)
//{     
//    if (i== 1)
//    {
//       winTitle = "SALINAN LKIM-BUKIT KAYU HITAM";
//    }  
//    else if (i == 2)
//    {           
//       winTitle = "SALINAN AGEN PENGANGKUTAN";
//   }   
//    else if (i== 3)
//    {  
//       winTitle = "SALINAN PERSATUAN NELAYAN NEGERI KEDAH-NEKAD";
//    }
//    
//}

}

function makeEventFunc( param1, param2 )
{
return function()
{  
  HighLightTR(param1,param2); 
  refreshTableGridIkan();
}
}


function MM_openBrWindow(theURL,winName,features) 
{
  window.open(theURL,winName,features);
}

function dateDiff() {
date1 = new Date();
date2 = new Date();
diff  = new Date();

if (isValidDate(dateform.firstdate.value) && isValidTime(dateform.firsttime.value)) { // Validates first date 
date1temp = new Date(dateform.firstdate.value + " " + dateform.firsttime.value);
date1.setTime(date1temp.getTime());
}
else return false; // otherwise exits

if (isValidDate(dateform.seconddate.value) && isValidTime(dateform.secondtime.value)) { // Validates second date 
date2temp = new Date(dateform.seconddate.value + " " + dateform.secondtime.value);
date2.setTime(date2temp.getTime());
}
else return false; // otherwise exits

// sets difference date to difference of first date and second date

diff.setTime(Math.abs(date1.getTime() - date2.getTime()));

timediff = diff.getTime();

weeks = Math.floor(timediff / (1000 * 60 * 60 * 24 * 7));
timediff -= weeks * (1000 * 60 * 60 * 24 * 7);

days = Math.floor(timediff / (1000 * 60 * 60 * 24)); 
timediff -= days * (1000 * 60 * 60 * 24);

hours = Math.floor(timediff / (1000 * 60 * 60)); 
timediff -= hours * (1000 * 60 * 60);

mins = Math.floor(timediff / (1000 * 60)); 
timediff -= mins * (1000 * 60);

secs = Math.floor(timediff / 1000); 
timediff -= secs * 1000;

dateform.difference.value = weeks + " weeks, " + days + " days, " + hours + " hours, " + mins + " minutes, and " + secs + " seconds";

return false; // form should never submit, returns false
}

function AddArray()
{
    var date1 = new Date();
    var date2 = new Date();
    var diff  = new Date();


    var dataItem1 = document.all.Exporter.value;    
    var strTemp = dataItem1;
    var strTemp2 = strTemp.split("|");   
    
    document.all.currentImporter.value=dataItem1;
    var dataItem2 = document.all.Bekalan;
    var dataItem3 = document.all.KompleksPPI;
    var dataItem4 = document.all.Importer.value;
     
    var stat = "false";
    
    //Verifying Licence Validity Period
    
    var svrDate = document.all.serverDate.value;
    var arrSvrDate = svrDate.split("/");
        
    var licDate = strTemp2[2];
    var arrLicDate = licDate.split("/");
    licDate = arrLicDate[1]+"/"+arrLicDate[0]+"/"+arrLicDate[2];    
    var date1temp = new Date(licDate + " " + "00:00:00AM");
    date1temp.setDate(date1temp.getDate()+7);    
    
    var date2temp = new Date(svrDate + " " + "00:00:00AM");    
    if (date1temp <=date2temp>0)
    {
       alert("Lesen Pengeksport Telah Tamat Tempoh & Melebihi Hari Pelepasan Ditetapkan\n\nTarikh Tamat Lesen Pengeksport : "+strTemp2[2]);                
    }
    else
    {
    
        var strImporterInfo = document.all.arrayVal.value;
        if (strImporterInfo!="")
        {    
            //Validate Importer Already Exist Or Not    
            var arrImporterInfoRow = strImporterInfo.split('~');
            var i =0;    
            for(i=0;i<arrImporterInfoRow.length;i++)
            {
                var strImporterInfoRow = arrImporterInfoRow[i];
                var arrImporterInfoCol = strImporterInfoRow.split("`");
                if(arrImporterInfoCol[0] == dataItem1)
                {
                    stat="true";
                }        
            } 
            //End of Validate Importer Exist Or Nit.
         }           
        
        if (stat=="false")
        {
            document.all.currentImporter.value=strTemp2[0];
            document.all.arrayVal.value = document.all.arrayVal.value + dataItem1 + '`' + document.all.searchKodExporter.value + '`' + dataItem2.options.value +'`'+ dataItem3.options.value + '`' + dataItem4 + '`' + document.all.searchKodImporter.value +'~';
           //document.all.TextBox1.value = document.all.TextBox1.value + dataItem1.options.value + '`' +dataItem1.options[dataItem1.selectedIndex].text + '`' + dataItem2.options.value +'`'+ dataItem3.options.value + '`' + dataItem4.options.value + '`' +dataItem4.options[dataItem4.selectedIndex].text +'~';
                        
            var myString =dataItem1 + '`' + document.all.searchKodExporter.value + '`' + dataItem2.options.value +'`'+ dataItem3.options.value + '`' + dataItem4 + '`' + document.all.searchKodImporter.value +'~';
            
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("tblGridImporter").insertRow();	
	        newRow.attachEvent("onclick", makeEventFunc('#c9cc99','cc3333'));
	        //newRow.bgColor="#c9cc99";
	        var oCell = newRow.insertCell();	
    	    
	        var strTemp=dataItem1;
	        var arrTemp=strTemp.split("|");	    
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />"+arrTemp[0];
    	    //oCell.innerHTML = "<img src=\"../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');\" />"+ document.all.Kod_BKH.value;				    
	        oCell = newRow.insertCell();
	        oCell.innerHTML = document.all.searchKodExporter.value;
	        oCell = newRow.insertCell();
	        oCell.innerHTML =arrTemp[1];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrTemp[2];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = document.all.searchKodImporter.value;
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrTemp[0];	    
	        //end of new row inserted	        
    	    
    	    
	        //set currentImporter value
	        document.all.currentImporter.value=arrTemp[0];    
	        //
            
            //showHint(document.all.arrayVal.value,"Load_ImporterInfo.aspx");
            //showHint2(document.all.arrayFishVal.value);
            
            //reset details ikan value    
//            document.all.Kod_BKH.value="";
//            document.all.Nama_Ikan.value="";
//            document.all.Kod8_Digit.value="";    
//            document.all.txtPetiKecil.value="";
//            document.all.txtKuantitiKecil.value="";
//            document.all.txtPetiBesar.value="";
//            document.all.txtKuantitiBesar.value=0;
//            document.all.txtNilai.value=0;
//            document.all.txtJumlahNilai.value=0;    
            //end of reset
              document.all.searchKodImporter.value="";
            document.all.searchKodExporter.value="";  
        }
        else
        {
            alert('Pengeksport '+ document.all.searchKodExporter.value +' telah wujud di dalam senarai!!!');
        }
   }     
}


function RemoveArray()
{
    //var dataItem = document.all.items;
    
    var myString;
    var strReplace;
    var elementsName;
    var details;
    var z;
    var errStatus;

    try
    {   
    for (i=0;i<document.all.checkbox.length;i++)
    {
	   
	    myString = document.all.arrayVal.value;
	    elementsName="checkbox" + String(i);
	    if(document.all.checkbox(i).checked)
	    {
   	        
   	        strReplace = document.all.checkbox(i).value;
   	        details = strReplace.split("`");
   	        var strKodImporter = details[0];	   	        
   	        var kodImporter = strKodImporter.split("|");    	   	        
   	        var TmpIkan = document.all.arrayFishVal.value;
   	        var arrIkan = TmpIkan.split("~");    
   	        
   	        for(z=0; z<arrIkan.length;z++)
   	        {
   	            var str = arrIkan[z].split("`");
   	            //alert(str[0]+"="+kodImporter[0]);
   	            if (str[0]==kodImporter[0])
   	            {
   	                var strReplaceIkan = arrIkan[z] + "~"; 	                
   	                //alert(strReplaceIkan);
   	                TmpIkan = TmpIkan.replace(strReplaceIkan,"");
   	                document.all.arrayFishVal.value = TmpIkan.replace(strReplaceIkan,"");
   	            }
   	            else 
   	            {   
   	                if (str[0]!="")
   	                {
   	                    document.all.currentImporter.value=str[0];
   	                }
   	            }
   	        }//end for z
   	        
   	        document.all.arrayVal.value=myString.replace(strReplace,"");	   	        
   	        refreshTableGridIkan()
   	        
	    }// end if checked	   
	    
     }//end for i
     }
     catch(e)
     {
        //alert(document.all.checkbox.checked);        
     }
     finally
     {
       try
       {
            if(document.all.checkbox.checked)
            {
                 //alert(document.all.checkbox.value);             
                 myString = document.all.arrayVal.value;
                 strReplace = document.all.checkbox.value;
	   	         details = strReplace.split("`");
	   	         var strKodImporter = details[0];	   	        
	   	         var kodImporter = strKodImporter.split("|");    	   	        
   	             var TmpIkan = document.all.arrayFishVal.value;
   	             
                 if (TmpIkan!=="")
                 {
                     var arrIkan = TmpIkan.split("~");    
                     for(z=0; z<arrIkan.length;z++)
                     {
                        var str = arrIkan[z].split("`");                 
                        if (str[0]==kodImporter[0])
                        {
                            var strReplaceIkan = arrIkan[z] + "~"; 	                
                           // alert(strReplaceIkan);
                            TmpIkan = TmpIkan.replace(strReplaceIkan,"");
                            document.all.arrayFishVal.value = TmpIkan.replace(strReplaceIkan,"");
                        }
                        else 
                        {   
                            if (str[0]!="")
                            {
                                document.all.currentImporter.value=str[0];
                            }
                        }
                        
                      }//end for
   	                  
                    }//end if TmpIkan 
                           	          
                    document.all.arrayVal.value=myString.replace(strReplace,"");	   	           	         
                    refreshTableGridIkan()
	        }//end if      
//	        else
//	        {
//	            alert(document.all.arrayVal.value);
//	        }
	        refreshTableGridImporter(); 
	    }
	    catch(x)
	    {
	        alert("Sila Pilih Sekurang-kurangnya 1 Pengeksport Untuk Pengoperasian!!!!");	        
        }
        finally
	    {
	        refreshTableGridImporter(); 
	    }   
	    
	    refreshTableGridImporter();	        
	 }    
 
}

//Refresh Table Grid Information Importer
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
            var arrImporterDetails = arrImporterInfoDetails[0];
            var arrImporterData = arrImporterDetails.split("|");            
            
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("tblGridImporter").insertRow();	
	        newRow.attachEvent("onclick", makeEventFunc('#c9cc99','cc3333'));
	        //newRow.bgColor="#c9cc99";
	        var oCell = newRow.insertCell();		        
    	    
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
    	    //oCell.innerHTML = "<img src=\"../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');removeRow(this);\" />"+ document.all.Kod_BKH.value;				    
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[1];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterData[1];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterData[2];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterInfoDetails[5];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrImporterData[0];	    
	        //end of new row inserted	      
	    
	        //set currentImporter value
	        document.all.currentImporter.value = arrImporterData[0];	    
	        //  
            
          
        }//end for
   
}

function AddFishArray()
{
    var etpk=0;    
    var etpb=0;
    
    if (document.all.currentImporter.value!="")
    {
    calculateJumlah();
    var strTempDetailsIkan = document.all.arrayFishVal.value;
    var arrTempDetailsIkan = strTempDetailsIkan.split("~");
    var kodImporter = document.all.currentImporter.value;
    var i=0;
    var cnt=0;
    var nilai=0;
    var tpk=0;
    var tkk=0;
    var tpb=0;
    var tkb=0;
    var tpek=0;
    var tekor=0;
    var totalPeti=0;
    var jumlahPeti=0;
    
    
    //Count no. of item declared for the specific importer    
    var myVal1=0;
    var myVal2=0;
    var myValKK=0;
    var myValKB=0;
    var myValPek=0;
    var myValEkor=0;
    var myValNilai=0;
    
    
    for (i=0;i<arrTempDetailsIkan.length;i++)
    {
        var arrTempIkanInfo = arrTempDetailsIkan[i].split("`");
        var arrTempKodImporter = arrTempIkanInfo[0].split("|");
        
        myVal1=0;
        myVal2=0;
        
        if (isNaN(arrTempIkanInfo[5]))
        {
          myVal1=0;
        }
        else
        {
          myVal1=arrTempIkanInfo[5];
        }
        
        if (isNaN(arrTempIkanInfo[6]))
        {
          myValKK=0;
        }
        else
        {
          myValKK=arrTempIkanInfo[6];
        }
      
        if (isNaN(arrTempIkanInfo[7]))
        {
          myVal2=0;
        }
        else
        {
          myVal2=arrTempIkanInfo[7];
        }
        
        if (isNaN(arrTempIkanInfo[8]))
        {
          myValKB=0;
        }
        else
        {
          myValKB=arrTempIkanInfo[8];
        }
        
        if (isNaN(arrTempIkanInfo[9]))
        {
          myValPek=0;
        }
        else
        {
          myValPek=arrTempIkanInfo[9];
        }
        
        if (isNaN(arrTempIkanInfo[10]))
        {
          myValEkor=0;
        }
        else
        {
          myValEkor=arrTempIkanInfo[10];
        }
        
        if (isNaN(arrTempIkanInfo[11]))
        {
          myValNilai=0;
        }
        else
        {
          myValNilai=arrTempIkanInfo[11];
        }
        
        
        if (arrTempKodImporter[0]==kodImporter)
        {
            cnt = cnt + 1;
            tpk = tpk + parseFloat(myVal1);           
            tkk = tkk + parseFloat(myValKK);
            tpb = tpb + parseFloat(myVal2);
            tkb = tkb + parseFloat(myValKB);
            tpek = tpek + parseFloat(myValPek);                                             
            tekor = tekor + parseFloat(myValEkor);
            nilai = nilai + parseFloat(myValNilai);                        
        }      
        
        
        
        
        etpk = etpk + parseFloat(myVal1);                
        etpb = etpb + parseFloat(myVal2);    
        
    }
               
    
    //
    if (document.all.txtPetiKecil.value=="")
    {
        myVal1=0;
    }
    else
    {
        myVal1=document.all.txtPetiKecil.value;
    }
    
    if (document.all.txtKuantitiKecil.value=="")
    {
        myValKK=0;
    }
    else
    {
        myValKK=document.all.txtKuantitiKecil.value;
    }
      
    if (document.all.txtPetiBesar.value=="")
    {
        myVal2=0;
    }
    else
    {
        myVal2=document.all.txtPetiBesar.value;
    }
    
    if (document.all.txtKuantitiBesar.value=="")
    {
        myValKB=0;
    }
    else
    {
        myValKB=document.all.txtKuantitiBesar.value;
    }    
    
    if (document.all.txtPek.value=="")
    {
        myValPek=0;
    }
    else
    {
        myValPek=document.all.txtPek.value;
    }    
    
    if (document.all.txtEkor.value=="")
    {
        myValEkor=0;
    }
    else
    {
        myValEkor=document.all.txtEkor.value;
    }    
    
    if (document.all.txtJumlahNilai.value=="")
    {
        myValNilai=0;
    }
    else
    {
        myValNilai=document.all.txtJumlahNilai.value;
    }   
    
    //alert(myValPek);
    
    tpk = tpk + parseFloat(myVal1);           
    tkk = tkk + parseFloat(myValKK);
    tpb = tpb + parseFloat(myVal2);
    tkb = tkb + parseFloat(myValKB);
    tpek = tpek + parseFloat(myValPek);                                             
    tekor = tekor + parseFloat(myValEkor);
    nilai = nilai + parseFloat(myValNilai);
    
     
            
    etpk = etpk + parseFloat(myVal1);   
    etpb = etpb + parseFloat(myVal2);
        
    //Checking whether existing items already reach maximum limit    
    if (cnt==8)
    {
        alert('Hanya 8 item sahaja yg boleh diisytiharkan dalam satu e-SKPI');
    }
    else
    {    
        
        if (myValNilai==0)
        {
            alert("Maklumat data ikan tidak lengkap!!! \n Nilai mestilah melebihi RM 0.00!!!!");           
        }
        else
        {
            document.getElementById("Label1").innerHTML=tpk;
            document.getElementById("Label2").innerHTML=tkk;
            document.getElementById("Label3").innerHTML=tpb;
            document.getElementById("Label4").innerHTML=tkb;
            document.getElementById("Label5").innerHTML=tpek;
            document.getElementById("Label6").innerHTML=tekor;
            document.getElementById("Label7").innerHTML=nilai;
            document.getElementById("Label8").innerHTML= etpk + etpb ;
                
            var strTemp = document.all.Destination.options.value;
            var strTemp2 = strTemp.split("|");  
            var arrVal = document.all.currentImporter.value + '`' + document.all.Kod_BKH.value + '`' + document.all.Nama_Ikan.value + '`' + document.all.Kod8_Digit.value + '`' + strTemp2[0] + '`' + myVal1 + '`' + myValKK + '`' + myVal2 + '`' + myValKB + '`' + myValPek + '`' + myValEkor + '`' + myValNilai + '`' + strTemp2[1] +'~';
            document.all.arrayFishVal.value = document.all.arrayFishVal.value + arrVal;
            addRow(arrVal);
            //showHint2(document.all.arrayFishVal.value);    
        }
    }
    //reset details ikan value    
    document.all.txtPetiKecil.value="";
    document.all.txtKuantitiKecil.value="";
    document.all.txtPetiBesar.value="";
    document.all.txtKuantitiBesar.value="";
    document.all.txtEkor.value="";
    document.all.txtNilai.value="";    
    document.all.txtJumlahNilai.value="";
    document.all.Kod_BKH.value="";
    document.all.Nama_Ikan.value="";
    document.all.Kod8_Digit.value="";
    document.all.txtNilai.value="";
    document.all.txtPek.value="";
    }
    else
    {
        alert("Sila Pilih atau Masukkan Pengimport Terlebih Dahulu!!!!");
    }
    
}



function RemoveFishArray(strReplace)
{
    var myString;
    var strReplace1 = strReplace;
    strReplace = strReplace1.replace("~","")+"~";
    if (strReplace!="")
    {
        myString = document.all.arrayFishVal.value;
        document.all.arrayFishVal.value=myString.replace(strReplace,"");
        refreshTableGridIkan();
    }
}


//Refresh Table Grid Information Ikan
function refreshTableGridIkan()
{
    
    var totalRows;
    var etpk = 0;           
    var etpb = 0;
    
    if (document.all("tblGrid").rows.length==undefined)
    {
        totalRows=-1;
    }
    else
    {
        totalRows=document.all("tblGrid").rows.length;
    }
    
     
    
    
    //clear tables rows for current importer fish declaration    
    var i=0;
    for(i=2;i<totalRows;i++)
    {
        document.all("tblGrid").deleteRow(2);
    }        
    
    //Load fish declaration information for currentImporter
    var currImporter = document.all.currentImporter.value;        
    var strIkanInfo = document.all.arrayFishVal.value;
    var arrIkanInfo = strIkanInfo.split("~");
    var nilai=0;
    var tpk=0;
    var tkk=0;
    var tpb=0;
    var tkb=0;
    var tpek=0;
    var tekor=0;
    var totalPeti=0;
    
    var myVal1=0;
    var myVal2=0;
    var myValKK=0;
    var myValKB=0;
    var myValPek=0;
    var myValEkor=0;
    var myValNilai=0;
        
    if (currImporter!="")
    {
        
        for (i=0;i<arrIkanInfo.length; i++)
        {
            var arrIkanInfoDetails  = arrIkanInfo[i].split("`");
            //alert(currImporter+"=="+arrIkanInfoDetails[0]);
            if (isNaN(arrIkanInfoDetails[5]))
            {
              myVal1=0;
            }
            else
            {
              myVal1=arrIkanInfoDetails[5];
            }
            
            if (isNaN(arrIkanInfoDetails[6]))
            {
              myValKK=0;
            }
            else
            {
              myValKK=arrIkanInfoDetails[6];
            }
          
            if (isNaN(arrIkanInfoDetails[7]))
            {
              myVal2=0;
            }
            else
            {
              myVal2=arrIkanInfoDetails[7];
            }
            
            if (isNaN(arrIkanInfoDetails[8]))
            {
              myValKB=0;
            }
            else
            {
              myValKB=arrIkanInfoDetails[8];
            }
            
            if (isNaN(arrIkanInfoDetails[9]))
            {
              myValPek=0;
            }
            else
            {
              myValPek=arrIkanInfoDetails[9];
            }
            
            if (isNaN(arrIkanInfoDetails[10]))
            {
              myValEkor=0;
            }
            else
            {
              myValEkor=arrIkanInfoDetails[10];
            }
            
            if (isNaN(arrIkanInfoDetails[11]))
            {
              myValNilai=0;
            }
            else
            {
              myValNilai=arrIkanInfoDetails[11];
            }
                
            if (currImporter==arrIkanInfoDetails[0])
            {         	
       	        //add a row to the rows collection and get a reference to the newly added row
                var newRow = document.all("tblGrid").insertRow();	
                var oCell = newRow.insertCell();
                oCell.innerHTML = "<img src=\"../images/del..gif\"  onclick=\"+RemoveFishArray('"+arrIkanInfo[i]+"');\" />"+ arrIkanInfoDetails[1];			
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[2];	
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[3];
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[12];
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[5];
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[6];
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[7];
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[8];
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[9];
                oCell = newRow.insertCell();
                oCell.innerHTML = arrIkanInfoDetails[10];
                oCell = newRow.insertCell();    
                oCell.innerHTML = arrIkanInfoDetails[11];
	            
                  
                //cnt = cnt + 1;
                tpk = tpk + parseFloat(myVal1);           
                tkk = tkk + parseFloat(myValKK);
                tpb = tpb + parseFloat(myVal2);
                tkb = tkb + parseFloat(myValKB);
                tpek = tpek + parseFloat(myValPek);                                             
                tekor = tekor + parseFloat(myValEkor);
                nilai = nilai + parseFloat(myValNilai);                                                           
                 	           
            }           
                
            
            etpk = etpk + parseFloat(myVal1);                
            etpb = etpb + parseFloat(myVal2);
            
           // alert(arrIkanInfoDetails[5]);
            
            
        }//end for
        document.getElementById("Label1").innerHTML=tpk;
        document.getElementById("Label2").innerHTML=tkk;
        document.getElementById("Label3").innerHTML=tpb;
        document.getElementById("Label4").innerHTML=tkb;
        document.getElementById("Label5").innerHTML=tpek;
        document.getElementById("Label6").innerHTML=tekor;
        document.getElementById("Label7").innerHTML=nilai;
        if (isNaN(etpk)) 
        {
            etpk=0;
        }    
        
        if (isNaN(etpb)) 
        {
            etpk=0;
        }    
        
                
        document.getElementById("Label8").innerHTML= etpk + etpb ; 
    }
}

//add a new row to the table
function addRow(myString)
{
	
	//add a row to the rows collection and get a reference to the newly added row
	var newRow = document.all("tblGrid").insertRow();	
	var oCell = newRow.insertCell();	
	 //oCell.innerHTML = "<input name=\"checkboxIkan\" type=\"checkbox\" value=\""+ myString +"\" onClick=\"+RemoveFishArray('"+myString+"');removeRow(src);\" />"
	
	oCell.innerHTML = "<img src=\"../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');\" />"+ document.all.Kod_BKH.value;			
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.Nama_Ikan.value;	
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.Kod8_Digit.value;
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.Destination.options[document.all.Destination.selectedIndex].text;
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.txtPetiKecil.value;
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.txtKuantitiKecil.value;
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.txtPetiBesar.value;
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.txtKuantitiBesar.value;
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.txtPek.value;
	oCell = newRow.insertCell();
	oCell.innerHTML = document.all.txtEkor.value;
	oCell = newRow.insertCell();    
	oCell.innerHTML = document.all.txtJumlahNilai.value;
	//AddFishArray();
	
	
	
}

//deletes the specified row from the table
function removeRow(src)
{
	/* src refers to the input button that was clicked.	
	   to get a reference to the containing <tr> element,
	   get the parent of the parent (in this case case <tr>)
	*/			
	var oRow = src.parentElement.parentElement;		
	
	//once the row reference is obtained, delete it passing in its rowIndex			
	document.all("tblGrid").deleteRow(oRow.rowIndex);		
}

function showHint(str,urls)
{

//alert(str);
//if (str.length==0)
//{ 
//document.getElementById("txtHint").innerHTML=""
//return
//}

xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");

//xmlHttp=GetXmlHttpObject();
if (xmlHttp==null)
{
alert ("Browser does not support HTTP Request");
return;
} 

//var url="Load_ImporterInfo.aspx";
var url=urls;
url=url+"?dataVal="+escape(str);
url=url+"&iCode="+escape(document.all.currentImporter.value);
url=url+"&sid="+Math.random();

xmlHttp.onreadystatechange=stateChanged;

xmlHttp.open("GET",url,true);
xmlHttp.send(null);
}

function stateChanged()
{ 
if (xmlHttp.readyState==4 || xmlHttp.readyState=="complete")
{ 
//alert(xmlHttp.responseText );

        document.getElementById("txtHint").innerHTML=xmlHttp.responseText;
 } 
}

function GetXmlHttpObject()
{ 
var objXMLHttp=null;
if (window.XMLHttpRequest)
{
objXMLHttp=new XMLHttpRequest();
}
else if (window.ActiveXObject)
{
objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
}
return objXMLHttp;
} 


function calculateJumlah()
{
  var myTxtNilai=document.all.txtNilai.value;
  var myTxtKuantitiKecil = document.all.txtKuantitiKecil.value;
  var myTxtKuantitiBesar = document.all.txtKuantitiBesar.value;
  if (myTxtNilai=="")
  {
    myTxtNilai=0;
  }
  
  if (myTxtKuantitiKecil=="")
  {
    myTxtKuantitiKecil=0;
  }
  
  if (myTxtKuantitiBesar=="")
  {
    myTxtKuantitiBesar=0;
  }
 
 
  if (parseFloat(myTxtNilai)>0)
  {
   //if(document.all.txtKuantitiKecil.value!="" && document.all.txtKuantitiBesar.value!="")
   //{
       document.all.txtJumlahNilai.value = (parseFloat(myTxtKuantitiKecil) + parseFloat(myTxtKuantitiBesar)) * parseFloat(myTxtNilai); 
      
   //} 
  }
}


function calculateTxtQtyKecil()
{
    var txtKecil = document.all.txtPetiKecil.value;
    if (txtKecil=="")
    {
        txtKecil=0;
    }
        
    var kodUrusan = document.all.JenisUrusan.options.value;
    var tmpCategoryIkan = document.all.Kod8_Digit.value;
    var CategoryIkan = tmpCategoryIkan.substr(0,1);
    var kodJenisIkan = document.all.JenisUrusan.value;

    if (kodUrusan == "001" && CategoryIkan == "3")
    {
        //do nothing
    }
    else if (kodUrusan == "001" && CategoryIkan == "2")
    {
        //do nothing
    }
    //' *** Transit Pulau Pinang ***
    else if (CategoryIkan == "4")
    {
        //do nothing
    }
    //        ' *** Transit Singapura ***
    else if (kodUrusan == "004" || kodUrusan == "005" || kodUrusan == "011" || kodUrusan == "012" && CategoryIkan == "1") 
    {
        //do nothing
    }
    else if (kodUrusan == "006" && CategoryIkan == "1")
    {
        //do nothing
    }
    else if (kodUrusan == "006" && CategoryIkan == "3")
    {
        //do nothing
    }
    else 
    {
     document.all.txtKuantitiKecil.value = parseInt(txtKecil) * 30;     
    }
       
}

function calculateTxtQtyBesar()
{
    var txtBesar = document.all.txtPetiBesar.value;
    if (txtBesar=="")
    {
        txtBesar=0;
    }
    var kodUrusan = document.all.JenisUrusan.options.value;
    var tmpCategoryIkan = document.all.Kod8_Digit.value;
    var CategoryIkan = tmpCategoryIkan.substr(0,1);
    var kodJenisIkan = document.all.JenisUrusan.value;

    if (kodUrusan == "001" && CategoryIkan == "3")
    {
        //do nothing
    }
    else if (kodUrusan == "001" && CategoryIkan == "2")
    {
        //do nothing
    }
    //' *** Transit Pulau Pinang ***
    else if (CategoryIkan == "4")
    {
        //do nothing
    }
    //        ' *** Transit Singapura ***
    else if (kodUrusan == "004" || kodUrusan == "005" || kodUrusan == "011" || kodUrusan == "012" && CategoryIkan == "1") 
    {
        //do nothing
    }
    else if (kodUrusan == "006" && CategoryIkan == "1")
    {
        //do nothing
    }
    else if (kodUrusan == "006" && CategoryIkan == "3")
    {
        //do nothing
    }
    else 
    {
     document.all.txtKuantitiBesar.value = parseInt(txtBesar) * 50;
    }
    calculateJumlah();
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

function showFilteredIkan()
{
   //alert("found");
          
    var searchItem =document.all.Kod_BKH.value;
    var found=0;
    //alert(KodBKH.indexOf(searchItem)); 
    if (document.all.currentImporter.value=="")
    {
        alert('Sila Masukkan Maklumat Pengimport & Pengeksport Terlebih Dahulu !!!');               
        document.all.Kod_BKH.value=""; 
        document.all.searchKodImporter.focus(); 
    }
    else
    {
       if (searchItem!="")
       {
          for (i=0;i<KodBKHNew.length;i++)
          {
           if (searchItem==KodBKHNew[i])
            {
                //alert("found");
                sendValue(KodBKH[i],NamaIkan[i],KodIkan[i],txtNilaiKadar[i]);
                found =1;
                document.all.Destination.focus();                 
            }    
          }//end next
       
          if (found==0)               
          {
             document.all.Kod_BKH.value=""; 
             document.all.Kod_BKH.focus();
             alert("Kod BKH Tidak Ditemui Sila Cari Secara Manual!!!");
             MM_openBrWindow('Senarai-Ikan.aspx','test','width=310,height=420,status=yes');                   
          }
       }
              
     }
   
}



function sendValue(param1,param2,param3,param4)
{
    
    
    //reset details ikan value    
    //document.all.txtPetiKecil.value=0;
    //document.all.txtKuantitiKecil.value=0;
    //document.all.txtPetiBesar.value=0;
    //document.all.txtKuantitiBesar.value=0;
    //document.all.txtEkor.value=0;
    //document.all.txtNilai.value=0;
    
    //document.all.txtJumlahNilai.value=0;
    
    
    //
    
    document.all.Kod_BKH.value=param1;
    document.all.Nama_Ikan.value=param2;
    document.all.Kod8_Digit.value=param3;
    document.all.txtNilai.value=param4;
    
    var categoryIkan = param3.substr(0,1);
    var kodUrusan=document.all.JenisUrusan.options.value; 
   
    //alert(categoryIkan);
    //alert(categoryIkan.substr(0,1));
    //Enable Input Texts
    switch(categoryIkan)
    {
       
        case "1" :    // *** Ikan Basah ***
            if (kodUrusan == "004" || kodUrusan == "005" || kodUrusan == "011" || kodUrusan == "012")
            {   
                // Urusan Transit PP || Transit PP Dgn Surat Kurang Caj || Transit PP Dgn Surat Pengecualian || Transit Batu Pahat  Dgn Surat Pengecualian Caj
                document.all.txtPetiKecil.disabled = false;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = false;
            }
            else if (kodUrusan == "006")
            {    // Urusan Transit Singapura
                document.all.txtPetiKecil.disabled = false;
                document.all.txtPetiBesar.disabled = false;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = false;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = false;
            }
            else
            {    // Import
                document.all.txtPetiKecil.disabled = false;
                document.all.txtPetiBesar.disabled = false;
                document.all.txtKuantitiKecil.disabled = true;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = true;
            }
            break;
            
        case "2" :    // *** Sejukbeku ***
            if (kodUrusan == "004" || kodUrusan == "005" || kodUrusan == "011" || kodUrusan == "006" || kodUrusan == "012")
            {    // Urusan Transit Pulau Pinang/Singapura/BP
                document.all.txtPetiKecil.disabled = true;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = false;
            }            
            else
            {    // Import
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtPetiKecil.disabled = false;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = true;
             }
             break;
             
        case "3" :    // *** Hidup ***
            if (kodUrusan == "004" || kodUrusan == "005" || kodUrusan == "011" || kodUrusan == "012")
            {    // Urusan Transit Pulau Pinang
                document.all.txtPetiKecil.disabled = true;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = false;
            }
            else if (kodUrusan == "006")
            {   // Urusan Transit Singapura
                document.all.txtPetiKecil.disabled = false;
                document.all.txtPetiBesar.disabled = false;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = false;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = false;
                document.all.txtNilai.disabled = false;
            }
            else
            {   // Import
                document.all.txtPetiKecil.disabled = false;
                document.all.txtPetiBesar.disabled = false;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = false;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = false;
                document.all.txtNilai.disabled = true;
             }
             break;      
        case "4" :    // *** Proses/Produk Perikanan ***
            if (kodUrusan == "004" || kodUrusan == "005" || kodUrusan == "011" || kodUrusan == "006" || kodUrusan == "012")
            {   // Urusan Transit Pulau Pinang/Singapura
                document.all.txtPetiKecil.disabled = true;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = false;
            }
            else
            {
                // Import
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtPetiKecil.disabled = false;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = false;
            }
            break;
        case "5" :    // *** Produk Perikanan Yang Lain ***
            if (kodUrusan == "004" || kodUrusan == "005" || kodUrusan == "011" || kodUrusan == "006" || kodUrusan == "012")
            {
                // Urusan Transit Pulau Pinang/Singapura
                document.all.txtPetiKecil.disabled = true;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = false;
            }
            else
            {   // Import
                document.all.txtKuantitiKecil.disabled = false;
                document.all.txtPetiKecil.disabled = true;
                document.all.txtPetiBesar.disabled = true;
                document.all.txtKuantitiBesar.disabled = true;
                document.all.txtPek.disabled = true;
                document.all.txtEkor.disabled = true;
                document.all.txtNilai.disabled = true;
            }
            break;       
    }//end switch for categoryIkan condition
   
     
}

function showFilteredImporter()
{
   //alert("found");
   
    var searchItem =document.all.searchKodImporter.value;
    var found=0;
    if (searchItem != "") 
    {   //alert(KodBKH.indexOf(searchItem)); 
//    if (document.all.searchKodImporter.value=="")
//    { 
//        alert('Sila Masukkan Maklumat Kod Importer Terlebih Dahulu !!!');               
//         document.all.searchKodImporter.focus();
//    }
//    else
//    {
       for (i=0;i<searchKodImporter.length;i++)
       {
           if (searchItem==searchKodImporter[i])
            {
               // alert("found="+i+"="+KeyKodAgen[i]);
                document.all.Importer.value = KodImporter[i];
                document.all.searchKodImporter.value = NamaImporter[i];
                found =1;                
            }    
       }//end next
       
       if (found==0)               
       {
           input_box=confirm("Kod Importer Tidak Ditemui Sila Cari Secara Manual!!! \nAdakah Anda Ingin Mencari Kod Importer Secara Manual? \nSila Tekan OK untuk \"Ya\" CANCEL untuk \"Tidak\"!! ");
           if (input_box==true)
           { 
                // Output when OK is clicked                
                window.open('Senarai-Importer.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
           }
           else
           {
                // Output when Cancel is clicked
                //alert ("You clicked cancel");
               document.all.searchKodImporter.focus();
                document.all.searchKodImporter.value="";
           }           
       }
              
  }
  
}

function showFilteredExporter()
{
   //alert("found");
          
    
    var searchItem =document.all.searchKodExporter.value;
    if (searchItem != "") 
    {
    var found=0;
    //alert(KodBKH.indexOf(searchItem)); 
//    if (document.all.searchKodExporter.value=="")
//    { 
//        alert('Sila Masukkan Maklumat Kod Agen Pengangkutan Terlebih Dahulu !!!');               
//         document.all.searchKodExporter.focus();
//    }
//    else
//    {
       for (i=0;i<searchKodExporter.length;i++)
       {
           if (searchItem==searchKodExporter[i])
            {
               // alert("found="+i+"="+KeyKodAgen[i]);
                document.all.Exporter.value = KodExporter[i];
                document.all.searchKodExporter.value = NamaExporter[i];
                found =1;
                document.all.searchKodImporter.focus();
            }    
       }//end next
       
       if (found==0)               
       {
           input_box=confirm("Kod Importer Tidak Ditemui Sila Cari Secara Manual!!! \nAdakah Anda Ingin Mencari Kod Importer Secara Manual? \nSila Tekan OK untuk \"Ya\" CANCEL untuk \"Tidak\"!! ");
           if (input_box==true)
           { 
                // Output when OK is clicked                
                window.open('Senarai-Exporter.aspx','SenaraAgen','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
           }
           else
           {
                // Output when Cancel is clicked
                //alert ("You clicked cancel");
                document.all.searchKodExporter.focus();
           }           
       }
              
  }
  
}


</script>
<%
    Dim cntArray As Integer = 0
    Dim sqlText As String = "SELECT [Nama_BKH], [Kod_Ikan], [Kod_BKH],[Harga_BKH] FROM [JENIS_IKAN]"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("KodBKHNew[" & cntArray & "]='" & jsReader.GetValue(2).ToString.Trim() & "';" & vbCrLf)
        Response.Write("KodBKH[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf)
        Response.Write("NamaIkan[" & cntArray & "]='" & jsReader.GetValue(0) & "';" & vbCrLf)
        Response.Write("KodIkan[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("txtNilaiKadar[" & cntArray & "]='" & jsReader.GetValue(3) & "';" & vbCrLf & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
    
    cntArray = 0
    'sqlText = "SELECT RTRIM(PENGIMPORT.Kod_Pengimport) as kodPengimport, RTRIM(PENGIMPORT.Kod_Pengimport) +'|'+ " & _
    '          "RTRIM(PENGIMPORT.No_Lesen) + '|'+ CAST(DAY(LESEN.Tarikh_Tamat) AS nvarchar(200)) " & _
    '          "+ '/'+ case when MONTH(LESEN.Tarikh_Tamat) < 10 then '0'+cast(month(lesen.tarikh_tamat) as varchar(1)) else cast(month(lesen.tarikh_tamat) as varchar(2)) end   " & _
    '          "+ '/' + CAST(YEAR(LESEN.Tarikh_Tamat) as nvarchar(4)) AS Val," & _
    '          "RTRIM(PENGIMPORT.Nama_Syarikat_Import) as [Nama_Syarikat_Import] " & _
    '          "FROM PENGIMPORT INNER JOIN " & _
    '          "LESEN ON PENGIMPORT.No_Lesen = LESEN.No_Lesen "
    sqlText = "SELECT RTRIM(Kod_Pengimport) as kodPengimport ,Kod_Pengimport, Nama_Pengimport AS Nama_Syarikat_Pengimport FROM PENGIMPORT_THAILAND ORDER BY LTRIM(Nama_Pengimport) ASC"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("searchKodImporter[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("KodImporter[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("NamaImporter[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
    
    cntArray = 0
    sqlText = "SELECT RTRIM(PENGEKSPORT.Kod_Pengeksport) as val, RTRIM(PENGEKSPORT.Kod_Pengeksport) + '|' + RTRIM(PENGEKSPORT.No_Lesen) + '|' + CAST(DAY(LESEN.Tarikh_Tamat) AS nvarchar(200)) + '/' + CASE WHEN MONTH(LESEN.Tarikh_Tamat) < 10 THEN '0' + CAST(month(lesen.tarikh_tamat) AS varchar(1)) ELSE CAST(month(lesen.tarikh_tamat) AS varchar(2)) END + '/' + CAST(YEAR(LESEN.Tarikh_Tamat) AS nvarchar(4)) AS Val, PENGEKSPORT.Nama_Syarikat_Eksport FROM PENGEKSPORT INNER JOIN LESEN ON PENGEKSPORT.No_Lesen = LESEN.No_Lesen " & _
              "ORDER BY LTRIM(PENGEKSPORT.Nama_Syarikat_Eksport)"
    'sqlText = "SELECT Rtrim([Kod_Pengeksport]) as val, [Kod_Pengeksport], RTRIM([Nama_Pengeksport]) as [Nama_Syarikat_Eksport] FROM [PENGEKSPORT_THAILAND]"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("searchKodExporter[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("KodExporter[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("NamaExporter[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
 %>


<body>
     <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         
          
        <table style="width: 100%">
            <tr>
                <td colspan="4" style="height: 18px; background-color:#0000cc;">
                    <strong>&nbsp;<span style="color: #ffffff">VIEW PENGISYTIHARAN EKSPORT </span></strong></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td style="width: 76px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td >
                    <strong>&nbsp;Agen Pengangkutan</strong></td>
                <td >
                    <asp:TextBox ID="NamaAgen" runat="server" Width="260px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 76px" >
                    <strong>&nbsp;#Rujukan</strong></td>
                <td >
                    <asp:TextBox ID="rujukan" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    <strong>&nbsp;No. Kenderaan</strong></td>
                <td >
                    <asp:TextBox ID="noKenderaan" runat="server" Width="93px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 76px" >
                    <strong>&nbsp;#Barcode</strong></td>
                <td >
                    <asp:TextBox ID="Barcodes" runat="server" Width="156px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr style="font-weight: bold">
                <td >
                    &nbsp;Cara Pengangkutan</td>
                <td >
                    <asp:DropDownList ID="cara_pengangkutan" runat="server" DataSourceID="JenisPengangkutan" DataTextField="Nama_Pengangkutan" DataValueField="Kod_Pengangkutan" Enabled="False">
                    </asp:DropDownList>
                </td>
                <td style="width: 76px" >
                    &nbsp;Jenis Urusan</td>
                <td >
                    <asp:DropDownList ID="JenisUrusan" runat="server" DataSourceID="Urusan" DataTextField="Nama_Urusan"
                        DataValueField="Kod_Urusan" Enabled="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 17px">
                    <hr />
                </td>
            </tr>
            
        </table>
   
    
    <table style="width: 100%">
        <tr>
            <td style="height: 21px" >
                <strong>Kompleks/PPI</strong></td>
            <td style="height: 21px" >
                &nbsp;<asp:DropDownList ID="KompleksPPI" runat="server" DataSourceID="PPI" DataTextField="Nama_PPI" DataValueField="Kod_PPI" Enabled="False">
                    </asp:DropDownList></td>
            <td style="height: 21px" >
                <strong>Destinasi Negara</strong></td>
            <td style="height: 21px">
                <strong>
                <asp:DropDownList ID="Bekalan" runat="server" DataSourceID="SumberBekalan" DataTextField="Nama_Negara" DataValueField="Kod_Negara" Enabled="False">
              </asp:DropDownList></strong></td>
        </tr>
        <tr>
            <td style="height: 21px" >
                <strong>Pengeksport</strong></td>
            <td style="height: 21px" >
                <asp:TextBox ID="searchKodExporter" runat="server" Width="266px" ReadOnly="True"></asp:TextBox><asp:HiddenField
                    ID="Exporter" runat="server" />
            </td>
            <td style="height: 21px" >
                <strong>Pengimport</strong></td>
            <td style="height: 21px">
                <asp:TextBox ID="searchKodImporter" runat="server" Width="266px" ReadOnly="True"></asp:TextBox><asp:HiddenField
                    ID="Importer" runat="server" />
            </td>
        </tr>        
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>
         <table id="tblGridImporter" border="0" style="border-right: gray thin groove;
             border-top: gray thin groove; border-left: gray thin groove; width: 100%;">
             <tr>
                 <td style="background-color:#f1f1f1; width:7%">
                     No.</td>
                 <td style="background-color:#f1f1f1; width:22%; height:22px">
                     Pengeksport</td>
                 <td style="background-color:#f1f1f1; width:16%; height:22px">
                     No. Lesen</td>
                 <td style="background-color:#f1f1f1; width:15%; height:22px">
                     Tarikh Luput</td>
                 <td style="background-color:#f1f1f1; width:22%; height:22px">
                     Pengimport</td>
                <td style="background-color:#f1f1f1; width:15%; height:22px">
                     Kod Pengeksport</td>
             </tr>        
          </table><table id="Table1" border="0" style="border-right: gray thin groove;
             border-left: gray thin groove; width: 100%; border-bottom: gray thin groove">
              <tr>
                  <td style="background-color:#f1f1f1; width:7%; color: #f1f1f1;">
                      No.</td>
                  <td style="background-color:#f1f1f1; width:22%; height:22px; color: #f1f1f1;">
                      Pengeksport</td>
                  <td style="background-color:#f1f1f1; width:16%; height:22px; color: #f1f1f1;">
                      No. Lesen</td>
                  <td style="background-color:#f1f1f1; width:15%; height:22px; color: #f1f1f1;">
                      Tarikh Luput</td>
                  <td style="background-color:#f1f1f1; width:22%; height:22px; color: #f1f1f1;">
                      Pengimport</td>
                  <td style="background-color:#f1f1f1; width:15%; height:22px; color: #f1f1f1;">
                     Kod Pengeksport</td>
              </tr>
          </table>
         <br />
         <input id="Button3" type="button" value="Tambah" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" onclick="AddArray();refreshTableGridIkan();" disabled  />
          <input id="Button4" type="button" value="Batal" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1; width: 61px;" onclick="RemoveArray()" disabled /><div><asp:HiddenField ID="arrayVal" runat="server" /><asp:HiddenField ID="arrayFishVal" runat="server" />
                <asp:HiddenField ID="currentImporter" runat="server" />
              <asp:HiddenField ID="serverDate" runat="server" />
              <asp:HiddenField ID="Invois_Id" runat="server" />
              <asp:HiddenField ID="OnlineSend_By" runat="server" />
              &nbsp;&nbsp;
              <br />
          </div>
    
        <table style="width: 100%; border-top-width: thin; border-left-width: thin; border-bottom-width: thin; border-right-width: thin;" border="0">
            <tr>
                <td rowspan="2" style="width: 55px">
                    <strong>Kod BKH</strong></td>
                <td  rowspan="2" style="width:20%;">
                    <strong>Nama</strong></td>
                <td rowspan="2" style="width: 58px">
                    <div style="text-align:center">
                        <strong>Kod 8 Digit</strong></div></td>
                <td  rowspan="2" style="width:15%">
                    <div style="text-align:center">
                        <strong>Destinasi</strong></div></td>
                <td  colspan="4" style="border-bottom: black thin solid">
                    <div style="text-align:center">
                        <strong>Peti</strong></div></td>
				 <td  rowspan="2" style="width: 27px" >
                    <div style="text-align:center">
                        <strong>Pek</strong></div></td>
				 <td  rowspan="2">
                    <div style="text-align:center">
                        <strong>Ekor</strong></div></td>	
					 <td  rowspan="2" style="width: 68px; text-align: center;">
                         <strong>Kadar (RM/KG)</strong></td>
                <td rowspan="2" style="width: 68px; text-align: center">
                    <strong>Nilai (RM)</strong></td>
            </tr>
            <tr>
              <td style="height: 15px">
                  <span style="color: black"><strong>Kecil</strong></span></td>
              <td style="height: 15px; text-align: center; color: black;">
                  <strong>Kuantiti (kg)</strong></td>
              <td style="height: 15px">
                  <strong>Besar</strong></td>
              <td style="height: 15px; text-align: center;" >
                  <strong>Kuantiti(kg)</strong></td>
            </tr>
            <tr>
                <td style="height: 23px; width: 55px;" >
                    <asp:TextBox ID="Kod_BKH" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px;" >
                    <asp:TextBox ID="Nama_Ikan" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px; width: 58px;" >
                    <asp:TextBox ID="Kod8_Digit" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px" >
                    <asp:DropDownList ID="Destination" runat="server" DataSourceID="Destinasi" DataTextField="Nama_Negara"
                        DataValueField="Kod_Negara" Width="100%" Enabled="False">
                    </asp:DropDownList></td>
                <td style="height: 23px" ><asp:TextBox ID="txtPetiKecil" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                 <td style="height: 23px" ><asp:TextBox ID="txtKuantitiKecil" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                 <td style="height: 23px" ><asp:TextBox ID="txtPetiBesar" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                 <td style="height: 23px" ><asp:TextBox ID="txtKuantitiBesar" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                 <td style="height: 23px; width: 27px;" >
                     <asp:TextBox ID="txtPek" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px;" >
                    <asp:TextBox ID="txtEkor" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px; width: 68px;">
                    <asp:TextBox ID="txtNilai" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 68px; height: 23px">
                    <asp:TextBox ID="txtJumlahNilai" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
           
        </table>        
        <table id="tblGrid" border="0" style="width: 100%;">
            <tbody>
            <tr>
                <td style="background-color:#f1f1f1" rowspan="2">
                    Kod BKH</td>
                <td rowspan="2" style="background-color:#f1f1f1;width: 20%">
                    Nama</td>
                <td style=" background-color:#f1f1f1" rowspan="2" >
                    <div style="text-align:center">
                        Kod 8 Digit</div>
                </td>
                <td rowspan="2" style="background-color:#f1f1f1;width: 15%;">
                    <div style="text-align:center">
                        <span style="color: black">Destinasi</span></div>
                </td>
                <td colspan="4" style="background-color:#f1f1f1;border-bottom: black thin solid;">
                    <div style="text-align:center">
                        <span style="color: black">Peti</span></div>
                </td>
                <td style="background-color:#f1f1f1" rowspan="2">
                    <div style=" text-align:center; color: black">
                        Pek</div>
                </td>
                <td style="background-color:#f1f1f1" rowspan="2">
                    <div style=" text-align:center">
                        Ekor</div>
                </td>
                <td rowspan="2" style="background-color:#f1f1f1;text-align: center">
                    Nilai (RM)</td>
            </tr>
            <tr>
                <td style="background-color:#f1f1f1;height: 15px">
                    Kecil</td>
                <td style="background-color:#f1f1f1;height: 15px">
                    Kuantiti (kg)</td>
                <td style="background-color:#f1f1f1;height: 15px">
                    Besar</td>
                <td style="background-color:#f1f1f1;height: 15px">
                    Kuantiti(kg)</td>
            </tr>
            </tbody>
        </table>
        <table border="0" style="width: 100%;">
            <tbody>
                 <tr>
                    <td rowspan="1" style=" background-color:#ffffcc; width : 289px" colspan="4">
                        <strong>
                    [CTRL]</strong> <span style="color: #0000ff"><strong>Senarai Ikan
                    <input id="Button1" type="button" value="Tambah" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" onclick="AddFishArray();" disabled  /><input id="Button2" type="button" value="Batal" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1; width: 50px;" onclick="removeRow()" disabled /></strong></span></td>
                    <td  style="background-color:#ffffcc;border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;">
                    <asp:Label ID="Label1" runat="server" Width="100%">0</asp:Label></td>
                    <td  style="background-color:#ffffcc;border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;">
                    <asp:Label ID="Label2" runat="server" Width="100%">0</asp:Label></td>
                    <td  style="background-color:#ffffcc;border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;">
                    <asp:Label ID="Label3" runat="server" Width="100%">0</asp:Label></td>
                    <td  style="background-color:#ffffcc; border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;">
                    <asp:Label ID="Label4" runat="server" Width="100%">0</asp:Label></td>
                    <td rowspan="1" style="background-color:#ffffcc; border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid">
                    <asp:Label ID="Label5" runat="server" Width="100%">0</asp:Label></td>
                    <td rowspan="1" style="background-color:#ffffcc; border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid">
                    <asp:Label ID="Label6" runat="server" Width="100%">0</asp:Label></td>
                    <td rowspan="1" style="background-color:#ffffcc;border-top-style: solid; border-top-color: teal; border-bottom: teal thin solid;">
                    <asp:Label ID="Label7" runat="server" Width="100%">0</asp:Label></td>
                </tr>
                <tr>
                    <td rowspan="1" style="background-color:#f1f1f1; width: 289px; color: #f1f1f1; height: 27px;" colspan="4">
                        Kod BKHNamaKod 8 Digit<div style="text-align:center">
                            <span style="color: #f1f1f1">Destinasi</span></div>
                    </td>
                    <td style="background-color:#f1f1f1; height: 27px; color: #f1f1f1;">
                        Kecil</td>
                    <td style="background-color:#f1f1f1; height: 27px; color: #f1f1f1;">
                        Kuantiti (kg)</td>
                    <td style="background-color:#f1f1f1; height: 27px; color: #f1f1f1;">
                        Besar</td>
                    <td style="background-color:#f1f1f1; height: 27px; color: #f1f1f1;">
                        Kuantiti(kg)</td>
                    <td rowspan="1" style="background-color:#f1f1f1; color: #f1f1f1; height: 27px">
                        <div style=" text-align:center; color: #f1f1f1">
                            Pek</div>
                    </td>
                    <td  rowspan="1" style="background-color:#f1f1f1; color: #f1f1f1; height: 27px">
                        <div style="text-align:center">
                            Ekor</div>
                    </td>
                    <td rowspan="1" style="background-color:#f1f1f1; color: #f1f1f1; height: 27px;">
                        Nilai (RM)</td>
                </tr>
               
            </tbody>
        </table>
        &nbsp;<strong>Jumlah Peti&nbsp; :&nbsp;</strong>
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="0" Width="82px"></asp:Label><br />
        &nbsp;
        <hr /><asp:Button ID="Button5" runat="server" Text="CETAK SKPE" UseSubmitBehavior="False" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="printReport();" Enabled="False"/><asp:Button ID="Keluar" runat="server" Text="KELUAR" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;"/><br />
        <br />
        <br />
        <br />
                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                 &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp;
                    
          
        <asp:SqlDataSource ID="JenisPengangkutan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Cara_Pengangkutan]) as Kod_Pengangkutan, [Nama_Cara_Pengangkutan] as [Nama_Pengangkutan]  FROM [CARA_PENGANGKUTAN]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SumberBekalan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Negara], [Nama_Negara] FROM [NEGARA]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="PPI" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_PPI], [Nama_PPI] FROM [PUSATKOMPLEK]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="Pengeksport" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM(PENGEKSPORT.Kod_Pengeksport) + '|' + RTRIM(PENGEKSPORT.No_Lesen) + '|' + CAST(DAY(LESEN.Tarikh_Tamat) AS nvarchar(200)) + '/' + CASE WHEN MONTH(LESEN.Tarikh_Tamat) < 10 THEN '0' + CAST(month(lesen.tarikh_tamat) AS varchar(1)) ELSE CAST(month(lesen.tarikh_tamat) AS varchar(2)) END + '/' + CAST(YEAR(LESEN.Tarikh_Tamat) AS nvarchar(4)) AS Val, PENGEKSPORT.Nama_Syarikat_Eksport FROM PENGEKSPORT INNER JOIN LESEN ON PENGEKSPORT.No_Lesen = LESEN.No_Lesen&#13;&#10;ORDER BY LTRIM(PENGEKSPORT.Nama_Syarikat_Eksport)">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Pengimport" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT Kod_Pengimport, Nama_Pengimport AS Nama_Syarikat_Pengimport FROM PENGIMPORT_THAILAND ORDER BY LTRIM(Nama_Pengimport) ASC">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Destinasi" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Negara]+'|'+[Nama_Negara] as [Kod_Negara], [Nama_Negara] FROM [NEGARA] ">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Urusan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Urusan], [Nama_Urusan] FROM [JENIS_URUSAN]"></asp:SqlDataSource>
         <asp:HiddenField ID="status" runat="server" />
        <cc1:FilteredTextBoxExtender ID="txtNilaiKeyboardRestrictor" runat="server" TargetControlID="txtNilai" FilterType="Custom,Numbers" ValidChars=",-.">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="PetiKecilRestrictor" runat="server" TargetControlID="txtPetiKecil" FilterType="Numbers">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="PetiBesarRestrictor" runat="server" TargetControlID="txtPetiBesar" FilterType="Numbers">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="QtyKecilRestrictor" runat="server" TargetControlID="txtKuantitiKecil" FilterType="Custom,Numbers" ValidChars=".">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="QtyBesarRestrictor" runat="server" TargetControlID="txtKuantitiBesar" FilterType="Custom,Numbers" ValidChars=".">
        </cc1:FilteredTextBoxExtender><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtKuantitiKecil" FilterType="Custom,Numbers" ValidChars=",-.">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="ekorRestrictor" runat="server" TargetControlID="txtEkor" FilterType="Custom,Numbers" ValidChars=",-.">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="PekRestrictor" runat="server" TargetControlID="txtPek" FilterType="Custom,Numbers" ValidChars=",-.">
        </cc1:FilteredTextBoxExtender>
         &nbsp; &nbsp;<br />
         &nbsp;<br />
       
           
         &nbsp;
        
        
    </form>
    <script language="javascript" type="text/javascript">
    //showHint(document.all.arrayVal.value,"Load_ImporterInfo.aspx");
    refreshTableGridImporter()
   // alert("testing 13");
    refreshTableGridIkan();
    //showHint2(document.all.arrayFishVal.value,"Load_ImporterFishInfo.aspx");
</script>   
</body>
</html>
