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
using Amostra.API.ViewModel.Amostra.Validation;
using AutoMapper;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;

        public ClientesController(AmostraContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Clientes
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{Page}/{Rows}/{ValFilter}/{ColOrder}/{ColDirectrion}")]
        public async Task<IActionResult> GetClientes(int Page, int Rows, string? ValFilter, string ColOrder, string ColDirectrion)
        {
            List<DtoCliente> dto = new List<DtoCliente>();
            ListagemCliente retorno = new ListagemCliente();
            try
            {

                if (_context.Clientes == null)
                {
                    return NotFound();
                }

                var tt = await _context.Clientes.ToListAsync();
                retorno.ttRows = tt.Count;

                IQueryable<Cliente> resultado = _context.Clientes;
                int Pula = 0;
                if (Page > 1)
                {
                    Pula = (Page - 1) * Rows;
                }
                resultado = resultado.Skip(Pula);
                resultado = resultado.Take(Rows);

                #region WHERE
                resultado = resultado.Where(p => p.Ativo == true);
                resultado = resultado.Where(p => p.Deleted == false);
                if (!string.IsNullOrEmpty(ValFilter))
                {
                    resultado = resultado.Where(p => p.Nome.Contains(ValFilter));
                }
                #endregion

                #region ORDER BY
                if (ColOrder == "Nome" || string.IsNullOrEmpty(ColOrder))
                {
                    if (ColDirectrion == "" || ColDirectrion == "ASC")
                    {
                        resultado = resultado.OrderBy(p => p.Nome);
                    }
                    else
                    {
                        resultado = resultado.OrderByDescending(p => p.Nome);
                    }
                }
                if (ColOrder == "Bairro")
                {
                    if (ColDirectrion == "" || ColDirectrion == "ASC")
                    {
                        resultado = resultado.OrderBy(p => p.Bairro);
                    }
                    else
                    {
                        resultado = resultado.OrderByDescending(p => p.Bairro);
                    }
                }
                if (ColOrder == "Localidade")
                {
                    if (ColDirectrion == "" || ColDirectrion == "ASC")
                    {
                        resultado = resultado.OrderBy(p => p.Localidade);
                    }
                    else
                    {
                        resultado = resultado.OrderByDescending(p => p.Localidade);
                    }
                }
                if (ColOrder == "Uf")
                {
                    if (ColDirectrion == "" || ColDirectrion == "ASC")
                    {
                        resultado = resultado.OrderBy(p => p.Uf);
                    }
                    else
                    {
                        resultado = resultado.OrderByDescending(p => p.Uf);
                    }
                }
                #endregion

                retorno.lst = _mapper.Map<List<DtoCliente>>(resultado);
            }
            catch(Exception ex)
            {
                retorno.msgEx = ex.Message;
            }
            return Ok(retorno);
        }

        // GET: api/Clientes/5
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(string id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DtoCliente>(cliente));
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(VMCliente model)
        {
            Cliente cliente = new Cliente();
            var validator = new ClienteValidator();
            var answerValidation = validator.Validate(model);
            if (!answerValidation.IsValid)
            {
                return BadRequest(answerValidation.Errors);
            }
            _context.Entry(_mapper.Map<Cliente>(model)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ClienteExists(cliente.CpfCnpj))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }

            return Ok();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpPost]
        public async Task<IActionResult> PostCliente(VMCliente model)
        {
            Cliente cliente = new Cliente();
            try
            {
                if (_context.Clientes == null)
                {
                    return Problem("Entity set 'AmostraContext.Clientes'  is null.");
                }
                var validator = new ClienteValidator();
                var answerValidation = validator.Validate(model);
                if (!answerValidation.IsValid)
                {
                    return BadRequest(answerValidation.Errors);
                }
                _context.Clientes.Add(_mapper.Map<Cliente>(model));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.CpfCnpj))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // DELETE: api/Clientes/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(string id)
        {
            return (_context.Clientes?.Any(e => e.CpfCnpj == id)).GetValueOrDefault();
        }
    }
}
