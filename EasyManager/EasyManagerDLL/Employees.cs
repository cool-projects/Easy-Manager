 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EasyManagerClasses;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace EasyManagerDLL
{
    public class EmployeeOperation
    {
        public int AddEmployee(string employeeName, string surname, string identityNumber,
            string residentialAddress, string contactNumber, string userName, string password,
            bool active, string position)
        {
            try
            {
                int results = 0;

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["easyconnection"].ConnectionString;
                
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    int activeMember = 0;
                    if (active == true)
                    {
                        activeMember = 1;
                    }

                    string insertQuery = "insert into Employees(Name, Surname, IDNumber, ";
                    insertQuery += "ResidentialAddress, ContactNumber, Username, User_Password, Active, EmployeePosition)";
                    insertQuery += " VALUES ('" + employeeName + "', '" + surname + "', '" + identityNumber + "', '" +
                        residentialAddress + "', '" + contactNumber + "', '" + userName + "', '" + password + "', " + activeMember + ", '" + position + "');";

                    MySqlCommand insertEmployeeCommand = new MySqlCommand(insertQuery, connection);
                    results = insertEmployeeCommand.ExecuteNonQuery();
                    connection.Close();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEmployee(int id, string employeeName, string surname, string identityNumber,
            string residentialAddress, string contactNumber, string userName, string password,
            bool active, string position)
        {
            try
            {
                int results = 0;
                int memberActive = 0;
                if (active == true)
                {
                    memberActive = 1;
                }
                string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string updateQuery = "update Employees set Name = '" + employeeName + "' , Surname = '" + surname + "'  , IDNumber = '" + identityNumber + "', ";
                    updateQuery += "ResidentialAddress = '" + residentialAddress + "', ContactNumber = '" + contactNumber + "', Username = '" + userName + "', User_Password = '" + password + "', Active = " + memberActive + " , EmployeePosition = '" + position + "'";
                    updateQuery += " where id = " + id + ";";
                    MySqlCommand updateEmployeeCommand = new MySqlCommand(updateQuery, connection);
                    results = updateEmployeeCommand.ExecuteNonQuery();
                    connection.Close();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteEmployee(int id, string identityNumber, bool active = false)
        {
            try
            {
                int results = 0;

                string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string deleteQuery = "update Employees set Active = " + 0 + " where IDNumber = " + identityNumber + " and id = " + id + ";";
                    MySqlCommand updateEmployeeCommand = new MySqlCommand(deleteQuery, connection);
                    results = updateEmployeeCommand.ExecuteNonQuery();
                    connection.Close();
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                Employee employee;
                List<Employee> EmployeeCollection = new List<Employee>(); 
                
                var connectionString = ConfigurationManager.ConnectionStrings["easyconnection"].ConnectionString;

               // string connectionString = ConfigurationSettings.AppSettings["con"];
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "select * from employees";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee = new Employee();
                        employee.employeeID = reader.GetInt32(0);
                        employee.EmployeeName = reader.GetString(1);
                        employee.Surname = reader.GetString(2);
                        employee.IdentityNumber = reader.GetString(3);
                        employee.ResidentialAddress = reader.GetString(4);
                        employee.ContactNumber = reader.GetString(5);
                        employee.Username = reader.GetString(6);
                        employee.Password = reader.GetString(7);
                        employee.UserActive = reader.GetBoolean(8);
                        employee.Position = reader.GetString(9);
                        EmployeeCollection.Add(employee);
                    }
                   
                }
                return EmployeeCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}