using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["User"] == null)
            {
                Menu1.Items.Add(new MenuItem("Register", "Register", null, "~/Register.aspx"));
                Menu1.Items.Add(new MenuItem("Log in", "Login", null, "~/login.aspx"));
			}
            else
            {
                Menu1.Items.Add(new MenuItem("Update User", "UpdateUser", null, "~/UpdateUser.aspx"));
				Menu1.Items.Add(new MenuItem("Friend List", "FriendList", null, "~/FriendList.aspx"));
				Menu1.Items.Add(new MenuItem("Log Out", "LogOut", null, "~/LogOut.aspx"));
				if (((UserDetail)Session["User"]).KindUser >= 5)
                    Menu1.Items.Add(new MenuItem("CreateGroupe", "CreateGroupe", null, "~/CreateGroupe.aspx"));
                    Menu1.Items.Add(new MenuItem("WachHistory", "WachHistory", null, "~/WachHistory.aspx"));
                    Menu1.Items.Add(new MenuItem("GroupMannge", "GroupMannge", null, "~/GroupMannge.aspx"));
                if (((UserDetail)Session["User"]).KindUser == 10)
                    Menu1.Items.Add(new MenuItem("MenngerPage", "MenngerPage", null, "~/MenngerPage.aspx"));
             //   GroupsDetails groups=((GroupsDetails)Page.Application["Rooms"]);
                GroupsDetails groups = (GroupsDetails)Cache.Get("Rooms");
               if (groups.Rooms.Count != 0)
                {
					this.ListBoxInvate.Items.Clear();
                    foreach (Group i in groups.Rooms)
                    {
                        if (i.IsInGroup(((UserDetail)Session["User"]).UserId))
                        {
                            ListItem ls = new ListItem(i.GroupeName, i.GroupId.ToString());
                            this.ListBoxInvate.Items.Add(ls);
                        }
                    }
                }
				PopIvateGroup();
			}
            List<UserDetail> User = (List<UserDetail>)Page.Application["Users"];
            if (User.Count != 0)
            {
                foreach (UserDetail i in User)
                {
                    this.ListBoxOnllineUser.Items.Add(i.UserName);
                }
            }
        }
		
    }


	protected void ListBoxInvate_SelectedIndexChanged(object sender, EventArgs e)
	{
		Response.Redirect("TheViewMovie.aspx?m=" + ListBoxInvate.SelectedValue);
	}
	public void PopIvateGroup()
	{//מציג את כל הקבוצו שהוזמנתה
		this.ListBoxInvateGroup.Items.Clear();
		GroupServies Gp = new GroupServies();
		DataSet ds = Gp.ShowInvateGroup(((UserDetail)Session["User"]).UserId);
		this.ListBoxInvateGroup.DataSource = ds;
		this.ListBoxInvateGroup.DataTextField=ds.Tables[0].Columns[1].ToString();
		this.ListBoxInvateGroup.DataValueField=ds.Tables[0].Columns[0].ToString();
		this.ListBoxInvateGroup.DataBind();
	}

	protected void ListBoxInvateGroup_SelectedIndexChanged(object sender, EventArgs e)
	{//מאשר הזמנה לקבוצה
		GroupServies Gp = new GroupServies();
		Gp.UpdateToWating(int.Parse(ListBoxInvateGroup.SelectedValue), ((UserDetail)Session["User"]).UserId, 1);
	}
}
