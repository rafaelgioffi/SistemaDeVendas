using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória")]
        [Display(Name = "Categoria")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "{0} deve ter entre {1} e {2}")]
        public string Name { get; set; }

        [HiddenInput]
        public DateTime CreateTime { get; set; }

        [HiddenInput]
        public DateTime UpdateTime { get; set; }

    }
}
