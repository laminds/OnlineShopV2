using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.EntityModels
{
    public class ProductReview
    {
        public DateTime Createdfrom { get; set; } = DateTime.Now;
        public DateTime Createdto { get; set; } = new DateTime();
        public string ProductName { get; set; } = string.Empty;
        public string Approved { get; set; } 
        //public int ProductreViewId {  get; set; }
        //public int ProductId {  get; set; }
        //public string ProductName { get; set; }
        //public int CustomerId { get; set; }
        //public string CustomerName { get; set; }
        //public string ReviewText { get; set; }
        //public string Rating { get; set; }
        //public Boolean IsApproved { get; set; }
        //public DateTime CreatedOn { get; set; }
    }
}
