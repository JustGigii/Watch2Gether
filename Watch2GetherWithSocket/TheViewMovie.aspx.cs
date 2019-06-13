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
	public string UserName;
	public Group Gr;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString["G"] == null || Session["User"] == null)
			if (Request.QueryString["m"] != null)
			{
				ImDb.WebService ImDb = new ImDb.WebService();
				MovieUrl = ImDb.GetURLAddress(int.Parse(Request.QueryString["m"]));
			}
			else
				Response.Redirect("HomePage.aspx");
		else
		{

			GroupId = int.Parse(Request.QueryString["G"]);
			//if (((GroupsDetails) Page.Application["Rooms"]).Rooms.Count != 0)
			GroupsDetails groupsDetails = (GroupsDetails)Cache.Get("Rooms");
			if (groupsDetails.Rooms.Count != 0)
			{
				//Gr = ((GroupsDetails)Page.Application["Rooms"]).GetTheSerchGroup(GroupId);
				Gr = groupsDetails.GetTheSerchGroup(GroupId);
				this.LabelCurrent.Text = Gr.CurrentTime.ToString();
				Gr.EndMovie = int.Parse(this.LabelEend.Text);
				//startTimer(Gr.MenngerGroup, ((UserDetail)Session["User"]).UserId);
				UserName = ((UserDetail)Session["User"]).UserName;
			}
			else
			{
				GroupId = 0;
				this.LabelCurrent.Text = "0";
			}
			ImDb.WebService ImDb = new ImDb.WebService();
			MovieUrl = ImDb.GetURLAddress(Gr.MovieID);
		}
	}
}