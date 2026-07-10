<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pemeriksaan.aspx.vb" Inherits="Pemeriksaan_Ikan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>[WICCS]PINTU MASUK UTARA</title>
    <link href="../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body runat="server">
      
    <form id="form1" runat="server">
        &nbsp;
        &nbsp;<br />
        <table style="width: 100%">
            <tr>
                <td colspan="4" style="height: 18px" bgcolor="#6600ff">
                    <strong>&nbsp;<span style="color: #ffffff">PEMERIKSAAN IKAN</span></strong></td>
            </tr>
            <tr>
                <td style="width: 97px">
                </td>
                <td style="width: 177px">
                </td>
                <td style="width: 86px">
                </td>
                <td style="width: 308px">
                </td>
            </tr>
            <tr>
                <td style="width: 97px" >
                    <strong>&nbsp;#Barcode</strong></td>
                <td style="width: 177px" >
                    <asp:TextBox ID="Barcode" runat="server" Width="156px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 86px" >
                    <strong>&nbsp;Jenis Urusan</strong></td>
                <td style="width: 308px" >
                    <asp:TextBox ID="jenis_urusan" runat="server" ReadOnly="True" Width="156px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 23px; width: 97px;" >
                    &nbsp;<strong>No. Kenderaan</strong></td>
                <td style="height: 23px; width: 177px;" >
                    <asp:TextBox ID="noKenderaan" runat="server" Width="93px" ReadOnly="True"></asp:TextBox></td>
                <td style="height: 23px; width: 86px;" >
                </td>
                <td style="height: 23px; width: 308px;" >
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 17px">
                    <hr />
                </td>
            </tr>
            
        </table>
        
        
        
            <table style="width: 100%">
                <tr  >
                    <td style="width: 163px; height: 21px;" >
                        <b>Status Pemeriksaan</b></td>
                    <td style="height: 21px" >
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">Sah ( Pemeriksaan Rambang )</asp:ListItem>
                            <asp:ListItem Value="1">Sah ( Pemeriksaan 100% )</asp:ListItem>
                            <asp:ListItem Value="0">Tidak Sah</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr style="display : none" id="a1" runat="server">
                    <td style="width: 163px; height: 24px;">
                        <strong>Tindakan</strong></td>
                    <td style="height: 24px" >
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Mahkamah</asp:ListItem>
                        <asp:ListItem>Isytihar Semula</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                
                
                
                <tr >
                    <td style="width: 163px; height: 56px">
                        <b>Alasan</b></td>
                    <td style="height: 56px">
                        <input id="Text1" style="width: 248px; height: 64px" type="text" /></td>
                </tr>
            </table>        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="720px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="No" >
                    <ItemTemplate>
                        <asp:CheckBox id="aut" text='' runat="server" ></asp:CheckBox>                        
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No SKPI" SortExpression="No_SKPI">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("No_SKPI") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("No_SKPI") %>'></asp:Label>                        
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="Nama_Syarikat_Import" HeaderText="Pengimport" SortExpression="Nama_Syarikat_Import" >
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
               
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT  dbo.PENGISYTIHARAN_I.No_SKPI, dbo.PENGIMPORT.Nama_Syarikat_Import FROM dbo.PENGISYTIHARAN_I INNER JOIN dbo.PENGIMPORT ON dbo.PENGISYTIHARAN_I.Kod_Pengimport = dbo.PENGIMPORT.Kod_Pengimport WHERE ([No_Barcode] = @No_Barcode)">
            <SelectParameters>
                <asp:QueryStringParameter Name="No_Barcode" QueryStringField="Barcode" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />



 
                        <hr />
        <asp:Button ID="Button1" runat="server" Text="Simpan" />
        
    </form>

</body>
</html>
