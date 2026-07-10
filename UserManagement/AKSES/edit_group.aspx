<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_group.aspx.vb" Inherits="akses" %>

<%@ Register Assembly="Microsoft.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="Microsoft.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>[WICCS]</title>
    <link href="../../css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>


<%

    ' view for main menu
   
    sqlText = "Select * from group_setting where group_id = '" & Trim(Request("iduser")) & "'"
    SQLReader = opClass.DataReader(sqlText)
    While SQLReader.Read()
        
        For j = 0 To CheckBoxList1.Items.Count - 1

              If CheckBoxList1.Items(j).Value = SQLReader("module_id") Then
                If j = 0 Then CheckBoxList1.Items(j).Selected = True
                If j = 1 Then CheckBoxList1.Items(j).Selected = True
                If j = 2 Then CheckBoxList1.Items(j).Selected = True
                If j = 3 Then CheckBoxList1.Items(j).Selected = True
                If j = 4 Then CheckBoxList1.Items(j).Selected = True
                If j = 5 Then CheckBoxList1.Items(j).Selected = True
                If j = 6 Then CheckBoxList1.Items(j).Selected = True
                If j = 7 Then CheckBoxList1.Items(j).Selected = True
                If j = 8 Then CheckBoxList1.Items(j).Selected = True
                If j = 9 Then CheckBoxList1.Items(j).Selected = True
                If j = 10 Then
                    CheckBoxList1.Items(j).Selected = True
                    table_laporan.Attributes.Add("style", "DISPLAY:BLOCK")
                End If
                
                If j = 11 Then CheckBoxList1.Items(j).Selected = True
                If j = 12 Then CheckBoxList1.Items(j).Selected = True
                If j = 13 Then CheckBoxList1.Items(j).Selected = True
                               
            End If
            
        Next

  
    End While

    SQLReader.Close()
    SQLReader = Nothing
    
    ' end coded    
    
    ' view for menu laporan
    
    sqlText1 = "Select * from group_setting_sub where group_id = '" & Trim(Request("iduser")) & "' and module_id='15'"
    ' Response.Write(sqlText1)
    SQLReader = opClass.DataReader(sqlText1)
    While SQLReader.Read()
        
        For j = 0 To CheckBoxList2.Items.Count - 1

            If CheckBoxList2.Items(j).Value = SQLReader("sub_module_id") Then
               
                'Remarks by Nizam Ramli On 14 July 2007 --- APA NIE NAK KASI LAMBAT KER ?
                
                'If j = 0 Then CheckBoxList2.Items(j).Selected = True
                'If j = 1 Then CheckBoxList2.Items(j).Selected = True
                'If j = 2 Then CheckBoxList2.Items(j).Selected = True
                'If j = 3 Then CheckBoxList2.Items(j).Selected = True
                'If j = 4 Then CheckBoxList2.Items(j).Selected = True
                
                CheckBoxList2.Items(j).Selected = True
                

            End If
            
        Next

  
    End While

    SQLReader.Close()
    SQLReader = Nothing
    
    ' end coded
    
    %>
<body>
    <form id="form1" runat="server">
 
        <br />
        <br />
        <table width="90%" id="TABLE1">
            <tr  style="height: 15px;">
                <td align="left" colspan="2" style="height: 11px" valign="top" ;>
                    <asp:Label ID="title" runat="server" Font-Bold="True"
                        Font-Underline="True"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                </td>
                <td align="left" style="width: 743px; height: 5px" valign="top">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                </td>
                <td align="left" style="width: 743px; height: 5px" valign="top">
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 179px; height: 5px" valign="top">
                    <strong>Nama Kumpulan</strong></td>
                <td align="left" style="width: 743px; height: 5px" valign="top">
                    :&nbsp;
                    <asp:Label ID="group_name" runat="server" Text="Label"></asp:Label>
                    <asp:HiddenField ID="iduser" runat="server" />
                </td>
            </tr>
        </table>
        &nbsp;<br />
        
        <table id="table_menu" runat="server">
            <tr bgColor="#006699">
                <td style="width: 557px; height: 11px">
                    <span style="color: #ffffff">
                    <strong><span style="font-size: 9pt; font-family: Arial">Modul Akses</span></strong><br />
                    </span>
                </td>
            </tr>
            <tr>
                <td style="width: 557px; height: 15px">
                    <strong><span style="font-size: 9pt; font-family: Arial">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Menu_main" DataValueField="module_id" RepeatColumns="3" Width="552px" Font-Bold="False">
                        </asp:CheckBoxList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:W-ICCSConnectionString2 %>"
                            SelectCommand="SELECT [module_id], [Menu_main] FROM [menu_main]">
                        </asp:SqlDataSource>
                    </span></strong>
                </td>
            </tr>
        </table>
        
        <table id="table_laporan" runat="server" style="display : None">
            <tr bgColor="#006699">
                <td style="width: 557px; height: 15px">
                    <span style="color: #ffffff">
                    <strong><span style="font-size: 9pt; font-family: Arial">Sub Modul Laporan</span></strong><br />
                    </span>
                </td>
            </tr>
            <tr>
                <td style="width: 557px; height: 15px">
                    <strong><span style="font-size: 9pt; font-family: Arial">
                    </span></strong>
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" DataSourceID="SqlDataSource2"
                        DataTextField="submodule" DataValueField="submodule_id" RepeatColumns="2" Width="424px">
                    </asp:CheckBoxList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:w-iccsConnectionString2 %>"
                        SelectCommand="SELECT [submodule_id], [module_id], [submodule] FROM [menu_sub] WHERE ([module_id] = @module_id)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="15" Name="module_id" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <br />
    
        
        
        &nbsp;
        <asp:Button ID="simpan" runat="server" OnClick="Simpan_Click" Style="border-right: #333333 1px ridge;
                        padding-right: 1px; border-top: #ffffff 1px ridge; padding-left: 1px; font-size: 10px;
                        padding-bottom: 1px; border-left: #ffffff 1px ridge; color: #000000; padding-top: 1px;
                        border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??; background-color: #f1f1f1"
                        Text="  Kemaskini  " />
                        
        <input id="idgroup" type="button" runat="server" Style="border-right: #333333 1px ridge; padding-right: 1px; border-top: #ffffff 1px ridge;
            padding-left: 1px; font-size: 10px; padding-bottom: 1px; border-left: #ffffff 1px ridge;
            color: #000000; padding-top: 1px; border-bottom: #000000 1px ridge; font-family: MS Shell Dlg,verdana,??;
            background-color: #f1f1f1" value="Kembali Ke Laman Utama" />
        <br />
       
                    &nbsp;<br />
    </form>

</body>
</html>
