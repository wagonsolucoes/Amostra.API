using Amostra.API.Repository;

namespace Amostra.API.Services
{
    public interface IUniteService
    {
        IClientesService ClienteSrv { get; }
        void Dispose();
    }
}
