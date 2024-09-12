using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.EntityModels
{
    public class Discount
    {
        public long discountId { get; set; }
        public Guid? Guid { get; set; }
        public bool? isActive { get; set; }
        public string? name { get; set; }
        public string? discounttype { get; set; }
        public int? discountamount { get; set; }
        public bool? isDelete { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
