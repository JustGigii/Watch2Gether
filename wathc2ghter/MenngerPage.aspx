<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" enableEventValidation="false" CodeFile="MenngerPage.aspx.cs" Inherits="MenngerPage1"  %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    
    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridViewUsers_RowCommand" AllowSorting="True" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit" OnRowEditing="GridViewUsers_RowEditing1"  OnRowDataBound="GridViewUsers_RowDataBound" ShowFooter="True" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewUsers_PageIndexChanging1" EnableTheming="True" OnRowUpdating="GridViewUsers_RowUpdating">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="UserID" ReadOnly="True" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="True" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" />
                <asp:TemplateField HeaderText="State">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListState" runat="server">
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
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("birthday","{0:d}")%>'></asp:Label>
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
                <asp:TemplateField HeaderText="Active/Not Active">
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="RadioButtonListStatus" runat="server" SelectedValue='<%# Bind("Status") %>'>
                            <asp:ListItem Value="True">True</asp:ListItem>
                            <asp:ListItem Value="False">False</asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DateAdd" HeaderText="DateAdd"  dataformatstring="{0:d}" ReadOnly="True" />
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
     <asp:GridView ID="GridViewViewTheBestMovie" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False">
         <AlternatingRowStyle BackColor="#DCDCDC" />
         <Columns>
             <asp:BoundField DataField="MovieName" HeaderText="Movie Name" />
             <asp:BoundField DataField="WachID" HeaderText="Wached" />
         </Columns>
         <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
         <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
         <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
         <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#0000A9" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#000065" />
     </asp:GridView>
     <asp:GridView ID="GridViewGroup" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
         <AlternatingRowStyle BackColor="#CCCCCC" />
         <Columns>
             <asp:BoundField DataField="GroupName" HeaderText="GroupName" />
             <asp:BoundField DataField="UserId" HeaderText="User" />
         </Columns>
         <FooterStyle BackColor="#CCCCCC" />
         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
         <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#808080" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#383838" />
     </asp:GridView>
    <asp:Chart ID="ChartMoives" runat="server" >
    <Titles>
        <asp:Title ShadowOffset="3" Name="Items" />
    </Titles>
    <Series>
        <asp:Series Name="Default" ChartType="Pie" />
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
    </ChartAreas>
    </asp:Chart>      
    <asp:Chart ID="ChartGroup" runat="server"  class="table-dark">
        <Series>
            <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>

