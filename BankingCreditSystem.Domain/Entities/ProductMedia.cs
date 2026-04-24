using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Domain.Entities
{
    public class ProductMedia : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Sort { get; set; }

        public string Thumb { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }

        public bool IsDownloaded { get; set; }
    }
}
