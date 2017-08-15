using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyManagerClasses
{
    public class MemberPolicy
    {
        public int ID { get; set; }
        public int PolicyID { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyName { get; set; }
        public decimal AdminFee { get; set; }
        public decimal MonthlyFee { get; set; }
        public int WaitingPeriod { get; set; }
        public DateTime DateJoined { get; set; }
        public  DateTime DateActivated { get; set; }
        public string MainMemberID { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string MainMemberFullName { get { return FirstName + " " + LastName; } }
        public byte[] ImageFile { get; set; }
        public string MembershipStatus { get; set; }
        public List<Members> Beneficiaries { get; set; }
        public List<Benefit> Benefits { get; set; }
    }

    public class MemberPolicyCreate
    {
        public string UserId { get; set; }
        public string MembershipNumber { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string MainMemberFullName { get { return FirstName + " " + LastName; } }
        public string PolicyNumber { get; set; }
        public decimal AdminFee { get; set; }
        public decimal MonthlyFee { get; set; }
        public int PolicyID { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateActivated { get; set; }
        public int NoOfBeneficiaries { get; set; }
        public int WaitingPeriod { get; set; }
        public List<Benefit> Benefits { get; set; }
    }
    public class MemberPolicyEdit
    {
        public string UserId { get; set; }
        public int MemberPolicyID { get; set; }
        public string MembershipNumber { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string MainMemberFullName { get { return FirstName + " " + LastName; } }
        public string PolicyNumber { get; set; }
        public string PolicyName { get; set; }
        public int WaitingPeriod { get; set; }
        public string PolicyDescription { get; set; }
        public decimal AdminFee { get; set; }
        public decimal MonthlyFee { get; set; }
        public int PolicyID { get; set; }
        public string DateJoined { get; set; }
        public string DateActivated { get; set; }
        public int NoOfBeneficiaries { get; set; }
        public int MaximumBeneficiaries { get; set; }
        public List<Benefit> Benefits { get; set; }
        public List<Members> MainMembers { get; set; }
    }
}
