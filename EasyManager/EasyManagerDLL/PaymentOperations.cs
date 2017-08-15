using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Entity;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using EasyManagerClasses;

namespace EasyManagerDLL
{
    public class PaymentOperations
    {
        //Constructor
        public PaymentOperations()
        {
            //Intentionally lefy empty
        }

        
        /// <summary>
        /// Method to insert payment into the database
        /// </summary>
        /// <param name="IdNumber"></param>
        /// <param name="policy"></param>
        /// <param name="amount"></param>
        /// <param name="paymentDate"></param>
        /// <returns></returns>
        public int UpdatePayment(string IdNumber, int policy, decimal amount)
        {//ProcessMemberPayment
            int results = 0;
            try
            {
                using (var command = GlobalDataAccess.CreateSpCommand("ProcessMemberPayment", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@identityNumber", SqlDbType.NVarChar).Value = IdNumber;
                    command.Parameters.Add("@policy", SqlDbType.Int).Value = policy;
                    command.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        results = reader.RecordsAffected;
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method used to get member payment records
        public DataTable GetMemberPayments(string memberIdentity)
        {
            try
            {
                DataTable dbResult = new DataTable("members");

                using (var command = GlobalDataAccess.CreateSpCommand("GETMEMBERPAYMENTS", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@identityNumber", SqlDbType.NVarChar).Value = memberIdentity;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            DataTable tblResults = new DataTable();
                            tblResults.Load(reader);
                            dbResult = tblResults;
                        }
                    }
                }
                return dbResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllPayments()
        {
            try
            {
                DataTable dbResult = new DataTable("payment");

                using (var command = GlobalDataAccess.CreateSpCommand("GETALLPAYMENTS", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            DataTable tblResults = new DataTable();
                            tblResults.Load(reader);
                            dbResult = tblResults;
                        }
                    }
                }
                return dbResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
