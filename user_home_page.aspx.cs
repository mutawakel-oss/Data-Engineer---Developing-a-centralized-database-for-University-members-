using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Student objStudent = new GeneralClass.Student();
    System.Data.Odbc.OdbcDataReader reader;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataTable tblPreviliges = new DataTable();
            if (Session["userName"] != null)
            {
                if (Session["userName"].ToString() != "")
                {
                    
                    GeneralClass.user user = new GeneralClass.user();
                    tblPreviliges= user.mRetrieveUserPreviliges(Session["userName"].ToString());
                    //The following code will check the retrieved student previliges availability
                    if (tblPreviliges.Rows[0][0].ToString() == "true")
                        btnStudentHomePage.Visible = true;
                    else
                        btnStudentHomePage.Visible = false;
                    //The following code will check the retrieved faculty previliges availability
                    if (tblPreviliges.Rows[1][0].ToString() == "true")
                        btnFacultyHomePage.Visible = true;
                    else
                        btnFacultyHomePage.Visible = false;
                    //The following code will check the retrieved employee previliges availability
                    if (tblPreviliges.Rows[2][0].ToString() == "true")
                        btnEmployeeHomePage.Visible = true;
                    else
                        btnEmployeeHomePage.Visible = false;
                    //The following code will check the retrieved report review previliges availability
                    //if (tblPreviliges.Rows[3][0].ToString() == "true")
                    //    btnReportReviewPage.Visible = true;
                    //else
                    //    btnReportReviewPage.Visible = false;
                    //The following code will check the retrieved administrative previliges availability
                    if (tblPreviliges.Rows[4][0].ToString() == "true")
                        btnUserControlPanel.Visible = true;
                    else
                        btnUserControlPanel.Visible = false;
                    
                }
            }
            else
                Response.Redirect("~/error.aspx?Error= Session Expired Please Login again ");
            HyperLink LB = (HyperLink)this.Master.Page.Controls[0].FindControl("hlkLogin");
            LB.Text = "Log Out";
            
            
            
        }
        catch (Exception exp)
        {

        }
           
    }
    protected void mOpenStudentPage(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to open the student home page for data entry.
        /// Author: mutawakelm
        /// Date :3/6/2010 8:31:15 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            Session["studentEntry"]="true";
            Session["userName"] = Session["userName"].ToString();
            Response.Redirect("~/student_home_page.aspx",true);
        }
        catch (Exception exp)
        {
        }
    }
    protected void mOpenFacultyPage(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to open the faculty home page
        /// Author: mutawakelm
        /// Date :3/6/2010 9:38:54 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            Session["facultyEntry"] = "true";
            Session["userName"] = Session["userName"].ToString();
            Response.Redirect("~/faculty_home_page.aspx", true);
        }
        catch (Exception exp)
        {
        }
    }
    protected void mOpenEmployeePage(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to open the employee home page
        /// Author: mutawakelm
        /// Date :3/6/2010 9:56:24 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            Session["employeeEntry"] = "true";
            Session["userName"] = Session["userName"].ToString();
            Response.Redirect("~/employee_home_page.aspx", true);

        }
        catch (Exception mOpenEmployeePage_Exp)
        {

        }

    }
    protected void mOpenReportPage(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:
        /// Author: mutawakelm
        /// Date :3/7/2010 2:35:45 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            Session["ReportReview"] = "true";
            Session["userName"] = Session["userName"].ToString();
            Response.Redirect("~/reports_page.aspx", true);
        }
        catch (Exception exp)
        {
        }
    }
    protected void mOpenControlPaenl(object sender, EventArgs e)
    {
        try
        {
            Session["controlPanel"] = "true";
            Session["userName"] = Session["userName"].ToString();
            Response.Redirect("~/user_control_panel.aspx", true);
        }
        catch (Exception exp)
        {
        }
    }
    protected void mOpenFeedback(object sender, EventArgs e)
    {
        try
        {
            Session["sendFeedback"] = "true";
            Session["userName"] = Session["userName"].ToString();
            Response.Redirect("~/send_feedback.aspx", true);
            

        }
        catch (Exception exp)
        {
        }
    }
  
     

}
