using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.Server;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        
        public Cliente Cliente { get; set; }
                
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        
        public Produto Produto { get; set; }
              
        [Display(Name = "Data da compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? DataCompra { get; set; }

        [Display(Name = "Forma de pagamento")]
        public string? FormaPagamento { get; set; }
    }
}