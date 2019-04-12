<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MenngerPage.aspx.cs" Inherits="MenngerPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridViewUsers_RowCommand" AllowSorting="True" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit" OnRowEditing="GridViewUsers_RowEditing1"  OnRowDataBound="GridViewUsers_RowDataBound" ShowFooter="True" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewUsers_PageIndexChanging1" EnableTheming="True" OnRowUpdating="GridViewUsers_RowUpdating">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="UserID" ReadOnly="True" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="True" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" />
                <asp:TemplateField HeaderText="State">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListState" runat="server">
                            <asp:ListItem>Israel</asp:ListItem>
                            <asp:ListItem>USA</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="birthday">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListYear" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListMonth" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListDay" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("birthday") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:TemplateField HeaderText="KindUser">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListKindUser" runat="server">
                            <asp:ListItem Selected="True" Value="0">משתמש רגיל</asp:ListItem>
                            <asp:ListItem Value="5">משתמש בתשלום</asp:ListItem>
                            <asp:ListItem Value="10">מנהל אתר</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("KindUser") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="RadioButtonListStatus" runat="server">
                            <asp:ListItem Value="true">True</asp:ListItem>
                            <asp:ListItem Value="false">False</asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DateAdd" HeaderText="DateAdd" ReadOnly="True" />
                <asp:BoundField DataField="CardID" HeaderText="CardID" />
                <asp:BoundField DataField="dateCard" HeaderText="dateCard" />
                <asp:BoundField DataField="SecurityCode" HeaderText="SecurityCode" />
                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
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
    </div>
        <asp:DropDownList ID="DropDownListSort" runat="server">
            <asp:ListItem Selected="True" Value="0">Choose Sort </asp:ListItem>
            <asp:ListItem Value="0">Up</asp:ListItem>
            <asp:ListItem Value="1">Down</asp:ListItem>
            <asp:ListItem Value="2">UserName UP</asp:ListItem>
            <asp:ListItem Value="3">UserName Down</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBoxSerch" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownListFilter" runat="server">
            <asp:ListItem Value="0">Sart With</asp:ListItem>
            <asp:ListItem Value="1">End With</asp:ListItem>
            <asp:ListItem Value="2">have</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonSortNFilter" runat="server" OnClick="ButtonSortNFilter_Click" Text="Serch" />
        <asp:Button ID="ButtonStatusView" runat="server" OnClick="ButtonStatusView_Click" Text="Hide Status" />
    <asp:Label ID="LabelErr" runat="server"></asp:Label>
</asp:Content>

