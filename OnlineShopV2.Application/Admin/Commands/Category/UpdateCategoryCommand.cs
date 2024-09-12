using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.Category
{
    public class UpdateCategoryCommand : IRequest<string>
    {
        public long? CategoryId { get; set; }
        public Guid? Guid { get; set; }
        public string? Name { get; set; }
        public int? OrderNo { get; set; }
        public bool? IsShowMenu { get; set; }
        public string? Description { get; set; }
        public long? ParentCategoryId { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeyword { get; set; }
        public string? MetaDescription { get; set; }
        public string? Seourl { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsDelete { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? Image { get; set; }
        public bool? IsShowHome { get; set; }
    }
}
