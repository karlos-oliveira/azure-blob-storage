using Microsoft.EntityFrameworkCore;
using ServicoBlob.Infra.Data.Configurations;
using ServicoBlob.Models;
using ServicoBlob.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBlob.Infra.Data
{
    public class ServicoBlobDbContext : DbContext, IContext
    {
        public ServicoBlobDbContext(DbContextOptions<ServicoBlobDbContext> options) : base(options) { }

        public DbSet<InformacaoArquivo> InformacaoArquivo { get { return this.Set<InformacaoArquivo>(); } }

        public int Commit()
        {
            return this.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return this.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return this.DbSet<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InformacaoArquivoConfiguration());
            
        }
    }
}
