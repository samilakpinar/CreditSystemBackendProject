using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Domain.Entities
{
    public class ProductProperty : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
