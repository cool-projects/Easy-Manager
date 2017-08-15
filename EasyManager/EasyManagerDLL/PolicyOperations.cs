using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EasyManagerClasses;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EasyManagerDLL
{
    public class PolicyOperations
    {
        //public int AddPolicy(string name, double monthlyAmount, string waitingPeriod, int maximumMembers)
        //{
        //    try
        //    {
        //        int results = 0;

        //        using (var connection = EasyManagerDLL.GlobalDataAccess.CreateSqlConnection())

        //        using (var command = EasyManagerDLL.GlobalDataAccess.CreateSpCommand("", connection))
        //        {
        //            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        //            command.Parameters.Add("@monthlyAmount", SqlDbType.Decimal).Value = monthlyAmount;
        //            command.Parameters.Add("@waitingPeriod", SqlDbType.NVarChar).Value = waitingPeriod;
        //            command.Parameters.Add("@maximumMembers", SqlDbType.Int).Value = maximumMembers;

        //            using (var reader = EasyManagerDLL.GlobalDataAccess.ExecuteReader(command))
        //            {
        //                if (reader.HasRows)
        //                {
        //                    //Have to test
        //                }

        //            }
        //        }

                
                
        //        //if (connection.State == ConnectionState.Open)
        //        //{
        //        //    string query = "insert into policy (Name, MonthlyFee, WaitingPeriod, Deleted, MaximumMembers)";
        //        //    query += "values('" + name + "', " + monthlyAmount + ", '" + waitingPeriod + "', 1, " + maximumMembers + ");";
        //        //    MySqlCommand command = new MySqlCommand(query, connection);
        //        //    results = command.ExecuteNonQuery();
        //        //}
        //        //connection.Close();
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public int UpdatePolicy(string name, double monthlyAmount, string waitingPeriod, int maximumMembers, bool deleted, int id)
        //{
        //    try
        //    {
        //        int results = 0;

        //        using (var connection = EasyManagerDLL.GlobalDataAccess.CreateSqlConnection())

        //        using (var command = EasyManagerDLL.GlobalDataAccess.CreateSpCommand("", connection))
        //        {
        //            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        //            command.Parameters.Add("@monthlyAmount", SqlDbType.Decimal).Value = monthlyAmount;
        //            command.Parameters.Add("@waitingPeriod", SqlDbType.NVarChar).Value = waitingPeriod;
        //            command.Parameters.Add("@maximumMembers", SqlDbType.Int).Value = maximumMembers;
        //            command.Parameters.Add("@deleted", SqlDbType.Bit).Value = deleted;
        //            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

        //            using (var reader = EasyManagerDLL.GlobalDataAccess.ExecuteReader(command))
        //            {
        //                if (reader.HasRows)
        //                {
        //                    //Have to test
        //                }

        //            }
        //        }

        //        //int notActive = 0;
        //        //string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //        //MySqlConnection connection = new MySqlConnection(connectionString);
        //        //connection.Open();
        //        //if(deleted)
        //        //{
        //        //    notActive = 0;
        //        //}
        //        //else
        //        //{
        //        //    notActive = 1;
        //        //}
        //        //int results = 0;
        //        //if (connection.State == ConnectionState.Open)
        //        //{
        //        //    string query = "update policy set Name = '" + name + "', MonthlyFee = " + monthlyAmount +
        //        //                   ", WaitingPeriod = '" + waitingPeriod + "'" +
        //        //                   ", Deleted = " + notActive + " where id = " + id + ";";
        //        //    MySqlCommand command = new MySqlCommand(query, connection);
        //        //    results = command.ExecuteNonQuery();
        //        //}
        //        //connection.Close();
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public int DeletePolicy(int id)
        //{
        //    try
        //    {
        //        using (var connection = EasyManagerDLL.GlobalDataAccess.CreateSqlConnection())

        //        using (var command = EasyManagerDLL.GlobalDataAccess.CreateSpCommand("", connection))
        //        {
        //            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

        //            using (var reader = EasyManagerDLL.GlobalDataAccess.ExecuteReader(command))
        //            {
        //                if (reader.HasRows)
        //                {
        //                    //Have to test
        //                }

        //            }
        //        }

        //        //int results = 0;
        //        //string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //        //MySqlConnection connection = new MySqlConnection(connectionString);
        //        //connection.Open();

        //        //if (connection.State == ConnectionState.Open)
        //        //{
        //        //    string query = "update policy set Deleted = 0 where id = " + id + ";";
        //        //    MySqlCommand command = new MySqlCommand(query, connection);
        //        //    results = command.ExecuteNonQuery();
        //        //}
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<Policy> GetAllPolicies()
        {
            List<Policy> funeralpolicies = new List<Policy>();
            DataTable dbResults = new DataTable();            

            try
            {
                using (var connection = EasyManagerDLL.GlobalDataAccess.CreateSqlConnection())

                using (var command = EasyManagerDLL.GlobalDataAccess.CreateSpCommand("usp_GetAllPolicies", connection))
                {
                   

                    using (var reader = EasyManagerDLL.GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            dbResults.Load(reader);

                            foreach (DataRow drPolicy in dbResults.Rows)
                            {
                                funeralpolicies.Add(new Policy() {
                                    PolicyID = Convert.ToInt32(drPolicy["ID"]),
                                    PolicyName = drPolicy["PolicyName"].ToString(),
                                    //MonthlyFee = Convert.ToDecimal(drPolicy["MonthlyFee"]),
                                    WaitingPeriod = Convert.ToInt32(drPolicy["WaitingPeriod"]),
                                    MaximumBeneficiaries = Convert.ToInt32(drPolicy["MaximumBeneficiaries"]),
                                    PolicyDescription = drPolicy["PolicyDescription"].ToString()
                                });
                            }
                        }

                    }
                }
                return funeralpolicies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Getting all policy benefits
        //public List<string> PolicyBenefits(string policyName)
        //{
        //    List<string> policyBenefits = new List<string>();
        //    DataTable dbResult = new DataTable();
        //    try
        //    {
        //        using (var connection = EasyManagerDLL.GlobalDataAccess.CreateSqlConnection())

        //        using (var command = EasyManagerDLL.GlobalDataAccess.CreateSpCommand("", connection))
        //        {
        //            command.Parameters.Add("@policyName", SqlDbType.NVarChar).Value = policyName;

        //            using (var reader = EasyManagerDLL.GlobalDataAccess.ExecuteReader(command))
        //            {
        //                if (reader.HasRows)
        //                {
        //                    //Have to test
        //                }

        //            }
        //        }


        //        //List<string> policyBenefits = new List<string>();
        //        //string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //        //MySqlConnection connection = new MySqlConnection(connectionString);
        //        //connection.Open();

        //        //if (connection.State == ConnectionState.Open)
        //        //{
        //        //    string query = "select b.benefit " +
        //        //                    "from policybenefits pb " +
        //        //                    "inner join policy p " +
        //        //                    "on p.id = pb.policyId " +
        //        //                    "inner join Benefits b " +
        //        //                    "on b.id = pb.benefitId " +
        //        //                    "where p.name = '" + policyName + "';";
        //        //    MySqlCommand command = new MySqlCommand(query, connection);
        //        //    MySqlDataReader reader = command.ExecuteReader();
        //        //    while (reader.Read())
        //        //    {
        //        //        policyBenefits.Add(reader.GetString(0));
        //        //    }
        //        //}
        //        //connection.Close();
        //        return policyBenefits;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ////Getting all the benefits
        //public List<string> GetAllBenefits(List<string> currentBenefits)
        //{
        //    try
        //    {
        //        using (var connection = EasyManagerDLL.GlobalDataAccess.CreateSqlConnection())

        //        using (var command = EasyManagerDLL.GlobalDataAccess.CreateSpCommand("", connection))
        //        {
        //            command.Parameters.Add("@currentBenefits", SqlDbType.NVarChar).Value = currentBenefits;

        //            using (var reader = EasyManagerDLL.GlobalDataAccess.ExecuteReader(command))
        //            {
        //                if (reader.HasRows)
        //                {
        //                    //Have to test
        //                }

        //            }
        //            //}
        //            //if (currentBenefits.Count > 0)
        //            //{
        //            //    string benefit = "";
        //            //    StringBuilder currentBenefitList = new StringBuilder();
        //            //    if (currentBenefits.Count > 0)
        //            //    {
        //            //        for (int i = 0; i < currentBenefits.Count; i++)
        //            //        {
        //            //            if (i == (currentBenefits.Count - 1))
        //            //            {
        //            //                benefit = currentBenefits[i] + "');";
        //            //                currentBenefitList.Append(benefit);
        //            //            }
        //            //            else
        //            //            {
        //            //                benefit = currentBenefits[i] + "', '";
        //            //                currentBenefitList.Append(benefit);
        //            //            }
        //            //        }
        //            //    }

        //            //    List<string> allBenefits = new List<string>();
        //            //    string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //            //    MySqlConnection connection = new MySqlConnection(connectionString);
        //            //    connection.Open();

        //            //    if (connection.State == ConnectionState.Open)
        //            //    {
        //            //        string query = "select benefit " +
        //            //                        "from benefits " +
        //            //                        "where benefit not in ('" + currentBenefitList.ToString();

        //            //        MySqlCommand command = new MySqlCommand(query, connection);
        //            //        MySqlDataReader reader = command.ExecuteReader();
        //            //        while (reader.Read())
        //            //        {
        //            //            allBenefits.Add(reader.GetString(0));
        //            //        }

        //            //    }
        //            //    connection.Close();
        //            //    return allBenefits;
        //            //}
        //            //else
        //            //{
        //            //    List<string> allBenefits = new List<string>();
        //            //    string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //            //    MySqlConnection connection = new MySqlConnection(connectionString);
        //            //    connection.Open();

        //            //    if (connection.State == ConnectionState.Open)
        //            //    {
        //            //        string query = "select benefit " +
        //            //                        "from benefits ";

        //            //        MySqlCommand command = new MySqlCommand(query, connection);
        //            //        MySqlDataReader reader = command.ExecuteReader();
        //            //        while (reader.Read())
        //            //        {
        //            //            allBenefits.Add(reader.GetString(0));
        //            //        }

        //            //    }
        //            //    connection.Close();
        //            //    return allBenefits;
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return currentBenefits;
        //}

        ////adding policy benefits
        //public int AddPolicyBenefits(List<string> newBenefits, int policyid)
        //{
        //    try
        //    {
        //        using (var connection = EasyManagerDLL.GlobalDataAccess.CreateSqlConnection())

        //        using (var command = EasyManagerDLL.GlobalDataAccess.CreateSpCommand("", connection))
        //        {
        //            command.Parameters.Add("@newBenefits", SqlDbType.NVarChar).Value = newBenefits;
        //            command.Parameters.Add("@monthlyAmount", SqlDbType.Decimal).Value = monthlyAmount;

        //            using (var reader = EasyManagerDLL.GlobalDataAccess.ExecuteReader(command))
        //            {
        //                if (reader.HasRows)
        //                {
        //                    //Have to test
        //                }

        //            }
        //        }
        //        int results = 0;
        //        string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //        MySqlConnection connection = new MySqlConnection(connectionString);
        //        connection.Open();

        //        if (connection.State == ConnectionState.Open)
        //        {
        //            if (newBenefits.Count > 0)
        //            {
        //                List<int> benefitId = new List<int>();
        //                for (int i = 0; i < newBenefits.Count; i++)
        //                {
        //                    string benefit = newBenefits[i];
        //                    string getBenefitId = "select id from benefits where Benefit = '" + benefit + "';";
        //                    MySqlCommand getBenefitCommand = new MySqlCommand(getBenefitId, connection);
        //                    MySqlDataReader reader = getBenefitCommand.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        benefitId.Add(reader.GetInt32(0));
        //                    }
        //                    reader.Close();                            
        //                }
        //                connection.Close();
        //                string val = "";
        //                StringBuilder builder = new StringBuilder();
        //                for (int z = 0; z < benefitId.Count; z++)
        //                {
        //                    if (z == (benefitId.Count - 1))
        //                    {
        //                        val = "(" + policyid.ToString() + "," + benefitId[z].ToString() + ");";
        //                        builder.Append(val);
        //                    }
        //                    else
        //                    {
        //                        val = "(" + policyid.ToString() + "," + benefitId[z].ToString() + "),";
        //                        builder.Append(val);
        //                    }
                            
        //                }
        //                connection = new MySqlConnection(connectionString);
        //                connection.Open();
        //                    string queryExtender = builder.ToString();
        //                    string addpolicyBenefit = "insert into policybenefits (PolicyId, BenefitId) values " + queryExtender;
        //                    MySqlCommand addPolicyBenefitCommand = new MySqlCommand(addpolicyBenefit, connection);
        //                    results = addPolicyBenefitCommand.ExecuteNonQuery();
                        
        //            }
        //        }
        //        connection.Close();
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ////deleting policy benefit
        //public int RemovePolicyBenefit(int policyid, string benefit)
        //{
        //    try
        //    {
        //        int results = 0;
        //        string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //        MySqlConnection connection = new MySqlConnection(connectionString);
        //        connection.Open();

        //        if (connection.State == ConnectionState.Open)
        //        {
        //            string getBenefitid = "select id from benefits where Benefit = '" + benefit +"';";
        //            int benefitId = 0;
        //            MySqlCommand getbenefitidquery = new MySqlCommand(getBenefitid, connection);
        //            MySqlDataReader reader = getbenefitidquery.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                benefitId = reader.GetInt32(0);
        //            }
        //            reader.Close();

        //            string removepolicyBenefit = "delete from policybenefits where PolicyId = " + policyid + " and BenefitId = " + benefitId + ";";
        //            MySqlCommand removeBenefit = new MySqlCommand(removepolicyBenefit, connection);
        //            results = removeBenefit.ExecuteNonQuery();
        //        }
        //        connection.Close();
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        ////Return Policy Id
        //public int GetPolicyId(string policy)
        //{
        //    try
        //    {
        //        int policyId = 0;
        //        string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //        MySqlConnection connection = new MySqlConnection(connectionString);
        //        connection.Open();
                
        //        string getpolicyid = "select id from policy where Name = '" + policy + "';";
        //        MySqlCommand PolicyId = new MySqlCommand(getpolicyid, connection);
        //        MySqlDataReader reader;
        //        reader = PolicyId.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            policyId = reader.GetInt32(0);
        //        }
        //        reader.Close();
        //        connection.Close();

        //        return policyId;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        ////update policy members
        //public int UpdatePolicyMembers(List<Members> membersList, int policyId)
        //{
        //    try
        //    {
        //        int results = 0;
        //        string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
        //        MySqlConnection connection = new MySqlConnection(connectionString);
        //        connection.Open();

        //        foreach (Members member in membersList)
        //        {
        //            string query = "update policymembers set PolicyId = " + policyId + " where Memberid = " + member.MemberID;
        //            MySqlCommand updateMembers = new MySqlCommand(query, connection);
        //            results = updateMembers.ExecuteNonQuery();
        //        }
        //        connection.Close();
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}
    }
}
