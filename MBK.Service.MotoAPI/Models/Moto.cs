using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handmade.Service.EmbroideryAPI.Models
{
    [Table("Embroideries")]
    public class Embroidery
	{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Range(1, 1000)]
        public double Prix { get; set; }
        public string Category { get; set; }
        public string ImageURL { get; set; }
    }
}
