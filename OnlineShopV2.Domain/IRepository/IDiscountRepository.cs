using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.IRepository
{
    public interface IDiscountRepository
    {
        Task<List<Discount>> GetDiscountAsync();
        Task<string> InsertDiscountInfo(Discount discount);
        Task<string> DeleteDiscount(int id);
    }
}
