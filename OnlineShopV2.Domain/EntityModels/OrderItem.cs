using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.EntityModels
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public Guid Guid { get; set; }
        public long orderId { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? SEOURL { get; set; }
        public string? ProductCode { get; set; }
        public string? Size { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ShippingCharge { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsReturn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
    }
}
