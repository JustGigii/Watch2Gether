<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Microsoft.Web.WebSockets;
public class Handler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        if (context.IsWebSocketRequest)
            context.AcceptWebSocketRequest(new WebSocketConnction());

    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}