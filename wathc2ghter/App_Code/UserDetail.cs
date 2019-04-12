using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetail
/// </summary>
public class UserDetail
{
    int _UserId;
    string _UserName;
    string _State;
    string _FirstName;
    string _Email;
    string _Password;
    int _KindUser;
    string _Image;
    string _Description;
    bool _Status;
    string _LastName;
    string _CardID;
    string _dateCard;
    string _SecurityCode;
    DateTime _DateAdd;
    DateTime _birthday;
    public UserDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    public string State
    {
        get { return _State; }
        set { _State = value; }
    }
    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    public string Imagel
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }
    public string CardID
    {
        get { return _CardID; }
        set { _CardID = value; }
    }
    public string dateCard
    {
        get { return _dateCard; }
        set { _dateCard = value; }
    }
    public string SecurityCode
    {
        get { return _SecurityCode; }
        set { _SecurityCode = value; }
    }
    public DateTime birthday
    {
        get { return _birthday; }
        set { _birthday = value; }
    }
    public DateTime DateAdd
    {
        get { return _DateAdd; }
        set { _DateAdd = value; }
    }
    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    public int KindUser
    {
        get { return _KindUser; }
        set { _KindUser = value; }
    }
    public bool Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
}