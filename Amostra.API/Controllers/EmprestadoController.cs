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
using Amostra.API.Services;
using FluentValidation.Results;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestadoController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;
        private IUniteService _srv;

        public EmprestadoController(AmostraContext context, IMapper mapper, IUnit unit)
        {
            _context = context;
            _mapper = mapper;
            _unit = unit;
            _srv = new UniteService(_context, _mapper, _unit);
        }

        [Route("Filtro/{IniciaEm}/{QtdLinhas}/{sIdLivro}/{IdCliente}/{ColunaOrdenar}/{Direcao}")]
        [Authorize(Roles = "Administrator,Emprestado")]
        [HttpGet]
        public async Task<IActionResult> GetFiltro(int IniciaEm, int QtdLinhas, string sIdLivro = "", string IdCliente = "", string ColunaOrdenar = "Cliente", string Direcao = "ASC")
        {
            EmprestadoLst r = new EmprestadoLst();
            try
            {
                Guid IdLivro = Guid.Empty;
                if (!string.IsNullOrEmpty(sIdLivro.Trim()))
                {
                    IdLivro = new Guid(sIdLivro);
                }
                r.ttRows = await _srv.EmprestadoSrv.FiltrarCount(IdCliente, IdLivro);
                r.lst = await _srv.EmprestadoSrv.FiltrarList(IniciaEm, QtdLinhas, IdCliente, IdLivro, ColunaOrdenar, Direcao);
                return Ok(r);
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
                return Ok(await _srv.EmprestadoSrv.Add(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update")]
        [Authorize(Roles = "Administrator,Emprestado")]
        [HttpPut]
        public async Task<IActionResult> Update(EmprestadoVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            try
            {
                r = await _srv.EmprestadoSrv.Update(model);
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete/{id}")]
        [Authorize(Roles = "Administrator,Emprestado")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _srv.EmprestadoSrv.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
