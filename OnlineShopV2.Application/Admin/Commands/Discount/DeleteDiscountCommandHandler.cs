using MediatR;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.Discount
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, string>
    {
        private readonly IDiscountRepository _discountRepository;
        public DeleteDiscountCommandHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<string> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            return await _discountRepository.DeleteDiscount(request.discountId);
        }
    }
}
