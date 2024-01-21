using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeVendas.Models
{
    public class Salles
    {
        [Key]
        public int SalleId { get; set; }

        [Display(Name = "Cliente")]
        [ForeignKey("Clients")]
        public int ClientId { get; set; }

        public Clients Clients { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public Products Products { get; set; }

        [Display(Name = "Data da compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime SalleDate { get; set; }

        [Display(Name = "Forma de pagamento")]
        public string PaymentMethod { get; set; }
    }
}