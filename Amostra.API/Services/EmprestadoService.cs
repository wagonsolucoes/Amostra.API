using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.Repository;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Amostra.API.Services
{
    public class EmprestadoService
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

        public async Task<EmprestadoDto> GetValueById(string id)
        {
            EmprestadoDto r = new EmprestadoDto();
            var Emprestado = _unit.Emprestado.GetValueById(id);
            if (Emprestado != null)
            {
                r = _mapper.Map<EmprestadoDto>(Emprestado);
            }
            return r;
        }

        public async Task<EmprestadoLst> Filtro(int IniciaEm, int QtdLinhas, string sIdLivro = "", string IdCliente = "", string ColunaOrdenar = "Cliente", string Direcao = "ASC")
        {
            EmprestadoLst r = new EmprestadoLst();
            Guid IdLivro = Guid.Empty;
            if (!string.IsNullOrEmpty(sIdLivro.Trim()))
            {
                IdLivro = new Guid(sIdLivro);
            }
            return _unit.Emprestado.Filtrar(IniciaEm, QtdLinhas, IdCliente, IdLivro, ColunaOrdenar, Direcao);
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
