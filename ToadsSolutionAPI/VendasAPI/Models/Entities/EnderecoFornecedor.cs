namespace VendasAPI.Models.Entities
{
    public class EnderecoFornecedor : Endereco
    {
        public virtual Fornecedor fornecedor { get; set; }
    }
}