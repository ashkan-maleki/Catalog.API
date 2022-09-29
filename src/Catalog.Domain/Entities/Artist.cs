using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Domain.Entities
{
    [Table("Artists", Schema = "catalog")]
    public class Artist
    {
        [Key]
        public Guid? ArtistId { get; set; }
        [Required]
        [StringLength(200)]
        public string? ArtistName { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}