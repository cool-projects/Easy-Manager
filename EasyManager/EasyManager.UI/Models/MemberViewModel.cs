using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyManager.UI.Models
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public string MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string KnownAs { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; }
        public string Nationality { get; set; }
        public string MemberType { get; set; }
        public string MemberStatus { get; set; }
    }
}