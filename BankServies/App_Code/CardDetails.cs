using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for CardDetails
/// </summary>
public class CardDetails
{
     string _CardID;//מספר תעודת זהות
     decimal  _CreditAmount;//מספר 
     string _ExpirationDate;//תאריך דפוגה של הכרטיס
      string _CompanyName;//שם חברה
    int _CompanyCode;//קוד החברה
    string _SecurityNumber;//מספר הבטחה
    Transaction[]  _Transactions;//מבצע עברה תשלום

    public CardDetails()
    {
        this._Transactions = new Transaction[0];
    }//פעולה בונה
    public Transaction[]  Transactions
    {
        get { return _Transactions; }
        set { _Transactions = value; }


	}//פרפרטיס של עברה תשלום
	public string CardID
    {
        get { return _CardID; }
        set { this._CardID = value; }
	}//פרפרטיס של מספר הכרטיס
	public decimal CreditAmount
    {
        get { return _CreditAmount; }
        set { this._CreditAmount = value; }
	}//פרפרטיס של סכום הכסף בחשבון
	public string ExpirationDate
{
    get { return _ExpirationDate; }
    set { this._ExpirationDate = value; }
	}//פרפרטיס של מספר התפוגה של הכרטיס
	public string CompanyName
{
    get { return _CompanyName; }
    set { this._CompanyName = value; }
	}//פרפרטיס של שם החברה
	public int CompanyCode
{
    get { return _CompanyCode; }
    set { this._CompanyCode = value; }
}//מספר החברה
	public string SecurityNumber
{
    get { return _SecurityNumber; }
    set { this._SecurityNumber = value; }
	}//פרפרטיס של מספר הבטחה
}