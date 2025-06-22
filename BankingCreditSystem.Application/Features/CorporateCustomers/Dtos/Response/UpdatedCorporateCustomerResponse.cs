using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Response
{
    public class UpdatedCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = default!;
        public DateTime UpdatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
}
