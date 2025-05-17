using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities;

public abstract class Customer : Entity<Guid>
{
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool IsActive { get; set; }
    public decimal CreditScore { get; set; }
} 