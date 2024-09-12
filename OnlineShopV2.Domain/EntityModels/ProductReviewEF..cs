using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.EntityModels
{
    public class ProductReviewEF
    {
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ReviewText { get; set; }
        public string Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsApproved { get; set; }
        public string CreatedBy { get; set; }
    }
}
