<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1>טבלת רישום</h1>
        <table>
            <tr>
                <td class="auto-style1">First Name</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxFname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxFname" ErrorMessage="Please Enter First Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>last Name</td>
                <td>
                    <asp:TextBox ID="TextBoxLname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxLname" ErrorMessage="Please Enter last Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>UserName</td>
                <td>
                    <asp:TextBox ID="TextBoxUname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter " ControlToValidate="TextBoxUname"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxUname" ErrorMessage="Must enter in first letter. After you must Enter at least 5 format" ValidationExpression="[a-z,A-Z]{1}\w{5,12}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Password</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxPass" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Minimum eight characters: at least one letter at least one number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Password Agin</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxepass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxepass" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPass" ControlToValidate="TextBoxepass" ErrorMessage="the password not mach "></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">birthday</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListYears" runat="server" AutoPostBack="False" CausesValidation="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListMonth" runat="server" AutoPostBack="False" CausesValidation="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListDay" runat="server" AutoPostBack="False" CausesValidation="True" ValidationGroup="g1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownListDay" ErrorMessage="Please Enter Date" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="DropDownListDay" ErrorMessage="Please Enter Day" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="DropDownListYears" ErrorMessage="Please Enter Moth" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="DropDownListYears" ErrorMessage="Please Enter Year" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
             <tr>
                <td class="auto-style2">State
                 </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListState" runat="server" AutoPostBack="False">
                        <asp:ListItem Selected="False">Choose State</asp:ListItem>
                        <asp:ListItem Value="Israel">Israel</asp:ListItem>
                        <asp:ListItem Value="USA">USA</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownListState" ErrorMessage="Please Enter"></asp:RequiredFieldValidator>
                   <br/> 
                 </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="TextBoxmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please Enter " ControlToValidate="TextBoxmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                 </td>
            </tr>
             <td class="auto-style1">Profile</td>
                <td class="auto-style1">
                    <input accept="image/*" name="pic" type="file" /></td>
            <tr>
                <td>&nbsp;
                    <asp:Button ID="ButtonSend" runat="server" Text="Send" OnClick="ButtonSend_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" />
                    <asp:Label ID="Labelerr" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Content>

