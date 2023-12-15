using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.ViewModel.Amostra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Amostra.API.ViewModel;
using RestSharp;
using Amostra.API.Repository;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;

        public LivroController(AmostraContext context, IMapper mapper, IUnit unit)
        {
            _context = context;
            _mapper = mapper;
            _unit = unit;
        }

        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValueById(string id)
        {
            try
            {
                var Livro = _unit.Livro.GetValueById(id);
                if (Livro == null)
                {
                    return NotFound();
                }
                var dto = _mapper.Map<LivroDto>(Livro);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Filtro")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpGet]
        public async Task<IActionResult> Filtro(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            LivroLst retorno = new LivroLst();
            try
            {
                return Ok(_unit.Livro.Filtrar(IniciaEm, QtdLinhas, TermoBusca, ColunaOrdenar, Direcao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [Route("Livro/Add")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpPost]
        public async Task<IActionResult> Add(LivroVm model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                model.Ativo = true;
                var validator = new LivroValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _unit.Livro.Add(_mapper.Map<Livro>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [Route("Livro/Update")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpPost]
        public async Task<IActionResult> Update(LivroVm model)
        {
            List<Livro> Livros = new List<Livro>();
            Livro Livro = new Livro();
            try
            {
                var validator = new LivroValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _unit.Livro.Update(_mapper.Map<Livro>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Livros);
        }

        [Route("Livro/Delete")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpDelete]
        public async Task<IActionResult> Delete(LivroVm model)
        {
            Livro Livro = new Livro();
            try
            {
                var validator = new LivroValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _unit.Livro.Delete(_mapper.Map<Livro>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
