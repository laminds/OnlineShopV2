using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopV2.Application.Admin
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public InsertCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<string> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            int CategoryId;
            if (request.CategoryId == null)
            {
                 CategoryId = 0;
            }
            else
            {
                 CategoryId = (int)request.CategoryId;
            }

            var categoryentity = new Category()
            {
                Guid = Guid.NewGuid(),
                CategoryId = CategoryId,    
                Name = request.Name,
                OrderNo = (int)request.OrderNo,
                Image = request.Image,
                Description = request.Description,
                ParentCategoryId = request.ParentCategoryId,
                MetaTitle = request.MetaTitle,
                MetaDescription = request.MetaDescription,
                MetaKeyword = request.MetaKeyword,
                Seourl = request.Seourl,
                IsShowMenu = (bool)request.IsShowMenu,
                IsShowHome = (bool)request.IsShowHome,
                IsActive = (bool)request.IsActive,
                CreatedBy = request.CreatedBy
            };
            var Result = await _categoryRepository.InsertCategoryInfo(categoryentity);
            return _mapper.Map<string>(Result);
        }
    }
}
