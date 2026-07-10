<%@ Page UICulture="it-IT" Culture="it-IT" Language="VB" AutoEventWireup="false" CodeFile="pengeksport_kecuali_new.aspx.vb" Inherits="pengeksport_kecuali_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PERSONALIA Daftar Maklumat Peribadi</title>
         <link rel="stylesheet" href="windowfiles/dhtmlwindow.css" type="text/css" />
        <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
     
</head>
<script type="text/javascript" src="windowfiles/dhtmlwindow.js">
</script>
<script type="text/javascript" language="javascript">


var agenwin;


var KeyKodIkan = new Array();
var KodIkan = new Array();
var Ikan = new Array();
var Ikan1 = new Array();


var KeyKodPengeksport = new Array();
var KodPengeksport = new Array();
var Pengeksport = new Array();

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


function showSenaraiIkan()
{
//agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "http://wiccs.lkim.gov.my/pintu_masuk/senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
agenwin=dhtmlwindow.open("SenaraiIkan", "iframe", "Senarai_ikan1.aspx", "#1: Senarai Ikan Larangan", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodIkan);
}



function showSenaraiPengeksport()
{
//agenwin=dhtmlwindow.open("SenaraiAgen", "iframe", "http://wiccs.lkim.gov.my/pintu_masuk/senarai_agen.aspx", "#1: Senarai Agen", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodAgen);
agenwin=dhtmlwindow.open("SenaraiPengeksport", "iframe", "Senarai_Pengeksport.aspx", "#1: Senarai Pengeksport", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodPengeksport);
}

function showFilteredIkan()
{
   //alert("found");
          
    var searchItem =document.all.searchKodIkan.value;
    var found=0;
    //alert(KodBKH.indexOf(searchItem)); 
    if (document.all.searchKodIkan.value=="")
    { 
        //alert('Sila Masukkan Maklumat Kod Agen Pengangkutan Terlebih Dahulu !!!');               
        // document.all.searchKodAgen.focus();
    }
    else
    {
       for (i=0;i<KeyKodIkan.length;i++)
       {
           if (searchItem==KeyKodIkan[i])
            {
               // alert("found="+i+"="+KeyKodAgen[i]);
                document.all.kodIkan.value = KodIkan[i];
                document.all.Ikan.value = Ikan[i];
                document.all.Ikan1.value = Ikan1[i];
                found =1;
            }    
       }//end next
       
       if (found==0)               
       {
           input_box=confirm("Kod Ikan Tidak Ditemui Sila Cari Secara Manual!!! \nAdakah Anda Ingin Mencari Kod Ikan Secara Manual? \nSila Tekan OK untuk \"Ya\" CANCEL untuk \"Tidak\"!! ");
           if (input_box==true)
           { 
                // Output when OK is clicked                
                //window.open('/Pintu_Masuk/Senarai_Agen.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
                agenwin=dhtmlwindow.open("SenaraiIkan", "iframe", "senarai_Ikan1.aspx", "#1: Senarai Ikan Larangan", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodIkan);
           }
           else
           {
                // Output when Cancel is clicked
                //alert ("You clicked cancel");
                document.all.searchKodIkan.value="";
                document.all.searchKodIkan.focus();
           }           
       }
              
     }
  
}



function showFilteredPengeksport()
{
   //alert("found");
          
    var searchItem =document.all.searchKodPengeksport.value;
    var found=0;
    //alert(KodBKH.indexOf(searchItem)); 
    if (document.all.searchKodPengeksport.value=="")
    { 
        //alert('Sila Masukkan Maklumat Kod Agen Pengangkutan Terlebih Dahulu !!!');               
        // document.all.searchKodAgen.focus();
    }
    else
    {
       for (i=0;i<KeyKodPengeksport.length;i++)
       {
           if (searchItem==KeyKodPengeksport[i])
            {
               // alert("found="+i+"="+KeyKodAgen[i]);
                document.all.kodPengeksport.value = KodPengeksport[i];
                document.all.Pengeksport.value = Pengeksport[i];
                found =1;
            }    
       }//end next
       
       if (found==0)               
       {
           input_box=confirm("Kod Pengeksport Tidak Ditemui Sila Cari Secara Manual!!! \nAdakah Anda Ingin Mencari Kod Pengeksport Secara Manual? \nSila Tekan OK untuk \"Ya\" CANCEL untuk \"Tidak\"!! ");
           if (input_box==true)
           { 
                // Output when OK is clicked                
                //window.open('/Pintu_Masuk/Senarai_Agen.aspx','SECURITY','scrollbars=yes,status=1,toolbar=no,personalbar=no,menubar=no,locationbar=no,resizable=no,width=380, height=420,top=100,left=70');               
                agenwin=dhtmlwindow.open("SenaraiPengeksport", "iframe", "senarai_Pengeksport.aspx", "#1: Senarai Pengeksport", "width=380px,height=340px,resize=1,scrolling=1,center=1", "recal",document.all.kodPengeksport);
           }
           else
           {
                // Output when Cancel is clicked
                //alert ("You clicked cancel");
                document.all.searchKodPengeksport.value="";
                document.all.searchKodPengeksport.focus();
           }           
       }
              
     }
  
}

</script>
<%
 Dim cntArray As Integer = 0
    Dim sqlText As String = "SELECT Rtrim([Kod_bkh]) as keyCode, [Kod_bkh],[kod_ikan],[nama_bkh] FROM [jenis_ikan_larangan] where status='yes'"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("KeyKodIkan[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("KodIkan[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("Ikan[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf)
        Response.Write("Ikan1[" & cntArray & "]='" & jsReader.GetValue(3) & "';" & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
    
    cntArray = 0
    sqlText = "SELECT Rtrim([Kod_pengeksport]) as keyCode, [Kod_pengeksport],[nama_syarikat_eksport] FROM [pengeksport] where status='yes'"
    jsReader = opClass.DataReader(sqlText)
    Response.Write("<script>")
    Do While jsReader.Read
        Response.Write("KeyKodPengeksport[" & cntArray & "]='" & jsReader.GetValue(0).ToString.Trim() & "';" & vbCrLf)
        Response.Write("KodPengeksport[" & cntArray & "]='" & jsReader.GetValue(1) & "';" & vbCrLf)
        Response.Write("Pengeksport[" & cntArray & "]='" & jsReader.GetValue(2) & "';" & vbCrLf)
        cntArray = cntArray + 1
    Loop
    Response.Write("</script>")
    jsReader.Close()
    jsReader = Nothing
    
    
 %>
 
<body>
    <form id="form1" runat="server">
    
  <div> 
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px; font-weight: bold;">MODUL  MENYUNTING MAKLUMAT</td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    <table style="width: 570px">
            <tr>
                <td colspan="3">
                    <span style="font-size: 10pt; font-family: Arial Black">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <span style="font-family: Arial"></span></span>
                </td>
            </tr>
        </table>
      
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
      <tr>
              <td colspan="2" style="height: 13px">
                  <font color="#333333"><strong> Daftar Maklumat Pengeksport Kecuali</strong></font></td>
              <td colspan="1" style="width: 182px; height: 13px;">
              </td>
          </tr>
         
          <tr>
              <td style="width: 220px; height: 19px;">&nbsp;
                  </td>
              <td style="width: 305px; height: 19px;">&nbsp;
                  </td>
              <td style="width: 182px; height: 19px;">
              </td>
          </tr>
                 
            
            <tr>
            <td style="width: 220px" >
                    Tarikh Mula :</td>
            <td style="width: 305px">
                    <asp:TextBox ID="t_mula" runat="server" Width="80px"></asp:TextBox>
            <input
            id="Button7" runat="server" class="textbox" name="choose2" onclick="popUpCalendar(this, t_mula, 'dd/mm/yyyy')"
            style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
            width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
            border-left-style: none; height: 18px; background-color: white; border-right-color: white;
            border-bottom-style: none" type="button" value=" " visible="false" />
                (dd/mm/yyyy)</td>
                            
                           <td style="width: 182px" >
                               Tarikh Tamat :</td>
                <td style="height: 14px; width: 309px;">
                    <asp:TextBox ID="t_tamat" runat="server" Width="80px"></asp:TextBox><input
            id="Button2" runat="server" class="textbox" name="choose2" onclick="popUpCalendar(this, t_tamat, 'dd/mm/yyyy')"
            style="border-left-color: white; background-image: url(calendar.jpg); border-bottom-color: white;
            width: 15px; cursor: hand; border-top-style: none; border-top-color: white; border-right-style: none;
            border-left-style: none; height: 18px; background-color: white; border-right-color: white;
            border-bottom-style: none" type="button" value=" " visible="false" />
                    (dd/mm/yyyy)</td>
              </tr>
        <tr>
            <td style="width: 220px">
                Jenis Ikan :</td>
            <td style="width: 305px; height: 14px">
                <asp:TextBox ID="searchKodIkan" runat="server" Width="24px"></asp:TextBox>
                <input id="Button13" runat="server" class="textbox" name="choose2" onclick="showSenaraiIkan(); return false;"
                    style="border-left-color: white; background-image: url(../images/search.gif);
                    border-bottom-color: white; width: 18px; cursor: hand; border-top-style: none;
                    border-top-color: white; border-right-style: none; border-left-style: none; height: 22px;
                    background-color: white; border-right-color: white; border-bottom-style: none"
                    type="button" value=" " visible="true" />
                <asp:TextBox ID="Ikan" runat="server" Width="64px"></asp:TextBox>
                <asp:TextBox ID="Ikan1" runat="server" Width="160px"></asp:TextBox>
                <asp:HiddenField ID="kodIkan" runat="server" />
            </td>
            <td style="width: 182px">
                Pengeksport Kecuali :</td>
            <td style="width: 309px; height: 14px">
                <asp:TextBox ID="searchKodPengeksport" runat="server" Width="24px"></asp:TextBox><input id="Button3" runat="server" class="textbox" name="choose2" onclick="showSenaraiPengeksport(); return false;"
                    style="border-left-color: white; background-image: url(../images/search.gif);
                    border-bottom-color: white; width: 18px; cursor: hand; border-top-style: none;
                    border-top-color: white; border-right-style: none; border-left-style: none; height: 22px;
                    background-color: white; border-right-color: white; border-bottom-style: none"
                    type="button" value=" " visible="true" /><asp:TextBox ID="Pengeksport" runat="server"
                        Width="160px"></asp:TextBox><asp:HiddenField ID="kodPengeksport" runat="server" />
            </td>
        </tr>
            
                  
      </table>
    <br />
    <asp:Button ID="NewUser" runat="server" Style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            Text="Simpan" /><input id="Button1" onclick="location.href='pengeksport_kecuali.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Papar/Kembali" />&nbsp;<br />
       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textbox1"
            Display="None" ErrorMessage="no pekerja"></asp:RequiredFieldValidator>--%>
      &nbsp; &nbsp;
        &nbsp;&nbsp;<br />
        
    
    </div>
    </form>
</body>
</html>
