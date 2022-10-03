using Catalog.Domain.Entities;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers;

class GenreMapper : IGenreMapper
{
    public GenreResponse? Map(Genre? genre) => 
        genre is not null ? new GenreResponse
        {
            GenreId = genre.GenreId,
            GenreDescription = genre.GenreDescription
        } : null;
}