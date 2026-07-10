<%@ Page Language="VB" AutoEventWireup="false" CodeFile="verifikasi_cajLain.aspx.vb" Inherits="verifikasi_barcode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form id="form1" runat="server">
    
  <div align="left"><br />
    <table style="width: 90%">
            
      <tr bgcolor="#66FFFF"> 
        <td colspan="2" style="text-align: center"> <strong><span style="color: #ffffff"><font color="#000000">VERIFIKASI 
          BARCODE UNTUK PERISYTIHARAN CAJ LAIN 
          </font>
         </strong></td>
            </tr>
            <tr>
                <td style="width: 50%; height: 15px; text-align: right">
                </td>
                <td style="height: 15px; width: 339px;">
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
            
      <tr bgcolor="#66FFFF"> 
        <td colspan="2" style="height: 15px"> </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
