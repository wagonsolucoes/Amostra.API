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

    public virtual DbSet<Emprestado> Emprestados { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-23JD9RF\\WAGONS;Database=Amostra;TrustServerCertificate=True;Trusted_Connection=True; Integrated Security=true;");

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
            entity.Property(e => e.Nascimento).HasColumnType("date");
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

        modelBuilder.Entity<Emprestado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresta__3214EC0764AA5852");

            entity.ToTable("Emprestado");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dh).HasColumnType("datetime");
            entity.Property(e => e.DhDevolucao).HasColumnType("datetime");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(14)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Emprestados)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emprestado_Cliente");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Emprestados)
                .HasForeignKey(d => d.IdLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emprestado_Livro");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro__3214EC074E7EA799");

            entity.ToTable("Livro");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Autor)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.DhCompra).HasColumnType("datetime");
            entity.Property(e => e.DhExtravio).HasColumnType("datetime");
            entity.Property(e => e.Editora)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.Prefacio).IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(350)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
