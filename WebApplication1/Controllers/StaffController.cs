using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL.IService;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class StaffController : Controller
    {
        private readonly IBikeService services;
        public StaffController(IBikeService _services)
        {
            services = _services;
        }
       //show all staffs
        public ActionResult Staffs()
        {
            //get store list
            List<StaffModel> staffList = services.GetStaffList();
            return View(staffList);
        }
        // GET: Staff
        public ActionResult Add()
        {
            return View();
        }
        // POST: ADDDetails
        [HttpPost]
        public ActionResult Add(StaffModel model)
        {
            if (ModelState.IsValid)
            {
                services.AddStaff(model);
                return RedirectToAction("Index");

            }
            return View("CreateDetails", model);

        }



    }
}