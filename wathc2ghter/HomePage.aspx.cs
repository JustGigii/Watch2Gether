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
}