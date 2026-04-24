using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankingCreditSystem.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
    public DbSet<CreditType> CreditTypes { get; set; }
    public DbSet<CreditApplication> CreditApplications { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductModel> ProductModels { get; set; }

    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
} 