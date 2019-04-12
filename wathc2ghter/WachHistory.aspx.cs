using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class WachHistory : System.Web.UI.Page
{
    Group Group;
    UserDetail User;
    GroupServies GroupCommand;
    UserServies UserCommand;
    DataSet Ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Ds = new DataSet();
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
            }
        }
        User = (UserDetail)Session["User"];
        PopUserHistory();
    }
    protected void ButtonUser_Click(object sender, EventArgs e)
    {//מציד צפייה יחדנית
        PopUserHistory();
        this.GridViewHistoryGroup.Visible = false;
        this.GridViewHistoryUser.Visible = true;
    }
    protected void PopUserHistory()
    {//מציג  את טבלת הסרטים מהdataset
        Ds = UserCommand.ViewHistoryWach(User.UserId);
        this.GridViewHistoryUser.DataSource = Ds.Tables["UserHistory"];
        GridViewHistoryUser.DataBind();

    }
    protected void PopGroupHistory()
    {//מציד מה דטדה סט את הסרטים שצפה בקבוצה
        Ds = UserCommand.ViewHistoryWach(User.UserId);
        this.GridViewHistoryGroup.DataSource = Ds.Tables["GroupHistory"];
        GridViewHistoryGroup.DataBind();
    }
    protected void ButtonGroupWach_Click(object sender, EventArgs e)
    {//משנה לטבלת צפיית קבוצה
        PopGroupHistory();
        this.GridViewHistoryGroup.Visible = true;
        this.GridViewHistoryUser.Visible = false;
    }
}