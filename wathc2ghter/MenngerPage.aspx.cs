using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MenngerPage1 : System.Web.UI.Page
{
    UserDetail Member;
    DataSet DS;
    UserServies Commands;
    int sum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Member = new UserDetail();
        Commands = new UserServies();
            DS = new DataSet();
		DS = Commands.FillAllUsers();
		popGird();


	}
    public void popGird()
    {//הפעולה מציגה את הטבלה
        this.GridViewUsers.DataSource = DS; 
        this.GridViewUsers.DataBind();
    }
    protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //   Label1.Text = e.CommandArgument.ToString();
        // Label2.Text = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[1].Text;

    }
    protected void GridViewUsers_RowEditing1(object sender, GridViewEditEventArgs e)
    {//הפעולה מכניסה את הטבלה למצב עריכה
        this.GridViewUsers.EditIndex = e.NewEditIndex;
        popGird();
    }
    protected void GridViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {//הפעולה מבטלת את מצב עריכה
        this.GridViewUsers.EditIndex = -1;
        popGird();
    }
    protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType != DataControlRowType.Pager)
        {
            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) || e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Normal))
            {
                for (int i = 1; i <= 12; i++)
                {
                    object o = e.Row.Cells[5].FindControl("DropDownListMonth");
                    ((DropDownList)(e.Row.Cells[5].FindControl("DropDownListMonth"))).Items.Add(i.ToString());
                }
                for (int l = DateTime.Today.Year; l > DateTime.Today.Year - 120; l--)
                {
                    ((DropDownList)e.Row.Cells[5].FindControl("DropDownListYear")).Items.Add(l.ToString());

                }
                for (int j = 1; j <= 31; j++)
                {
                    ((DropDownList)e.Row.Cells[5].FindControl("DropDownListDay")).Items.Add(j.ToString());
                }
            }
        }
    }
    protected void GridViewUsers_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        this.GridViewUsers.PageIndex = e.NewPageIndex;
        popGird();
    }

    protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {//הפונקציה מעדכמת את פרטי המשתמש
        try
        {
            Member.UserId = int.Parse(GridViewUsers.Rows[e.RowIndex].Cells[0].Text);
            Member.UserName = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            Member.FirstName = GridViewUsers.Rows[e.RowIndex].Cells[2].Text;
            Member.LastName = GridViewUsers.Rows[e.RowIndex].Cells[3].Text;
			Member.State = ((DropDownList)(GridViewUsers.Rows[e.RowIndex].Cells[4].FindControl("DropDownListState"))).SelectedValue;
            Member.birthday = DateTime.Parse(((DropDownList)GridViewUsers.Rows[e.RowIndex].Cells[5].FindControl("DropDownListYear")).SelectedValue+"." + ((DropDownList)GridViewUsers.Rows[e.RowIndex].Cells[5].FindControl("DropDownListMonth")).SelectedValue +"."+ ((DropDownList)GridViewUsers.Rows[e.RowIndex].Cells[5].FindControl("DropDownListDay")).SelectedValue);
            Member.Email = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
            Member.Password = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[7].Controls[0])).Text;
            Member.KindUser = int.Parse(((DropDownList)(GridViewUsers.Rows[e.RowIndex].Cells[8].FindControl("DropDownListKindUser"))).SelectedValue);
            Member.Status = bool.Parse(((RadioButtonList)(GridViewUsers.Rows[e.RowIndex].Cells[9].FindControl("RadioButtonListStatus"))).SelectedValue);
            Member.DateAdd = DateTime.Parse(GridViewUsers.Rows[e.RowIndex].Cells[10].Text);
			Member.CardID = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[11].Controls[0])).Text;
            Member.dateCard = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[12].Controls[0])).Text;
            Member.SecurityCode = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[13].Controls[0])).Text;
            Commands.UpdateUserServer(Member);
            this.GridViewUsers.EditIndex = -1;
            popGird();
        }
        catch (Exception err) { LabelErr.Text = err.Message;}
    }
    private void SordAndFilter(string sort, string filter)
    {
        DataView View = new DataView(DS.Tables["Users"]);
        View.Sort = sort;
        View.RowFilter = filter;
        this.GridViewUsers.DataSource = View;
        this.GridViewUsers.DataBind();
    }

    protected void ButtonSortNFilter_Click(object sender, EventArgs e)
    {
        string world = this.TextBoxSerch.Text;
        string sort = "";
        string filter = "";// = 
        switch (int.Parse(this.DropDownListSort.SelectedValue))
        {
            case 0:
                sort = "UserID";
                break;
            case 1:
                sort = "UserID DESC";
                break;
            case 2:
                sort = "UserName";
                break;
            case 3:
                sort = "UserName DESC";
                break;

        }
        if (!world.Equals(""))
        {
            if (filter != "") filter += " and";
            switch (int.Parse(this.DropDownListFilter.SelectedValue))
            {
                case 0: filter += " UserName like '" + world + "*'";
                    break;
                case 2: filter += " UserName like '*" + world + "*'";
                    break;
                case 1: filter += " UserName like '*" + world + "'";
                    break;
            }
        }
        SordAndFilter(sort, filter);
    }
    protected void ButtonStatusView_Click(object sender, EventArgs e)
    {
        string world = this.TextBoxSerch.Text;
        string sort = "";
        string filter = "";// = 
        switch (int.Parse(this.DropDownListSort.SelectedValue))
        {
            case 0:
                sort = "UserID";
                break;
            case 1:
                sort = "UserID DESC";
                break;
            case 2:
                sort = "UserName";
                break;
            case 3:
                sort = "UserName DESC";
                break;

        }
        if (!world.Equals(""))
        {
            if (filter != "") filter += " and";
            switch (int.Parse(this.DropDownListFilter.SelectedValue))
            {
                case 0: filter += " UserName like '" + world + "*'";
                    break;
                case 2: filter += " UserName like '*" + world + "*'";
                    break;
                case 1: filter += " UserName like '*" + world + "'";
                    break;
            }
        }
        if (this.ButtonStatusView.Text == "Hide Status")
        {
            filter += " Status = False";
            this.ButtonStatusView.Text = "View Status";
        }
        else
        {
            filter += " Status = True";
            this.ButtonStatusView.Text = "Hide Status";
        }
        SordAndFilter(sort, filter);
    }
}