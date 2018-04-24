using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class EnderecoFuncionario : Endereco
    {
        public virtual Funcionario funcionario { get; set; }

    }
}