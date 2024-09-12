using Microsoft.Data.SqlClient;
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
    public class ProductReviewRepository : IProductReviewRepository
    {
        protected OnlineShopDbContext dbcontext;
        public ProductReviewRepository(OnlineShopDbContext _db)
        {
            dbcontext = _db;
        }

        public async Task<List<ProductReviewList>> GetProductReviewAsync()
        {
            return await dbcontext.ProductReview.ToListAsync();
        }

        public async Task<List<ProductReviewList>> GetProductReviewList(ProductReview ProductReview)
        {          
            List<ProductReviewList> result = new List<ProductReviewList>();
            try
            {
                //Note: Ensure that the stored procedure returns a result set that matches the ProductReviewList structure.
               
                 result = await dbcontext.ProductReview
                    .FromSqlRaw("EXEC [dbo].[Search_ProductReview] @Createdfrom, @Createdto, @ProductName,@Approved",
                        new SqlParameter("@Createdfrom", (object)ProductReview.Createdfrom ?? DBNull.Value),
                        new SqlParameter("@Createdto", (object)ProductReview.Createdto ?? DBNull.Value),
                        new SqlParameter("@ProductName", (object)ProductReview.ProductName ?? DBNull.Value),
                        new SqlParameter("@Approved", (object)ProductReview.Approved ?? DBNull.Value))
                    .ToListAsync();

                //return new List<ProductReviewList>();
            }
            catch (Exception ex)
            {
                return null;
            }
            return result;  
        }


        public async Task<string> ProductReviewApproved(int id)
        {
            try
            {
                var connection = dbcontext.Database.GetDbConnection();
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandText = "[dbo].[ToggleProductReviewApproval]";
                command.CommandType = CommandType.StoredProcedure;

                var IdParam = command.CreateParameter();
                IdParam.ParameterName = "@ProductReviewId";
                IdParam.Value = id;
                command.Parameters.Add(IdParam);

                await command.ExecuteNonQueryAsync();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


        //public Task<List<ProductReviewList>> GetProductReviewList(ProductReview productReview)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
