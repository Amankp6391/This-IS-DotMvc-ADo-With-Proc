using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrudWithAdo.Models;
using MvcCrudWithAdo.Service;

namespace MvcCrudWithAdo.Controllers
{
    public class UserController : Controller
    {
        UserDAL userDAL = new UserDAL();
        // GET: User
        public ActionResult List()
        {
            var data = userDAL.GetUsers();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if (userDAL.InsertUser(user))
            {
                TempData["InsertErrorMsg"] = "<script>alert('User save Successfully')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "<script>alert('Data not save')</script>";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var data = userDAL.GetUsers().Find(a => a.Id == id);
            return View(data);
        }


        public ActionResult Edit(int id)
        {
            var data = userDAL.GetUsers().Find(a => a.Id == id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            if (userDAL.UpdateUser(user))
            {
                TempData["UpdateErrorMsg"] = "<script>alert('User update Successfully')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "<script>alert('Data not update')</script>";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            int r = userDAL.DeleteUser(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('User delete Successfully')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["deleteErrorMsg"] = "<script>alert('Data not delete')</script>";
            }
            return View();
        }


    }
}
