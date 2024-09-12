using AutoMapper;
using MediatR;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetProductReview
{
    public class GetProductReviewQueryHandler: IRequestHandler<GetProductReviewQuery, List<ProductReviewList>>
    {
        private readonly IProductReviewRepository _ProductReviewRepository;
        private readonly IMapper _mapper;

        public GetProductReviewQueryHandler(IProductReviewRepository ProductReviewRepository, IMapper mapper)
        {
            _ProductReviewRepository = ProductReviewRepository;
            _mapper = mapper;


        }
        public async Task<List<ProductReviewList>> Handle(GetProductReviewQuery request, CancellationToken cancellationToken)
        {
            var list = await _ProductReviewRepository.GetProductReviewAsync();

            var sliderlist = _mapper.Map<List<ProductReviewList>>(list);
            return sliderlist;

        }
    }
}
