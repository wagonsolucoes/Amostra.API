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
    public class LivroController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;
        private IUniteService _srv;

        public LivroController(AmostraContext context, IMapper mapper, IUnit unit)
        {
            _context = context;
            _mapper = mapper;
            _unit = unit;
            _srv = new UniteService(_context, _mapper, _unit);
        }

        [Route("Filtro/{IniciaEm}/{QtdLinhas}/{TermoBusca}/{ColunaOrdenar}/{Direcao}/")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpGet]
        public async Task<IActionResult> GetFiltro(int IniciaEm, int QtdLinhas, string TermoBusca = "", string ColunaOrdenar = "Titulo", string Direcao = "ASC")
        {
            LivroLst r = new LivroLst();
            try
            {
                r.ttRows = await _srv.LivroSrv.FiltrarCount(TermoBusca);
                r.lst = _mapper.Map<List<LivroDto>>(await _srv.LivroSrv.FiltrarList(IniciaEm, QtdLinhas, TermoBusca, ColunaOrdenar, Direcao));
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        [Authorize(Roles = "Administrator,Cliente")]
        [Route("DdlLivro")]
        [HttpGet]
        public async Task<IActionResult> GetDdlLivro()
        {
            try
            {
                return Ok(_unit.Livro.GetDDL());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Add")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpPost]
        public async Task<IActionResult> Add(LivroVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            try
            {
                r = await _srv.LivroSrv.Add(model);
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpPut]
        public async Task<IActionResult> Update(LivroVm model)
        {
            List<ValidationFailure> r = new List<ValidationFailure>();
            try
            {
                r = await _srv.LivroSrv.Update(model);
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete/{id}")]
        [Authorize(Roles = "Administrator,Livro")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _srv.LivroSrv.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
