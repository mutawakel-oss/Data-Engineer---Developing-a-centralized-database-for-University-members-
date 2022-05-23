using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    System.Data.Odbc.OdbcDataReader reader;
    GeneralClass.Program objProgram = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataTable tblStudentPreviliges = new DataTable();
            int campusCounter = 0;
            int collegeCounter = 0;
            if ((Session["studentEntry"] != null) && (Session["userName"]!=null))
            {
                if (Session["studentEntry"].ToString() == "true")
                {
                    if (!IsPostBack)
                    {
                        GeneralClass.user user = new GeneralClass.user();
                        tblStudentPreviliges= user.mCheckStudentEntryPrivilges(Session["userName"].ToString());
                        if (tblStudentPreviliges.Rows.Count > 0)
                        {
                            campusCounter = 0;
                            collegeCounter = 0;
                            for (int i = 0; i < tblStudentPreviliges.Rows.Count; i++)
                            {
                                if (tblStudentPreviliges.Rows[i][0].ToString() == "campus")
                                {
                                    ddlCampus.Items.Add(tblStudentPreviliges.Rows[i][2].ToString());
                                    ddlCampus.Items[campusCounter].Value = tblStudentPreviliges.Rows[i][1].ToString();
                                    campusCounter++;

                                }
                                else
                                    if (tblStudentPreviliges.Rows[i][0].ToString() == "college")
                                    {

                                        ddlCollege.Items.Add(tblStudentPreviliges.Rows[i][2].ToString());
                                        ddlCollege.Items[collegeCounter].Value = tblStudentPreviliges.Rows[i][1].ToString();
                                        collegeCounter++;
                                    }
                            }
                        }
                        mFillGenderDropDownList();
                        mFillNationalityDropDownList();
                        mFillSecondaryCetrificate();
                        mFillSecondaryCetrificate();
                        mFillGraduationYear();
                        mFillLocationDropDownList();
                        mFillRegistrationSemester();
                        mFillDegreeDurationDropDownList();
                        mFillPeriodUnitDropDownList();
                        mFillRequiredUnitsDropDownList();
                        mFillRegisteredUnitsDropDownList();
                        mFillRegisteredSemestersDropDownList();
                        mFillSummerSemesterDropDownList();
                        mFillWithdrawnAttemptsDDL();
                        mFillAcademicYearDDL();
                        mFillGpaCreteriaDDL();
                        mFillGeneralStatusDDL();
                        mFillRegistrationStatusDDL();
                        mFillStudyStatusDDL();
                        mFillScholarShipDDL();
                        mFillTrnasferStatusDDL();
                        mFillDegreeWeightDDL();
                        mFillDegreeDropDownList();
                        mFillAccommodationDropDownList();
                        mFillCollegeDropDownList();
                        mFillMajorSpecialiationDropDownList();
                        txtSecondaryPercentage.Text = "999998";
                        txtQudratMark.Text = "998";
                        txtTahsleiMark.Text = "998";
                        ddlPreviousField.SelectedValue = "999998";
                        ddlRequiredUnits.SelectedValue = "998";
                        txtWarnings.Text = "0";
                        ddlScholarShip.SelectedValue = "98";
                        ddlTransferStatus.SelectedValue = "2";
                        ddlGrantedDegree.SelectedValue = "8";
                        ddlGrantedDegree.Enabled = false;
                        ddlDegreeWeight.SelectedValue = "8";
                        ddlDegreeWeight.Enabled = false;
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
  
    protected void mFillSecondaryCetrificate()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the secondary certificate types
        /// Author: mutawakelm
        /// Date :2/20/2010 10:15:59 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strSecondaryTypeQuery = "SELECT code,certificate_type FROM secondary_certificate_type_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strSecondaryTypeQuery);
            if (reader.HasRows)
            {
                ddlSecondaryType.Items.Clear();
                while (reader.Read())
                {
                    ddlSecondaryType.Items.Add(reader["certificate_type"].ToString());
                    ddlSecondaryType.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillGraduationYear()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the secondary school graduation year
        /// Author: mutawakelm
        /// Date :2/20/2010 10:35:12 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            ddlGraduationYear.Items.Clear();
            ddlRegistraitonYear.Items.Clear();
            for (int i = 1370; i <= 1431; i++)
            {
                ddlGraduationYear.Items.Add(i.ToString());
                ddlRegistraitonYear.Items.Add(i.ToString());
            }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillRegistrationSemester()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the registration semester drop down list
        /// Author: mutawakelm
        /// Date :2/20/2010 2:58:03 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strSemesterQuery = "SELECT code,semester_name FROM semester_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strSemesterQuery);
            if (reader.HasRows)
            {

                ddlRegistrationSemester.Items.Clear();
                while (reader.Read())
                {
                    ddlRegistrationSemester.Items.Add(reader["semester_name"].ToString());
                    ddlRegistrationSemester.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();

        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillRequiredUnitsDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the required units drop down list.
        /// Author: mutawakelm
        /// Date :2/20/2010 4:34:42 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            ddlRemainedUnits.Items.Clear();
            ddlTotalPassedUnits.Items.Clear();
            ddlRequiredUnits.Items.Clear();

            for (int i = 1; i < 1000; i++)
            {
                ddlRequiredUnits.Items.Add(i.ToString());
                ddlTotalPassedUnits.Items.Add(i.ToString());
                ddlRemainedUnits.Items.Add(i.ToString());
            }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillRegisteredUnitsDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the required units drop down list.
        /// Author: mutawakelm
        /// Date :2/20/2010 4:34:42 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            
            ddlRegisteredUnits.Items.Clear();
            ddlPassedUnits.Items.Clear();
            for (int i = 1; i < 100; i++)
            {
                ddlRegisteredUnits.Items.Add(i.ToString());
                ddlPassedUnits.Items.Add(i.ToString());
            }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillRegisteredSemestersDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the required units drop down list.
        /// Author: mutawakelm
        /// Date :2/20/2010 4:34:42 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {

            ddlRegisteredSemesters.Items.Clear();
            for (int i = 1; i < 100; i++)
            {
                ddlRegisteredSemesters.Items.Add(i.ToString());
                
            }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillSummerSemesterDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the summer semester drop down list
        /// Author: mutawakelm
        /// Date :2/21/2010 9:29:09 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strCurrentOrganizationQuery = "SELECT code,status FROM summer_semester_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strCurrentOrganizationQuery);
            if (reader.HasRows)
            {

                ddlSummerSemester.Items.Clear();
                while (reader.Read())
                {
                    ddlSummerSemester.Items.Add(reader["status"].ToString());
                    ddlSummerSemester.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillWithdrawnAttemptsDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the withdrawn attempts drop down lists.
        /// Author: mutawakelm
        /// Date :2/21/2010 9:37:40 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            ddlWithdrawnAttempts.Items.Clear();
            for (int i = 0; i < 11; i++)
                ddlWithdrawnAttempts.Items.Add(i.ToString());
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillAcademicYearDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the academic year drop down list.
        /// Author: mutawakelm
        /// Date :2/21/2010 9:43:12 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strCurrentOrganizationQuery = "SELECT code,academic_year FROM academic_year_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strCurrentOrganizationQuery);
            if (reader.HasRows)
            {

                ddlAcademicYear.Items.Clear();
                while (reader.Read())
                {
                    ddlAcademicYear.Items.Add(reader["academic_year"].ToString());
                    ddlAcademicYear.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillGpaCreteriaDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the GPA creteria Drop Down List.
        /// Author: mutawakelm
        /// Date :2/21/2010 9:48:41 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strCurrentOrganizationQuery = "SELECT code,gpa_creteria FROM gpa_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strCurrentOrganizationQuery);
            if (reader.HasRows)
            {

                ddlGpaCreteria.Items.Clear();
                while (reader.Read())
                {
                    ddlGpaCreteria.Items.Add(reader["gpa_creteria"].ToString());
                    ddlGpaCreteria.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillGpaDropDownList(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the GPA drop down list according to the selection of GPA creteria drop down list
        /// Author: mutawakelm
        /// Date :2/21/2010 9:52:53 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (ddlGpaCreteria.SelectedValue == "1")
            {
                rngGpa.MaximumValue = "5";
                rngGpa.MinimumValue = "0";
            }
            else
                if (ddlGpaCreteria.SelectedValue == "2")
                {
                    rngGpa.MaximumValue = "4";
                    rngGpa.MinimumValue = "0";
                }
                else
                    if (ddlGpaCreteria.SelectedValue == "3")
                    {
                        rngGpa.MaximumValue = "100";
                        rngGpa.MinimumValue = "0";
                    }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillGeneralStatusDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the general status drop down list.
        /// Author: mutawakelm
        /// Date :2/21/2010 10:28:49 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strSecondaryTypeQuery = "SELECT code,status FROM student_status_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strSecondaryTypeQuery);
            if (reader.HasRows)
            {

                ddlGeneralStatus.Items.Clear();
                while (reader.Read())
                {
                    ddlGeneralStatus.Items.Add(reader["status"].ToString());
                    ddlGeneralStatus.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillRegistrationStatusDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the general status drop down list.
        /// Author: mutawakelm
        /// Date :2/21/2010 10:28:49 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strSecondaryTypeQuery = "SELECT code,status FROM registration_status_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strSecondaryTypeQuery);
            if (reader.HasRows)
            {

                ddlRegistraitonStatus.Items.Clear();
                while (reader.Read())
                {
                    ddlRegistraitonStatus.Items.Add(reader["status"].ToString());
                    ddlRegistraitonStatus.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillStudyStatusDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the general status drop down list.
        /// Author: mutawakelm
        /// Date :2/21/2010 10:28:49 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strSecondaryTypeQuery = "SELECT code,status FROM study_status_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strSecondaryTypeQuery);
            if (reader.HasRows)
            {

                ddlStudyStatus.Items.Clear();
                while (reader.Read())
                {
                    ddlStudyStatus.Items.Add(reader["status"].ToString());
                    ddlStudyStatus.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mUpdateStudyStatusDDL(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to update the study status drop down list according to the selection of general status drop down list.
        /// Author: mutawakelm
        /// Date :2/21/2010 10:49:18 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (ddlGeneralStatus.SelectedValue != "0")
            {
                ddlStudyStatus.SelectedValue = "8";
            }
            if (ddlGeneralStatus.SelectedValue == "6")
            {
                ddlGrantedDegree.Enabled = true;
                ddlDegreeWeight.Enabled = true;
            }
            if ((ddlGeneralStatus.SelectedValue == "1") || (ddlGeneralStatus.SelectedValue == "2") || (ddlGeneralStatus.SelectedValue == "3") || (ddlGeneralStatus.SelectedValue == "4") || (ddlGeneralStatus.SelectedValue == "5") || (ddlGeneralStatus.SelectedValue == "6") || (ddlGeneralStatus.SelectedValue == "7"))
                ddlRegistraitonStatus.SelectedValue = "8";
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillScholarShipDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This functino will be used to fill the scholar ship Drop Down List
        /// Author: mutawakelm
        /// Date :2/21/2010 10:55:40 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strScholarShipQuery = "SELECT code,status FROM scholarship_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strScholarShipQuery);
            if (reader.HasRows)
            {

                ddlScholarShip.Items.Clear();
                while (reader.Read())
                {
                    ddlScholarShip.Items.Add(reader["status"].ToString());
                    ddlScholarShip.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillTrnasferStatusDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the transfer status drop down list.
        /// Author: mutawakelm
        /// Date :2/21/2010 11:11:05 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strTransferQuery = "SELECT code,status FROM transfer_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strTransferQuery);
            if (reader.HasRows)
            {

                ddlTransferStatus.Items.Clear();
                while (reader.Read())
                {
                    ddlTransferStatus.Items.Add(reader["status"].ToString());
                    ddlTransferStatus.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillDegreeWeightDDL()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the transfer status drop down list.
        /// Author: mutawakelm
        /// Date :2/21/2010 11:11:05 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strDegreeWeightQuery = "SELECT code,name FROM degree_weight_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strDegreeWeightQuery);
            if (reader.HasRows)
            {

                ddlDegreeWeight.Items.Clear();
                while (reader.Read())
                {
                    ddlDegreeWeight.Items.Add(reader["name"].ToString());
                    ddlDegreeWeight.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillMajorSpecialiationDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the major specialization drop down list "lblMajorSpecialization"
        /// Author: mutawakelm
        /// Date :1/27/2010 9:26:10 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strMajorSpecialiationQuery = "SELECT code,specialization FROM major_specialization_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strMajorSpecialiationQuery);
            if (reader.HasRows)
            {
                ddlPreviousField.Items.Clear();
                ddlMinorFieldName.Items.Clear();
                ddlMajorSpecialization.Items.Clear();
                while (reader.Read())
                {
                    ddlMajorSpecialization.Items.Add(reader["specialization"].ToString());
                    ddlMajorSpecialization.Items[counter].Value = reader["code"].ToString();
                    ddlMinorFieldName.Items.Add(reader["specialization"].ToString());
                    ddlMinorFieldName.Items[counter].Value = reader["code"].ToString();
                    ddlPreviousField.Items.Add(reader["specialization"].ToString());
                    ddlPreviousField.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillMajorFieldName(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the major filed name with the value "N/A" in case of selecting the value "000100"
        /// Author: mutawakelm
        /// Date :2/20/2010 3:23:49 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            if (ddlMajorSpecialization.SelectedValue == "000100")
            {
                txtMajorFieldName.Text = "N/A";
                
            }
            ddlMinorFieldName.SelectedValue = ddlMajorSpecialization.SelectedValue;

        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillDegreeDurationDropDownList()
    {
        
        //=====================================================//
	        /// <summary>
         /// Description:This function will be used to fill the degree duration drop down list.
         /// Author: mutawakelm
        /// Date :2/20/2010 3:49:20 PM
         /// Parameter:
         /// input:
         /// output:
         /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            ddlDegreeDuration.Items.Clear();
            for(int i=1;i<100;i++)
                ddlDegreeDuration.Items.Add(i.ToString());


        }catch(Exception exp)
        {
            
        }
    }
    protected void mFillPeriodUnitDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This functino will be used to fill the graduation country drop down list "ddlGraduationCountry"
        /// Author: mutawakelm
        /// Date :1/27/2010 9:21:40 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strGraduationCountryQuery = "SELECT code,duration FROM degree_duration_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strGraduationCountryQuery);
            if (reader.HasRows)
            {

                ddlPeriodUnit.Items.Clear();
                while (reader.Read())
                {
                    ddlPeriodUnit.Items.Add(reader["duration"].ToString());
                    ddlPeriodUnit.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillGenderDropDownList()
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the drop downlist "ddlGender"
        /// Author: mutawakelm
        /// Date :11/17/2009 3:11:56 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//

        try
        {
            string strGenderQuery = "SELECT code,gender FROM gender_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strGenderQuery);
            if (reader.HasRows)
            {
                ddlGender.Items.Clear();
                while (reader.Read())
                {
                    ddlGender.Items.Add(reader["gender"].ToString());
                    ddlGender.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillCollegeDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the drop down list of colleges.
        /// Author: mutawakelm
        /// Date :1/27/2010 8:51:31 AM
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

                
                ddlCurrentCollege.Items.Clear();
                ddlPrevCollege.Items.Clear();
                while (reader.Read())
                {
                   
                    ddlCurrentCollege.Items.Add(reader["college_name"].ToString());
                    ddlCurrentCollege.Items[counter].Value = reader["code"].ToString();
                    ddlPrevCollege.Items.Add(reader["college_name"].ToString());
                    ddlPrevCollege.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();

        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
        }
    }
    protected void mFillNationalityDropDownList()
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the drop downlist "ddlGender"
        /// Author: mutawakelm
        /// Date :11/17/2009 3:11:56 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//

        try
        {
            string strNationalityQuery = "SELECT code,naitonality FROM nationality_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strNationalityQuery);
            if (reader.HasRows)
            {

                ddlNationality.Items.Clear();
                while (reader.Read())
                {
                    ddlNationality.Items.Add(reader["naitonality"].ToString());
                    ddlNationality.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    } 
    protected void mFillLocationDropDownList()
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the drop downlist "ddlGender"
        /// Author: mutawakelm
        /// Date :11/17/2009 3:11:56 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//

        try
        {
            string strLocationQuery = "SELECT code,location_name FROM location_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strLocationQuery);
            if (reader.HasRows)
            {
                ddlOrganizationLocation.Items.Clear();
                ddlLocation.Items.Clear();
                while (reader.Read())
                {
                    ddlLocation.Items.Add(reader["location_name"].ToString());
                    ddlLocation.Items[counter].Value = reader["code"].ToString();
                    ddlOrganizationLocation.Items.Add(reader["location_name"].ToString());
                    ddlOrganizationLocation.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillDegreeDropDownList()
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the drop downlist "ddlGender"
        /// Author: mutawakelm
        /// Date :11/17/2009 3:11:56 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//

        try
        {
            string strDegreeQuery = "SELECT code,qalification_name FROM qualification_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strDegreeQuery);
            if (reader.HasRows)
            {
                ddlGrantedDegree.Items.Clear();
                ddlDegree.Items.Clear();
                while (reader.Read())
                {
                    ddlDegree.Items.Add(reader["qalification_name"].ToString());
                    ddlDegree.Items[counter].Value = reader["code"].ToString();
                    ddlGrantedDegree.Items.Add(reader["qalification_name"].ToString());
                    ddlGrantedDegree.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mFillAccommodationDropDownList()
    {
        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the drop downlist "ddlGender"
        /// Author: mutawakelm
        /// Date :11/17/2009 3:11:56 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//

        try
        {
            string strAccommodationQuery = "SELECT code,accomodation_name FROM accomodation_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strAccommodationQuery);
            if (reader.HasRows)
            {

                ddlAccommodation.Items.Clear();
                while (reader.Read())
                {
                    ddlAccommodation.Items.Add(reader["accomodation_name"].ToString());
                    ddlAccommodation.Items[counter].Value = reader["code"].ToString();
                    counter++;
                }
                reader.Close();
            }
            else reader.Close();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mSaveData(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to save the data of the employee
        /// Author: mutawakelm
        /// Date :12/5/2009 11:11:34 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            //The following call will reformat some fields
            //mReformat();
            //The following code will create an instance of the student class to fill the student data
            GeneralClass.student student = new GeneralClass.student();
            student.setFirstName(txtFirstName.Text.Trim());
            student.setMiddleName(txtMiddleName.Text.Trim());
            student.setLastName(txtLastName.Text.Trim());
            student.setNationlID(txtNationalId.Text.Trim());
            student.setBirthDate(txtBirthDate.Text.Trim());
            student.setGender(ddlGender.SelectedItem.Value.ToString());
            student.setNationality(ddlNationality.SelectedItem.Value.ToString());
            student.setCertificateType(ddlSecondaryType.SelectedItem.Value.ToString());
            student.setSecondaryGraduationYear(ddlGraduationYear.SelectedItem.Text.ToString());
            student.setSecondaryGraduationPlace(ddlLocation.SelectedItem.Value.ToString());
            student.setStudentPercentage(txtSecondaryPercentage.Text.Trim());
            student.setQudratGrade(txtQudratMark.Text.Trim());
            student.setTahseleGrade(txtTahsleiMark.Text.Trim());
            student.setInstitution(txtInstitutionID.Text.Trim());
            student.setCityLocation(ddlOrganizationLocation.SelectedItem.Value.ToString());
            student.setRegistrationYear(ddlRegistraitonYear.SelectedItem.Text.ToString());
            student.setRegistrationSemester(ddlRegistrationSemester.SelectedItem.Value.ToString());
            student.setRegisteredCollege(ddlCollege.SelectedItem.Value.ToString());
            student.setCurrentCollege(ddlCurrentCollege.SelectedItem.Value.ToString());
            student.setPrevCollege(ddlPrevCollege.SelectedItem.Value.ToString());
            student.setStudenttID(txtStudentID.Text.ToString());
            student.setMajorField(ddlMajorSpecialization.SelectedItem.Value.ToString());
            student.setMajorFieldName(txtMajorFieldName.Text.Trim());
            student.setAdvancedField(ddlMinorFieldName.SelectedItem.Value.ToString());
            student.setPrevField(ddlPreviousField.SelectedItem.Value.ToString());
            student.setTargetedDegree(ddlDegree.SelectedItem.Value.ToString());
            student.setStudyDuration(ddlDegreeDuration.SelectedItem.Value.ToString());
            student.setDurationUnit(ddlPeriodUnit.SelectedItem.Value.ToString());
            student.setRequiredUnit(ddlRequiredUnits.SelectedItem.Text.ToString());
            student.setRegistereddUnit(ddlRegisteredUnits.SelectedItem.Text.ToString());
            student.setPassedUnit(ddlPassedUnits.SelectedItem.Text.ToString());
            student.setTotalPassedUnit(ddlTotalPassedUnits.SelectedItem.Text.ToString());
            student.setRemainedUnit(ddlRemainedUnits.SelectedItem.Text.ToString());
            student.setRegisteredSemesters(ddlRegisteredSemesters.SelectedItem.Value.ToString());
            student.setSummerSemester(ddlSummerSemester.SelectedItem.Value.ToString());
            student.setWithdrawnCounter(ddlWithdrawnAttempts.SelectedItem.Text.ToString());
            student.setAcademicYear(ddlAcademicYear.SelectedItem.Value.ToString());
            student.setGPA_Creteria(ddlGpaCreteria.SelectedItem.Value.ToString());
            student.setGPA(txtGpa.Text.Trim());
            student.setWarningCounter(txtWarnings.Text.Trim());
            student.setGeneralStatus(ddlGeneralStatus.SelectedItem.Value.ToString());
            student.setRegistrationStatus(ddlRegistraitonStatus.SelectedItem.Value.ToString());
            student.setStudyCategory(ddlStudyStatus.SelectedItem.Value.ToString());
            student.setScholarShip(ddlScholarShip.SelectedItem.Value.ToString());
            student.setTransferStatus(ddlTransferStatus.SelectedItem.Value.ToString());
            student.setGainedDegree(ddlGrantedDegree.SelectedItem.Value.ToString());
            student.setStudentGradeStatus(ddlDegreeWeight.SelectedItem.Value.ToString());
            student.setAcommodation(ddlAccommodation.SelectedItem.Value.ToString());
            student.setCampus(ddlCampus.SelectedItem.Value.ToString());
            student.setUserName(Session["userName"].ToString());
            string saveResult = student.mSaveStudentData(lblEntryStatus.Text.ToString());//This call will be used to call the data save function
            if (saveResult != null)
            {
                MessageBox.MessageBox.Show(saveResult);
                if (saveResult != "National ID is already exist in the database, please check the National ID field.") 
                mClearFields();
            }
           
            
        }
        catch (Exception exp)
        {
            
        }
    }
    protected void mReformat()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to reformat some fields
        /// Author: mutawakelm
        /// Date :2/20/2010 11:26:15 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            double dblSecondaryPercentage =double.Parse(txtSecondaryPercentage.Text.Trim());
            
            //The following code will be used to reformat the secondary Percentage field
            if (txtSecondaryPercentage.Text != "999998")
            {
                if (dblSecondaryPercentage < 100)
                    txtSecondaryPercentage.Text = "0" + dblSecondaryPercentage.ToString("N2") ;
                
            }
            //The following code will be used to reformat the Qudrat test mark
            if (txtQudratMark.Text != "998")
            {
                if((double.Parse(txtQudratMark.Text.Trim()) < 100)&&(txtQudratMark.Text.Length<3))
                    txtQudratMark.Text = "0"+txtQudratMark.Text.Trim();
                if(double.Parse(txtQudratMark.Text.Trim()) < 10)
                    txtQudratMark.Text = "00" + txtQudratMark.Text.Trim();
            }
            //The following code will be used to reformat the Tahsili mark

            if (txtTahsleiMark.Text != "998")
            {
                if (double.Parse(txtTahsleiMark.Text.Trim()) < 100)
                    txtTahsleiMark.Text = "0" + txtTahsleiMark.Text.Trim();
                if (double.Parse(txtTahsleiMark.Text.Trim()) < 10)
                    txtTahsleiMark.Text = "0" + txtTahsleiMark.Text.Trim();
            }
        }
        catch (Exception exp)
        {
        }
    }
    protected void mBtnClearClicked(object sender, EventArgs e)
    {
        try
        {
            mClearFields();
        }
        catch (Exception exp)
        {
        }
        
    }
    protected void mClearFields()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to clear the fields
        /// Author: mutawakelm
        /// Date :12/5/2009 3:58:21 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtNationalId.Text = "";
            txtBirthDate.Text = "";

            txtStudentID.Text = "";
            txtNationalId.Enabled = true;
            txtSecondaryPercentage.Text = "999998";
            txtQudratMark.Text = "998";
            txtTahsleiMark.Text = "998";
            ddlPreviousField.SelectedValue = "999998";
            ddlRequiredUnits.SelectedValue = "998";
            txtWarnings.Text = "0";
            ddlScholarShip.SelectedValue = "98";
            ddlTransferStatus.SelectedValue = "2";
            ddlGrantedDegree.SelectedValue = "8";
            ddlGrantedDegree.Enabled = false;
            ddlDegreeWeight.SelectedValue = "8";
            ddlDegreeWeight.Enabled = false;
            lblEntryStatus.Text = "new";
            
            
         
            
        }
        catch (Exception exp)
        {
        }
    }
    protected void mSearch(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to search about an employee
        /// Author: mutawakelm
        /// Date :12/5/2009 4:07:44 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            
            mpeSearch.Show();
        }
        catch (Exception exp)
        {
        }
    }
    public void mSearchStudent(object sender, EventArgs e)
    {


        //=====================================================//
        /// <summary>
        /// Description:This function will be used to send the search parameters to the function "mSearchEmployee" which
        /// is located in the cleass 'employee'.
        /// Author: mutawakelm
        /// Date :1/25/2010 10:50:35 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            GeneralClass.student student = new GeneralClass.student();//This instance will be used to send the search parameters
            student.setNationlID(txtSearchNationalID.Text.Trim());
            student.setStudenttID(txtSearchStudentID.Text.Trim());
            student.setFirstName(txtSearchFirstName.Text.Trim());
            student.setMiddleName(txtSearchMiddleName.Text.Trim());
            student.setLastName(txtSearchLastName.Text.Trim());
            DataTable tblSearResult = student.mSearchStudent(Session["userName"].ToString());
            resultsGrid.DataSource = tblSearResult;
            resultsGrid.DataBind();
            mpeSearch.Show();

        }
        catch (Exception exp)
        {
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
            TableCell itemCell = e.Item.Cells[1];
            string strStudentID = itemCell.Text;
            GeneralClass.student StudentFinder = new GeneralClass.student();
            GeneralClass.student foundedStudent = StudentFinder.mFindStudent(strStudentID);
            //The following code will be used to fill the founded employee data
            txtFirstName.Text = foundedStudent.getFirstName();
            txtMiddleName.Text = foundedStudent.getMiddleName();
            txtLastName.Text = foundedStudent.getLastName();
            txtNationalId.Text = foundedStudent.getNationalID();
            txtBirthDate.Text = foundedStudent.getBirthDate();
            ddlGender.SelectedValue = foundedStudent.getGender();
            ddlNationality.SelectedValue = foundedStudent.getNationality();
            ddlSecondaryType.SelectedValue = foundedStudent.getCertificateType();
            ddlGraduationYear.SelectedValue = foundedStudent.getSecondaryGraduationYear();
            txtInstitutionID.Text = foundedStudent.getInstitution();
            ddlLocation.SelectedValue = foundedStudent.getSecondaryGraduationPlace();
            txtSecondaryPercentage.Text = foundedStudent.getStudentPercentage();
            txtQudratMark.Text = foundedStudent.getQudratGrade();
            txtTahsleiMark.Text = foundedStudent.getTahseleGrade();
            txtStudentID.Text = foundedStudent.getStudenttID();
            ddlOrganizationLocation.SelectedValue = foundedStudent.getCityLocation();
            ddlRegistraitonYear.SelectedValue = foundedStudent.getRegistrationYear();
            ddlRegistrationSemester.SelectedValue = foundedStudent.getRegistrationSemester();
            ddlCollege.SelectedValue = foundedStudent.getRegisteredCollege();
            ddlCurrentCollege.SelectedValue = foundedStudent.getCurrentCollege();
            ddlPrevCollege.SelectedValue = foundedStudent.getPrevCollege();
            ddlMajorSpecialization.SelectedValue = foundedStudent.getMajorField();
            txtMajorFieldName.Text = foundedStudent.getMajorFieldName();
            ddlMinorFieldName.SelectedValue = foundedStudent.getAdvancedField();
            ddlPreviousField.SelectedValue = foundedStudent.getPrevField();
            ddlDegree.SelectedValue = foundedStudent.getTargetedDegree();
            ddlDegreeDuration.SelectedValue = foundedStudent.getStudyDuration();
            ddlPeriodUnit.SelectedValue = foundedStudent.getDurationUnit();
            ddlRequiredUnits.SelectedValue = foundedStudent.getRequiredUnit();
            ddlRegisteredUnits.SelectedValue = foundedStudent.getRegistereddUnit();
            ddlPassedUnits.SelectedValue = foundedStudent.getPassedUnit();
            ddlTotalPassedUnits.SelectedValue = foundedStudent.getTotalPassedUnit();
            ddlRemainedUnits.SelectedValue = foundedStudent.getRemainedUnit();
            ddlRegisteredSemesters.SelectedValue = foundedStudent.getRegisteredSemesters();
            ddlSummerSemester.SelectedValue = foundedStudent.getSummerSemester();
            ddlWithdrawnAttempts.SelectedValue = foundedStudent.getWithdrawnCounter();
            ddlGpaCreteria.SelectedValue = foundedStudent.getGPA_Creteria();
            txtGpa.Text = foundedStudent.getGPA();
            txtWarnings.Text = foundedStudent.getWarningCounter();
            ddlGeneralStatus.SelectedValue = foundedStudent.getGeneralStatus();
            ddlRegistraitonStatus.SelectedValue = foundedStudent.getRegistrationStatus();
            ddlStudyStatus.SelectedValue = foundedStudent.getStudyCategory();
            ddlScholarShip.SelectedValue = foundedStudent.getScholarShip();
            ddlTransferStatus.SelectedValue = foundedStudent.getTransferStatus();
            ddlGrantedDegree.SelectedValue = foundedStudent.getGainedDegree();
            ddlDegreeWeight.SelectedValue = foundedStudent.getStudentGradeStatus();
            ddlAccommodation.SelectedValue = foundedStudent.getAcommodation();
            ddlCampus.SelectedValue = foundedStudent.getCampus();
            txtNationalId.Enabled = false;
            lblEntryStatus.Text = "edit";
            
          

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


            TableCell itemCell = e.Item.Cells[1];
            string strStudentNationalID = itemCell.Text;
            objProgram.gDeleteRecord("DELETE FROM STUDENT WHERE NATID='" + strStudentNationalID + "'");
            mClearFields();
            MessageBox.MessageBox.Show("Faculty Record has been removed successfully.");
            
        }
        catch (Exception exp)
        {
        }
    }
    protected void mCancleChanges(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to call "Clearing Fields" Function.
        /// Author: mutawakelm
        /// Date :1/26/2010 2:30:34 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            mClearFields();
        }
        catch (Exception exp)
        {
        }
    }
    protected void mCalculateRemainedUnits(object sender, EventArgs e)
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to calculate the total of remained units by using the following formula:
        /// Total of Rmeained Units=Total Required Units-Total Passed Units
        /// Author: mutawakelm
        /// Date :2/22/2010 3:06:51 PM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            int totalRequiredUnits = int.Parse(ddlRequiredUnits.SelectedItem.Text.ToString());
            int totalPassedUnits = int.Parse(ddlTotalPassedUnits.SelectedItem.Text.ToString());
            int totalRemainedUnits = totalRequiredUnits - totalPassedUnits;
            ddlRemainedUnits.SelectedValue = totalRemainedUnits.ToString();
        }
        catch (Exception exp)
        {
        }
    }

}
