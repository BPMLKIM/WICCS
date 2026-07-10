<%@ Page Language="VB" AutoEventWireup="false" CodeFile="agen_pengangkutan.aspx.vb" Inherits="suntinganmaklumat_agen_pengangkutan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/bhea2.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Table Agen Pengangkutan<br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="Kod_Agen_Pengangkutan" DataSourceID="SqlDataSource1" BorderStyle="None" BorderWidth="0px" Width="100%" ShowFooter="True">
                    <Columns>
                        <asp:BoundField DataField="Kod_Agen_Pengangkutan" HeaderText="Kod_Agen_Pengangkutan"
                            ReadOnly="True" SortExpression="Kod_Agen_Pengangkutan" />
                        <asp:BoundField DataField="Nama_Agen_Pengangkutan" HeaderText="Nama_Agen_Pengangkutan"
                            SortExpression="Nama_Agen_Pengangkutan" />
                        <asp:BoundField DataField="Alamat_Agen_Pengangkutan" HeaderText="Alamat_Agen_Pengangkutan"
                            SortExpression="Alamat_Agen_Pengangkutan" />
                        <asp:BoundField DataField="Deposit_Semasa" HeaderText="Deposit_Semasa" SortExpression="Deposit_Semasa" />
                        <asp:BoundField DataField="Transaksi_Semasa" HeaderText="Transaksi_Semasa" SortExpression="Transaksi_Semasa" />
                       <asp:CommandField  ShowDeleteButton="True" ShowEditButton="True" />
                       </Columns>
                    <PagerSettings Mode="NextPrevious" />
                    <FooterStyle BackColor="White" />
                    <EmptyDataRowStyle BackColor="White" />
                    <RowStyle BackColor="White" />
                    <EditRowStyle BackColor="MistyRose" />
                    <SelectedRowStyle BackColor="White" />
                    <PagerStyle BackColor="White" />
                    <HeaderStyle BackColor="White" />
                </asp:GridView>
                &nbsp;&nbsp;
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                    DeleteCommand="DELETE FROM [AGEN_PENGANGKUTAN] WHERE [Kod_Agen_Pengangkutan] = @Kod_Agen_Pengangkutan"
                    InsertCommand="INSERT INTO [AGEN_PENGANGKUTAN] ([Kod_Agen_Pengangkutan], [Nama_Agen_Pengangkutan], [Alamat_Agen_Pengangkutan], [Deposit_Semasa], [Transaksi_Semasa]) VALUES (@Kod_Agen_Pengangkutan, @Nama_Agen_Pengangkutan, @Alamat_Agen_Pengangkutan, @Deposit_Semasa, @Transaksi_Semasa)"
                    SelectCommand="SELECT [Kod_Agen_Pengangkutan], [Nama_Agen_Pengangkutan], [Alamat_Agen_Pengangkutan], [Deposit_Semasa], [Transaksi_Semasa] FROM [AGEN_PENGANGKUTAN]"
                    UpdateCommand="UPDATE [AGEN_PENGANGKUTAN] SET [Nama_Agen_Pengangkutan] = @Nama_Agen_Pengangkutan, [Alamat_Agen_Pengangkutan] = @Alamat_Agen_Pengangkutan, [Deposit_Semasa] = @Deposit_Semasa, [Transaksi_Semasa] = @Transaksi_Semasa WHERE [Kod_Agen_Pengangkutan] = @Kod_Agen_Pengangkutan">
                    <DeleteParameters>
                        <asp:Parameter Name="Kod_Agen_Pengangkutan" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Nama_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Alamat_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Deposit_Semasa" Type="Single" />
                        <asp:Parameter Name="Transaksi_Semasa" Type="Single" />
                        <asp:Parameter Name="Kod_Agen_Pengangkutan" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Kod_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Nama_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Alamat_Agen_Pengangkutan" Type="String" />
                        <asp:Parameter Name="Deposit_Semasa" Type="Single" />
                        <asp:Parameter Name="Transaksi_Semasa" Type="Single" />
                    </InsertParameters>
                </asp:SqlDataSource>
                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
