using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect : Movie_s_Servies
{
	static string connectionString = @"Provider=Microsoft.Jet.oledb.4.0; data source=" + HttpContext.Current.Server.MapPath(@"~\App_Data\IMDB.mdb");
	//קישור לכניסה לטטה בייס
	public Connect()
	{
	}//פעולה בונה		
	public static string GetInfo()
	{
		return connectionString;
	}//שולח את שישור הקישור
}