<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pengisyitiharan_pindahan.aspx.vb" Inherits="Import_pengisyitiharan_p" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>[WICCS]-Pengisytiharan Pindahan Barangan</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" /> 
    <style type="text/css">
/* ==================================================================== */
/* SCROLLING DATA GRID - IE ONLY!                                       */
/* ==================================================================== */
/* 
Tables inside a scrollingdatagrid should have:
 1. border-collapse:separate
 2. No border or margin
 3. Background colors on all cells to avoid bleed-thru on scroll
 4. cellspacing="0" on the <table> tag itself
*/
DIV.scrollingdatagrid {
	overflow-x:auto;
	overflow-y:auto;
	position:relative;
	padding:0px;
	FONT-SIZE: 8pt;    
    FONT-FAMILY: Verdana, Tahoma;
}
DIV.scrollingdatagrid TABLE {
	width : 98.7%; /* Make room for scroll bar! */
	margin:0px;
	border:0px;
	border-collapse:separate;
	FONT-SIZE: 8pt;    
    FONT-FAMILY: Verdana, Tahoma;
}
DIV.scrollingdatagrid TABLE TR .locked, DIV.scrollingdatagrid TABLE THEAD TR, DIV.scrollingdatagrid TABLE TFOOT TR {
	position:relative;
}
/* OffsetParent of the TR is the DIV because it is position:relative */
DIV.scrollingdatagrid TABLE THEAD TR {
	top:expression(this.offsetParent.scrollTop);
}
/* OffsetParent of the THEAD and TFOOT locked column is the TR because it is position:relative */
DIV.scrollingdatagrid THEAD .locked, DIV.scrollingdatagrid TFOOT .locked {
	left:expression(this.offsetParent.offsetParent.scrollLeft);
}
DIV.scrollingdatagrid TBODY .locked {
	left:expression(this.offsetParent.scrollLeft);
}
/* The TFOOT should stick to the bottom of the DIV */
DIV.scrollingdatagrid TABLE TFOOT TR {
	top:expression(0 - this.offsetParent.scrollHeight + this.offsetParent.clientHeight + this.offsetParent.scrollTop);
}
/* Make the z-index values very clear so overlaps happen as expected! */
DIV.scrollingdatagrid TD, DIV.scrollingdatagrid TH { z-index:1; }
DIV.scrollingdatagrid TD.locked, DIV.scrollingdatagrid TH.locked { z-index:2; }
DIV.scrollingdatagrid THEAD TR, DIV.scrollingdatagrid TFOOT TR { z-index:3; }
DIV.scrollingdatagrid THEAD TR TH.locked { z-index:4; }
</style> 
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


<script type="text/javascript" src="../../windowfiles/dhtmlwindow.js">

/***********************************************
* DHTML Window Widget- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for legal use.
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/

</script>
<script language="javascript" type="text/javascript">

var chargeFound=0;
var kategori_ikan_g = new Array();
var jenis_urusan_g = new Array();
var kpk_g = new Array();
var kpb_g = new Array();
var ke_g = new Array();
var kqty_g = new Array();
var id_g = new Array();


var company_c = new Array();
var kategori_ikan_c = new Array();
var jenis_urusan_c = new Array();
var kpk_c = new Array();
var kpb_c = new Array();
var ke_c = new Array();
var kqty_c = new Array();
var id_c = new Array();

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
var MKodKategoriIkan = new Array();
var txtNilaiKadar = new Array();


var preEl ;
var orgBColor;
var orgTColor;

function newForm()
{
    input_box=confirm("PERHATIAN !!!!\n\Adakah Anda Pasti Ingin Memaparkan Borang Baru? Sila Tekan OK untuk YA CANCEL untuk TIDAK");    
    if (input_box==true) 
    {
        location.href='../../pintu_masuk/verifikasi_PintuMasuk.aspx';    
    }    
}

function pastiKanData()
{
    var jenisUrusanLama = document.all.JenisUrusanLama.value;
    var jenisUrusanBaru = document.all.JenisUrusan.options[document.all.JenisUrusan.selectedIndex].text;    
    
    if (jenisUrusanBaru!=jenisUrusanLama)
    {
        input_box=confirm("PERHATIAN !!!!\n\nAnda Telah Menukar Jenis Urusan Dari \""+ jenisUrusanLama +"\" Kepada \""+ jenisUrusanBaru +"\"\nAdakah Anda Pasti Dengan Perubahan Tersebut? Sila Tekan OK untuk YA CANCEL untuk TIDAK");    
        if (input_box==true) 
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }
    else
    {   
       
        if (document.all.JenisUrusan.options.value=="007" ||document.all.JenisUrusan.options.value=="009" || document.all.JenisUrusan.options.value=="019" || document.all.JenisUrusan.options.value=="020")
        {
           alert("Pengisytiharan Bagi Jenis Urusan \""+ jenisUrusanBaru +"\" Adalah Tidak Dibenarkan!!!!");
            return false;
        }
        else
        {
            return true;
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
document.all.currentImporter.value=a_obj.cells(5).innerHTML;
//alert(document.all.currentImporter.value);
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

var cajpetibesar = new Array();
var cajpetikecil = new Array();
var cajkkuantiti = new Array();
var cajkekor = new Array();

function findKadarCajPB(strFind)
{
    var i;
    var foundstr=0;
    for(i=0; i<cajpetibesar.length; i++)
    {
        if (strFind.replace(/\s+$/,"")==cajpetibesar[i].replace(/\s+$/,""))
        {
           foundstr=1;
           break;
        }
    }
    return foundstr;
}

function findKadarCajPK(strFind)
{
 
    var i;
    var foundstr=0;
    for(i=0; i<cajpetikecil.length; i++)
    {
        if (strFind.replace(/\s+$/,"")==cajpetikecil[i].replace(/\s+$/,""))
        {
           foundstr=1;
           break;
        }
    }
    return foundstr;
}

function findKadarCajQty(strFind)
{   
    var i;
    var foundstr=0;
    for(i=0; i<cajkkuantiti.length; i++)
    {
        if (strFind.replace(/\s+$/,"")==cajkkuantiti[i].replace(/\s+$/,""))
        {
           foundstr=1;
           break;
        }
    }
    return foundstr;
}

function findKadarCajEkor(strFind)
{   
    var i;
    var foundstr=0;
    for(i=0; i<cajkekor.length; i++)
    {
        if (strFind.replace(/\s+$/,"")==cajkekor[i].replace(/\s+$/,""))
        {
           foundstr=1;
           break;
        }
    }
    return foundstr;
}


function listKadarCajPBI()
{   
    var i;
    var dataStringPB;   
    for(i=0; i<cajpetibesar.length; i++)
    {
       if (i==0)
       {
        dataStringPB=cajpetibesar[i];
       }
       else
       {
        dataStringPB=dataStringPB+", "+cajpetibesar[i];
       } 
    }
    return dataStringPB;
}

function listKadarCajPK()
{ 
    var i;
    var dataString;
    for(i=0; i<cajpetikecil.length; i++)
    {
       if (i==0)
       {
        dataString=cajpetikecil[i];
       }
       else
       {
        dataString=dataString+", "+cajpetikecil[i];
       } 
    }
    return dataString;
}

function listKadarCajQty()
{   
    var i;
    var dataString;
    for(i=0; i<cajkkuantiti.length; i++)
    {
       //alert("drKuantiti="+cajkkuantiti[i]);
       if (i==0)
       {
        dataString=cajkkuantiti[i];
       }
       else
       {
        dataString=dataString+", "+cajkkuantiti[i];
       } 
    }
    return dataString;
}

function listKadarCajEkor()
{   
    var i;
    var dataString;
    for(i=0; i<cajkekor.length; i++)
    {
       if (i==0)
       {
        dataString=cajkekor[i];
       }
       else
       {
        dataString=dataString+", "+cajkekor[i];
       } 
    }
    return dataString;
}



function printReport(strCetak)
{

//MM_openBrWindow(str,'eSKPI',''); 


//Get Kadar Caj PetiBesar,PetiKecil,Kuantiti,KadarEkor
var strIkanInfo = document.all.arrayFishVal.value;
var arrIkanInfo = strIkanInfo.split("~");
var i;

for (i=0;i<arrIkanInfo.length-1; i++)
{
    var arrIkanInfoDetails  = arrIkanInfo[i].split("`");
   // alert(arrIkanInfo[i]);
   // alert(arrIkanInfoDetails.length);
    var foundPK=0;
   
    if (arrIkanInfoDetails[13].replace(/\s+$/,"")!="")    
    {
         foundPK=findKadarCajPK(arrIkanInfoDetails[13]);
    }
    if (foundPK==0)
    {       
       if (cajpetikecil.length>=0)
       {
        cajpetikecil[cajpetikecil.length]=arrIkanInfoDetails[13].replace(/\s+$/,"");
       }
       else
       {
        cajpetikecil[0]=arrIkanInfoDetails[13].replace(/\s+$/,"");
       }
    }
    
    var foundPB=0;
    
    if (arrIkanInfoDetails[14].replace(/\s+$/,"")!="")    
    {
       foundPB=findKadarCajPB(arrIkanInfoDetails[14]);
    }
    if (foundPB==0)
    {
             
       if (cajpetibesar.length>=0)
       {
        cajpetibesar[cajpetibesar.length]=arrIkanInfoDetails[14].replace(/\s+$/,"");
       }
       else
       {
        cajpetibesar[0]=arrIkanInfoDetails[14].replace(/\s+$/,"");
       }              
    }
    
    var foundKekor=0;
    if (arrIkanInfoDetails[15].replace(/\s+$/,"")!="")    
    {
       foundKekor=findKadarCajEkor(arrIkanInfoDetails[15]);
    }
    if (foundKekor==0)
    {
       if (cajkekor.length>=0)
       {
          cajkekor[cajkekor.length]=arrIkanInfoDetails[15].replace(/\s+$/,"");
       }
       else
       {
          cajkekor[0]=arrIkanInfoDetails[15].replace(/\s+$/,"");
       }
    }
    
    
    var foundKQty=0;
    if (arrIkanInfoDetails[16].replace(/\s+$/,"")!="")    
    {
         foundKQty=findKadarCajQty(arrIkanInfoDetails[16]);
    }
    if (foundKQty==0)
    {
        if (cajkkuantiti.length>=0)
        {
           cajkkuantiti[cajkkuantiti.length]=arrIkanInfoDetails[16].replace(/\s+$/,"");
        }
        else
        {
           cajkkuantiti[0]=arrIkanInfoDetails[16].replace(/\s+$/,""); 
        }
    }   
 
 
   
} //end for

var cajPBI=listKadarCajPBI();
var cajPK=listKadarCajPK();
var cajKdrEkor=listKadarCajEkor();
var cajKdrQty =listKadarCajQty();

/*
alert("cajPB"+cajPBI);
alert("cajPK"+cajPK);
alert("cajKdrEkor"+cajKdrEkor);
alert("cajKdrQty"+cajKdrQty);
*/

var winTitle;

var str ="../../import/eSKPI-P.aspx?barcode="+ document.all.Barcodes.value +"&invois_id="+document.all.Invois_Id.value+"&SalinanMs="+ escape(winTitle)+"&cajPBI="+ cajPBI +"&cajPK="+ cajPK +"&cajKdrEkor"+ cajKdrEkor +"&cajKdrQty="+ cajKdrQty +"&cetak="+ strCetak+"&pname="+document.all.printer_name.value;
//alert(document.all.printer_name.value);
if (strCetak==1)
{
    if (document.all.printer_name.value!="")
    {    
      window.open(str,'eSKPI_prt','width=5,height=5,status=yes');
    }
    else
    {
      alert("Sila Pilih Printer Terlebih Dahulu !!!");
    }
}
else
{
window.open(str,'eSKPI_p','');
}

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

var kodimporter_ppi = new Array();
var kod_ppi = new Array();

function findImporterPPI(strfindimp,strfindppi)
{
    var foundImpPPI=0;
    for(ix=0;ix<kodimporter_ppi.length;ix++)
    {
       // alert(strfindimp.replace(/\s+$/,"") +"=="+ kodimporter_ppi[ix].replace(/\s+$/,""));
      //  alert(strfindppi.replace(/\s+$/,"")+"=="+kod_ppi[ix].replace(/\s+$/,""));        
        if (strfindimp.replace(/\s+$/,"")==kodimporter_ppi[ix].replace(/\s+$/,"") && strfindppi.replace(/\s+$/,"")==kod_ppi[ix].replace(/\s+$/,""))
        {
           foundImpPPI=1;
           break; 
        }
    }
    return foundImpPPI;
}

// show senarai printer
function showSenaraiprinter()
{
  window.open('../../pembayaran/senarai-printer.aspx','test','width=310,height=420,status=yes');  
}

function AddArray()
{
    var date1 = new Date();
    var date2 = new Date();
    var diff  = new Date();
    
    
    if (document.all.nama_pemandu_pindahan.value=="" || document.all.no_kenderaan_pindahan.value=="")
    {
        alert("Sila masukkan nama pemandu & no kenderaan \nbagi pindahan barangan untuk meneruskan operasi!!!")
    }
    else
    {    

    var dataItem1 = document.all.Importer.value;    
    document.all.currentImporter.value=dataItem1;
    var dataItem2 = document.all.Bekalan;
    var dataItem3 = document.all.KompleksPPI;
    var dataItem4 = document.all.Exporter.value;
    var strTemp = dataItem1;
    var strTemp2 = strTemp.split("|");    
    var stat = "false";
    
     //Verifying Importer Have Permission To Do Any Transaction On Selected PPI Or Not
     var ImporterPPIStatus=findImporterPPI(strTemp2[0],document.all.KompleksPPI.options.value);
    //alert(ImporterPPIStatus);
    if (ImporterPPIStatus==1)    
    {
    
    
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
       alert("Lesen Pengimport Telah Tamat Tempoh & Melebihi Hari Pelepasan Ditetapkan");                
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
            document.all.arrayVal.value = dataItem1 + '`' + document.all.searchKodImporter.value  + '`' + dataItem2.options.value +'`'+ dataItem3.options.value + '`' + dataItem4 + '`' + document.all.searchKodExporter.value +'`'+ document.all.nama_pemandu_pindahan.value +'`'+ document.all.no_kenderaan_pindahan.value +'~'+ document.all.arrayVal.value;
            
                        
            var myString =dataItem1 + '`' + document.all.searchKodImporter.value + '`' + dataItem2.options.value +'`'+ dataItem3.options.value + '`' + dataItem4 + '`' + document.all.searchKodExporter.value +'`'+ document.all.nama_pemandu_pindahan.value +'`'+ document.all.no_kenderaan_pindahan.value +'~';
            
            /* Remarks By Nizam 11 On July 2007
            
            //add a row to the rows collection and get a reference to the newly added row
	        var newRow = document.all("tblGridImporter").insertRow();	
	        newRow.attachEvent("onclick", makeEventFunc('#c9cc99','cc3333'));
	        //newRow.bgColor="#c9cc99";
	        var oCell = newRow.insertCell();	
    	    
    	    */
    	    
	        var strTemp=dataItem1;
	        var arrTemp=strTemp.split("|");	    
    	    
    	    /*
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
    	    //oCell.innerHTML = "<img src=\"../../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');\" />"+ document.all.Kod_BKH.value;				    
	        oCell = newRow.insertCell();
	        oCell.innerHTML = document.all.searchKodImporter.value;
	        oCell = newRow.insertCell();
	        oCell.innerHTML =arrTemp[1];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrTemp[2];	
	        oCell = newRow.insertCell();
	        oCell.innerHTML = document.all.searchKodExporter.value ;
	        oCell = newRow.insertCell();
	        oCell.innerHTML = arrTemp[0];
	        oCell = newRow.insertCell();
	        oCell.innerHTML = document.all.nama_pemandu_pindahan.value;
	        oCell = newRow.insertCell();
	        oCell.innerHTML = document.all.no_kenderaan_pindahan.value;
	        	    
	        //end of new row inserted	        
    	    
    	    */
    	    refreshTableGridImporter();
    	    
	        //set currentImporter value
	        document.all.currentImporter.value=arrTemp[0];    
	        //
            
            //showHint(document.all.arrayVal.value,"Load_ImporterInfo.aspx");
            //showHint2(document.all.arrayFishVal.value);
            
            //reset details ikan value    
////            document.all.Kod_BKH.value="";
////            document.all.Nama_Ikan.value="";
////            document.all.Kod8_Digit.value="";    
////            document.all.txtPetiKecil.value="";
////            document.all.txtKuantitiKecil.value="";
////            document.all.txtPetiBesar.value="";
////            document.all.txtKuantitiBesar.value="";
////            document.all.txtNilai.value="";
////            document.all.txtJumlahNilai.value="";    
            //end of reset
            document.all.searchKodImporter.value="";
            document.all.searchKodExporter.value="";
        }
        else
        {
            alert('Pengimport '+ document.all.searchKodImporter.value +' telah wujud di dalam senarai!!!');
        }
   } 
    }
    else
   {
     alert('Pengimport '+ document.all.searchKodImporter.value  +' tidak dibenarkan melakukan sebarang transaksi di PPI Ini !!!');
   }  
  }//end if for validation pemandu pindahan && no kenderaan pindahan
  document.all.nama_pemandu_pindahan.value="";
  document.all.no_kenderaan_pindahan.value="";
  
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
   	        refreshTableGridIkan();
   	        
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
	        alert("Sila Pilih Sekurang-kurangnya 1 Pengimport Untuk Pengoperasian!!!!");	        
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
    	   // oCell.style.width="22px";
	      //  oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';
	        oCell.innerHTML = "<input name=\"checkbox\" type=\"checkbox\" value=\""+ myString +"\" />";
    	    //oCell.innerHTML = "<img src=\"../../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');removeRow(this);\" />"+ document.all.Kod_BKH.value;				    
    	    
	        oCell = newRow.insertCell();	        
	       // oCell.style.width="25px";
	       // oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';	        
	        oCell.innerHTML = arrImporterInfoDetails[1];
	        
	        oCell = newRow.insertCell();
	        //oCell.style.width="25px";
	        //oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';
	        oCell.innerHTML = arrImporterData[1];	
	
	        oCell = newRow.insertCell();
	        //oCell.style.width="25px";
	        //oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';
	        oCell.innerHTML = arrImporterData[2];	
	        
	        oCell = newRow.insertCell();
	        //oCell.style.width="25px";
	        //oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';
	        oCell.innerHTML = arrImporterInfoDetails[5];
	        
	        oCell = newRow.insertCell();
	        //oCell.style.width="25px";
	        //oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';
	        oCell.innerHTML = arrImporterData[0];	    
	        
	        oCell = newRow.insertCell();	        
	        //oCell.style.width="25px";
	        //oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';
	        oCell.innerHTML = arrImporterInfoDetails[6];	    
	        
	        oCell = newRow.insertCell();
	       // oCell.style.width="25px";
	      //  oCell.style.height="22px";	        
	        //oCell.style.background-color='#f1f1f1';
	        oCell.innerHTML = arrImporterInfoDetails[7];	    
	        //end of new row inserted	      
	    
	        //set currentImporter value
	        document.all.currentImporter.value = arrImporterData[0];	    
	        //  
            
          
        }//end for
   
}


function getImporterStatus(importerCode)
{
    
    var skpiStatus="";
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
            if (importerCode==arrImporterData[0])
            {
                skpiStatus=arrImporterInfoDetails[6].replace(/\s+$/,"");                
                break;     
            }
                     
    }//end for
    
    return skpiStatus;
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
//    if (cnt==8)
//    {
//        alert('Hanya 8 item sahaja yg boleh diisytiharkan dalam satu e-SKPI');
//    }
//    else
//    {    
        
        if (myValNilai==0)
        {
            alert("Maklumat data ikan tidak lengkap!!! \n Nilai mestilah melebihi RM 0.00!!!!");           
            document.all.ju.value = "0";
            document.all.kpk.value = "0";
            document.all.kpb.value = "0";
            document.all.ke.value = "0";
            document.all.kq.value = "0";
            document.all.kod_id.value = "0";
        }
        else
        {
            //Search Company Exists In Array Company_C or Not To Calculate Fish Charges
                     
            var kpk=0;
            var kpb=0;
            var kq=0;
            var ke=0;
              
             if (document.all.kpk.value!="")
             {
               kpk=document.all.kpk.value; 
             }
             if (document.all.kpb.value!="")
             {
               kpb=document.all.kpb.value; 
             }
             if (document.all.kq.value!="")
             {
               kq=document.all.kq.value; 
             }
             if (document.all.ke.value!="")
             {
               ke=document.all.ke.value; 
             }
             
             
            var CnilaiCaj = (parseFloat(myVal1) * parseFloat(kpk)) + (parseFloat(myVal2) * parseFloat(kpb)) + (parseFloat(myValKK) * parseFloat(kq)) + (parseFloat(myValPek) * parseFloat(ke)); 
            
            //var CnilaiCaj = (parseFloat(myVal1) * parseFloat(document.all.kpk.value)) + (parseFloat(myVal2) * parseFloat(document.all.kpb.value)) + (parseFloat(myValKK) * parseFloat(document.all.kq.value)) + (parseFloat(myValPek) * parseFloat(document.all.ke.value));
                
            document.getElementById("Label1").innerHTML=tpk;
            document.getElementById("Label2").innerHTML=tkk;
            document.getElementById("Label3").innerHTML=tpb;
            document.getElementById("Label4").innerHTML=tkb;
            document.getElementById("Label5").innerHTML=tpek;
            document.getElementById("Label6").innerHTML=tekor;
            document.getElementById("Label7").innerHTML=nilai;
            document.getElementById("Label8").innerHTML= etpk + etpb ;
            
            //var CnilaiCaj = parseDouble(myVal1) * parseDouble(document.all.kpk.value);// + (parseDouble(myVal2) * parseDouble(document.all.kpb.value)) + (parseDouble(myValKK) * parseDouble(document.all.kq.value)) + (parseDouble(myValPek) * parseDouble(document.all.ke.value));
           
            //alert(myVal1);
            //alert(document.all.kpk.value);  
            //var CnilaiCaj=parseFloat(myVal1);
            //alert(CnilaiCaj);    
            var strTemp = document.all.Destination.options.value;
            var strTemp2 = strTemp.split("|");  
            var arrVal = document.all.currentImporter.value + '`' + document.all.Kod_BKH.value + '`' + document.all.Nama_Ikan.value + '`' + document.all.Kod8_Digit.value + '`' + strTemp2[0] + '`' + myVal1 + '`' + myValKK + '`' + myVal2 + '`' + myValKB + '`' + myValPek + '`' + myValEkor + '`' + myValNilai + '`' + strTemp2[1] +'`'+ document.all.kpk.value +'`'+ document.all.kpb.value +'`'+ document.all.ke.value +'`'+ document.all.kq.value +'`'+ document.all.kod_id.value + '`'+ CnilaiCaj + '~';
            document.all.arrayFishVal.value = arrVal + document.all.arrayFishVal.value;
           // alert(document.all.arrayFishVal.value);
            //addRow(arrVal);
            refreshTableGridIkan();
            //showHint2(document.all.arrayFishVal.value);    
        }
    //}
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
    //strReplace = strReplace + "~";
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
    for(i=1;i<totalRows;i++)
    {
        document.all("tblGrid").deleteRow(1);
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
       	        var importerStatus = getImporterStatus(currImporter);
       	         
       	        //add a row to the rows collection and get a reference to the newly added row
                var newRow = document.all("tblGrid").insertRow();	
                var oCell = newRow.insertCell();
                // if (importerStatus=="B")
	            //{
                    oCell.innerHTML = "<img src=\"../../images/del..gif\"  onclick=\"+RemoveFishArray('"+arrIkanInfo[i]+"~');\" />"+ arrIkanInfoDetails[1];			
                //}
                //else
                //{
                //    oCell.innerHTML =" ";
                //}    
                
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
	
	oCell.innerHTML = "<img src=\"../../images/del..gif\"  onclick=\"+RemoveFishArray('"+myString+"');\" />"+ document.all.Kod_BKH.value;			
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
    //alert(searchItem);
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
          var katIkan;
          // alert(searchItem+"=="+KodBKHNew[i]);
           if (searchItem==KodBKHNew[i])
            {
                //alert("found");
                sendValue(KodBKH[i],NamaIkan[i],KodIkan[i],txtNilaiKadar[i]);
                found =1;
                //Set Fish Charges
                 katIkan=MKodKategoriIkan[i];
                //alert(document.all.currentImporter.value +","+ document.all.JenisUrusan.options.value + ","+ MKodKategoriIkan[i]);
                showFilteredCompanyIkanCaj(document.all.currentImporter.value,document.all.JenisUrusan.options.value,katIkan);
                if (chargeFound==0)
                {
                    showFilteredIkanCaj(document.all.JenisUrusan.options.value,katIkan);
                }
                document.all.Destination.focus();                 
                break;
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
                document.all.searchKodExporter.focus();
            }    
       }//end next
       
       if (found==0)               
       {
           input_box=confirm("Kod Importer Tidak Ditemui Sila Cari Secara Manual!!! \nAdakah Anda Ingin Mencari Kod Importer Secara Manual? \nSila Tekan OK untuk \"Ya\" CANCEL untuk \"Tidak\"!! ");
           if (input_box==true)
           { 
                // Output when OK is clicked                
                window.open('/w-iccs/Import/Senarai-Importer.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
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
            }    
       }//end next
       
       if (found==0)               
       {
           input_box=confirm("Kod Importer Tidak Ditemui Sila Cari Secara Manual!!! \nAdakah Anda Ingin Mencari Kod Importer Secara Manual? \nSila Tekan OK untuk \"Ya\" CANCEL untuk \"Tidak\"!! ");
           if (input_box==true)
           { 
                // Output when OK is clicked                
                window.open('/w-iccs/Import/Senarai-Exporter.aspx','SenaraAgen','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
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

/*
function showFilteredCompanyIkanCaj(company_code,jenis_urusan_code,kategori_ikanSearch)
{
    chargeFound=0;
   // alert(company_c.length);
    for (i=0;i<company_c.length;i++)
    {
          // alert(company_code +"="+ company_c[i]);
          // alert(jenis_urusan_code +"="+ jenis_urusan_c[i]);
          // alert(kategori_ikanSearch +"="+ kategori_ikan_c[i]);
           
           if (company_code==company_c[i] && jenis_urusan_code==jenis_urusan_c[i] && kategori_ikanSearch==kategori_ikan_c[i])
            {
                //alert("found");
                document.all.ju.value = jenis_urusan_code;
                document.all.kpk.value = kpk_c[i];
                document.all.kpb.value = kpb_c[i];
                document.all.ke.value = ke_c[i];
                document.all.kq.value = kqty_c[i];
                document.all.kod_id.value = id_c[i];
                chargeFound =1;                              
                break;
            }    
     }//end next    
   
}
*/

function showFilteredCompanyIkanCaj(company_code,jenis_urusan_code,kategori_ikanSearch)
{
    chargeFound=0;
   // alert(company_c.length);
    for (i=0;i<company_c.length;i++)
    {
          //alert(company_code +"="+ company_c[i]);
          //alert(jenis_urusan_code +"="+ jenis_urusan_c[i]);
          //alert(kategori_ikanSearch +"="+ kategori_ikan_c[i]);
          //alert(jenis_urusan_code+"="+jenis_urusan_c[i]+" && "+ kategori_ikanSearch+"=="+ kategori_ikan_c[i]);
           //if (company_code==company_c[i] && jenis_urusan_code==jenis_urusan_c[i] && kategori_ikanSearch==kategori_ikan_c[i])
           if (company_code==company_c[i] && kategori_ikanSearch==kategori_ikan_c[i])
            {
               // alert("found");
                document.all.ju.value = jenis_urusan_code;
                document.all.kpk.value = kpk_c[i];
                document.all.kpb.value = kpb_c[i];
                document.all.ke.value = ke_c[i];
                document.all.kq.value = kqty_c[i];
                document.all.kod_id.value = id_c[i];
                chargeFound =1;                              
                break;
            }    
     }//end next    
   
}

function showFilteredIkanCaj(jenis_urusan_code,kategori_ikanSearch)
{
    //chargeFound=0;
    for (i=0;i<jenis_urusan_c.length;i++)
    {
           if ((jenis_urusan_code==jenis_urusan_g[i]) && (kategori_ikanSearch==kategori_ikan_g[i]))
            {
               // alert("found="+i+"="+KeyKodAgen[i]);
                document.all.ju.value = jenis_urusan_code;
                document.all.kpk.value = kpk_g[i];
                document.all.kpb.value = kpb_g[i];
                document.all.ke.value = ke_g[i];
                document.all.kq.value = kqty_g[i];
                document.all.kod_id.value = id_g[i];
                chargeFound =1;                
                break;
            }    
    }//end next    
}

function openMasterSheet()
{
 var strUrl="../../import/v_mastersheet.aspx";
 MM_openBrWindow(strUrl,'test','width=800,height=600,status=yes');
}
</script>
<%
    Dim cntArray As Integer = 0
    Dim sqlText As String = "SELECT [Nama_BKH], [Kod_Ikan], [Kod_BKH],[Harga_BKH],RTRIM([Kod_Kategori_Ikan]) as Kod_Kategori_Ikan FROM [JENIS_IKAN] WHERE [STATUS]='yes'"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("KodBKHNew[" & cntArray & "]='" & jsReader.GetValue(2).ToString.Trim() & "';" & vbCrLf)
        Response.Write("KodBKH[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf)
        Response.Write("NamaIkan[" & cntArray & "]='" & jsReader.GetValue(0) & "';" & vbCrLf)
        Response.Write("KodIkan[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("MKodKategoriIkan[" & cntArray & "]='" & jsReader.GetValue(4) & "';" & vbCrLf)
        Response.Write("txtNilaiKadar[" & cntArray & "]='" & jsReader.GetValue(3) & "';" & vbCrLf & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
    
    cntArray = 0
    sqlText = "SELECT RTRIM(PENGIMPORT.Kod_Pengimport) as kodPengimport, RTRIM(PENGIMPORT.Kod_Pengimport) +'|'+ " & _
              "RTRIM(PENGIMPORT.No_Lesen) + '|'+ CAST(DAY(LESEN.Tarikh_Tamat) AS nvarchar(200)) " & _
              "+ '/'+ case when MONTH(LESEN.Tarikh_Tamat) < 10 then '0'+cast(month(lesen.tarikh_tamat) as varchar(1)) else cast(month(lesen.tarikh_tamat) as varchar(2)) end   " & _
              "+ '/' + CAST(YEAR(LESEN.Tarikh_Tamat) as nvarchar(4)) AS Val," & _
              "RTRIM(PENGIMPORT.Nama_Syarikat_Import) as [Nama_Syarikat_Import] " & _
              "FROM PENGIMPORT INNER JOIN " & _
              "LESEN ON PENGIMPORT.No_Lesen = LESEN.No_Lesen "
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
    sqlText = "SELECT Rtrim([Kod_Pengeksport]) as val, [Kod_Pengeksport], RTRIM([Nama_Pengeksport]) as [Nama_Syarikat_Eksport] FROM [PENGEKSPORT_THAILAND]"
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
                
    'Load Kadar Caj Ikan Untuk Semua Pengimport
    cntArray = 0
    sqlText = "SELECT RTRIM(Kategori_Ikan) as Kategori_Ikan, RTRIM(Jenis_Urusan) as Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti, id " & _
              "FROM IKAN_CAJ WHERE status = 'yes'"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("kategori_ikan_g[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("jenis_urusan_g[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("kpk_g[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf)
        Response.Write("kpb_g[" & cntArray & "]='" & jsReader.GetValue(3) & "';" & vbCrLf)
        Response.Write("ke_g[" & cntArray & "]='" & jsReader.GetValue(4) & "';" & vbCrLf)
        Response.Write("id_g[" & cntArray & "]='" & jsReader.GetValue(6) & "';" & vbCrLf)
        Response.Write("kqty_g[" & cntArray & "]='" & jsReader.GetValue(5) & "';" & vbCrLf & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
    
    'Load Kadar Caj Ikan Untuk Pengimport Tertentu
    cntArray = 0
    sqlText = "SELECT RTRIM(Kategori_Ikan) as Kategori_Ikan, RTRIM(Jenis_Urusan) as Jenis_Urusan, Kadar_Peti_Kecil, Kadar_Peti_Besar, Kadar_Ekor, Kadar_Kuantiti, Kod_Pengimport,id " & _
              "FROM COMPANY_IKAN_CAJ WHERE (tarikh_tamat >= GETDATE())"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("kategori_ikan_c[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("jenis_urusan_c[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("kpk_c[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf)
        Response.Write("kpb_c[" & cntArray & "]='" & jsReader.GetValue(3) & "';" & vbCrLf)
        Response.Write("ke_c[" & cntArray & "]='" & jsReader.GetValue(4) & "';" & vbCrLf)
        Response.Write("kqty_c[" & cntArray & "]='" & jsReader.GetValue(5) & "';" & vbCrLf)
        Response.Write("id_c[" & cntArray & "]='" & jsReader.GetValue(7) & "';" & vbCrLf)
        Response.Write("company_c[" & cntArray & "]='" & jsReader.GetValue(6) & "';" & vbCrLf & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
    
    'Load Rujukan PPI Pengimport
    cntArray = 0
    sqlText = "SELECT [Kod_Pengimport],[Kod_PPI] " & _
              "FROM pintu_masuk_sistem_q"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("kodimporter_ppi[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("kod_ppi[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf & vbCrLf)
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
                    <strong>&nbsp;<span style="color: #ffffff">PENGISYTIHARAN PINDAHAN BARANGAN</span></strong></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td >
                    <strong>&nbsp;Agen Pengangkutan</strong></td>
                <td >
                    <asp:TextBox ID="NamaAgen" runat="server" Width="260px" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <strong>&nbsp;#Rujukan</strong></td>
                <td>
                    <asp:TextBox ID="rujukan" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    <strong>&nbsp;Nama Pemandu</strong></td>
                <td >
                    <asp:TextBox ID="NamaPemandu" runat="server" Width="259px"></asp:TextBox></td>
                <td >
                    <strong>&nbsp;#Barcode</strong></td>
                <td >
                    <asp:TextBox ID="Barcodes" runat="server" Width="156px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 23px" >
                    <strong>&nbsp;No. Kenderaan</strong></td>
                <td style="height: 23px; font-weight: bold;" >
                    <asp:TextBox ID="noKenderaan" runat="server" Width="93px" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px; font-weight: bold;" >
                &nbsp;Jenis Urusan</td>
                <td style="height: 23px; font-weight: bold;" >
                    <asp:DropDownList ID="JenisUrusan" runat="server" DataSourceID="Urusan" DataTextField="Nama_Urusan"
                        DataValueField="Kod_Urusan">
                    </asp:DropDownList></td>
            </tr>
            <tr style="font-weight: bold">
                <td >
                    &nbsp;Cara Pengangkutan</td>
                <td >
                    <asp:DropDownList ID="cara_pengangkutan" runat="server" DataSourceID="JenisPengangkutan" DataTextField="Nama_Pengangkutan" DataValueField="Kod_Pengangkutan">
                    </asp:DropDownList>
                </td>
                <td >
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 17px">
                    <hr />
                </td>
            </tr>
            
        </table>
    <table style="width: 100%">
        <tr>
            <td colspan="4" style="height: 21px">
                <strong>&nbsp;Maklumat Pengangkutan Bagi Pindahan Barangan</strong></td>
        </tr>
        <tr>
            <td style="height: 21px">
                &nbsp;<strong>Nama Pemandu</strong></td>
            <td style="height: 21px">
                     <asp:TextBox ID="nama_pemandu_pindahan" runat="server" Width="90%"></asp:TextBox></td>
            <td style="height: 21px">
                <strong>No. Kenderaan</strong></td>
            <td style="height: 21px">
                <asp:TextBox ID="no_kenderaan_pindahan" runat="server" Width="93px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 21px"><hr /></td>
        </tr>
        <tr>
            <td style="height: 21px;" >
                <strong>&nbsp;Sumber Bekalan</strong></td>
            <td style="height: 21px" >
                <asp:DropDownList ID="Bekalan" runat="server" DataSourceID="SumberBekalan" DataTextField="Nama_Negara" DataValueField="Kod_Negara">
              </asp:DropDownList></td>
            <td style="height: 21px" >
                <strong>Kompleks/PPI</strong></td>
            <td style="height: 21px">
                <strong><asp:DropDownList ID="KompleksPPI" runat="server" DataSourceID="PPI" DataTextField="Nama_PPI" DataValueField="Kod_PPI">
                    </asp:DropDownList></strong></td>
        </tr>
        <tr>
            <td style="height: 21px;" >
                <strong>&nbsp;Pengimport</strong></td>
            <td style="height: 21px" >
                <asp:TextBox ID="searchKodImporter" runat="server" Width="266px"></asp:TextBox><asp:HiddenField
                    ID="Importer" runat="server" />
            </td>
            <td style="height: 21px" >
                <strong>Pengeksport</strong></td>
            <td style="height: 21px">
                <asp:TextBox ID="searchKodExporter" runat="server" Width="266px"></asp:TextBox><asp:HiddenField
                    ID="Exporter" runat="server" />
            </td>
        </tr>        
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>        
         <div class="scrollingdatagrid" style="width:100%;height:110px;">
          <table id="tblGridImporter" border="0" style="width: 100%;">
            <thead>
             <tr>
                 <th style="background-color:#f1f1f1; width:7%">
                     No.</th>
                 <th style="background-color:#f1f1f1; width:20%; height:22px">
                     Pengimport</th>
                 <th style="background-color:#f1f1f1; width:16%; height:22px">
                     No. Lesen</th>
                 <th style="background-color:#f1f1f1; width:10%; height:22px">
                     Tarikh Luput</th>
                 <th style="background-color:#f1f1f1; width:20%; height:22px">
                     Pengeksport</th>
                 <th style="background-color:#f1f1f1; width:10%; height:22px">
                     Kod Pengimport</th>
                 <th style="background-color:#f1f1f1; width:15px; height:22px">
                     Nama Pemandu</th> 
                 <th style="background-color:#f1f1f1; width:15px; height:22px">
                     No. Kenderaan</th>    
             </tr>
             </thead>
             <tbody>
             </tbody>           
          </table></div><table id="Table1" border="0" style="width: 100%;">
              <tr>
                  <td style="background-color:#f1f1f1; width:7%; color: #f1f1f1;">
                      No.</td>
                  <td style="background-color:#f1f1f1; width:20%; height:22px; color: #f1f1f1;">
                      Pengimport</td>
                  <td style="background-color:#f1f1f1; width:16%; height:22px; color: #f1f1f1;">
                      No. Lesen</td>
                  <td style="background-color:#f1f1f1; width:10%; height:22px; color: #f1f1f1;">
                      Tarikh Luput</td>
                  <td style="background-color:#f1f1f1; width:20%; height:22px; color: #f1f1f1;">
                      Pengeksport</td>
                  <td style="background-color:#f1f1f1; width:10%; height:22px; color: #f1f1f1;">
                      Kod Pengimport</td>
                  <td style="background-color:#f1f1f1; width:15%; height:22px; color: #f1f1f1;">
                      Nama Pemandu</td>
                  <td style="background-color:#f1f1f1; width:15%; height:22px; color: #f1f1f1;">
                      No. Kenderaan</td>    
              </tr>
          </table>
         <br />
         <input id="Button3" type="button" value="Tambah" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" onclick="AddArray();refreshTableGridIkan();"  />
          <input id="Button4" type="button" value="Batal" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1; width: 61px;" onclick="RemoveArray()" /><div><asp:HiddenField ID="arrayVal" runat="server" /><asp:HiddenField ID="arrayFishVal" runat="server" />
                <asp:HiddenField ID="currentImporter" runat="server" />
              <asp:HiddenField ID="serverDate" runat="server" />
              <asp:HiddenField ID="Invois_Id" runat="server" />
              <asp:HiddenField ID="status" runat="server" />
              <asp:HiddenField ID="OnlineSend_By" runat="server" />
              <asp:HiddenField ID="ju" runat="server" Value="0" />
              <asp:HiddenField ID="kpk" runat="server" Value="0" />
              <asp:HiddenField ID="kpb" runat="server" Value="0" />
              <asp:HiddenField ID="ke" runat="server" Value="0" />
              <asp:HiddenField ID="kq" runat="server" Value="0" />
              <asp:HiddenField ID="kod_id" runat="server" />
              <asp:HiddenField ID="CajMasuk" runat="server" Value="0" />
              <asp:HiddenField ID="printer_name" runat="server" />
              <asp:HiddenField ID="JenisUrusanLama" runat="server" />
              &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
              &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
              <br />
          </div>
    
        <table style="width: 100%; border-top-width: thin; border-left-width: thin; border-bottom-width: thin; border-right-width: thin;" border="0">
            <tr>
                <td style="width: 55px">
                    <strong>Kod BKH</strong></td>
                <td style="width:20%;">
                    <strong>Nama</strong></td>
                <td style="width: 58px">
                    <div style="text-align:center">
                        <strong>Kod 8 Digit</strong></div></td>
                <td style="width:15%">
                    <div style="text-align:center">
                        <strong>Destinasi</strong></div></td>
                <td style="height: 15px">
                  <span style="color: black"><strong>Peti Kecil</strong></span></td>
                <td style="height: 15px; text-align: center; color: black;">
                  <strong>Kuantiti Kecil (kg)</strong></td>
                <td style="height: 15px">
                  <strong>Peti Besar</strong></td>
                <td style="height: 15px; text-align: center;" >
                  <strong>Kuantiti Besar(kg)</strong></td>
				 <td style="width: 27px" >
                    <div style="text-align:center">
                        <strong>Pek</strong></div></td>
				 <td >
                    <div style="text-align:center">
                        <strong>Ekor</strong></div></td>	
					 <td  style="width: 68px; text-align: center;">
                         <strong>Kadar (RM/KG)</strong></td>
                <td  style="width: 68px; text-align: center">
                    <strong>Nilai (RM)</strong></td>
            </tr>            
            <tr>
                <td style="height: 23px; width: 55px;" >
                    <asp:TextBox ID="Kod_BKH" runat="server" Width="100%"></asp:TextBox></td>
                <td style="height: 23px;" >
                    <asp:TextBox ID="Nama_Ikan" runat="server" Width="100%"></asp:TextBox></td>
                <td style="height: 23px; width: 58px;" >
                    <asp:TextBox ID="Kod8_Digit" runat="server" Width="100%"></asp:TextBox></td>
                <td style="height: 23px" >
                    <asp:DropDownList ID="Destination" runat="server" DataSourceID="Destinasi" DataTextField="Nama_Pasar"
                        DataValueField="Kod_Pasar" Width="100%">
                    </asp:DropDownList></td>
                <td style="height: 23px" ><asp:TextBox ID="txtPetiKecil" runat="server" Width="100%"></asp:TextBox></td>
                 <td style="height: 23px" ><asp:TextBox ID="txtKuantitiKecil" runat="server" Width="100%"></asp:TextBox></td>
                 <td style="height: 23px" ><asp:TextBox ID="txtPetiBesar" runat="server" Width="100%"></asp:TextBox></td>
                 <td style="height: 23px" ><asp:TextBox ID="txtKuantitiBesar" runat="server" Width="100%"></asp:TextBox></td>
                 <td style="height: 23px; width: 27px;" >
                     <asp:TextBox ID="txtPek" runat="server" Width="100%"></asp:TextBox></td>
                <td style="height: 23px;" >
                    <asp:TextBox ID="txtEkor" runat="server" Width="100%"></asp:TextBox></td>
                <td style="height: 23px; width: 68px;">
                    <asp:TextBox ID="txtNilai" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width: 68px; height: 23px">
                    <asp:TextBox ID="txtJumlahNilai" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
           
        </table>  
         
        
     <div class="scrollingdatagrid" style="width:100%;height:110px; left: 0px; top: 0px;">
        <table id="tblGrid" border="0" style="width: 100%;">
            <thead>
            <tr>
                <th style="background-color:#f1f1f1">
                    Kod BKH</th>
                <th  style="background-color:#f1f1f1;width: 20%">
                    Nama</th>
                <th style=" background-color:#f1f1f1">
                    <div style="text-align:center">
                        Kod 8 Digit</div>
                </th>
                <th style="background-color:#f1f1f1;width: 15%;">
                    <div style="text-align:center">
                        <span style="color: black">Destinasi</span></div>
                </th>
                <th style="background-color:#f1f1f1;">
                  <span style="color: black"><strong>Peti Kecil</strong></span></th>
              <th style="background-color:#f1f1f1;">
                  <strong>Kuantiti Kecil (kg)</strong></th>
              <th style="background-color:#f1f1f1;">
                  <strong>Peti Besar</strong></th>
              <th style="background-color:#f1f1f1;" >
                  <strong>Kuantiti Besar(kg)</strong></th>
                <th style="background-color:#f1f1f1">
                    <div style=" text-align:center; color: black">
                        Pek</div>
                </th>
                <th style="background-color:#f1f1f1">
                    <div style=" text-align:center">
                        Ekor</div>
                </th>
                <th style="background-color:#f1f1f1;text-align: center">
                    Nilai (RM)</th>
            </tr>            
            </thead>
            <tbody>
            </tbody>
            </table>
            </div>
        <table border="0" style="width: 100%;">
            <tbody>
                 <tr>
                    <td rowspan="1" style=" background-color:#ffffcc; width : 289px" colspan="4">
                        <strong>
                    [CTRL]</strong> <span style="color: #0000ff"><strong>Senarai Ikan
                    <input id="Button1" type="button" value="Tambah" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" onclick="AddFishArray();"  /><input id="Button2" type="button" value="Batal" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1; width: 50px;" onclick="removeRow()" /></strong></span></td>
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
                    <td rowspan="1" style="background-color:#f1f1f1; width: 289px; color: #f1f1f1; height: 17px;" colspan="4">
                        Kod BKHNamaKod 8 Digit<div style="text-align:center">
                            <span style="color: #f1f1f1">Destinasi</span></div>
                    </td>
                    <td style="background-color:#f1f1f1; height: 17px; color: #f1f1f1;">
                        Kecil</td>
                    <td style="background-color:#f1f1f1; height: 17px; color: #f1f1f1;">
                        Kuantiti (kg)</td>
                    <td style="background-color:#f1f1f1; height: 17px; color: #f1f1f1;">
                        Besar</td>
                    <td style="background-color:#f1f1f1; height: 17px; color: #f1f1f1;">
                        Kuantiti(kg)</td>
                    <td rowspan="1" style="background-color:#f1f1f1; color: #f1f1f1; height: 17px">
                        <div style=" text-align:center; color: #f1f1f1">
                            Pek</div>
                    </td>
                    <td  rowspan="1" style="background-color:#f1f1f1; color: #f1f1f1; height: 17px">
                        <div style="text-align:center">
                            Ekor</div>
                    </td>
                    <td rowspan="1" style="background-color:#f1f1f1; color: #f1f1f1; height: 17px;">
                        Nilai (RM)</td>
                </tr>
               
            </tbody>
        </table>
        &nbsp;<strong>Jumlah Peti&nbsp; :&nbsp;</strong>
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="0" Width="82px"></asp:Label><br />
        &nbsp;
        <hr />
         <input id="Button6" onclick="newForm();" style="border-right: #333333 1px ridge;
             padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
             padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
             border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
             type="button" value="BARU" /><input
             id="Button9" onclick="openMasterSheet();" style="border-right: #333333 1px ridge;
             padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
             padding-bottom: 1px; border-left: #ffffff 1px ridge; width: 131px; color: #000000;
             padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
             background-color: #f1f1f1" type="button" value="PAPAR MASTERSHEET" /><asp:Button ID="Simpan" runat="server" Text="SIMPAN" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="return pastiKanData();" /><input
                 id="Button10" runat="server" disabled="disabled" onclick="printReport(1);" style="border-right: #333333 1px ridge;
                 padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                 padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                 border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                 type="button" value="CETAK SKPI" /><input id="Button5" runat="server" disabled="disabled"
                     onclick="printReport();;" style="border-right: #333333 1px ridge; padding-right: 1px;
                     border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                     border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                     font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
                     value="PAPAR CETAKKAN" />
         <input id="Button8" runat="server" disabled="disabled" onclick="showSenaraiprinter();"
             style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
             padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
             color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
             background-color: #f1f1f1" type="button" value="PILIH PRINTER" />
         <asp:Button ID="Keluar" runat="server" Text="KELUAR" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;"/><br />
         <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
             Visible="False" />
         <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
             Visible="False" />
         <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true"
             Visible="False" />
         <CR:CrystalReportViewer ID="CrystalReportViewer4" runat="server" AutoDataBind="true"
             Visible="False" />
         <CR:CrystalReportViewer ID="CrystalReportViewer5" runat="server" AutoDataBind="true"
             Visible="False" />
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                 &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp;
         &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                    
          
        <asp:SqlDataSource ID="JenisPengangkutan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Cara_Pengangkutan]) as Kod_Pengangkutan, [Nama_Cara_Pengangkutan] as [Nama_Pengangkutan]  FROM [CARA_PENGANGKUTAN]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SumberBekalan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Negara], [Nama_Negara] FROM [NEGARA]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="PPI" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_PPI], [Nama_PPI] FROM [PUSATKOMPLEK]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="Pengimport" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT     RTRIM(PENGIMPORT.Kod_Pengimport) +'|'+&#13;&#10;RTRIM(PENGIMPORT.No_Lesen) + '|'+ CAST(DAY(LESEN.Tarikh_Tamat) AS nvarchar(200)) &#13;&#10;                      + '/'+ case when MONTH(LESEN.Tarikh_Tamat) < 10 then '0'+cast(month(lesen.tarikh_tamat) as varchar(1)) else cast(month(lesen.tarikh_tamat) as varchar(2)) end   &#13;&#10;                      + '/' + CAST(YEAR(LESEN.Tarikh_Tamat) as nvarchar(4)) AS Val, &#13;&#10;                      LEFT(RTRIM(PENGIMPORT.Nama_Syarikat_Import),40) as [Nama_Syarikat_Import] &#13;&#10;FROM         PENGIMPORT INNER JOIN&#13;&#10;                      LESEN ON PENGIMPORT.No_Lesen = LESEN.No_Lesen">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Pengeksport" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Pengeksport], RTRIM([Nama_Pengeksport]) as [Nama_Syarikat_Eksport] FROM [PENGEKSPORT_THAILAND]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Destinasi" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Pasar]+'|'+[Nama_Pasar] as [Kod_Pasar], [Nama_Pasar] FROM [DESTINASI_PASAR] ORDER BY [Nama_Pasar]">
        </asp:SqlDataSource>
         &nbsp;<asp:SqlDataSource ID="Urusan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
             SelectCommand="SELECT [Kod_Urusan], [Nama_Urusan] FROM [JENIS_URUSAN] WHERE [Kod_Urusan] ='008' order by [Nama_Urusan] asc ">
         </asp:SqlDataSource>
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
    refreshTableGridIkan();
    //showHint2(document.all.arrayFishVal.value,"Load_ImporterFishInfo.aspx");
</script>   
</body>
</html>
