using System;
using System.Collections.Generic;

namespace Amostra.API.Models.Amostra;

public partial class Cliente
{
    public string CpfCnpj { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Complemento { get; set; }

    public string Bairro { get; set; } = null!;

    public string Localidade { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public DateTime? Nascimento { get; set; }

    public int? Idade { get; set; }

    public bool? Ativo { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<Emprestado> Emprestados { get; set; } = new List<Emprestado>();
}
