<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateGroupe.aspx.cs" Inherits="CreateGroupe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td class="auto-style2"><asp:TextBox ID="TextBoxGroupeName" runat="server"></asp:TextBox><h1 style="color:white;">שם הקבוצה</h1> </td>
            <td><asp:DropDownList ID="DropDownListKindGourp" runat="server"></asp:DropDownList>
                <h1 style="color:white;">סוג קבוצה</h1></td>
        </tr>
        <tr>
            <td><asp:GridView ID="GridViewFrends" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GridViewFrends_RowCommand" OnRowDataBound="GridViewFrends_RowDataBound">
                <AlternatingRowStyle BackColor="#c1c1c1" ForeColor="#808080" />
                <Columns>
                    <asp:BoundField DataField="FriendId" HeaderText="FriendId" InsertVisible="False" />
                    <asp:BoundField DataField="UserName" HeaderText="Name" />
                    <asp:ButtonField ButtonType="Button" CommandName="AddMember" Text="Add" />
                    <asp:ButtonField ButtonType="Button" CommandName="DeleteFromGroup" Text="Delete" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                
                <h1 style="color:white"><asp:Label ID="Labelerr" runat="server"></asp:Label></h1>
            </td>
        </tr>
    </table>
    <asp:Button ID="ButtonSends" runat="server" Text="Submit" OnClick="ButtonSends_Click" />
</asp:Content>

