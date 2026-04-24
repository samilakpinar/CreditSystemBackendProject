using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Dtos.Requests
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
