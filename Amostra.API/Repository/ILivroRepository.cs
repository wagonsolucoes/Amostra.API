using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel.Amostra;

namespace Amostra.API.Repository
{
    public interface ILivroRepository : IGenericRepository<Livro>
    {
        public LivroLst Filtrar(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Nome", string Direcao = "ASC");
    }
}