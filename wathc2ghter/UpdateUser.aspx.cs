using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UpdateUser1 : System.Web.UI.Page
{
    UserDetail User;
    UserServies UserCommand;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserCommand = new UserServies();
        if (!Page.IsPostBack)
        {
            User = new UserDetail();
            TableDEtails.Visible = false;
            TableDEtails.Enabled = false;
			TableUpgrade.Visible = false;
			TableUpgrade.Enabled = false;
            if (Session["User"] == null)
                Response.Redirect("login.aspx");
            else
            {
                User = (UserDetail)Session["User"];
                UserCommand = new UserServies();
				if (User.KindUser <= 1)
				{
					
					Buttonupgrade.Enabled = true;
					poplateDDLYear();
					populateDDLMonth();


				}
			}

        }
        User = (UserDetail)Session["User"];
    }

    protected void buttonShopProfileDetails_Click(object sender, EventArgs e)
    {
        if (this.buttonShopProfileDetails.Text != "Submit")
        {
            try
            {
                string pass = this.TextBoxPass.Text;
                string UserName = User.UserName;
                int num = UserCommand.IsUserValid(UserName, pass);
                if (num != null)
                {
                    TableDEtails.Visible = true;
                    TableDEtails.Enabled = true;
                    TextBoxPass.Visible = false;
                    LabelPass.Visible = false;
                    this.buttonShopProfileDetails.Text = "Submit";
                    PopText();
                }
            }
            catch (Exception Err)
            {
                LabelERR.Text = Err.Message;
            }
        }
        else
        {
            try
            {
                User.UserName = this.TextBoxUname.Text;
                User.State = this.DropDownListState.SelectedValue;
                User.FirstName = this.TextBoxFname.Text;
                User.Email = this.TextBoxmail.Text;
                User.Password = this.TextBoxPass.Text;
				User.LastName = this.TextBoxLname.Text;
                UserCommand.UpdateUserServer(User);
                TableDEtails.Visible = false;
                TableDEtails.Enabled = false;
                TextBoxPass.Visible = true;
                this.buttonShopProfileDetails.Text = "ShowProfileDetail";
            }
            catch (Exception Err)
            {
                LabelERR.Text = Err.Message;
            }
        }

    }
    protected void PopText()
    {//פעולה מעלה את כל הפרטים של המשתמש
        TextBoxFname.Text = User.FirstName;
        TextBoxLname.Text = User.LastName;
        TextBoxUname.Text = User.UserName;
        TextBoxPasst.Text = User.Password;
        foreach (ListItem i in DropDownListState.Items)
        {
            if (i.Value == User.State)
                i.Selected = true;
            else
                i.Selected = false;
        }
        foreach (ListItem i in DropDownListMonth.Items)
        {
            if (int.Parse(i.Value) == User.birthday.Month)
                i.Selected = true;
            else
                i.Selected = false;
        }
        TextBoxmail.Text = User.Email;
        Image1.ImageUrl = User.Imagel;
        TextBoxmail.Text = User.Email;
        Image1.ImageUrl = User.Imagel;
        string xml = "https://gist.githubusercontent.com/nathanhornby/4727009/raw/86eea19828e19455fe4082a989521f32f7006e9a/XML%2520Country%2520List";
        DataSet DataState = new DataSet();
        DataState.ReadXml(xml);
        this.DropDownListState.DataSource = DataState;
        this.DropDownListState.DataTextField = "handle";
        this.DropDownListState.DataBind();
    }
    private void populateDDLMonth()
    {
        ListItem li = new ListItem("בחר חודש", "0");
        for (int i = 1; i <= 12; i++)
        {
            DropDownListMonth.Items.Add(i.ToString());
        }
    }

    private void poplateDDLYear()
    {//מעדכן שנה
        ListItem li = new ListItem("בחר שנה", "0");
        for (int i = DateTime.Today.Year; i < DateTime.Today.Year + 12; i++)
        {
            DropDownListYears.Items.Add(i.ToString());
        }
    }
    protected void ButtonCancelUser_Click(object sender, EventArgs e)
    {
        this.ButtonCancelUser.Attributes["onclick"] = "javascript:return confirm('are you sure delete your Accound')";
        User.Status = false;
    }

    protected void Buttonupgrade_Click(object sender, EventArgs e)
    {
        if (this.Buttonupgrade.Text != "Submit")
        {
            try
            {
                TableUpgrade.Visible = true;
                TableUpgrade.Enabled = true;
				poplateDDLYear();
				populateDDLMonth();
				this.Buttonupgrade.Text = "Submit";
            }
            catch (Exception Err)
            {
                LabelERR.Text = Err.Message;
            }
        }
        else
        {
            try
            {
				//בודק
				
                WebCreditService.CardDetails card = new WebCreditService.CardDetails();
                card.CardID =this.TextBoxCardId.Text;
                card.ExpirationDate = this.DropDownListMonth.SelectedValue + "/" + this.DropDownListYears.SelectedValue;
                card.SecurityNumber = this.TextBoxCVS.Text;
                WebCreditService.WebCreditService web = new WebCreditService.WebCreditService();
                if (web.CheckCard(card))
                { 
                    WebCreditService.Transaction Trc = new WebCreditService.Transaction();
                    Trc.Payee = "31";
                    Trc.Amount = 60;
                    Trc.DatePosted = DateTime.Now;
                    Trc.CreditNumber = card.CardID;
                    Trc.TransactioType = "חובה";
                    web.insertTransaction(Trc);
                    //User.CardID = this.TextBoxCardId.Text;
                    //User.dateCard = this.DropDownListMonth.SelectedValue + "/" + this.DropDownListYears.SelectedValue;
                    //User.SecurityCode = this.TextBoxCVS.Text;
                    User.KindUser = 5;
					Session["User"] = User;
					UserCommand.UpdateUserServer(User);
                    TableUpgrade.Visible = false;
                    TableUpgrade.Enabled = false;
                    this.Buttonupgrade.Text = "upgrade Your accound";
                }
                else
                    LabelERR.Text = "your card not valid"; 
            }
            catch (Exception Err)
            {
                LabelERR.Text = Err.Message;
            }
        }
    }
}