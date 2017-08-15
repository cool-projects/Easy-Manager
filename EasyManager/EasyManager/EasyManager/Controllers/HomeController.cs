using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyManagerBLL;
using EasyManagerClasses;

namespace EasyManager.Controllers
{
    public class HomeController : Controller
    {
        //Connection to Business Logic
        EasyManagerBL easyBL = new EasyManagerBL();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Members()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //Get all members
            List<Members> members = new List<Members>();
            members = easyBL.GetAllMembers("");

            List<MemberPolicy> policyMembers = new List<MemberPolicy>();
                        
            //Get all member policies
            foreach (Members member in members)
            {
                Policy memPolicy = new Policy();
                memPolicy = easyBL.GetMemberPolicy(member.MembershipNumber);
                MemberPolicy policyMember = new MemberPolicy();
                //policyMember.Cover = memPolicy.Name;
                //policyMember.EntryDate = member.MembershipStatus;
                //policyMember.FirstName = member.FirstName;
                //policyMember.LastName = member.LastName;
                //policyMember.IdentityNumber = member.IdentityNumber;
                //policyMember.MemberStatus = member.MembershipStatus;
                policyMembers.Add(policyMember);
            }
            ViewBag.Name = members[0].FirstName + " Testing";
            ViewBag.IdNumber = members[0].IdentityNumber;
            //ViewBag.Cell = 
            return View(policyMembers);
        }

        public ActionResult Policy()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Claims()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
