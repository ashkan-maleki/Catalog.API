using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers;

public class ItemMapper : IItemMapper
{
    public Item? Map(AddItemRequest? request) =>
        request is not null ? new Item
        {
            Name = request.Name,
            Description = request.Description,
            LabelName = request.LabelName,
            PictureUri = request.PictureUri,
            ReleaseDate = request.ReleaseDate,
            Format = request.Format,
            AvailableStock = request.AvailableStock,
            GenreId = request.GenreId,
            ArtistId = request.ArtistId,
            Price = request.Price is not null ? 
                new Money
                {
                    Currency = request.Price.Currency,
                    Amount = request.Price.Amount
                } : null,
        } : null;

    public Item? Map(EditItemRequest? request) =>
        request is not null ? new Item
        {
            Name = request.Name,
            Description = request.Description,
            LabelName = request.LabelName,
            PictureUri = request.PictureUri,
            ReleaseDate = request.ReleaseDate,
            Format = request.Format,
            AvailableStock = request.AvailableStock,
            GenreId = request.GenreId,
            ArtistId = request.ArtistId,
            Price = request.Price is not null ?
                new Money
                {
                    Currency = request.Price.Currency,
                    Amount = request.Price.Amount
                } : null,
        } : null;

    public ItemResponse Map(Item item)
    {
        throw new NotImplementedException();
    }
}