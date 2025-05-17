namespace BankingCreditSystem.Domain.Entities;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string IdentityNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; } = null!;
} 