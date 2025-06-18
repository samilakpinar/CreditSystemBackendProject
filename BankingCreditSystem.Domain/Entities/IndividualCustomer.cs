namespace BankingCreditSystem.Domain.Entities;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string NationalId { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
} 