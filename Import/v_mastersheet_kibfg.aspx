<%@ Page Language="VB" AutoEventWireup="false" CodeFile="v_mastersheet.aspx.vb" Inherits="Import_v_mastersheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />    
</head>
<script language="javascript" type="text/javascript">

// ADDED BY ZURAINI
function centPlace(num)
{
 num="" + num;
 d=num.split('.');
 c="0." + d[1];
 c=parseFloat(c);
 cent=Math.round(c * 100);
 cent="" + cent;
 if(cent.length==1) cent="0" + cent;
 v=d[0] + "." + cent;
 return v;
}
// END CODED

 

var chargeFound=0;


var arrKodDestNegeri = new Array();
var arrNamaNegeri = new Array();

var arrImporterCajLuarBiasa = new Array();
/*
var kategori_ikan_g = new Array();
var jenis_urusan_g = new Array();
var kpk_g = new Array();
var kpb_g = new Array();
var ke_g = new Array();
var kqty_g = new Array();
var id_g = new Array();
*/

/*
var company_c = new Array();
var kategori_ikan_c = new Array();
var jenis_urusan_c = new Array();
var kpk_c = new Array();
var kpb_c = new Array();
var ke_c = new Array();
var kqty_c = new Array();
var id_c = new Array();
*/

var searchKodImporter = new Array();
var KodImporter = new Array();
var NamaImporter = new Array();

/* var searchKodExporter = new Array();
var KodExporter = new Array();
var NamaExporter = new Array();
*/

var KodBKHNew = new Array();
var KodIkan = new Array();
var NamaIkan = new Array();
var KodBKH = new Array();
var MKodKategoriIkan = new Array();
var txtNilaiKadar = new Array();

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
    
    '   cntArray = 0
    '   sqlText = "SELECT Rtrim([Kod_Pengeksport]) as val, [Kod_Pengeksport], RTRIM([Nama_Pengeksport]) as [Nama_Syarikat_Eksport] FROM [PENGEKSPORT_THAILAND]"
    '   jsReader = opClass.DataReader(sqlText)
    '   Response.Write("<script>")
    '   Do While jsReader.Read
    ' Response.Write("searchKodExporter[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
    ' Response.Write("KodExporter[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
    ' Response.Write("NamaExporter[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf & vbCrLf)
    ' cntArray = cntArray + 1
    ' Loop
    ' Response.Write("</script>")
    ' jsReader.Close()
    ' jsReader = Nothing
   
    
    'Load Kod Negeri
    cntArray = 0
    sqlText = "SELECT RTRIM(Kod_Negeri) as kodNegeri, Nama_Negeri " & _
              "FROM NEGERI WHERE (status ='yes')"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("arrKodDestNegeri[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("arrNamaNegeri[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
 %>
 
<script language="javascript" type="text/javascript">
 
 var totkdrkecil = new Array();
 var totkdrbesar = new Array();
 var totkdrberat = new Array();
 var totkdrekor = new Array();
 
 var totalpetikecil = new Array();
 var totalpetibesar = new Array();
 
 var ArrayDestinationKod = new Array();
 var ArrayDestinationName = new Array();
 var tbl1_destinasi = new Array();
 var destinasi_totalpeti = new Array();
 var destinasi_totalkg = new Array();
 var destinasi_totalekor = new Array();
 var destinasi_totalnilai = new Array();
 var destinasi_totalpengimport = new Array();
 
    
 var tbl1_kodimporter = new Array();
 var totalpeti = new Array();
 var totalkilo = new Array();
 var totalekor = new Array();
 var totalcaj = new Array();
 var namaPengimport = new Array();
 var noLesen = new Array();
    
 function getIndexArray(strKodImporter)
 {
    var idx=-1;
    for(i=0;i<tbl1_kodimporter.length;i++)
    {
        if (strKodImporter==tbl1_kodimporter[i])
        {
            idx=i;
            break;
        }
    }   
    //alert(idx);
    return idx;
 }   
 


 function getIndexArrayNegeri(strKodNegeri)
 {
    var strSearchNegeri = strKodNegeri.charAt(0)+strKodNegeri.charAt(1);
    //alert("strSearchNegeri"+strSearchNegeri);
    
    var idx_neg=-1;
    for(ji=0;ji<arrKodDestNegeri.length;ji++)
    {
        //alert(strSearchNegeri+"=="+arrKodDestNegeri[ji]);
        if (strSearchNegeri==arrKodDestNegeri[ji])
        {
            idx_neg=ji;
            break;
        }
    }   
    //alert(idx);
    return idx_neg;
 }   
 
 function getIndexArrayDest(strKodDestination)
 {
    var idx_dest=-1;
    for(x=0;x<tbl1_destinasi.length;x++)
    {
        if (strKodDestination==tbl1_destinasi[x])
        {
            idx_dest=x;
            break;
        }
    }   
    //alert(idx);
    return idx_dest;
 }  
 
 
 function getIndexArrayDestiny(strDestination)
 {
    var idx_destiny=-1;
    for(y=0;y<ArrayDestinationKod.length;y++)
    {
        if (strDestination==ArrayDestinationKod[y])
        {
            idx_destiny=y;
            break;
        }
    }   
    //alert(idx);
    return idx_destiny;
 }  

 var totalcajbiasa=0;
 var totalcajluarbiasa=0;
    
 
 function processImporterCajLuarBiasa(strFind)
 {
    var foundStatus=0;
    var i;
    for(i=0;i<arrImporterCajLuarBiasa.length;i++)
    {
        //alert(strFind+"=="+arrImporterCajLuarBiasa[i]);
        
        if (strFind==arrImporterCajLuarBiasa[i])
        {
            foundStatus=1;
            break;
        }         
    }
    
    if (foundStatus==0)
    {
        if (arrImporterCajLuarBiasa.length>=0)
        {
            arrImporterCajLuarBiasa[arrImporterCajLuarBiasa.length]=strFind;
        }
        else
        {
            arrImporterCajLuarBiasa[0]=strFind;
        }
    }
 }
 
 function findImporterCajLuarBiasa(strFind)
 {
    var foundStatusC=0;
    var x;
    for(x=0;x<arrImporterCajLuarBiasa.length;x++)
    {
        //alert(strFind+"=="+arrImporterCajLuarBiasa[x]);
        if (strFind==arrImporterCajLuarBiasa[x])
        {
            foundStatusC=1;
            break;
        }            
    }
    return foundStatusC;
    
 }
 
 
 function processTable1()
 {
    var myUrusan = window.opener.document.all.JenisUrusan;
    
    //var myBarangan = myUrusan.replace('Import','');    
    document.all.urusan.innerHTML = myUrusan.options[myUrusan.selectedIndex].text;
    document.all.kenderaan.innerHTML = window.opener.document.all.noKenderaan.value;
    document.all.agen.innerHTML = window.opener.document.all.NamaAgen.value;
    document.all.barangan.innerHTML = "Ikan";
    document.all.cajKenderaan.innerHTML = centPlace(window.opener.document.all.CajMasuk.value);
    
    
    var totalRows;
    
    if (document.all("tblGrid1").rows.length==undefined)
    {
        totalRows=-1;
    }
    else
    {
        totalRows=document.all("tblGrid1").rows.length;
    }    
    
    //clear tables rows for current importer fish declaration    
    var i=0;
    for(i=2;i<totalRows;i++)
    {
        document.all("tblGrid1").deleteRow(2);
    }        
    
    
    //Load fish declaration information for currentImporter    
    var strIkanInfo = window.opener.document.all.arrayFishVal.value;
    // alert(strIkanInfo);
    var arrIkanInfo = strIkanInfo.split("~");   
    //alert(arrIkanInfo.length);    
    for (i=0;i<arrIkanInfo.length; i++)
    {
        var arrIkanInfoDetails  = arrIkanInfo[i].split("`");
        
        if (arrIkanInfo[i].replace(/\s+$/,"")!="")
        {
            //alert(arrIkanInfo[i]);
            
            var loc_index;// = -1;
            loc_index = getIndexArray(arrIkanInfoDetails[0]);
        
            //Kira Jumlah Caj 
            if (arrIkanInfoDetails[17]>=10000)        
            {      
                if (arrIkanInfoDetails[18].replace(/\s+$/,"")!="")
                {
                    totalcajluarbiasa=parseFloat(totalcajluarbiasa) + parseFloat(arrIkanInfoDetails[18]);
                }
                processImporterCajLuarBiasa(arrIkanInfoDetails[0].replace(/\s+$/,""))
            }
            else
            {
                if (arrIkanInfoDetails[18].replace(/\s+$/,"")!="")
                {
                    totalcajbiasa = parseFloat(totalcajbiasa) + parseFloat(arrIkanInfoDetails[18]);
                }
            }
        
            var tmpPetiBesar=0;
            var tmpPetiKecil=0;
            var tmpKilo=0;
            var tmpEkor=0;
            var tmpCaj=0;
        
        /*  if (isNaN(arrIkanInfoDetails[5])=false)
            {
                tmpPetiBesar = arrIkanInfoDetails[5];    
            }
        
            if (isNaN(arrIkanInfoDetails[7])=false)
            {
                tmpPetiKecil=arrIkanInfoDetails[7];
            }
        
            if (isNaN(arrIkanInfoDetails[6])=false)
            {
                tmpKilo=arrIkanInfoDetails[6];
            }
       
            if (isNaN(arrIkanInfoDetails[9])=false)
            {
                tmpEkor=arrIkanInfoDetails[9];
            }
        */        
        
            //alert("check loc index="+ loc_index);
            if (loc_index>-1)
            {            
                totalpeti[loc_index] = parseFloat(totalpeti[loc_index]) + parseFloat(arrIkanInfoDetails[5]) + parseFloat(arrIkanInfoDetails[7]); 
                totalkilo[loc_index] = parseFloat(totalkilo[loc_index]) + parseFloat(arrIkanInfoDetails[6]) + parseFloat(arrIkanInfoDetails[8]);        
                totalekor[loc_index] = parseFloat(totalekor[loc_index]) + parseFloat(arrIkanInfoDetails[9]);         
                totalcaj[loc_index] = parseFloat(totalcaj[loc_index]) + parseFloat(arrIkanInfoDetails[18]);         
            
                totalpetikecil[loc_index] = parseFloat(totalpetikecil[loc_index]) + parseFloat(arrIkanInfoDetails[5]); 
                totalpetibesar[loc_index] = parseFloat(totalpetibesar[loc_index]) + parseFloat(arrIkanInfoDetails[7]); 
            
                if (arrIkanInfoDetails[13].replace(/\s+$/,"")!="" && parseFloat(arrIkanInfoDetails[13]) > 0)
                {
                    totkdrkecil[loc_index]= arrIkanInfoDetails[13];
                }
                if (arrIkanInfoDetails[14].replace(/\s+$/,"")!="" && parseFloat(arrIkanInfoDetails[14]) > 0)
                {
                    totkdrbesar[loc_index]= arrIkanInfoDetails[14];
                }
                if (arrIkanInfoDetails[15].replace(/\s+$/,"")!="" && parseFloat(arrIkanInfoDetails[15]) > 0)
                {
                    totkdrberat[loc_index]= arrIkanInfoDetails[15];
                }    
                if (arrIkanInfoDetails[16].replace(/\s+$/,"")!="" && parseFloat(arrIkanInfoDetails[16]) > 0)
                {
                    totkdrekor[loc_index]= arrIkanInfoDetails[16];
                }
            
                // alert(arrIkanInfoDetails[0]);
                // alert(totalcaj[loc_index]);
                        
            }
            else
            {
                
                loc_index=tbl1_kodimporter.length-1 + 1;
                //alert("tambah loc index="+ loc_index);            
                totalpeti[loc_index] = parseFloat(arrIkanInfoDetails[5]) + parseFloat(arrIkanInfoDetails[7]); 
                totalkilo[loc_index] = parseFloat(arrIkanInfoDetails[6]) + parseFloat(arrIkanInfoDetails[8]);        
                totalekor[loc_index] = parseFloat(arrIkanInfoDetails[9]);         
                tbl1_kodimporter[loc_index] = arrIkanInfoDetails[0];
                totalcaj[loc_index] = parseFloat(arrIkanInfoDetails[18]);         
                //noLesen[loc_index] = arrIkanInfoDetails[2];            
                totalpetikecil[loc_index] = parseFloat(arrIkanInfoDetails[5]); 
                totalpetibesar[loc_index] = parseFloat(arrIkanInfoDetails[7]);             
            
                totkdrkecil[loc_index]= arrIkanInfoDetails[13];
                totkdrbesar[loc_index]= arrIkanInfoDetails[14];
                totkdrberat[loc_index]= arrIkanInfoDetails[15];
                totkdrekor[loc_index]= arrIkanInfoDetails[16];
            }
        
            //Get Selected Destination
            var destinasi_loc_idx;// = -1;
            var strSearchDest = arrIkanInfoDetails[4];
        
            destinasi_loc_idx = getIndexArrayDestiny(strSearchDest);
        
        
            //alert(ArrayDestinationKod.length);
            if (destinasi_loc_idx==-1)
            {
                //alert(strSearchDest);
                destinasi_loc_idx = ArrayDestinationKod.length-1 + 1;
                //alert("destinasi_loc_idx="+ destinasi_loc_idx);          
                //var test =  strSearchDest.replace(/\s+$/,"");

                //alert("test"+ test);
                ArrayDestinationKod[destinasi_loc_idx] = strSearchDest;
                ArrayDestinationName[destinasi_loc_idx] = arrIkanInfoDetails[12];           
            }
        
        
            //Agihan Mengikut Pasaran Info Grouping
            var loc_index_dest;// = -1;
            var strDestinationCodeArray = arrIkanInfoDetails[4] +"|"+ arrIkanInfoDetails[0];
            loc_index_dest = getIndexArrayDest(strDestinationCodeArray);
        
            // alert("loc_index_dest="+loc_index_dest);
        
            if (loc_index_dest>-1)
            {
                destinasi_totalpeti[loc_index_dest] = parseFloat(destinasi_totalpeti[loc_index_dest]) + parseFloat(arrIkanInfoDetails[5]) + parseFloat(arrIkanInfoDetails[7]); 
                destinasi_totalkg[loc_index_dest] = parseFloat(destinasi_totalkg[loc_index_dest]) + parseFloat(arrIkanInfoDetails[6]) + parseFloat(arrIkanInfoDetails[8]);        
                destinasi_totalekor[loc_index_dest] = parseFloat(totalekor[loc_index_dest]) + parseFloat(arrIkanInfoDetails[9]);         
                destinasi_totalnilai[loc_index_dest] = parseFloat(destinasi_totalnilai[loc_index_dest]) + parseFloat(arrIkanInfoDetails[11]);         
            }
            else
            {
                loc_index_dest = tbl1_destinasi.length-1 + 1;
                tbl1_destinasi[loc_index_dest] = strDestinationCodeArray;
                destinasi_totalpeti[loc_index_dest] = parseFloat(arrIkanInfoDetails[5]) + parseFloat(arrIkanInfoDetails[7]); 
                destinasi_totalkg[loc_index_dest] =  parseFloat(arrIkanInfoDetails[6]) + parseFloat(arrIkanInfoDetails[8]);        
                destinasi_totalekor[loc_index_dest] = parseFloat(totalekor[loc_index_dest]) + parseFloat(arrIkanInfoDetails[9]);         
                destinasi_totalnilai[loc_index_dest] = parseFloat(arrIkanInfoDetails[11]);                    
            }            
      
        }//end if (arrIkanInfo[i].replace(/\s+$/,"")!="")
        
     }//end for (i=0;i<arrIkanInfo.length; i++) 
     
      
        
        
     //alert("totalpeti="+ totalpeti[0]);                      
     fillUpRec_tblGrid1();
     fillUpRec_tblGrid2();
             
                    	
 }        
	     
function fillUpRec_tblGrid1()        
{
    
    var jumlahpeti = 0;
    var jumlahkg = 0;
    var jumlahcaj = 0;
    var jumlahekor = 0;
    var myTotalCajLuarBiasa=0;
       
    for(i=0;i<tbl1_kodimporter.length;i++)
    {
        
       /*
        jumlahpeti= parseFloat(jumlahpeti) + parseFloat(totalpeti[i]);
        jumlahkg= parseFloat(jumlahkg) + parseFloat(totalkilo[i]);
        jumlahcaj= parseFloat(jumlahcaj) + parseFloat(totalcaj[i]);
        jumlahekor = parseFloat(jumlahekor) + + parseFloat(totalekor[i]);               
       */
        
        var checkImporterCajStatus=findImporterCajLuarBiasa(tbl1_kodimporter[i]);
        //alert(checkImporterCajStatus);
        var jenisCajLabel="";
        if (checkImporterCajStatus==1)
        {
            jenisCajLabel="Pengurangan";
        }
        else
        {
            jenisCajLabel="Biasa";
            jumlahpeti= parseFloat(jumlahpeti) + parseFloat(totalpeti[i]);
            jumlahkg= parseFloat(jumlahkg) + parseFloat(totalkilo[i]);
            jumlahcaj= parseFloat(jumlahcaj) + parseFloat(totalcaj[i]);
            jumlahekor = parseFloat(jumlahekor) + + parseFloat(totalekor[i]);       
        }
       
        
        var importerDetails = showFilteredImporter(tbl1_kodimporter[i]);
        var arrImporterDetails = importerDetails.split("|");
       // var cnt=i+1;
        
        //add a row to the rows collection and get a reference to the newly added row
        var cnt=0;
        if (checkImporterCajStatus!=1)
        {
        cnt=cnt+1;
        var newRow = document.all("tblGrid1").insertRow();	
        var oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:center;'>"+ cnt +"</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:left;'>"+ arrImporterDetails[1]; +"</span>"; //noLesen[i];	
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:left;'>"+ arrImporterDetails[0]; +"</span>"; //tbl1_kodimporter[i];//nameImporter[i];//"test1";// //namaPengimport[i];
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ totalpeti[i]; + "</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ totalkilo[i]; + "</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ totalekor[i]; + "</span>";
        
        oCell = newRow.insertCell();      
        
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ centPlace(totalcaj[i]); + "</span>";     
        
        
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "Ikan";               
        
        }
        
        //add a row to the rows collection and get a reference to the newly added row into tblGrid3
        var cnt2x=0;
        if (checkImporterCajStatus==1)
        {
        cnt2x=cnt2x+1;
        var newRow3 = document.all("tblGrid3").insertRow();	
        var oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:center;'>"+ cnt2x +"</span>";    
                
        oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:left;'>"+ arrImporterDetails[0] +"</span>"; 
        
        oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ totalpetibesar[i] + " x "+ totkdrbesar[i] +"</span>";
        
        oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ totalpetikecil[i] + "x" + totkdrkecil[i] + "</span>";
        
        oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ totalkilo[i] + " x "+ totkdrberat[i] + "</span>";
        
        oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ totalekor[i] + " x "+ totkdrekor[i] + "</span>";
        
        oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ centPlace(totalcaj[i]) + "</span>";               
        
        oCell3 = newRow3.insertCell();
        oCell3.innerHTML = "<span style='display:inline-block;width:100%;text-align:center;'>"+ jenisCajLabel + "</span>";               
        myTotalCajLuarBiasa = parseFloat(totalcaj[i])+parseFloat(myTotalCajLuarBiasa);
        }
        
    }//end for
    
    document.all.jp.innerHTML=jumlahpeti;
    document.all.jkg.innerHTML=jumlahkg;
    document.all.jcaj.innerHTML=centPlace(jumlahcaj);
    document.all.jekor.innerHTML=jumlahekor;
    //document.all.totalcajsemua.innerHTML=centPlace(parseFloat(window.opener.document.all.CajMasuk.value) + parseFloat(jumlahcaj));
    document.all.CB.innerHTML=jumlahcaj;//totalcajbiasa;
    document.all.CP.innerHTML=centPlace(myTotalCajLuarBiasa);//centPlace(totalcajluarbiasa);
    document.all.totalcajsemua.innerHTML=centPlace(parseFloat(window.opener.document.all.CajMasuk.value) + parseFloat(jumlahcaj) + parseFloat(myTotalCajLuarBiasa));
}	            

function fillUpRec_tblGrid2()        
{             
    
    var cntBil=0;
    //alert("ArrayDestinationKod="+ ArrayDestinationKod.length);
    var semuapengimport=0;
    var semuapeti=0;
    var semuakg=0;
    var semuaekor=0;
    var semuanilai=0;       
        
    for(mz=0;mz<ArrayDestinationKod.length;mz++)   
    {   
        cntBil=cntBil+1;         
        var jumlahpetid = 0;
        var jumlahkgd = 0;
        var jumlahnilaid = 0;
        var jumlahekord = 0;
        var cntImporter = 0;
        
        //alert("tbl1_destinasi="+ tbl1_destinasi.length);
        for(z=0;z<tbl1_destinasi.length-1;z++)
        {
            var strTmp = tbl1_destinasi[z];
            var ArrStrTmp = strTmp.split("|");        
            
           // alert(mz);
            var strComp=ArrayDestinationKod[mz].replace(/\s+$/,"");            
            
            if (ArrStrTmp[0].replace(/\s+$/,"")==strComp)
            {   
                //alert(strComp +"=="+ ArrStrTmp[0]);  
                                                                                    
                jumlahpetid= parseFloat(jumlahpetid) + parseFloat(destinasi_totalpeti[z]);                                       
                jumlahkgd= parseFloat(jumlahkgd) + parseFloat(destinasi_totalkg[z]);
                jumlahnilaid= parseFloat(jumlahnilaid) + parseFloat(destinasi_totalnilai[z]);
                jumlahekord = parseFloat(jumlahekord) + parseFloat(destinasi_totalekor[z]);              
                cntImporter=cntImporter+1;                                
            }   
        }//end for(z=0;z<tbl1_destinasi.length-1;z++)       
         
        if (isNaN(jumlahpetid))
        {
           jumlahpetid=0;
        }
        
        if (isNaN(jumlahkgd))
        {
           jumlahkgd=0;
        }
        
        if (isNaN(jumlahnilaid))
        {
           jumlahnilaid=0;
        }
        
        if (isNaN(jumlahekord))
        {
           jumlahekord=0;
        }
       
    
        semuapengimport = parseFloat(semuapengimport) + parseFloat(cntImporter);
        // alert("semuapengimport="+semuapengimport);    
        
        semuapeti=parseFloat(semuapeti) + parseFloat(jumlahpetid);
        // alert("semuapeti="+semuapeti);
            
        semuakg=parseFloat(semuakg) + parseFloat(jumlahkgd);
        // alert("semuakg="+semuakg);   
        
        semuaekor=parseFloat(semuaekor) + parseFloat(jumlahekord);
        // alert("semuaekor="+semuaekor); 
        
        semuanilai=parseFloat(semuanilai) + parseFloat(jumlahnilaid);
        // alert("semuanilai="+semuanilai);         
       
        document.all.bi.innerHTML=semuapengimport;    
        document.all.bp.innerHTML=semuapeti;
        document.all.bkg.innerHTML=semuakg;
        document.all.bekor.innerHTML=semuaekor;
        document.all.brm.innerHTML=semuanilai;
        
        var strNegeriName="";
        var indexNegeri=getIndexArrayNegeri(ArrayDestinationKod[mz].replace(/\s+$/,""));
        //alert(indexNegeri);
        if (indexNegeri>-1)
        {
            strNegeriName = arrNamaNegeri[indexNegeri];
        }
       
        //alert("masukStrcmp="+jumlahpetid);
        
        //add a row to the rows collection and get a reference to the newly added row
        var newRow = document.all("tblGrid2").insertRow();	
        var oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:center;'>"+ cntBil +"</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:left;'>"+ ArrayDestinationName[mz] +"</span>"; //noLesen[i];	
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:left;'>"+ strNegeriName +"</span>"; //tbl1_kodimporter[i];//nameImporter[i];//"test1";// //namaPengimport[i];
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ cntImporter + "</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ jumlahpetid + "</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ jumlahkgd + "</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ jumlahekord + "</span>";
        
        oCell = newRow.insertCell();
        oCell.innerHTML = "<span style='display:inline-block;width:100%;text-align:right;'>"+ jumlahnilaid + "</span>";                       
            
    }//end for(mz=0;mz<ArrayDestinationKod.length;mz++)    
    
}	   

                  
function showFilteredImporter(strKodImporter)
{  
    var searchItem =strKodImporter;
    var foundImporter="";
    if (searchItem !="") 
    {  
       for (m=0;m<searchKodImporter.length;m++)
       {
           //alert(searchItem +"=="+ searchKodImporter[i]);
           if (searchItem==searchKodImporter[m])
            {              
             //alert("found="+NamaImporter[m]); 
             var strTemp=KodImporter[m];
             var leseninfo = strTemp.split("|");
             foundImporter=NamaImporter[m] +"|"+ leseninfo[1];   
             break;
            }    
       }//end next
    }    
    return foundImporter;
}

/*
function showFilteredExporter()
{

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
                 	           
*/
   

</script>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table style="width: 100%">
            <tr>
                <td style="height: 15px; font-weight:bold; width: 180px;" >
                    NO. KENDERAAN</td>
                <td style="height: 15px; font-weight:bold;">
                    :
                    <asp:Label ID="kenderaan" runat="server" Width="95%"></asp:Label></td>
                <td style="height: 15px; font-weight:bold;" >
                    URUSAN</td>
                <td style="height: 15px; font-weight:bold;" >
                    :
                    <asp:Label ID="urusan" runat="server" Width="95%"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 15px; font-weight:bold; width: 180px;">
                    NO. AGEN PENGANGKUTAN</td>
                <td style="height: 15px; font-weight:bold;">
                    :
                    <asp:Label ID="agen" runat="server" Width="95%"></asp:Label></td>
                <td style="height: 15px; font-weight:bold;">
                    BARANGAN</td>
                <td style="height: 15px; font-weight:bold;">
                    :
                    <asp:Label ID="barangan" runat="server" Width="95%"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 180px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    
    </div>
        <strong><span style="text-decoration: underline">
            <br />
            CAJ PERKHIDMATAN IKAN (BIASA)<br />
        </span></strong>
        <br />
        <table id="tblGrid1" border="0" style="border-right: gray thin groove; border-top: gray thin groove;
            border-left: gray thin groove; width: 100%">            
            <tr>
                <td style="width: 7%; height: 24px; background-color: #f1f1f1; text-align: center;">
                    BIL&nbsp;
                </td>
                <td style="width: 16%; height: 24px; background-color: #f1f1f1; text-align: left;">
                    &nbsp;NO. LESEN</td>
                <td style="width: 22%; height: 24px; background-color: #f1f1f1; text-align: left;">
                    &nbsp;PENGIMPORT</td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    PETI&nbsp;</td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    KG&nbsp;
                </td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    EKOR&nbsp;</td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    CAJ (RM)</td>
                <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: center;">
                    &nbsp;KUMPULAN</td>
            </tr>       
            
        </table><table id="Table1" border="0" style="border-right: gray thin groove; border-bottom: gray thin groove;
            border-left: gray thin groove; width: 100%">            
            <tr>
                <td style="height: 24px; background-color: #f1f1f1; text-align: left;" colspan="3">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Jumlah</td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    <asp:Label ID="jp" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    <asp:Label ID="jkg" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    <asp:Label ID="jekor" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    <asp:Label ID="jcaj" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: right;">
                    </td>
            </tr>       
            
        </table>
    </form>
    <br />
    <table style="width: 100%" id="TABLE2">
        <tr>
            <td style="height: 15px">
                <strong><span style="text-decoration: underline">PENGURANGAN CAJ PERKHIDMATAN IKAN </span>
                </strong>
            </td>
        </tr>
    </table>
    <br />
    <table id="tblGrid3" border="0" style="border-right: gray thin groove; border-top: gray thin groove;
            border-left: gray thin groove; width: 100%">
        <tr>
            <td style="width: 7%; height: 24px; background-color: #f1f1f1; text-align: center;">
                BIL&nbsp;
            </td>
            <td style="width: 22%; height: 24px; background-color: #f1f1f1; text-align: left;">
                &nbsp;PENGIMPORT</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
                PETI&nbsp;BESAR</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
                PETI KECIL</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
                BERAT</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
                EKOR</td>
            <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: right;">
                CAJ IKAN (RM)&nbsp;
            </td>
            <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: center">
                JENIS CAJ</td>
        </tr>
    </table>    
    <table id="Table3" border="0" style="border-right: gray thin groove; border-bottom: gray thin groove;
            border-left: gray thin groove; width: 100%">
        <tr>
            <td style="width: 7%; height: 24px; background-color: #f1f1f1; text-align: center;">
            </td>
            <td style="width: 22%; height: 24px; background-color: #f1f1f1; text-align: left;">
            </td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
            </td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
            </td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
            </td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
            </td>
            <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: center;"></td>
            <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: center">
            </td>
        </tr>
    </table><br /><table border="0" style="width: 100%">
        <tr>
            <td colspan="3" style="height: 24px; text-align: right">
                Caj Kenderaan Masuk :</td>
            <td style="width: 230px; height: 24px; text-align: left">
                &nbsp; &nbsp; RM<asp:Label ID="cajKenderaan" runat="server" Width="100px"></asp:Label></td>
            <td style="height: 24px; text-align: left">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;  text-align: right;" colspan="3">Jumlah Caj Biasa&nbsp;:
            </td>
            <td style="height: 24px;  text-align: left; width: 230px;">
                &nbsp;&nbsp; &nbsp; RM<asp:Label ID="CB" runat="server" Width="100px"></asp:Label></td>
            <td style="height: 24px; text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 24px;  text-align: right;">Jumlah Pengurangan Caj :</td>
            <td style="height: 24px;  text-align: left; width: 230px;">
                &nbsp;&nbsp; &nbsp; RM<asp:Label ID="CP" runat="server" Width="100px"></asp:Label></td>
            <td style="height: 24px; text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 24px; text-align: right">
                Jumlah Besar:</td>
            <td style="border-right: black 3px solid; border-top: black 1px dotted; border-left: black 1px dotted;
                width: 230px; border-bottom: black 3px solid">
                &nbsp; &nbsp; RM<asp:Label ID="totalcajsemua" runat="server" Width="150px"></asp:Label></td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <br />
   

    <table style="width: 100%">
        <tr>
            <td style="height: 15px">
                <strong><span style="text-decoration: underline">AGIHAN MENGIKUT PASARAN</span></strong></td>
        </tr>
    </table>
    <br />
    <table id="tblGrid2" border="0" style="border-right: gray thin groove; border-top: gray thin groove;
            border-left: gray thin groove; width: 100%">
        <tr>
            <td style="width: 7%; height: 24px; background-color: #f1f1f1; text-align: center;">
                BIL&nbsp;
            </td>
            <td style="width: 16%; height: 24px; background-color: #f1f1f1; text-align: left;">
                &nbsp;DESTINASI</td>
            <td style="width: 22%; height: 24px; background-color: #f1f1f1; text-align: left;">
                &nbsp;NEGERI</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: center;">
                BIL PENGIMPORT</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                PETI &nbsp;</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                KG &nbsp;</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                EKOR</td>
            <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: right;">
                &nbsp;RM&nbsp;</td>
        </tr>
    </table>
    <table border="0" style="border-right: gray thin groove; border-bottom: gray thin groove;
            border-left: gray thin groove; width: 100%">
        <tr>
            <td style="height: 24px; background-color: #f1f1f1; text-align: left;" colspan="3">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Jumlah</td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                <asp:Label ID="bi" runat="server" Width="100%"></asp:Label></td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                <asp:Label ID="bp" runat="server" Width="100%"></asp:Label></td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                <asp:Label ID="bkg" runat="server" Width="100%"></asp:Label></td>
            <td style="width: 10%; height: 24px; background-color: #f1f1f1; text-align: right;">
                <asp:Label ID="bekor" runat="server" Width="100%"></asp:Label></td>
            <td style="width: 15%; height: 24px; background-color: #f1f1f1; text-align: right;">
                <asp:Label ID="brm" runat="server" Width="100%"></asp:Label></td>
        </tr>
    </table>    
     
     <script language="javascript" type="text/javascript">    
    processTable1();    
    </script>
</body>
</html>
