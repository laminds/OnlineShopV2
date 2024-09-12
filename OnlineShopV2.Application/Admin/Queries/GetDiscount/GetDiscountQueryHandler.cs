using AutoMapper;
using MediatR;
using OnlineShopV2.Application.Admin.Queries.GetProduct;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetDiscount
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, List<DiscountVm>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetDiscountQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }
        public async Task<List<DiscountVm>> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var list = await _discountRepository.GetDiscountAsync();
            var Discountlist = _mapper.Map<List<DiscountVm>>(list);
            return Discountlist;
        }
    }
}
