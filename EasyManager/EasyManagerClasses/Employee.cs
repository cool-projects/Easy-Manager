using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyManagerClasses
{
    public class Employee
    {
        int id;
        string employeeName;
        string surname;
        string identityNumber;
        string residentialAddress;
        string contactNumber;
        string userName;
        string password;
        bool userActive;
        string position;

        public int employeeID
        {
            get { return id; }
            set { id = value; }
        }

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string IdentityNumber
        {
            get { return identityNumber; }
            set { identityNumber = value; }
        }

        public string ResidentialAddress
        {
            get { return residentialAddress; }
            set { residentialAddress = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string Username
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool UserActive
        {
            get { return userActive; }
            set { userActive = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
