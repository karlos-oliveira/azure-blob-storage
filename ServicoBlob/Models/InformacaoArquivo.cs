using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBlob.Models
{
    public class InformacaoArquivo
    {
        public Guid Id { get; set; }
        //public Guid IdConta { get; set; }
        public string Nome { get; set; }
        public double Tamanho { get; set; }
        public string Descricao { get; set; }
        public string ContentType { get; set; }
        public Guid IdUsuario { get; set; }
        public string Container { get; set; }
        public byte[] Conteudo { get; set; }
        public byte[] ConteudoThumb { get; set; }
    }
}
