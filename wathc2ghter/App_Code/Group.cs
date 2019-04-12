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
    bool _StatusGroup;//הקבוצה פעילה לא פעילה
    List<int> UserMembers;//חברי הקבוצה
    int _CurrentTime;//נקודת הצפייה תחלילת הסרט היא 0
    int _MovieID;//מספר הסרט משצה ע"י ה-webservice
	public Group()
	{
        UserMembers = new List<int>();
		//
		// TODO: Add constructor logic here
		//
	}
    public int GroupId
    {
        get { return this._GroupId; }
        set { this._GroupId = value; }
    }
    public string GroupeName
    {
        get { return this._GroupeName; }
        set { this._GroupeName = value; }
    }
    public int KindGroup
    {
        get { return this._KindGroup; }
        set { this._KindGroup = value; }
    }
    public int MenngerGroup
    {
        get { return this._MenngerGroup; }
        set { this._MenngerGroup = value; }
    }
    public DateTime DateGroup
    {
        get { return this._DateGroup; }
        set { this._DateGroup = value; }
    }
    public bool StatusGroup
    {
        get { return this._StatusGroup; }
        set { this._StatusGroup = value; }
    }
    public List<int> GetUsermembers()
    {
        return this.UserMembers;
    }
	public void SetUsermembers(List<int> People)
	{
		this.UserMembers = People;
	}

	public void AddUser(int UserID)
    {
        UserMembers.Add(UserID);
    }
    public int CurrentTime
    {
        get { return this._CurrentTime; }
        set { this._CurrentTime = value; }
    }
    public int MovieID
    {
        get { return this._MovieID; }
        set { this._MovieID = value; }

    }
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
    }
}