﻿using Catalog.Domain.Entities;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers;

public class ArtistMapper : IArtistMapper
{
    public ArtistResponse? Map(Artist? artist) => 
        artist is not null ? new ArtistResponse
        {
            ArtistId = artist.ArtistId,
            ArtistName = artist.ArtistName
        } : null;
}