<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TheViewMovie.aspx.cs" Inherits="TheViewMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<Button ID="Buttonplay"   Text="play" onclick="playVideo()" />--%>
    <%--<Button ID="Buttonpause"  Text="Stop" onclick="pauseVideo()"  />--%>
    <button onclick="pauseVideo()" type="button">Stop</button>
     <button onclick="playVideo()" type="button">play</button>
    <video  width="480" height="270" id="myVideo" controls>
	<source src="<%= MovieUrl %>" />


        
</video>
    <asp:TextBox ID="LabelCurrent" runat="server" Text="0"  Visible="true"></asp:TextBox>
    <asp:TextBox ID="LabelEend" runat="server" Text="0"  Visible="true"></asp:TextBox>
   
    <script>
        var video = document.getElementById('myVideo');
        var Ends = document.getElementById('ContentPlaceHolder1_LabelEend');
        Ends.value = video.duration;
        playVideo();

        function playVideo()
        {
            alert("play");
          
            var timeS = document.getElementById('ContentPlaceHolder1_LabelCurrent');
            video.currentTime = timeS.value;
            alert(video.currentTime);
            video.play();
        }

        //function pauseVideo()
        //{
        //    //alert("stop");
        //    //alert(Time);
        //    video.pause();
        //   Time = video.currentTime;
        //   var timeS=   document.getElementById('ContentPlaceHolder1_LabelCurrent');
        //   timeS.value=Time;
        // //  alert(timeS.value);
        //}

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
          <asp:TextBox ID="TextBoxChat" runat="server" TextMode="MultiLine" Height="185px" ReadOnly="True"></asp:TextBox>
          <br> </br>
          <asp:TextBox ID="TextBoxMessge" runat="server"></asp:TextBox><asp:Button ID="ButtonSubmit" runat="server" Text="Send" />
      </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>

<%--https://codepen.io/Gowiphi/pen/stmqp--%>