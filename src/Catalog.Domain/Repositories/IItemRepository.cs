using Catalog.Domain.Entities;

namespace Catalog.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<IReadOnlyList<Item>> GetAsync();
        Task<Item?> GetAsync(Guid id);
        Item? Add(Item item);
        Item? Update(Item item);
    }
}
