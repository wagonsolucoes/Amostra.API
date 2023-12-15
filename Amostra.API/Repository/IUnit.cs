namespace Amostra.API.Repository
{
    public interface IUnit: IDisposable
    {
        IClienteRepository Cliente { get; }
        IEmprestadoRepository Emprestado { get; }
        ILivroRepository Livro { get; }
        int Salvar();
        void Dispose();
    }
}
