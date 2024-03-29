﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;

namespace Catalog.Domain.Requests.Item
{
    public class EditItemRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? LabelName { get; set; }
        public Money? Price { get; set; }
        public string? PictureUri { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
        public string? Format { get; set; }
        public int? AvailableStock { get; set; }
        public Guid? GenreId { get; set; }
        public Guid? ArtistId { get; set; }
    }
}
