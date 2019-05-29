<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TheViewMovie.aspx.cs" Inherits="TheViewMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta http-equiv="refresh" content="30">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="ButtonStart" runat="server" OnClick="ButtonStart_Click" Text="Start" />
    <asp:Button ID="ButtonStop" runat="server" Text="Stop" OnClick="ButtonStop_Click" />
    <video  width="480" height="270" id="myVideo" controls>
	<source src="<%= MovieUrl %>" />


        
</video>
    <asp:TextBox ID="LabelCurrent" runat="server" Text="0"></asp:TextBox>
    <asp:TextBox ID="LabelEend" runat="server" Text="0"></asp:TextBox>
   
    <script>
        var video = document.getElementById('myVideo');
        var timeS = document.getElementById('ContentPlaceHolder1_LabelCurrent');
        playVideo();

        function playVideo()
        {
            var timeS = document.getElementById('ContentPlaceHolder1_LabelCurrent');
            video.currentTime = timeS.value;
        }

        function pauseVideo()
        {
            //alert("stop");
            //alert(Time);
            video.pause();
         //  alert(timeS.value);
        }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
          <h4><asp:TextBox ID="TextBoxChat" runat="server" TextMode="MultiLine" Height="185px" ReadOnly="True" CssClass="alert alert-primary">fg </asp:TextBox></h4>
          <br>
          <br></br>
          <asp:TextBox ID="TextBoxMessge" runat="server"></asp:TextBox>
          <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-warning btn btn-secondary active" OnClick="ButtonSubmit_Click1" Text="Send" />
          </br>
      </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>

<%--https://codepen.io/Gowiphi/pen/stmqp--%>