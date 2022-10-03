using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Responses
{
    public class PriceResponse
    {
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
    }
}
