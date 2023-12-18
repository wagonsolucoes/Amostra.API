using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;

namespace Amostra.API.Repository
{
    public interface IClienteRepository: IGenericRepository<Cliente>
    {
        public Task<ClienteLst?> Filtrar(int IniciaEm, int QtdLinhas, string TermoBusca, string ColunaOrdenar, string Direcao);
        
        public Task<int> FiltrarCount(string TermoBusca = "");

        public Task<List<Cliente>> FiltrarLista(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Nome", string Direcao = "ASC");

        public Task<List<SelectDto>> GetDdlCliente();
    }
}