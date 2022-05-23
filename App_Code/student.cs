using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for student
/// </summary>
namespace GeneralClass
{
    public class student : member
    {
        private string NationalID;
        private string BirthDate;
        private string Gender;
        private string Nationality;
        private string CertificateType;
        private string SecondaryGraduationYear;
        private string SecondaryGraduationPlace;
        private string StudentPercentage;
        private string QudratGrade;
        private string TahseleGrade;
        private string InstitutionID;
        private string CityLocation;
        private string RegestrationYear;
        private string RegistrationSemester;
        private string RegistrationCollege;
        private string CurrentCollege;
        private string prevCollege;
        private string StudentID;
        private string MajorField;
        private string MajorFiledName;
        private string AdvancedField;
        private string PrevField;
        private string TargetedDegree;
        private string StudyDuration;
        private string DurationUnit;
        private string RequiredUnits;
        private string RegisteredUnits;
        private string PassedUnits;
        private string TotalPassedUnits;
        private string RemainedUnits;
        private string RegisteredSemesters;
        private string SummerSemester;
        private string WithdrawnCounter;
        private string AcademicYear;
        private string GPA;
        private string GPA_Creteria;
        private string WarningCounter;
        private string GeneralStatus;
        private string RegistrationStatus;
        private string StudyCategory;
        private string ScholarShip;
        private string TransferStatus;
        private string GainedDegree;
        private string StudentGradeStatus;
        private string Accommodation;
        private string campus_id;
        private string userName;
        System.Data.Odbc.OdbcDataReader reader;
        GeneralClass.Program objProgram = new GeneralClass.Program();
        
        public student()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void setNationlID(string strNationlId) { NationalID = strNationlId; }
        public void setBirthDate(string strBirthDate) { BirthDate = strBirthDate; }
        public void setGender(string strGender) { Gender = strGender; }
        public void setNationality(string strNationality) { Nationality = strNationality; }
        public void setCertificateType(string strCertificateType) { CertificateType = strCertificateType; }
        public void setSecondaryGraduationYear(string strSecondaryGraduationYear) { SecondaryGraduationYear = strSecondaryGraduationYear; }
        public void setSecondaryGraduationPlace(string strSecondaryGraduationPlace) { SecondaryGraduationPlace = strSecondaryGraduationPlace; }
        public void setStudentPercentage(string strStudentPercentage) { StudentPercentage = strStudentPercentage; }
        public void setQudratGrade(string strQudratGrade) { QudratGrade = strQudratGrade; }
        public void setTahseleGrade(string strTahseleGrade) { TahseleGrade = strTahseleGrade; }
        public void setInstitution(string strInstitutionID) { InstitutionID = strInstitutionID; }
        public void setCityLocation(string strCityLocation) { CityLocation = strCityLocation; }
        public void setRegistrationYear(string strRegistrationYear) { RegestrationYear = strRegistrationYear; }
        public void setRegistrationSemester(string strRegistrationSemester) { RegisteredSemesters = strRegistrationSemester; }
        public void setRegisteredCollege(string strRegistredCollege) { RegistrationCollege = strRegistredCollege; }
        public void setCurrentCollege(string strCurrentCollege) { CurrentCollege = strCurrentCollege; }
        public void setPrevCollege(string strPrevCollege) { prevCollege = strPrevCollege; }
        public void setStudenttID(string strStudentID) { StudentID = strStudentID; }
        public void setMajorField(string strMajorField) { MajorField = strMajorField; }
        public void setMajorFieldName(string strMajorFieldName) { MajorFiledName = strMajorFieldName; }
        public void setAdvancedField(string strAdvancedField) { AdvancedField = strAdvancedField; }
        public void setPrevField(string strPrevField) { PrevField = strPrevField; }
        public void setTargetedDegree(string strTargetedDegree) { TargetedDegree = strTargetedDegree; }
        public void setStudyDuration(string strStudyDuration) { StudyDuration = strStudyDuration; }
        public void setDurationUnit(string strDurationUnit) { DurationUnit =strDurationUnit; }
        public void setRequiredUnit(string strRequiredUnit) { RequiredUnits = strRequiredUnit; }
        public void setRegistereddUnit(string strRegisteredUnit) { RegisteredUnits = strRegisteredUnit; }
        public void setPassedUnit(string strPassedUnit) { PassedUnits = strPassedUnit; }
        public void setTotalPassedUnit(string strTotalPassedUnits) { TotalPassedUnits = strTotalPassedUnits; }
        public void setRemainedUnit(string strRemainedUnit) { RemainedUnits = strRemainedUnit; }
        public void setRegisteredSemesters(string strRegisteredSemesters) { RegistrationSemester = strRegisteredSemesters; }
        public void setSummerSemester(string strSummerSemesters) { SummerSemester = strSummerSemesters; }
        public void setWithdrawnCounter(string strWithdrawnCounter) { WithdrawnCounter = strWithdrawnCounter; }
        public void setAcademicYear(string strAcademicYear) { AcademicYear = strAcademicYear; }
        public void setGPA(string strGPA) { GPA = strGPA; }
        public void setGPA_Creteria(string strGpaCreteria) { GPA_Creteria = strGpaCreteria; }
        public void setWarningCounter(string strWarningCounter) { WarningCounter = strWarningCounter; }
        public void setGeneralStatus(string strGeneralStatus) { GeneralStatus = strGeneralStatus; }
        public void setRegistrationStatus(string strRegistrationStatus) { RegistrationStatus = strRegistrationStatus; }
        public void setStudyCategory(string strStudyCategory) { StudyCategory = strStudyCategory; }
        public void setScholarShip(string strScholarShip) { ScholarShip = strScholarShip; }
        public void setTransferStatus(string strTransferStatus) { TransferStatus = strTransferStatus; }
        public void setGainedDegree(string strGainedDegree) { GainedDegree = strGainedDegree; }
        public void setStudentGradeStatus(string strStudentGradeStatus) { StudentGradeStatus = strStudentGradeStatus; }
        public void setAcommodation(string strAccommodation) { Accommodation = strAccommodation; }
        public void setCampus(string strCampus) { campus_id = strCampus; }
        public void setUserName(string strUserName) { userName = strUserName; }
        //The following functions are the getters of the class
        public string getNationalID() { return NationalID; }
        public string getBirthDate() { return BirthDate; }
        public string getGender() { return Gender; }
        public string getNationality() { return Nationality; }
        public string getCertificateType() {return CertificateType ; }
        public string getSecondaryGraduationYear() {return SecondaryGraduationYear; }
        public string getSecondaryGraduationPlace() {return SecondaryGraduationPlace ; }
        public string getStudentPercentage() { return StudentPercentage ; }
        public string getQudratGrade() {return QudratGrade ; }
        public string getTahseleGrade() {return TahseleGrade ; }
        public string getInstitution() {return InstitutionID ; }
        public string getCityLocation() {return CityLocation ; }
        public string getRegistrationYear() {return RegestrationYear ; }
        public string getRegistrationSemester() {return RegisteredSemesters ; }
        public string getRegisteredCollege() { return RegistrationCollege; }
        public string getCurrentCollege() { return CurrentCollege; }
        public string getPrevCollege() { return prevCollege; }
        public string getStudenttID() { return StudentID; }
        public string getMajorField() { return MajorField; }
        public string getMajorFieldName() { return MajorFiledName; }
        public string getAdvancedField() { return AdvancedField; }
        public string getPrevField() { return PrevField; }
        public string getTargetedDegree() { return TargetedDegree; }
        public string getStudyDuration() { return StudyDuration; }
        public string getDurationUnit() { return DurationUnit; }
        public string getRequiredUnit() { return RequiredUnits; }
        public string getRegistereddUnit() { return RegisteredUnits; }
        public string getPassedUnit() { return PassedUnits; }
        public string getTotalPassedUnit() { return TotalPassedUnits; }
        public string getRemainedUnit() { return RemainedUnits; }
        public string getRegisteredSemesters() { return RegistrationSemester; }
        public string getSummerSemester() { return SummerSemester; }
        public string getWithdrawnCounter() { return WithdrawnCounter; }
        public string getAcademicYear() { return AcademicYear; }
        public string getGPA() { return GPA; }
        public string getGPA_Creteria() { return GPA_Creteria; }
        public string getWarningCounter() { return WarningCounter; }
        public string getGeneralStatus() { return GeneralStatus; }
        public string getRegistrationStatus() { return RegistrationStatus; }
        public string getStudyCategory() { return StudyCategory; }
        public string getScholarShip() { return ScholarShip; }
        public string getTransferStatus() { return TransferStatus; }
        public string getGainedDegree() { return GainedDegree; }
        public string getStudentGradeStatus() { return StudentGradeStatus; }
        public string getAcommodation() { return Accommodation; }
        public string getCampus() { return campus_id; }
        public string getUserName() { return userName; }
        public string mSaveStudentData(string lblStatusEntry)
        {

            try
            {
                string strAvailaibilityQuery = "";
                bool available = false;//This variable will be true if the student record is already exist
                int returnID = 0;
                objProgram.Add("FNAME", this.getFirstName(), "S");
                objProgram.Add("MNAMES", this.getMiddleName(), "S");
                objProgram.Add("SURNAME", this.getLastName(), "S");
                objProgram.Add("NATID", getNationalID(), "S");
                objProgram.Add("BIRTHDTE", getBirthDate(), "S");
                objProgram.Add("GENDER", getGender(), "S");
                objProgram.Add("NATION", getNationality(), "S");
                objProgram.Add("HSTYPE", getCertificateType(), "S");
                objProgram.Add("HSYEAR", getSecondaryGraduationYear(), "S");
                objProgram.Add("HSLOC", getSecondaryGraduationPlace(), "S");
                objProgram.Add("HSPERCENT", getStudentPercentage(), "S");
                objProgram.Add("APLTEST", getQudratGrade(), "S");
                objProgram.Add("ACHVTEST", getTahseleGrade(), "S");
                objProgram.Add("INSTID", getInstitution(), "S");
                objProgram.Add("LOCSTDY", getCityLocation(), "S");
                objProgram.Add("STUDID", getStudenttID(), "S");
                objProgram.Add("COMYEAR", getRegistrationYear(), "S");
                objProgram.Add("COMSEM", getRegistrationSemester(), "S");
                objProgram.Add("ADMCOLG", getRegisteredCollege(), "S");
                objProgram.Add("CURNTCOLG", getCurrentCollege(), "S");
                objProgram.Add("PRVCOLG", getPrevCollege(), "S");
                objProgram.Add("SBJQA1", getMajorField(), "S");
                objProgram.Add("SBJNAME", getMajorFieldName(), "S");
                objProgram.Add("SBJQA2", getAdvancedField(), "S");
                objProgram.Add("PRSBJ", getPrevField(), "S");
                objProgram.Add("QUALAIM", getTargetedDegree(), "S");
                objProgram.Add("STDYLNGTH", getStudyDuration(), "S");
                objProgram.Add("UNITLNGTH", getDurationUnit(), "S");
                objProgram.Add("NCREQ", getRequiredUnit(), "S");
                objProgram.Add("NCREG", getRegistereddUnit(), "S");
                objProgram.Add("NCPASS", getPassedUnit(), "S");
                objProgram.Add("TNCPASS", getTotalPassedUnit(), "S");
                objProgram.Add("NCREM", getRemainedUnit(), "S");
                objProgram.Add("NSREG", getRegisteredSemesters(), "S");
                objProgram.Add("SUMSEM", getSummerSemester(), "S");
                objProgram.Add("NWDRAW", getWithdrawnCounter(), "S");
                objProgram.Add("YEARPRG", getAcademicYear(), "S");
                objProgram.Add("CUMGPA", getGPA(), "S");
                objProgram.Add("GPATYPE", getGPA_Creteria(), "S");
                objProgram.Add("NACWARN", getWarningCounter(), "S");
                objProgram.Add("GSTATUS", getGeneralStatus(), "S");
                objProgram.Add("REGSTATUS", getRegistrationStatus(), "S");
                objProgram.Add("STDYMODE", getStudyCategory(), "S");
                objProgram.Add("SCLRSHIP", getScholarShip(), "S");
                objProgram.Add("TRANS", getTransferStatus(), "S");
                objProgram.Add("QUAL", getGainedDegree(), "S");
                objProgram.Add("CLASS", getStudentGradeStatus(), "S");
                objProgram.Add("ACCOM", getAcommodation(), "S");
                objProgram.Add("campus_id", getCampus(), "S");
                objProgram.Add("user_name", getUserName(), "S");
                //The following code will check the availability of the employee record
                if (lblStatusEntry == "edit")
                {
                    returnID = objProgram.UpdateRecordStatement("STUDENT", "NATID", "'" + NationalID + "'");
                    if ((returnID != -1) && (returnID != 0))
                    {
                        return "Record has been updated successfully.";

                    }
                    else
                        return "Record has not been updated successfully.";
                }
                else
                {
                    strAvailaibilityQuery = "SELECT NATID FROM STUDENT WHERE NATID='" + NationalID + "'";
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
                        returnID = objProgram.InsertRecordStatement("STUDENT");
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
                return null;
            }
        }
        public DataTable mSearchStudent(string userName)
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
                tblSearchResults.Columns.Add("StudentID");
                tblSearchResults.Columns.Add("studentName");


                string strSearchQuery = "SELECT * FROM STUDENT WHERE ";//This variable will hold the search query.
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
                if ((StudentID != "") && (strSearchQuery.Substring(strSearchQuery.Length - 7, 6).ToString() == " WHERE"))
                    strSearchQuery += " STUDID='" + StudentID.Trim() + "'";
                else
                {
                    if (StudentID != "")
                        strSearchQuery += " and STUDID='" + StudentID.Trim() + "'";
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
        public student mFindStudent(string strNationlID)
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
                student foundedStudent = new student();
                string strQuery = "SELECT * FROM STUDENT WHERE  NATID='" + strNationlID + "'";
                reader = objProgram.gRetrieveRecord(strQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    foundedStudent.setFirstName(reader["FNAME"].ToString());
                    foundedStudent.setMiddleName(reader["MNAMES"].ToString());
                    foundedStudent.setLastName(reader["SURNAME"].ToString());
                    foundedStudent.setNationlID(reader["NATID"].ToString());
                    foundedStudent.setBirthDate(reader["BIRTHDTE"].ToString());
                    foundedStudent.setGender(reader["GENDER"].ToString());
                    foundedStudent.setNationality(reader["NATION"].ToString());
                    foundedStudent.setCertificateType(reader["HSTYPE"].ToString());
                    foundedStudent.setSecondaryGraduationYear(reader["HSYEAR"].ToString());
                    foundedStudent.setSecondaryGraduationPlace(reader["HSLOC"].ToString());
                    foundedStudent.setStudentPercentage(reader["HSPERCENT"].ToString());
                    foundedStudent.setQudratGrade(reader["APLTEST"].ToString());
                    foundedStudent.setTahseleGrade(reader["ACHVTEST"].ToString());
                    foundedStudent.setInstitution(reader["INSTID"].ToString());
                    foundedStudent.setCityLocation(reader["LOCSTDY"].ToString());
                    foundedStudent.setStudenttID(reader["STUDID"].ToString());
                    foundedStudent.setRegistrationYear(reader["COMYEAR"].ToString());
                    foundedStudent.setRegistrationSemester(reader["COMSEM"].ToString());
                    foundedStudent.setRegisteredCollege(reader["ADMCOLG"].ToString());
                    foundedStudent.setCurrentCollege(reader["CURNTCOLG"].ToString());
                    foundedStudent.setPrevCollege(reader["PRVCOLG"].ToString());
                    foundedStudent.setMajorField(reader["SBJQA1"].ToString());
                    foundedStudent.setMajorFieldName(reader["SBJNAME"].ToString());
                    foundedStudent.setAdvancedField(reader["SBJQA2"].ToString());
                    foundedStudent.setPrevField(reader["PRSBJ"].ToString());
                    foundedStudent.setTargetedDegree(reader["QUALAIM"].ToString());
                    foundedStudent.setStudyDuration(reader["STDYLNGTH"].ToString());
                    foundedStudent.setDurationUnit(reader["UNITLNGTH"].ToString());
                    foundedStudent.setRequiredUnit(reader["NCREQ"].ToString());
                    foundedStudent.setRegistereddUnit(reader["NCREG"].ToString());
                    foundedStudent.setPassedUnit(reader["NCPASS"].ToString());
                    foundedStudent.setTotalPassedUnit(reader["TNCPASS"].ToString());
                    foundedStudent.setRemainedUnit(reader["NCREM"].ToString());
                    foundedStudent.setRegisteredSemesters(reader["NSREG"].ToString());
                    foundedStudent.setSummerSemester(reader["SUMSEM"].ToString());
                    foundedStudent.setWithdrawnCounter(reader["NWDRAW"].ToString());
                    foundedStudent.setAcademicYear(reader["YEARPRG"].ToString());
                    foundedStudent.setGPA(reader["CUMGPA"].ToString());
                    foundedStudent.setGPA_Creteria(reader["GPATYPE"].ToString());
                    foundedStudent.setWarningCounter(reader["NACWARN"].ToString());
                    foundedStudent.setGeneralStatus(reader["GSTATUS"].ToString());
                    foundedStudent.setRegistrationStatus(reader["REGSTATUS"].ToString());
                    foundedStudent.setStudyCategory(reader["STDYMODE"].ToString());
                    foundedStudent.setScholarShip(reader["SCLRSHIP"].ToString());
                    foundedStudent.setTransferStatus(reader["TRANS"].ToString());
                    foundedStudent.setGainedDegree(reader["QUAL"].ToString());
                    foundedStudent.setStudentGradeStatus(reader["CLASS"].ToString());
                    foundedStudent.setAcommodation(reader["ACCOM"].ToString());
                    foundedStudent.setCampus(reader["campus_id"].ToString());
                    reader.Close();
                }
                else
                    reader.Close();
                return foundedStudent;
            }
            catch (Exception exp)
            {
                return null;

            }
        }
    }
}
