<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TheViewMovie.aspx.cs" Inherits="TheViewMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var name = "<%= UserName %>";
            var GroupId = "<% =GroupId %>";
            if (GroupId != 0) {
                var url = 'ws://localhost:57809/Handler.ashx' + '?ChatName=' + name;
                ws = new WebSocket(url);

                ws.onopen = function () {
                    $('#chatMessages').prepend('<h3>Connected </h3><br/>');
                    var video = document.getElementById('myVideo');
                    var timeS = document.getElementById('ContentPlaceHolder1_LabelCurrent');
                    playVideo();

                    function playVideo() {
                        var timeS = document.getElementById('ContentPlaceHolder1_LabelCurrent');
                        video.currentTime = timeS.value;
                    }
                    $('#cmdStart').click(function () {
                        var video = document.getElementById('myVideo');
                        if (video.paused)
                            ws.send("start," + GroupId);
                        else
                            ws.send("stop," + GroupId);


                    });

                    $('#cmdSend').click(function () {

                        ws.send($('#txtMessage').val() + "," + GroupId);

                        $('#txtMessage').val('');

                    });
                };
                ws.onmessage = function (e) {
                    var video = document.getElementById('myVideo');
                    var obj = JSON.parse(e.data);
                    switch (obj.Command) {
                        case "stop":
                            if (GroupId == obj.Group) {
                                video.pause();
                                video.currentTime = obj.Sec;
                            }
                            break;
                        case "start":
                            if (GroupId == obj.Group)
                                video.play();
                            break;
                        default:
                            if (GroupId == obj.Group)
                                $('#chatMessages').prepend('<h3>' + obj.Command + '</h3><br/>');
                    }
                };

                $('#cmdLeave').click(function () {

                    ws.close();

                });

                ws.onclose = function () {

                    $('#chatMessages').prepend('<h3>Closed <h3><br/>');

                };

                ws.onerror = function (e) {

                    $('#chatMessages').prepend('Oops something went wront <br/>');

                };
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <input id="cmdStart" type="button" value="Play/Pause" />

    <video  width="480" height="270" id="myVideo" controls>
	<source src="<%= MovieUrl %>" />


        
</video>
    <asp:TextBox ID="LabelCurrent" runat="server" Text="0"></asp:TextBox>
    <asp:TextBox ID="LabelEend" runat="server" Text="0"></asp:TextBox>
   
    <div class="table-info">
    <br />
    <input id="txtMessage" />
 
    <input id="cmdSend" type="button" value="Send" />

 
    <br />
 
    <div id="chatMessages" />
        </div>
    </asp:Content>

<%--https://codepen.io/Gowiphi/pen/stmqp--%>