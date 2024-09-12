using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoryAsync();
        Task<string> InsertCategoryInfo(Category category);
        Task<string> DeleteCategory(int id);
    }
}
