using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;
using FluentValidation.Results;

namespace Amostra.API.Services
{
    public interface ILivroService
    {
        public Task<int> FiltrarCount(string TermoBusca = " ");

        public Task<List<Livro>> FiltrarList(int IniciaEm, int QtdLinhas, string TermoBusca = " ", string ColunaOrdenar = "Titulo", string Direcao = "ASC");

        public Task<List<SelectDto>> GetDdlLivro();

        public Task<List<ValidationFailure>> Add(LivroVm model);

        public Task<List<ValidationFailure>> Update(LivroVm model);

        public Task<bool> Delete(Guid id);
    }
}
