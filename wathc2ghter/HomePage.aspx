<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataListCatalog" runat="server" OnItemCommand="DataListCatalog_ItemCommand" DataKeyField="MovieId">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButtonshow" runat="server" ImageUrl='<%# Bind("UrlPicture")%>' Width="200" Height="300" CommandName="show" CommandArgument="show" />
            <h1>
                <asp:Label ID="LabelName" runat="server" Text='<%# Bind("MoiveName") %>'></asp:Label>
                <asp:Label ID="LabelId" runat="server" Text="Label" Visible="False"></asp:Label>
            </h1>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

