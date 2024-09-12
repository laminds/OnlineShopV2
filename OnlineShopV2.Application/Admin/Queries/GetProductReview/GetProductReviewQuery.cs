using MediatR;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetProductReview
{
    public class GetProductReviewQuery : IRequest<List<ProductReviewList>>
    {

    }
}
