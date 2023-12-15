using System;
using System.Collections.Generic;

namespace Amostra.API.Models.Amostra;

public partial class Emprestado
{
    public Guid Id { get; set; }

    public string IdCliente { get; set; } = null!;

    public Guid IdLivro { get; set; }

    public DateTime Dh { get; set; }

    public DateTime? DhDevolucao { get; set; }

    public int? DiasEmprestado { get; set; }

    public bool Ativo { get; set; }

    public bool Deleted { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Livro IdLivroNavigation { get; set; } = null!;
}
