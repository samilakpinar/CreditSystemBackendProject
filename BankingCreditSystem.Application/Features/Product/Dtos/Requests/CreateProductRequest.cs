using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Dtos.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int CategoryId { get; set; }
        public List<int> CategoryIds { get; set; }

        //public int? ModelId { get; set; }
        public int? SupplierId { get; set; }

        public string StockCode { get; set; }

        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }

        public string Description { get; set; }
        public string Slug { get; set; }
        public int? ColorId { get; set; }
        public int? BrandId { get; set; }
        public int TotalQuantity { get; set; }



        //public string GroupId { get; set; }

        public List<CreateVariantRequest> Variants { get; set; }
        public List<CreateMediaRequest> Medias { get; set; }
        public List<Guid> PropertyIds { get; set; }
        public CreateSeoRequest Seo { get; set; }
    }
}
