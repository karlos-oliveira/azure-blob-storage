using ServicoBlob.Models;
using ServicoBlob.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBlob.Infra.Data.Repository
{

    public class InformacaoArquivoRepository : IInformacaoArquivoRepository
    {
        private readonly IContext _context;

        public InformacaoArquivoRepository(IContext context)
        {
            _context = context;
        }

        public InformacaoArquivo ConsultarInformacaoArquivo(Guid IdInformacaoArquivo)
        {
            return _context.InformacaoArquivo.Where(x => x.Id == IdInformacaoArquivo).First();
        }

        public List<InformacaoArquivo> ConsultarInformacaoArquivos()
        {
            return _context.InformacaoArquivo.ToList();
        }

        public void CriarInformacaoArquivo(InformacaoArquivo inputs)
        {
            _context.InformacaoArquivo.Add(inputs);
            _context.Commit();
        }

        public void DeletarInformacaoArquivo(Guid IdInformacaoArquivo)
        {
            _context.InformacaoArquivo.Remove(_context.InformacaoArquivo.Find(IdInformacaoArquivo));
            _context.Commit();
        }

        public void EditarInformacaoArquivo(InformacaoArquivo inputs)
        {
            _context.InformacaoArquivo.Update(inputs);
            _context.Commit();
        }
    }

}
