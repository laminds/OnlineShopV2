using MediatR;
using OnlineShopV2.Application.Admin.Commands.Category;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<string> Handle (UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var Updatecategory = new Category()
            {
                CategoryId = (long)request.CategoryId,
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
            return await _categoryRepository.InsertCategoryInfo(Updatecategory);
        }
    }
}
