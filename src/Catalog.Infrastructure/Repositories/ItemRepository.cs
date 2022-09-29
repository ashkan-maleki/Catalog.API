using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CatalogContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ItemRepository(CatalogContext context)
        {
            _context = context  ?? throw new 
                ArgumentNullException(nameof(context));
        }

        public async Task<IReadOnlyList<Item>> GetAsync()
            => await _context.Items?.AsNoTracking()
                .ToListAsync()!;
        public async Task<Item?> GetAsync(Guid id)
            => await _context.Items?.AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Genre)
                .Include(x => x.Artist)
                .FirstOrDefaultAsync()!;

        public Item? Add(Item item)
            => _context.Items?.Add(item).Entity;

        public Item? Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
