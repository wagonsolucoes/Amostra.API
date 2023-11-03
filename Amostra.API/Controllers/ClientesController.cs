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

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AmostraContext _context;

        public ClientesController(AmostraContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{Page}/{Rows}/{ValFilter}/{ColOrder}/{ColDirectrion}")]
        public async Task<ActionResult<DtoCliente>> GetClientes(int Page, int Rows, string? ValFilter, string ColOrder, string ColDirectrion)
        {
            DtoCliente dto = new DtoCliente();
            try
            {

                if (_context.Clientes == null)
                {
                    return NotFound();
                }

                var tt = await _context.Clientes.ToListAsync();
                dto.ttRows = tt.Count;

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

                dto.lst = resultado.ToList();
            }
            catch(Exception ex)
            {
                dto.msgEx = ex.Message;
            }
            return dto;
        }

        // GET: api/Clientes/5
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(string id)
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

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(string id, Cliente cliente)
        {
            if (id != cliente.CpfCnpj)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'AmostraContext.Clientes'  is null.");
            }
            _context.Clientes.Add(cliente);
            try
            {
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

            return CreatedAtAction("GetCliente", new { id = cliente.CpfCnpj }, cliente);
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
