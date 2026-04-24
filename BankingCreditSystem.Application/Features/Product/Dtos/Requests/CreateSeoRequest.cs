using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Dtos.Requests
{
    public class CreateSeoRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
    }
}
