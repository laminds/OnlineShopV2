using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using OnlineShopV2.Application.Admin.Commands.Discount;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin
{
    public class InsertDiscountCommandHandler : IRequestHandler<InsertDiscountCommand, string>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly OnlineShopDbContext _context;

        public InsertDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper, OnlineShopDbContext context)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(InsertDiscountCommand request, CancellationToken cancellationToken)
        {
            int discountId;
            if(request.discountId == 0)
            {
                discountId = 0;
            }
            else
            {
                discountId = (int)request.discountId;
            }

            var discountentity = new Discount()
            {
                Guid = Guid.NewGuid(),
                discountId = request.discountId,
                isActive = request.isActive,
                name = request.name,
                discounttype = request.discounttype,
                discountamount = request.discountamount,
                CreatedBy = request.CreatedBy
            };
            var Result = await _discountRepository.InsertDiscountInfo(discountentity);
            return _mapper.Map<string>(Result);
        }
    }
}
