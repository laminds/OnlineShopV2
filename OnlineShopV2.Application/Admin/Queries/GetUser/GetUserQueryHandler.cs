using AutoMapper;
using MediatR;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUser>>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<List<GetUser>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _loginRepository.GetUserAsync();
            var userlist = _mapper.Map<List<GetUser>>(users);
            return userlist;
        }
    }
}
