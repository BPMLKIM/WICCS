<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Pra_Pintu_Masuk_Utara.aspx.vb" Inherits="Pra_Pintu_Masuk_Pintu_Masuk_Utara" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
   

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
//agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "http://wiccs.lkim.gov.my/pintu_masuk/senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
}
function reloadCaj()
{
    var dataItem1 = document.all.Kenderaan;    
    //document.all.currentImporter.value=    
    var cajString = dataItem1.options[dataItem1.selectedIndex].value
    var cajArray = cajString.split("|");
    //document.all.cajKenderaan.value=cajArray[2];
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
                //window.open('/Pintu_Masuk/Senarai_Agen.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
                agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
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

   function printReport(strCetak)
{


var winTitle;

var str ="http://report.lkim.gov.my/pintu_masuk/slip_pra_utara.aspx?barcode="+ document.all.barcoded.value +"&cetak="+ strCetak+"&pname="+document.all.printer_name.value;

str ="slip_pra_utara.aspx?barcode="+ document.all.barcoded.value +"&cetak="+ strCetak+"&pname="+document.all.printer_name.value;


if (strCetak==1)
{
    if (document.all.printer_name.value!="")
    {    
      window.open(str,'eSKPI','width=5,height=5,status=yes');
    }
    else
    {
     alert("Sila Pilih Printer Terlebih Dahulu !!!");
    }
}
else
{
window.open(str,'eSKPI','');
}

}

function showSenaraiprinter()
{
  window.open('../pembayaran/senarai-printer.aspx','test','width=310,height=420,status=yes');  
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
<body>

    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager> 
  <br />
  <table border="0" cellpadding="0" cellspacing="0" width="938">
    <tr> 
      <td width="30%" style="height: 13px">
          PRA PENGISYTIHARAN IMPORT</td>
      <td width="70%" bgcolor="royalblue" style="height: 13px">&nbsp;</td>
    </tr>
  </table>
  <br />
  <asp:UpdatePanel ID="UpdatePanel1" runat="server"> <ContentTemplate> 
  <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
                 <table style="width: 100%">
            
      <tr> 
        <td  colspan="2"  > 
          <strong><span style="color: white"><font color="#333333">MAKLUMAT PRA PENGISYTIHARAN
              IMPORT</font></span></strong></td>
            </tr>
                     <tr>
                         <td style="width: 169px; height: 23px;">
                             <strong>&nbsp;</strong></td>
                         <td style="width: 379px; height: 23px;">
                             <asp:TextBox ID="NoRujukan" runat="server" Visible="False"></asp:TextBox>
                             <asp:Button ID="PeriksaRujukan" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                           border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                           border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                           font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Periksa"
                           Width="80px" CausesValidation="False" OnClick="PeriksaRujukan_Click" Visible="False"/></td>
                     </tr>
                     <tr>
                <td style="width: 169px" >
                    &nbsp;<strong>Kod Agen Pengangkutan</strong></td>
                <td style="height: 14px; width: 379px;">
                    :<asp:TextBox ID="searchKodAgen" runat="server"></asp:TextBox>
                    <input id="calender2" runat="server" class="textbox" name="choose2" onclick="showSenaraiAgen(); return false;"
                        style="border-left-color: white; background-image: url(../images/search.gif); border-bottom-color: white;
                        width: 18px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                        border-left-style: none; height: 22px; background-color: white; border-right-color: white;
                        border-bottom-style: none" type="button" value=" " visible="true" />
                    <asp:HiddenField ID="kodAgen" runat="server" />
                </td>
                     </tr>
                     <tr>
                         <td style="width: 169px">
                         </td>
                         <td style="width: 379px">
                         </td>
                     </tr>
            <tr>
                <td style="width: 169px" >
                    &nbsp;<strong>Nama Agen Pengangkutan</strong></td>
                <td style="width: 379px" >
                    :<asp:TextBox ID="Agen" runat="server" Width="223px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 230px" >
                    <strong>&nbsp;No/Nama Kapal/Penerbangan/Kenderaan</strong></td>
                <td style="width: 379px" >
                    :<asp:TextBox ID="noKenderaan" runat="server" MaxLength="100" Width="224px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 230px; height: 28px;" >
                    <strong>&nbsp;Jenis Kapal/Kapal Terbang/Kenderaan</strong></td>
                <td style="height: 28px; width: 379px;" >
                    :<asp:DropDownList ID="Kenderaan" runat="server" DataSourceID="JenisPengangkutan"
                        DataTextField="nama_pengangkutan" DataValueField="val" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="">Sila buat pilihan</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 169px" >
                    <strong>&nbsp;Jenis Urusan</strong></td>
                <td style="width: 379px" >
                    :<asp:DropDownList ID="JenisUrusan" runat="server" DataSourceID="Urusan" DataTextField="Nama_Urusan" DataValueField="Kod_Urusan">
                    </asp:DropDownList>
                    </td>
            </tr>
                     <tr>
                         <td style="width: 169px">
                             <strong> </strong>
                         </td>
                         <td style="width: 379px; text-align: left">
                             <strong> </strong><asp:TextBox ID="cajKenderaan" runat="server" Width="58px" Visible="False"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td colspan="2"><hr /></td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             &nbsp;<input style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; WIDTH: 72px; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1" id="Button6" type="button" value="Baru" onclick="self.location.href='pra_pintu_masuk_utara.aspx';" /><asp:Button ID="Button2" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                           border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                           border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                           font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Simpan"
                           Width="80px" OnClick="Button2_Click" /><asp:Button ID="Button1" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                           border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                           border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                           font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Keluar"
                           Width="84px" OnClientClick="location.href='verifikasi_PintuMasuk.aspx';" UseSubmitBehavior="False" CausesValidation="False" /></td>
                     </tr>
               <tr>
                   <td colspan="2" style="height: 15px">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Agen"
                           Display="None" ErrorMessage="Nama Agen Pengangkutan Wajib Diisi"></asp:RequiredFieldValidator>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="searchKodAgen"
                           ErrorMessage="Kod Agen Pengangkutan Wajib Diisi" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="noKenderaan"
                           ErrorMessage="No. Kenderaan Wajib Diisi" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator></td>
               </tr>
                     <tr>
                         <td colspan="2" style="height: 15px">
                             <asp:Label ID="signalResponse" runat="server" Font-Bold="True" ForeColor="Red" Width="100%"></asp:Label></td>
                     </tr>
        </table> 
                </asp:Panel>
                
                <asp:Panel ID="Panel2" runat="server" Height="50px" Width="100%" Visible="False">
                   <table style="width: 100%">
                       <tr>
                           
        <td  colspan="2" > 
          <strong><span style="color: #ffffff"><font color="#333333">MAKLUMAT PRA PENGISYTIHARAN
              IMPORT BERIKUT TELAH SELAMAT DISIMPAN</font></span></strong></td>
                       </tr>
                       <tr>
                           <td style="height: 13px" colspan="2">
                              <asp:Image ID="Image1" runat="server" ImageAlign="Left" /></td>
                       </tr>
                       <tr>
                           <td colspan="2">
                               <strong>&nbsp;LEMBAGA KEMAJUAN IKAN MALAYSIA</strong></td>
                       </tr>
                       <tr>
                           <td colspan="2">
                           </td>
                       </tr>
                       <tr>
                           <td width="30%">
                               &nbsp;<strong>Nombor Daftar</strong></td>
                <td >
                    :&nbsp;<asp:Label ID="daftar" runat="server" Text="Label" Width="86px" Font-Bold="True"></asp:Label></td>
                       </tr>
                       <tr>
                           <td width="30%">
                    &nbsp;Nombor Siri</td>
                <td >
                    :&nbsp;<asp:Label ID="nSiri" runat="server" Text="Label" Width="87px"></asp:Label></td>
                       </tr>
                       <tr>
                           <td width="30%">
                               <strong>&nbsp;</strong>Kod Agen Pengangkutan</td>
                           <td>
                               :&nbsp;<asp:Label ID="Label1" runat="server" Text="Label" Width="56px"></asp:Label></td>
                       </tr>
            <tr>
                <td width="30%">
                    <strong>&nbsp;</strong>Tarikh &amp; Masa Masuk</td>
                <td >
                    :&nbsp;<asp:Label ID="Tarikh" runat="server" Text="Label" Width="178px"></asp:Label></td>
            </tr>
            <tr>
                <td width="30%">
                    <strong>&nbsp;</strong>Pintu Masuk</td>
                <td >
                    :&nbsp;<asp:Label ID="Label3" runat="server" Text="Import" Width="55px"></asp:Label></td>
            </tr>
                       <tr>
                           <td width="30%">
                               &nbsp;No./Nama Kapal/Penerbangan/Kenderaan</td>
                           <td>
                               :&nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Width="240px"></asp:Label></td>
                       </tr>
                       <tr>
                           <td width="30%">
                               <strong>&nbsp;</strong>JenisKapal/Kapal Terbang/Kenderaan</td>
                           <td >
                               :&nbsp;<asp:Label ID="Label2" runat="server" Text="Label" Width="140px"></asp:Label></td>
                       </tr>
            <tr>
                <td width="30%">
                    <strong>&nbsp;</strong>Jenis Urusan</td>
                <td >
                    :&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Width="100%"></asp:Label></td>
            </tr>
                       <tr>
                           <td style="height: 15px" width="30%">
                               &nbsp;Nombor Barcode</td>
                           <td style="height: 15px">
                               :
                               <asp:TextBox ID="barcoded" runat="server" BorderStyle="None" ReadOnly="True"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td style="height: 15px" width="30%">
                               <strong>
                                   <asp:Label ID="TextBox1" runat="server" MaxLength="10" Visible="False"></asp:Label></strong></td>
                           <td style="height: 15px">
                               &nbsp;<asp:Label ID="Label6" runat="server" Text="Label" Width="57px" Visible="False"></asp:Label></td>
                       </tr>
                       <tr>
                           <td colspan="2" style="height: 15px">
                           </td>
                       </tr>
                       <tr>
                           <td colspan="2" style="height: 15px">
                               <span style="font-size: 7pt"><strong>&nbsp;</strong>PERHATIAN :- SIMPAN SLIP INI UNTUK
                                   URUSAN SETERUSNYA</span></td>
                       </tr>
                       <tr>
                           <td colspan="2" style="height: 15px">
                               <hr />
                           </td>
                       </tr>
            <tr>
                <td style="height: 15px" colspan="2"><input style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; WIDTH: 72px; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1" id="Button10" type="button" value="Baru" onclick="self.location.href='pra_pintu_masuk_utara.aspx';" /><input
                        id="Button5" runat="server" onclick="printReport('1');" style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        type="button" value="Cetak Slip" /><input id="Button4" runat="server" onclick="showSenaraiprinter();"
                            style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
                            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
                            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
                            background-color: #f1f1f1" type="button" value="Pilih Printer" /><asp:Button ID="Button9" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                           border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                           border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                           font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Keluar"
                           Width="84px" OnClientClick="location.href='verifikasi_PintuMasuk.aspx';" UseSubmitBehavior="False" CausesValidation="False" />
                </td>
            </tr>
            </table>
        &nbsp;<asp:Button ID="Button3" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="TERUSKAN ISYTIHAR" Width="248px" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</table>
                </asp:Panel>
                &nbsp;&nbsp;
                               
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="Button2" ConfirmText="Adakah anda pasti untuk menyimpan maklumat?">
                </cc1:ConfirmButtonExtender>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" Width="272px" />
      &nbsp;
            </ContentTemplate>
            <triggers>
            <asp:PostBackTrigger ControlID="Button3" />
            </triggers>
        </asp:UpdatePanel>
        <asp:HiddenField ID="printer_name" runat="server" />
        <br />
        <br />
      
        <asp:SqlDataSource ID="JenisPengangkutan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT rtrim( [Kod_Pengangkutan])+'|'+ rtrim([Nama_Pengangkutan])+'|'+rtrim(cast([Caj_Pengangkutan] as varchar(20))) as val, [nama_pengangkutan]  FROM [JENIS_PENGANGKUTAN]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Urusan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT     Kod_Urusan, Nama_Urusan&#13;&#10;FROM         JENIS_URUSAN&#13;&#10;WHERE     (Kod_Urusan IN ('001', '007','016','009','019','020','008'))&#13;&#10;ORDER BY Nama_Urusan ASC">
        </asp:SqlDataSource>
        &nbsp;
    </form>
</body>
</html>
