using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Domain.Entities
{
    [Table("Genres", Schema = "catalog")]
    public class Genre
    {
        [Key]
        public Guid? GenreId { get; set; }
        [Required]
        [StringLength(1000)]
        public string? GenreDescription { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}