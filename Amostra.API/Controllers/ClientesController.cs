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
    public class ClientesController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IUnit _unit;

        public ClientesController(AmostraContext context, IMapper mapper, IUnit unit)
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
                var cliente = _unit.Cliente.GetValueById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                var dto = _mapper.Map<ClienteDto>(cliente);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{IniciaEm}/{QtdLinhas}/{TermoBusca}/{ColunaOrdenar}/{Direcao}")]
        public async Task<IActionResult> GetFiltro(int IniciaEm, int QtdLinhas, string TermoBusca = " ", string ColunaOrdenar = "Nome", string Direcao = "ASC")
        {
            ClienteLst retorno = new ClienteLst();
            try
            {
                return Ok(_unit.Cliente.Filtrar(IniciaEm, QtdLinhas, TermoBusca, ColunaOrdenar, Direcao));
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
                return Ok(_unit.Cliente.GetDdlCliente());
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
            try
            {
                var validator = new ClienteValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _unit.Cliente.Add(_mapper.Map<Cliente>(model));
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
        [HttpPut]
        public async Task<IActionResult> Update(ClienteVm model)
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();
            try
            {
                var validator = new ClienteValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _unit.Cliente.Update(_mapper.Map<Cliente>(model));
                _unit.Salvar();
                _unit.Dispose();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(clientes);
        }

        [Route("Delete/{id}")]
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var model = _unit.Cliente.GetValueById(id);
                if(model == null)
                {
                    return Ok();
                }
                _unit.Cliente.Delete(model);
                _unit.Salvar();
                _unit.Dispose();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [Route("Cliente/ViaCep/{cep}")]
        [HttpGet]
        public async Task<Viacep> ViaCep(string cep)
        {
            Viacep? vc = new Viacep();
            try
            {
                string url = "https://viacep.com.br";
                var client = new RestClient(url);
                var request = new RestRequest("/ws/" + cep.Replace("-", "") + "/json/", Method.Get);
                vc = client.Execute<Viacep>(request).Data;
            }
            catch (Exception ex)
            {
                vc = new Viacep();
            }
            return vc;
        }
    }
}
