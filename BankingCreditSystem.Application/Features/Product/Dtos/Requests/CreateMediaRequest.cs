using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Dtos.Requests
{
    public class CreateMediaRequest
    {
        public string Thumb { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public int Sort { get; set; }
    }
}
