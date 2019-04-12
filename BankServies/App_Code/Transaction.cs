using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Transaction
/// </summary>
public class Transaction
{
    int _TransactionID;
    DateTime _DatePosted;
    decimal _amount;
    string _payee;
    string _CreditNumber;
    string _TransactioType;

    public Transaction()
	{
		
	}

    public int TransactionID
    {
        get { return this._TransactionID; }
        set { this._TransactionID = value; }
    }
    public DateTime DatePosted
    {
        get { return this._DatePosted; }
        set { this._DatePosted = value; }
    }
    public decimal Amount
    {
        get { return this._amount; }
        set { this._amount = value; }
    }
    public string Payee
    {
        get { return this._payee; }
        set { this._payee = value; }
    }
    public string CreditNumber
    {
        get { return this._CreditNumber; }
        set { this._CreditNumber = value; }
    }
    public string TransactioType
    {
        get { return this._TransactioType; }
        set { this._TransactioType = value; }
    }
}
