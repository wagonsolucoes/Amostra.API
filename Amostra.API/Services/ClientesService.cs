using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.Repository;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Amostra.API.Services
{
    public class ClientesService : IClientesService
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;

        public ClientesService(AmostraContext context, IMapper mapper, IUnit unit)
        {
            _context = context;
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<ClienteDto> GetValueById(string id)
        {
            ClienteDto r = new ClienteDto();
            var obj = _unit.Cliente.GetValueById(id);
            if (obj != null)
            {
                r = _mapper.Map<ClienteDto>(obj);
            }
            return r;
        }

        public async Task<int> FiltrarCount(string TermoBusca = " ")
        {
            return await _unit.Cliente.FiltrarCount(TermoBusca);
        }

        public async Task<List<Cliente>> FiltrarList(int IniciaEm, int QtdLinhas, string TermoBusca = " ", string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            return await _unit.Cliente.FiltrarLista(IniciaEm, QtdLinhas, TermoBusca, ColunaOrdenar, Direcao);
        }

        public async Task<List<SelectDto>> GetDdlCliente()
        {
            var lst = await _unit.Cliente.GetDdlCliente();
            return lst;
        }

        public async Task<List<ValidationFailure>> Add(ClienteVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            var validator = new ClienteValidator();
            var answerValidation = validator.Validate(model);
            if (!answerValidation.IsValid)
            {
                r = answerValidation.Errors;
            }
            else
            {
                _unit.Cliente.Add(_mapper.Map<Cliente>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            return r;
        }

        public async Task<List<ValidationFailure>> Update(ClienteVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();
            var validator = new ClienteValidator();
            var answerValidation = validator.Validate(model);
            if (!answerValidation.IsValid)
            {
                r = answerValidation.Errors;
            }
            else
            {
                _unit.Cliente.Update(_mapper.Map<Cliente>(model));
                _unit.Salvar();
                _unit.Dispose();
            }            
            return r;
        }

        public async Task<bool> Delete(string id)
        {
            bool r = false;
            var model = _unit.Cliente.GetValueById(id);
            if (model != null)
            {
                _unit.Cliente.Delete(model);
                _unit.Salvar();
                _unit.Dispose();
                r = true;
            }            
            return r;
        }

        public async Task<Viacep?> ViaCep(string cep)
        {
            Viacep? vc = new Viacep();
            string url = "https://viacep.com.br";
            var client = new RestClient(url);
            var request = new RestRequest("/ws/" + cep.Replace("-", "") + "/json/", Method.Get);
            vc = client.Execute<Viacep>(request).Data;
            return vc;
        }
    }
}
