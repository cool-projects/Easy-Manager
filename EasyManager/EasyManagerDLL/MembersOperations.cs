using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EasyManagerClasses;
using System.Configuration;

namespace EasyManagerDLL
{
    public class MembersOperations
    {
        public List<SimpleStatistics> GetSimpleStats(string userID)
        {
            try
            {
                DataTable dbResult = new DataTable("stats");
                List<SimpleStatistics> statsList = new List<SimpleStatistics>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetSimpleStatistics", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = userID;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drStats in dbResult.Rows)
                            {
                                statsList.Add(new SimpleStatistics()
                                {
                                    stat_name = drStats["stat_name"].ToString(),
                                    stat_count = Convert.ToInt32(drStats["stat_count"]),
                                });
                            }
                        }
                    }
                }
                return statsList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddMember(MemberCreate member)
        {
            try
            {
                //DateTime birthDate = new DateTime();
                //birthDate = 

                using (var command = GlobalDataAccess.CreateSpCommand("usp_AddNewMember", GlobalDataAccess.CreateSqlConnection()))
                {
                    string Initials = string.Empty;
                    foreach (var character in member.FirstName.Split(' '))
                    {
                        Initials += character.Substring(0, 1);
                    }
                    command.Parameters.Add("@MainMemID", SqlDbType.NVarChar).Value = member.MainMemberID;
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = member.FirstName;
                    command.Parameters.Add("@Initials", SqlDbType.NVarChar).Value = Initials;
                    command.Parameters.Add("@KnownAs", SqlDbType.NVarChar).Value = member.KnownAs;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = member.LastName;
                    command.Parameters.Add("@Gender", SqlDbType.Int).Value = member.Gender;
                    command.Parameters.Add("@IdentityNumber", SqlDbType.NVarChar).Value = member.IdentityNumber;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = member.DateOfBirth;
                    command.Parameters.Add("@Title", SqlDbType.Int).Value = member.Title;
                    command.Parameters.Add("@Nationality", SqlDbType.Int).Value = member.Nationality;
                    command.Parameters.Add("@MemType", SqlDbType.Int).Value = member.MembershipType;
                    command.Parameters.Add("@MemStatus", SqlDbType.Int).Value = 3;
                    command.Parameters.Add("@ImageFilename", SqlDbType.NVarChar).Value = member.ImageFilename;
                    command.Parameters.Add("@ImageFile", SqlDbType.VarBinary).Value = member.ImageFile;
                    command.Parameters.Add("@Cellphone", SqlDbType.NVarChar).Value = member.Cellphone;
                    command.Parameters.Add("@AddressLine1", SqlDbType.NVarChar).Value = member.AddressLine1;
                    command.Parameters.Add("@AddressLine2", SqlDbType.NVarChar).Value = member.AddressLine2;
                    command.Parameters.Add("@Province", SqlDbType.Int).Value = member.Province;
                    command.Parameters.Add("@City", SqlDbType.Int).Value = member.City;
                    command.Parameters.Add("@Deleted", SqlDbType.Bit).Value = false;
                    command.Parameters.Add("@LastUpdateTimestamp", SqlDbType.DateTime).Value = null;
                    command.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = member.UserId;
                    command.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = null;
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = member.UserId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        return reader.RecordsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EditMember(MemberToEdit member)
        {
            try
            {
                //DateTime birthDate = new DateTime();
                //birthDate = 

                using (var command = GlobalDataAccess.CreateSpCommand("usp_EditMember", GlobalDataAccess.CreateSqlConnection()))
                {
                    string Initials = string.Empty;
                    foreach (var character in member.FirstName.Split(' '))
                    {
                        Initials += character.Substring(0, 1);
                    }
                    command.Parameters.Add("@MembershipNo", SqlDbType.NVarChar).Value = member.MembershipNumber;
                    command.Parameters.Add("@MainMemID", SqlDbType.NVarChar).Value = member.MainMemberID;
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = member.FirstName;
                    command.Parameters.Add("@Initials", SqlDbType.NVarChar).Value = Initials;
                    command.Parameters.Add("@KnownAs", SqlDbType.NVarChar).Value = member.KnownAs;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = member.LastName;
                    command.Parameters.Add("@Gender", SqlDbType.Int).Value = member.Gender;
                    command.Parameters.Add("@IdentityNumber", SqlDbType.NVarChar).Value = member.IdentityNumber;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = member.DateOfBirth;
                    command.Parameters.Add("@Title", SqlDbType.Int).Value = member.Title;
                    command.Parameters.Add("@Nationality", SqlDbType.Int).Value = member.Nationality;
                    command.Parameters.Add("@MemType", SqlDbType.Int).Value = member.MembershipType;
                    command.Parameters.Add("@MemStatus", SqlDbType.Int).Value = member.MembershipStatus;
                    command.Parameters.Add("@ImageFilename", SqlDbType.NVarChar).Value = member.ImageFilename;
                    command.Parameters.Add("@ImageFile", SqlDbType.VarBinary).Value = member.ImageFile;
                    command.Parameters.Add("@Cellphone", SqlDbType.NVarChar).Value = member.Cellphone;
                    command.Parameters.Add("@AddressLine1", SqlDbType.NVarChar).Value = member.AddressLine1;
                    command.Parameters.Add("@AddressLine2", SqlDbType.NVarChar).Value = member.AddressLine2;
                    command.Parameters.Add("@Province", SqlDbType.Int).Value = member.Province;
                    command.Parameters.Add("@City", SqlDbType.Int).Value = member.City;
                    command.Parameters.Add("@Deleted", SqlDbType.Bit).Value = false;
                    command.Parameters.Add("@LastUpdateTimestamp", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = member.UserId;
                    command.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = member.UserId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        return reader.RecordsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //AllocatePolicyToMember
        public int AllocatePolicyToMember(MemberPolicyCreate member)
        {
            try
            {
                using (var command = GlobalDataAccess.CreateSpCommand("usp_AllocatePolicyToMember", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@MembershipNumber", SqlDbType.NVarChar).Value = member.MembershipNumber;
                    command.Parameters.Add("@IsLatest", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@PolicyID", SqlDbType.Int).Value = member.PolicyID; 
                    command.Parameters.Add("@AdminFee", SqlDbType.Decimal).Value = member.AdminFee;
                    command.Parameters.Add("@MonthlyFee", SqlDbType.Decimal).Value = member.MonthlyFee;
                    command.Parameters.Add("@NoOfBeneficiaries", SqlDbType.Int).Value = member.NoOfBeneficiaries;
                    command.Parameters.Add("@WaitingPeriod", SqlDbType.Int).Value = member.WaitingPeriod;
                    command.Parameters.Add("@Deleted", SqlDbType.Bit).Value = false;
                    command.Parameters.Add("@LastUpdateTimestamp", SqlDbType.DateTime).Value = null;
                    command.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = member.UserId;
                    command.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = null;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        foreach (var item in member.Benefits)
                        {
                            using (var command1 = GlobalDataAccess.CreateSpCommand("usp_AllocateBenefits", GlobalDataAccess.CreateSqlConnection()))
                            {
                                command1.Parameters.Add("@MembershipNumber", SqlDbType.NVarChar).Value = member.MembershipNumber;
                                command1.Parameters.Add("@BenefitID", SqlDbType.Int).Value = item.BenefitID;
                                command1.Parameters.Add("@Deleted", SqlDbType.Bit).Value = false;
                                command1.Parameters.Add("@LastUpdateTimestamp", SqlDbType.DateTime).Value = null;
                                command1.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime).Value = DateTime.Now;
                                command1.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = member.UserId;
                                command1.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = null;
                                using (var reader1 = GlobalDataAccess.ExecuteReader(command1))
                                {
                                    //return reader1.RecordsAffected;
                                }
                            }
                        }
                        return reader.RecordsAffected;
                    }
                }
                
                //return 1;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }
        //EditPolicyMember
        public int EditPolicyMember(MemberPolicyEdit member)
        {
            try
            {
                using (var command = GlobalDataAccess.CreateSpCommand("usp_EditPolicyMember", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@MembershipNumber", SqlDbType.NVarChar).Value = member.MembershipNumber;
                    command.Parameters.Add("@IsLatest", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@PolicyID", SqlDbType.Int).Value = member.PolicyID;
                    command.Parameters.Add("@AdminFee", SqlDbType.Decimal).Value = member.AdminFee;
                    command.Parameters.Add("@MonthlyFee", SqlDbType.Decimal).Value = member.MonthlyFee;
                    command.Parameters.Add("@NoOfBeneficiaries", SqlDbType.Int).Value = member.NoOfBeneficiaries;
                    command.Parameters.Add("@WaitingPeriod", SqlDbType.Int).Value = member.WaitingPeriod;
                    command.Parameters.Add("@Deleted", SqlDbType.Bit).Value = false;
                    command.Parameters.Add("@LastUpdateTimestamp", SqlDbType.DateTime).Value = null;
                    command.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = member.UserId;
                    command.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = null;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        foreach (var item in member.Benefits)
                        {
                            using (var command1 = GlobalDataAccess.CreateSpCommand("usp_UpdateMemberBenefits", GlobalDataAccess.CreateSqlConnection()))
                            {
                                command1.Parameters.Add("@MembershipNumber", SqlDbType.NVarChar).Value = member.MembershipNumber;
                                command1.Parameters.Add("@BenefitID", SqlDbType.Int).Value = item.BenefitID;
                                command1.Parameters.Add("@Deleted", SqlDbType.Bit).Value = false;
                                command1.Parameters.Add("@LastUpdateTimestamp", SqlDbType.DateTime).Value = null;
                                command1.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime).Value = DateTime.Now;
                                command1.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = member.UserId;
                                command1.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = null;
                                using (var reader1 = GlobalDataAccess.ExecuteReader(command1))
                                {
                                    //return reader1.RecordsAffected;
                                }
                            }
                        }
                        return reader.RecordsAffected;
                    }
                }

                //return 1;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }
        //GetBenefits
        public List<Benefit> GetBenefits()
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<Benefit> BenefitsList = new List<Benefit>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetBenefits", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drBenefits in dbResult.Rows)
                            {
                                BenefitsList.Add(new Benefit()
                                {
                                    BenefitID = Convert.ToInt32(drBenefits["ID"]),
                                    BenefitName = drBenefits["BenefitName"].ToString(),
                                    Description = drBenefits["Description"].ToString(),
                                    BenefitCost = Convert.ToDecimal(drBenefits["BenefitCost"]),
                                });
                            }
                        }
                    }
                }
                return BenefitsList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetMemberBenefits
        public List<Benefit> GetMemberBenefits(string memNo)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<Benefit> BenefitsList = new List<Benefit>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetMemberBenefits", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@memNo", SqlDbType.NVarChar).Value = memNo;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drBenefits in dbResult.Rows)
                            {
                                BenefitsList.Add(new Benefit()
                                {
                                    BenefitID = Convert.ToInt32(drBenefits["ID"]),
                                    BenefitName = drBenefits["BenefitName"].ToString(),
                                    Description = drBenefits["Description"].ToString(),
                                    BenefitCost = Convert.ToDecimal(drBenefits["BenefitCost"]),
                                });
                            }
                        }
                    }
                }
                return BenefitsList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateMemberDetails(Members member)
        {
            try
            {
                int results = 0;

                using (var command = GlobalDataAccess.CreateSpCommand("UpdatePolicyMember", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@FirstNme", SqlDbType.NVarChar).Value = member.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = member.LastName;
                    command.Parameters.Add("@KnownAs", SqlDbType.NVarChar).Value = member.KnownAs;
                    command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = member.Gender;
                    command.Parameters.Add("@Title", SqlDbType.Char).Value = member.Title;
                    command.Parameters.Add("@IdentityNumber", SqlDbType.NVarChar).Value = member.IdentityNumber;
                    command.Parameters.Add("@birthDate", SqlDbType.DateTime).Value = member.DateOfBirth.ToString();
                    command.Parameters.Add("@Nationality", SqlDbType.NVarChar).Value = member.Nationality;
                    command.Parameters.Add("@MemType", SqlDbType.NVarChar).Value = member.MembershipType;
                    command.Parameters.Add("@MemberStatus", SqlDbType.NVarChar).Value = member.MembershipStatus;
                    command.Parameters.Add("@MemberId", SqlDbType.Int).Value = member.MemberId;

                    results = GlobalDataAccess.ExecuteNonQuery(command);

                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Members> GetAllMembers(string UserId)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<Members> policyMembersList = new List<Members>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetAllMembers", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            
                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                policyMembersList.Add(new Members()
                                {
                                    MemberId = Convert.ToInt32(drPolicyMember["ID"]),
                                    MembershipNumber = drPolicyMember["MembershipNumber"].ToString(),
                                    MainMemberID = drPolicyMember["MainMemberID"].ToString(),
                                    FirstName = drPolicyMember["FirstName"].ToString(),
                                    Initials = drPolicyMember["Initials"].ToString(),
                                    KnownAs = drPolicyMember["KnownAs"].ToString(),
                                    Gender = drPolicyMember["Gender"].ToString(),
                                    LastName = drPolicyMember["LastName"].ToString(),
                                    IdentityNumber = drPolicyMember["IdentityNumber"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(drPolicyMember["DateOfBirth"]),
                                    Title = drPolicyMember["Title"].ToString(),
                                    Nationality = drPolicyMember["Nationality"].ToString(),
                                    MembershipType = drPolicyMember["MembershipType"].ToString(),
                                    MembershipStatus = drPolicyMember["MembershipStatus"].ToString(),
                                    ImageFilename = drPolicyMember["ImageFilename"].ToString(),
                                    ImageFile = (byte[])drPolicyMember["ImageFile"],
                                    Cellphone = drPolicyMember["Cellphone"].ToString(),
                                    AddressLine1 = drPolicyMember["AddressLine1"].ToString(),
                                    AddressLine2 = drPolicyMember["AddressLine2"].ToString(),
                                    CityID = drPolicyMember["CityID"].ToString(),
                                    ProvinceID = drPolicyMember["ProvinceID"].ToString(),
                                    City = drPolicyMember["City"].ToString(),
                                    Province = drPolicyMember["Province"].ToString(),
                                });
                            }
                        }
                    }
                }
                return policyMembersList;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Members> GetMainMembers(string UserId)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<Members> policyMembersList = new List<Members>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetMainMembers", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                policyMembersList.Add(new Members()
                                {
                                    MemberId = Convert.ToInt32(drPolicyMember["ID"]),
                                    MembershipNumber = drPolicyMember["MembershipNumber"].ToString(),
                                    MainMemberID = drPolicyMember["MainMemberID"].ToString(),
                                    FirstName = drPolicyMember["FirstName"].ToString(),
                                    Initials = drPolicyMember["Initials"].ToString(),
                                    KnownAs = drPolicyMember["KnownAs"].ToString(),
                                    Gender = drPolicyMember["Gender"].ToString(),
                                    LastName = drPolicyMember["LastName"].ToString(),
                                    IdentityNumber = drPolicyMember["IdentityNumber"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(drPolicyMember["DateOfBirth"]),
                                    Title = drPolicyMember["Title"].ToString(),
                                    Nationality = drPolicyMember["Nationality"].ToString(),
                                    MembershipType = drPolicyMember["MembershipType"].ToString(),
                                    MembershipStatus = drPolicyMember["MembershipStatus"].ToString(),
                                    ImageFilename = drPolicyMember["ImageFilename"].ToString(),
                                    ImageFile = (byte[])drPolicyMember["ImageFile"],
                                    Cellphone = drPolicyMember["Cellphone"].ToString(),
                                    AddressLine1 = drPolicyMember["AddressLine1"].ToString(),
                                    AddressLine2 = drPolicyMember["AddressLine2"].ToString(),
                                    CityID = drPolicyMember["CityID"].ToString(),
                                    ProvinceID = drPolicyMember["ProvinceID"].ToString(),
                                    City = drPolicyMember["City"].ToString(),
                                    Province = drPolicyMember["Province"].ToString(),
                                });
                            }
                        }
                    }
                }
                return policyMembersList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Members> GetAllocatedMembers(string UserId)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<Members> policyMembersList = new List<Members>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetAllocatedMembers", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                policyMembersList.Add(new Members()
                                {
                                    MemberId = Convert.ToInt32(drPolicyMember["ID"]),
                                    MembershipNumber = drPolicyMember["MembershipNumber"].ToString(),
                                    MainMemberID = drPolicyMember["MainMemberID"].ToString(),
                                    FirstName = drPolicyMember["FirstName"].ToString(),
                                    Initials = drPolicyMember["Initials"].ToString(),
                                    LastName = drPolicyMember["LastName"].ToString(),
                                    IdentityNumber = drPolicyMember["IdentityNumber"].ToString(),
                                    Title = drPolicyMember["Title"].ToString(),
                                });
                            }
                        }
                    }
                }
                return policyMembersList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Members> GetUnAllocatedMembers(string UserId)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<Members> policyMembersList = new List<Members>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetUnAllocatedMembers", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                policyMembersList.Add(new Members()
                                {
                                    MemberId = Convert.ToInt32(drPolicyMember["ID"]),
                                    MembershipNumber = drPolicyMember["MembershipNumber"].ToString(),
                                    MainMemberID = drPolicyMember["MainMemberID"].ToString(),
                                    FirstName = drPolicyMember["FirstName"].ToString(),
                                    Initials = drPolicyMember["Initials"].ToString(),
                                    LastName = drPolicyMember["LastName"].ToString(),
                                    IdentityNumber = drPolicyMember["IdentityNumber"].ToString(),
                                    Title = drPolicyMember["Title"].ToString(),
                                });
                            }
                        }
                    }
                }
                return policyMembersList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Members> GetBeneficiaries(string membershipNo)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<Members> policyMembersList = new List<Members>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetBeneficiaries", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@memNo", SqlDbType.NVarChar).Value = membershipNo;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                policyMembersList.Add(new Members()
                                {
                                    MemberId = Convert.ToInt32(drPolicyMember["ID"]),
                                    MembershipNumber = drPolicyMember["MembershipNumber"].ToString(),
                                    MainMemberID = drPolicyMember["MainMemberID"].ToString(),
                                    FirstName = drPolicyMember["FirstName"].ToString(),
                                    Initials = drPolicyMember["Initials"].ToString(),
                                    KnownAs = drPolicyMember["KnownAs"].ToString(),
                                    Gender = drPolicyMember["Gender"].ToString(),
                                    LastName = drPolicyMember["LastName"].ToString(),
                                    IdentityNumber = drPolicyMember["IdentityNumber"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(drPolicyMember["DateOfBirth"]),
                                    Title = drPolicyMember["Title"].ToString(),
                                    Nationality = drPolicyMember["Nationality"].ToString(),
                                    MembershipType = drPolicyMember["MembershipType"].ToString(),
                                    MembershipStatus = drPolicyMember["MembershipStatus"].ToString(),
                                    ImageFilename = drPolicyMember["ImageFilename"].ToString(),
                                    ImageFile = (byte[])drPolicyMember["ImageFile"],
                                    Cellphone = drPolicyMember["Cellphone"].ToString(),
                                    AddressLine1 = drPolicyMember["AddressLine1"].ToString(),
                                    AddressLine2 = drPolicyMember["AddressLine2"].ToString(),
                                    CityID = drPolicyMember["CityID"].ToString(),
                                    ProvinceID = drPolicyMember["ProvinceID"].ToString(),
                                    City = drPolicyMember["City"].ToString(),
                                    Province = drPolicyMember["Province"].ToString(),
                                });
                            }
                        }
                    }
                }
                return policyMembersList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Members GetMemberInfo(int id)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                Members memberInfo = new Members();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetMemberInfo", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                memberInfo.MemberId = Convert.ToInt32(drPolicyMember["ID"]);
                                memberInfo.MembershipNumber = drPolicyMember["MembershipNumber"].ToString();
                                memberInfo.MainMemberID = drPolicyMember["MainMemberID"].ToString();
                                   memberInfo.FirstName = drPolicyMember["FirstName"].ToString();
                                   memberInfo.KnownAs = drPolicyMember["KnownAs"].ToString();
                                   memberInfo.Gender = drPolicyMember["Gender"].ToString();
                                   memberInfo.LastName = drPolicyMember["LastName"].ToString();
                                   memberInfo.IdentityNumber = drPolicyMember["IdentityNumber"].ToString();
                                   memberInfo.DateOfBirth = Convert.ToDateTime(drPolicyMember["DateOfBirth"]);
                                   memberInfo.Title = drPolicyMember["Title"].ToString();
                                   memberInfo.Nationality = drPolicyMember["Nationality"].ToString();
                                   memberInfo.MembershipType = drPolicyMember["MembershipType"].ToString();
                                   memberInfo.MembershipStatus = drPolicyMember["MembershipStatus"].ToString();
                                   memberInfo.ImageFilename = drPolicyMember["ImageFilename"].ToString();
                                   memberInfo.ImageFile = (byte[])drPolicyMember["ImageFile"];
                                   memberInfo.Cellphone = drPolicyMember["Cellphone"].ToString();
                                   memberInfo.AddressLine1 = drPolicyMember["AddressLine1"].ToString();
                                   memberInfo.AddressLine2 = drPolicyMember["AddressLine2"].ToString();
                                   memberInfo.City = drPolicyMember["City"].ToString();
                                memberInfo.Province = drPolicyMember["Province"].ToString();
                            }
                        }
                    }
                }
                return memberInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetPolicyMembers
        public List<MemberPolicy> GetPolicyMembers(string UserId)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                List<MemberPolicy> policyMembersList = new List<MemberPolicy>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetPolicyMembers", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                policyMembersList.Add(new MemberPolicy()
                                {
                                    PolicyID = Convert.ToInt32(drPolicyMember["PolicyID"]),
                                    PolicyNumber = drPolicyMember["PolicyNumber"].ToString(),
                                    PolicyName = drPolicyMember["PolicyName"].ToString(),
                                    MonthlyFee = Convert.ToDecimal(drPolicyMember["MonthlyFee"]),
                                    WaitingPeriod = Convert.ToInt32(drPolicyMember["WaitingPeriod"]),
                                    DateJoined = Convert.ToDateTime(drPolicyMember["DateJoined"]),
                                    DateActivated = Convert.ToDateTime(drPolicyMember["DateActivated"]),
                                    MainMemberID = drPolicyMember["MainMemberID"].ToString(),
                                    FirstName = drPolicyMember["FirstName"].ToString(),
                                    Initials = drPolicyMember["Initials"].ToString(),
                                    LastName = drPolicyMember["LastName"].ToString(),
                                    ImageFile = (byte[])drPolicyMember["ImageFile"],
                                    MembershipStatus = drPolicyMember["MembershipStatus"].ToString(),
                                });
                            }
                        }
                    }
                }
                return policyMembersList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetPolicyMemberInfo
        public MemberPolicy GetPolicyMemberInfo(string membershipNo)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                MemberPolicy memberInfo = new MemberPolicy();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetPolicyMemberInfo", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@memNo", SqlDbType.NVarChar).Value = membershipNo;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                memberInfo.PolicyID = Convert.ToInt32(drPolicyMember["PolicyID"]);
                                memberInfo.PolicyNumber = drPolicyMember["PolicyNumber"].ToString();
                                memberInfo.PolicyName = drPolicyMember["PolicyName"].ToString();
                                memberInfo.AdminFee = Convert.ToDecimal(drPolicyMember["AdminFee"]);
                                memberInfo.MonthlyFee = Convert.ToDecimal(drPolicyMember["MonthlyFee"]);
                                memberInfo.WaitingPeriod = Convert.ToInt32(drPolicyMember["WaitingPeriod"]);
                                memberInfo.DateJoined = Convert.ToDateTime(drPolicyMember["DateJoined"]);
                                memberInfo.DateActivated = Convert.ToDateTime(drPolicyMember["DateActivated"]);
                                memberInfo.MainMemberID = drPolicyMember["MainMemberID"].ToString();
                                memberInfo.FirstName = drPolicyMember["FirstName"].ToString();
                                memberInfo.Initials = drPolicyMember["Initials"].ToString();
                                memberInfo.LastName = drPolicyMember["LastName"].ToString();
                                memberInfo.ImageFile = (byte[])drPolicyMember["ImageFile"];
                                memberInfo.MembershipStatus = drPolicyMember["MembershipStatus"].ToString();
                            }
                        }
                    }
                }
                //Beneficiaries

                return memberInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetPolicyInfo
        public Policy GetPolicyInfo(int polID)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                Policy memberInfo = new Policy();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetPolicyInfo", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@polID", SqlDbType.NVarChar).Value = polID;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drPolicyMember in dbResult.Rows)
                            {
                                memberInfo.PolicyID = Convert.ToInt32(drPolicyMember["ID"]);
                                memberInfo.PolicyName = drPolicyMember["PolicyName"].ToString();
                                memberInfo.PolicyDescription = drPolicyMember["PolicyDescription"].ToString();
                                memberInfo.WaitingPeriod = Convert.ToInt32(drPolicyMember["WaitingPeriod"]);
                                memberInfo.MaximumBeneficiaries = Convert.ToInt32(drPolicyMember["MaximumBeneficiaries"]);
                            }
                        }
                    }
                }
                //Beneficiaries

                return memberInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Policy GetMemberPolicy(string IdentityNumber)
        {
            Policy memberPolicy = new Policy();
            try
            {
                DataTable dbResult = new DataTable("members");

                using (var command = GlobalDataAccess.CreateSpCommand("usp_MemberPolicyDetails", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@IdentityNumber", SqlDbType.NVarChar).Value = IdentityNumber;

                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            DataTable tblResults = new DataTable();
                            tblResults.Load(reader);
                            memberPolicy = new Policy()
                            {
                                //ID = Convert.ToInt32(tblResults.Rows[0]["PolicyId"].ToString()),
                                //Name = tblResults.Rows[0]["PolicyType"].ToString(),
                                //MonthlyFee = Convert.ToDecimal(tblResults.Rows[0]["Amount"].ToString()),
                                //WaitingPeriod = tblResults.Rows[0]["WaitingPeriod"].ToString(),
                                //MaximumMembers = Convert.ToInt32(tblResults.Rows[0]["MaximumMembers"].ToString())
                            };


                        }
                    }
                }
                return memberPolicy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetMemberToEdit
        public MemberToEdit GetMemberToEdit(int id)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                MemberToEdit memberInfo = new MemberToEdit();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetMemberToEdit", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drMember in dbResult.Rows)
                            {
                                memberInfo.MemberId = Convert.ToInt32(drMember["ID"]);
                                memberInfo.MembershipNumber = drMember["MembershipNumber"].ToString();
                                memberInfo.MainMemberID = drMember["MainMemberID"].ToString();
                                memberInfo.FirstName = drMember["FirstName"].ToString();
                                memberInfo.Initials = drMember["Initials"].ToString();
                                memberInfo.KnownAs = drMember["KnownAs"].ToString();
                                memberInfo.Gender = Convert.ToInt32(drMember["GenderID"]);
                                memberInfo.LastName = drMember["LastName"].ToString();
                                memberInfo.IdentityNumber = drMember["IdentityNumber"].ToString();
                                memberInfo.DateOfBirth = Convert.ToDateTime(drMember["DateOfBirth"]).ToString("yyyy-MM-dd");
                                memberInfo.Title = Convert.ToInt32(drMember["TitleID"]);
                                memberInfo.Nationality = Convert.ToInt32(drMember["CountryID"]);
                                memberInfo.MembershipType = Convert.ToInt32(drMember["MembershipTypeID"]);
                                memberInfo.MembershipStatus = Convert.ToInt32(drMember["MembershipStatusID"]);
                                memberInfo.ImageFilename = drMember["ImageFilename"].ToString();
                                memberInfo.ImageFile = (byte[])drMember["ImageFile"];
                                memberInfo.Cellphone = drMember["Cellphone"].ToString();
                                memberInfo.AddressLine1 = drMember["AddressLine1"].ToString();
                                memberInfo.AddressLine2 = drMember["AddressLine2"].ToString();
                                memberInfo.City = Convert.ToInt32(drMember["CityID"]);
                                memberInfo.Province = Convert.ToInt32(drMember["ProvinceID"]);
                            }
                        }
                    }
                }
                return memberInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetMemberPolicyToEdit
        public MemberPolicyEdit GetMemberPolicyToEdit(string memNo)
        {
            try
            {
                DataTable dbResult = new DataTable("members");
                MemberPolicyEdit memberPolicyInfo = new MemberPolicyEdit();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetMemberPolicyToEdit", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@memNo", SqlDbType.NVarChar).Value = memNo;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drMemberPolicy in dbResult.Rows)
                            {
                                memberPolicyInfo.MemberPolicyID = Convert.ToInt32(drMemberPolicy["MemberPolicyID"]);
                                memberPolicyInfo.MembershipNumber = drMemberPolicy["MembershipNumber"].ToString();
                                memberPolicyInfo.FirstName = drMemberPolicy["FirstName"].ToString();
                                memberPolicyInfo.Initials = drMemberPolicy["Initials"].ToString();
                                memberPolicyInfo.LastName = drMemberPolicy["LastName"].ToString();
                                memberPolicyInfo.PolicyNumber = drMemberPolicy["PolicyNumber"].ToString();
                                memberPolicyInfo.PolicyID = Convert.ToInt32(drMemberPolicy["PolicyID"]);
                                memberPolicyInfo.PolicyName = drMemberPolicy["PolicyName"].ToString();
                                memberPolicyInfo.PolicyDescription = drMemberPolicy["PolicyDescription"].ToString();
                                memberPolicyInfo.WaitingPeriod = Convert.ToInt32(drMemberPolicy["WaitingPeriod"]);
                                memberPolicyInfo.AdminFee = Convert.ToDecimal(drMemberPolicy["AdminFee"]);
                                memberPolicyInfo.MonthlyFee = Convert.ToDecimal(drMemberPolicy["MonthlyFee"]);
                                memberPolicyInfo.DateJoined = Convert.ToDateTime(drMemberPolicy["DateJoined"]).ToString("yyyy-MM-dd");
                                memberPolicyInfo.DateActivated = Convert.ToDateTime(drMemberPolicy["DateActivated"]).ToString("yyyy-MM-dd");
                                memberPolicyInfo.NoOfBeneficiaries = Convert.ToInt32(drMemberPolicy["NoOfBeneficiaries"]);
                                memberPolicyInfo.MaximumBeneficiaries = Convert.ToInt32(drMemberPolicy["MaximumBeneficiaries"]);
                            }
                        }
                    }
                }
                return memberPolicyInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Countries> GetCountries()
        {
            try
            {
                DataTable dbResult = new DataTable("countries");
                List<Countries> countryList = new List<Countries>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetAllCountries", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drCountry in dbResult.Rows)
                            {
                                countryList.Add(new Countries()
                                {
                                    Id = Convert.ToInt32(drCountry["ID"]),
                                    Name = drCountry["Name"].ToString(),
                                });
                            }
                        }
                    }
                }
                return countryList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Province> GetProvinces()
        {
            try
            {
                DataTable dbResult = new DataTable("provinces");
                List<Province> provinceList = new List<Province>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetAllProvinces", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drProvince in dbResult.Rows)
                            {
                                provinceList.Add(new Province()
                                {
                                    Id = Convert.ToInt32(drProvince["ID"]),
                                    Name = drProvince["Name"].ToString(),
                                });
                            }
                        }
                    }
                }
                return provinceList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<City> GetCities()
        {
            try
            {
                DataTable dbResult = new DataTable("cities");
                List<City> cityList = new List<City>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetAllCities", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drCity in dbResult.Rows)
                            {
                                cityList.Add(new City()
                                {
                                    Id = Convert.ToInt32(drCity["ID"]),
                                    Name = drCity["Name"].ToString(),
                                });
                            }
                        }
                    }
                }
                return cityList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<City> GetCities(int provinceID)
        {
            try
            {
                DataTable dbResult = new DataTable("cities");
                List<City> cityList = new List<City>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetCities", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@provinceID", SqlDbType.Int).Value = provinceID;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drCity in dbResult.Rows)
                            {
                                cityList.Add(new City()
                                {
                                    Id = Convert.ToInt32(drCity["ID"]),
                                    Name = drCity["Name"].ToString(),
                                });
                            }
                        }
                    }
                }
                return cityList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> Defaulters()
        {
            List<string> nonPaying = new List<string>();

            using (var command = GlobalDataAccess.CreateSpCommand("GetNonPayingMembers", GlobalDataAccess.CreateSqlConnection()))
            {
                using (var reader = GlobalDataAccess.ExecuteReader(command))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            nonPaying.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return nonPaying;
        }
        public int MemberDefaults(string identityNumber)
        {
            int results = 0;

            using (var command = GlobalDataAccess.CreateSpCommand("AddNewDefaulter", GlobalDataAccess.CreateSqlConnection()))
            {
                command.Parameters.Add("@identityNumber", SqlDbType.NVarChar).Value = identityNumber;
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }

                results = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return results;
        }
        public DataTable GetAllChildMembers()
        {
            try
            {
                DataTable dbResult = new DataTable("members");

                using (var command = GlobalDataAccess.CreateSpCommand("GetAllCHILDMembers", GlobalDataAccess.CreateSqlConnection()))
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
        public List<string> GetDocuments()
        {
            try
            {
                DataTable tblResults = new DataTable();
                List<string> result = new List<string>();

                using (var command = GlobalDataAccess.CreateSpCommand("GetAllDocumentTypes", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            tblResults.Load(reader);
                        }

                        foreach (DataRow drDocument in tblResults.Rows)
                        {
                            result.Add(drDocument["DocumentType"].ToString());
                        }
                    }
                }
                   
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetCompanies()
        public List<Branch> GetCompanies(string userId)
        {
            try
            {
                DataTable dbResult = new DataTable("branches");
                List<Branch> branchList = new List<Branch>();

                using (var command = GlobalDataAccess.CreateSpCommand("usp_GetCompanyBranches", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userId;
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {

                            dbResult.Load(reader);
                            foreach (DataRow drBranch in dbResult.Rows)
                            {
                                branchList.Add(new Branch()
                                {
                                    CompanyName = drBranch["CompanyName"].ToString(),
                                    BranchName = drBranch["BranchName"].ToString(),
                                });
                            }
                        }
                    }
                }
                return branchList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Getting Number Count
        public int MembersCoveredCount(string identityNumber)
        {
            try
            {
                DataTable dbResult = new DataTable("members");

                using (var command = GlobalDataAccess.CreateSpCommand("PolicyHolderMemberCount", GlobalDataAccess.CreateSqlConnection()))
                {
                    //command.Parameters.Add("@HolderId", SqlDbType.NVarChar).Value = identityNumber;
                    command.Parameters.Add("@HolderId", SqlDbType.NVarChar).Value = identityNumber;
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
                return dbResult.Rows.Count;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Members> MembersCovered(string identityNumber)
        {

            List<Members> allMembers = new List<Members>();

            try
            {            
               
                    DataTable dbResult = new DataTable("members");

                    using (var command = GlobalDataAccess.CreateSpCommand("GetAllHolderMembers", GlobalDataAccess.CreateSqlConnection()))
                    {
                        using (var reader = GlobalDataAccess.ExecuteReader(command))
                        {
                            if (reader.HasRows)
                            {
                                DataTable tblResults = new DataTable();
                                tblResults.Load(reader);

                            foreach (DataRow drMember in tblResults.Rows)
                            {
                                allMembers.Add(new Members() {
                                    MemberId = Convert.ToInt32(drMember["resellerId"]),
                                    FirstName = drMember["FirstName"].ToString(),
                                    LastName = drMember["LastName"].ToString(),
                                    IdentityNumber = drMember["IdentityNumber"].ToString(),
                                    //BirthDate = Convert.ToDateTime(drMember["BirthDate"]),
                                    //Age = drMember["Age"].ToString(),
                                    //Membership = drMember["MemberType"].ToString(),
                                    //ContactNumber = drMember["ContactNumber"].ToString(),
                                    //ResidentialAddress = drMember["ResidentialAddress"].ToString(),
                                    //PolicyHolder = drMember["PolicyHolder"].ToString(),
                                    //MemberCover = drMember["PolicyName"].ToString(),
                                    //MembershipStatus = drMember["MemberActive"].ToString(),
                                    //StartDate = Convert.ToDateTime(drMember["StartDate"])

                                });
                            }
                            }
                        }
                    }
                    return allMembers;

                }
                catch (Exception ex)
                {
                    throw ex;
                }                
                
        }

        //Add member documents
        //Method used to add required documents for the member covered
        public int AddMemberDocuments(string memberId, int documentId, string documentLocation)
        {
            try
            {
                int results = 0;
                //Openning database connection

                using (var command = GlobalDataAccess.CreateSpCommand("AddMemberDocuments", GlobalDataAccess.CreateSqlConnection()))
                {
                    command.Parameters.Add("@identityNumber,", SqlDbType.NVarChar).Value = memberId;
                    command.Parameters.Add("@documentNumber", SqlDbType.Int).Value = documentId;
                    command.Parameters.Add("@documentLocation", SqlDbType.NVarChar).Value = documentLocation;

                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }

                    results = command.ExecuteNonQuery();

                }    
                
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method used to get the document id of the document Type which is passed as
        //a parameter to the function
        public int GetDocumentID(string document)
        {
            try
            {  
                int documentId = 0;
                string getIdQuery = "select id from documents where documentType = '" + document + "';";

                using (var command = new SqlCommand(getIdQuery))
                {
                    command.Connection = GlobalDataAccess.CreateSqlConnection();
                    command.Connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            documentId = reader.GetInt32(0);
                        }
                    }

                }

                return documentId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method used to get all the documents of a member
        //Documents that are required in every policy
        public string GetMemberDocuments(string memberIdentityNumber, string documentType)
        {
            try
            {

                //using (var command = GlobalDataAccess.CreateSpCommand("", ))
                //{

                //}
                   string documentLocation = "";
                //string connectionString = @"SERVER=localhost; DATABASE=EasyManagerDB; USERNAME=root; Password=sa;";
                //MySqlConnection connection = new MySqlConnection(connectionString);
                //connection.Open();
                //if (connection.State == ConnectionState.Open)
                //{
                //    string query = "select md.documentlocation " +
                //                    "from memberdocuments as md " +
                //                    "inner join documents as d " +
                //                    "on d.id = md.documentid " +
                //                    "where memberIDNumber = '" + memberIdentityNumber + "'  and d.documentType = '" + documentType + " ';";
                //    MySqlCommand command = new MySqlCommand(query, connection);
                //    MySqlDataReader reader = command.ExecuteReader();
                    //if (reader.HasRows)
                    //{
                    //    while (reader.Read())
                    //    {
                    //        documentLocation = @reader.GetString(0);
                    //    }
                    //    reader.Close();
                    //}
                //}
              //  connection.Close();

                return documentLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        

        public List<MemberStatus> MemberStatusList()
        {
            List<MemberStatus> memberStatusList = new List<MemberStatus>();

            try
            {
                DataTable dbResult = new DataTable("members");

                using (var command = GlobalDataAccess.CreateSpCommand("GetMemberStatus", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            DataTable tblResults = new DataTable();
                            tblResults.Load(reader);

                            foreach (DataRow drMemberStatus in tblResults.Rows)
                            {
                                memberStatusList.Add(new MemberStatus() {
                                    Id = Convert.ToInt32(drMemberStatus["Id"]),
                                    MemberActive = drMemberStatus["MemberActive"].ToString()
                                });
                            }

                        }
                    }
                }
                return memberStatusList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return memberStatusList;
        }

        public List<MembershipType> Membermembership()
        {
            List<MembershipType> memberStatusList = new List<MembershipType>();

            try
            {
                DataTable dbResult = new DataTable("members");

                using (var command = GlobalDataAccess.CreateSpCommand("MemberShip", GlobalDataAccess.CreateSqlConnection()))
                {
                    using (var reader = GlobalDataAccess.ExecuteReader(command))
                    {
                        if (reader.HasRows)
                        {
                            DataTable tblResults = new DataTable();
                            tblResults.Load(reader);

                            foreach (DataRow drMemberStatus in tblResults.Rows)
                            {
                                memberStatusList.Add(new MembershipType()
                                {
                                    Id = Convert.ToInt32(drMemberStatus["Id"]),
                                    MemberType = drMemberStatus["MemberType"].ToString()
                                });
                            }

                        }
                    }
                }
                return memberStatusList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return memberStatusList;
        }
    }
}