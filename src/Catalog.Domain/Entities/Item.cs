using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Domain.Entities
{
    [Table("Items", Schema = "catalog")]
    public class Item
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string? Description { get; set; }
        public string? LabelName { get; set; }
        public Money? Price { get; set; }
        public string? PictureUri { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
        public string? Format { get; set; }
        public int? AvailableStock { get; set; }
        public Guid? GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
        public Guid? ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist? Artist { get; set; }
        public bool? IsInactive { get; set; }
    }
}