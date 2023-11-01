using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.Models.WagonMail;
using Amostra.API.ViewModel.Amostra;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cliente = Amostra.API.Models.WagonMail.Cliente;

namespace Amostra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AmostraContext _context;
        private readonly IMapper _mapper;
        private IValidator<VMCliente> _validator;


        public ClientesController(IMapper mapper, IValidator<VMCliente> validator, AmostraContext context)
        {
            _mapper = mapper;
            _validator = validator;
            _context = context;
        }

        // GET: api/Clientes
        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VMCliente>>> GetClientes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            return _mapper.Map<List<VMCliente>>(await _context.Clientes.ToListAsync());
        }

        // GET: api/Clientes/5

        [Authorize(Roles = "Administrator,Cliente")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoCliente>> GetCliente(string id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            return _mapper.Map<DtoCliente>(await _context.Clientes.FindAsync(id));
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Roles = "Administrator,Cliente")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(string id, VMCliente model)
        {
            if (model.CpfCnpj.Length < 10)
            {
                return BadRequest();
            }

            ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            _context.Entry(_mapper.Map<Cliente>(model)).State = EntityState.Modified;

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
        public async Task<IActionResult> PostCliente(VMCliente model)
        {
            Models.Amostra.Cliente cliente = new Models.Amostra.Cliente();
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'Clientes'  is null.");
            }
            ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            _context.Clientes.Add(_mapper.Map<Models.Amostra.Cliente>(model));
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostBairro", new { CpfCnpj = cliente.CpfCnpj }, model);
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
