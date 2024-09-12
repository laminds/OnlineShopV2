using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.Product
{
    public class DeleteProductCommand : IRequest<string>
    {
        public int ProductId { get; set; }
    }
}
