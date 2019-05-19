using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudioGuide.Models
{
    public class Info
    {

        public class Doctor
        {
            public string name;
            public string phoneNumber;
            public string email;
            public string password;
            public string specialization;
            public string dob;
        }

        public class Patient
        {

            public string name;
            public string phoneNumber;
            public string email;
            public string password;
            public string fatherName;
            public string address;
            public string dob;
        }
    }
}