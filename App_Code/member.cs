using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for member
/// </summary>
/// 

namespace GeneralClass
{
    public class member
    {
        private string FirstName;
        private string MiddleName;
        private string LastName;

        public member()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void setFirstName(string fName)
        {
            FirstName = fName;
        }
        public void setMiddleName(string MName)
        {
            MiddleName = MName;
        }
        public void setLastName(string LName)
        {
            LastName = LName;
        }
        public string getFirstName()
        {
            return this.FirstName;
        }
        public string getMiddleName()
        {
            return this.MiddleName;
        }
        public string getLastName()
        {
            return this.LastName;
        }
    }
}
