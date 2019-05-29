using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UserServies 
{
	protected OleDbCommand Mycommand;//פקודות לבסיס הנתונים
	protected OleDbDataAdapter adapter;//פעולה מחברת בין בסיס הנתונים לדטה סט
	protected OleDbConnection MyConnction;//מפעולת חיבור בין בסיס הנתונים לתוכנה
	protected OleDbTransaction Transaction;//אחרי על מספר שינויים בדטה בייס
	DataSet ds;//דטה סט
	public UserServies()
	{
		MyConnction = new OleDbConnection(Connect.GetInfo());
		ds = new DataSet();
		adapter = new OleDbDataAdapter("select * from Users", Connect.GetInfo());
		
		//
		// TODO: Add constructor logic here
		//
	}//פעולה בונה
	private DataSet Convert2dataset()//פעולה יוצרת טבלה חדשה שיש את כל מה שצריך להכיל בUser
	{

		DataTable Dt = new DataTable();
		Dt.TableName = "Users";
		Dt.Columns.Add("UserId");
		Dt.Columns.Add("UserName");
		Dt.Columns.Add("State");
		Dt.Columns.Add("FirstName");
		Dt.Columns.Add("Email");
		Dt.Columns.Add("Password");
		Dt.Columns.Add("KindUser");
		Dt.Columns.Add("Image");
		Dt.Columns.Add("Description");
		Dt.Columns.Add("Status");
		Dt.Columns.Add("LastName");
		Dt.Columns.Add("CardID");
		Dt.Columns.Add("dateCard");
		Dt.Columns.Add("SecurityCode");
		Dt.Columns.Add("DateAdd");
		Dt.Columns.Add("birthday");
		Dt.PrimaryKey = new DataColumn[] { Dt.Columns["UserId"] };
		ds.Tables.Add(Dt);
		return ds;
	}
	public void AddUser(UserDetail user)//מעדכן פרטים בdatabes 
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("AddUser", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@UserName", OleDbType.BSTR);
			parm.Value = user.UserName;
			parm = Mycommand.Parameters.Add("@State", OleDbType.BSTR);
			parm.Value = user.State;
			parm = Mycommand.Parameters.Add("@FirstName", OleDbType.BSTR);
			parm.Value = user.FirstName;
			parm = Mycommand.Parameters.Add("@Email", OleDbType.BSTR);
			parm.Value = user.Email;
			parm = Mycommand.Parameters.Add("@Password", OleDbType.BSTR);
			parm.Value = user.Password;
			parm = Mycommand.Parameters.Add("@KindUser", OleDbType.Integer);
			parm.Value = user.KindUser;
			parm = Mycommand.Parameters.Add("@Image", OleDbType.BSTR);
			parm.Value = user.Imagel;
			parm = Mycommand.Parameters.Add("@Description", OleDbType.BSTR);
			parm.Value = user.Description;
			parm = Mycommand.Parameters.Add("@Status", OleDbType.Boolean);
			parm.Value = user.Status;
			parm = Mycommand.Parameters.Add("@LastName", OleDbType.BSTR);
			parm.Value = user.LastName;
			parm = Mycommand.Parameters.Add("@CardID", OleDbType.BSTR);
			parm.Value = user.CardID;
			parm = Mycommand.Parameters.Add("@dateCard", OleDbType.BSTR);
			parm.Value = user.dateCard;
			parm = Mycommand.Parameters.Add("@SecurityCode", OleDbType.BSTR);
			parm.Value = user.SecurityCode;
			parm = Mycommand.Parameters.Add("@DateAdd", OleDbType.Date);
			parm.Value = user.DateAdd;
			parm = Mycommand.Parameters.Add("@birthday", OleDbType.Date);
			parm.Value = user.birthday;
			Mycommand.ExecuteNonQuery();
		}
		catch (Exception err) { throw err; }
		finally { MyConnction.Close(); }
	}
	public int IsUserValid(string name, string pass)//בודק עם המשתמש נמצעה בדטה בייס עם נמצאה אז שולח 
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("IsEnbale", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@user", OleDbType.BSTR);
			parm.Value = name;
			parm = Mycommand.Parameters.Add("@Password", OleDbType.BSTR);
			parm.Value = pass;
			if (Mycommand.ExecuteScalar() != null)
			{
				return int.Parse(Mycommand.ExecuteScalar().ToString());
			}
			else
			{
				Exception Er = new Exception("your password or username incorect");
				throw Er;
			}
		}
		catch (Exception Err)
		{
			throw Err;
		}
		finally { MyConnction.Close(); }
	}
	public int IsUserValidName(string name)//בודק עם המשתמש נמצעה בדטה בייס עם נמצאה אז שולח את מספר של המשתמש
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("IsEnbaleOnlyName", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@user", OleDbType.BSTR);
			parm.Value = name;
			if (Mycommand.ExecuteScalar() != null)
			{
				return int.Parse(Mycommand.ExecuteScalar().ToString());
			}
			else
			{
				Exception Er = new Exception("username incorect");
				throw Er;
			}
		}
		catch (Exception Err)
		{
			throw Err;
		}
		finally { MyConnction.Close(); }
	}
	public DataSet FillAllUsers(DataSet Dataset)//הפעעולה ממעלה את כל בדתה סט בטבלת יוסרס
	{
		try
		{
			MyConnction.Open();
		//	Dataset = Convert2dataset();
			adapter.Fill(ds,"Users");
            ds.Tables["Users"].PrimaryKey = new DataColumn[] { ds.Tables["Users"].Columns["UserId"] };
            
			return ds;
		}
		catch (Exception Err) { throw Err; }
		finally { MyConnction.Close(); }
	}
	public DataSet FillAllUsers()//הפעעולה ממעלה את כל בדתה סט בטבלת יוסרס
	{
		try
		{
			MyConnction.Open();
		//	ds = Convert2dataset();
            adapter.Fill(ds, "Users");
            ds.Tables["Users"].PrimaryKey = new DataColumn[] { ds.Tables["Users"].Columns["UserId"] };
			return ds;
		}
		catch (Exception Err) { throw Err; }
		finally { MyConnction.Close(); }
	}
	public void UpdateUserServer(UserDetail User, DataSet DS)//פעולה מקבלת טבלה ופרטי משתמש
	{
		foreach (DataRow Row in DS.Tables["Users"].Rows)
		{
			if (User.UserId == int.Parse(Row["UserId"].ToString()))
			{
				Row["State"] = User.State;
				Row["FirstName"] = User.FirstName;
				Row["Email"] = User.Email;
				Row["KindUser"] = User.KindUser;
				Row["Description"] = User.Description;
				Row["Status"] = User.Status;
				Row["LastName"] = User.LastName;
				Row["CardID"] = User.CardID;
				Row["dateCard"] = User.dateCard;
				Row["SecurityCode"] = User.SecurityCode;
				Row["DateAdd"] = User.DateAdd;
				Row["birthday"] = User.birthday;
			}
		}
		try
		{
			MyConnction.Open();
			OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
			adapter.UpdateCommand = builder.GetUpdateCommand();
			adapter.Update(DS, "Users");
		}
		catch (Exception err)
		{ throw err; }
		finally { MyConnction.Close(); }
	}
	public void UpdateUserServer(UserDetail user)//פעולה מקבלת טבלה ופרטי משתמש
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("UpdateUser", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@UserName", OleDbType.BSTR);
			parm.Value = user.UserName;
			parm = Mycommand.Parameters.Add("@State", OleDbType.BSTR);
			parm.Value = user.State;
			parm = Mycommand.Parameters.Add("@FirstName", OleDbType.BSTR);
			parm.Value = user.FirstName;
			parm = Mycommand.Parameters.Add("@Email", OleDbType.BSTR);
			parm.Value = user.Email;
			parm = Mycommand.Parameters.Add("@Password", OleDbType.BSTR);
			parm.Value = user.Password;
			parm = Mycommand.Parameters.Add("@KindUser", OleDbType.Integer);
			parm.Value = user.KindUser;
			parm = Mycommand.Parameters.Add("@Status", OleDbType.Boolean);
			parm.Value = user.Status;
			parm = Mycommand.Parameters.Add("@LastName", OleDbType.BSTR);
			parm.Value = user.LastName;
            //parm = Mycommand.Parameters.Add("@CardID", OleDbType.BSTR);
            //parm.Value = user.CardID;
            //parm = Mycommand.Parameters.Add("@dateCard", OleDbType.BSTR);
            //parm.Value = user.dateCard;
            //parm = Mycommand.Parameters.Add("@SecurityCode", OleDbType.BSTR);
            //parm.Value = user.SecurityCode;
			parm = Mycommand.Parameters.Add("@DateAdd", OleDbType.Date);
			parm.Value = user.DateAdd;
			parm = Mycommand.Parameters.Add("@birthday", OleDbType.Date);
			parm.Value = user.birthday;
			parm = Mycommand.Parameters.Add("@UserId", OleDbType.Integer);
			parm.Value = user.UserId;
			Mycommand.ExecuteNonQuery();
		}
		catch (Exception err) { throw err; }
		finally { MyConnction.Close(); }
	}
	public DataSet PopFriends(int UserId)//פעולה מקבלת userid 
										 // ומחזירה דטהסט של כל החברים של האדם
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("ShowFirends", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@UserId", OleDbType.Integer);
			parm.Value = UserId;
			adapter = new OleDbDataAdapter(Mycommand);
			ds = new DataSet();
			adapter.Fill(ds);
			return ds;

		}
		catch (Exception REE) { throw REE; }
		finally { MyConnction.Close(); }
	}
	public DataSet ViewHistoryWach(int UserID)//פעולה מקבלת מספר משתמש ומחזירה שני טבלאות  שבהם יש את כל פרטי המשתמש
	{
		try
		{

			MyConnction.Open();
			ds = new DataSet();
			//ds.Tables.Add(CreateTable(new string[] { "WachID", "MovieID", "GroupName", "WatchDate" }, "GroupHistory"));
			Mycommand = new OleDbCommand("GroupHistory", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter Pram = Mycommand.Parameters.Add("@UserId", OleDbType.Integer);
			Pram.Value = UserID;
			adapter = new OleDbDataAdapter(Mycommand);
			adapter.Fill(ds, "GroupHistory");
			Mycommand = new OleDbCommand("UserHistory", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			Pram = Mycommand.Parameters.Add("@UserId", OleDbType.Integer);
			Pram.Value = UserID;
			adapter = new OleDbDataAdapter(Mycommand);
			adapter.Fill(ds, "UserHistory");
			AddMoviesNames(ds);
			return ds;

		}
		catch (Exception Err) { throw Err; }
		finally { MyConnction.Close(); }
	}
	private void AddMoviesNames(DataSet ds)//הוספת שמות הסרטים מ IMDB לטבלת הסטוריית סרטים למשתמש
	{

		ds.Tables["UserHistory"].Columns.Add(new DataColumn(("MovieName"), typeof(string)));
		ds.Tables["GroupHistory"].Columns.Add(new DataColumn(("MovieName"), typeof(string)));
		ImDb.WebService Db = new ImDb.WebService();
		DataTable TableMovies = Db.GetMoviesName();
		for (int i = 0; i < ds.Tables["UserHistory"].Rows.Count; i++)
		{

			DataRow dr = TableMovies.Rows.Find(ds.Tables["UserHistory"].Rows[i][1]);

			ds.Tables["UserHistory"].Rows[i]["MovieName"] = dr["MovieName"];
		}
		for (int i = 0; i < ds.Tables["GroupHistory"].Rows.Count; i++)
		{

			DataRow dr = TableMovies.Rows.Find(ds.Tables["GroupHistory"].Rows[i]["MovieID"]);

			ds.Tables["GroupHistory"].Rows[i]["MovieName"] = dr["MovieName"];
		}
	}
	private DataTable CreateTable(string[] col, string Name)//הפעולה מקבלת שמות של סדאות ומכינה טבלאה הנתאימה
	{
		DataTable send = new DataTable();
		DataColumn cols = new DataColumn(col[0], typeof(string));
		cols.Unique = true;
		send.Columns.Add(cols);
		for (int i = 1; i < col.Length; i++)
		{
			if (col[i] != "")
			{
				send.Columns.Add(new DataColumn(col[i]));
			}
		}
		send.TableName = Name;
		return send;
	}
	public void AddToHistory(int Movie, int User , bool IsTransaction)//מוסיף להיסטוריה של משתמש
	{
		try
		{
			if (!IsTransaction)
				MyConnction.Open();
			Mycommand = new OleDbCommand("Add2History", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@MovieID", OleDbType.Integer);
			parm.Value = Movie;
			parm = Mycommand.Parameters.Add("@DateWatch", OleDbType.Date);
			parm.Value = DateTime.Now;
			parm = Mycommand.Parameters.Add("@UserId", OleDbType.Integer);
			parm.Value = User;
			if(IsTransaction)
			Mycommand.Transaction = Transaction;
			Mycommand.ExecuteNonQuery();
		}
		catch (Exception err) { throw err; }
		finally { if (!IsTransaction) MyConnction.Close(); }
	}
	public void AddToGoupHistory(int Movie,int Group, int User)
	{
		try
		{
			MyConnction.Open();
			Transaction = MyConnction.BeginTransaction();
			AddToHistory(Movie, User, true);
			Mycommand = new OleDbCommand("TheLastGroup", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@UserId", OleDbType.Integer);
			parm.Value = User;
			Mycommand.Transaction = Transaction;
			int Watch =int.Parse(Mycommand.ExecuteScalar().ToString());
			Mycommand = new OleDbCommand("History2Group", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			parm = Mycommand.Parameters.Add("@GroupId", OleDbType.Integer);
			parm.Value = Group;
			parm = Mycommand.Parameters.Add("@WatchId", OleDbType.Integer);
			parm.Value = Watch;
			Mycommand.Transaction = Transaction;
			Mycommand.ExecuteNonQuery();
			Transaction.Commit();
		}
		catch (Exception err) { throw err;}
		finally { MyConnction.Close(); }

	}
	public void DeleteUser(int UserId, int FrendsId)//פעולה מוחק חבר מי מאגר החברים
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("DeleteFriend", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@UserId", OleDbType.BSTR);
			parm.Value = UserId;
			parm = Mycommand.Parameters.Add("@FriendId", OleDbType.BSTR);
			parm.Value = FrendsId;
			Mycommand.ExecuteNonQuery();
		}
		catch (Exception err) { throw err; }
		finally { MyConnction.Close(); }
	}
	public void AddFriends(int UserId, int FrendsId)//פעולה מוחק חבר מי מאגר החברים
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("AddFriends", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = Mycommand.Parameters.Add("@UserId", OleDbType.BSTR);
			parm.Value = UserId;
			parm = Mycommand.Parameters.Add("@FriendId", OleDbType.BSTR);
			parm.Value = FrendsId;
			Mycommand.ExecuteNonQuery();
		}
		catch (Exception err) { throw err; }
		finally { MyConnction.Close(); }
	}
    public DataSet MostView()
    {
        try
        {
            MyConnction.Open();
            Mycommand = new OleDbCommand("MostView", MyConnction);
            Mycommand.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
			adapter = new OleDbDataAdapter(Mycommand);
			adapter.Fill(ds, "UserHistory");
			ImDb.WebService Db = new ImDb.WebService();
			DataTable TableMovies = Db.GetMoviesName();
			ds.Tables[0].Columns.Add(new DataColumn(("MovieName"), typeof(string)));
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{

				DataRow dr = TableMovies.Rows.Find(ds.Tables[0].Rows[i]["MovieID"]);

				ds.Tables[0].Rows[i]["MovieName"] = dr["MovieName"];
			}
			return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
        finally { MyConnction.Close(); }
    }
	public DataSet MostUserInGroup()
	{
		try
		{
			MyConnction.Open();
			Mycommand = new OleDbCommand("MostUserInGroup", MyConnction);
			Mycommand.CommandType = CommandType.StoredProcedure;
			ds = new DataSet();
			adapter = new OleDbDataAdapter(Mycommand);
			adapter.Fill(ds);
			return ds;
		}
		catch (Exception err)
		{
			throw err;
		}
		finally { MyConnction.Close(); }
	}
}
