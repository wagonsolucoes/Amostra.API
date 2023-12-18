using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel.Amostra;

namespace Amostra.API.Repository
{
    public interface IEmprestadoRepository : IGenericRepository<Emprestado>
    {
        public Task<int> FiltrarCount(string IdCliente, Guid? IdLivro);
        
        public Task<List<Emprestado>> FiltrarLista(int IniciaEm, int QtdLinhas, string IdCliente, Guid? IdLivro, string ColunaOrdenar = "Cliente", string Direcao = "ASC");
    }
}