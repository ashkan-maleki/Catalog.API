using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers;

public class ItemMapper : IItemMapper
{
    private readonly IArtistMapper _artistMapper;
    private readonly IGenreMapper _genreMapper;

    public ItemMapper(IArtistMapper artistMapper, IGenreMapper genreMapper)
    {
        _artistMapper = artistMapper ?? throw new ArgumentNullException(typeof(ItemMapper).FullName);
        _genreMapper = genreMapper ?? throw new ArgumentNullException(typeof(ItemMapper).FullName);
    }

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

    public ItemResponse? Map(Item? request) =>
        request is not null ? new ItemResponse
        {
            Name = request.Name,
            Description = request.Description,
            LabelName = request.LabelName,
            PictureUri = request.PictureUri,
            ReleaseDate = request.ReleaseDate,
            Format = request.Format,
            AvailableStock = request.AvailableStock,
            GenreId = request.GenreId,
            Genre = _genreMapper.Map(request.Genre),
            ArtistId = request.ArtistId,
            Artist = _artistMapper.Map(request.Artist),
            Price = request.Price is not null ?
                new MoneyResponse
                {
                    Currency = request.Price.Currency,
                    Amount = request.Price.Amount
                } : null,
        } : null;
}