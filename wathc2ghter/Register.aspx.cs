using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register1 : System.Web.UI.Page
{
    UserServies UserServies;
    UserDetail User;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            poplateDDLYear();
            populateDDLMonth();
            populateDays();
            string xml = "https://gist.githubusercontent.com/nathanhornby/4727009/raw/86eea19828e19455fe4082a989521f32f7006e9a/XML%2520Country%2520List";
            DataSet ds = new DataSet();
            ds.ReadXml(xml);
            this.DropDownListState.DataSource = ds;
            this.DropDownListState.DataTextField = "handle";
            this.DropDownListState.DataBind();
        }
        else
        {
            User = new UserDetail();
            UserServies = new UserServies();
        }
    }
    private void populateDDLMonth()
    {
        this.DropDownListDay.Items.Clear();
        ListItem li = new ListItem("בחר חודש", "0");
        for (int i = 1; i <= 12; i++)
        {
            DropDownListMonth.Items.Add(i.ToString());
        }
    }

    private void poplateDDLYear()
    {//מעדכן שנה
        this.DropDownListDay.Items.Clear();
        ListItem li = new ListItem("בחר שנה", "0");
        for (int i = DateTime.Today.Year; i > DateTime.Today.Year - 120; i--)
        {
            DropDownListYears.Items.Add(i.ToString());
        }
    }
    private void populateDays()
    {//מעדכן יום
        this.DropDownListDay.Items.Clear();
        ListItem li = new ListItem("בחר יום", "0");
        this.DropDownListDay.Items.Add(li);
        for (int i = 1; i <= DateTime.DaysInMonth(int.Parse(DropDownListYears.SelectedValue), int.Parse(DropDownListMonth.SelectedValue)); i++)
        {
            DropDownListDay.Items.Add(i.ToString());
        }
    }

    protected void ButtonSend_Click(object sender, EventArgs e)
    {//מעדכן פרטים בdatabase
        User.UserId = 0;
        User.UserName = this.TextBoxUname.Text;
        User.State = this.DropDownListState.SelectedValue;
        User.FirstName = this.TextBoxFname.Text;
        User.Email = this.TextBoxmail.Text;
        User.Password = this.TextBoxPass.Text;
        User.KindUser = 1;
        User.Imagel = "null";
        User.Description = "Description";
        User.Status = true;
        User.LastName = this.TextBoxLname.Text;
        User.CardID = "0";
        User.dateCard = "0";
        User.SecurityCode = "0";
        User.DateAdd = DateTime.Now;
        User.birthday = new DateTime(int.Parse(this.DropDownListYears.SelectedValue), int.Parse(this.DropDownListMonth.SelectedValue), int.Parse(this.DropDownListDay.SelectedValue));
        try
        {
            UserServies.AddUser(User);
        }
        catch (Exception err)
        {
            Labelerr.Text = err.Message;
        }
        Session["User"] = User;
    }
}