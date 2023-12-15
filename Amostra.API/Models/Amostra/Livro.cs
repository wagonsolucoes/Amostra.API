using System;
using System.Collections.Generic;

namespace Amostra.API.Models.Amostra;

public partial class Livro
{
    public Guid Id { get; set; }

    public DateTime DhCompra { get; set; }

    public string Titulo { get; set; } = null!;

    public string Prefacio { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Editora { get; set; } = null!;

    public DateTime? DhExtravio { get; set; }

    public bool? Extraviado { get; set; }

    public bool Emprestado { get; set; }

    public bool Ativo { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<Emprestado> Emprestados { get; set; } = new List<Emprestado>();
}
