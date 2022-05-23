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
    DataTable tblFacultyEntryPreviliges = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int campusCounter = 0;
            int collegeCounter = 0;
            int departmentCounter=0;
            if ((Session["facultyEntry"] != null) && (Session["userName"] != null))
            {
                if (Session["facultyEntry"].ToString() == "true")
                {
                    if (!IsPostBack)
                    {
                        GeneralClass.user user = new GeneralClass.user();
                        tblFacultyEntryPreviliges = user.mCheckFacultyEntryPrivilges(Session["userName"].ToString());
                        if (tblFacultyEntryPreviliges.Rows.Count > 0)
                        {
                            campusCounter = 0;
                            collegeCounter = 0;
                            departmentCounter = 0;
                            for (int i = 0; i < tblFacultyEntryPreviliges.Rows.Count; i++)
                            {
                                if (tblFacultyEntryPreviliges.Rows[i][0].ToString() == "campus")
                                {
                                    ddlCampus.Items.Add(tblFacultyEntryPreviliges.Rows[i][2].ToString());
                                    ddlCampus.Items[campusCounter].Value = tblFacultyEntryPreviliges.Rows[i][1].ToString();
                                    campusCounter++;

                                }
                                else
                                    if (tblFacultyEntryPreviliges.Rows[i][0].ToString() == "college")
                                    {

                                        ddlCollege.Items.Add(tblFacultyEntryPreviliges.Rows[i][2].ToString());
                                        ddlCollege.Items[collegeCounter].Value = tblFacultyEntryPreviliges.Rows[i][1].ToString();
                                        collegeCounter++;
                                    }
                                    else
                                        if (tblFacultyEntryPreviliges.Rows[i][0].ToString() == "department")
                                        {

                                            ddlDepartment.Items.Add(tblFacultyEntryPreviliges.Rows[i][2].ToString());
                                            ddlDepartment.Items[departmentCounter].Value = tblFacultyEntryPreviliges.Rows[i][1].ToString();
                                            departmentCounter++;
                                        }

                            }
                            mFillGenderDropDownList();
                            mFillNationalityDropDownList();
                            mFillMaritalStatusDropDownList();
                            mFillReligionDownList();
                            mFillLocationDropDownList();
                            mFillPositionDropDownList();
                            mFillDegreeDropDownList();
                            mFillAccommodationDropDownList();
                            mFillHiringCategoryDropDownList();
                            mFillHiringStatusDropDownList();
                            mFillGraduationCountryDropDownList();
                            mFillMajorSpecialiationDropDownList();
                            mFillCurrentOrganizationDropDownList();
                            mFillPositionDescriptionDropDownList();


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
    protected void mFillPositionDescriptionDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill "ddlPositionDescription"
        /// Author: mutawakelm
        /// Date :1/27/2010 9:57:27 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strPositionDescriptionQuery = "SELECT code,position_description FROM position_description_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strPositionDescriptionQuery);
            if (reader.HasRows)
            {

                ddlPositionDescription.Items.Clear();
                while (reader.Read())
                {
                    ddlPositionDescription.Items.Add(reader["position_description"].ToString());
                    ddlPositionDescription.Items[counter].Value = reader["code"].ToString();
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
    protected void mFillCurrentOrganizationDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill "ddlCurrentOrganization"
        /// Author: mutawakelm
        /// Date :1/27/2010 9:44:31 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strCurrentOrganizationQuery = "SELECT code,institution FROM institution_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strCurrentOrganizationQuery);
            if (reader.HasRows)
            {

                ddlCurrentOrganization.Items.Clear();
                while (reader.Read())
                {
                    ddlCurrentOrganization.Items.Add(reader["institution"].ToString());
                    ddlCurrentOrganization.Items[counter].Value = reader["code"].ToString();
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
                ddlMajorSpecialization.Items.Clear();
                while (reader.Read())
                {
                    ddlMajorSpecialization.Items.Add(reader["specialization"].ToString());
                    ddlMajorSpecialization.Items[counter].Value = reader["code"].ToString();
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
    protected void mFillGraduationCountryDropDownList()
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
            string strGraduationCountryQuery = "SELECT code,naitonality FROM nationality_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strGraduationCountryQuery);
            if (reader.HasRows)
            {

                ddlGraduationCountry.Items.Clear();
                while (reader.Read())
                {
                    ddlGraduationCountry.Items.Add(reader["naitonality"].ToString());
                    ddlGraduationCountry.Items[counter].Value = reader["code"].ToString();
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
    protected void mFillHiringStatusDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This functino will be used to fill the "ddlHiringStatus" drop down list.
        /// Author: mutawakelm
        /// Date :1/27/2010 9:08:50 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strHiringStatus = "SELECT code,position_status FROM position_status_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strHiringStatus);
            if (reader.HasRows)
            {

                ddlHiringStatus.Items.Clear();
                while (reader.Read())
                {

                    ddlHiringStatus.Items.Add(reader["position_status"].ToString());
                    ddlHiringStatus.Items[counter].Value = reader["code"].ToString();
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
    protected void mFillHiringCategoryDropDownList()
    {

        //=====================================================//
        /// <summary>
        /// Description:This function will be used to fill the "ddlHiringCategory" drop down list.
        /// Author: mutawakelm
        /// Date :1/27/2010 9:02:47 AM
        /// Parameter:
        /// input:
        /// output:
        /// Example:
        /// <summary>
        //=====================================================//
        try
        {
            string strHiringCategoryQuery = "SELECT code,position_type FROM position_category_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strHiringCategoryQuery);
            if (reader.HasRows)
            {

                ddlHiringCategory.Items.Clear();
                while (reader.Read())
                {
                    ddlHiringCategory.Items.Add(reader["position_type"].ToString());
                    ddlHiringCategory.Items[counter].Value = reader["code"].ToString();
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
    protected void mFillMaritalStatusDropDownList()
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
            string strMaritalQuery = "SELECT code,status_name FROM married_status_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strMaritalQuery);
            if (reader.HasRows)
            {

                ddlMaritalStatus.Items.Clear();
                while (reader.Read())
                {
                    ddlMaritalStatus.Items.Add(reader["status_name"].ToString());
                    ddlMaritalStatus.Items[counter].Value = reader["code"].ToString();
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
    protected void mFillReligionDownList()
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
            string strReligionQuery = "SELECT code,religion_name FROM religion_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strReligionQuery);
            if (reader.HasRows)
            {

                ddlReligion.Items.Clear();
                while (reader.Read())
                {
                    ddlReligion.Items.Add(reader["religion_name"].ToString());
                    ddlReligion.Items[counter].Value = reader["code"].ToString();
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

                ddlLocation.Items.Clear();
                while (reader.Read())
                {
                    ddlLocation.Items.Add(reader["location_name"].ToString());
                    ddlLocation.Items[counter].Value = reader["code"].ToString();
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
    protected void mFillPositionDropDownList()
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
            string strPositionQuery = "SELECT code,academic_position FROM academic_position_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strPositionQuery);
            if (reader.HasRows)
            {

                ddlPosition.Items.Clear();
                while (reader.Read())
                {
                    ddlPosition.Items.Add(reader["academic_position"].ToString());
                    ddlPosition.Items[counter].Value = reader["code"].ToString();
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

                ddlDegree.Items.Clear();
                while (reader.Read())
                {
                    ddlDegree.Items.Add(reader["qalification_name"].ToString());
                    ddlDegree.Items[counter].Value = reader["code"].ToString();
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
            GeneralClass.faculty faculty = new GeneralClass.faculty();
            faculty.setFirstName(txtFirstName.Text.Trim());
            faculty.setMiddleName(txtMiddleName.Text.Trim());
            faculty.setLastName(txtLastName.Text.Trim());
            faculty.setNationlID(txtNationalId.Text.Trim());
            faculty.setBirthDate(txtBirthDate.Text.Trim());
            faculty.setGender(ddlGender.SelectedItem.Value.ToString());
            faculty.setNationality(ddlNationality.SelectedItem.Value.ToString());
            faculty.setMaritalStatus(ddlMaritalStatus.SelectedItem.Value.ToString());
            faculty.setRelegion(ddlReligion.SelectedItem.Value.ToString());
            faculty.setEmail(txtEmail.Text.Trim());
            faculty.setInstitution(txtInstitutionID.Text.Trim());
            faculty.setCityLocation(ddlLocation.SelectedItem.Value.ToString());
            faculty.setBadgeId(txtBadgeNo.Text.Trim());
            faculty.setRank(ddlPosition.SelectedItem.Value.ToString());
            faculty.setApptDate(txtHiringDate.Text.Trim());
            faculty.setDepartmentId(ddlDepartment.SelectedItem.Value.ToString());
            faculty.setStartDate(txtStartHiringDate.Text.Trim());
            faculty.setDegree(ddlDegree.SelectedItem.Value.ToString());
            faculty.setBasicSalary(txtBasicSalary.Text.Trim());
            faculty.setMonthlySalary(txtTotalSalary.Text.Trim());
            faculty.setAccommodation(ddlAccommodation.SelectedItem.Value.ToString());
            faculty.setCollege(ddlCollege.SelectedItem.Value.ToString());
            faculty.setHiringCategory(ddlHiringCategory.SelectedItem.Value.ToString());
            faculty.setHiringStatus(ddlHiringStatus.SelectedItem.Value.ToString());
            faculty.setGraduationDate(txtGraduationDate.Text.Trim());
            faculty.setGraduationOrganization(txtGraduationOrg.Text.Trim());
            faculty.setGraduationCountry(ddlGraduationCountry.SelectedItem.Value.ToString());
            faculty.setMajorField(ddlMajorSpecialization.SelectedItem.Value.ToString());
            faculty.setMajorFieldName(txtMajorSpecializationName.Text.Trim());
            faculty.setAdvancedField(txtAdvancedField.Text.Trim());
            faculty.setCurrentOrganization(ddlCurrentOrganization.SelectedItem.Value.ToString());
            faculty.setPositionDescription(ddlPositionDescription.SelectedItem.Value.ToString());
            faculty.setCampus(ddlCampus.SelectedItem.Value.ToString());
            faculty.setUserName(Session["userName"].ToString());
            string saveResult = faculty.mSaveFacultyData(lblEntryStatus.Text);//This call will be used to call the data save function
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
            txtEmail.Text = "";
            txtBadgeNo.Text = "";
            txtHiringDate.Text = "";
            txtStartHiringDate.Text = "";
            txtBasicSalary.Text = "";
            txtTotalSalary.Text = "";
            txtGraduationDate.Text = "";
            txtGraduationOrg.Text = "";
            txtMajorSpecializationName.Text = "";
            txtAdvancedField.Text = "";
            txtNationalId.Enabled = true;
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
    public void mSearchFaculty(object sender, EventArgs e)
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
            GeneralClass.faculty faculty = new GeneralClass.faculty();//This instance will be used to send the search parameters
            faculty.setNationlID(txtSearchNationalID.Text.Trim());
            faculty.setBadgeId(txtSearchBadgeNo.Text.Trim());
            faculty.setFirstName(txtSearchFirstName.Text.Trim());
            faculty.setMiddleName(txtSearchMiddleName.Text.Trim());
            faculty.setLastName(txtSearchLastName.Text.Trim());
            DataTable tblSearResult = faculty.mSearchFaculty(Session["userName"].ToString());
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
            string strFaculyID = itemCell.Text;
            GeneralClass.faculty FacultyFinder = new GeneralClass.faculty();
            GeneralClass.faculty foundedFaculty = FacultyFinder.mFindFaculty(strFaculyID);
            //The following code will be used to fill the founded employee data
            txtFirstName.Text = foundedFaculty.getFirstName();
            txtMiddleName.Text = foundedFaculty.getMiddleName();
            txtLastName.Text = foundedFaculty.getLastName();
            txtNationalId.Text = foundedFaculty.getNationalID();
            txtBirthDate.Text = foundedFaculty.getBirthDate();
            ddlGender.SelectedValue = foundedFaculty.getGender();
            ddlNationality.SelectedValue = foundedFaculty.getNationality();
            ddlMaritalStatus.SelectedValue = foundedFaculty.getMaritalStatus();
            ddlReligion.SelectedValue = foundedFaculty.getRelegion();
            txtEmail.Text = foundedFaculty.getEmail();
            txtInstitutionID.Text = foundedFaculty.getInstitutionID();
            ddlLocation.SelectedValue = foundedFaculty.getCityLocation();
            txtBadgeNo.Text = foundedFaculty.getBadgeId();
            ddlPosition.SelectedValue = foundedFaculty.getRank();
            txtHiringDate.Text = foundedFaculty.getApptDate();
            ddlDepartment.SelectedValue = foundedFaculty.getDepartmentID();
            txtStartHiringDate.Text = foundedFaculty.getStartDate();
            ddlDegree.SelectedValue = foundedFaculty.getDegree();
            txtBasicSalary.Text = foundedFaculty.getBasicSalary();
            txtTotalSalary.Text = foundedFaculty.getMonthlySalary();
            ddlAccommodation.SelectedValue = foundedFaculty.getAccommodation();
            ddlCollege.SelectedValue = foundedFaculty.getCollege();
            ddlHiringCategory.SelectedValue = foundedFaculty.getHiringCategory();
            ddlHiringStatus.SelectedValue = foundedFaculty.getHiringStatus();
            txtGraduationDate.Text = foundedFaculty.getGradutionDate();
            txtGraduationOrg.Text = foundedFaculty.getGraduationOrganization();
            ddlGraduationCountry.SelectedValue = foundedFaculty.getGraduationCountry();
            ddlMajorSpecialization.SelectedValue = foundedFaculty.getMajorField();
            txtMajorSpecializationName.Text = foundedFaculty.getMajorFieldName();
            txtAdvancedField.Text = foundedFaculty.getAdvancedFied();
            ddlCurrentOrganization.SelectedValue = foundedFaculty.getCurrentOrganization();
            ddlPositionDescription.SelectedValue = foundedFaculty.getPositionDescription();
            ddlCampus.SelectedValue = foundedFaculty.getCampus();
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
            string strEmployeeID = itemCell.Text;
            objProgram.gDeleteRecord("DELETE FROM FACULTY WHERE NATID='" + strEmployeeID + "'");
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

}
