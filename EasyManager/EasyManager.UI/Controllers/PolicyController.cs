using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyManager.UI.Controllers
{
    [Authorize]
    public class PolicyController : Controller
    {
        // GET: PolicyList
        public ActionResult PolicyList()
        {
            return View();
        }

        // GET: Policy/PolicyDetails/5
        public ActionResult PolicyDetails(int id)
        {
            return View();
        }

        // GET: Policy/PolicyCreate
        public ActionResult PolicyCreate()
        {
            return View();
        }

        // POST: Policy/PolicyCreate
        [HttpPost]
        public ActionResult PolicyCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Policy/PolicyEdit/5
        public ActionResult PolicyEdit(int id)
        {
            return View();
        }

        // POST: Policy/PolicyEdit/5
        [HttpPost]
        public ActionResult PolicyEdit(int id, FormCollection collection)
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

        // GET: Policy/PolicyDelete/5
        public ActionResult PolicyDelete(int id)
        {
            return View();
        }

        // POST: Policy/PolicyDelete/5
        [HttpPost]
        public ActionResult PolicyDelete(int id, FormCollection collection)
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
