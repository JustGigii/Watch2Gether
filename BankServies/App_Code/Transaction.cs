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
    int _TransactionID;//מספר העברה
    DateTime _DatePosted;//זמן העברה
    decimal _amount;//כמות העברה
    string _payee;//למי התשלום
    string _CreditNumber;//מספר כרטיס
    string _TransactioType;//סוג העברה
    public Transaction()
	{
		
	}//פעולה בונה
    public int TransactionID
    {
        get { return this._TransactionID; }
        set { this._TransactionID = value; }
    }//פרופרטיס של מספר העברה
    public DateTime DatePosted
    {
        get { return this._DatePosted; }
        set { this._DatePosted = value; }
	}// פרופרטיס של זמן העברה
	public decimal Amount
    {
        get { return this._amount; }
        set { this._amount = value; }
	}//פרופרטיס של כמות העברה
	public string Payee
    {
        get { return this._payee; }
        set { this._payee = value; }
	}//פרופרטיס של למי התשלום
	public string CreditNumber
    {
        get { return this._CreditNumber; }
        set { this._CreditNumber = value; }
	}//פרופרטיס של מספר כרטיס
	public string TransactioType
    {
        get { return this._TransactioType; }
        set { this._TransactioType = value; }
	}//פרופרטיס של סוג העברה
}
