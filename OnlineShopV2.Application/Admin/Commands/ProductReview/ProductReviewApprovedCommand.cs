using MediatR;
using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.ProductReview
{
    public class ProductReviewApprovedCommand : IRequest<string>
    {
        public int ProductReviewId { get; set; }
        public Boolean IsApproved { get; set; }
    }
}
