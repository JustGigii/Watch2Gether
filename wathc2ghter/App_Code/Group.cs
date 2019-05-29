using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Groupe
/// </summary>
public class Group
{
    int _GroupId; //מספר הקבוצה;
    string _GroupeName;//שם הקבוצה
    int _KindGroup;//סוג הקבוצה
    int _MenngerGroup;//ה-id של המנהל
    DateTime _DateGroup;//זמן יצירת הקבןצה 
    bool _StatusGroup;//הקבוצה פעילה לא פעילה true פעיל False לא פעיל
    List<int> UserMembers;//חברי הקבוצה
    int _CurrentTime;//נקודת הצפייה תחלילת הסרט היא 0
    int _MovieID;//מספר הסרט משצה ע"י ה-webservice
	string _Chat; // הציג את השיחה בין האנשים באתר
	int _EndMovie;//מחזיר מתי הסרט נגמר
	bool _Active;//מחזיר עם הרט פועל או לא פועל
	public Group()
	{
		_CurrentTime = 0;
        UserMembers = new List<int>();
		_Active = true;
		//
		// TODO: Add constructor logic here
		//
	}//פעולה בונה
    public int GroupId
    {
        get { return this._GroupId; }
        set { this._GroupId = value; }
    }//פעולה Get וSet של משספר קבוצה
    public string GroupeName
    {
        get { return this._GroupeName; }
        set { this._GroupeName = value; }
	}//פעולה Get וSet של משם קבוצה
	public int KindGroup
    {
        get { return this._KindGroup; }
        set { this._KindGroup = value; }
	}//פעולה Get וSet של קוד קבוצה
	public int MenngerGroup
    {
        get { return this._MenngerGroup; }
        set { this._MenngerGroup = value; }
	}//פעולה Get וSet של מנהל קבוצה
	public DateTime DateGroup
    {
        get { return this._DateGroup; }
        set { this._DateGroup = value; }
	}//פעולה Get וSet של זמן פתיחת קבוצה
	public bool StatusGroup
    {
        get { return this._StatusGroup; }
        set { this._StatusGroup = value; }
	}//פעולה Get וSet של פעילות הקבוצה קבוצה
	public List<int> GetUsermembers()
    {
        return this.UserMembers;
    }//פעולה מחיזרה את כל חברי הקבוצה	 
	public void SetUsermembers(List<int> People)
	{
		this.UserMembers = People;
	}//פעולה מקבלת רשימה של חברי קבוצה ומוסיפה אותם לקבוצה		
	public void AddUser(int UserID)
    {
        UserMembers.Add(UserID);
    }//פעולה מקבל קוד משתמש ומוסיפה אותו לקבוצה 
    public int CurrentTime
    {
        get { return this._CurrentTime; }
        set { this._CurrentTime = value; }
	}////פעולה Get וSet של זמן הצפייה של הסרט	  
	public int MovieID
    {
        get { return this._MovieID; }
        set { this._MovieID = value; }

	}//פעולה Get וSet של הסרט הנצפה 
	public bool IsInGroup(int num)
    {
        bool ok= false;
        int counter = 0;
        while (!ok && counter <= UserMembers.Count-1)
        {
            ok = (num == UserMembers[counter]) ? true: false;
            counter++;
        }
        
        return ok;
    }//הפעולה מקבלת מספר משתמש ובודקת עם הוא נמצא בקבוצה
	public String Chat
	{
		get { return _Chat; }
		set { _Chat += value; }
	}//פעולה Get וSet של הצ'ט של הקבוצה			
	public int EndMovie
	{
		get { return this._EndMovie; }
		set { this._EndMovie = value; }
	}//פעולה Get וSet של סוף הסרט
	public bool Active//פעולה Get וSet של פעלות הסרט
	{
		get { return _Active; }
		set { _Active = value;}
	}
}