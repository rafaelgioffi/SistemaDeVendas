﻿using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

       public string MostrarCPF()
        {
            if (CPF.Length < 14)
            {
                return "CPF Inválido";
            }
            string cpf1 = CPF.Substring(0, 3);
            string cpf2 = CPF.Substring(CPF.Length - 2);
            
            return $"{cpf1}.***.***-{cpf2}";
        }
    }
}