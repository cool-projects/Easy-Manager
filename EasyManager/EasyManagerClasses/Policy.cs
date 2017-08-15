using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyManagerClasses
{
    public class Policy
    {
        public int ID { get; set; }
        public int PolicyID { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        //public decimal MonthlyFee { get; set; }
        public int WaitingPeriod { get; set; }
        public int MaximumBeneficiaries { get; set; }
    }
}
