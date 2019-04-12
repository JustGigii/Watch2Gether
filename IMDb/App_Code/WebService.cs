using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet GetTheCatlog() {
        Movie_s_Servies Ms = new Movie_s_Servies();
        return Ms.GetAllTheCatlog();
    }
    [WebMethod]
    public MovieDetails GetMoviesDetails(int MovieId)
    {
        Movie_s_Servies Ms = new Movie_s_Servies();
        return Ms.GetMovieDetails(MovieId);
    }
	[WebMethod]
	public string GetURLAddress(int MovieId)
	{
		Movie_s_Servies Ms = new Movie_s_Servies();
		return Ms.GetUrlAddres(MovieId);
	}
    [WebMethod]
	//public DataTable GetMoviesName(int[] ListGruop)
        public DataTable GetMoviesName()
    {
        int[] ListGruop = new int[2];
        ListGruop[0] = 3;
        ListGruop[1] = 5;

        //מקבל רשימת קודי סרטים ומחזיר שמות הסרטים במאגר
       
        Movie_s_Servies MS = new Movie_s_Servies();
        return MS.GetMoiveName(ListGruop);
    }
        [WebMethod]
    public int GetMoiveLenght()
    {
        Movie_s_Servies MS = new Movie_s_Servies();
        return MS.GetMoiveLenght();
    }
}
