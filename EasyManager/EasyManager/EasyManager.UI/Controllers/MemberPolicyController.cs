using EasyManagerBLL;
using EasyManagerClasses;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyManager.UI.Controllers
{
    [Authorize]
    public class MemberPolicyController : Controller
    {
        EasyManagerBL bll = new EasyManagerBL();
        string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        // GET: MemberPolicyList
        public ActionResult MemberPolicyList()
        {
            var model = new List<MemberPolicy>();
            model = bll.GetPolicyMembers(UserId);
            ViewBag.Policy = "class = active";
            ViewBag.PoList = "class = active";
            return View(model);
        }

        // GET: Member/MemberPolicyInfo/5
        public ActionResult MemberPolicyInfo(string membershipNo)
        {
            var model = new MemberPolicy();
            model = bll.GetPolicyMemberInfo(membershipNo);
            model.Beneficiaries = bll.GetBeneficiaries(membershipNo);
            model.Benefits = bll.GetMemberBenefits(membershipNo);
            return PartialView("_MemberPolicyListInfoPartial", model);
        }
        //PolicyInfo
        public ActionResult PolicyInfo(int polID)
        {
            var model = new Policy();
            model = bll.GetPolicyInfo(polID);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        // GET: MemberPolicy/MemberPolicyDetails/5
        public ActionResult MemberPolicyDetails(int id)
        {
            return View();
        }

        // GET: MemberPolicy/MemberPolicyCreate
        public ActionResult MemberPolicyCreate()
        {
            InitializeMemberInfo();
            ViewBag.PoCreate = "class = active";
            return View();
        }
        
        // POST: MemberPolicy/MemberPolicyCreate
        [HttpPost]
        public ActionResult MemberPolicyCreate(MemberPolicyCreate collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                return View();
            }
            catch
            {
                
                return View();
            }
        }
        public ActionResult AllocatePolicyToMember(string MemNumber, string PolID, string NoOfBenefic, string AdminFee, string MonthlyFee, string WaitingPeriod, string Benefits )
        {
            try
            {
                int id;
                var model = new MemberPolicyCreate();
                var listBenefits = new List<Benefit>();
                string[] benefits = Benefits.Split(',');
                model.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                model.MembershipNumber = MemNumber;
                model.PolicyID = Convert.ToInt32(PolID);
                model.NoOfBeneficiaries = Convert.ToInt32(NoOfBenefic.Split(' ').First());
                model.AdminFee = Convert.ToInt32(AdminFee);
                model.MonthlyFee = Convert.ToInt32(MonthlyFee);
                model.WaitingPeriod = Convert.ToInt32(WaitingPeriod.Split(' ').First());
                foreach (var item in benefits)
                {
                    if(int.TryParse(item, out id))
                    {
                        listBenefits.Add(new Benefit { BenefitID = id });
                    }
                }
                model.Benefits = listBenefits;
                var result = bll.AllocatePolicyToMember(model);
                InitializeMemberInfo();
                if (result > 0)
                {
                    //success
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                    //fail
                }
                //return View("MemberPolicyCreate");
            }
            catch (Exception ex)
            {
                InitializeMemberInfo();
                return Json(0, JsonRequestBehavior.AllowGet);
                //return View("MemberPolicyCreate");
            }
            
        }
        public ActionResult GetPolicies()
        {

            var model = new List<Policy>();
            model = bll.GetAllPolicies();
            return PartialView("_PolicyList", model);
        }
        // GET: MemberPolicy/MemberPolicyEdit/5
        public ActionResult MemberPolicyEdit(string memNo)
        {
            var model = new MemberPolicyEdit();
            model = bll.GetMemberPolicyToEdit(memNo);
            model.Benefits = bll.GetMemberBenefits(memNo);
            model.MainMembers = bll.GetAllocatedMembers(UserId);
            InitializeMemberPolicyEdit();
            return View(model);
        }

        // POST: MemberPolicy/MemberPolicyEdit/5
        [HttpPost]
        public ActionResult MemberPolicyEdit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //EditPolicyMember
        public ActionResult EditPolicyMember(string MemNumber, string PolID, string NoOfBenefic, string AdminFee, string MonthlyFee, string WaitingPeriod, string Benefits)
        {
            try
            {
                int id;
                var model = new MemberPolicyEdit();
                var listBenefits = new List<Benefit>();
                string[] benefits = Benefits.Split(',');
                model.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                model.MembershipNumber = MemNumber;
                model.PolicyID = Convert.ToInt32(PolID);
                model.NoOfBeneficiaries = Convert.ToInt32(NoOfBenefic.Split(' ').First());
                model.AdminFee = Convert.ToDecimal(AdminFee);
                model.MonthlyFee = Convert.ToDecimal(MonthlyFee);
                model.WaitingPeriod = Convert.ToInt32(WaitingPeriod.Split(' ').First());
                foreach (var item in benefits)
                {
                    if (int.TryParse(item, out id))
                    {
                        listBenefits.Add(new Benefit { BenefitID = id });
                    }
                }
                model.Benefits = listBenefits;
                var result = bll.EditPolicyMember(model);
                InitializeMemberInfo();
                if (result > 0)
                {
                    //success
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                    //fail
                }
            }
            catch (Exception ex)
            {
                InitializeMemberInfo();
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        // GET: MemberPolicy/MemberPolicyDelete/5
        public ActionResult MemberPolicyDelete(int id)
        {
            return View();
        }

        // POST: MemberPolicy/Delete/5
        [HttpPost]
        public ActionResult PolicyMemberDelete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private void InitializeMemberInfo()
        {
            ViewBag.MembershipNumber = bll.GetUnAllocatedMembers(UserId).Select(x => new SelectListItem { Text = x.LastName + " " + x.Initials + " - " + x.MainMemberID  , Value = x.MainMemberID.ToString() }).GroupBy(x => x.Value).Select(g => g.First()).OrderBy(x => x.Text);
            ViewBag.BenefitsList = bll.GetBenefits();
            ViewBag.Policy = "class = active";
        }
        private void InitializeMemberPolicyEdit()
        {
            ViewBag.BenefitsList = bll.GetBenefits();
            ViewBag.Policy = "class = active";
        }
        public ActionResult GetMemberDetails(string membershipNo, string Type)
        {
            if (Type == "1" && membershipNo != "") // create
            {
                var member = bll.GetMainMembers(UserId).Where(m => m.MembershipNumber == membershipNo).ToList(); //get member corresponding to membership number
                var count = bll.GetBeneficiaries(membershipNo).Count();
                member.Add(new Members() { NoOfBeneficiaries = count });
                return Json(member, JsonRequestBehavior.AllowGet);
            }
            else if (Type == "2" && membershipNo != "")// edit
            {
                var memberToEdit = bll.GetMemberPolicyToEdit(membershipNo);
                memberToEdit.Benefits = bll.GetMemberBenefits(membershipNo);
                return Json(memberToEdit, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(0);
        }
    }
}
