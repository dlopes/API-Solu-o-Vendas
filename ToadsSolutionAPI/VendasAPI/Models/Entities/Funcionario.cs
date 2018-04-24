using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class Funcionario
    {
        //private long _id;
        public virtual long id { get; set; }
        public virtual string nome { get; set; }
        public virtual string cpf { get; set; }
        public virtual string email { get; set; }
        public virtual string rg { get; set; }
        public virtual string orgaorg { get; set; }
        public virtual byte[] foto { get; set; }
        //public virtual string bairro;
        public virtual string cargo { get; set; }
        public virtual string celular { get; set; }
        public virtual string telefone { get; set; }
        public virtual decimal comissao { get; set; }
        public virtual decimal salario { get; set; }
        public virtual DateTime posse { get; set; }
        public virtual string auditoria { get; set; }
        //public virtual IList<EnderecoFuncionario> enderecoFuncionarios { get; set; }
        //public virtual IList<Profissao> profissoes { get; set; }
        public virtual IList<Departamento> departamentos { get; set; }
        [JsonIgnore]
        public virtual IList<Usuario> usuarios { get; set; }

        /*public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }*/
    }
}