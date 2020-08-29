using AutoMapper.Configuration;
using FormularioProjeto.Banco.configMapping;
using FormularioProjeto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace FormularioProjeto.Banco
{
    public class InvestContext : DbContext
    {
        //private readonly IConfiguration _configuration;

        public InvestContext(DbContextOptions<InvestContext> options ) :base(options)
        {

        }
        //public InvestContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public DbSet<Conta> Conta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e =>
                    e.GetProperties())
                    .Where(property =>
                        property.ClrType == typeof(string))
                    .ToList()
                    .ForEach(property =>
                        property.SetColumnType("varchar(256)"));

            modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e =>
                    e.GetForeignKeys())
                    .ToList()
                    .ForEach(relationship =>
                        relationship.DeleteBehavior = DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new contaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
