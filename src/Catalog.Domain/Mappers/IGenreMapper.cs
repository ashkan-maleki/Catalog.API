using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers
{
    public interface IGenreMapper
    {
        GenreResponse? Map(Genre? genre);
    }

    class GenreMapper : IGenreMapper
    {
        public GenreResponse? Map(Genre? genre) => 
            genre is not null ? new GenreResponse
            {
                GenreId = genre.GenreId,
                GenreDescription = genre.GenreDescription
            } : null;
    }
}
