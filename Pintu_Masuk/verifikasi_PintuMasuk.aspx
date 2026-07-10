<%@ Page Language="VB" AutoEventWireup="false" CodeFile="verifikasi_PintuMasuk.aspx.vb" Inherits="Pintu_Masuk_verifikasi_PintuMasuk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
function redirectShowInfo(url)
{
  alert(url);
  input_box=confirm("Pengisytiharan Bagi Nombor Barcode Berikut " + document.all.Barcode.value + " Sudah Wujud!!! \nAdakah Anda Ingin Memaparkan Maklumat Pengistiharan Tersebut? \nSila Tekan OK untuk \"YA\" CANCEL untuk \"TIDAK\"");
  if (input_box==true) 
  { 
    location.href=url;
  } 
  else 
  {
    location.href="verifikasi_PintuMasuk.aspx";
  }  
}

function praimport()
{
window.navigate("pra_pintu_masuk_utara.aspx");
}


function praexport()
{
window.navigate("pra_pintu_masuk_selatan.aspx");
}
</script>
</head>
<body>
    <form id="form1"  runat="server">
  <br />
    <div>
        <table style="width: 80%" align="center">
            
      <tr bgcolor="#CC0000"> 
        <td colspan="2" style="text-align: center; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; height: 16px; background-color: #CC0000;"> 
          <strong><span style="color: #ffffff">VERIFIKASI BARCODE PENGISYTIHARAN</span></strong></td>
            </tr>
            <tr>
                <td style="width: 50%; height: 15px; text-align: right">
                </td>
                <td style="height: 15px; width: 445px;">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 15px; text-align: center">
                    <strong>Sila Masukkan Nombor Barcode</strong></td>
            </tr>
            <tr>
                <td style="height: 15px; text-align: center;" colspan="2">
                    <strong></strong>
                    <asp:TextBox ID="Barcode" runat="server" Width="149px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 15px; text-align: center" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="SEMAK BARCODE" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1" Width="133px" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 15px; text-align: center">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; height: 16px; background-color: #CC0000;"> 
          <strong><span style="color: #ffffff">MENU PRA PENGISYTIHARAN BAGI PPI YANG TIADA PINTU MASUK</span></strong></td>
            </tr>
        </table>
        
         <table style="width: 80%" align="center">
            
      <tr bgcolor="#CC0000"> 
        
            </tr>
            <tr>
                <td style="width: 50%; height: 15px; text-align: right">
                </td>
                <td style="height: 15px; width: 445px;">
                </td>
            </tr>
            <tr><td colspan="2" style="height: 15px; text-align: center">
                    <strong>Sila Pilih Pra Isytihar Import atau Eksport</strong></td></tr>
            
            <tr>
               <td style="height: 15px; text-align: center" colspan="2">
                    <input id="Button3" runat="server" onclick="praimport();" style="border-right: #333333 1px ridge;
                            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                            type="button" value="PRA ISYTIHAR IMPORT" />
                   &nbsp; || &nbsp; <input id="Button2" runat="server" onclick="praexport();" style="border-right: #333333 1px ridge;
                            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                            type="button" value="PRA ISYTIHAR EKSPORT" />
            </tr>
            <tr>
                <td colspan="2" style="height: 15px; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="height: 16px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: #CC0000;" bgcolor="#6600ff" colspan="2">&nbsp;
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
