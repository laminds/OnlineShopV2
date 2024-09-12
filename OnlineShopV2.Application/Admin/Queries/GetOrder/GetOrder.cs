using OnlineShopV2.Application.Common.Mappings;
using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Queries.GetOrder
{
    public class GetOrder : IMapFrom<Orders>
    {
        public long OrderId { get; set; }
        public Guid Guid { get; set; }
        public string? OrderStatus { get; set; }
        public decimal GrandTotal { get; set; }
        public string? PaymentType { get; set; }
        public string? Promocode { get; set; }
        public string? BillFirstName { get; set; }
        public string? BillLastName { get; set; }
        public string? BillAddressLine1 { get; set; }
        public string? BillCityName { get; set; }
        public string? BillStateName { get; set; }
        public string? BillZipCode { get; set; }
        public string? BillPhoneNo { get; set; }
        public string? BillEmail { get; set; }
        public bool IsEmailSent { get; set; }
        public DateTime? EmailSendTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDelete { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
