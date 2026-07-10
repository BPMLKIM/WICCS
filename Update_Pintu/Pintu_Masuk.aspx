<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Pintu_Masuk.aspx.vb" Inherits="Pintu_Masuk_Pintu_Masuk_Utara" %>

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
var KeyKodAgen = new Array();
var KodAgen = new Array();
var NamaAgen = new Array();

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

<script language="javascript" type="text/javascript">

function showSenaraiprinter()
{
  window.open('../pembayaran/senarai-printer.aspx','test','width=310,height=420,status=yes');  
}

function printReport(strCetak)
{
winTitle = "Salinan Update Pintu Masuk";
nama = "<%=Session("namaPegawai") %>";
jawatan = "<%=Session("jobtitle") %>";
str ="report.aspx?item=1&strBarcode="+ document.all.TextBox1.value +"&pintu_masuk="+document.all.pintu_masuk.value +"&searchKodAgen="+document.all.searchKodAgen.value+"&Agen="+document.all.Agen.value+"&noKenderaan="+document.all.noKenderaan.value+"&cara_pengangkutan="+document.all.cara_pengangkutan.value+"&JenisUrusan="+document.all.JenisUrusan.value+"&SalinanMs="+ escape(winTitle)+"&cetak=" +strCetak +"&pilihan="+document.all.CheckBoxList2.value+"&pname="+document.all.printer_name.value;

 if (strCetak==1)
    {
        if (document.all.printer_name.value!="")
        {    
             window.open(str,'prt','width=50,height=50,status=yes');
        }
        else
        {
            alert("Sila Pilih Printer Terlebih Dahulu !!!");
        }
    }
    else
    {
        window.open(str,'LKIM','');
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
    
    sqlText = "Select * from item_bukan_ikan where no_barcode = '" & Trim(Request("strbarcode")) & "'"
    SQLReader = opClass.DataReader(sqlText)
    While SQLReader.Read()
        
        For j = 0 To CheckBoxList2.Items.Count - 1

            If CheckBoxList2.Items(j).Value = SQLReader("kod_barangan") Then
                CheckBoxList2.Items(j).Selected = True
                              
                                             
            End If
            
        Next
  
    End While

    SQLReader.Close()
    SQLReader = Nothing
    
 %> 

<body>

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
                         <td style="width: 208px">
                         </td>
                         <td style="width: 379px; height: 14px">
                             <asp:Image ID="Image1" runat="server" ImageAlign="Left" /></td>
                     </tr>
                     <tr>
                         <td style="width: 208px">
                             &nbsp;<strong>Nombor Barcode</strong></td>
                         <td style="width: 379px; height: 14px">
                             :<asp:Label ID="strBarcode" runat="server" Text="Label" Visible="False"></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td style="width: 208px">
                             &nbsp;<strong>Pintu Masuk</strong></td>
                         <td style="width: 379px; height: 14px">
                             :<asp:DropDownList ID="pintu_masuk" runat="server">
                                 <asp:ListItem Value="Import">Import</asp:ListItem>
                                 <asp:ListItem Value="Eksport">Eksport</asp:ListItem>
                             </asp:DropDownList></td>
                     </tr>
                     <tr>
                <td style="width: 208px" >
                    &nbsp;<strong>Kod Agen Pengangkutan</strong></td>
                <td style="height: 14px; width: 379px;">
                    :<asp:TextBox ID="searchKodAgen" runat="server"></asp:TextBox><input id="calender2" runat="server" class="textbox" name="choose2" onclick="showSenaraiAgen(); return false;"
                        style="border-left-color: white; background-image: url(../images/search.gif); border-bottom-color: white;
                        width: 18px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
                        border-left-style: none; height: 22px; background-color: white; border-right-color: white;
                        border-bottom-style: none" type="button" value=" " visible="true" />
                    <asp:HiddenField ID="kodAgen" runat="server" />
                </td>
                     </tr>
            <tr>
                <td style="width: 208px" >
                    &nbsp;<strong>Nama Agen Pengangkutan</strong></td>
                <td style="width: 379px" >
                    :<asp:TextBox ID="Agen" runat="server" Width="223px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 230px" >
                    <strong>&nbsp; No/Nama Kapal/Penerbangan/Kenderaan</strong></td>
                <td style="width: 379px" >
                    :<asp:TextBox ID="noKenderaan" runat="server" MaxLength="10"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 230px; height: 28px;" >
                    <strong>&nbsp;Jenis Kapal/Kapal Terbang/Kenderaan</strong></td>
                <td style="height: 28px; width: 379px;" >
                    :<asp:DropDownList ID="cara_pengangkutan" runat="server" DataSourceID="JenisPengangkutan"
                        DataTextField="Nama_Pengangkutan" DataValueField="Kod_Pengangkutan">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 208px" >
                    <strong>&nbsp;Jenis Urusan</strong></td>
                <td style="width: 379px" >
                    :<asp:DropDownList ID="JenisUrusan" runat="server" DataSourceID="Urusan" DataTextField="Nama_Urusan" DataValueField="Kod_Urusan">
                    </asp:DropDownList>
                    </td>
            </tr>
                     <tr>
                         <td style="width: 208px; height: 18px;">
                             <strong>&nbsp;Barangan Bukan Ikan</strong></td>
                         <td style="width: 379px; height: 18px;">
                             <asp:CheckBoxList ID="CheckBoxList2" runat="server" DataSourceID="SqlDataSource2"
                                 DataTextField="Nama_barangan" DataValueField="Kod_barangan" RepeatColumns="4" Width="424px">
                             </asp:CheckBoxList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                                 SelectCommand="SELECT Kod_barangan, Nama_barangan FROM KodBukanIkan">
                             </asp:SqlDataSource>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">
                         </td>
                     </tr>
                     
                     <tr>
                         <td colspan="2" style="height: 22px">
                             &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="border-right: #333333 1px ridge;
                                 padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                                 padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                                 border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                                 Text="Kemaskini" /><input id="Cetak" onclick="printReport('1');" style="border-right: #333333 1px ridge;
                               padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                               padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                               border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                               type="button" validation="true" value="Cetak" /><asp:Button ID="cetak" runat="server"
                                   Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
                                   padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
                                   color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
                                   background-color: #f1f1f1" Text="Cetak" Visible="False" /><input id="Button1" runat="server"
                                       onclick="showSenaraiprinter();" style="border-right: #333333 1px ridge; padding-right: 1px;
                                       border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                                       border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                                       font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" type="button"
                                       value="Pilih Printer" /><input id="Button3" onclick="printReport();" style="border-right: #333333 1px ridge;
                               padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                               padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                               border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                               type="button" validation="true" value="Papar Cetak" /><asp:Button ID="Button5" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                           border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                           border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                           font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Keluar"
                           Width="84px" /></td>
                     </tr>
        </table> 
                

        <br />
        <br />
      
        <asp:SqlDataSource ID="JenisPengangkutan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Pengangkutan]) as Kod_Pengangkutan, [Nama_Pengangkutan] as [Nama_Pengangkutan]  FROM [JENIS_PENGANGKUTAN]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Urusan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT     Kod_Urusan, Nama_Urusan&#13;&#10;FROM         JENIS_URUSAN ORDER BY Nama_Urusan ASC">
        </asp:SqlDataSource>
        <asp:HiddenField ID="printer_name" runat="server" />
        &nbsp;&nbsp;<br />
        &nbsp;
    </form>
</body>
</html>
