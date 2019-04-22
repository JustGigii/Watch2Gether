using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;


/// <summary>
/// Summary description for Class1
/// </summary>
public class TimerW2G
{
	
    public static int s = 0;
    public static System.Timers.Timer _timer;
	public TimerW2G()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void startTimer()
    {   
        // initialize the time control giving as parameter the time in milliseconds, between raisings of the Elapsed event. The default is 100 milliseconds.   
        _timer = new System.Timers.Timer(5000);

        // subscribe to the Elapsed event   
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

        // Keep the timer alive until the end of Main.
        GC.KeepAlive(_timer);
        _timer.Start();
    }

    private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
		// Do whatever you want to do on each tick of the timer
		if (System.Web.HttpContext.Current != null)


			for (int i = 0; i < ((GroupsDetails)System.Web.HttpContext.Current.Application["Rooms"]).Rooms.Count; i++)
			{
				Group Mark = ((GroupsDetails)System.Web.HttpContext.Current.Application["Rooms"]).Rooms[i];

				Mark.CurrentTime += int.Parse(e.SignalTime.ToString());
				if (Mark.CurrentTime == Mark.EndMovie)
				{
					((GroupsDetails)System.Web.HttpContext.Current.Application["Rooms"]).Rooms.Remove(Mark);
				}
				System.Web.HttpContext.Current.Response.Redirect("TheViewMovie.aspx ? m =" + Mark.MovieID);
			}
		}
    }

}
