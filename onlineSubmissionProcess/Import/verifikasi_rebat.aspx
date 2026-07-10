<%@ Page Language="VB" AutoEventWireup="false" CodeFile="verifikasi_rebat.aspx.vb" Inherits="Pintu_Masuk_verifikasi_rebat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <br /> <div>
        <table style="width: 80%" align="center">
            
      <tr bgcolor="#CCCC66"> 
        <td colspan="2" style="text-align: center; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; height: 16px; background-color: #ffccff;"> 
          <strong><span style="color: #ffffff"><font color="#333333">VERIFIKASI PENGISYTIHARAN
              REBAT KIBFG</font></span></strong></td>
            </tr>
            <tr>
                <td style="width: 50%; height: 15px; text-align: right">
                </td>
                <td style="height: 15px">
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
                <td style="height: 16px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: #ffccff;" bgcolor="#6600ff" colspan="2">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 15px; text-align: center">
                    <asp:Button ID="Button2" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                        border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                        border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                        font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="CETAK SEMULA SLIP REBAT DAN MASTERSHEET REBAT"
                        Width="304px" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
