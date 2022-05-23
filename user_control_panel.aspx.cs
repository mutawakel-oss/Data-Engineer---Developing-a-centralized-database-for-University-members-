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
            if ((Session["controlPanel"] != null) && (Session["userName"] != null))
            {
                if (!IsPostBack)
                {
                    Page.RegisterStartupScript("SetFocus", "<script>document.getElementById('" + txtUserName.ClientID + "').focus();</script>");
                    mFillUserGrid();
                    mFillCollegeList();
                    mFillDepartment();
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
    protected void mFillCollegeList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the list "chkCollege" with the colleges list
        /// Author: mutawakelm
        /// Date :3/1/2010 10:03:06 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strCollegteQuery = "SELECT code,college_name FROM college_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strCollegteQuery);
            if (reader.HasRows)
            {

                chkCollege.Items.Clear();
                while (reader.Read())
                {
                    chkCollege.Items.Add(reader["college_name"].ToString());
                    chkCollege.Items[counter].Value=reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if(reader!=null)
                reader.Close();
        }
    }
    protected void mFillDepartment()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the list "chkDepartment" with the system departments
        /// Author: mutawakelm
        /// Date :3/1/2010 10:09:30 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strDepartmentQuery = "SELECT code,department_name FROM department_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strDepartmentQuery);
            if (reader.HasRows)
            {

                chkDepartment.Items.Clear();
                while (reader.Read())
                {
                    chkDepartment.Items.Add(reader["department_name"].ToString());
                    chkDepartment.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillUserGrid()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the user grid with the list of system users
        /// Author: mutawakelm
        /// Date :2/27/2010 12:03:35 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            GeneralClass.user user = new GeneralClass.user();
            DataTable tblSystemUsers = user.mFindSystemUsers();
            gridUsers.DataSource = tblSystemUsers;
            gridUsers.DataBind();

        }
        catch (Exception exp)
        {

        }
    }
    protected void mSearch(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to add the username as a user of the system
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
            bool available = false;
            string strAvailablitityQuery = "SELECT * FROM system_user_table WHERE user_name='"+txtUserName.Text+"'";
            reader = objProgram.gRetrieveRecord(strAvailablitityQuery);
            if (reader.HasRows)
            {
                reader.Read();
                available = true;
                reader.Close();
            }
            else
                reader.Close();
            //The following code will add the new user in case of unavialbility
            if (available == false)
            {
                objProgram.Add("user_name",txtUserName.Text,"S");
                objProgram.Add("full_name",txtFull.Text,"S");
                objProgram.InsertRecordStatement("system_user_table");
            }
            else
                MessageBox.MessageBox.Show("User record is already exist.");
                mFillUserGrid();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
  
  
    protected void mDisplaySpecification(object source, DataGridCommandEventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the "employee_home_page" with the result data
        /// Author: mutawakelm
        /// Date :1/25/2010 2:38:24 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            //TableCell itemCell = e.Item.Cells[1];
            //string strFaculyID = itemCell.Text;
            //GeneralClass.faculty FacultyFinder = new GeneralClass.faculty();
            //GeneralClass.faculty foundedFaculty = FacultyFinder.mFindFaculty(strFaculyID);
            ////The following code will be used to fill the founded employee data
            //txtFirstName.Text = foundedFaculty.getFirstName();
            //txtMiddleName.Text = foundedFaculty.getMiddleName();
            //txtLastName.Text = foundedFaculty.getLastName();
            //txtNationalId.Text = foundedFaculty.getNationalID();
            //txtBirthDate.Text = foundedFaculty.getBirthDate();
            //ddlGender.SelectedValue = foundedFaculty.getGender();
            //ddlNationality.SelectedValue = foundedFaculty.getNationality();
            //ddlMaritalStatus.SelectedValue = foundedFaculty.getMaritalStatus();
            //ddlReligion.SelectedValue = foundedFaculty.getRelegion();
            //txtEmail.Text = foundedFaculty.getEmail();
            //txtInstitutionID.Text = foundedFaculty.getInstitutionID();
            //ddlLocation.SelectedValue = foundedFaculty.getCityLocation();
            //txtBadgeNo.Text = foundedFaculty.getBadgeId();
            //ddlPosition.SelectedValue = foundedFaculty.getRank();
            //txtHiringDate.Text = foundedFaculty.getApptDate();
            //ddlDepartment.SelectedValue = foundedFaculty.getDepartmentID();
            //txtStartHiringDate.Text = foundedFaculty.getStartDate();
            //ddlDegree.SelectedValue = foundedFaculty.getDegree();
            //txtBasicSalary.Text = foundedFaculty.getBasicSalary();
            //txtTotalSalary.Text = foundedFaculty.getMonthlySalary();
            //ddlAccommodation.SelectedValue = foundedFaculty.getAccommodation();
            //ddlCollege.SelectedValue = foundedFaculty.getCollege();
            //ddlHiringCategory.SelectedValue = foundedFaculty.getHiringCategory();
            //ddlHiringStatus.SelectedValue = foundedFaculty.getHiringStatus();
            //txtGraduationDate.Text = foundedFaculty.getGradutionDate();
            //txtGraduationOrg.Text = foundedFaculty.getGraduationOrganization();
            //ddlGraduationCountry.SelectedValue = foundedFaculty.getGraduationCountry();
            //ddlMajorSpecialization.SelectedValue = foundedFaculty.getMajorField();
            //txtMajorSpecializationName.Text = foundedFaculty.getMajorFieldName();
            //txtAdvancedField.Text = foundedFaculty.getAdvancedFied();
            //ddlCurrentOrganization.SelectedValue = foundedFaculty.getCurrentOrganization();
            //ddlPositionDescription.SelectedValue = foundedFaculty.getPositionDescription();

        }
        catch (Exception exp)
        {
        }
    }
    protected void mDeleteEmployee(object source, DataGridCommandEventArgs e)
    {


        //=====================================================//
        /// <summary>
        /// Description:This function will be used to delete the records selected by the users.
        /// Author: mutawakelm
        /// Date :1/26/2010 10:38:50 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            TableCell nameCell = e.Item.Cells[0];
            TableCell userNameCell = e.Item.Cells[1];
            string strUserFullName = nameCell.Text;
            string strUserName = userNameCell.Text;
            txtUserFullName.Text = strUserFullName;
            lblHiddenUserName.Text = strUserName;
            //The following code will fill the grade of previliges
            mFillPreviligesGrid();
            mpeUserPreviliges.Show();
            

        }
        catch (Exception exp)
        {
        }
    }
    protected void mCheckPreviligeItems(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to check the selected privilege 
        /// Author: mutawakelm
        /// Date :3/1/2010 9:42:05 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (ddlPrevilige.SelectedValue == "1")
            {
                
                rowCollege.Visible = true;
                rowDepartment.Visible = true;
                mpeUserPreviliges.Show();
            }
            else
                if (ddlPrevilige.SelectedValue == "2")
                {
                    rowDepartment.Visible = false;
                    rowCollege.Visible = true;
                    mpeUserPreviliges.Show();
                }
                else
                    if (ddlPrevilige.SelectedValue == "3")
                    {
                        rowCollege.Visible = false;
                        rowDepartment.Visible = true;
                        mpeUserPreviliges.Show();
                    }
                    else
                        if (ddlPrevilige.SelectedValue == "4")
                        {
                            rowCollege.Visible = true;
                            rowDepartment.Visible = true;
                            mpeUserPreviliges.Show();
                        }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mAddPreviliges(object sender, EventArgs e)
    {
        //=====================================================//
        /// <summary>
        /// Description:This functin will be used to add/edit the previliges for the selected user.
        /// Author: mutawakelm
        /// Date :3/1/2010 11:01:07 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strSelectedCampuses="";
            string strSelectedColleges = "";
            string strSelectedDepartments = "";
            string strGainedPrivileges = "";
            string strAccummulatedMessage="";
            string strAdministrativePreviliges = "";
            int returnID = 0;
            if (chkAdministration.Checked == true)
                strAdministrativePreviliges = "yes";
            else
                if (chkAdministration.Checked == false)
                    strAdministrativePreviliges = "";
            if (ddlPrevilige.SelectedValue == "1")
            {
                //The following code will collect the selected campuses
                for (int i = 0; i < chkCampus.Items.Count;i++ )
                {
                    if (chkCampus.Items[i].Selected == true)
                        strSelectedCampuses += chkCampus.Items[i].Value+",";

                }
                if(strSelectedCampuses.Length>0)
                strSelectedCampuses = strSelectedCampuses.Substring(0, strSelectedCampuses.Length-1);
                //The following code will collect the selected colleges

                for (int i = 0; i < chkCollege.Items.Count; i++)
                {
                    if (chkCollege.Items[i].Selected == true)
                        strSelectedColleges += chkCollege.Items[i].Value + ",";

                }
                if (strSelectedColleges.Length > 0)
                strSelectedColleges = strSelectedColleges.Substring(0, strSelectedColleges.Length - 1);
                //The following code will collect the selected departments

                for (int i = 0; i < chkDepartment.Items.Count; i++)
                {
                    if (chkDepartment.Items[i].Selected == true)
                        strSelectedDepartments += chkDepartment.Items[i].Value + ",";

                }
                if (strSelectedDepartments.Length > 0)
                strSelectedDepartments = strSelectedDepartments.Substring(0, strSelectedDepartments.Length - 1);
                //The following code will be used to update the system users table with the selected privilegs
                if ((strSelectedCampuses != "") && (strSelectedColleges != "") && (strSelectedDepartments != ""))
                {
                    objProgram.Add("faculty_entry", strSelectedCampuses + "|" + strSelectedColleges + "|" + strSelectedDepartments,"S");
                    returnID= objProgram.UpdateRecordStatement("system_user_table", "user_name", "'"+lblHiddenUserName.Text+"'");
                    if ((returnID != -1) && (returnID != 0))
                        MessageBox.MessageBox.Show("Privilges was updated successfully. ");
                }
                else
                {
                    if (strSelectedCampuses == "")
                        strAccummulatedMessage+="\n- You should select at least one campus.";
                    if (strSelectedColleges == "")
                        strAccummulatedMessage += "\n- You should select at least one college.";
                    if(strSelectedDepartments=="")
                        strAccummulatedMessage += "\n- You should select at least one department.";
                    MessageBox.MessageBox.Show(strAccummulatedMessage);
                    mpeUserPreviliges.Show();
                }

            }
            else
                if (ddlPrevilige.SelectedValue == "2")
                {
                    //The following code will collect the selected campuses
                    for (int i = 0; i < chkCampus.Items.Count; i++)
                    {
                        if (chkCampus.Items[i].Selected == true)
                            strSelectedCampuses += chkCampus.Items[i].Value + ",";

                    }
                    if (strSelectedCampuses.Length > 0)
                        strSelectedCampuses = strSelectedCampuses.Substring(0, strSelectedCampuses.Length - 1);
                    //The following code will collect the selected colleges

                    for (int i = 0; i < chkCollege.Items.Count; i++)
                    {
                        if (chkCollege.Items[i].Selected == true)
                            strSelectedColleges += chkCollege.Items[i].Value + ",";

                    }
                    if (strSelectedColleges.Length > 0)
                        strSelectedColleges = strSelectedColleges.Substring(0, strSelectedColleges.Length - 1);
                    //The following code will be used to update the system users table with the selected privilegs
                    if ((strSelectedCampuses != "") && (strSelectedColleges != ""))
                    {
                        objProgram.Add("student_entry", strSelectedCampuses + "|" + strSelectedColleges, "S");
                        returnID = objProgram.UpdateRecordStatement("system_user_table", "user_name", "'" + lblHiddenUserName.Text + "'");
                        if ((returnID != -1) && (returnID != 0))
                            MessageBox.MessageBox.Show("Privilges was updated successfully. ");
                    }
                    else
                    {
                        if (strSelectedCampuses == "")
                            strAccummulatedMessage += "\n - You should select at least one campus.";
                        if (strSelectedColleges == "")
                            strAccummulatedMessage += "\n - You should select at least one college.";
                       
                        MessageBox.MessageBox.Show(strAccummulatedMessage);
                        mpeUserPreviliges.Show();
                    }
                }
              else
                    if (ddlPrevilige.SelectedValue == "3")
                    {
                        //The following code will collect the selected campuses
                        for (int i = 0; i < chkCampus.Items.Count; i++)
                        {
                            if (chkCampus.Items[i].Selected == true)
                                strSelectedCampuses += chkCampus.Items[i].Value + ",";

                        }
                        if (strSelectedCampuses.Length > 0)
                            strSelectedCampuses = strSelectedCampuses.Substring(0, strSelectedCampuses.Length - 1);
                        //The following code will collect the selected departments

                        for (int i = 0; i < chkDepartment.Items.Count; i++)
                        {
                            if (chkDepartment.Items[i].Selected == true)
                                strSelectedDepartments += chkDepartment.Items[i].Value + ",";

                        }
                        if (strSelectedDepartments.Length > 0)
                            strSelectedDepartments = strSelectedDepartments.Substring(0, strSelectedDepartments.Length - 1);
                        //The following code will be used to update the system users table with the selected privilegs
                        if ((strSelectedCampuses != "") && (strSelectedDepartments != ""))
                        {
                            objProgram.Add("employee_entry", strSelectedCampuses + "|" + strSelectedDepartments, "S");
                            returnID = objProgram.UpdateRecordStatement("system_user_table", "user_name", "'" + lblHiddenUserName.Text + "'");
                            if ((returnID != -1) && (returnID != 0))
                                MessageBox.MessageBox.Show("Privilges was updated successfully. ");
                        }
                        else
                        {
                            if (strSelectedCampuses == "")
                                strAccummulatedMessage += "\n - You should select at least one campus.";
                            if (strSelectedDepartments == "")
                                strAccummulatedMessage += "\n - You should select at least one department.";

                            MessageBox.MessageBox.Show(strAccummulatedMessage);
                            mpeUserPreviliges.Show();
                        }
                    }
                    else
                        if (ddlPrevilige.SelectedValue == "4")
                        {
                            //The following code will collect the selected campuses
                            for (int i = 0; i < chkCampus.Items.Count; i++)
                            {
                                if (chkCampus.Items[i].Selected == true)
                                    strSelectedCampuses += chkCampus.Items[i].Value + ",";

                            }
                            if (strSelectedCampuses.Length > 0)
                                strSelectedCampuses = strSelectedCampuses.Substring(0, strSelectedCampuses.Length - 1);
                            //The following code will collect the selected colleges

                            for (int i = 0; i < chkCollege.Items.Count; i++)
                            {
                                if (chkCollege.Items[i].Selected == true)
                                    strSelectedColleges += chkCollege.Items[i].Value + ",";

                            }
                            if (strSelectedColleges.Length > 0)
                                strSelectedColleges = strSelectedColleges.Substring(0, strSelectedColleges.Length - 1);
                            //The following code will collect the selected departments

                            for (int i = 0; i < chkDepartment.Items.Count; i++)
                            {
                                if (chkDepartment.Items[i].Selected == true)
                                    strSelectedDepartments += chkDepartment.Items[i].Value + ",";

                            }
                            if (strSelectedDepartments.Length > 0)
                                strSelectedDepartments = strSelectedDepartments.Substring(0, strSelectedDepartments.Length - 1);
                            //The following code will be used to update the system users table with the selected privilegs
                            if ((strSelectedCampuses != "") && (strSelectedColleges != "") && (strSelectedDepartments != ""))
                            {
                                objProgram.Add("report_viewer", strSelectedCampuses + "|" + strSelectedColleges + "|" + strSelectedDepartments, "S");
                                
                                returnID = objProgram.UpdateRecordStatement("system_user_table", "user_name", "'" + lblHiddenUserName.Text + "'");
                                if ((returnID != -1) && (returnID != 0))
                                    MessageBox.MessageBox.Show("Privilges was updated successfully. ");
                            }
                            else
                            {
                                if (strSelectedCampuses == "")
                                    strAccummulatedMessage += "\n- You should select at least one campus.";
                                if (strSelectedColleges == "")
                                    strAccummulatedMessage += "\n- You should select at least one college.";
                                if (strSelectedDepartments == "")
                                    strAccummulatedMessage += "\n- You should select at least one department.";
                                MessageBox.MessageBox.Show(strAccummulatedMessage);
                                mpeUserPreviliges.Show();
                            }
                        }
                
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillPreviligesGrid()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the previliges grid.
        /// Author: mutawakelm
        /// Date :3/1/2010 2:13:08 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strPreviligesQuery = "";
            string strFacultyPreviliges = "";
            string strFacultyCampuses = "";
            string strFacultyColleges = "";
            string strFacultyDepts = "";
            string strFaculatyFormattedCampuses="Cmapuses: ";
            string strFacultyFormattedColleges = "Colleges: ";
            string strFacultyFormattedDepartment = "Departments: ";
            string strFacultyFormattedPreviliges = "";

            string strStudentPreviliges = "";
            string strStudentCampuses = "";
            string strStudentColleges = "";
            string strStudentFormattedCampuses="Campuses: ";
            string strStudentFormattedColleges="Colleges: ";
            string strStudentFormattedPreviliges = "";

            string strEmployeePreviliges = "";
            string strEmployeeCampuses = "";
            string strEmployeeDepts = "";
            string strEmployeeFormattedCampuses="Campuses: ";
            string strEmployeeFormattedDepts="Departments: ";
            string strEmployeeFormattedPreviliges = "";

            string strReportPreviliges = "";
            string strReportCampuses = "";
            string strReportColleges = "";
            string strReportDepts = "";
            string strReportFormattedCampuses = "Campuses: ";
            string strReportFormattedColleges = "Colleges: ";
            string strReportFormattedDepartments = "Departments: ";
            string strReportFormattedPreviliges = "";

            DataTable tblUserPreviliges = new DataTable();
            tblUserPreviliges.Columns.Add("faculty_entry");
            tblUserPreviliges.Columns.Add("student_entry");
            tblUserPreviliges.Columns.Add("employee_entry");
            tblUserPreviliges.Columns.Add("report_review");
           
            strPreviligesQuery = "SELECT * FROM system_user_table WHERE user_name='"+lblHiddenUserName.Text+"'";
            reader = objProgram.gRetrieveRecord(strPreviligesQuery);
            if (reader.HasRows)
            {
                reader.Read();
                strFacultyPreviliges = reader["faculty_entry"].ToString();
                strStudentPreviliges = reader["student_entry"].ToString();
                strEmployeePreviliges = reader["employee_entry"].ToString();
                strReportPreviliges = reader["report_viewer"].ToString();
                reader.Close();
            }
            else
                reader.Close();
            //The following code will retrieve the Facutly Previliges
            if (strFacultyPreviliges != "")
            {
                string[] facultyPreviligesSplitter = strFacultyPreviliges.Split('|');
                strFacultyCampuses = facultyPreviligesSplitter[0];
                string[] facultyCampusesSplitter = strFacultyCampuses.Split(',');
                for (int i = 0; i < facultyCampusesSplitter.Length; i++)
                    strFaculatyFormattedCampuses += mRetrieveCampus(facultyCampusesSplitter[i]) + ",";
                strFacultyColleges = facultyPreviligesSplitter[1];
                string[] facultyCollegeSplitter = strFacultyColleges.Split(',');
                for (int i = 0; i < facultyCollegeSplitter.Length; i++)
                    strFacultyFormattedColleges += mRetrieveCollege(facultyCollegeSplitter[i]) + ",";
                strFacultyDepts = facultyPreviligesSplitter[2];
                string[] facultyDepartmentSplitter = strFacultyDepts.Split(',');
                for (int i = 0; i < facultyDepartmentSplitter.Length; i++)
                    strFacultyFormattedDepartment += mRetrieveDepartment(facultyDepartmentSplitter[i]) + ",";
                strFacultyFormattedPreviliges = strFaculatyFormattedCampuses.Substring(0, strFaculatyFormattedCampuses.Length - 1) + "<hr>" + strFacultyFormattedColleges.Substring(0, strFacultyFormattedColleges.Length - 1) + "<hr>" + strFacultyFormattedDepartment.Substring(0, strFacultyFormattedDepartment.Length - 1);
            }
            
            //The following code will be used to get the student entry prvivileges
            if (strStudentPreviliges!="")
            {
            string[] studentPreviligesSplitter = strStudentPreviliges.Split('|');
            strStudentCampuses = studentPreviligesSplitter[0];
            strStudentColleges = studentPreviligesSplitter[1];
            string[] studentCampusesSplitter = strStudentCampuses.Split(',');
            for (int i = 0; i < studentCampusesSplitter.Length; i++)
                strStudentFormattedCampuses += mRetrieveCampus(studentCampusesSplitter[i]) + ",";
            string[] studentCollegesSplitter = strStudentColleges.Split(',');
            for (int i = 0; i < studentCollegesSplitter.Length; i++)
                strStudentFormattedColleges += mRetrieveCollege(studentCollegesSplitter[i]) + ",";
            strStudentFormattedPreviliges = strStudentFormattedCampuses.Substring(0, strStudentFormattedCampuses.Length - 1) + "<hr>" + strStudentFormattedColleges.Substring(0, strStudentFormattedColleges.Length-1);
            }

            //The following code will be used to get the Employee entry prvivileges
            if (strEmployeePreviliges != "")
            {
                string[] employeePreviligesSplitter = strEmployeePreviliges.Split('|');
                strEmployeeCampuses = employeePreviligesSplitter[0];
                strEmployeeDepts = employeePreviligesSplitter[1];
                string[] employeeCampusesSplitter = strEmployeeCampuses.Split(',');
                for (int i = 0; i < employeeCampusesSplitter.Length; i++)
                    strEmployeeFormattedCampuses += mRetrieveCampus(employeeCampusesSplitter[i]) + ",";
                string[] employeeDeptsSplitter = strEmployeeDepts.Split(',');
                for (int i = 0; i < employeeDeptsSplitter.Length; i++)
                    strEmployeeFormattedDepts += mRetrieveDepartment(employeeDeptsSplitter[i]) + ",";
                strEmployeeFormattedPreviliges = strEmployeeFormattedCampuses.Substring(0, strEmployeeFormattedCampuses.Length - 1) + "<hr>" + strEmployeeFormattedDepts.Substring(0, strEmployeeFormattedDepts.Length - 1);
            }
            //The following code will be used to get the report review prvivileges
            if (strReportPreviliges != "")
            {
                string[] reportPreviligesSplitter = strReportPreviliges.Split('|');
                strReportCampuses = reportPreviligesSplitter[0];
                string[] reportCampusesSplitter = strReportCampuses.Split(',');
                for (int i = 0; i < reportCampusesSplitter.Length; i++)
                    strReportFormattedCampuses += mRetrieveCampus(reportCampusesSplitter[i]) + ",";
                strReportColleges = reportPreviligesSplitter[1];
                string[] reportCollegSplitter = strReportColleges.Split(',');
                for (int i = 0; i < reportCollegSplitter.Length; i++)
                    strReportFormattedColleges += mRetrieveCollege(reportCollegSplitter[i]) + ",";
                strReportDepts = reportPreviligesSplitter[2];
                string[] reportDeptsSplitter = strReportDepts.Split(',');
                for (int i = 0; i < reportDeptsSplitter.Length; i++)
                    strReportFormattedDepartments += mRetrieveDepartment(reportDeptsSplitter[i]) + ",";
                strReportFormattedPreviliges = strReportFormattedCampuses.Substring(0, strReportFormattedCampuses.Length - 1) + "<hr>" + strReportFormattedColleges.Substring(0, strReportFormattedColleges.Length - 1) + "<hr>" + strReportFormattedDepartments.Substring(0, strReportFormattedDepartments.Length - 1);
            }
            //The following field will fill the datatable "tblUserPreviliges"
            tblUserPreviliges.Rows.Add(strFacultyFormattedPreviliges,strStudentFormattedPreviliges,strEmployeeFormattedPreviliges,strReportFormattedPreviliges);
            grdCurrentPreviliges.DataSource = tblUserPreviliges;
            grdCurrentPreviliges.DataBind();

            
        }
        catch (Exception exp)
        {
        }
    }
    protected string mRetrieveCampus(string strCampusID)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to retrieve a campus name from the ampuses table
        /// Author: mutawakelm
        /// Date :3/1/2010 2:40:32 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string returnedCampusName = "";
            string strCampusesQuery = "SELECT * FROM campus_table WHERE campus_id='"+strCampusID+"'";
            reader = objProgram.gRetrieveRecord(strCampusesQuery);
            if (reader.HasRows)
            {
                reader.Read();
                returnedCampusName= reader["campus_name"].ToString();
                reader.Close();
            }
            else
                reader.Close();
            return returnedCampusName;
            
        }
        catch (Exception exp)
        {
            return null;
        }
    }
    protected string mRetrieveCollege(string strCollegeId)
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to retrieve a college name from the college table
        /// Author: mutawakelm
        /// Date :3/1/2010 2:40:32 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string returnedCollegeName = "";
            string strCollegeQuery = "SELECT * FROM college_table WHERE code='"+strCollegeId+"'";
            reader = objProgram.gRetrieveRecord(strCollegeQuery);
            if (reader.HasRows)
            {
                reader.Read();
                returnedCollegeName = reader["college_name"].ToString();
                reader.Close();
            }
            else
                reader.Close();
            return returnedCollegeName;
        }
        catch (Exception exp)
        {
            return null;
        }
    }
    protected string mRetrieveDepartment(string strDepartmentID)
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to retrieve a department name from the department table
        /// Author: mutawakelm
        /// Date :3/1/2010 2:40:32 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string returnedDepartmentName = "";
            string strDepartmentQuery = "SELECT * FROM department_table WHERE code='" + strDepartmentID + "'";
            reader = objProgram.gRetrieveRecord(strDepartmentQuery);
            if (reader.HasRows)
            {
                reader.Read();
                returnedDepartmentName = reader["department_name"].ToString();
                reader.Close();
            }
            else
                reader.Close();
            return returnedDepartmentName;
        }
        catch (Exception exp)
        {
            return null;
        }
    }


}
