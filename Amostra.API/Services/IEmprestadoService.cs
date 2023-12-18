using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;
using FluentValidation.Results;

namespace Amostra.API.Services
{
    public interface IEmprestadoService
    {
        public Task<int> FiltrarCount(string IdCliente, Guid? IdLivro);
        public Task<List<EmprestadoDto>> FiltrarList(int IniciaEm, int QtdLinhas, string IdCliente, Guid? IdLivro, string ColunaOrdenar = "Cliente", string Direcao = "ASC");
        public Task<List<ValidationFailure>> Add(EmprestadoVm model);
        public Task<List<ValidationFailure>> Update(EmprestadoVm model);
        public Task<bool> Delete(Guid id);
    }
}
