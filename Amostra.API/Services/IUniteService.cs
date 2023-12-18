using Amostra.API.Repository;

namespace Amostra.API.Services
{
    public interface IUniteService
    {
        IClientesService ClienteSrv { get; }

        IEmprestadoService EmprestadoSrv { get; }

        ILivroService LivroSrv { get; }

        void Dispose();
    }
}
