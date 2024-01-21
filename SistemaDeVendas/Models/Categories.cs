using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string Name { get; set; }
    }
}
