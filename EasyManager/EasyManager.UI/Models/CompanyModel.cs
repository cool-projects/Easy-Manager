using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyManager.UI.Models
{
    public class CompanyModel
    {
        public List<Branch> BranchList { get; set; }
    }
    public class Branch
    {
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
    }
}