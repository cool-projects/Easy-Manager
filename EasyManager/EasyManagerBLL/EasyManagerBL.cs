using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyManagerDLL;
using EasyManagerClasses;
using System.Data;
using System.Web;
using System.Drawing;
using System.IO;
using ImageResizer;

namespace EasyManagerBLL
{
    public class EasyManagerBL
    {
        //EmployeeOperation employee = new EmployeeOperation();
        PolicyOperations policy = new PolicyOperations();
        MembersOperations memberOperations = new MembersOperations();
        PaymentOperations paymentOperations = new PaymentOperations();
        //adding employees
        //public int AddEmployee(string employeeName, string surname, string identityNumber, string residentialAddress,
        //                string contactNumber, string userName, string password, bool active, string position)
        //{
        //    try
        //    {
        //        int results = 0;                
        //        results = employee.AddEmployee(employeeName, surname, identityNumber, residentialAddress,
        //                contactNumber, userName, password, active, position);
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //Updating employees
        //public int UpdateEmployee(int id, string employeeName, string surname, string identityNumber, string residentialAddress,
        //                string contactNumber, string userName, string password, bool active, string position)
        //{
        //    try
        //    {
        //        int results = 0;
        //        results = employee.UpdateEmployee(id, employeeName, surname, identityNumber, residentialAddress,
        //            contactNumber, userName, password, active, position);
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //Getting all employees
        //public List<Employee> GetEmployees()
        //{
        //    try
        //    {
        //        List<Employee> AllEmployees = new List<Employee>();
        //        AllEmployees = employee.GetEmployees();
        //        return AllEmployees;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //Deleting employees
        //public int DeleteEmployee(int id, string identityNumber, bool active = false)
        //{
        //    try
        //    {
        //        int results = 0;
        //        results = employee.DeleteEmployee(id, identityNumber, active);
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<SimpleStatistics> GetSimpleStats(string userID)
        {
            try
            {
                return memberOperations.GetSimpleStats(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Image processing
        public byte[] ImageProcessor(HttpPostedFileBase file, Image img)
        {
            //create byte array
            if (file != null)
            {
                //convert file to image
                Image sourceimage = Image.FromStream(file.InputStream);
                using (var newImage = ScaleImage(sourceimage, 100, 100))
                {
                    MemoryStream ms = new MemoryStream();
                    newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            else
            {
                using (var newImage = ScaleImage(img, 100, 100))
                {
                    MemoryStream ms = new MemoryStream();
                    newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
        //getting all schemes
        public List<Policy> GetAllPolicies()
        {
            List<Policy> allPolicies = new List<Policy>();
            try
            {

                EasyManagerBL easyManagerBl = new EasyManagerBL();
                allPolicies = policy.GetAllPolicies();
                return allPolicies;
            }
            catch (Exception)
            {
                //throw ex;
            }
            return allPolicies;
        }
        
        public List<MemberStatus> MemberStatus()
        {
            try
            {
                return memberOperations.MemberStatusList();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        //Getting all members 
        public List<Members> GetAllMembers(string UserId)
        {
            try
            {
                return memberOperations.GetAllMembers(UserId);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        //GetMainMembers
        public List<Members> GetMainMembers(string UserId)
        {
            try
            {
                return memberOperations.GetMainMembers(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetAllocatedMembers
        public List<Members> GetAllocatedMembers(string UserId)
        {
            try
            {
                return memberOperations.GetAllocatedMembers(UserId);
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
                return memberOperations.GetUnAllocatedMembers(UserId);
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
                return memberOperations.GetMemberInfo(id);
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
                return memberOperations.GetMemberToEdit(id);
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
                return memberOperations.GetMemberPolicyToEdit(memNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get all Countries
        public List<Countries> GetCountries()
        {
            try
            {
                return memberOperations.GetCountries();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetProvinces
        public List<Province> GetProvinces()
        {
            try
            {
                return memberOperations.GetProvinces();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetCities
        public List<City> GetCities()
        {
            try
            {
                return memberOperations.GetCities();
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
                return memberOperations.GetCities(provinceID);
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
                return memberOperations.GetCompanies(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataTable GetAllMAINMembers()
        //{
        //    try
        //    {
        //        DataTable members = new DataTable();
        //        members = memberOperations.GetAllMainMembers();
        //        return members;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable GetAllCHILDMembers()
        {
            try
            {
                DataTable members = new DataTable();
                members = memberOperations.GetAllChildMembers();
                return members;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //MemberPolicies
        public List<MemberPolicy> GetPolicyMembers(string UserId)
        {
            try
            {
                return memberOperations.GetPolicyMembers(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MemberPolicy GetPolicyMemberInfo(string membershipNo)
        {
            try
            {
                return memberOperations.GetPolicyMemberInfo(membershipNo);
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
                return memberOperations.GetBeneficiaries(membershipNo);
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
                return memberOperations.GetPolicyInfo(polID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MembershipType> Membermembership()
        {
            try
            {
                return memberOperations.Membermembership();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Getting members for a policy
        //public DataTable GetPolicyMembers(string policy)
        //{
        //    try
        //    {
        //        DataTable policyMembers = new DataTable("policymembers");
        //        policyMembers = memberOperations.GetPolicyMembers(policy);
        //        return policyMembers;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //Getting all policy Names
        //public List<string> PolicyNames()
        //{
        //    try
        //    {
        //        List<string> allPolicyNames = new List<string>();
        //        allPolicyNames = memberOperations.PolicyNames();
        //        return allPolicyNames;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //Adding Policy Member
        public int AddNewMember(MemberCreate member)
        {
            try
            {
                int results = 0;
                results = memberOperations.AddMember(member);
                return results;
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
                int results = 0;
                results = memberOperations.EditMember(member);
                return results;
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
                int results = 0;
                results = memberOperations.AllocatePolicyToMember(member);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //EditPolicyMember
        public int EditPolicyMember(MemberPolicyEdit member)
        {
            try
            {
                int results = 0;
                results = memberOperations.EditPolicyMember(member);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GetBenefits
        public List<Benefit> GetBenefits()
        {
            try
            {
                return memberOperations.GetBenefits();
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
                return memberOperations.GetMemberBenefits(memNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Updating member policy type
        //public int UpdateMemberPolicyType(int memberId, string memberIdNumber, string newPolicy)
        //{
        //    try
        //    {
        //        int results = 0;
        //        results = memberOperations.UpdateMemberPolicyType(memberId, memberIdNumber, newPolicy);
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //Getting required documents
        public List<string> RequiredDocuments()
        {
            try
            {
                List<string> documents = new List<string>();
                documents = memberOperations.GetDocuments();
                return documents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Checking number members covered by main member
        public int MembersCoveredCount(string identityNumber)
        {
            try
            {
                int results = 0;
                results = memberOperations.MembersCoveredCount(identityNumber);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Getting the maximum number of members currently 
        //covered by a policy
        //public int GetMaximumMembers(string policy)
        //{
        //    try
        //    {
        //        int results = 0;
        //        results = memberOperations.GetMaximumMembers(policy);
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //Getting all the Beneficiaries covered in a policy
        public List<Members> MembersCovered(string identityNumber)
        {
            try
            {
                List<Members> allMembers = new List<Members>();
                allMembers = memberOperations.MembersCovered(identityNumber);
                return allMembers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Updating Member Details
        //public int UpdateMemberDetails(MemberPolicy member)
        //{
        //    try
        //    {
        //        int results = 0;
        //        results = memberOperations.UpdateMemberDetails(member);
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //Getting PolicyId
        //public int GetPolicyId(string policyName)
        //{
        //    try
        //    {
        //        PolicyOperations policyOps = new PolicyOperations();
        //        int policyId = 0;
        //        policyId = policyOps.GetPolicyId(policyName);
        //        return policyId;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //Updating policy members policies
        //public int UpdatePolicyMembers(List<Members> memberList, int policyId)
        //{
        //    try
        //    {
        //        int resuls = 0;
        //        PolicyOperations policyOps = new PolicyOperations();
        //        resuls = policyOps.UpdatePolicyMembers(memberList, policyId);
        //        return resuls;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //Add member documents
        //Method used to add required documents for the member covered
        public int AddMemberDocuments(string memberId, int documentName, string documentLocation)
        {
            try
            {
                int results = 0;
                results = memberOperations.AddMemberDocuments(memberId, documentName, documentLocation);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method to get the id of the document currently selected
        public int GetDocumentId(string document)
        {
            try
            {
                int documentid = 0;
                documentid = memberOperations.GetDocumentID(document);
                return documentid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method used to get the member documents
        public string GetMemberDocuments(string memberIdNumber, string documentType)
        {
            try
            {
                string documentLocation = "";
                documentLocation = memberOperations.GetMemberDocuments(memberIdNumber, documentType);
                return documentLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method to process member payment
        public int UpdatePayment(string IdNumber, int Policy, decimal
           amount)
        {
            try
            {
                int results = 0;
                results = paymentOperations.UpdatePayment(IdNumber, Policy, amount);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Policy GetMemberPolicy(string memberIdNumber)
        {
            try
            {
                Policy policyType = new Policy();
                policyType = memberOperations.GetMemberPolicy(memberIdNumber);
                return policyType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetMemberPayments(string memberIdNumber)
        {
            DataTable memberPayments = new DataTable();
            try
            {
                memberPayments = paymentOperations.GetMemberPayments(memberIdNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return memberPayments;
        }

        public DataTable GetAllPayments()
        {
            DataTable allmembersPayments = new DataTable();
            try
            {
                allmembersPayments = paymentOperations.GetAllPayments();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allmembersPayments;
        }
    }
}
