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
using System.Runtime.CompilerServices;
using Amostra.API.Services;
using FluentValidation.Results;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;
        private IUniteService _srv;

        public ClientesController(AmostraContext context, IMapper mapper, IUnit unit, IUniteService srv)
        {
            _context = context;
            _mapper = mapper;
            _unit = unit;
            _srv = new UniteService(_context, _mapper, _unit);
        }
        
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{IniciaEm}/{QtdLinhas}/{TermoBusca}/{ColunaOrdenar}/{Direcao}")]
        public async Task<IActionResult> GetFiltro(int IniciaEm, int QtdLinhas, string TermoBusca = " ", string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            ClienteLst r = new ClienteLst();
            try
            {
                r.ttRows = await _srv.ClienteSrv.FiltrarCount(TermoBusca);
                r.lst = _mapper.Map<List<ClienteDto>>(await _srv.ClienteSrv.FiltrarList(IniciaEm, QtdLinhas, TermoBusca, ColunaOrdenar, Direcao));
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [Authorize(Roles = "Administrator,Cliente")]
        [Route("DdlCliente")]
        [HttpGet]
        public async Task<IActionResult> GetDdlCliente()
        {
            try
            {
                return Ok(await _srv.ClienteSrv.GetDdlCliente());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Add")]
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpPost]
        public async Task<IActionResult> Add(ClienteVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            try
            {             
                r = await _srv.ClienteSrv.Add(model);
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(ClienteVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            try
            {
                r = await _srv.ClienteSrv.Update(model);
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [Route("Delete/{id}")]
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await _srv.ClienteSrv.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Cliente/ViaCep/{cep}")]
        [HttpGet]
        public async Task<Viacep?> ViaCep(string cep)
        {
            Viacep? vc = new Viacep();
            try
            {
                vc = await _srv.ClienteSrv.ViaCep(cep);
            }
            catch (Exception ex)
            {
                vc = new Viacep();
            }
            return vc;
        }
    }
}
