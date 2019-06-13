using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetail
/// </summary>
public class UserDetail
{
    int _UserId;//מספר משתמש
    string _UserName;//שם משתמש
	string _State;//אזור 
	string _FirstName;//שם
    string _Email;//מייל	
    string _Password;//סיסמה	
    int _KindUser;//סוג משתמש
    string _Image;//תומה של המשתמש	
    string _Description;//תיאור של המשתמש
    bool _Status;//משתמש פעיל או לא
    string _LastName;//שם משפחה	
    string _CardID;//קוד כרטיס
    string _dateCard;//זמן תפוקת הכרטיס
    string _SecurityCode;//קוד הבטחה
    DateTime _DateAdd;//זמן הוספה 
    DateTime _birthday;//יום הולדת
    public UserDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }//פעולה בונה
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
	}
	public string State
    {
        get { return _State; }
        set { _State = value; }
	}//פעולה Get וSet של שם אזור 
	public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
	}//פעולה Get וSet של שם  
	public string Email
    {
        get { return _Email; }
        set { _Email = value; }
	}//פעולה Get וSet של מייל 
	public string Password
    {
        get { return _Password; }
        set { _Password = value; }
	}//פעולה Get וSet של סיסמה 
	public string Imagel
    {
        get { return _Image; }
        set { _Image = value; }
	}//פעולה Get וSet של תמונה 
	public string Description
    {
        get { return _Description; }
        set { _Description = value; }
	}//פעולה Get וSet של תיאור 
	public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
	}//פעולה Get וSet של שם משפחה 
	public string CardID
    {
        get { return _CardID; }
        set { _CardID = value; }
	}//פעולה Get וSet של קוד כרטיס 
	public string dateCard
    {
        get { return _dateCard; }
        set { _dateCard = value; }
	}//פעולה Get וSet של זמן תפוקת הכרטיס 
	public string SecurityCode
    {
        get { return _SecurityCode; }
        set { _SecurityCode = value; }
	}//פעולה Get וSet של קוד הבטחה 
	public DateTime birthday
    {
        get { return _birthday; }
        set { _birthday = value; }
	}//פעולה Get וSet של יום הולדת 
	public DateTime DateAdd
    {
        get { return _DateAdd; }
        set { _DateAdd = value; }
	}//פעולה Get וSet של זמן הוספה 
	public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
	}//פעולה Get וSet של מספר משתמש 
	public int KindUser
    {
        get { return _KindUser; }
        set { _KindUser = value; }
	}//פעולה Get וSet של סוג משתמש 
	public bool Status
    {
        get { return _Status; }
        set { _Status = value; }
	}//פעולה Get וSet של שם סטטוס 
}