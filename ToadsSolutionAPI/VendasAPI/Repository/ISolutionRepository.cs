using System.Collections.Generic;
namespace VendasAPI.Repository
{
    public interface ISolutionRepository<T>
    {
        void Inserir(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        T RetornarPorId(long Id);
        IList<T> Consultar();
        int RetornarCout(long id);
    }
}
