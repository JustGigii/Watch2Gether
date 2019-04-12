using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for CardDetails
/// </summary>
public class CardDetails
{
     string _CardID;
     decimal  _CreditAmount;
     UserDetails _User;
     string _ExpirationDate;
      string _CompanyName;
    int _CompanyCode;
    string _SecurityNumber;
    Transaction[]  _Transactions;

    public CardDetails()
    {
        this._Transactions = new Transaction[0];
    }
    public Transaction[]  Transactions
    {
        get { return _Transactions; }
        set { _Transactions = value; }
        }
public string CardID
    {
        get { return _CardID; }
        set { this._CardID = value; }
    }
    public decimal CreditAmount
    {
        get { return _CreditAmount; }
        set { this._CreditAmount = value; }
    }
    public UserDetails User
{
        get { return _User; }
        set { this._User = value; }
    }
    public string ExpirationDate
{
    get { return _ExpirationDate; }
    set { this._ExpirationDate = value; }
}
public string CompanyName
{
    get { return _CompanyName; }
    set { this._CompanyName = value; }
}
public int CompanyCode
{
    get { return _CompanyCode; }
    set { this._CompanyCode = value; }
}
public string SecurityNumber
{
    get { return _SecurityNumber; }
    set { this._SecurityNumber = value; }
}
}