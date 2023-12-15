using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.Repository;
using AutoMapper;

namespace Amostra.API.Repository
{
    public class Unit: IUnit
    {
        private readonly AmostraContext _ctx;
        private ClientesRepository _cliente;
        private readonly IMapper _mapper;

        public Unit(AmostraContext ctx, IMapper mapper) { 
            _ctx = ctx;
            _mapper = mapper;
            Cliente = new ClientesRepository(_ctx, _mapper);
            Emprestado = new EmprestadoRepository(_ctx, _mapper);
            Livro = new LivroRepository(_ctx, _mapper);
        }

        public IClienteRepository Cliente { get; private set; }
        public IEmprestadoRepository Emprestado { get; private set; }
        public ILivroRepository Livro { get; private set; }

        public int Salvar()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
