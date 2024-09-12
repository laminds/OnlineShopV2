using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.IRepository
{
    public interface IProductReviewRepository
    {
        Task<List<ProductReviewList>> GetProductReviewAsync();
        Task<List<ProductReviewList>> GetProductReviewList(ProductReview productReview);
        Task<string> ProductReviewApproved(int id);

    }
}
