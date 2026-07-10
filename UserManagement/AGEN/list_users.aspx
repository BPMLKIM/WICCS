<%@ Page Language="VB" AutoEventWireup="false" CodeFile="list_users.aspx.vb" Inherits="UserManagement_AGEN_list_users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>W-ICCS User Management</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
   

</head>
<script language="javascript" type="text/javascript">
var preEl ;
var orgBColor;
var orgTColor;


function HighLightTR(backColor,textColor){  
if(typeof(preEl)!='undefined') {
preEl.bgColor=orgBColor; 
try{ChangeTextColor(preEl,orgTColor);}catch(e){;}
} 
var el = event.srcElement;
el = el.parentElement;
orgBColor = el.bgColor;
orgTColor = el.style.color;
el.bgColor=backColor;

try{ChangeTextColor(el,textColor);}catch(e){;}
preEl = el; 
}

function ChangeTextColor(a_obj,a_color){  ;
for (i=0;i<a_obj.cells.length;i++){//put condition before increase!!!!!
a_obj.cells(i).style.color=a_color; 
document.all.currentImporter.value=a_obj.cells(i).innerHTML;
}
}

function selectedCompany()
{
var data1=document.all.agen.options.value;
location.href="new_agen_user.aspx?agentCode="+data1;
}

</script>
<body>
    <form id="form1" runat="server">
    
  <div> <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager> 
    &nbsp;<br />
    <table border="0" cellpadding="0" cellspacing="0" width="938">
      <tr> 
        <td width="27%" style="height: 13px">M O D U L &nbsp;&nbsp;&nbsp;K E S 
          E L A M A T A N</td>
        <td width="73%" bgcolor="#999999" style="height: 13px">&nbsp;</td>
      </tr>
    </table>  <br />
  </div>
        <table style="width: 653px">
            <tr>
                <td colspan="3">
                    <strong><span style="font-size: 10pt; font-family: Arial Black">PENGURUSAN PENGGUNA
                        AGEN</span></strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px" bgcolor="gainsboro">
                    <strong>
                    Perhatian :</strong> Sila klik pada kata penguna untuk mengemaskini atau memapar maklumat
                    pengguna.</td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 650px">
                    <tr>
                        <td style="width: 217px; height: 15px">
                        </td>
                        <td style="width: 217px; height: 15px">&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 217px; height: 8px">
                            Senarai Pengguna
                        </td>
                        <td style="height: 8px">
                    <asp:DropDownList ID="agen" runat="server" AutoPostBack="True" DataSourceID="agenSrc"
                        DataTextField="Nama_Agen_Pengangkutan" DataValueField="Kod_Agen">
                    </asp:DropDownList>
                    <asp:Button ID="mulaCarian" runat="server" Text="Refresh" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" /></td>
                    </tr>
                    <tr>
                        <td style="width: 217px; height: 8px">
                        </td>
                        <td style="height: 8px">
                        </td>
                    </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataSourceID="lkim_userlists"
            Width="651px" Height="22px" ShowFooter="True" EmptyDataText="Tiada Rekod Ditemui" Font-Bold="False" >
            <HeaderStyle BackColor="RoyalBlue" ForeColor="White" Height="22px" HorizontalAlign="Left" />
            <PagerSettings Mode="NextPreviousFirstLast" />
            <RowStyle Height="18px" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Nama Penuh" SortExpression="name" />
                <asp:BoundField DataField="designation" HeaderText="Jawatan" SortExpression="designation" />
                <asp:BoundField DataField="email_address" HeaderText="Email" SortExpression="email_address" />
                <asp:BoundField DataField="contact_no" HeaderText="Tel. No." SortExpression="contact_no" />
                <asp:BoundField DataField="user_name" HeaderText="ID Pengguna" SortExpression="user_name" />
                <asp:BoundField DataField="User Type" HeaderText="Jenis Pengguna" SortExpression="User Type" />
                <asp:BoundField DataField="User Status" HeaderText="Status" SortExpression="User Status" />
            </Columns>
            <FooterStyle BackColor="RoyalBlue" Height="22px" />
            <AlternatingRowStyle BackColor="#E0E0E0" />
            <EmptyDataRowStyle Font-Bold="True" />
        </asp:GridView>
        <asp:SqlDataSource ID="lkim_userlists" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
            SelectCommand="SELECT front_login.kod_agen_pengangkutan, front_login.name, front_login.designation, front_login.email_address, front_login.contact_no, front_login.user_name, user_type.description AS [User Type], user_status.description AS [User Status] FROM user_status INNER JOIN front_login ON user_status.user_status = front_login.user_status INNER JOIN user_type ON front_login.user_type = user_type.user_type WHERE (front_login.kod_agen_pengangkutan = + @kod And front_login.deleted='N')">
            <SelectParameters>
                <asp:ControlParameter ControlID="agen" DefaultValue="%" Name="kod" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
                <asp:SqlDataSource ID="agenSrc" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCS_Conn %>"
                    SelectCommand="SELECT [Kod_Agen_Pengangkutan] as kod_Agen, [Nama_Agen_Pengangkutan] FROM [AGEN_PENGANGKUTAN] ORDER BY [Nama_Agen_Pengangkutan]">
                </asp:SqlDataSource>
                <br />
                   
                <asp:Button ID="NewUser" runat="server" Text="Pengguna Baru" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;" OnClientClick="selectedCompany();"/>
                <asp:Button ID="Button2" runat="server" Text="Kembali Ke Laman Utama" style="BORDER-RIGHT: #333333 1px ridge; PADDING-RIGHT: 1px; BORDER-TOP: #ffffff 1px ridge; PADDING-LEFT: 1px; FONT-SIZE: 10px; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px ridge; COLOR: #000000; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1px ridge; FONT-FAMILY: MS Shell Dlg,verdana,??; BACKGROUND-COLOR: #f1f1f1;"/>&nbsp;<br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
