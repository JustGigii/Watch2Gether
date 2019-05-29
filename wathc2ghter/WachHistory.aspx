<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WachHistory.aspx.cs" Inherits="WachHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridViewHistoryUser" runat="server" BackColor="#CCCCCC" BorderColor="#999999" CssClass="center" EditRowStyle-CssClass="center"  BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="MovieID" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" />
            <asp:BoundField DataField="MovieName" HeaderText="MovieName" />
            <asp:BoundField DataField="DateWatch"  dataformatstring="{0:d}" HeaderText="DateWatch" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Tomato" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>

    <asp:GridView ID="GridViewHistoryGroup" runat="server" AlternatingRowStyle-CssClass='auto-style1'  BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="MovieID" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="GroupName" HeaderText="GroupName" />
            <asp:BoundField DataField="MovieName" HeaderText="MovieName" />
            <asp:BoundField DataField="WatchDate"  dataformatstring="{0:d}" HeaderText="WatchDate" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Tomato" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>

    <asp:Button ID="ButtonUser" runat="server" OnClick="ButtonUser_Click" Text="ViewPersonalWach" />
    <asp:Button ID="ButtonGroupWach" runat="server" OnClick="ButtonGroupWach_Click" Text="ViewGroupWach" />

</asp:Content>

