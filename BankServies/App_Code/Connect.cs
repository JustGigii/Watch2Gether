using System;
using System.Web;
public class Connect : CardsService
{
	public static string getConnectionString()
	{//string location = HttpContext.Current.Server.MapPath("@../../App_Data/" + FILENAME);
		return "Provider=Microsoft.Jet.OLEDB.4.0; data source=" + HttpContext.Current.Server.MapPath("~/App_Data/" + "creditCard.mdb");
	}//קישור לדטה בייס
}

