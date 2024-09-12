using MediatR;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.ProductReview
{
    public class ProductReviewApprovedCommandHandler : IRequestHandler<ProductReviewApprovedCommand, string>
    {
        private readonly IProductReviewRepository _ProductReviewRepository;
        public ProductReviewApprovedCommandHandler(IProductReviewRepository ProductReviewRepository)
        {
            _ProductReviewRepository = ProductReviewRepository;
        }
        public async Task<string> Handle(ProductReviewApprovedCommand request, CancellationToken cancellationToken)
        {
            return await _ProductReviewRepository.ProductReviewApproved(request.ProductReviewId);
        }
    }
}
