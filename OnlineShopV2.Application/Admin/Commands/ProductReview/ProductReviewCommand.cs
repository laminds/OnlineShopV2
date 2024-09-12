using MediatR;
using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.ProductReview
{
    public class ProductReviewCommand : IRequest<List<ProductReviewList>>
    {
        public DateTime Createdfrom {  get; set; }
        public DateTime Createdto { get; set; }
        public string ProductName { get; set; }
        public string Approved { get; set; }


        //public int ProductReviewId { get; set; }
        //public int ProductId { get; set; }
        //public string ProductName { get; set; } 
        //public int CustmoreID { get; set; }
        //public string CustmoreName { get;set; }
        //public string ReviewText {  get; set; } 
        //public string Rating {  get; set; }

    }
}
