using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;

namespace Amostra.API.Repository
{
    public interface ILivroRepository : IGenericRepository<Livro>
    {
        public Task<Livro> GetLivro(Guid Id);

        public Task<int> FiltrarCount(string TermoBusca = "");

        public Task<List<Livro>> FiltrarLista(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Titulo", string Direcao = "ASC");

        public Task<List<SelectDto>> GetDDL();
    }
}