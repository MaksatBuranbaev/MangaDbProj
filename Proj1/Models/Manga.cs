using System.ComponentModel.DataAnnotations;

namespace Proj1.Models
{
    public class Manga
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(50)]
        public string Illustrator { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Display(Name = "Realese Date")]
        [DataType(DataType.Date)]
        public DateTime RealeseDate { get; set; }
        [StringLength(100)]
        public string Genre { get; set; }
    }
}
