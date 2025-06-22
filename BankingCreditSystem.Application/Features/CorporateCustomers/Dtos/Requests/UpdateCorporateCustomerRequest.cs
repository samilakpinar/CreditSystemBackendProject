using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateCorporateCustomerRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string AuthorizedPersonName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
}