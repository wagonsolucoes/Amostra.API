using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;
using FluentValidation.Results;

namespace Amostra.API.Services
{
    public interface IClientesService
    {
        public Task<ClienteDto> GetValueById(string id);
        public Task<int> FiltrarCount(string TermoBusca = " ");
        public Task<List<Cliente>> FiltrarList(int IniciaEm, int QtdLinhas, string TermoBusca = " ", string ColunaOrdenar = "Nome", string Direcao = "ASC");
        public Task<List<SelectDto>> GetDdlCliente();
        public Task<List<ValidationFailure>> Add(ClienteVm model);
        public Task<List<ValidationFailure>> Update(ClienteVm model);
        public Task<bool> Delete(string id);
        public Task<Viacep?> ViaCep(string cep);
    }
}
