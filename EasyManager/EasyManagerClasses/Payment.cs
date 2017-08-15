using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyManagerClasses
{
    public class Payment
    {
        public int ID { get; set; }
        public string MemberIdNumber { get; set; }
        public string policy { get; set; }
        public decimal Amount { get; set; }
        public string datePayed { get; set; }
    }
}
