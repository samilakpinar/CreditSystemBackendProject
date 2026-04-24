using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Dtos.Response
{
    public class UpdatedCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
}
