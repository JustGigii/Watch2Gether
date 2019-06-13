using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogOut : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		List<UserDetail> Users = (List<UserDetail>)Page.Application["Users"];
		Users.Remove((UserDetail)Session["User"]);
		Session.Abandon();
		Response.Redirect("HomePage.aspx");
	}
}