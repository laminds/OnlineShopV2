using Microsoft.EntityFrameworkCore;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Data;
using OnlineShopV2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected OnlineShopDbContext dbcontext;
        public CategoryRepository(OnlineShopDbContext _db)
        {
            dbcontext = _db;
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            return await dbcontext.Category.Where(c => c.IsDelete == false).ToListAsync();
        }
        public async Task<string> InsertCategoryInfo(Category category)
        {
            try
            {
                if (category.CategoryId != 0)
                {
                    var result = await dbcontext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateProductInfo] @CategoryId = {0}, @Name = {1}, @OrderNo = {2}, @Image = {3}, @Description = {4}, @ParentCategoryId = {5}, @MetaTitle = {6}, @MetaDescription = {7}, @MetaKeyword = {8}, @SEOURL = {9}, @IsShowMenu = {10}, @IsShowHome = {11}, @IsActive = {12}, @CreatedBy = {13}",
                    category.CategoryId, category.Name, category.OrderNo, category.Image, category.Description, category.ParentCategoryId,
                    category.MetaTitle, category.MetaDescription, category.MetaKeyword, category.Seourl, category.IsShowMenu,
                    category.IsShowHome, category.IsActive, category.CreatedBy);
                    return "Category Update successfully";
                }
                else
                {
                    var result = await dbcontext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateProductInfo] @Guid = {0}, @Name = {1}, @OrderNo = {2}, @Image = {3}, @Description = {4}, @ParentCategoryId = {5}, @MetaTitle = {6}, @MetaDescription = {7}, @MetaKeyword = {8}, @SEOURL = {9}, @IsShowMenu = {10}, @IsShowHome = {11}, @IsActive = {12}, @CreatedBy = {13}",
                    category.Guid, category.Name, category.OrderNo, category.Image, category.Description, category.ParentCategoryId,
                    category.MetaTitle, category.MetaDescription, category.MetaKeyword, category.Seourl, category.IsShowMenu,
                    category.IsShowHome, category.IsActive, category.CreatedBy);
                    return "Category Save successfully";
                }
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
        public async Task<string> DeleteCategory(int id)
        {
            try
            {
                var connection = dbcontext.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandText = "[admin].[usp_DeleteCategoryInfo]";
                command.CommandType = CommandType.StoredProcedure;

                var CategoryIdParam = command.CreateParameter();
                CategoryIdParam.ParameterName = "@CategoryId";
                CategoryIdParam.Value = id;
                command.Parameters.Add(CategoryIdParam);

                await command.ExecuteNonQueryAsync();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
