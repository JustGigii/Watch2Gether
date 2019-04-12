﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        System.Data.DataSet DS = new System.Data.DataSet();
        UserServies User = new UserServies();
        DS = User.FillAllUsers(DS);
        Application["DataSetUsers"] = DS;
        Application["Users"] = new List<UserDetail>();
        ImDb.WebService ImDb = new ImDb.WebService();
        DS = ImDb.GetTheCatlog();
        Application["Catlog"] = DS;

        Application["Rooms"] = new GroupsDetails();
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
        //Application.Lock();
        //List<UserDetail> User = (List<UserDetail>)Application["Users"];
        //for (int i = 0; i < User.Count; i++)
        //{
        //    if (((UserDetail)Session["Users"]).UserId == User[i].UserId)
        //        User.Remove(User[i]);
        //    Application.UnLock();
        //}
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.


    }

</script>