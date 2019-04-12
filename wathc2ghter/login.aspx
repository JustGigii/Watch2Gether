<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <h1>דף התחברות</h1>
        <table>
            <tr<>
                <td class="auto-style2">UserName</td>
                <td class="auto-style2"> <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            
        </table>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
    </div>
       
        <asp:Label ID="LabelErr" runat="server"></asp:Label>  
</asp:Content>

