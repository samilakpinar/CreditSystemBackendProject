using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Domain.Entities
{
    public class Property : Entity<Guid>
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public Property Parent { get; set; }
    }
}
