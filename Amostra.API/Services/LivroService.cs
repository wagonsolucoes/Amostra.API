using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.Repository;
using Amostra.API.ViewModel;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Amostra.API.Services
{
    public class LivroService: ILivroService
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;

        public LivroService(AmostraContext context, IMapper mapper, IUnit unit)
        {
            _context = context;
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<Livro> GetLivro(Guid Id)
        {
            return await _unit.Livro.GetLivro(Id);
        }

        public async Task<int> FiltrarCount(string TermoBusca = " ")
        {
            return await _unit.Livro.FiltrarCount(TermoBusca);
        }

        public async Task<List<Livro>> FiltrarList(int IniciaEm, int QtdLinhas, string TermoBusca = " ", string ColunaOrdenar = "Titulo", string Direcao = "ASC")
        {
            return await _unit.Livro.FiltrarLista(IniciaEm, QtdLinhas, TermoBusca, ColunaOrdenar, Direcao);
        }

        public async Task<List<SelectDto>> GetDdlLivro()
        {
            return await _unit.Livro.GetDDL();
        }

        public async Task<List<ValidationFailure>> Add(LivroVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            model.Id = Guid.NewGuid();
            model.Ativo = true;
            var validator = new LivroValidator();
            var answerValidation = validator.Validate(model);
            if (!answerValidation.IsValid)
            {
                r = answerValidation.Errors;
            }
            else
            {
                _unit.Livro.Add(_mapper.Map<Livro>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            return r;
        }

        public async Task<List<ValidationFailure>> Update(LivroVm model)
        {
            List<Livro> Livros = new List<Livro>();
            Livro Livro = new Livro();
            List<ValidationFailure> r = new List<ValidationFailure>();
            var validator = new LivroValidator();
            var answerValidation = validator.Validate(model);
            if (!answerValidation.IsValid)
            {
                r = answerValidation.Errors;
            }
            else
            {
                _unit.Livro.Update(_mapper.Map<Livro>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            return r;
        }

        public async Task<bool> Delete(Guid id)
        {
            bool r = false;
            var model = _unit.Livro.Find(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                _unit.Livro.Delete(model);
                _unit.Salvar();
                _unit.Dispose();
                r = true;
            }            
            return r;
        }
    }
}
