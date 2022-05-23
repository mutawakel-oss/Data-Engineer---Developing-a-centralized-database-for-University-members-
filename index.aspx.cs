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
    GeneralClass.user objUser = new GeneralClass.user();
    System.Data.Odbc.OdbcDataReader reader;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.RegisterStartupScript("SetFocus", "<script>document.getElementById('" + txtUserName.ClientID+ "').focus();</script>");
            HyperLink LB = (HyperLink)this.Master.Page.Controls[0].FindControl("hlkLogin");
            LB.Text = "Login";
            
        }
        catch (Exception exp)
        {

        }
           
    }
    protected void mLogin(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to check the authority of the login
        /// Author: mutawakelm
        /// Date :10/3/2009 8:55:12 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            bool userAvailability = false;
            
            string bln = IsAuthenticated("", txtUserName.Text,txtPassword.Text);
            if (bln != null && bln != "")
            {
                userAvailability = objUser.mCheckUserAvailablity(txtUserName.Text);
                if (userAvailability == true)
                {
                    Session["UserFullName"] = bln.ToString();
                    Session["userName"] = txtUserName.Text;
                    Response.Redirect("~/user_home_page.aspx", false);
                }
                else
                    Response.Redirect("error.aspx?Error= You are not allowed to access the system ");
               
            }
            else
            {
                Response.Redirect("error.aspx?Error= Please enter valid username and password ");
            }
        }
        catch (Exception exp)
        {
        }
    }
    public string IsAuthenticated(string domain, string username, string pwd)
    {
        try
        {

            SearchResult result = null;
            string domainAndUsername = username.Trim();
            if (ddlDomain.SelectedItem.Value == "1")
            {
                try
                {
                    DirectoryEntry entry = new DirectoryEntry("LDAP://10.8.128.100", ddlDomain.SelectedItem.Text.ToLower() + "\\" + domainAndUsername, pwd);
                    Object obj = entry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + username + ")";
                    search.PropertiesToLoad.Add("cn");
                    result = search.FindOne();
                }
                catch (Exception exp)
                {

                }
            }
            else
                if (ddlDomain.SelectedItem.Value == "2")
                {
                    try
                    {
                        DirectoryEntry entry = new DirectoryEntry("LDAP://10.8.128.101", ddlDomain.SelectedItem.Text.ToLower() + "\\" + domainAndUsername, pwd);
                        Object obj = entry.NativeObject;
                        DirectorySearcher search = new DirectorySearcher(entry);
                        search.Filter = "(SAMAccountName=" + username + ")";
                        search.PropertiesToLoad.Add("cn");
                        result = search.FindOne();

                    }
                    catch (Exception exp)
                    {
                    }
                }



            if (null == result)
            {
                return string.Empty;
            }
            else
            {
                // Update the new path to the user in the directory
                //_path = result.Path;
                //_filterAttribute = (string)result.Properties["cn"][0];
                GeneralClass.Program.strLOGINUSERPATH = result.GetDirectoryEntry().Parent.Path;  // ldap path 
                GeneralClass.Program.SKODE = pwd;


                string fullName = result.GetDirectoryEntry().Properties["Name"].Value.ToString();
                // string str1 = result.GetDirectoryEntry().Properties["userAccountControl"].Value.ToString();
                if (null != result.GetDirectoryEntry().Properties["employeeid"].Value)
                    Session["Badge"] = result.GetDirectoryEntry().Properties["employeeid"].Value.ToString();
                if (null != result.GetDirectoryEntry().Properties["telephonenumber"].Value)
                    Session["Extn"] = result.GetDirectoryEntry().Properties["telephonenumber"].Value.ToString();
                if (null != result.GetDirectoryEntry().Properties["mobile"].Value)
                    Session["Mobile"] = result.GetDirectoryEntry().Properties["mobile"].Value.ToString();
                if (null != result.GetDirectoryEntry().Properties["mail"].Value)
                    Session["mail"] = result.GetDirectoryEntry().Properties["mail"].Value.ToString();
                if (null != result.GetDirectoryEntry().Properties["Description"].Value)
                    Session["Title"] = result.GetDirectoryEntry().Properties["Description"].Value.ToString();
                if (null != result.GetDirectoryEntry().Properties["Department"].Value)
                    Session["Department"] = result.GetDirectoryEntry().Properties["Department"].Value.ToString();



                return (string)result.Properties["cn"][0].ToString();
            }
        }
        catch (Exception exp)
        {
            return string.Empty;
        }
    }
     

}
