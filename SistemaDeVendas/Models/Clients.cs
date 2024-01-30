using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SistemaDeVendas.Models
{
    public class Clients
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CPF { get; set; }

        public string? CEP { get; set; }

        public string? Street { get; set; }

        public string? Number { get; set; }

        public string? Neighborhood { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string? Sex { get; set; }

        [HiddenInput]
        public DateTime CreateTime { get; set; }

        [HiddenInput]
        public DateTime UpdateTime { get; set; }

        public string ShowCPF()
        {
            if (CPF.Length < 14)
            {
                return "CPF Inválido";
            }
            string cpf1 = CPF.Substring(0, 3);
            string cpf2 = CPF.Substring(CPF.Length - 2);
            
            return $"{cpf1}.***.***-{cpf2}";
        }

        public int GetYears()
        {
            if (!string.IsNullOrEmpty(BirthDate.ToString()))
            {
                int today = DateTime.Now.Year;
                int birth = BirthDate.Year;
                return today - birth;
            }
            return 0;
        }
        
    }
}