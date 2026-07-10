<%@ Page Language="VB" AutoEventWireup="false" CodeFile="print_Pintu_Masuk.aspx.vb" Inherits="Pintu_Masuk_Pintu_Masuk_Utara" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]PINTU MASUK UTARA</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="windowfiles/dhtmlwindow.css" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<script type="text/javascript" src="windowfiles/dhtmlwindow.js">

/***********************************************
* DHTML Window Widget- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for legal use.
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/

</script>
<script type="text/javascript" language="javascript">

var agenwin;
//agenwin.onclose=function(){ //Run custom code when window is being closed (return false to cancel action):
//return window.confirm("Close window 1?")
//}

//agenwin.hide();

var KeyKodAgen = new Array();
var KodAgen = new Array();
var NamaAgen = new Array();

//document.onkeyup = KeyCheck;       

//function KeyCheck(e)
//{
//   var KeyID = (window.event) ? event.keyCode : e.keyCode;
//   
//   //alert(KeyID);
//   if (KeyID == 17)
//   {
//        
//        //reset details ikan value    
//        document.all.Kod_BKH.value="";
//        document.all.Nama_Ikan.value="";
//        document.all.Kod8_Digit.value="";    
//        document.all.txtPetiKecil.value=0;
//        document.all.txtKuantitiKecil.value=0;
//        document.all.txtPetiBesar.value=0;
//        document.all.txtKuantitiBesar.value=0;
//        document.all.txtNilai.value=0;
//        document.all.txtNilai.value=0;
//        document.all.txtJumlahNilai.value=0;   
//        //
//    
//        //validate input
//        if (document.all.currentImporter.value=="")
//        {
//            alert('Sila Masukkan Maklumat Pengimport & Pengeksport Terlebih Dahulu !!!');               
//        }
//        else
//        {
//            MM_openBrWindow('Senarai-Ikan.aspx','test','width=310,height=420,status=yes');   
//        }
//   }
//   
//}

function showSenaraiAgen()
{
agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "http://quest2003/w-iccs/pintu_masuk/senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
}
function reloadCaj()
{
    var dataItem1 = document.all.Kenderaan;    
    //document.all.currentImporter.value=    
    var cajString = dataItem1.options[dataItem1.selectedIndex].value
    var cajArray = cajString.split("|");
    document.all.cajKenderaan.value=cajArray[2];
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

function showFilteredAgen()
{
   //alert("found");
          
    var searchItem =document.all.searchKodAgen.value;
    var found=0;
    //alert(KodBKH.indexOf(searchItem)); 
    if (document.all.searchKodAgen.value=="")
    { 
        //alert('Sila Masukkan Maklumat Kod Agen Pengangkutan Terlebih Dahulu !!!');               
        // document.all.searchKodAgen.focus();
    }
    else
    {
       for (i=0;i<KeyKodAgen.length;i++)
       {
           if (searchItem==KeyKodAgen[i])
            {
               // alert("found="+i+"="+KeyKodAgen[i]);
                document.all.kodAgen.value = KodAgen[i];
                document.all.Agen.value = NamaAgen[i];
                found =1;
            }    
       }//end next
       
       if (found==0)               
       {
           input_box=confirm("Kod Agen Pengangkutan Tidak Ditemui Sila Cari Secara Manual!!! \nAdakah Anda Ingin Mencari Kod Agen Pengangkutan Secara Manual? \nSila Tekan OK untuk \"Ya\" CANCEL untuk \"Tidak\"!! ");
           if (input_box==true)
           { 
                // Output when OK is clicked                
                window.open('/w-iccs/Pintu_Masuk/Senarai_Agen.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
           }
           else
           {
                // Output when Cancel is clicked
                //alert ("You clicked cancel");
                document.all.searchKodAgen.value="";
                document.all.searchKodAgen.focus();
           }           
       }
              
     }
  
}

</script>

<%
    Dim cntArray As Integer = 0
    Dim sqlText As String = "SELECT Rtrim([Kod_Agen_Pengangkutan]) as keyCode, [Kod_Agen_Pengangkutan],[Nama_Agen_Pengangkutan] FROM [AGEN_PENGANGKUTAN]"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("KeyKodAgen[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("KodAgen[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("NamaAgen[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
 %>
<body onLoad="window.print();">

    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager> 
  <br />
  <table border="0" cellpadding="0" cellspacing="0" width="938">
     <tr>
                <td  colspan="2" bgcolor="#6600ff" style="height: 16px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: royalblue;" >
                    <strong><span style="color: #ffffff">KEMASKINI MAKLUMAT PENDAFTARAN MASUK</span></strong></td>
            </tr>
  </table>
  <br />

                 <table style="width: 100%">
            
      <tr> 
        <td  colspan="2"  > 
          <strong><span style="color: white"></span></strong></td>
            </tr>
                     <tr>
                         <td style="width: 172px">
                             &nbsp;<strong>Nombor Barcode</strong></td>
                         <td style="width: 379px; height: 14px">
                             : &nbsp;<asp:Label ID="strBarcode" runat="server" Text="Label"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 172px">
                             &nbsp;<strong>Pintu Masuk</strong></td>
                         <td style="width: 379px; height: 14px">
                             : &nbsp;<asp:Label ID="pintu_masuk" runat="server" Text="Label"></asp:Label></td>
                     </tr>
                     <tr>
                <td style="width: 172px" >
                    &nbsp;<strong>Kod Agen Pengangkutan</strong></td>
                <td style="height: 14px; width: 379px;">
                    :
                    &nbsp;<asp:Label ID="searchKodAgen" runat="server" Text="Label"></asp:Label>&nbsp;
                </td>
                     </tr>
            <tr>
                <td style="width: 172px" >
                    &nbsp;<strong>Nama Agen Pengangkutan</strong></td>
                <td style="width: 379px" >
                    :&nbsp;
                    <asp:Label ID="Agen" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 172px" >
                    <strong>&nbsp;Nombor Kenderaan</strong></td>
                <td style="width: 379px" >
                    :&nbsp;
                    <asp:Label ID="nokenderaan" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 172px;" >
                    <strong>&nbsp;Jenis Kenderaan</strong></td>
                <td style="width: 379px;" >
                    : &nbsp;<asp:Label ID="cara_pengangkutan" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 172px" >
                    <strong>&nbsp;Jenis Urusan</strong></td>
                <td style="width: 379px" >
                    : &nbsp;<asp:Label ID="JenisUrusan" runat="server" Text="Label"></asp:Label></td>
            </tr>
                     <tr>
                         <td colspan="2">
                         </td>
                     </tr>
        </table> 
                

        <br />
        <br />
        &nbsp; &nbsp;
    </form>
</body>
</html>
