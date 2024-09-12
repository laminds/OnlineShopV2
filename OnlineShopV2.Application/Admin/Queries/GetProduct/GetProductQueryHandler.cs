using AutoMapper;
using MediatR;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductVm>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var list = await _productRepository.GetProductAsync();
            var Productlist = _mapper.Map<List<ProductVm>>(list);
            return Productlist;
        }
    }
}
