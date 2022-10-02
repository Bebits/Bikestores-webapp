using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.BAL.IService;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using Microsoft.AspNet.Identity;

namespace WebApplication1.BAL.Service
{
    public class Bike : IBikeService
    {
        BikeStoresEntities bikeStoresDb = new BikeStoresEntities();
        public List<StoreModel> GetStoreList()
        {
            //using (bikeStoresDb = new BikeStoresEntities())
            //    {
            List<StoreModel> storeList = (from b in bikeStoresDb.Stores
                                          select new StoreModel
                                          {
                                              StoreId = b.store_id,
                                              StoreName = b.store_name,
                                              Phone = b.phone,
                                              Email = b.email,
                                              Street = b.street,
                                              City = b.street,
                                              State = b.state,
                                              ZipCode = b.zip_code,
                                              CreatedBy =b.CreatedBy,
                                              Created_Date = b.Created_Date,
                                              ModifiedBy = b.ModifiedBy,
                                              ModifiedDate = b.ModifiedDate
                                          }).ToList();

            return storeList;
        }
        public void AddStoreList(StoreModel model)
        {
            Store model2 = new Store();
            model2.store_name = model.StoreName;
            model2.email = model.Email;
            model2.phone = model.Phone;
            model2.city = model.City;
            model2.state = model.State;
            model2.street = model.Street;
            model2.zip_code = model.ZipCode;
            model2.Created_Date = DateTime.Now;
            //model2.CreatedBy =
          
            //model2.CreatedBy = System.Web.HttpContext.Current.User.Identity.Name();

            bikeStoresDb.Stores.Add(model2);
            bikeStoresDb.SaveChanges();
        }

        public void DeleteDetails(int? id)
        {
            var data = bikeStoresDb.Stores.Where(x => x.store_id == id).FirstOrDefault();
            bikeStoresDb.Stores.Remove(data);
            bikeStoresDb.SaveChanges();

        }
        public void Edit(StoreModel model)
        {
            var data = bikeStoresDb.Stores.Where(x => x.store_id == model.StoreId).FirstOrDefault();
            if (data != null)
            {
                data.store_id = model.StoreId;
                data.store_name = model.StoreName;
                data.email = model.Email;
                data.phone = model.Phone;
                data.city = model.City;
                data.state = model.State;
                data.street = model.Street;
                data.zip_code = model.ZipCode;
                data.ModifiedDate = DateTime.Now;
                //data.ModifiedBy = AspNetUsers.Identity.GetUserId();
              
                bikeStoresDb.SaveChanges();
            }
        }
        public List<StoreStocksModel> GetStoreStocksList(StoreStocksModel model)
        {

            List<StoreStocksModel> stockstoreList = (from b in bikeStoresDb.Stocks join s in bikeStoresDb.Products
                                                     on b.product_id equals s.product_id
                                                     //from stockproduct in e.DefaultIfEmpty()
                                                     where b.store_id == model.StoreId
                                                     select new StoreStocksModel
                                                     {
                                                         StoreId = b.store_id,
                                                         ProductId = b.product_id,
                                                         ProductName = s.product_name,
                                                         quantity = b.quantity
                                                     }).ToList();
            return stockstoreList;


        }
        //public List<StoreStocksModel> GetStocksList(StoreStocksModel model)
        //{
        //    List<StoreStocksModel> stocksList = (from b in bikeStoresDb.Stocks
        //                                             where b.store_id == model.StoreId

        //                                             select new StoreStocksModel
        //                                             {
        //                                                 StoreId = b.store_id,
        //                                                 ProductId = b.product_id,
        //                                                 quantity = b.quantity
        //                                             }).ToList();
        //    return stocksList;
        //}
        public void AddStoreStockList(StoreStocksModel model)
        {
            //Store _store = new Store();
            //_store.store_id = model.StoreId;
            //_sto
            //bikeStoresDb.Stores.Add(_store);
            //bikeStoresDb.SaveChanges();

            Stock _stock = new Stock();
            _stock.store_id = model.StoreId;
            _stock.product_id = model.ProductId;
            _stock.quantity = model.quantity;
            bikeStoresDb.Stocks.Add(_stock);

            bikeStoresDb.SaveChanges();
        }
        public void Delete(int Id, int pId)
        {
            var data = bikeStoresDb.Stocks.Where(x => x.store_id == Id && x.product_id == pId).FirstOrDefault();
            bikeStoresDb.Stocks.Remove(data);
            bikeStoresDb.SaveChanges();
        }
        public void EditStock(StoreStocksModel model)
        {
            var data = bikeStoresDb.Stocks.Where(x => x.store_id == model.StoreId && x.product_id == model.ProductId).FirstOrDefault();
            if (data != null)
            {
                data.store_id = model.StoreId;
                data.product_id = model.ProductId;
                data.quantity = model.quantity;
                bikeStoresDb.SaveChanges();
            }
        }
        public List<ProductModel> GetProductList(StoreStocksModel stocks)
        {
            List<ProductModel> productList = new List<ProductModel>
                (
                from s in bikeStoresDb.Stocks
                join p in bikeStoresDb.Products
                on s.product_id equals p.product_id into e
                from stockproduct in e.DefaultIfEmpty()
                where s.product_id == stocks.ProductId
                select new ProductModel
                {
                    ProductId = s.product_id,
                    ProductName = stockproduct.product_name
                }).ToList();
            return productList;
        }
        //Saffs
        public List<StaffModel> GetStaffList()
        {
            List<StaffModel> staffList = (from s in bikeStoresDb.Staffs
                                          select new StaffModel
                                          {
                                              staff_id = s.staff_id,
                                              first_name = s.first_name,
                                              last_name = s.last_name,
                                              email = s.email,
                                              phone = s.phone,
                                              active = s.active,
                                              store_id = s.store_id,
                                              manager_id = s.manager_id
                                              //quantity = ssdetails.quantity
                                          }).ToList();

            return staffList;
        }
        public void AddStaff(StaffModel model)
        {
            Staff model2 = new Staff();
            model2.first_name = model.first_name;
            model2.email = model.email;
            model2.phone = model.phone;


            bikeStoresDb.Staffs.Add(model2);


            bikeStoresDb.SaveChanges();
        }
        public List<cpbModel> GetcpbList()
        {
            List<cpbModel> cpbList = (from p in bikeStoresDb.Products
                                      join c in bikeStoresDb.Categories
                                      on p.category_id equals c.category_id
                                      join b in bikeStoresDb.Brands
                                      on p.brand_id equals b.brand_id
                                      select new cpbModel
                                      {
                                          CategoryName = c.category_name,
                                          CategoryId = c.category_id,
                                          ProductName = p.product_name,
                                          BrandName = p.product_name,
                                          BrandId = p.brand_id,
                                          ModelYear = p.model_year,
                                          ProductId = p.product_id,
                                          ListPrice = p.list_price


                                      }).ToList();

            return cpbList;
        }
        public void AddcpbList(cpbModel model)
        {
            using (var bikeStoresDb = new BikeStoresEntities())
            {
                using (var transaction = bikeStoresDb.Database.BeginTransaction())
                    try
                    {
                        Brand _brand = new Brand();
                        _brand.brand_id = model.BrandId;
                        _brand.brand_name = model.BrandName;
                        bikeStoresDb.Brands.Add(_brand);
                        //bikeStoresDb.SaveChanges();

                        Category _category = new Category();
                        _category.category_id = model.CategoryId;
                        _category.category_name = model.CategoryName;
                        bikeStoresDb.Categories.Add(_category);
                        //bikeStoresDb.SaveChanges();

                        int latestCid = _category.category_id;
                        int latestBid = _brand.brand_id;

                        Product _product = new Product();
                        _product.product_id = model.ProductId;
                        _product.product_name = model.ProductName;
                        _product.model_year = model.ModelYear;
                        _product.category_id = latestCid;
                        _product.brand_id = latestBid;
                        _product.list_price = model.ListPrice;
                        bikeStoresDb.Products.Add(_product);
                        bikeStoresDb.SaveChanges();
                        // transaction commit
                        transaction.Commit();
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                    }
            }
           
               
        }
        public void cpbDelete(int bId, int pId, int cid)
        {
            //var P = bikeStoresDb.Products.Where(x => x.product_id == Product.productid);
            //bikeStoresDb.Products.RemoveRange(P);
            //bikeStoresDb.SaveChanges();

            //var B = bikeStoresDb.Brands.Where(x => x.brand_id == Brand.BrandId);
            //bikeStoresDb.Brands.Remove(B);
            //bikeStoresDb.SaveChanges();

            //var C = bikeStoresDb.Categories.Where(x => x.category_id == Category.CategoryId);
            //bikeStoresDb.Categories.RemoveRange(C);
            //bikeStoresDb.SaveChanges();

        }
        public List<CategoryModel> GetCategoryList()
        {
            List<CategoryModel> cList = (from
                                       c in bikeStoresDb.Categories

                                           select new CategoryModel
                                           {
                                               category_name = c.category_name,
                                               category_Id = c.category_id

                                           }).ToList();

            return cList;
        }
        public List<ProductModel> GetProductList()
        {
            List<ProductModel> pList = (from
                                       p in bikeStoresDb.Products

                                          select new ProductModel
                                          {
                                              ProductName = p.product_name,
                                              ProductId = p.product_id

                                          }).ToList();

            return pList;
        }
        public List<BrandsModel> GetBrandList()
        {
            List<BrandsModel> bList = (from
                                       b in bikeStoresDb.Brands

                                       select new BrandsModel
                                       {
                                           brand_id = b.brand_id,
                                           brand_name = b.brand_name

                                       }).ToList();

            return bList;
        }
        public void dataDelete(DeleteModel delete)
        {
            using (var bikeStoresDb = new BikeStoresEntities())
            {
                //using (var transaction = bikeStoresDb.Database.BeginTransaction())
                //    try
                //    {
                        if (delete.ProductId != 0)
                        {
                            var productdata = bikeStoresDb.Products.Where(x => x.product_id == delete.ProductId).FirstOrDefault();
                            bikeStoresDb.Products.Remove(productdata);
                            bikeStoresDb.SaveChanges();

                        }
                        else if (delete.BrandId != 0)
                        {
                            var productdata = bikeStoresDb.Products.Where(x => x.brand_id == delete.BrandId).FirstOrDefault();
                            if (productdata != null)
                            {
                                bikeStoresDb.Products.Remove(productdata);
                                bikeStoresDb.SaveChanges();
                            }

                            var branddata = bikeStoresDb.Brands.Where(x => x.brand_id == delete.BrandId).FirstOrDefault();
                            bikeStoresDb.Brands.Remove(branddata);
                            bikeStoresDb.SaveChanges();
                        }
                        else if (delete.CategoryId != 0)
                        {
                            var categorydata = bikeStoresDb.Categories.Where(x => x.category_id == delete.CategoryId).FirstOrDefault();
                            bikeStoresDb.Categories.Remove(categorydata);
                            bikeStoresDb.SaveChanges();
                            var productdata = bikeStoresDb.Products.Where(x => x.category_id == delete.CategoryId).FirstOrDefault();
                            if (productdata != null)
                            {
                                bikeStoresDb.Products.Remove(productdata);
                                bikeStoresDb.SaveChanges();
                                
                            }

                        }
                    }
                    //catch (Exception)
                    //{
                    //    transaction.Rollback();
                    //}
            }
        }

    }



   