using ApiClientes.App.Models.Base;
using ApiClientes.App.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiClientes.App.Models.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(30, ErrorMessage = "O nome deve ter no mínimo {2} e no máximo {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(14, ErrorMessage = "O CPF deve ter {1} caracteres")]
        [CPFValido]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        [DataNascimento]
        public DateTime? Nascimento { get; set; }

        [ScaffoldColumn(false)]
        public List<EnderecoSimplesDTO> Enderecos { get; set; }
    }
}
