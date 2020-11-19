using ApiClientes.App.Models.Base;
using ApiClientes.App.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiClientes.App.Models.DTOs
{
    public class ClienteSimplesDTO
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string CPF { get; set; }

        public DateTime? Nascimento { get; set; }

    }
}
