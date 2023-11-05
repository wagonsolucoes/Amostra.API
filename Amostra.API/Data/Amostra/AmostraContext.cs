using System;
using System.Collections.Generic;
using Amostra.API.Models.Amostra;
using Microsoft.EntityFrameworkCore;

namespace Amostra.API.Data.Amostra;

public partial class AmostraContext : DbContext
{
    public AmostraContext()
    {
    }

    public AmostraContext(DbContextOptions<AmostraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CpfCnpj).HasName("PK__Cliente__0BCA032B56169987");

            entity.ToTable("Cliente");

            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Bairro)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Complemento)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Email)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.Localidade)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Logradouro)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
