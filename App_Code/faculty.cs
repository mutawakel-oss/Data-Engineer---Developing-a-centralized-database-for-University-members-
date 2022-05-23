using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for faculty
/// </summary>
namespace GeneralClass
{
    public class faculty : member
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
        private string college;
        private string hiringCategory;
        private string hiringStatus;
        private string graduationDate;
        private string graduationOrganization;
        private string graduationCountry;
        private string majorField;
        private string majorFiledName;
        private string advancedField;
        private string currentOrganization;
        private string positionDescription;
        private string campus_id;
        private string user_name;
        System.Data.Odbc.OdbcDataReader reader;
        GeneralClass.Program objProgram = new GeneralClass.Program();

        public faculty()
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
        public void setCollege(string strCollege) { college = strCollege; }
        public void setHiringCategory(string strHiringCategory) { hiringCategory = strHiringCategory; }
        public void setHiringStatus(string strHiringStatus) { hiringStatus = strHiringStatus; }
        public void setGraduationDate(string strGraduationDate) { graduationDate = strGraduationDate; }
        public void setGraduationOrganization(string strGraduationOrganization) { graduationOrganization = strGraduationOrganization; }
        public void setGraduationCountry(string strGraduationCountry) { graduationCountry = strGraduationCountry; }
        public void setMajorField(string strMajorField) { majorField = strMajorField; }
        public void setMajorFieldName(string strMajorFieldName) { majorFiledName = strMajorFieldName; }
        public void setAdvancedField(string strAdvancedField) { advancedField = strAdvancedField; }
        public void setCurrentOrganization(string strCurrentOrganization) { currentOrganization = strCurrentOrganization; }
        public void setPositionDescription(string strPositionDescription) { positionDescription = strPositionDescription; }
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
        public string getCollege() { return college; }
        public string getHiringCategory() { return hiringCategory; }
        public string getHiringStatus() { return hiringStatus; }
        public string getGradutionDate() { return graduationDate; }
        public string getGraduationOrganization() { return graduationOrganization; }
        public string getGraduationCountry() { return graduationCountry; }
        public string getMajorField() { return majorField; }
        public string getMajorFieldName() { return majorFiledName; }
        public string getAdvancedFied() { return advancedField; }
        public string getCurrentOrganization() { return currentOrganization; }
        public string getPositionDescription() { return positionDescription; }
        public string getCampus() { return campus_id; }
        public string getUserName() { return user_name; }
        public string mSaveFacultyData(string lblStatusEntry)
        {
            try
            {
                string strAvailaibilityQuery = "";
                bool available = false;//This variable will be true if the employee record is already exist
                int returnID = 0;
                objProgram.Add("NATID", NationalID, "I");
                objProgram.Add("FNAME", this.getFirstName(), "S");
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
                objProgram.Add("COLGID", college, "S");
                objProgram.Add("MOFAC", hiringCategory, "S");
                objProgram.Add("FACSTUS", hiringStatus, "S");
                objProgram.Add("HQDATE", graduationDate, "S");
                objProgram.Add("HQINST", graduationOrganization, "S");
                objProgram.Add("HQCNTRY", graduationCountry, "S");
                objProgram.Add("ACDIS1", majorField, "S");
                objProgram.Add("ACDISNAME", majorFiledName, "S");
                objProgram.Add("ACDIS2", advancedField, "S");
                objProgram.Add("CRTINST", currentOrganization, "S");
                objProgram.Add("ACEMPFUN", positionDescription, "S");
                objProgram.Add("campus_id", campus_id, "S");
                objProgram.Add("user_name", user_name, "S");
                if (lblStatusEntry == "edit")
                {
                    returnID = objProgram.UpdateRecordStatement("FACULTY", "NATID", "'" + NationalID + "'");
                    if ((returnID != -1) && (returnID != 0))
                    {
                        return "Record has been updated successfully.";

                    }
                    else
                        return "Record has not been updated successfully.";
                }
                else
                {

                    //The following code will check the availability of the employee record
                    strAvailaibilityQuery = "SELECT NATID FROM FACULTY WHERE NATID='" + NationalID + "'";
                    reader = objProgram.gRetrieveRecord(strAvailaibilityQuery);
                    if (reader.HasRows)
                    {
                        available = true;
                        reader.Close();

                    }
                    else
                    {
                        available = false;
                        reader.Close();
                    }
                    if (available == false)
                    {
                        returnID = objProgram.InsertRecordStatement("FACULTY");
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
                            return "National ID is already exist in the database, please check the National ID field.";
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
        public DataTable mSearchFaculty(string userName)
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


                string strSearchQuery = "SELECT * FROM FACULTY WHERE ";//This variable will hold the search query.
                if (this.getFirstName() != "")
                    strSearchQuery += " FNAME='" + this.getFirstName().Trim() + "'";
                if ((this.getMiddleName() != "") && (strSearchQuery.Substring(strSearchQuery.Length - 7, 6).ToString() == " WHERE"))
                    strSearchQuery += " MNAMES='" + this.getMiddleName().Trim() + "'";
                else
                {
                    if (this.getMiddleName() != "")
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
                strSearchQuery += " and user_name='" + userName + "'";
                //The following code will reterive the result of search and return it to the "employee_home" page
                reader = objProgram.gRetrieveRecord(strSearchQuery);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tblSearchResults.Rows.Add(reader["NATID"].ToString(), reader["FNAME"].ToString() + " " + reader["MNAMES"].ToString() + " " + reader["SURNAME"].ToString());
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
        public faculty mFindFaculty(string strNationlID)
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
                faculty foundedFaculty = new faculty();
                string strQuery = "SELECT * FROM fACULTY WHERE  NATID='" + strNationlID + "'";
                reader = objProgram.gRetrieveRecord(strQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    foundedFaculty.setFirstName(reader["FNAME"].ToString());
                    foundedFaculty.setMiddleName(reader["MNAMES"].ToString());
                    foundedFaculty.setLastName(reader["SURNAME"].ToString());
                    foundedFaculty.setNationlID(reader["NATID"].ToString());
                    foundedFaculty.setBirthDate(reader["BIRTHDTE"].ToString());
                    foundedFaculty.setGender(reader["GENDER"].ToString());
                    foundedFaculty.setNationality(reader["NATION"].ToString());
                    foundedFaculty.setMaritalStatus(reader["MRSTATUS"].ToString());
                    foundedFaculty.setRelegion(reader["RELGN"].ToString());
                    foundedFaculty.setEmail(reader["EMAIL"].ToString());
                    foundedFaculty.setInstitution(reader["INSTID"].ToString());
                    foundedFaculty.setCityLocation(reader["CITYLOC"].ToString());
                    foundedFaculty.setBadgeId(reader["EMPID"].ToString());
                    foundedFaculty.setRank(reader["RANK"].ToString());
                    foundedFaculty.setApptDate(reader["APPTDATE"].ToString());
                    foundedFaculty.setDepartmentId(reader["DEPTID"].ToString());
                    foundedFaculty.setStartDate(reader["STRTDATE"].ToString());
                    foundedFaculty.setDegree(reader["HQHELD"].ToString());
                    foundedFaculty.setBasicSalary(reader["BASCSAL"].ToString());
                    foundedFaculty.setMonthlySalary(reader["MNTHSAL"].ToString());
                    foundedFaculty.setAccommodation(reader["ACCOM"].ToString());
                    foundedFaculty.setCollege(reader["COLGID"].ToString());
                    foundedFaculty.setHiringCategory(reader["MOFAC"].ToString());
                    foundedFaculty.setHiringStatus(reader["FACSTUS"].ToString());
                    foundedFaculty.setGraduationDate(reader["HQDATE"].ToString());
                    foundedFaculty.setGraduationOrganization(reader["HQINST"].ToString());
                    foundedFaculty.setGraduationCountry(reader["HQCNTRY"].ToString());
                    foundedFaculty.setMajorField(reader["ACDIS1"].ToString());
                    foundedFaculty.setMajorFieldName(reader["ACDISNAME"].ToString());
                    foundedFaculty.setAdvancedField(reader["ACDIS2"].ToString());
                    foundedFaculty.setCurrentOrganization(reader["CRTINST"].ToString());
                    foundedFaculty.setPositionDescription(reader["ACEMPFUN"].ToString());
                    foundedFaculty.setCampus(reader["campus_id"].ToString());
                    reader.Close();
                }
                else
                    reader.Close();
                return foundedFaculty;
            }
            catch (Exception exp)
            {
                return null;

            }
        }
    }
}
