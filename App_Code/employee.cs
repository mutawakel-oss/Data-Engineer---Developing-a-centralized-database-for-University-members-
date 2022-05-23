using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for employee
/// </summary>
namespace GeneralClass
{
    public class employee : member
    {
        private string NationalID;
        private string BirthDate;
        private string Gender;
        private string Nationality;
        private string MaritalStatus;
        private string Relegion;
        private string Email;
        private string InstitutionID;
        private string CityLocation;
        private string BadgeID;
        private string Rank;
        private string ApptDate;
        private string DepartmentID;
        private string StartDate;
        private string Degree;
        private string BasicSalary;
        private string MonthlySalary;
        private string Accommodation;
        private string campus_id;
        private string user_name;
        System.Data.Odbc.OdbcDataReader reader;
        GeneralClass.Program objProgram = new GeneralClass.Program();

        public employee()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void setNationlID(string strNationlId) { NationalID = strNationlId; }
        public void setBirthDate(string strBirthDate) { BirthDate = strBirthDate; }
        public void setGender(string strGender) { Gender = strGender; }
        public void setNationality(string strNationality) { Nationality = strNationality; }
        public void setMaritalStatus(string strMaritalStatus) { MaritalStatus = strMaritalStatus; }
        public void setRelegion(string strRelegion) { Relegion = strRelegion; }
        public void setEmail(string strEmail) { Email = strEmail; }
        public void setInstitution(string strInstitutionID) { InstitutionID = strInstitutionID; }
        public void setCityLocation(string strCityLocation) { CityLocation = strCityLocation; }
        public void setBadgeId(string strBadgeId) { BadgeID = strBadgeId; }
        public void setRank(string strRank) { Rank = strRank; }
        public void setApptDate(string strApptDate) { ApptDate = strApptDate; }
        public void setDepartmentId(string strDeapartmentId) { DepartmentID = strDeapartmentId; }
        public void setStartDate(string strSatartDate) { StartDate = strSatartDate; }
        public void setDegree(string strDegree) { Degree = strDegree; }
        public void setBasicSalary(string strBasicSalary) { BasicSalary = strBasicSalary; }
        public void setMonthlySalary(string strMonthlySalary) { MonthlySalary = strMonthlySalary; }
        public void setAccommodation(string strAccommodation) { Accommodation = strAccommodation; }
        public void setCampus(string strCampus) { campus_id = strCampus; }
        public void setUserName(string strUserName) { user_name = strUserName; }
        //The following functions are the getters of the employee class
        public string getNationalID() { return NationalID; }
        public string getBirthDate() { return BirthDate; }
        public string getGender() { return Gender; }
        public string getNationality() { return Nationality; }
        public string getMaritalStatus() { return MaritalStatus; }
        public string getRelegion() { return Relegion; }
        public string getEmail() { return Email; }
        public string getInstitutionID() { return InstitutionID; }
        public string getCityLocation() { return CityLocation; }
        public string getBadgeId() { return BadgeID; }
        public string getRank() { return Rank; }
        public string getApptDate() { return ApptDate; }
        public string getDepartmentID() { return DepartmentID; }
        public string getStartDate() { return StartDate; }
        public string getDegree() { return Degree; }
        public string getBasicSalary() { return BasicSalary; }
        public string getMonthlySalary() { return MonthlySalary; }
        public string getAccommodation() { return Accommodation; }
        public string getCampus() { return campus_id; }
        public string getUserName() { return user_name; }
        public string mSaveEmployeeData(string lblStatusEntry)
    {
        try
        {
            string strAvailaibilityQuery = "";
            bool available = false;//This variable will be true if the employee record is already exist
            string EntryResponsible = "";//This variable will contain the name of the entry responsible of the existent ID
            int returnID = 0;
            objProgram.Add("NATID", NationalID, "I");
            objProgram.Add("FNAME",this.getFirstName(), "S");
            objProgram.Add("MNAMES", this.getMiddleName(), "S");
            objProgram.Add("SURNAME", this.getLastName(), "S");
            objProgram.Add("BIRTHDTE", BirthDate, "S");
            objProgram.Add("GENDER", Gender, "S");
            objProgram.Add("NATION", Nationality, "S");
            objProgram.Add("MRSTATUS", MaritalStatus, "S");
            objProgram.Add("RELGN", Relegion, "S");
            objProgram.Add("EMAIL", Email, "S");
            objProgram.Add("INSTID", InstitutionID, "S");
            objProgram.Add("CITYLOC", CityLocation, "S");
            objProgram.Add("EMPID", BadgeID, "S");
            objProgram.Add("RANK", Rank, "S");
            objProgram.Add("APPTDATE", ApptDate, "S");
            objProgram.Add("DEPTID", DepartmentID, "S");
            objProgram.Add("STRTDATE", StartDate, "S");
            objProgram.Add("HQHELD", Degree, "S");
            objProgram.Add("BASCSAL", BasicSalary, "S");
            objProgram.Add("MNTHSAL", MonthlySalary, "S");
            objProgram.Add("ACCOM", Accommodation, "S");
            objProgram.Add("campus_id", campus_id, "S");
            objProgram.Add("user_name", user_name, "S");
            //The following code will check the availability of the employee record
            if (lblStatusEntry == "edit")
            {
                returnID = objProgram.UpdateRecordStatement("STAFF", "NATID", "'" + NationalID + "'");
                if ((returnID != -1) && (returnID != 0))
                {
                    return "Record has been updated successfully.";

                }
                else
                    return "Record has not been updated successfully.";
            }
            else
            {

                strAvailaibilityQuery = "SELECT NATID,user_name FROM STAFF WHERE NATID='" + NationalID + "'";
                reader = objProgram.gRetrieveRecord(strAvailaibilityQuery);
                if (reader.HasRows)
                {
                    available = true;
                    EntryResponsible = reader["user_name"].ToString();
                    reader.Close();

                }
                else
                {
                    available = false;
                    reader.Close();
                }
                if (available == false)
                {
                    returnID = objProgram.InsertRecordStatement("STAFF");
                    if (returnID != 0)
                    {
                        return "Record has been saved successfully.";


                    }
                    else
                        return "Record has not been saved successfully.";

                }
                else
                    if (available == true)
                    {
                            return "National ID is already exist in the database.It was entered by: "+EntryResponsible;
                    }
            }
            return null;
        }
        catch (Exception exp)
        {
            if (reader != null)
                reader.Close();
            return null;
        }
    }
        public DataTable mSearchEmployee(string userName)
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to search about an employee data according to the recieved parameters
            /// Author: mutawakelm
            /// Date :1/25/2010 11:01:43 AM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                DataTable tblSearchResults = new DataTable();
                tblSearchResults.Columns.Add("employeeNationalID");
                tblSearchResults.Columns.Add("employeeName");
                
                
                string strSearchQuery = "SELECT * FROM STAFF WHERE ";//This variable will hold the search query.
                if (this.getFirstName() != "")
                    strSearchQuery += " FNAME='"+this.getFirstName().Trim()+"'";
                if ((this.getMiddleName() != "") && (strSearchQuery.Substring(strSearchQuery.Length - 7, 6).ToString() == " WHERE"))
                    strSearchQuery += " MNAMES='" + this.getMiddleName().Trim() + "'";
                else
                {
                    if(this.getMiddleName() != "")
                    strSearchQuery += " and MNAMES='" + this.getMiddleName().Trim() + "'";
                }
                if ((this.getLastName() != "") && (strSearchQuery.Substring(strSearchQuery.Length - 7, 6).ToString() == " WHERE"))
                    strSearchQuery += " SURNAME='" + this.getLastName().Trim() + "'";
                else
                {
                    if (this.getLastName() != "")
                    strSearchQuery += " and SURNAME='" + this.getLastName().Trim() + "'";
                }
                if ((BadgeID != "") && (strSearchQuery.Substring(strSearchQuery.Length - 7, 6).ToString() == " WHERE"))
                    strSearchQuery += " EMPID='" + BadgeID.Trim() + "'";
                else
                {
                    if (BadgeID != "")
                    strSearchQuery += " and EMPID='" + BadgeID.Trim() + "'";
                }
                if ((NationalID != "") && (strSearchQuery.Substring(strSearchQuery.Length - 7, 6).ToString() == " WHERE"))
                    strSearchQuery += " NATID='" + NationalID.Trim() + "'";
                else
                {
                    if (NationalID != "")
                    strSearchQuery += " and NATID='" + NationalID.Trim() + "'";
                }
                strSearchQuery += " and user_name='"+userName+"'";
                //The following code will reterive the result of search and return it to the "employee_home" page
                reader = objProgram.gRetrieveRecord(strSearchQuery);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tblSearchResults.Rows.Add(reader["NATID"].ToString(),reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString());
                    }
                    reader.Close();
                }
                else
                    reader.Close();
                return tblSearchResults;
            }
            catch (Exception exp)
            {
                if (reader != null)
                    reader.Close();
                return null;
            }
        }
        public employee mFindEmployee(string strNationlID)
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to find an employee by using NationlId
            /// Author: mutawakelm
            /// Date :1/25/2010 2:42:15 PM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                employee foundedEmployee=new employee();
                string strQuery = "SELECT * FROM STAFF WHERE  NATID='"+strNationlID+"'";
                reader = objProgram.gRetrieveRecord(strQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    foundedEmployee.setFirstName(reader["FNAME"].ToString());
                    foundedEmployee.setMiddleName(reader["MNAMES"].ToString());
                    foundedEmployee.setLastName(reader["SURNAME"].ToString());
                    foundedEmployee.setNationlID(reader["NATID"].ToString());
                    foundedEmployee.setBirthDate(reader["BIRTHDTE"].ToString());
                    foundedEmployee.setGender(reader["GENDER"].ToString());
                    foundedEmployee.setNationality(reader["NATION"].ToString());
                    foundedEmployee.setMaritalStatus(reader["MRSTATUS"].ToString());
                    foundedEmployee.setRelegion(reader["RELGN"].ToString());
                    foundedEmployee.setEmail(reader["EMAIL"].ToString());
                    foundedEmployee.setInstitution(reader["INSTID"].ToString());
                    foundedEmployee.setCityLocation(reader["CITYLOC"].ToString());
                    foundedEmployee.setBadgeId(reader["EMPID"].ToString());
                    foundedEmployee.setRank(reader["RANK"].ToString());
                    foundedEmployee.setApptDate(reader["APPTDATE"].ToString());
                    foundedEmployee.setDepartmentId(reader["DEPTID"].ToString());
                    foundedEmployee.setStartDate(reader["STRTDATE"].ToString());
                    foundedEmployee.setDegree(reader["HQHELD"].ToString());
                    foundedEmployee.setBasicSalary(reader["BASCSAL"].ToString());
                    foundedEmployee.setMonthlySalary(reader["MNTHSAL"].ToString());
                    foundedEmployee.setAccommodation(reader["ACCOM"].ToString());
                    foundedEmployee.setCampus(reader["campus_id"].ToString());
                    reader.Close();
                }
                else
                    reader.Close();
                return foundedEmployee;
            }
            catch (Exception exp)
            {
                return null;

            }
        }

    }
}
