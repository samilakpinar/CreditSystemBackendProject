using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Dtos.Requests
{
    public class CreateVariantRequest
    {
        public Guid VariantId { get; set; }
        public string StockCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
