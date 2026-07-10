<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="Import_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
            DataTextField="Nama_Pengangkutan" DataValueField="Kod_Pengangkutan">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT RTRIM([Kod_Pengangkutan]) as Kod_Pengangkutan, [Nama_Pengangkutan] FROM [JENIS_PENGANGKUTAN]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
