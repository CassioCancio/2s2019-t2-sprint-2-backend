using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.M_AutoPecas.WebApi.Domains
{
    public partial class AutoPecasContext : DbContext
    {
        public AutoPecasContext()
        {
        }

        public AutoPecasContext(DbContextOptions<AutoPecasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Pecas> Pecas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=M_AutoPecas;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Forneced__AA57D6B4E3F38398")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco)
                    .HasName("UQ__Forneced__4DF3E1FFC40DFFB0")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial)
                    .HasName("UQ__Forneced__448779F0949D9850")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fornecedores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Fornecedo__IdUsu__59FA5E80");
            });

            modelBuilder.Entity<Pecas>(entity =>
            {
                entity.HasKey(e => e.IdPeca);

                entity.HasIndex(e => e.CodigoPeca)
                    .HasName("UQ__Peças__B9F4770F67F35F09")
                    .IsUnique();

                entity.Property(e => e.CodigoPeca)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdFonecedorNavigation)
                    .WithMany(p => p.Peças)
                    .HasForeignKey(d => d.IdFonecedor)
                    .HasConstraintName("FK__Peças__IdFoneced__5DCAEF64");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534C3F39D9D")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuarios__7ABB9731BE1FDE66")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
