using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL.IService;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
   [Authorize]
    public class StoreController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;

        //public StoreController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        private readonly IBikeService services;
        public StoreController(IBikeService _services)
        {
            services = _services;
        }
        // GET: Bike
        public ActionResult Index()
        {
            //get store list
            List<StoreModel> storeList = services.GetStoreList();
            return View(storeList);
        }

        // GET: Bike/Details/5
        public ActionResult CreateDetails(string StoreName)
        {
            //ModelState.Clear();
            StoreModel model = new StoreModel();
            return View(model);
        }
        // POST: ADDDetails
        [HttpPost]
        public ActionResult Add(StoreModel model)
        {
           var ssid= User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                services.AddStoreList(model);
                return RedirectToAction("Index");

            }
            return View("CreateDetails", model);
            
        }

        public ActionResult Delete(int? id)
        {
            services.DeleteDetails(id);
            return RedirectToAction("Index");
        }
        //edit
        public ActionResult Edit(StoreModel model)
        {
            return View(model);
        }

        [HttpPost , ActionName("Edit")]
        public ActionResult Edits(StoreModel model)
        {
            services.Edit(model);
            return RedirectToAction("Index");
        }

    }
}


