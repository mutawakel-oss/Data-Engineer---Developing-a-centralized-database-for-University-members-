using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Student objStudent = new GeneralClass.Student();
    System.Data.Odbc.OdbcDataReader reader;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HyperLink LB = (HyperLink)this.Master.Page.Controls[0].FindControl("hlkLogin");
            LB.Text = "Log Out";
            if ((Session["sendFeedback"] != null) && (Session["userName"] != null))
            {
            }
            else
                Response.Redirect("~/error.aspx?Error= Session Expired Please Login again ");
            
        }
        catch (Exception exp)
        {

        }
           
    }
    protected void mSendFeedback(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to send the user feedback
        /// Author: mutawakelm
        /// Date :4/11/2010 8:36:43 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            objProgram.Add("username", Session["userName"].ToString(), "S");
            objProgram.Add("subject", txtSubject.Text, "S");
            objProgram.Add("description", txtDescription.Text, "S");
            objProgram.InsertRecordStatement("feedback_table");
            Response.Redirect("~/user_home_page.aspx");


        }
        catch (Exception exp)
        {
        }
    }
    
     

}
