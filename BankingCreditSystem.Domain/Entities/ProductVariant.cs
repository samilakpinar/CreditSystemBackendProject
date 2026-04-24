using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Domain.Entities
{
    public class ProductVariant : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid VariantId { get; set; }
        public Variant Variant { get; set; }

        public string StockCode { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
