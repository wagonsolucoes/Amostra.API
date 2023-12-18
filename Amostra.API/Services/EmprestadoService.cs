using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.Repository;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Amostra.API.Services
{
    public class EmprestadoService: IEmprestadoService
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;

        public EmprestadoService(AmostraContext context, IMapper mapper, IUnit unit)
        {
            _context = context;
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<int> FiltrarCount(string IdCliente, Guid? IdLivro)
        {
            return await _unit.Emprestado.FiltrarCount(IdCliente, IdLivro);
        }

        public async Task<List<EmprestadoDto>> FiltrarList(int IniciaEm, int QtdLinhas, string IdCliente, Guid? IdLivro, string ColunaOrdenar = "Cliente", string Direcao = "ASC")
        {
            var lst = await _unit.Emprestado.FiltrarLista(IniciaEm, QtdLinhas, IdCliente, IdLivro, ColunaOrdenar, Direcao);
            return _mapper.Map<List<EmprestadoDto>>(lst);
        }

        public async Task<List<ValidationFailure>> Add(EmprestadoVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            model.Id = Guid.NewGuid();
            model.Ativo = true;
            model.Dh = DateTime.Now;
            var validator = new EmprestadoValidator();
            var answerValidation = validator.Validate(model);
            if (!answerValidation.IsValid)
            {
                r = answerValidation.Errors;
            }
            else
            {
                _unit.Emprestado.Add(_mapper.Map<Emprestado>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            return r;
        }

        public async Task<List<ValidationFailure>> Update(EmprestadoVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            var validator = new EmprestadoValidator();
            var answerValidation = validator.Validate(model);
            if (!answerValidation.IsValid)
            {
                r = answerValidation.Errors;
            }
            else
            {
                _unit.Emprestado.Update(_mapper.Map<Emprestado>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            return r;
        }

        public async Task<bool> Delete(Guid id)
        {
            bool r = false;
            var model = _unit.Emprestado.Find(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {                
                _unit.Emprestado.Delete(model);
                _unit.Salvar();
                _unit.Dispose();
                r = true;
            }            
            return r;
        }
    }
}
