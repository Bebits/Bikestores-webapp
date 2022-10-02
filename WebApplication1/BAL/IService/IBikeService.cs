using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.ViewModel;

namespace WebApplication1.BAL.IService
{
   public interface IBikeService
    {
        List<StoreModel> GetStoreList();
        void AddStoreList(StoreModel model);
        void DeleteDetails(int? id);
        void Edit(StoreModel model);
        List<StoreStocksModel> GetStoreStocksList(StoreStocksModel model);
        void AddStoreStockList(StoreStocksModel model);
        void Delete(int id, int pId);
        void EditStock(StoreStocksModel model);
        List<ProductModel> GetProductList(StoreStocksModel stocks);
        List<StaffModel> GetStaffList();
        void AddStaff(StaffModel model);
        List<cpbModel> GetcpbList();
        void AddcpbList(cpbModel model);
        void cpbDelete(int bid, int pId, int cid);
        List<ProductModel> GetProductList();
       
        List<BrandsModel> GetBrandList();
        List<CategoryModel> GetCategoryList();
        void dataDelete(DeleteModel model);
    }
}
