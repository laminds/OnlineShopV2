using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductAsync();
        Task<string> InsertProductInfo(Product product);
        Task<string> DeleteProduct(int id);
    }
}
