<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateUser.aspx.cs" Inherits="UpdateUser1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table border="1" BorderStyle="Outset">
            <tr>
                <td> <asp:Button runat="server" ID="buttonShopProfileDetails" Text="ShowProfileDetail" OnClick="buttonShopProfileDetails_Click" /> </td>
                <td>
                     <asp:TextBox runat="server" ID="TextBoxPass" TextMode="Password"/>
                     <asp:Label ID="LabelPass" runat="server" Text="please enter you password"></asp:Label>
                <asp:Table runat="server" ID="TableDEtails">
                    <asp:TableRow runat="server">
                       <asp:TableCell>First Name</asp:TableCell>
                        <asp:TableCell>
                             <asp:TextBox ID="TextBoxFname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxFname" ErrorMessage="Please Enter "></asp:RequiredFieldValidator>
                        </asp:TableCell>
                       </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>last Name</asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBoxLname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxLname" ErrorMessage="Please Enter "></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow>
                        <asp:TableCell>UserName</asp:TableCell>
                        <asp:TableCell>
                           <asp:TextBox ID="TextBoxUname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter " ControlToValidate="TextBoxUname"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxUname" ErrorMessage="Must enter in first letter. After you must Enter at least 5 format" ValidationExpression="[a-z,A-Z]{1}\w{5,12}"></asp:RegularExpressionValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell> Password</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBoxPasst" runat="server" TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPasst" ErrorMessage="Please Enter "></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPasst" ErrorMessage="Minimum eight characters, at least one letter and one number:" ValidationExpression="\w+"></asp:RegularExpressionValidator>
                </asp:TableCell>
                    </asp:TableRow>
                      <asp:TableRow>
                        <asp:TableCell>Password Agin</asp:TableCell>
                        <asp:TableCell> <asp:TextBox ID="TextBoxepass" runat="server" TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxepass" ErrorMessage="Please Enter "></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPasst" ControlToValidate="TextBoxepass" ErrorMessage="the password not mach "></asp:CompareValidator></asp:TableCell>
                    </asp:TableRow>
                      <asp:TableRow>
                        <asp:TableCell>State</asp:TableCell>
                        <asp:TableCell><asp:DropDownList ID="DropDownListState" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownListState" ErrorMessage="Please Enter"></asp:RequiredFieldValidator>
                   <br/> </asp:TableCell>
                    </asp:TableRow>
                      <asp:TableRow>
                        <asp:TableCell>Email</asp:TableCell>
                        <asp:TableCell> <asp:TextBox ID="TextBoxmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please Enter " ControlToValidate="TextBoxmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></asp:TableCell>
                    </asp:TableRow>
                      <asp:TableRow>
                        <asp:TableCell>Profile</asp:TableCell>
                        <asp:TableCell><td class="auto-style1">
                             <asp:Image ID="Image1" runat="server" />
                    <input accept="image/*" name="pic" type="file" /></td></asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="ButtonCancelUser" runat="server" Text="Press here to Cancel Your accound" OnClick="ButtonCancelUser_Click" /></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="Buttonupgrade" runat="server" Text="upgrade your accond" OnClick="Buttonupgrade_Click"></asp:Button></td>
                <td><asp:Table ID="TableUpgrade" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>CardID</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBoxCardId" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>CardDate</asp:TableCell>
                        <asp:TableCell>
                    <asp:DropDownList ID="DropDownListYears" runat="server" AutoPostBack="False" CausesValidation="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListMonth" runat="server" AutoPostBack="False" CausesValidation="True">
                    </asp:DropDownList>
                             <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="DropDownListYears" ErrorMessage="Please Enter Years" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="DropDownListMonth" ErrorMessage="Please Enter Moth" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                      <asp:TableCell>CVS</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBoxCVS" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    </asp:Table>
                    </td>
            </tr>
        </table>
        <asp:Label ID="LabelERR" runat="server" ></asp:Label>
</asp:Content>

