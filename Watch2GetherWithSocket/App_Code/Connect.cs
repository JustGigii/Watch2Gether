using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect
{
	//קישור לדאטה בייס
	static string connectionString = @"Provider=Microsoft.Jet.oledb.4.0; data source=" + HttpContext.Current.Server.MapPath(@"~\App_Data\Movie2gether.mdb");
	public Connect()//פעולה בונה
	{
	}

	public static string GetInfo()//הפעולה מחזירה את השירשור לכניסה של הדטה בייס
	{ 
		return connectionString;
	}
}