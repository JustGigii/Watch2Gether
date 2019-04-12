using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TheViewMovie : System.Web.UI.Page
{
	public static int s = 0;
	public static System.Timers.Timer _timer;
	public int GroupId;
	public string MovieUrl;
	string counttime;
	public Group Gr;
	protected void Page_Load(object sender, EventArgs e)
	{
		
		if (Request.QueryString["m"] == null)
			Response.Redirect("HomePage.aspx");
		else
		{
			GroupId = int.Parse(Request.QueryString["m"]);
			if (((GroupsDetails) Page.Application["Rooms"]).Rooms.Count != 0)
			{
			Gr = ((GroupsDetails)Page.Application["Rooms"]).GetTheSerchGroup(GroupId);
                //this.LabelCurrent.Text = Gr.CurrentTime.ToString();
                this.LabelCurrent.Text = "0";
                //startTimer(Gr.MenngerGroup, ((UserDetail)Session["User"]).UserId);
			}
			else
			{
				this.LabelCurrent.Text = "0";
			}
			ImDb.WebService ImDb = new ImDb.WebService();
			MovieUrl = ImDb.GetURLAddress(int.Parse(Request.QueryString["m"]));

			
	}
		
	}
	protected void Buttonplay_Click(object sender, EventArgs e)
	{
		//Buttonplay.Attributes["onclick"] = "javascript:playVideo();";

	}
	protected void Buttonpause_Click(object sender, EventArgs e)
	{
		//   this.Buttonpause.Attributes["onclick"] = "javascript:pauseVideo;";
	}

	protected static void startTimer(int Mannger, int Claint)
	{
		// initialize the time control giving as parameter the time in milliseconds, between raisings of the Elapsed event. The default is 100 milliseconds.   
		if (Mannger == Claint)
		{
			_timer = new System.Timers.Timer();
		}
		else
		{
			_timer = new System.Timers.Timer(20000);
		}
		// subscribe to the Elapsed event   
		_timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

		// Keep the timer alive until the end of Main.
		GC.KeepAlive(_timer);
		_timer.Start();
	}

	protected static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
	{
		// Do whatever you want to do on each tick of the timer
        //if (Gr.MenngerGroup == ((UserDetail)Session["Users"]).UserId)
		s++;
	}
}