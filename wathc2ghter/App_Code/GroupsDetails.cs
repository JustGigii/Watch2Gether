using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GroupsDetails
/// </summary>
public class GroupsDetails : Group
{
	private List<Group> rooms;//חדרים באתר	
	public List<Group> Rooms//פעולה בונה
	{

		get { return this.rooms; }

	}

	public GroupsDetails()//פעולה בונה
	{
		rooms = new List<Group>();
	}
	public void AddToGroup(Group group)//מוסיף קוצה לרשימת חדרים
	{
		rooms.Add(group);
	}
	public Group GetTheSerchGroup(int id)//פהעולה מקבל מסםר קבוצה ומחזירה את הקבוצה ברשימת החדרים
	{
		foreach (Group i in rooms)
		{
			if (i.GroupId == id)
				return i;
		}
		return null;
	}
}