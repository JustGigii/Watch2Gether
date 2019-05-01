using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomePage_ExmpleMovie : System.Web.UI.Page
{
    public DataSet Ds;
    public string MovieId;
    protected void Page_Load(object sender, EventArgs e)
    {
        MovieId = Request.QueryString["m"];
        if (!Page.IsPostBack)
        {
            if (MovieId == null)
                Response.Redirect("HomePage.aspx");
            if (Session["User"] == null)
                this.ButtonWatch.Enabled = false;
                PopMoiveDetails();
        }

    }
    public void PopMoiveDetails()
    {
        ImDb.WebService Wb = new ImDb.WebService();
        ImDb.MovieDetails Movie = Wb.GetMoviesDetails(int.Parse(MovieId));
        this.LabelMovieName.Text = Movie.MoivesName;
        this.LabelDescription.Text = Movie.description;
        this.ImageMoviePhoto.ImageUrl = Movie.UrlPicture;
        this.LabelYearRate.Text += Movie.YearRate;
        this.LabelDate.Text += Movie.Date.ToShortDateString();
        this.Labelcategory.Text = Movie.Category;
        this.DataListPlayers.DataSource = Movie.PlayersNRevive.Tables["PlayersTBbl"];
        this.DataListPlayers.DataBind();
        this.DataListReview.DataSource = Movie.PlayersNRevive.Tables["ReviewsTBbl"];
        this.DataListReview.DataBind();
    }
    protected void ButtonTrailler_Click(object sender, EventArgs e)
    {
        ImDb.WebService Wb = new ImDb.WebService();
        ImDb.MovieDetails Movie = Wb.GetMoviesDetails(int.Parse(MovieId));
        Response.Redirect(Movie.TrailerAdd);
    }
    protected void ButtonWatch_Click(object sender, EventArgs e)
    {
        if (((UserDetail)Session["User"]).KindUser >= 5)
        {
            ListBoxGroup.Visible = true;
            ListBoxGroup.Enabled = true;
            GroupServies Gr = new GroupServies();
            Ds = new DataSet();
            Ds = Gr.ShowUserGoup(((UserDetail)Session["User"]).UserId);
            ListBoxGroup.DataSource = Ds.Tables["Group"];
            ListBoxGroup.DataTextField = Ds.Tables["Group"].Columns["GroupName"].ToString();
            ListBoxGroup.DataValueField = Ds.Tables["Group"].Columns["GroupId"].ToString();
            ListBoxGroup.DataBind();
            ListItem LI = new ListItem("Alone", "Null");
            ListBoxGroup.Items.Add(LI);
        }
        else
        {
            UserServies Command = new UserServies();
			Command.AddToHistory(int.Parse(MovieId), ((UserDetail)Session["User"]).UserId);
            Response.Redirect("TheViewMovie.aspx?m=" + MovieId);
        }
    }
    protected void ListBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
       if ( ListBoxGroup.SelectedValue == "Null")
           Response.Redirect("TheViewMovie.aspx?m=" + MovieId);
        else
       {
           Group Group = new Group();
			GroupServies Groupcommand = new GroupServies();
			 Group = Groupcommand.GetGroupToWatch(int.Parse(ListBoxGroup.SelectedValue), int.Parse(MovieId));
			//((GroupsDetails)Application["Rooms"]).AddToGroup(Group);
           GroupsDetails g=(GroupsDetails) Cache.Get("Rooms");
           g.AddToGroup(Group);
          Cache.Insert("Rooms", g);
			Group.MenngerGroup = ((UserDetail)Session["User"]).UserId;
				Response.Redirect("TheViewMovie.aspx?m=" + Group.GroupId);


		}
    }
}