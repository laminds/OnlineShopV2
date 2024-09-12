using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.EntityModels
{
    public class Product
    {
        public long ProductId { get; set; }
        public Guid? Guid { get; set; }
        public string? Name { get; set; }
        //public string? ProductCode { get; set; }
        public string? Description { get; set; }
        //public long? SupplierId { get; set; }
        //public string? SupplierProductCode { get; set; }
        //public decimal? ListPrice { get; set; }
        public int? SellingPrice { get; set; }
        public string? CategoryId { get; set; }
        public string? AvailabilityStatus { get; set; }
        public int? Discount { get; set; }
        public bool? IsPublish { get; set; }
        //public DateTime? SaleStartDate { get; set; }
        //public DateTime? SaleEndDate { get; set; }
        public int? MaxQuantity { get; set; }
        public bool? IsShowHome { get; set; }
        public bool? IsActive { get; set; }
        //public string? MetaTitle { get; set; }
        //public string? MetaKeyword { get; set; }
        //public string? MetaDescription { get; set; }
        public string? SKU { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsDelete { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        //public string? TagId { get; set; }
        public long? BrandId { get; set; }
    }
}
