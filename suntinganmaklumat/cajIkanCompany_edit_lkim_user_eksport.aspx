<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cajIkanCompany_edit_lkim_user_eksport.aspx.vb" Inherits="UserManagement_LKIM_edit_lkim_user_eksport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS Kemaskini Maklumat Pengguna LKIM</title>
    <link href="css/bhea2.css" rel="stylesheet" type="text/css" />
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
        <table border="0" style="width: 95%">
            <tr>
                <td style="width: 197px">
                    <strong>Id</strong></td>
                <td>
                    :<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 197px">
                    <strong>&nbsp;Kategori Ikan</strong></td>
                <td>
                    :<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><strong></strong></td>
            </tr>
             <%--<tr>
                <td style="width: 197px">
                    <strong>&nbsp;Kod Ikan</strong></td>
                <td>
                    :<asp:Label ID="Label10" runat="server" Text="Label"></asp:Label><strong></strong></td>
            </tr>--%>
            <tr style="font-weight: bold">
                <td style="width: 197px">
                    &nbsp;Kadar Peti Kecil</td>
                <td>
                    : <strong>RM&nbsp; </strong>
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 197px; height: 15px">
                    <strong>&nbsp;Kadar Peti Besar</strong></td>
                <td style="height: 15px">
                    : <strong>RM&nbsp; </strong>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 197px">
                    <strong>&nbsp;Kadar Ekor</strong></td>
                <td>
                    : <strong>RM</strong>&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 197px">
                    <strong>&nbsp;Kadar Kuantiti</strong></td>
                <td>
                    : <strong>RM</strong>&nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 197px">
                    &nbsp;<strong>Tarikh Mula Penguatkuasaan</strong></td>
                <td>
                    :
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 197px">
                    <strong>&nbsp;Tarikh Akhir Penguatkuasaan</strong></td>
                <td>
                    :
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;<br />
                    <asp:Button ID="Batal" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="Batal" Width="130px" /><asp:Button ID="papar" runat="server" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="Papar" Width="130px" />
                </td>
            </tr>
        </table>
        <br />
        &nbsp;<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="batal" ConfirmText="Adakah and pasti ingin menghapuskan maklumat berikut?">
        </cc1:ConfirmButtonExtender>
        &nbsp;&nbsp;&nbsp;<br />
        &nbsp; &nbsp;
  &nbsp; &nbsp;&nbsp;
</form>
</body>
</html>
