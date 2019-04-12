using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for MovieDetails
/// </summary>
public class MovieDetails
{
    int _MovieId;
    string _MoivesName;
    string _TrailerAdd;
    string _Addres;
    string _YearRate;
    string _Category;
    DateTime _Date;
    string _description;
    string _UrlPicture;
    DataSet _PlayersNRevive;
	public MovieDetails()
	{
		//
		// TODO: Add constructor logic here
		//
        _PlayersNRevive = new DataSet();
	}
    public int MovieId
    {
        get { return _MovieId; }
        set { _MovieId = value; }
    }
    public string MoivesName
    {
        get { return _MoivesName; }
        set { _MoivesName = value; }
    }
    public string TrailerAdd
    {
        get { return _TrailerAdd; }
        set { _TrailerAdd = value; }
    }
    public string Addres
    {
        get { return _Addres; }
        set { _Addres = value; }
    }
    public string YearRate
    {
        get { return _YearRate; }
        set { _YearRate = value; }
    }
    public string Category
    {
        get { return _Category; }
        set { _Category = value; }
    }
    public string description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string UrlPicture
    {
        get { return _UrlPicture; }
        set { _UrlPicture = value; }
    }
    public DateTime Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public DataSet PlayersNRevive
    {
        get { return _PlayersNRevive; }
        set { _PlayersNRevive = value; }
    }

    
}