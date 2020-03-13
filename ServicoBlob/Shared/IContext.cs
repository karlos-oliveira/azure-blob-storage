using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ServicoBlob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBlob.Shared
{
    public interface IContext : IDisposable
    {
        DbSet<InformacaoArquivo> InformacaoArquivo { get; }
       
        DatabaseFacade Database { get; }
        DbSet<T> DbSet<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();

    }
}
