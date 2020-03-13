using ServicoBlob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBlob.Infra.Data.Repository
{

    public interface IInformacaoArquivoRepository
    {
        void CriarInformacaoArquivo(InformacaoArquivo inputs);
        InformacaoArquivo ConsultarInformacaoArquivo(Guid IdInformacaoArquivo);
        List<InformacaoArquivo> ConsultarInformacaoArquivos();
        void EditarInformacaoArquivo(InformacaoArquivo inputs);
        void DeletarInformacaoArquivo(Guid IdInformacaoArquivo);
    }

}
