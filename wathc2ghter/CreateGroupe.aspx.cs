using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateGroupe : System.Web.UI.Page
{
    Group Group;
    UserDetail User;
    GroupServies GroupCommand;
    UserServies UserCommand;
    protected void Page_Load(object sender, EventArgs e)
    {
        GroupCommand = new GroupServies();
        UserCommand = new UserServies();
        if (!Page.IsPostBack)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");

            }
            else
            {
                User = (UserDetail)Session["User"];
                Session["Group"] = new Group();
            }
        }
        else
            Labelerr.Text = "";
            User = (UserDetail)Session["User"];
            Group = (Group)Session["Group"];
        PopDropDownListKindGourp();
        PopGrid();
    }
    public void PopDropDownListKindGourp()
    {
        DropDownListKindGourp.DataSource = GroupCommand.GetKindGroup();
        DropDownListKindGourp.DataTextField = "Kind";
        DropDownListKindGourp.DataValueField = "KindId";
        DropDownListKindGourp.DataBind();

    }
    public void PopGrid()
    {
        int num = User.UserId;
        this.GridViewFrends.DataSource = UserCommand.PopFriends(num);
        GridViewFrends.DataBind();
    }
    protected void GridViewFrends_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddMember")
        {
            int MemeberID = int.Parse(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[0].Text);
            //if (!Group.IsInGroup(MemeberID))
            //{
                Group.AddUser(MemeberID);
              //  ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[2].Visible = false;
            //}
            //else
            //    Labelerr.Text = "The User Valid In Group";
            Session["Group"] = Group;
            PopGrid();
        }
    }
    protected void ButtonSends_Click(object sender, EventArgs e)
    {
        Group.GroupeName = this.TextBoxGroupeName.Text;
        Group.KindGroup = int.Parse(this.DropDownListKindGourp.SelectedValue);
        Group.DateGroup = DateTime.Now;
        Group.MenngerGroup = ((UserDetail)Session["User"]).UserId;
        GroupCommand.CreateGroup((Group)Session["Group"]);
    }
    protected void GridViewFrends_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType != DataControlRowType.Pager)
        {
            if(Group.IsInGroup(int.Parse(e.Row.Cells[0].Text)))
            e.Row.Cells[2].Enabled = false;
        }
    }
}