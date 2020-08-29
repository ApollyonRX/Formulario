using FormularioProjeto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Banco.configMapping
{
    public class contaMap: IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("ContasBet", "Invest");
            builder.HasIndex(x => x.ContaId);
        }
    }
}
