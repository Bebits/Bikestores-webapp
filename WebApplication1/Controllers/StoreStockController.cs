using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL.IService;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class StoreStockController : Controller
    {
            
        private readonly IBikeService services;
        public StoreStockController(IBikeService _services)
        {
            services = _services;
        }
        //GET: StoreStock
        public ActionResult StoreStock(StoreStocksModel model)
        {
            //get storestore list
            var data = services.GetStoreStocksList(model);
            //var data = services.GetProductList(model);

            return View(data);
        }
        public ActionResult Create(StoreStocksModel model)
        {

            //ModelState.Clear();

            //var data = services.GetStocksList(model);
            return View(model);
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Creates(StoreStocksModel model)
        {
            if (ModelState.IsValid)
            {
                services.AddStoreStockList(model);
                return RedirectToAction("StoreStock",new { model.StoreId });

            }
            return View("Create", model);

        }
        public ActionResult Delete(int Id, int pId)
        {
            services.Delete(Id, pId);
            return RedirectToAction("StoreStock", new { StoreId=Id });
        }

        public ActionResult EditStock(StoreStocksModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Edits(StoreStocksModel model)
        {
            services.EditStock(model);
            return RedirectToAction("StoreStock", new { model.StoreId });
        }

    }



}