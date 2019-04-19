using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImDb;
using System.Data;

public partial class HomePage : System.Web.UI.Page
{
    DataSet DS;
    protected void Page_Load(object sender, EventArgs e)
    {

		DS = (DataSet)Page.Application["Catlog"];
        if (!Page.IsPostBack)
        {
           
            PopCatalog();
			PopCategory();
        }
      
    }
    public void PopCatalog()
    {
        
        this.DataListCatalog.DataSource = DS;
         this.DataListCatalog.DataBind();
    }
    protected void DataListCatalog_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "show")
        {
            int rowNum = e.Item.ItemIndex;
            string MovieID = DataListCatalog.DataKeys[rowNum].ToString();
            

            Response.Redirect("ExmpleMovie.aspx?m="+MovieID);
        }
    }
	protected void ButtonSortNFilter_Click(object sender, EventArgs e)
	{
		string world = this.TextBoxSerch.Text;
		string sort = "";
		string filter = "";// = 
		switch (int.Parse(this.DropDownListSort.SelectedValue))
		{
			case -1:
				sort = "";
				break;
			case 0:
				sort = "MoiveName";
				break;
			case 1:
				sort = "MoiveName DESC";
				break;
		}
		if (!world.Equals(""))
		{
			if (filter != "") filter += " and";
			switch (int.Parse(this.DropDownListFilter.SelectedValue))
			{
				case 0:
					filter += " MoiveName like '" + world + "*'";
					break;
				case 2:
					filter += " MoiveName like '*" + world + "*'";
					break;
				case 1:
					filter += " MoiveName like '*" + world + "'";
					break;
			}
		}
		SordAndFilter(sort, filter);
	}
	private void SordAndFilter(string sort, string filter)
	{
		DataView View = new DataView(DS.Tables[0]);
		View.Sort = sort;
		View.RowFilter = filter;
		this.DataListCatalog.DataSource = View;
		this.DataListCatalog.DataBind();
	}
	protected void PopCategory()
	{
		ImDb.WebService imdb = new WebService();
		DS = imdb.GetCategory();
		this.DropDownListCategory.DataSource = imdb.GetCategory().Tables[0];
		this.DropDownListCategory.DataTextField = DS.Tables[0].Columns["CategoryName"].ToString();
		this.DropDownListCategory.DataValueField = DS.Tables[0].Columns["CategoryId"].ToString();
		this.DropDownListCategory.DataBind();
		ListItem Ls = new ListItem("All", "");
		this.DropDownListCategory.Items.Add(Ls);

	}

	protected void ButtonCategory_Click(object sender, EventArgs e)
	{
		string sort = "categoryID";
		string filter = (DropDownListCategory.SelectedValue != "")? "categoryID ='" + DropDownListCategory.SelectedValue + "'":""  ;
		SordAndFilter(sort, filter);
	}
}