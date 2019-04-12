using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Collections;
using System.ComponentModel;
using System.Web.UI.HtmlControls;

public class CardsService
{
    private OleDbConnection objConn;
    private OleDbCommand objCmd;
    private OleDbTransaction objTrans;
    private string connectionString;

    public string ConnectionString
    {
        get
        { return this.connectionString; }
        set
        { this.connectionString = value; }
    }
   
    public CardsService()
    {
        this.connectionString = Connect.getConnectionString();
        objConn = new OleDbConnection(this.connectionString);
    }


    public DataSet GetCompanies()
    {
        objCmd = new OleDbCommand("GetCompanies", objConn);
        objCmd.CommandType = CommandType.StoredProcedure;


        try
        {
            objConn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(objCmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "CreditCompanies");
            return dataSet;
        }
        catch (Exception ex)
        { return null; }
        finally
        { objConn.Close(); }

    }
    /// <summary>
    /// insert New Transaction
    /// </summary>
    /// <param name="transaction"></param>

    public bool insertTransaction(Transaction transaction)
    {


        objCmd = new OleDbCommand("spInsertTransaction", objConn);
        objCmd.Transaction = objTrans;
        objCmd.CommandType = CommandType.StoredProcedure;

        //set parameters for storde procedure

        OleDbParameter objParam;
        objParam = objCmd.Parameters.Add("@DatePosted", OleDbType.Date);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = System.DateTime.Now;

        objParam = objCmd.Parameters.Add("@Amount", OleDbType.Currency);
        objParam.Direction = ParameterDirection.Input;
       objParam.Value = transaction.Amount;
     

        objParam = objCmd.Parameters.Add("@Payee", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = transaction.Payee;

        objParam = objCmd.Parameters.Add("@CreditNumber", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = transaction.CreditNumber;

        objParam = objCmd.Parameters.Add("@TransactioType", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = transaction.TransactioType;
        try
        {
            objCmd.Connection.Open();
           int num= objCmd.ExecuteNonQuery();
            return num > 0;

        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            objCmd.Connection.Close();
        }

    }
  

    public bool CheckCard(CardDetails card)
        //מקבלת פרטי כרטיס אשראי ומחזירה אמת אם פרטי הכרטיס תקינים והכרטיס שייך למשתמש
    {
        //long total = long.Parse(card.CardID);
        //int sum = Check_id(ref total);
        //if (sum % 10 != 0)
        //return false;
        try
        {
            objConn.Open();
            objCmd = new OleDbCommand("IdCheak", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter Param = new OleDbParameter();
            Param = objCmd.Parameters.Add("@CardID", OleDbType.BSTR);
            Param.Value = card.CardID;
            Param = objCmd.Parameters.Add("@ExpirationDate", OleDbType.BSTR);
            Param.Value = card.ExpirationDate;
            Param = objCmd.Parameters.Add("@SecurityNumber", OleDbType.BSTR);
            Param.Value = card.SecurityNumber;
            object UserID = objCmd.ExecuteScalar();
            if (UserID != null)
                return true;
            return false;
        }
        catch (Exception Err)
        {
            throw Err;
        }
        finally { objConn.Close(); }
        
    }
    private static int Check_id(ref int total)
    {//בוקת את ספירת הביקורת של התעודת זהות
        int div;
        int sum = 0;
        int i = 1;
        while (total > 0)
        {
            div = total % 10;
            div *= i;
            if (div >= 10)
                sum += div / 10 + div % 10;
            else
                sum += div;
            if (i == 1)
                i++;
            else
                i--;
            total = total / 10;
        }
        return sum;
    }

}
