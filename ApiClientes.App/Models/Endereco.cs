using ApiClientes.App.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiClientes.App.Models
{
    public class Endereco : ModelBase
    {
        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        
        public string Estado { get; set; }


        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

    }
}
