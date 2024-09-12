using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        protected OnlineShopDbContext dbcontext;
        private readonly ILoginRepository? _repository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(ILoginRepository loginRepository, IMapper mapper, OnlineShopDbContext _db)
        {
            dbcontext = _db;
            _repository = loginRepository;
            _mapper = mapper;
        }
        
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            int UserId;
            if(request.UserId == 0)
            {
                UserId = 0;
            }
            else
            {
                UserId = (int)request.UserId;
            }
            var userentity = new Users()
            {
                Guid = Guid.NewGuid(),
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Username,
                Phone = request.Phone,
                Password = request.Password,
                CreatedBy = "hitesh",
                CustomerRole = request.CustomerRole,
            };
            var result = await _repository.CreateUserAsync(userentity);
            return _mapper.Map<string>(result);
        }
    }
}