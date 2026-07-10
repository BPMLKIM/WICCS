<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Pintu_Keluar_Selatan.aspx.vb" Inherits="Pintu_Keluar" %>

<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>[WICCS]PINTU MASUK UTARA</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" method="post">


                <br /><br />
                 <table style="width: 100%">
            <tr>
                <td  colspan="2" bgcolor="#6600ff" style="height: 18px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: royalblue;" >
                    <strong><span style="color: #ffffff">&nbsp;MAKLUMAT PENDAFTARAN KELUAR</span></strong></td>
            </tr>
                     <tr>
                         <td style="width: 169px">
                             <strong>&nbsp;Nombor Barcode</strong></td>
                         <td style="width: 376px">
                             :<asp:TextBox ID="strBarcode" runat="server" Width="184px" Enabled="False"></asp:TextBox></td>
                     </tr>
            <tr>
                <td style="width: 169px; height: 28px;" >
                    &nbsp;<strong>Nama Agen Pengangkutan</strong></td>
                <td style="width: 376px; height: 28px;" >
                    :<asp:TextBox ID="Agen" runat="server" Width="223px" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 169px" >
                    &nbsp;<strong>Kod Agen Pengangkutan</strong></td>
                <td style="height: 14px; width: 376px;">
                    :<asp:TextBox ID="kodAgen" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 230px" >
                    <strong>No./Nama Kapal/Penerbangan/Kenderaan</strong></td>
                <td style="width: 376px" >
                    :<asp:TextBox ID="noKenderaan" runat="server" MaxLength="10" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 230px; height: 28px;" >
                    <strong>Jenis Kapal/Kapal Terbang/Kenderaan</strong></td>
                <td style="height: 28px; width: 376px;" >
                    :<asp:DropDownList ID="cara_pengangkutan" runat="server" DataSourceID="JenisPengangkutan"
                        DataTextField="Nama_Pengangkutan" DataValueField="Kod_Pengangkutan" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
                     <tr>
                         <td style="width: 169px; height: 28px">
                             <strong>&nbsp;Jenis Urusan</strong></td>
                         <td style="width: 376px; height: 28px">
                             :<asp:DropDownList ID="JenisUrusan" runat="server" DataSourceID="Urusan" DataTextField="Nama_Urusan"
                        DataValueField="Kod_Urusan" Enabled="False">
                    </asp:DropDownList>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2"><hr /></td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             &nbsp;<asp:Button ID="Simpan" runat="server" OnClick="Simpan_Click" Style="border-right: #333333 1px ridge;
                                 padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                                 padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                                 border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                                 Text="Simpan" />
                             <asp:Button ID="Button5" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px;
                           border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px; padding-bottom: 1px;
                           border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge;
                           font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1" Text="Keluar"
                           Width="84px" /></td>
                     </tr>
               <tr>
                   <td colspan="2" style="height: 15px">
                       </td>
               </tr>
        </table> 
              
                
               
                &nbsp; &nbsp; &nbsp;&nbsp;
            
        <br />
        <br />
      
       <asp:SqlDataSource ID="JenisPengangkutan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Pengangkutan]) as Kod_Pengangkutan, [Nama_Pengangkutan] as [Nama_Pengangkutan]  FROM [JENIS_PENGANGKUTAN]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="Urusan" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT [Kod_Urusan], [Nama_Urusan] FROM [JENIS_URUSAN]"></asp:SqlDataSource>
        &nbsp; &nbsp;
    </form>
</body>
</html>
