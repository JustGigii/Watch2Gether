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
    int _MovieId;//מספר הסרט
    string _MoivesName;//שם הסרט
    string _TrailerAdd;//קישור לטריילר של סרט
    string _Addres;//קישור לסרט
    string _YearRate;//הקבלה גיל
    string _Category;//קטגוריה
    DateTime _Date;//תאריך שעולה הסרט
    string _description;//תיאור הסרט
    string _UrlPicture;//תמונת של הסרט
    DataSet _PlayersNRevive;//שקחנים בסרט
	public MovieDetails()
	{
		//
		// TODO: Add constructor logic here
		//
        _PlayersNRevive = new DataSet();
	}//פעולה בונה
    public int MovieId
    {
        get { return _MovieId; }
        set { _MovieId = value; }
    }//פרופרטיס של מספר הסרט
    public string MoivesName
    {
        get { return _MoivesName; }
        set { _MoivesName = value; }
	}//פרופרטיס של שם הסרט
	public string TrailerAdd
    {
        get { return _TrailerAdd; }
        set { _TrailerAdd = value; }
	}//פרופרטיס של קישור טריילר של הסרט
	public string Addres
    {
        get { return _Addres; }
        set { _Addres = value; }
	}//פרופרטיס של קישור הסרט
	public string YearRate
    {
        get { return _YearRate; }
        set { _YearRate = value; }
	}//פרופרטיס של הגבלת גיל
	public string Category
    {
        get { return _Category; }
        set { _Category = value; }
	}//פרופרטיס של קתגוריה של הסרט
	public string description
    {
        get { return _description; }
        set { _description = value; }
	}//פרופרטיס של תיאור הסרט
	public string UrlPicture
    {
        get { return _UrlPicture; }
        set { _UrlPicture = value; }
	}//פרופרטיס של צתמונת הסרט
	public DateTime Date
    {
        get { return _Date; }
        set { _Date = value; }
	}//פרופרטיס של זמן שעלה הסרט
	public DataSet PlayersNRevive
    {
        get { return _PlayersNRevive; }
        set { _PlayersNRevive = value; }
	}//פרופרטיס של שחקנים שחקו בסרט


}