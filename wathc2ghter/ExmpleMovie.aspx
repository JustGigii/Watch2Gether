<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExmpleMovie.aspx.cs" Inherits="HomePage_ExmpleMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 551px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
       <tr>
           <td><asp:Image ID="ImageMoviePhoto" runat="server" Height="202px" Width="357px" /></td>
           <td class="auto-style2"><p><asp:Label ID="LabelMovieName" runat="server" Text="Label"></asp:Label></p></td>
       </tr>
       <tr>
           <td><asp:Label ID="LabelYearRate" runat="server" Text="YearRate: "></asp:Label></td>
           <td class="auto-style2"><asp:Label ID="Labelcategory" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="LabelDate" runat="server" Text="Date Uplod: "></asp:Label></td>
       </tr>
       <tr>
           
           <tb><asp:DataList ID="DataListPlayers" runat="server" RepeatDirection="Horizontal">
               <ItemTemplate>
                   <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Image") %>' />
                   <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                   <asp:Label ID="Label2" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
               </ItemTemplate>
           </asp:DataList></tb>
           <td class="auto-style2"><asp:Label ID="LabelDescription" runat="server" Text="Label"></asp:Label> 
           </td>
       </tr>
   </table>
    <asp:Button ID="ButtonTrailler" runat="server" Text="Trailer" OnClick="ButtonTrailler_Click" />
    <asp:Button ID="ButtonWatch" runat="server" Text="Watch" OnClick="ButtonWatch_Click" />
    <asp:ListBox ID="ListBoxGroup" runat="server" AutoPostBack="True" Enabled="False" Visible="False" OnSelectedIndexChanged="ListBoxGroup_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="Null">Alone</asp:ListItem>
</asp:ListBox>
    <asp:DataList ID="DataListReview" runat="server" Height="597px" Width="816px">
        <ItemTemplate>
            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>' style="color: #FFFFFF"></asp:Label><br>
            <br></br>
            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
            <br>
            <br></br>
            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
            </br>
            </br>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

