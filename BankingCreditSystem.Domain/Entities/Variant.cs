using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Domain.Entities
{
    public class Variant : Entity<Guid>
    {
        public int? ParentId { get; set; }

        public string Name { get; set; } // 36, 38 vs
        public int Sort { get; set; }
    }
}
