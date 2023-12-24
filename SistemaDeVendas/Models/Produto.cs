using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)"), Required(ErrorMessage = "Preço é obrigatório")]
        [DataType(DataType.Currency)]
        [Range(minimum: 0.01, maximum: 99999999999.99, ErrorMessage = "O valor deve ser entre {2} e {1}")]
        public decimal PrecoUnit { get; set; }

        //public Cliente Cliente { get; set; }
        //public int ClienteID { get; set;}
    }
}