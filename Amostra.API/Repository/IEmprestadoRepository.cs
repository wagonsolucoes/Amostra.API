using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel.Amostra;

namespace Amostra.API.Repository
{
    public interface IEmprestadoRepository : IGenericRepository<Emprestado>
    {
        public EmprestadoLst Filtrar(int IniciaEm, int QtdLinhas, string IdCliente, Guid IdLivro, string ColunaOrdenar = "Nome", string Direcao = "ASC");
    }
}