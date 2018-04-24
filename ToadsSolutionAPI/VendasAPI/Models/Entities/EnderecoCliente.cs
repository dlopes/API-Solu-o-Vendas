namespace VendasAPI.Models.Entities
{
    public class EnderecoCliente : Endereco
    {
        public virtual Cliente cliente { get; set; }
    }
}