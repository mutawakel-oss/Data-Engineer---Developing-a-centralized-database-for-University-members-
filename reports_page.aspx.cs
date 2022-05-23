using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Data;
using System.Xml;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    GeneralClass.Program objProgram = new GeneralClass.Program();
    GeneralClass.Student objStudent = new GeneralClass.Student();
    System.Data.Odbc.OdbcDataReader reader;
    DataTable tblReport = new DataTable();
    string strCurrentQuery = "";
    string strCurrentRole = "";
    //Notes: user name shoud be replaced with session username.
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataTable tblReportPreviliges = new DataTable();
            int campusCounter = 0;
            int collegeCounter = 1;
            int departmentCounter = 1;
            //Temporary code
            //End of Temporary Code
            if ((Session["ReportReview"] != null) && (Session["userName"] != null))
            {
                if (Session["ReportReview"].ToString() == "true")
                {
                    if (!IsPostBack)
                    {
                        GeneralClass.user user = new GeneralClass.user();
                        tblReportPreviliges = user.mCheckReportReviewPrivilges(Session["userName"].ToString());
                        if (tblReportPreviliges.Rows.Count > 0)
                        {
                            campusCounter = 0;
                            collegeCounter = 1;
                            departmentCounter = 1;
                            ddlCollege.Items.Add("Select a College");
                            ddlCollege.Items[0].Value = "no";
                            ddlDepartment.Items.Add("Select a department");
                            ddlDepartment.Items[0].Value = "no";
                            for (int i = 0; i < tblReportPreviliges.Rows.Count; i++)
                            {
                                if (tblReportPreviliges.Rows[i][0].ToString() == "campus")
                                {
                                    ddlCampus.Items.Add(tblReportPreviliges.Rows[i][2].ToString());
                                    ddlCampus.Items[campusCounter].Value = tblReportPreviliges.Rows[i][1].ToString();
                                    campusCounter++;
                                }
                                else
                                    if (tblReportPreviliges.Rows[i][0].ToString() == "college")
                                    {
                                        ddlCollege.Items.Add(tblReportPreviliges.Rows[i][2].ToString());
                                        ddlCollege.Items[collegeCounter].Value = tblReportPreviliges.Rows[i][1].ToString();
                                        collegeCounter++;
                                    }
                                    else
                                        if (tblReportPreviliges.Rows[i][0].ToString() == "department")
                                        {
                                            ddlDepartment.Items.Add(tblReportPreviliges.Rows[i][2].ToString());
                                            ddlDepartment.Items[departmentCounter].Value = tblReportPreviliges.Rows[i][1].ToString();
                                            departmentCounter++;
                                        }
                                        else
                                            if (tblReportPreviliges.Rows[i][0].ToString() == "administrative")
                                            {
                                                chkOverallStatistics.Visible = true;
                                            }
                            }

                        }
                    }
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
    protected void mDisplayReport(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to display the report according to the selected creterias
        /// Author: mutawakelm
        /// Date :3/7/2010 11:35:47 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            lblRecordNo.Text = "";
            if (chkCamups.Checked == false)
            {
                ReportGrid.DataSource = null;
                ReportGrid.DataBind();
                lblReportTitle.Text = "";
                mFillGridByCategory();
            }
            else
                if (chkCamups.Checked == true)
                {
                    ReportGrid.DataSource = null;
                    ReportGrid.DataBind();
                    lblReportTitle.Text = "";
                    mFillGridBySelectdCreterias();

                }
        }
        catch (Exception exp)
        {
            if(reader!=null)
                reader.Close();
        }
    }
    protected void mFillGridBySelectdCreterias()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the grade according to the selected creterias
        /// Author: mutawakelm
        /// Date :3/8/2010 2:13:15 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            tblReport.Columns.Add("nationalID");
            tblReport.Columns.Add("userFullName");
            tblReport.Columns.Add("role");
            tblReport.Columns.Add("by");
            string strCategoryQuery = "";
            string strFromDate = txtFromDate.Text;
            string strToDate = txtToDate.Text;
            int recordsCounter = 0;
            ReportGrid.CurrentPageIndex = 0;
            if (ddlCategory.SelectedItem.Value == "1")
            {
                if (ddlCollege.SelectedItem.Value != "no")
                {
                    ReportGrid.DataSource = null;
                    ReportGrid.DataBind();
                    //The following code will fill the report grid
                    strCategoryQuery = "SELECT st.*,us.full_name FROM STUDENT as st join system_user_table as us on st.user_name=us.user_name  WHERE CURNTCOLG='" + ddlCollege.SelectedItem.Value + "' AND campus_id="+ddlCampus.SelectedItem.Value;
                    if ((strFromDate != "") && (strToDate != ""))
                        strCategoryQuery += " and (st.creation_date >='" + strFromDate + " 00:00:01 AM'" + " and st.creation_date<='" + strToDate + " 11:59:00 PM')";
                    strCurrentQuery = strCategoryQuery;
                    strCurrentRole = "student";
                    reader = objProgram.gRetrieveRecord(strCategoryQuery);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tblReport.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString(), "Student", reader["full_name"].ToString());
                            recordsCounter++;
                        }
                        reader.Close();
                    }
                    else
                        reader.Close();
                    lblReportTitle.Text = "Report of Entered Students ";
                    ReportGrid.DataSource = tblReport;
                    ReportGrid.DataBind();
                    lblRecordNo.Text = recordsCounter.ToString();
                }
                else
                    MessageBox.MessageBox.Show("Please select a college.");
            }
            else
                if (ddlCategory.SelectedItem.Value == "2")
                {
                    if ((ddlCollege.SelectedItem.Value != "no") || (ddlDepartment.SelectedItem.Value != "no"))
                    {
                        ReportGrid.DataSource = null;
                        ReportGrid.DataBind();
                        //The following code will fill the report grid
                        strCategoryQuery = "SELECT fa.*,us.full_name FROM FACULTY as fa join system_user_table as us on fa.user_name=us.user_name  ";
                        if ((ddlCollege.SelectedItem.Value != "no") && (ddlDepartment.SelectedItem.Value != "no"))
                            strCategoryQuery += " WHERE COLGID='"+ddlCollege.SelectedItem.Value+"' AND DEPTID='"+ddlDepartment.SelectedItem.Value+"'";
                        else
                            if(ddlCollege.SelectedItem.Value!="no")
                                strCategoryQuery += " WHERE COLGID='" + ddlCollege.SelectedItem.Value + "'";
                            else
                                if(ddlDepartment.SelectedItem.Value!="no")
                                    strCategoryQuery += " WHERE DEPTID='" + ddlDepartment.SelectedItem.Value+ "'";
                        if ((strFromDate != "") && (strToDate != ""))
                            strCategoryQuery += " and (fa.creation_date >='" + strFromDate + " 00:00:01 AM'" + " and fa.creation_date<='" + strToDate + " 11:59:00 PM')";
                        strCategoryQuery += " and campus_id="+ddlCampus.SelectedItem.Value;
                        strCurrentQuery = strCategoryQuery;
                        strCurrentRole = "faculty";
                        reader = objProgram.gRetrieveRecord(strCategoryQuery);
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tblReport.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString(), "Faculty", reader["full_name"].ToString());
                                recordsCounter++;
                            }
                            reader.Close();
                        }
                        else
                            reader.Close();
                        lblReportTitle.Text = "Report of Entered Faculy ";
                        ReportGrid.DataSource = tblReport;
                        ReportGrid.DataBind();
                        lblRecordNo.Text = recordsCounter.ToString();
                    }
                    else
                    {
                        MessageBox.MessageBox.Show("Please select a college/department.");
                    }
                }
                else
                    if (ddlCategory.SelectedItem.Value == "3")
                    {

                        if (ddlDepartment.SelectedItem.Value != "no")
                        {
                            ReportGrid.DataSource = null;
                            ReportGrid.DataBind();
                            //The following code will fill the report grid
                            strCategoryQuery = "SELECT staf.*,us.full_name FROM STAFF as staf join system_user_table as us on staf.user_name=us.user_name  WHERE DEPTID='"+ddlDepartment.SelectedItem.Value+"' AND campus_id="+ddlCampus.SelectedItem.Value;
                            if ((strFromDate != "") && (strToDate != ""))
                                strCategoryQuery += " and (staf.creation_date >='" + strFromDate + " 00:00:01 AM'" + " and staf.creation_date<='" + strToDate + " 11:59:00 PM')";
                            strCurrentQuery = strCategoryQuery;
                            strCurrentRole = "staff";
                            reader = objProgram.gRetrieveRecord(strCategoryQuery);
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    tblReport.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString(), "Employee", reader["full_name"].ToString());
                                    recordsCounter++;
                                }
                                reader.Close();
                            }
                            else
                                reader.Close();
                            lblReportTitle.Text = "Report of Entered Employees ";
                            ReportGrid.DataSource = tblReport;
                            ReportGrid.DataBind();
                            lblRecordNo.Text = recordsCounter.ToString();
                        }
                        else
                            MessageBox.MessageBox.Show("Please select a department.");
                    }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mConvertToXml()
    {
        try
        {
            
            DataTable tblEmployeesTable = new DataTable("STAFF");
            tblEmployeesTable.Columns.Add("NATID");
            tblEmployeesTable.Columns.Add("FNAME");
            tblEmployeesTable.Columns.Add("MNAMES");
            tblEmployeesTable.Columns.Add("SURNAME");
            tblEmployeesTable.Columns.Add("BIRTHDTE");
            tblEmployeesTable.Columns.Add("GENDER");
            tblEmployeesTable.Columns.Add("NATION");
            tblEmployeesTable.Columns.Add("MRSTATUS");
            tblEmployeesTable.Columns.Add("RELGN");
            tblEmployeesTable.Columns.Add("EMAIL");
            tblEmployeesTable.Columns.Add("INSTID");
            tblEmployeesTable.Columns.Add("CITYLOC");
            tblEmployeesTable.Columns.Add("EMPID");
            tblEmployeesTable.Columns.Add("RANK");
            tblEmployeesTable.Columns.Add("APPTDATE");
            tblEmployeesTable.Columns.Add("DEPTID");
            tblEmployeesTable.Columns.Add("STRTDATE");
            tblEmployeesTable.Columns.Add("HQHELD");
            tblEmployeesTable.Columns.Add("BASCSAL");
            tblEmployeesTable.Columns.Add("MNTHSAL");
            tblEmployeesTable.Columns.Add("ACCOM");
            DataTable tblFacultyTable = new DataTable("FACULTY");
            tblFacultyTable.Columns.Add("FNAME");
            tblFacultyTable.Columns.Add("MNAMES");
            tblFacultyTable.Columns.Add("SURNAME");
            tblFacultyTable.Columns.Add("NATID");
            tblFacultyTable.Columns.Add("BIRTHDTE");
            tblFacultyTable.Columns.Add("GENDER");
            tblFacultyTable.Columns.Add("NATION");
            tblFacultyTable.Columns.Add("MRSTATUS");
            tblFacultyTable.Columns.Add("RELGN");
            tblFacultyTable.Columns.Add("EMAIL");
            tblFacultyTable.Columns.Add("INSTID");
            tblFacultyTable.Columns.Add("CITYLOC");
            tblFacultyTable.Columns.Add("COLGID");
            tblFacultyTable.Columns.Add("DEPTID");
            tblFacultyTable.Columns.Add("EMPID");
            tblFacultyTable.Columns.Add("RANK");
            tblFacultyTable.Columns.Add("APPTDATE");
            tblFacultyTable.Columns.Add("MOFAC");
            tblFacultyTable.Columns.Add("STRTDATE");
            tblFacultyTable.Columns.Add("FACSTUS");
            tblFacultyTable.Columns.Add("HQHELD");
            tblFacultyTable.Columns.Add("HQDATE");
            tblFacultyTable.Columns.Add("HQINST");
            tblFacultyTable.Columns.Add("HQCNTRY");
            tblFacultyTable.Columns.Add("ACDIS1");
            tblFacultyTable.Columns.Add("ACDISNAME");
            tblFacultyTable.Columns.Add("ACDIS2");
            tblFacultyTable.Columns.Add("CRTINST");
            tblFacultyTable.Columns.Add("ACEMPFUN");
            tblFacultyTable.Columns.Add("BASCSAL");
            tblFacultyTable.Columns.Add("MNTHSAL");
            tblFacultyTable.Columns.Add("ACCOM");
            DataTable tblStudentTable = new DataTable("STUDENT");
            tblStudentTable.Columns.Add("FNAME");
            tblStudentTable.Columns.Add("MNAMES");
            tblStudentTable.Columns.Add("SURNAME");
            tblStudentTable.Columns.Add("NATID");
            tblStudentTable.Columns.Add("BIRTHDTE");
            tblStudentTable.Columns.Add("GENDER");
            tblStudentTable.Columns.Add("NATION");
            tblStudentTable.Columns.Add("HSTYPE");
            tblStudentTable.Columns.Add("HSYEAR");
            tblStudentTable.Columns.Add("HSLOC");
            tblStudentTable.Columns.Add("HSPERCENT");
            tblStudentTable.Columns.Add("APLTEST");
            tblStudentTable.Columns.Add("ACHVTEST");
            tblStudentTable.Columns.Add("INSTID");
            tblStudentTable.Columns.Add("LOCSTDY");
            tblStudentTable.Columns.Add("STUDID");
            tblStudentTable.Columns.Add("COMYEAR");
            tblStudentTable.Columns.Add("COMSEM");
            tblStudentTable.Columns.Add("ADMCOLG");
            tblStudentTable.Columns.Add("CURNTCOLG");
            tblStudentTable.Columns.Add("PRVCOLG");
            tblStudentTable.Columns.Add("SBJQA1");
            tblStudentTable.Columns.Add("SBJNAME");
            tblStudentTable.Columns.Add("SBJQA2");
            tblStudentTable.Columns.Add("PRSBJ");
            tblStudentTable.Columns.Add("QUALAIM");
            tblStudentTable.Columns.Add("STDYLNGTH");
            tblStudentTable.Columns.Add("UNITLNGTH");
            tblStudentTable.Columns.Add("NCREQ");
            tblStudentTable.Columns.Add("NCREG");
            tblStudentTable.Columns.Add("NCPASS");
            tblStudentTable.Columns.Add("TNCPASS");
            tblStudentTable.Columns.Add("NCREM");
            tblStudentTable.Columns.Add("NSREG");
            tblStudentTable.Columns.Add("SUMSEM");
            tblStudentTable.Columns.Add("NWDRAW");
            tblStudentTable.Columns.Add("YEARPRG");
            tblStudentTable.Columns.Add("CUMGPA");
            tblStudentTable.Columns.Add("GPATYPE");
            tblStudentTable.Columns.Add("NACWARN");
            tblStudentTable.Columns.Add("GSTATUS");
            tblStudentTable.Columns.Add("REGSTATUS");
            tblStudentTable.Columns.Add("STDYMODE");
            tblStudentTable.Columns.Add("SCLRSHIP");
            tblStudentTable.Columns.Add("TRANS");
            tblStudentTable.Columns.Add("QUAL");
            tblStudentTable.Columns.Add("CLASS");
            tblStudentTable.Columns.Add("ACCOM");
            
            if ((strCurrentRole != "") && (strCurrentQuery != ""))
            {
                if (strCurrentRole == "faculty")
                {
                    reader = objProgram.gRetrieveRecord(strCurrentQuery);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            tblFacultyTable.Rows.Add(reader["FNAME"].ToString(), reader["MNAMES"].ToString(), reader["SURNAME"].ToString()
                                , reader["NATID"].ToString(), reader["BIRTHDTE"].ToString(), reader["GENDER"].ToString(), reader["NATION"].ToString()
                            , reader["MRSTATUS"].ToString(), reader["RELGN"].ToString(), reader["EMAIL"].ToString(), reader["INSTID"].ToString(), reader["CITYLOC"].ToString(), reader["COLGID"].ToString()
                            , reader["DEPTID"].ToString(), reader["EMPID"].ToString(), reader["RANK"].ToString(), reader["APPTDATE"].ToString(), reader["MOFAC"].ToString()
                            , reader["STRTDATE"].ToString(), reader["FACSTUS"].ToString(), reader["HQHELD"].ToString(), reader["HQDATE"].ToString(),
                             reader["HQINST"].ToString(), reader["HQCNTRY"].ToString(), reader["ACDIS1"].ToString(), reader["ACDISNAME"].ToString(),
                              reader["ACDIS2"].ToString(), reader["CRTINST"].ToString(), reader["ACEMPFUN"].ToString(), reader["BASCSAL"].ToString(),
                              reader["MNTHSAL"].ToString(), reader["ACCOM"].ToString());
                        }
                        reader.Close();
                    }
                    else
                        reader.Close();
                    System.IO.StringWriter writer = new System.IO.StringWriter();
                    tblFacultyTable.WriteXml(writer, XmlWriteMode.IgnoreSchema, false);
                    XmlDocument empDoc = new XmlDocument();
                    Response.ContentType = "text/xml";
                    //Load the XML from a String
                    empDoc.LoadXml(writer.ToString());
                    //Save the XML data onto a file                    
                    empDoc.Save(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                    //The following code will replace the header of the xml file
                    StreamReader streamReader = File.OpenText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                    string contents = streamReader.ReadToEnd();
                    streamReader.Close();
                    StreamWriter streamWriter = File.CreateText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                    streamWriter.Write(contents.Replace("<DocumentElement>", "<?xml version='1.0' encoding='UTF-8'?> <dataroot xmlns:od='urn:schemas-microsoft-com:officedata' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'  generated='2009-12-05T16:44:44'> "));
                    streamWriter.Close();
                    StreamReader streamReader2 = File.OpenText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                    string contents2 = streamReader2.ReadToEnd();
                    streamReader2.Close();
                    StreamWriter streamWriter2 = File.CreateText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                    streamWriter2.Write(contents2.Replace("</DocumentElement>", "</dataroot>"));
                    streamWriter2.Close();
                    //end of the replacing code
                    Response.ContentType = "text/xml";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Session["userName"].ToString() + ".xml");
                    Response.TransmitFile(Server.MapPath("~/reports/" + Session["userName"].ToString() + ".xml"));
                    Response.End();
                }
                else
                    if (strCurrentRole == "staff")
                    {
                        reader = objProgram.gRetrieveRecord(strCurrentQuery);
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tblEmployeesTable.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString(), reader["MNAMES"].ToString()
                                    , reader["SURNAME"].ToString(), reader["BIRTHDTE"].ToString(), reader["GENDER"].ToString(), reader["NATION"].ToString()
                                , reader["MRSTATUS"].ToString(), reader["RELGN"].ToString(), reader["EMAIL"].ToString(), reader["INSTID"].ToString(), reader["CITYLOC"].ToString()
                                , reader["EMPID"].ToString(), reader["RANK"].ToString(), reader["APPTDATE"].ToString(), reader["DEPTID"].ToString(), reader["STRTDATE"].ToString()
                                , reader["HQHELD"].ToString(), reader["BASCSAL"].ToString(), reader["MNTHSAL"].ToString(), reader["ACCOM"].ToString());
                            }
                            reader.Close();
                        }
                        else
                            reader.Close();
                        System.IO.StringWriter writer = new System.IO.StringWriter();
                        tblEmployeesTable.WriteXml(writer, XmlWriteMode.IgnoreSchema,true);
                        XmlDocument empDoc = new XmlDocument();
                        Response.ContentType = "text/xml";
                        //Load the XML from a String
                        empDoc.LoadXml(writer.ToString());
                        //Save the XML data onto a file                    
                        empDoc.Save(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                       
                        //The following code will be used to reformat the heading of the xml file
                        //The following code will replace the header of the xml file
                        StreamReader streamReader = File.OpenText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                        string contents = streamReader.ReadToEnd();
                        streamReader.Close();
                        StreamWriter streamWriter = File.CreateText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                        streamWriter.Write(contents.Replace("<DocumentElement>", "<?xml version='1.0' encoding='UTF-8'?> <dataroot xmlns:od='urn:schemas-microsoft-com:officedata' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'  generated='2009-12-05T16:44:44'> "));
                        streamWriter.Close();
                        StreamReader streamReader2 = File.OpenText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                        string contents2 = streamReader2.ReadToEnd();
                        streamReader2.Close();
                        StreamWriter streamWriter2 = File.CreateText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                        streamWriter2.Write(contents2.Replace("</DocumentElement>", "</dataroot>"));
                        streamWriter2.Close();
                        //end of the replacing code
                        Response.ContentType = "text/xml";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Session["userName"].ToString() + ".xml");
                        Response.TransmitFile(Server.MapPath("~/reports/" + Session["userName"].ToString() + ".xml"));
                        Response.End();
                    }
                    else
                        if (strCurrentRole == "student")
                        {
                            reader = objProgram.gRetrieveRecord(strCurrentQuery);
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    tblStudentTable.Rows.Add(reader["FNAME"].ToString(), reader["MNAMES"].ToString(), reader["SURNAME"].ToString()
                                        , reader["NATID"].ToString(), reader["BIRTHDTE"].ToString(), reader["GENDER"].ToString(), reader["NATION"].ToString()
                                    , reader["HSTYPE"].ToString(), reader["HSYEAR"].ToString(), reader["HSLOC"].ToString(), reader["HSPERCENT"].ToString()
                                    , reader["APLTEST"].ToString(), reader["ACHVTEST"].ToString(), reader["INSTID"].ToString(), reader["LOCSTDY"].ToString(), reader["STUDID"].ToString()
                                    , reader["COMYEAR"].ToString(), reader["COMSEM"].ToString(), reader["ADMCOLG"].ToString(), reader["CURNTCOLG"].ToString(),
                                    reader["PRVCOLG"].ToString(), reader["SBJQA1"].ToString(), reader["SBJNAME"].ToString(), reader["SBJQA2"].ToString(),
                                    reader["PRSBJ"].ToString(), reader["QUALAIM"].ToString(), reader["STDYLNGTH"].ToString(), reader["UNITLNGTH"].ToString(),
                                    reader["NCREQ"].ToString(), reader["NCREG"].ToString(), reader["NCPASS"].ToString(), reader["TNCPASS"].ToString(), reader["NCREM"].ToString(),
                                     reader["NSREG"].ToString(), reader["SUMSEM"].ToString(), reader["NWDRAW"].ToString(), reader["YEARPRG"].ToString(),
                                    reader["CUMGPA"].ToString(), reader["GPATYPE"].ToString(), reader["NACWARN"].ToString(), reader["GSTATUS"].ToString(),
                                     reader["REGSTATUS"].ToString(), reader["STDYMODE"].ToString(), reader["SCLRSHIP"].ToString(), reader["TRANS"].ToString(),
                                      reader["QUAL"].ToString(), reader["CLASS"].ToString(), reader["ACCOM"].ToString());
                                }
                                reader.Close();
                            }
                            else
                                reader.Close();
                            System.IO.StringWriter writer = new System.IO.StringWriter();
                            tblStudentTable.WriteXml(writer, XmlWriteMode.IgnoreSchema, false);
                            XmlDocument empDoc = new XmlDocument();
                            Response.ContentType = "text/xml";
                            //Load the XML from a String
                            empDoc.LoadXml(writer.ToString());
                            //Save the XML data onto a file                    
                            empDoc.Save(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                            //Response.Write(empDoc.InnerXml);
                            //The following code will replace the header of the xml file
                            StreamReader streamReader = File.OpenText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                            string contents = streamReader.ReadToEnd();
                            streamReader.Close();
                            StreamWriter streamWriter = File.CreateText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                            streamWriter.Write(contents.Replace("<DocumentElement>", "<?xml version='1.0' encoding='UTF-8'?> <dataroot xmlns:od='urn:schemas-microsoft-com:officedata' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'  generated='2009-12-05T16:44:44'> "));
                            streamWriter.Close();
                            StreamReader streamReader2 = File.OpenText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                            string contents2 = streamReader2.ReadToEnd();
                            streamReader2.Close();
                            StreamWriter streamWriter2 = File.CreateText(Server.MapPath("reports\\" + Session["userName"].ToString() + ".xml"));
                            streamWriter2.Write(contents2.Replace("</DocumentElement>", "</dataroot>"));
                            streamWriter2.Close();
                            //end of the replacing code
                            Response.ContentType = "text/xml";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Session["userName"].ToString() + ".xml");
                            Response.TransmitFile(Server.MapPath("~/reports/" + Session["userName"].ToString() + ".xml"));
                            Response.End();
                        }
            }
           
            
           
        }
        catch (Exception exp)
        {

        }
    }
    protected void mFillGridByCategory()
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to display the report according to the selected category
        /// Author: mutawakelm
        /// Date :3/7/2010 11:35:47 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            tblReport.Columns.Add("nationalID");
            tblReport.Columns.Add("userFullName");
            tblReport.Columns.Add("role");
            tblReport.Columns.Add("by");
            string strCategoryQuery = "";
            string strFromDate=txtFromDate.Text;
            string strToDate=txtToDate.Text;
            int RecordsCounter = 0;
            ReportGrid.CurrentPageIndex = 0;
            //The following code will display the report according to the selected category
            if (ddlCategory.SelectedItem.Value == "1")
            {
                //The following code will clear the reports grid
                ReportGrid.DataSource = null;
                ReportGrid.DataBind();
                //The following code will fill the report grid
                strCategoryQuery = "SELECT st.*,us.full_name FROM STUDENT as st join system_user_table as us on st.user_name=us.user_name  WHERE st.user_name='" + Session["userName"].ToString() + "'";
                if ((strFromDate != "") && (strToDate != ""))
                    strCategoryQuery += " and (st.creation_date >='" + strFromDate + " 00:00:01 AM'" + " and st.creation_date<='" + strToDate + " 11:59:00 PM')";
                strCurrentQuery = strCategoryQuery;
                strCurrentRole = "student";
                reader = objProgram.gRetrieveRecord(strCategoryQuery);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tblReport.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString(), "Student", reader["full_name"].ToString());
                        RecordsCounter++;
                    }
                    reader.Close();
                }
                else
                    reader.Close();
                lblReportTitle.Text = "Report of Entered Students";
                ReportGrid.DataSource = tblReport;
                ReportGrid.DataBind();
                lblRecordNo.Text = RecordsCounter.ToString();
            }
            else
                if (ddlCategory.SelectedItem.Value == "2")
                {
                    ReportGrid.DataSource = null;
                    ReportGrid.DataBind();
                    lblReportTitle.Text = "";
                    //The following code will fill the report grid
                    strCategoryQuery = "SELECT fa.*,us.full_name FROM FACULTY as fa join system_user_table as us on fa.user_name=us.user_name  WHERE fa.user_name='" + Session["userName"].ToString()+ "'";
                    if ((strFromDate != "") && (strToDate != ""))
                        strCategoryQuery += " and (fa.creation_date >='" + strFromDate + " 00:00:01 AM'" + " and fa.creation_date<='" + strToDate + " 11:59:00 PM')";
                    strCurrentQuery = strCategoryQuery;
                    strCurrentRole = "faculty";
                    reader = objProgram.gRetrieveRecord(strCategoryQuery);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tblReport.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString(), "Faculty", reader["full_name"].ToString());
                            RecordsCounter++;
                        }
                        reader.Close();
                    }
                    else
                        reader.Close();
                    lblReportTitle.Text = "Report of Entered Faculty";
                    ReportGrid.DataSource = tblReport;
                    ReportGrid.DataBind();
                    lblRecordNo.Text = RecordsCounter.ToString();

                }
                else
                    if (ddlCategory.SelectedItem.Value == "3")
                    {
                        ReportGrid.DataSource = null;
                        ReportGrid.DataBind();
                        lblReportTitle.Text = "";
                        //The following code will fill the report grid
                        strCategoryQuery = "SELECT staff.*,us.full_name FROM STAFF staff  join system_user_table as us on staff.user_name=us.user_name  WHERE staff.user_name='" + Session["userName"].ToString() + "'";
                        if ((strFromDate != "") && (strToDate != ""))
                            strCategoryQuery += " and (staff.creation_date >='" + strFromDate + " 00:00:01 AM'" + " and staff.creation_date<='" + strToDate + " 11:59:00 PM')";
                        strCurrentQuery = strCategoryQuery;
                        strCurrentRole = "staff";
                        reader = objProgram.gRetrieveRecord(strCategoryQuery);
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tblReport.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString(), "Employee", reader["full_name"].ToString());
                                RecordsCounter++;
                            }
                            reader.Close();
                        }
                        else
                            reader.Close();
                        lblReportTitle.Text = "Report of Entered Employee";
                        ReportGrid.DataSource = tblReport;
                        ReportGrid.DataBind();
                        lblRecordNo.Text = RecordsCounter.ToString();
                    }
        }
        catch (Exception exp)
        {
        }
    }
    protected void reportGrid_pageIndexChanged(object sender, DataGridPageChangedEventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to change the paging index of the data grid "reportGrid"
        /// Author: mutawakelm
        /// Date :3/7/2010 1:29:40 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (chkCamups.Checked == false)
                mFillGridByCategory();
            else
                if (chkCamups.Checked == true)
                    mFillGridBySelectdCreterias();
            ReportGrid.CurrentPageIndex = e.NewPageIndex;
            ReportGrid.DataBind();
        }
        catch (Exception exp)
        {

        }
    }
    protected void mDisplayDetails(object source, DataGridCommandEventArgs e)
    {
        try
        {
            TableCell itemCell = e.Item.Cells[2];
            string strFaculyID = itemCell.Text;
            
            
        }
        catch (Exception exp)
        {
        }
    }
    protected void mDisplayPdfFile(object sender, EventArgs e)
    {
        try
        {
            if (chkCamups.Checked == false)
            {
                ReportGrid.AllowPaging = false;
                mFillGridByCategory();

            }
            else
                if (chkCamups.Checked == true)
            {
                ReportGrid.AllowPaging = false;
                mFillGridBySelectdCreterias();
            }
            if (ReportGrid.Items.Count > 0)
                GeneralClass.ResponseWriter.Write(Response, "Export.pdf", new GeneralClass.PdfDataGridExporter(ReportGrid, Context, lblReportTitle.Text));
            
        }
        catch (Exception exp)
        {
        }
    }
    protected void mCampusCheckChanged(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to check the status of the cehck box "chkCamups"
        /// Author: mutawakelm
        /// Date :3/8/2010 11:25:05 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (chkCamups.Checked == true)
            {
                ddlCampus.Enabled = true;
                lblCampus.Enabled = true;
                chkDepartment.Enabled = true;
                chkCollege.Enabled = true;
            }
            else
                if (chkCamups.Checked == false)
                {
                    ddlDepartment.SelectedIndex = 0;
                    ddlCollege.SelectedIndex = 0;
                    chkCollege.Checked = false;
                    chkDepartment.Checked = false;
                    ddlCampus.Enabled = false;
                    lblCampus.Enabled = false;
                    chkDepartment.Enabled = false;
                    lblDepartment.Enabled = false;
                    ddlDepartment.Enabled = false;
                    chkCollege.Enabled = false;
                    lblCollege.Enabled = false;
                    ddlCollege.Enabled = false;
                }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mDepartmentCheckChanged(object sender, EventArgs e)
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to check the status of the cehck box "chkDepartment"
        /// Author: mutawakelm
        /// Date :3/8/2010 11:25:05 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (chkDepartment.Checked == true)
            {
                lblDepartment.Enabled = true;
                ddlDepartment.Enabled = true;
            }
            else
                if (chkDepartment.Checked == false)
                {
                    ddlDepartment.SelectedIndex =0;
                    lblDepartment.Enabled = false;
                    ddlDepartment.Enabled = false;
                }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mCollegeCheckChanged(object sender, EventArgs e)
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to check the status of the cehck box "chkCollege"
        /// Author: mutawakelm
        /// Date :3/8/2010 11:25:05 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            
               
            if (chkCollege.Checked == true)
            {
                lblCollege.Enabled = true;
                ddlCollege.Enabled = true;
            }
            else
                if (chkCollege.Checked == false)
                {
                    ddlCollege.SelectedIndex =0;
                    lblCollege.Enabled = false;
                    ddlCollege.Enabled = false;
                }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mGenerateXML(object sender, EventArgs e)
    {
        try
        {
            if (chkOverallStatistics.Checked == false)
            {
                if (chkCamups.Checked == false)
                {
                    mFillGridByCategory();
                }
                else
                    if (chkCamups.Checked == true)
                    {
                        mFillGridBySelectdCreterias();
                    }
            }
            else
                if (chkOverallStatistics.Checked == true)
                {
                    if (ddlCategory.SelectedItem.Value == "1")
                    {
                        strCurrentRole = "student";
                        strCurrentQuery = "SELECT * FROM STUDENT";
                    }
                    else
                        if (ddlCategory.SelectedItem.Value == "2")
                        {
                            strCurrentRole = "faculty";
                            strCurrentQuery = "SELECT * FROM FACULTY";
                        }
                        else
                            if (ddlCategory.SelectedItem.Value == "3")
                            {
                                strCurrentRole = "staff";
                                strCurrentQuery = "SELECT * FROM STAFF";
                            }
                }
            
            mConvertToXml();
        }
        catch (Exception exp)
        {
        }
    }
     

}
