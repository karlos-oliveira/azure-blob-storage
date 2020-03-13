using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoBlob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBlob.Infra.Data.Configurations
{
    public class InformacaoArquivoConfiguration : IEntityTypeConfiguration<InformacaoArquivo>
    {
        public void Configure(EntityTypeBuilder<InformacaoArquivo> builder)
        {
            builder.ToTable("InformacaoArquivo");

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.IdUsuario).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.ContentType).IsRequired();
            builder.Property(x => x.Tamanho).IsRequired();
            builder.Property(x => x.Container).IsRequired();
            //builder.Property(x => x.IdConta).IsRequired();
            builder.Ignore(x => x.Conteudo);
            builder.Ignore(x => x.ConteudoThumb);

            builder.HasKey(x => x.Id);
        }
    }
}