using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasyCRUDTeste.Models
{
    public partial class ANGULARCRUDContext : DbContext
    {
        public virtual DbSet<Experiencia> Experiencia { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=MATIAS\SQLEXPRESS;Initial Catalog=ANGULARCRUD;Integrated Security=False;User ID=sa;Password=senha1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experiencia>(entity =>
            {
                entity.HasKey(e => new { e.IdExperiencia, e.IdPessoa })
                    .HasName("PK_EXPERIENCIA");

                entity.Property(e => e.IdExperiencia).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome).HasColumnType("varchar(128)");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Experiencia)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EXPERIEN_REFERENCE_PESSOA");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK_PESSOA");

                entity.Property(e => e.Agencia).HasColumnType("varchar(128)");

                entity.Property(e => e.Cidade).HasColumnType("varchar(128)");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Disponibilidade).HasColumnType("varchar(128)");

                entity.Property(e => e.Email).HasColumnType("varchar(128)");

                entity.Property(e => e.Estado).HasColumnType("varchar(128)");

                entity.Property(e => e.Horario).HasColumnType("varchar(128)");

                entity.Property(e => e.Nome).HasColumnType("varchar(128)");

                entity.Property(e => e.NomeBanco).HasColumnType("varchar(128)");

                entity.Property(e => e.NomePessoaBanco).HasColumnType("varchar(128)");

                entity.Property(e => e.NrConta).HasColumnType("varchar(128)");

                entity.Property(e => e.Opconta)
                    .HasColumnName("OPConta")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Portfolio).HasColumnType("varchar(128)");

                entity.Property(e => e.Skype).HasColumnType("varchar(128)");

                entity.Property(e => e.Telefone).HasColumnType("varchar(128)");

                entity.Property(e => e.TipoConta).HasColumnType("varchar(128)");
            });
        }
    }
}