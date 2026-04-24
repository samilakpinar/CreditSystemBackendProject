using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Domain.Entities
{
    public class ProductSeo : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string SchemaMarkup { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }
        public bool NoIndex { get; set; }
        public bool NoFollow { get; set; }
    }
}
