using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeVendas.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [Range(3, 50, ErrorMessage = "Nome é obrigatório e deve ter entre {2} e {1}")]
        public string Name { get; set; }

        [Range(0, 600, ErrorMessage = "A descrição deve ter entre {2} e {1}")]
        public string? Description { get; set; }


        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)"), Required(ErrorMessage = "Preço é obrigatório")]
        [DataType(DataType.Currency)]
        [Range(minimum: 0.01, maximum: 999999.99, ErrorMessage = "O valor deve ser entre {2} e {1}")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

    }
}