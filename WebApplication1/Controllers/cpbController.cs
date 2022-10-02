using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL.IService;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class cpbController : Controller
    {
        private readonly IBikeService services;
        public cpbController(IBikeService _services)
        {
            services = _services;
        }
        // GET: cpb
        public ActionResult Index(cpbModel model)
        {
            List<cpbModel> cpbList = services.GetcpbList();
            return View(cpbList);
        }
        // GET: Staff
        public ActionResult Add()
        {
            return View();
        }
        // POST: ADDDetails
        [HttpPost]
        public ActionResult Add(cpbModel model)
        {
                services.AddcpbList(model);
            return RedirectToAction("Add");
            //return RedirectToAction("Index");
            //return View("Index", model);

        }
        public ActionResult CpbDelete(int bId, int pId, int cId)
        {
            services.cpbDelete(bId, pId, cId);
            return RedirectToAction("Index", new { BrandId = bId });
        }

        //public ActionResult CategoryDetails(CategoryModel model)
        //{
        //    List<CategoryModel> cList = services.GetCategoryList();
        //    return View(cList);
        //}
       
        public ActionResult ProductDetails(ProductModel model)
        {
            List<ProductModel> pList = services.GetProductList();
            return View(pList);
        }
        public ActionResult CategoryDetails(CategoryModel model)
        {
            List<CategoryModel> cList = services.GetCategoryList();
            return View(cList);
        }
        public ActionResult BrandDetails(BrandsModel model)
        {
            List<BrandsModel> bList = services.GetBrandList();
            return View(bList);
        }
        public ActionResult Deletecpb(DeleteModel delete)
        {
            services.dataDelete(delete);
            return RedirectToAction("Index");
        }

    }
}