using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Dtos.Response
{
    public class UpdatedProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } //fiziksel

        public int CategoryId { get; set; }

        public int? BrandId { get; set; }

        public int? ModelId { get; set; }

        public int? ColorId { get; set; }

        public int? SupplierId { get; set; }

        public string StockCode { get; set; }

        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public decimal? OtherPrice { get; set; }

        public int VatAmount { get; set; }
        public int TaxStatus { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int TotalQuantity { get; set; }
        public bool IsApprovedForSale { get; set; }
        public bool IsNonReturnable { get; set; }
        public bool IsStock { get; set; }
        public string VideoPath { get; set; }
        public string VideoThumbPath { get; set; }
        public string VideoStatus { get; set; }
        public string Message { get; set; }
    }
}
