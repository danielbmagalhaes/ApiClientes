using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiClientes.App.Models.Base
{
    public class ApiClientesDbContext : DbContext
    {
        public ApiClientesDbContext(DbContextOptions<ApiClientesDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Mapeando Entidade Cliente
            builder.Entity<Cliente>().ToTable("Cliente");
            builder.Entity<Cliente>().HasKey(p => p.Id);
            builder.Entity<Cliente>().Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Entity<Cliente>().Property(p => p.CPF).IsRequired().HasMaxLength(14);
            builder.Entity<Cliente>().Property(p => p.Nascimento).IsRequired();
            builder.Entity<Cliente>().Property(p => p.CreatedAt);
            builder.Entity<Cliente>().Property(p => p.UpdatedAt);

            //Mapeando Entidade Endereco
            builder.Entity<Endereco>().ToTable("Endereco");
            builder.Entity<Endereco>().HasKey(p => p.Id);
            builder.Entity<Endereco>().Property(p => p.Logradouro).IsRequired().HasMaxLength(50);
            builder.Entity<Endereco>().Property(p => p.Bairro).IsRequired().HasMaxLength(40);
            builder.Entity<Endereco>().Property(p => p.Cidade).IsRequired().HasMaxLength(40);
            builder.Entity<Endereco>().Property(p => p.Estado).IsRequired().HasMaxLength(40);
            builder.Entity<Endereco>().Property(p => p.CreatedAt);
            builder.Entity<Endereco>().Property(p => p.UpdatedAt);

            //Relacionamento Cliente Endereco
            builder.Entity<Endereco>()
                .HasOne(c => c.Cliente)
                .WithMany(e => e.Enderecos)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
