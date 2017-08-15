using EasyManagerBLL;
using EasyManagerClasses;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyManager.UI.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        EasyManagerBL bll = new EasyManagerBL();
        string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        // GET: Member/MemberList
        [HttpGet]
        public ActionResult MemberList()
        {
            
            var model = new List<Members>();
            model = bll.GetAllMembers(UserId);
            ViewBag.Member = "class = active";
            ViewBag.MList = "class = active";
            return View(model);
        }
        // GET: Member/MemberInfo/5
        public ActionResult MemberInfo(int ID, int Type)
        {
            var model = new Members();
            if(Type == 1) //memberList
            {
                model = bll.GetMemberInfo(ID);
                return PartialView("_MemberListInfoPartial", model);
            }
            else //memberDetails
            {
                model = bll.GetMemberInfo(ID);
                return PartialView("_MemberDetailsInfoPartial", model);
            }
        }
        // GET: Member/MemberDetails/5
        public ActionResult MemberDetails(int ID, string MainM_ID)
        {
            var model = new List<Members>();//may need to use ID and create a new StoredProc
            ViewBag.Member = "class = active";
            if (ID == -1) //for updating contacts fields
            {
                model = bll.GetAllMembers(UserId).Where(x => x.MembershipNumber == MainM_ID).ToList();
                return Json(model, JsonRequestBehavior.AllowGet);
            } 
            else
            {
                model = bll.GetAllMembers(UserId).Where(x => x.MainMemberID == MainM_ID).ToList();
                return View(model);
            }
        }
        // GET: Member/MemberCreate
        public ActionResult MemberCreate()
        {
            InitializeMemberPage();
            ViewBag.MCreate = "class = active";
            return View();
        }

        // POST: Member/MemberCreate
        [HttpPost]
        public ActionResult MemberCreate(MemberCreate collection, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    collection.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    // TODO: Add insert logic here
                    Image img = Image.FromFile(Server.MapPath(@"~\Images\default.png"));
                    if (file == null)
                        collection.ImageFilename = "default.png";
                    else
                        collection.ImageFilename = file.FileName;
                    collection.ImageFile = bll.ImageProcessor(file, img);
                    int result = bll.AddNewMember(collection);
                    if(result > 0)
                    {
                        InitializeMemberPage();
                        ViewBag.IsSaved = "create";
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        InitializeMemberPage();
                        ViewBag.IsSaved = "duplicate";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    InitializeMemberPage();
                    ViewBag.IsSaved = "fail";
                    return View();
                }
            }
            else
            {
                InitializeMemberPage();
                ViewBag.IsSaved = "fail";
                return View();
            }
           
        }
        //GetProvinces
        public ActionResult GetCities(string provinceId)
        {
            if(provinceId == "")
            {
                var cityList = bll.GetCities(); //get list of all cities
                return Json(cityList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var cityList = bll.GetCities(Convert.ToInt32(provinceId)); //get list of cities in provinces 
                return Json(cityList, JsonRequestBehavior.AllowGet);
            }
        }
        private void InitializeMemberPage()
        {
            ViewBag.MainMemberID = bll.GetMainMembers(UserId).Select(x => new SelectListItem { Text = x.MainMemberID + " (" + x.LastName + " " + x.Initials + ")", Value = x.MainMemberID.ToString() }).GroupBy(x => x.Value).Select(g => g.First()).OrderBy(x => x.Text);
            ViewBag.Nationality = bll.GetCountries().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.City = bll.GetCities().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text);
            ViewBag.Province = bll.GetProvinces().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Member = "class = active";
            
        }
        
        // GET: Member/MemberEdit/5
        public ActionResult MemberEdit(int ID)
        {
            var model = new MemberToEdit();
            model = bll.GetMemberToEdit(ID);
            InitializeEditMemberPage(model);
            ViewBag.MEdit = "class = active";
            return View(model);
        }
        private void InitializeEditMemberPage(MemberToEdit model)
        {
            
            //MainMemberID = bll.GetAllMembers().Where(m => m.MembershipNumber == m.MainMemberID).Select(x => new SelectListItem { Text = x.MainMemberID + " (" + x.LastName + " " + x.Initials + ")", Value = x.MainMemberID.ToString() }).GroupBy(x => x.Value).Select(g => g.First()).OrderBy(x => x.Text);
            ViewBag.MainMemberID = new SelectList(bll.GetMainMembers(UserId), "MainMemberID", "MainMemberID", model.MainMemberID);
            ViewBag.Nationality = new SelectList(bll.GetCountries(), "Id", "Name", model.Nationality);
            ViewBag.City = new SelectList(bll.GetCities(), "Id", "Name", model.City);
            ViewBag.Province = new SelectList(bll.GetProvinces(), "Id", "Name", model.Province);
            ViewBag.Member = "class = active";
        }
        // POST: Member/MemberEdit/5
        [HttpPost]
        public ActionResult MemberEdit(MemberToEdit collection, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    collection.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    // TODO: Add insert logic here
                    Image img = Image.FromFile(Server.MapPath(@"~\Images\default.png"));
                    if (file == null)
                        collection.ImageFilename = "default.png";
                    else
                        collection.ImageFilename = file.FileName;
                    collection.ImageFile = bll.ImageProcessor(file, img);
                    int result = bll.EditMember(collection);
                    var model = new MemberToEdit();
                    model = bll.GetMemberToEdit(collection.MemberId);
                    InitializeEditMemberPage(model);
                    ViewBag.MEdit = "class = active";
                    if (result > 0)
                        ViewBag.IsSaved = "update";
                    else
                        ViewBag.IsSaved = "fail";
                    return View(model);
                }
                catch (Exception ex)
                {
                    var model = new MemberToEdit();
                    model = bll.GetMemberToEdit(collection.MemberId);
                    InitializeEditMemberPage(model);
                    ViewBag.MEdit = "class = active";
                    ViewBag.IsSaved = "fail";
                    return View(model);
                }
            }
            else
            {
                var model = new MemberToEdit();
                model = bll.GetMemberToEdit(collection.MemberId);
                InitializeEditMemberPage(model);
                ViewBag.MEdit = "class = active";
                return View(model);
            }
            
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
