using Microsoft.EntityFrameworkCore;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected OnlineShopDbContext dbContext;
        public ProductRepository(OnlineShopDbContext _db) 
        {
            dbContext = _db;
        }
        public async Task<List<Product>> GetProductAsync()
        {
            return await dbContext.Product.Where(c => c.IsDelete == false).ToListAsync();
        }
        public async Task<string> InsertProductInfo(Product product)
        {
            try
            {
                if (product.ProductId != 0)
                {
                    var result = await dbContext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateProductDetails] @ProductId = {0}, @Name = {1}, @Description = {2}, @SKU = {3}, @CategoryId = {4}, @SellingPrice = {5}, @MaxQuantity = {6}, @AvailabilityStatus = {7}, @Discount = {8}, @IsPublish = {9}, @IsShowHome = {10}, @IsActive = {11}, @CreatedBy = {12}",
                    product.ProductId, product.Name, product.Description, product.SKU, product.CategoryId, product.SellingPrice,
                    product.MaxQuantity, product.AvailabilityStatus, product.Discount, product.IsPublish, product.IsShowHome,
                    product.IsActive, product.CreatedBy);
                    return "Product Update successfully";
                }
                else
                {
                    var result = await dbContext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateProductDetails] @Guid = {0}, @Name = {1}, @Description = {2}, @SKU = {3}, @CategoryId = {4}, @SellingPrice = {5}, @MaxQuantity = {6}, @AvailabilityStatus = {7}, @Discount = {8}, @IsPublish = {9}, @IsShowHome = {10}, @IsActive = {11}, @CreatedBy = {12}",
                    product.Guid, product.Name, product.Description, product.SKU, product.CategoryId, product.SellingPrice,
                    product.MaxQuantity, product.AvailabilityStatus, product.Discount, product.IsPublish, product.IsShowHome,
                    product.IsActive, product.CreatedBy);
                    return "Product Save successfully";
                }
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
      public async Task<string> DeleteProduct(int id)
        {
            try
            {
                var connection = dbContext.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandText = "[admin].[usp_DeleteProductInfo]";
                command.CommandType = CommandType.StoredProcedure;

                var ProductIdParam = command.CreateParameter();
                ProductIdParam.ParameterName = "@ProductId";
                ProductIdParam.Value = id;
                command.Parameters.Add(ProductIdParam);

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
