using Amostra.API.Data.Amostra;
using Amostra.API.Models.Amostra;
using Amostra.API.Repository;
using AutoMapper;

namespace Amostra.API.Services
{
    public class UniteService : IUniteService
    {
        private readonly AmostraContext _ctx;
        private ClientesService _cliente;
        private IUnit _unit;

        public UniteService(AmostraContext ctx, IMapper mapper, IUnit unit)
        {
            _ctx = ctx;
            _unit = unit;
            ClienteSrv = new ClientesService(_ctx, mapper, _unit);
        }

        public IClientesService ClienteSrv { get; private set; }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
