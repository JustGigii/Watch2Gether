using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login1 : System.Web.UI.Page
{
    DataSet DS;
    UserServies UserServies;
    UserDetail User;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserServies = new UserServies();
        User = new UserDetail();
        DS = (DataSet)Page.Application["DataSetUsers"];
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            User.UserId = UserServies.IsUserValid(TextBoxUserName.Text, TextBoxPass.Text);
            User.UserName = TextBoxUserName.Text;
            User.Password = TextBoxPass.Text;
            if (User.UserId != null && User.Status == false)
            {
                DataRow Row = DS.Tables["Users"].Rows.Find(User.UserId);
                User.State = Row["State"].ToString();
                User.FirstName = Row["FirstName"].ToString();
                User.Email = Row["Email"].ToString();
                User.KindUser = int.Parse(Row["KindUser"].ToString());
                User.Description = Row["Description"].ToString();
                User.Status = bool.Parse(Row["Status"].ToString());
                User.LastName = Row["LastName"].ToString();
                User.CardID = Row["CardID"].ToString(); ;
                User.dateCard = Row["dateCard"].ToString(); ;
                User.SecurityCode = Row["SecurityCode"].ToString(); ;
                User.DateAdd = DateTime.Parse(Row["DateAdd"].ToString());
                User.birthday = DateTime.Parse(Row["birthday"].ToString());
                Session["User"] = User;
                List<UserDetail> Online = (List<UserDetail>)Page.Application["Users"];
                Online.Add(User);
                Page.Application["Users"] = Online;
                Response.Redirect("UpdateUser.aspx");

            }
            else
            {
                Exception Err = new Exception("invalid User");
                throw Err;
            }

        }
        catch (Exception ex)
        {
            LabelErr.Text = ex.Message;
        }
    }
}