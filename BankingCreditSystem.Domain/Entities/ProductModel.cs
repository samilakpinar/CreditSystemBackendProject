using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Domain.Entities
{
    public class ProductModel : Entity<int>
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Chest { get; set; }
        public int Waist { get; set; }
        public int Hip { get; set; }
        public int ModelBody { get; set; }
    }
}
