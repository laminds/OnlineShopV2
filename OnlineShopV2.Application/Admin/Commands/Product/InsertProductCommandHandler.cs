using AutoMapper;
using MediatR;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopV2.Application.Admin.Commands.Product;
using OnlineShopV2.Application.Admin.Commands;

namespace OnlineShopV2.Application.Admin
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly OnlineShopDbContext _context;

        public InsertProductCommandHandler(IProductRepository productRepository, IMapper mapper, OnlineShopDbContext context)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            int ProductId;
            if(request.ProductId == 0) 
            {
                ProductId = 0;
            }
            else
            {
                ProductId = (int)request.ProductId;
            }

            var productentity = new Product()
            {
                Guid = Guid.NewGuid(),
                ProductId = request.ProductId,
                Name = request.Name,
                Description = request.Description,
                SKU = request.SKU,
                CategoryId = request.CategoryId,
                IsPublish = request.IsPublish,
                IsShowHome = request.IsShowHome,
                IsActive = request.IsActive,
                SellingPrice =request.SellingPrice,
                MaxQuantity = request.MaxQuantity,
                AvailabilityStatus = request.AvailabilityStatus,
                Discount = request.Discount,
                CreatedBy = "Hitesh"
            };
            var Result = await _productRepository.InsertProductInfo(productentity);
            return _mapper.Map<string>(Result);
        }
    }
}
