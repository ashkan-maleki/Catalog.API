using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers
{
    public interface IArtistMapper
    {
        ArtistResponse? Map(Artist? artist);
    }
}
