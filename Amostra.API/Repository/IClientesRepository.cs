using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel.Amostra;

namespace Amostra.API.Repository
{
    public interface IClienteRepository: IGenericRepository<Cliente>
    {
        public ClienteLst Filtrar(int IniciaEm, int QtdLinhas, string TermoBusca, string ColunaOrdenar, string Direcao);
    }
}