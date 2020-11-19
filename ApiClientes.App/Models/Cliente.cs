using ApiClientes.App.Models.Base;
using ApiClientes.App.Models.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiClientes.App.Models
{
    
    public class Cliente: ModelBase
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime Nascimento { get; set; }

        public List<Endereco> Enderecos { get; set; }


    }

	
}

