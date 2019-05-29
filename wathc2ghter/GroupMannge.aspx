<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GroupMannge.aspx.cs" Inherits="GroupMannge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            color: #FFFFFF;
            font-size: medium;
        }
        .auto-style3 {
            font-size: large;
            color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:RadioButtonList ID="RadioButtonListGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListGroup_SelectedIndexChanged">
    </asp:RadioButtonList>
    <asp:Table ID="TablePageInterFace" runat="server">
        <asp:TableRow>
            
            <asp:TableCell class="auto-style2">Group Name</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBoxGroupName" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell class="auto-style2">Kind Group</asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="DropDownListKindGourp" runat="server"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell class="auto-style2"> <asp:Button ID="ButtonStatus" runat="server" Text="Press To Delete The Group" OnClick="ButtonStatus_Click"></asp:Button></asp:TableCell>
          <asp:TableCell> <asp:Button ID="ButtonUpdate" runat="server" Text="Submit" OnClick="ButtonUpdate_Click" /></asp:TableCell>
        </asp:TableRow>
   </asp:Table>
    
     <asp:Label ID="LabelErr" runat="server" CssClass="auto-style3"></asp:Label>
    
    <br />
    <asp:Label ID="LabelPeople" style="color: #FFFFFF" Font-Size="XX-Large" runat="server" Text="People in Group"> </asp:Label>
    <asp:GridView ID="GridViewPeopleOnGroup" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="GridViewPeopleOnGroup_RowCommand" OnRowDataBound="GridViewPeopleOnGroup_RowDataBound">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="User Name" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" />
            <asp:BoundField DataField="JoinDate" HeaderText="Join Date" />
            <asp:BoundField DataField="SatusName" HeaderText="Status" />
            <asp:ButtonField ButtonType="Button" CommandName="invite" Text="invite Agin" />
            <asp:ButtonField ButtonType="Button" CommandName="Kick" Text="Kick" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
         <br />
    <asp:Label ID="LabelFrendlist" style="color: #FFFFFF" Font-Size="XX-Large" runat="server" Text="Your Firend&#39;s List"></asp:Label> 
         <asp:GridView ID="GridViewFrends" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridViewFrends_RowCommand">
             <Columns>
                 <asp:BoundField DataField="UserName" HeaderText="UserName" />
                 <asp:BoundField DataField="FriendId" HeaderText="UserId" />
                 <asp:ButtonField ButtonType="Button" CommandName="Add" Text="Add" />
             </Columns>
             <FooterStyle BackColor="White" ForeColor="#000066" />
             <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
             <RowStyle ForeColor="#000066" />
             <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#007DBB" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
   
</asp:Content>

