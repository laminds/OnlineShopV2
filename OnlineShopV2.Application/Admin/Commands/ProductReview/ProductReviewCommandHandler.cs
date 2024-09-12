using AutoMapper;
using MediatR;
using OnlineShopV2.Application.Admin.Commands.ProductReview;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin
{ 
    public class ProductReviewCommandHandler : IRequestHandler<ProductReviewCommand, List<ProductReviewList>>
    {
        private readonly IProductReviewRepository _ProductReviewRepository;
        private readonly IMapper _mapper;

        public ProductReviewCommandHandler(IProductReviewRepository ProductReviewRepository, IMapper mapper)
        {
            _ProductReviewRepository = ProductReviewRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductReviewList>> Handle(ProductReviewCommand request, CancellationToken cancellationToken)
        {
            List<ProductReviewList> result = new List<ProductReviewList>();
            var ProductReview = new ProductReview()
            {
                Createdfrom = request.Createdfrom,
                Createdto = request.Createdto,
                ProductName = request.ProductName,
                Approved = request.Approved
            };
            result = await _ProductReviewRepository.GetProductReviewList(ProductReview);
            // return _mapper.Map<string>(Result);
            return result;
        }
    }
}
