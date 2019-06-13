<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="center">

    <asp:DropDownList ID="DropDownListSort" runat="server" CssClass="btn-group-sm">
            <asp:ListItem Selected="True" Value="-1">Choose Sort </asp:ListItem>
            <asp:ListItem Value="0">Up</asp:ListItem>
            <asp:ListItem Value="1">Down</asp:ListItem>
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
           <asp:DataList ID="DataListCatalog" runat="server" OnItemCommand="DataListCatalog_ItemCommand" DataKeyField="MovieId" RepeatColumns="3" CssClass="table-active">
        <ItemTemplate> 
            
    <asp:Label ID="LabelErr" runat="server"></asp:Label>
            <asp:ImageButton ID="ImageButtonshow" runat="server" ImageUrl='<%# Bind("UrlPicture")%>' Width="200" Height="300" CommandName="show" CommandArgument="show"/>
            <h3>
                <asp:Label ID="LabelName" runat="server" Text='<%# Bind("MoiveName") %>' Width="250"></asp:Label>
                <asp:Label ID="LabelId" runat="server" Text="Label" Visible="False"></asp:Label>
            </h3>
        </ItemTemplate>
    </asp:DataList>
          </div>  
</asp:Content>

