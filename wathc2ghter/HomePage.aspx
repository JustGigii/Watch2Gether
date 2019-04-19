<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DropDownList ID="DropDownListSort" runat="server">
            <asp:ListItem Selected="True" Value="-1">Choose Sort </asp:ListItem>
            <asp:ListItem Value="0">Up</asp:ListItem>
            <asp:ListItem Value="1">Down</asp:ListItem>
            <asp:ListItem Value="2">UserName UP</asp:ListItem>
            <asp:ListItem Value="3">UserName Down</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBoxSerch" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownListCategory" runat="server" AutoPostBack="True">
    </asp:DropDownList>
        <asp:DropDownList ID="DropDownListFilter" runat="server">
            <asp:ListItem Value="0">Sart With</asp:ListItem>
            <asp:ListItem Value="1">End With</asp:ListItem>
            <asp:ListItem Value="2">have</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonSortNFilter" runat="server" OnClick="ButtonSortNFilter_Click" Text="Serch" />
    <asp:Button ID="ButtonCategory" runat="server" Text="Serch Category" OnClick="ButtonCategory_Click" />
    <asp:DataList ID="DataListCatalog" runat="server" OnItemCommand="DataListCatalog_ItemCommand" DataKeyField="MovieId">
        <ItemTemplate>
            
    <asp:Label ID="LabelErr" runat="server"></asp:Label>
            <asp:ImageButton ID="ImageButtonshow" runat="server" ImageUrl='<%# Bind("UrlPicture")%>' Width="200" Height="300" CommandName="show" CommandArgument="show" />
            <h1>
                <asp:Label ID="LabelName" runat="server" Text='<%# Bind("MoiveName") %>'></asp:Label>
                <asp:Label ID="LabelId" runat="server" Text="Label" Visible="False"></asp:Label>
            </h1>
        </ItemTemplate>
    </asp:DataList>
    
</asp:Content>

