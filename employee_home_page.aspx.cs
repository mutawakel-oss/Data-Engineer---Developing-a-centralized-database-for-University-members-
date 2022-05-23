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
    DataTable tblEmployeePrivilges = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int campusCounter = 0;
            int departmentCounter=0;
            if ((Session["employeeEntry"] != null) && (Session["userName"] != null))
            {
                if (Session["employeeEntry"].ToString() == "true")
                {
                    if (!IsPostBack)
                    {
                        GeneralClass.user user = new GeneralClass.user();
                        tblEmployeePrivilges = user.mCheckEmployeeEntryPrivilges(Session["userName"].ToString());
                        if (tblEmployeePrivilges.Rows.Count > 0)
                        {
                            campusCounter = 0;
                            departmentCounter = 0;
                            for (int i = 0; i < tblEmployeePrivilges.Rows.Count; i++)
                            {
                                if (tblEmployeePrivilges.Rows[i][0].ToString() == "campus")
                                {
                                    ddlCampus.Items.Add(tblEmployeePrivilges.Rows[i][2].ToString());
                                    ddlCampus.Items[campusCounter].Value = tblEmployeePrivilges.Rows[i][1].ToString();
                                    campusCounter++;

                                }
                                else
                                    if (tblEmployeePrivilges.Rows[i][0].ToString() == "department")
                                    {

                                        ddlDepartment.Items.Add(tblEmployeePrivilges.Rows[i][2].ToString());
                                        ddlDepartment.Items[departmentCounter].Value = tblEmployeePrivilges.Rows[i][1].ToString();
                                        departmentCounter++;
                                    }

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

                    }
                }
            }
            else
                Response.Redirect("~/error.aspx?Error= Session Expired Please Login again ");
            
        }
        catch (Exception exp)
        {
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
            string strPositionQuery = "SELECT code,position_name FROM position_table";
            int counter = 0;
            reader = objProgram.gRetrieveRecord(strPositionQuery);
            if (reader.HasRows)
            {

                ddlPosition.Items.Clear();
                while (reader.Read())
                {
                    ddlPosition.Items.Add(reader["position_name"].ToString());
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
            GeneralClass.employee employee = new GeneralClass.employee();
            employee.setFirstName(txtFirstName.Text.Trim());
            employee.setMiddleName(txtMiddleName.Text.Trim());
            employee.setLastName(txtLastName.Text.Trim());
            employee.setNationlID(txtNationalId.Text.Trim());
            employee.setBirthDate(txtBirthDate.Text.Trim());
            employee.setGender(ddlGender.SelectedItem.Value.ToString());
            employee.setNationality(ddlNationality.SelectedItem.Value.ToString());
            employee.setMaritalStatus(ddlMaritalStatus.SelectedItem.Value.ToString());
            employee.setRelegion(ddlReligion.SelectedItem.Value.ToString());
            employee.setEmail(txtEmail.Text.Trim());
            employee.setInstitution(txtInstitutionID.Text.Trim());
            employee.setCityLocation(ddlLocation.SelectedItem.Value.ToString());
            employee.setBadgeId(txtBadgeNo.Text.Trim());
            employee.setRank(ddlPosition.SelectedItem.Value.ToString());
            employee.setApptDate(txtHiringDate.Text.Trim());
            employee.setDepartmentId(ddlDepartment.SelectedItem.Value.ToString());
            employee.setStartDate(txtStartHiringDate.Text.Trim());
            employee.setDegree(ddlDegree.SelectedItem.Value.ToString());
            employee.setBasicSalary(txtBasicSalary.Text.Trim());
            employee.setMonthlySalary( txtTotalSalary.Text.Trim());
            employee.setAccommodation(ddlAccommodation.SelectedItem.Value.ToString());
            employee.setCampus(ddlCampus.SelectedItem.Value.ToString());
            employee.setUserName(Session["userName"].ToString());
            string saveResult = employee.mSaveEmployeeData(lblEntryStatus.Text.ToString());//This call will be used to call the data save function
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
            lblEntryStatus.Text = "new";
            txtNationalId.Enabled = true;

            
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
    public void mSearchEmployee(object sender, EventArgs e)
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
            GeneralClass.employee employee = new GeneralClass.employee();//This instance will be used to send the search parameters
            employee.setNationlID(txtSearchNationalID.Text.Trim());
            employee.setBadgeId(txtSearchBadgeNo.Text.Trim());
            employee.setFirstName(txtSearchFirstName.Text.Trim());
            employee.setMiddleName(txtSearchMiddleName.Text.Trim());
            employee.setLastName(txtSearchLastName.Text.Trim());
            DataTable tblSearResult = employee.mSearchEmployee(Session["userName"].ToString());
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
            string strEmployeeID = itemCell.Text;
            GeneralClass.employee employeeFinder = new GeneralClass.employee();
            GeneralClass.employee foundedEmployee= employeeFinder.mFindEmployee(strEmployeeID);
            //The following code will be used to fill the founded employee data
            txtFirstName.Text = foundedEmployee.getFirstName();
            txtMiddleName.Text = foundedEmployee.getMiddleName();
            txtLastName.Text = foundedEmployee.getLastName();
            txtNationalId.Text = foundedEmployee.getNationalID();
            txtBirthDate.Text = foundedEmployee.getBirthDate();
            ddlGender.SelectedValue = foundedEmployee.getGender();
            ddlNationality.SelectedValue = foundedEmployee.getNationality();
            ddlMaritalStatus.SelectedValue = foundedEmployee.getMaritalStatus();
            ddlReligion.SelectedValue = foundedEmployee.getRelegion();
            txtEmail.Text = foundedEmployee.getEmail();
            txtInstitutionID.Text = foundedEmployee.getInstitutionID();
            ddlLocation.SelectedValue = foundedEmployee.getCityLocation();
            txtBadgeNo.Text = foundedEmployee.getBadgeId();
            ddlPosition.SelectedValue = foundedEmployee.getRank();
            txtHiringDate.Text = foundedEmployee.getApptDate();
            ddlDepartment.SelectedValue = foundedEmployee.getDepartmentID();
            txtStartHiringDate.Text = foundedEmployee.getStartDate();
            ddlDegree.SelectedValue = foundedEmployee.getDegree();
            txtBasicSalary.Text = foundedEmployee.getBasicSalary();
            txtTotalSalary.Text = foundedEmployee.getMonthlySalary();
            ddlAccommodation.SelectedValue = foundedEmployee.getAccommodation();
            ddlCampus.SelectedValue = foundedEmployee.getCampus();
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
            objProgram.gDeleteRecord("DELETE FROM STAFF WHERE NATID='" + strEmployeeID + "'");
            mClearFields();
            MessageBox.MessageBox.Show("Employee Record has been removed successfully.");
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
