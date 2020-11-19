using ApiClientes.App.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiClientes.App.Models.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O dono do endereço deve ser informado")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O dono do endereço deve ser informado")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        [StringLength(50, ErrorMessage = "O logradouro deve ter no mínimo {2} e no máximo {1} caracteres", MinimumLength = 5)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(40, ErrorMessage = "O bairro deve ter no máximo {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        [StringLength(40, ErrorMessage = "a cidade deve ter no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        [StringLength(40, ErrorMessage = "O estado deve ter no máximo {1} caracteres")]
        public string Estado { get; set; }

        [JsonIgnore]
        public ClienteSimplesDTO Cliente { get; set; }
    }
}
