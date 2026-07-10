<%@ Page Language="VB" AutoEventWireup="false" CodeFile="s7_edit_lkim_user.aspx.vb" Inherits="UserManagement_LKIM_edit_lkim_user" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Kemaskini Maklumat Pengguna LKIM</title>
    <link href="css/bhea2.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="popcalendar.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
 
     function maskKeyPress(objEvent)
{
    var iKeyCode; 
    iKeyCode = objEvent.keyCode;              
    if (iKeyCode>=48 && iKeyCode<=57) 
    {
    return true;
    }
    else if (iKeyCode == 45) {
    return true;
    }
    else {
    return false;
    }
 }

function validateInt1()
{
    var deposit_semasa_tambahan; 
    deposit_semasa_tambahan = parseFloat(document.form1.deposit_semasa_tambahan.value); if ( isNaN(deposit_semasa_tambahan) || (deposit_semasa_tambahan % 1 != 0) ) { document.form1.deposit_semasa_tambahan.value = 0; } 
    var deposit_semasa; 
    deposit_semasa = parseFloat(document.form1.deposit_semasa.value); if ( isNaN(deposit_semasa) || (deposit_semasa % 1 != 0) ) { document.form1.deposit_semasa.value = 0; } 
    calculate1();
 }
function calculate1() 
{
    var tbdeposit_semasa_tambahan = parseFloat(document.form1.deposit_semasa_tambahan.value);
    var tbdeposit_semasa = parseFloat(document.form1.deposit_semasa.value);
    document.form1.nilai_deposit_semasa.value = parseInt(tbdeposit_semasa_tambahan) + parseInt(tbdeposit_semasa);
    }
</script>
    
    
</head>
<body>
    <form id="form1" runat="server">
    
  <div> 
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">MODUL  MENYUNTING MAKLUMAT </td>
        <td width="73%" bgcolor="#006699" style="height: 13px">&nbsp;</td>
      </tr>
    </table>
    <table style="width: 570px">
            <tr>
                <td colspan="3">
                    <span style="font-size: 10pt; font-family: Arial Black">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <span style="font-family: Arial"></span></span></td>
            </tr>
        </table>
    
    <br />
  </div>
        
  <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
    <tr> 
      <td colspan="2" > <font color="#333333"><strong>Maklumat Spesis <span style="color: #000000">
          Hidupan Akuatik</span></strong></font></td>
    </tr>
    <tr> 
      <td style="width: 67px"> </td>
      <td style="width: 94px"> </td>
    </tr>
    <tr>
      <td style="width: 67px">&nbsp;</td>
      <td style="width: 94px">&nbsp;</td>
    </tr>
    <tr> 
      <td style="width: 67px"> Kod Spesis</td>
      <td style="width: 94px"> <asp:TextBox ID="textbox1" runat="server" Width="200px"></asp:TextBox></td>
    </tr>
    <tr> 
      <td style="width: 67px"> Nama Spesis</td>
      <td style="width: 94px"> <asp:TextBox ID="textbox2" runat="server" Width="200px" MaxLength="20"></asp:TextBox>&nbsp;
      </td>
    </tr>
  </table>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="NewUser" ConfirmText="Adakah anda pasti ingin mengemaskini maklumat pengguna berikut?">
        </cc1:ConfirmButtonExtender>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button1" ConfirmText="Adakah and pasti ingin menghapuskan maklumat pengguna berikut?">
        </cc1:ConfirmButtonExtender>
        &nbsp;&nbsp;<br />
        &nbsp;<asp:Button ID="NewUser" runat="server"
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Kemaskini" /><asp:Button ID="Button1" runat="server" 
            Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" Text="Hapus" /><input id="Button3" onclick="location.href='s7.aspx'" style="border-right: #333333 1px ridge;
            padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
            padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
            border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
            type="button" value="Papar" />
  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
</form>
</body>
</html>
