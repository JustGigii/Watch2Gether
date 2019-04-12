using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GroupsDetails
/// </summary>
public class GroupsDetails
{
    private List<Group> rooms;
    public List<Group> Rooms
    {

        get { return this.rooms; }
       
    }
	public GroupsDetails()
	{
        rooms = new List<Group>();
	}
    public void AddToGroup(Group group)
    {
        rooms.Add(group);
    }
	public Group GetTheSerchGroup(int id)
	{
		foreach (Group i in rooms)
		{
			if (i.GroupId == id)
				return i;
		}
		return null;
	}
}