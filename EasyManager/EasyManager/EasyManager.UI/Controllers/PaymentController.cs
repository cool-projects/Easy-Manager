using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyManager.UI.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentList()
        {
            ViewBag.Payment = "class = active";
            ViewBag.PList = "class = active";
            return View();
        }

        // GET: Payment/PaymentDetails/5
        public ActionResult PaymentDetails(int id)
        {
            return View();
        }

        // GET: Payment/PaymentCreate
        public ActionResult PaymentCreate()
        {
            ViewBag.Payment = "class = active";
            ViewBag.PCreate = "class = active";
            return View();
        }

        // POST: Payment/PaymentCreate
        [HttpPost]
        public ActionResult PaymentCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                ViewBag.Payment = "class = active";
                ViewBag.PCreate = "class = active";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/PaymentEdit/5
        public ActionResult PaymentEdit(int id)
        {
            ViewBag.Payment = "class = active";
            return View();
        }

        // POST: Payment/Edit/5
        [HttpPost]
        public ActionResult PaymentEdit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                ViewBag.Payment = "class = active";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payment/Delete/5
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
