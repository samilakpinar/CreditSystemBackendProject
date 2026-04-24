using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICategoryRepository : IAsyncRepository<Category, int>
{
}
