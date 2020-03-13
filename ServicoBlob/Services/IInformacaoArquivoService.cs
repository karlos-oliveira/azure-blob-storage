using ServicoBlob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBlob.Services
{

    public interface IInformacaoArquivoService
    {
        Guid CriarInformacaoArquivo(InformacaoArquivo inputs);
        InformacaoArquivo ConsultarInformacaoArquivo(Guid IdInformacaoArquivo, bool isThumb = false);
        InformacaoArquivo ConsultarMetadadoInformacaoArquivo(Guid IdInformacaoArquivo);
        List<InformacaoArquivo> ConsultarInformacaoArquivos();
        void EditarInformacaoArquivo(InformacaoArquivo inputs);
        void DeletarInformacaoArquivo(Guid IdInformacaoArquivo);
    }

}
