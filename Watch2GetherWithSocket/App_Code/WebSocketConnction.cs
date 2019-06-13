using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
/// <summary>
/// Summary description for WebSocketConnction
/// </summary>
public class WebSocketConnction: WebSocketHandler
{
	private static WebSocketCollection Clients = new WebSocketCollection();
	string name;
	public override void OnOpen()
	{
		name = this.WebSocketContext.QueryString["ChatName"];
		Clients.Add(this);
		Clients.Broadcast(name + " Has Connect.");
	}
	public override void OnMessage(string message)
	{
		string[] words = message.Split(',');
		GroupsDetails Rooms = (GroupsDetails)HttpRuntime.Cache.Get("Rooms");
		Group Group = Rooms.GetTheSerchGroup(int.Parse(words[1]));
		switch (words[0])
		{
			case "start":
				Group.Active = true;
				Clients.Broadcast("{\"Command\":\"start\", \"Sec\":\"" + Group.CurrentTime + "\", \"Group\":\"" + Group.GroupId + "\"}");
				break;
			case "stop":
				Group.Active = false;
				Clients.Broadcast("{\"Command\":\"stop\", \"Sec\":\""+ Group.CurrentTime+"\", \"Group\":\""+Group.GroupId+"\"}");
				break;
			default:
				string send = name + ": " + words[0];
				Clients.Broadcast("{\"Command\":\""+ send + "\", \"Sec\":\"" + Group.CurrentTime + "\", \"Group\":\"" + Group.GroupId + "\"}");
				break;
		}
		
	}
	public override void OnClose()
	{
		Clients.Remove(this);
		Clients.Broadcast(name + " Left The Chat");
	}
}