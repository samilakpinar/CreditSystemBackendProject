using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities;

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; } = null!;
    public string TaxNumber { get; set; } = null!;
    public string CompanyRegistrationNumber { get; set; } = null!;
    public DateTime EstablishmentDate { get; set; }
    public string LegalStatus { get; set; } = null!;
    public decimal AnnualTurnover { get; set; }
} 