using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.SchemaDefinitions
{
    public class ItemEntitySchemaDefinition :
        IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p => p.Price).HasConversion(
                p => $"{p.Amount}:{p.Currency}",
                p => new Money
                {
                    Amount = Convert.ToDecimal(p.Split(':', StringSplitOptions.None)[0]),
                    Currency = p.Split(':', StringSplitOptions.None)[1]
                }
            );
        }
    }
}
