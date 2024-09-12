using MediatR;
using OnlineShopV2.Application.Queries.GetSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<List<GetOrder>>
    {
    }
}
