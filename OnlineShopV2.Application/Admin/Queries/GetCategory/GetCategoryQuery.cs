using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<List<CategoryVm>>
    {
    }
}
