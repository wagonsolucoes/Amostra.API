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
    public class EmprestadoController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;

        public EmprestadoController(AmostraContext context, IMapper mapper, IUnit unit)
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
                var Emprestado = _unit.Emprestado.GetValueById(id);
                if (Emprestado == null)
                {
                    return NotFound();
                }
                var dto = _mapper.Map<EmprestadoDto>(Emprestado);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Filtro/{IniciaEm}/{QtdLinhas}/{sIdLivro}/{IdCliente}/{ColunaOrdenar}/{Direcao}")]
        [Authorize(Roles = "Administrator,Emprestado")]
        [HttpGet]
        public async Task<IActionResult> Filtro(int IniciaEm, int QtdLinhas, string sIdLivro = "", string IdCliente = "", string ColunaOrdenar = "Cliente", string Direcao = "ASC")
        {
            try
            {
                Guid IdLivro = Guid.Empty;
                if (!string.IsNullOrEmpty(sIdLivro.Trim()))
                {
                    IdLivro = new Guid(sIdLivro);
                }
                return Ok(_unit.Emprestado.Filtrar(IniciaEm, QtdLinhas, IdCliente, IdLivro, ColunaOrdenar, Direcao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [Route("Add")]
        [Authorize(Roles = "Administrator,Emprestado")]
        [HttpPost]
        public async Task<IActionResult> Add(EmprestadoVm model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                model.Ativo = true;
                model.Dh = DateTime.Now;
                var validator = new EmprestadoValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _unit.Emprestado.Add(_mapper.Map<Emprestado>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [Route("Update")]
        [Authorize(Roles = "Administrator,Emprestado")]
        [HttpPut]
        public async Task<IActionResult> Update(EmprestadoVm model)
        {
            List<Emprestado> Emprestados = new List<Emprestado>();
            Emprestado Emprestado = new Emprestado();
            try
            {
                var validator = new EmprestadoValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _unit.Emprestado.Update(_mapper.Map<Emprestado>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Emprestados);
        }

        [Route("Delete/{id}")]
        [Authorize(Roles = "Administrator,Emprestado")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var model = _unit.Emprestado.Find(x => x.Id == id).FirstOrDefault();
                if (model == null)
                {
                    return Ok();
                }
                _unit.Emprestado.Delete(model);
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
