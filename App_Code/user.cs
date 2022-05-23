using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for member
/// </summary>
/// 

namespace GeneralClass
{
    public class user : member
    {
        private string SystemuserName;
        System.Data.Odbc.OdbcDataReader reader;
        GeneralClass.Program objProgram = new GeneralClass.Program();
        
        public user()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void setUserName(string userName)
        {
            SystemuserName = userName;
        }    
        public string getUserName()
        {
            return this.SystemuserName;
        }
        public DataTable mFindSystemUsers()
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to retrieve the system users then assign them to a data table
            /// Author: mutawakelm
            /// Date :2/27/2010 12:09:47 PM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                string strUsersQuery = "SELECT * FROM system_user_table ";//This variable will contain the query of system users
                DataTable tblSystemUsers = new DataTable();
                tblSystemUsers.Columns.Add("userFullName");
                tblSystemUsers.Columns.Add("userName");
                reader= objProgram.gRetrieveRecord(strUsersQuery);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tblSystemUsers.Rows.Add(reader["full_name"].ToString(), reader["user_name"].ToString());
                    }
                    reader.Close();
                }
                else
                    reader.Close();
                return tblSystemUsers;

            }
            catch (Exception exp)
            {
                if (reader != null)
                    reader.Close();
                return null;
            }
        }
        public DataTable mRetrieveUserPreviliges(string strUserName)
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to retrieve the previliges of the user logon user
            /// Author: mutawakelm
            /// Date :3/3/2010 2:55:51 PM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                DataTable tblUserPreviliges = new DataTable();
                tblUserPreviliges.Columns.Add("status");
                string strUsersQuery = "SELECT * FROM system_user_table WHERE user_name='"+strUserName+"' ";//This variable will contain the query of system users
                reader= objProgram.gRetrieveRecord(strUsersQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    //The following code will check the student entry previliges
                    if (reader["student_entry"].ToString() != "")
                        tblUserPreviliges.Rows.Add("true");
                    else
                        tblUserPreviliges.Rows.Add("false");
                    //The following code will check the faculty entry previliges
                    if (reader["faculty_entry"].ToString()!="")
                        tblUserPreviliges.Rows.Add("true");
                    else
                        tblUserPreviliges.Rows.Add("false");
                    //The following code will check the employee entry previliges

                    if (reader["employee_entry"].ToString() != "")
                        tblUserPreviliges.Rows.Add("true");
                    else
                        tblUserPreviliges.Rows.Add("false");
                    //The following code will check the report review previliges

                    if (reader["report_viewer"].ToString() != "")
                        tblUserPreviliges.Rows.Add("true");
                    else
                        tblUserPreviliges.Rows.Add("false");
                    //The following code will check the administration previliges
                    if (reader["administrator"].ToString() != "")
                        tblUserPreviliges.Rows.Add("true");
                    else
                        tblUserPreviliges.Rows.Add("false");
                    

                    reader.Close();

                }
                return tblUserPreviliges;

            }catch(Exception exp)
            {
                if (reader != null)
                    reader.Close();
                return null;
            }
        }
        public DataTable mCheckStudentEntryPrivilges(string strUserName)
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to check the priviliges 
            /// Author: mutawakelm
            /// Date :3/6/2010 8:36:26 AM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                string strStudentEntryPrivilges = "";
                string strCampuses = "";
                string strColleges = "";
                DataTable tblStudentEntryPreviliges=new DataTable();
                tblStudentEntryPreviliges.Columns.Add("title");
                tblStudentEntryPreviliges.Columns.Add("id");
                tblStudentEntryPreviliges.Columns.Add("name");
                string strQuery = "SELECT student_entry FROM system_user_table WHERE user_name='" + strUserName + "'";
                reader = objProgram.gRetrieveRecord(strQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    strStudentEntryPrivilges = reader["student_entry"].ToString();
                    reader.Close();
                }
                else
                    reader.Close();
                //The following code will reformat the student entry privilges
                if (strStudentEntryPrivilges != "")
                {
                    string[] strPrivilegesSplitter = strStudentEntryPrivilges.Split('|');
                    strCampuses = strPrivilegesSplitter[0];
                    string[] campusesSplitter = strCampuses.Split(',');
                    for (int i = 0; i < campusesSplitter.Length; i++)
                    {
                        tblStudentEntryPreviliges.Rows.Add("campus",campusesSplitter[i],mRetrieveCampus(campusesSplitter[i]));
                    }
                    strColleges = strPrivilegesSplitter[1];
                    string[] collegeSplitter = strColleges.Split(',');
                    for (int i = 0; i < collegeSplitter.Length; i++)
                    {
                        tblStudentEntryPreviliges.Rows.Add("college",collegeSplitter[i],mRetrieveCollege(collegeSplitter[i]));
                    }
                }

                return tblStudentEntryPreviliges;
            }
            catch (Exception exp)
            {
                if (reader != null)
                    reader.Close();
                return null;
            }
        }
        public DataTable mCheckFacultyEntryPrivilges(string strUserName)
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to check the priviliges 
            /// Author: mutawakelm
            /// Date :3/6/2010 8:36:26 AM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                string strFacultyEntryPrivilges = "";
                string strCampuses = "";
                string strColleges = "";
                string strDepartments = "";
                DataTable tblFacultyEntryPreviliges = new DataTable();
                tblFacultyEntryPreviliges.Columns.Add("title");
                tblFacultyEntryPreviliges.Columns.Add("id");
                tblFacultyEntryPreviliges.Columns.Add("name");
                string strQuery = "SELECT faculty_entry FROM system_user_table WHERE user_name='" + strUserName + "'";
                reader = objProgram.gRetrieveRecord(strQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    strFacultyEntryPrivilges = reader["faculty_entry"].ToString();
                    reader.Close();
                }
                else
                    reader.Close();
                //The following code will reformat the student entry privilges
                if (strFacultyEntryPrivilges != "")
                {
                    string[] strPrivilegesSplitter = strFacultyEntryPrivilges.Split('|');
                    strCampuses = strPrivilegesSplitter[0];
                    string[] campusesSplitter = strCampuses.Split(',');
                    for (int i = 0; i < campusesSplitter.Length; i++)
                    {
                        tblFacultyEntryPreviliges.Rows.Add("campus", campusesSplitter[i], mRetrieveCampus(campusesSplitter[i]));
                    }
                    strColleges = strPrivilegesSplitter[1];
                    string[] collegeSplitter = strColleges.Split(',');
                    for (int i = 0; i < collegeSplitter.Length; i++)
                    {
                        tblFacultyEntryPreviliges.Rows.Add("college", collegeSplitter[i], mRetrieveCollege(collegeSplitter[i]));
                    }
                    strDepartments = strPrivilegesSplitter[2];
                    string[] departmentsSplitter = strDepartments.Split(',');
                    for (int i = 0; i < departmentsSplitter.Length; i++)
                    {
                        tblFacultyEntryPreviliges.Rows.Add("department",departmentsSplitter[i],mRetrieveDepartment(departmentsSplitter[i]));
                    }
                }

                return tblFacultyEntryPreviliges;
            }
            catch (Exception exp)
            {
                if (reader != null)
                    reader.Close();
                return null;
            }
        }
        public DataTable mCheckEmployeeEntryPrivilges(string strUserName)
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to check the priviliges 
            /// Author: mutawakelm
            /// Date :3/6/2010 8:36:26 AM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                string strEmployeeEntryPrivilges = "";
                string strCampuses = "";
                string strDepartments = "";
                DataTable tblEmployeeEntryPreviliges = new DataTable();
                tblEmployeeEntryPreviliges.Columns.Add("title");
                tblEmployeeEntryPreviliges.Columns.Add("id");
                tblEmployeeEntryPreviliges.Columns.Add("name");
                string strQuery = "SELECT employee_entry FROM system_user_table WHERE user_name='" + strUserName + "'";
                reader = objProgram.gRetrieveRecord(strQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    strEmployeeEntryPrivilges = reader["employee_entry"].ToString();
                    reader.Close();
                }
                else
                    reader.Close();
                //The following code will reformat the student entry privilges
                if (strEmployeeEntryPrivilges != "")
                {
                    string[] strPrivilegesSplitter = strEmployeeEntryPrivilges.Split('|');
                    strCampuses = strPrivilegesSplitter[0];
                    string[] campusesSplitter = strCampuses.Split(',');
                    for (int i = 0; i < campusesSplitter.Length; i++)
                    {
                        tblEmployeeEntryPreviliges.Rows.Add("campus", campusesSplitter[i], mRetrieveCampus(campusesSplitter[i]));
                    }
                  
                    strDepartments = strPrivilegesSplitter[1];
                    string[] departmentsSplitter = strDepartments.Split(',');
                    for (int i = 0; i < departmentsSplitter.Length; i++)
                    {
                        tblEmployeeEntryPreviliges.Rows.Add("department", departmentsSplitter[i], mRetrieveDepartment(departmentsSplitter[i]));
                    }
                }

                return tblEmployeeEntryPreviliges;
            }
            catch (Exception exp)
            {
                if (reader != null)
                    reader.Close();
                return null;
            }
        }
        public DataTable mCheckReportReviewPrivilges(string strUserName)
        {

            //=====================================================//
            /// <summary>
            /// Description:This function will be used to check the priviliges of report review
            /// Author: mutawakelm
            /// Date :3/6/2010 8:36:26 AM
            /// Parameter:
            /// input:
            /// output:
            /// Example:
            /// <summary>
            //=====================================================//
            try
            {
                string strReportReviewPrivilges = "";
                string strCampuses = "";
                string strColleges = "";
                string strDepartments = "";
                string strAdministrativePreviliges = "";
                DataTable tblReportReviewPreviliges = new DataTable();
                tblReportReviewPreviliges.Columns.Add("title");
                tblReportReviewPreviliges.Columns.Add("id");
                tblReportReviewPreviliges.Columns.Add("name");
                string strQuery = "SELECT report_viewer,administrator FROM system_user_table WHERE user_name='" + strUserName + "'";
                reader = objProgram.gRetrieveRecord(strQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    strCampuses = reader["report_viewer"].ToString();
                    strAdministrativePreviliges = reader["administrator"].ToString();
                    reader.Close();
                }
                else
                    reader.Close();
                //The following code will reformat the student entry privilges
                if (strCampuses != "")
                {
                    string[] strPrivilegesSplitter = strCampuses.Split('|');
                    strCampuses = strPrivilegesSplitter[0];
                    string[] campusesSplitter = strCampuses.Split(',');
                    for (int i = 0; i < campusesSplitter.Length; i++)
                    {
                        tblReportReviewPreviliges.Rows.Add("campus", campusesSplitter[i], mRetrieveCampus(campusesSplitter[i]));
                    }
                    strColleges = strPrivilegesSplitter[1];
                    string[] collegeSplitter = strColleges.Split(',');
                    for (int i = 0; i < collegeSplitter.Length; i++)
                    {
                        tblReportReviewPreviliges.Rows.Add("college", collegeSplitter[i], mRetrieveCollege(collegeSplitter[i]));
                    }
                    strDepartments = strPrivilegesSplitter[2];
                    string[] departmentsSplitter = strDepartments.Split(',');
                    for (int i = 0; i < departmentsSplitter.Length; i++)
                    {
                        tblReportReviewPreviliges.Rows.Add("department", departmentsSplitter[i], mRetrieveDepartment(departmentsSplitter[i]));
                    }
                }
                if (strAdministrativePreviliges != "")
                {
                    tblReportReviewPreviliges.Rows.Add("administrative", "0", "yes");
                }

                return tblReportReviewPreviliges;
            }
            catch (Exception exp)
            {
                if (reader != null)
                    reader.Close();
                return null;
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
                string strCampusesQuery = "SELECT * FROM campus_table WHERE campus_id='" + strCampusID + "'";
                reader = objProgram.gRetrieveRecord(strCampusesQuery);
                if (reader.HasRows)
                {
                    reader.Read();
                    returnedCampusName = reader["campus_name"].ToString();
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
                string strCollegeQuery = "SELECT * FROM college_table WHERE code='" + strCollegeId + "'";
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
        public bool mCheckUserAvailablity(string strUserName)
        {
            try
            {
                string strUsersQuery = "SELECT * FROM system_user_table WHERE user_name='"+strUserName+"'";//This variable will contain the query of system users
                reader = objProgram.gRetrieveRecord(strUsersQuery);
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception exp)
            {
                if (reader != null)
                    reader.Close();
                        return false;
            }
        }
      
    }
}
