using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyManagerClasses
{
    public class Claim
    {
        public string ClaimId { get; set; }
        public string MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }
    }
}
