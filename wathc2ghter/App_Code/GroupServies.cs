using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for GroupServies
/// </summary>
public class GroupServies
{
    OleDbCommand command;
    OleDbDataAdapter adapter;
    OleDbConnection Connction = new OleDbConnection(Connect.GetInfo());
    DataSet ds;
    OleDbTransaction tr;
    public GroupServies()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetKindGroup()
    {
        //פעולה צחזירה טבלה של סוג הסרטים שיש באתר 
        DataTable DT = new DataTable("KindGroupe");
        DT.Columns.Add("KindId"); DT.Columns.Add("Kind");
        try
        {
            Connction.Open();
            this.adapter = new OleDbDataAdapter("select * from KindGroupe", Connction);
            adapter.Fill(DT);
            return DT;
        }
        catch (Exception Err)
        {
            throw Err;
        }
        finally
        {
            Connction.Close();
        }
    }
    public void CreateGroup(Group Group)
    {//פעולה יוצרת קבוצה חדשה
        try
        {
            Connction.Open();
            tr = Connction.BeginTransaction();
            command = new OleDbCommand("CreateGroup", Connction);
            command.CommandType = CommandType.StoredProcedure;
            command.Transaction = tr;

            OleDbParameter parm;
            parm = command.Parameters.Add("@GroupName", OleDbType.BSTR);
            parm.Value = Group.GroupeName;
            parm = command.Parameters.Add("@KindGroup", OleDbType.Integer);
            parm.Value = Group.KindGroup;
            parm = command.Parameters.Add("@MenngerGroup", OleDbType.Integer);
            parm.Value = Group.MenngerGroup;
            command.ExecuteNonQuery();
            Group.GroupId = InsertGroup(Group.MenngerGroup);
            foreach (int i in Group.GetUsermembers())
            {
                AddMemberToGroup(i,Group.GroupId, true);
            }
            tr.Commit();

        }
        catch (Exception err) { throw err; tr.Rollback(); }
        finally { Connction.Close(); }
    }
    public void AddMemberToGroup(int User, int GroupId, bool inTransaction)
    {//הוספה מתשמש לקבוצה
        try
        {
            command = new OleDbCommand("AddMemberToGroup", Connction);
            command.CommandType = CommandType.StoredProcedure;
            if (inTransaction) command.Transaction = tr; else Connction.Open();
            OleDbParameter parm;
            parm = command.Parameters.Add("@GroupId", OleDbType.BSTR);
            parm.Value = GroupId;
            parm = command.Parameters.Add("@UserId", OleDbType.Integer);
            parm.Value = User;
            command.ExecuteNonQuery();
        }
        catch (Exception err) { throw err; }
        finally { if (!inTransaction) Connction.Close(); }

    }
    public int InsertGroup(int MemberGroup)
    {//מוסיף אדם לקבצה שנפתחה
      try
        {
        command = new OleDbCommand("InsertLastGroup", Connction);
        command.CommandType = CommandType.StoredProcedure;
        command.Transaction = tr;
        OleDbParameter parm;
        parm = command.Parameters.Add("@MenngerGroup", OleDbType.Integer);
        parm.Value = MemberGroup;
        return int.Parse(command.ExecuteScalar().ToString());
        }
      catch (Exception err) { throw err; }
    }
	public DataSet ShowUserGoup(int UserId)
    {
        try
        {//מציג את כל הקבצות של האדם
            command = new OleDbCommand("ShowAllUserGroup", Connction);
        command.CommandType = CommandType.StoredProcedure;
        Connction.Open();
        OleDbParameter parm;
        parm = command.Parameters.Add("@UserId", OleDbType.Integer);
        parm.Value = UserId;
        adapter = new OleDbDataAdapter(command);
        ds = new DataSet();
        adapter.Fill(ds,"Group");
        return ds;
        }
        catch (Exception err) { throw err; }
        finally { Connction.Close(); }
    }
    public Group GetGroupToWatch(int GroupId,int MovieId)
    {//מקבל מספר קבוצה ומספר סרט מחזיר את כל המידע על הקבוצה
        Group Gr = new Group();
        Gr.GroupId = GroupId;
        try
        {
            Connction.Open();
			tr = Connction.BeginTransaction();
			command = new OleDbCommand("PopGroup", Connction);
            command.CommandType = CommandType.StoredProcedure;
            OleDbParameter parm;
			command.Transaction = tr;
            parm = command.Parameters.Add("@GroupId", OleDbType.Integer);
            parm.Value = GroupId;
            adapter = new OleDbDataAdapter(command);
            ds = new DataSet();
            adapter.Fill(ds, "Group");
            Gr.GroupeName= ds.Tables["Group"].Rows[0]["GroupName"].ToString();
            Gr.KindGroup = int.Parse(ds.Tables["Group"].Rows[0]["KindGroup"].ToString());
            Gr.MenngerGroup = int.Parse(ds.Tables["Group"].Rows[0]["MenngerGroup"].ToString());
            Gr.DateGroup = DateTime.Parse((ds.Tables["Group"].Rows[0]["DateGroup"].ToString()));
            Gr.StatusGroup = bool.Parse((ds.Tables["Group"].Rows[0]["StatusGroup"].ToString()));
            Gr.SetUsermembers(GetPoepleInGroup(GroupId));
			Gr.MovieID = MovieId;
			Gr.CurrentTime= 0;
			tr.Commit();
			return Gr;
        }
        catch (Exception err) { throw err; }
        finally { Connction.Close(); }
    }
	public List<int> GetPoepleInGroup(int Group)
	{
		try
		{//מחזיר את כל האנשים בקבוצה
			command = new OleDbCommand("GetallPopleOnGroup", Connction);
			command.CommandType = CommandType.StoredProcedure;
			command.Transaction = tr;
			OleDbParameter parm;
			parm = command.Parameters.Add("@GroupId", OleDbType.Integer);
			parm.Value = Group;
			OleDbDataReader read =  command.ExecuteReader();
			List<int> Poeple = new List<int>();
			while (read.Read())
			{
				if(read.GetInt32(1) == 1)
				Poeple.Add(read.GetInt32(0));
			}
			return Poeple;
		}
		catch (Exception err)
		{
			throw err;
		}
	}
	public DataSet GetPoepleInGroupDb(int Group)
	{
		try
		{//מחזיר את כל האנשים בקבוצה בצורת דטה בייס
			Connction.Open();
			command = new OleDbCommand("GetallPopleOnGroup", Connction);
			command.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = command.Parameters.Add("@GroupId", OleDbType.Integer);
			parm.Value = Group;
			adapter = new OleDbDataAdapter(command);
			ds = new DataSet();
			adapter.Fill(ds);
			AddStatusName(ds);
			return ds;
		}
		catch (Exception err)
		{
			throw err;
		}
		finally { Connction.Close(); }
	}
	private void AddStatusName(DataSet ds)
	{//מוסיף עומדה של שם הסטטוס
		ds.Tables[0].Columns.Add("SatusName");
		for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
		{
			switch (int.Parse(ds.Tables[0].Rows[i]["StatusJoin"].ToString()))
			{
				case 1:
				ds.Tables[0].Rows[i]["SatusName"] = "Online";
			break;
				case 5:
			ds.Tables[0].Rows[i]["SatusName"] = "Waiting";
			break;
			case 10: 
			ds.Tables[0].Rows[i]["SatusName"] = "Ofline";
			break;
		}
			}
		}
	public DataSet GetGroupCanMannge(int UserId)
    {
          try
        {
              ds = new DataSet();
            Connction.Open();
            command = new OleDbCommand("GetAllUserGroupMannge", Connction);
            command.CommandType = CommandType.StoredProcedure; 
            OleDbParameter parm;
            parm = command.Parameters.Add("@UserId", OleDbType.BSTR);
            parm.Value = UserId;
            adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);
            return ds;
        }
          catch (Exception err)
          {
              throw err;
          }
        finally{Connction.Close();}
    }
	public void UpdateToWating(int GroupId, int UserId,int Status)
	{
		try
		{//מעדען את הסטטוס של האדם עם הוא מנמצא בקבוצה או לא
			Connction.Open();
			command = new OleDbCommand("MakeOnline", Connction);
			command.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = command.Parameters.Add("@Status", OleDbType.Integer);
			parm.Value = Status;
			parm = command.Parameters.Add("@UserId", OleDbType.Integer);
			parm.Value = UserId;
			parm = command.Parameters.Add("@GroupId", OleDbType.Integer);
			parm.Value = GroupId;
			command.ExecuteNonQuery();

		}
		catch (Exception err)
		{
			throw err;
		}
		finally { Connction.Close(); }
	}
	public DataSet ShowInvateGroup(int UserId)
	{
		try
		{//מעדען את הסטטוס של האדם עם הוא מנמצא בקבוצה או לא
			Connction.Open();
			command = new OleDbCommand("InvateGroup", Connction);
			command.CommandType = CommandType.StoredProcedure;
			OleDbParameter parm;
			parm = command.Parameters.Add("@UserId", OleDbType.Integer);
			parm.Value = UserId;
			adapter = new OleDbDataAdapter(command);
			ds = new DataSet();
			adapter.Fill(ds);
			return ds;
		}
		catch (Exception err)
		{
			throw err;
		}
		finally { Connction.Close(); }
	}

}