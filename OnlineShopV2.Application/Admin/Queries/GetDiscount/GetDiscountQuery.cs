using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetDiscount
{
    public class GetDiscountQuery : IRequest<List<DiscountVm>>
    {
    }
}
