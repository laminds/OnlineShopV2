using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public int SliderId { get; set; }
    }
}
