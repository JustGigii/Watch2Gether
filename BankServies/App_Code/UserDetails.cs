using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class UserDetails
{
    string _UserID;
    string _FirstName;
    string _LastName;
    string _UserName;
    string _PassWord;
   

    public string UserID
    {
        get { return this._UserID; }
        set { this._UserID = value ;}
    }
    public string FirstName
    {
        get { return this._FirstName; }
        set { this._FirstName = value; }
    }
    public string LastName
    {
        get { return this._LastName; }
        set { this._LastName = value; }
    }
    public string UserName
    {
        get { return this._UserName; }
        set { this._UserName = value; }
    }
    public string Password
    {
        get { return this._PassWord; }
        set { this._PassWord = value; }
    }
    public UserDetails()
	{
	}
}
