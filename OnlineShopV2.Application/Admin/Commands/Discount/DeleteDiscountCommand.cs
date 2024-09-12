using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.Discount
{
    public class DeleteDiscountCommand : IRequest<string>
    {
        public int discountId { get; set; }
    }
}
