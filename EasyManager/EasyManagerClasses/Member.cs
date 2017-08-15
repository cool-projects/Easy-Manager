using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace EasyManagerClasses
{
    public class Members
    {
        public int MemberId { get; set; }
        public string MembershipNumber { get; set; }
        public string MainMemberID { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string KnownAs { get; set; }
        public string LastName { get; set; }
        public string MemberFullName { get { return Initials + " " + LastName; } }
        public string MemberFullNameAndID { get { return LastName + " " + Initials + " - "+ MembershipNumber; } }
        public string Gender { get; set; }
        public string IdentityNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string Nationality { get; set; }
        public string MembershipType { get; set; }
        public string MembershipStatus { get; set; }
        public string ImageFilename { get; set; }
        public byte[] ImageFile { get; set; }
        public string Cellphone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Address { get { return AddressLine1 + " " + Environment.NewLine + AddressLine2; } }
        public string Province { get; set; }
        public string City { get; set; }
        public string ProvinceID { get; set; }
        public string CityID { get; set; }
        public int NoOfBeneficiaries { get; set; }
    }

    public class MemberCreate
    {
        public int MemberId { get; set; }
        public string UserId { get; set; }
        public string MembershipNumber { get; set; }
        public string MainMemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string KnownAs { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Title { get; set; }
        [Required]
        public int Nationality { get; set; }
        [Required]
        public int MembershipType { get; set; }
        [Required]
        public int MembershipStatus { get; set; }
        public string ImageFilename { get; set; }
        public byte[] ImageFile { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{10})\)?$", ErrorMessage = "The Cellphone number is not a valid contact number")]
        public string Cellphone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int Province { get; set; }
        public int City { get; set; }
    }

    public class MemberToEdit
    {
        public int MemberId { get; set; }
        public string UserId { get; set; }
        [Required]
        public string MembershipNumber { get; set; }
        public string MainMemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string KnownAs { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public int Title { get; set; }
        [Required]
        public int Nationality { get; set; }
        [Required]
        public int MembershipType { get; set; }
        [Required]
        public int MembershipStatus { get; set; }
        public string ImageFilename { get; set; }
        public byte[] ImageFile { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{10})\)?$", ErrorMessage = "The Cellphone number is not a valid contact number")]
        public string Cellphone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int Province { get; set; }
        public int City { get; set; }
    }
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Company
    {
        public List<Branch> BranchList { get; set; }
    }
    public class Branch
    {
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
    }
}
