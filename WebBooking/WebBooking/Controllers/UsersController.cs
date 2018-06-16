using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBooking.Business;
using WebBooking.Models.DataModel;

namespace WebBooking.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        private UsersBusiness db = new UsersBusiness();
        public ActionResult Index()
        {

            return View(db.GetUsers());
        }

        // GET: Users/Details/5
        public ActionResult Details(int ? id)
        {
            
            if (id == null)
            {
                ModelState.AddModelError("", "ID null ?");
            }
            return View(db.GetUsers().FirstOrDefault(t => t.ID == id));

        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UsersModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    bool Result = db.CreateUser(model);
                    if (Result == true)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Insert Data Error");
                        return View();
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Error"+ex);
                }
            }
            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsersModel model)
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

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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
