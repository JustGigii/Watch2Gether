using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for WebCreditService_
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebCreditService: System.Web.Services.WebService {

    public WebCreditService() {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
     [WebMethod(Description = "Get Credit Companies ")]
    public DataSet GetCreditCompanies()
     {
    
        CardsService cardsService = new CardsService();
        return cardsService.GetCompanies();
    }


[WebMethod(Description = "insert new Transaction ")]
    public bool insertTransaction(Transaction transaction)
{
     CardsService cardsService = new CardsService();
      return  cardsService.insertTransaction(transaction);
    }


 [WebMethod(Description = "Check Card Details")]
    public bool CheckCard(CardDetails card)
    {
  
         CardsService cardsService = new CardsService();
         return cardsService.CheckCard(card);
    }

}
