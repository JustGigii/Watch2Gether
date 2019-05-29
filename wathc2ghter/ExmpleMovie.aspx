<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExmpleMovie.aspx.cs" Inherits="ExmpleMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-light">
        <table = class=" table table-bordered">
            <tr>
                <td class><asp:Image ID="ImageMoviePhoto" runat="server" Height="300" Width="200"/></td>
                <td colspan="2"><h1 class="text-light center display-1"><asp:Label ID="LabelMovieName" runat="server" Text="Label"></asp:Label></h1></td>
            </tr>
            <tr>
                <td ><h1 class="text-warning">YearRate: <asp:Label  class="text-light" ID="LabelYearRate" runat="server" Text=""></asp:Label></h1></td>
          <td><h1 class="text-info">Category: <asp:Label  class="text-light" ID="Labelcategory" runat="server" Text=""></asp:Label></h1></td>
            <td><h1 class="text-success">Date upload: <asp:Label class="text-light" ID="LabelDate" runat="server" Text=""></asp:Label></h1> </td>
            </tr>
            <tr>
                <td><asp:DataList  class="text-light" ID="DataListPlayers" runat="server" RepeatDirection="Horizontal">
               <ItemTemplate>
                   <asp:Image Width="100"  ID="Image1" runat="server" ImageUrl='<%# Bind("Image") %>' />
                   <h4 class="text-info">Actor's name: <asp:Label  class="text-light" ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label></h4>
                   <h4 class=" text-warning">Role: <asp:Label  class="text-light" ID="Label2" runat="server" Text='<%# Bind("Role") %>'></asp:Label></h4>
               </ItemTemplate>
           </asp:DataList></td>
                <td  colspan="2"><h1 class="text-info">Description:</h1><asp:Label  class="text-light" ID="LabelDescription" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <asp:Button  class="btn btn-Warning btn-sm" ID="ButtonTrailler" runat="server" Text="Trailer" OnClick="ButtonTrailler_Click" />
    <asp:Button  class="btn btn-Warning btn-sm" ID="ButtonWatch" runat="server" Text="Watch" OnClick="ButtonWatch_Click" />
    <asp:ListBox ID="ListBoxGroup" runat="server" AutoPostBack="True" Enabled="False" Visible="False" OnSelectedIndexChanged="ListBoxGroup_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="Null">Alone</asp:ListItem>
</asp:ListBox>
    <asp:DataList ID="DataListReview" runat="server" RepeatColumns="1" CssClass=" table table-bordered">
        <ItemTemplate>
          <h2 class="text-info">Name: <asp:Label class=" text-light" ID="Label3" runat="server" Text='<%# Bind("Name") %>' style="color: #FFFFFF"></asp:Label></h2>
           <h2 class="text-warning">Grade: <asp:Label class="text-light" ID="Label4" runat="server" Text='<%# Bind("Grade") %>'></asp:Label></h2>
            <h2 class="text-success">Description:</h2>
            <asp:Label class="text-light" ID="Label5" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
    </div>
</asp:Content>


