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
    public class DiscountRepository :  IDiscountRepository
    {
        protected OnlineShopDbContext dbContext;
        public DiscountRepository(OnlineShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Discount>> GetDiscountAsync()
        {
            return await dbContext.Discount.Where(c => c.isDelete == false).ToListAsync();
        }
        public async Task<string> InsertDiscountInfo(Discount discount)
        {
            try
            {
                if (discount.discountId != 0)
                {
                    var result = await dbContext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateDiscountDetails] @discountId = {0}, @isActive = {1}, @name = {2}, @discounttype = {3}, @discountamount = {4}, @CreatedBy = {5}",
                    discount.discountId, discount.isActive, discount.name, discount.discounttype, discount.discountamount, discount.CreatedBy);
                    return "Discount Update successfully";
                }
                else
                {
                    var result = await dbContext.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertAndUpdateDiscountDetails] @Guid = {0}, @isActive = {1}, @name = {2}, @discounttype = {3}, @discountamount = {4}, @CreatedBy = {5}",
                    discount.Guid, discount.isActive, discount.name, discount.discounttype, discount.discountamount, discount.CreatedBy);
                    return "Discount Add successfully";
                }
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
        public async Task<string> DeleteDiscount(int id)
        {
            try
            {
                var connection = dbContext.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandText = "[admin].[usp_DeleteDiscountDetails]";
                command.CommandType = CommandType.StoredProcedure;

                var DiscountIdParam = command.CreateParameter();
                DiscountIdParam.ParameterName = "@discountId";
                DiscountIdParam.Value = id;
                command.Parameters.Add(DiscountIdParam);

                await command.ExecuteNonQueryAsync();
                return "true";
            }
            catch (Exception ex)
            {
                return "false"; 
            }
        }
    }
}
