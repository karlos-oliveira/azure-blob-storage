using ServicoBlob.Infra.Data.Repository;
using ServicoBlob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ServicoBlob.Services
{

    public class InformacaoArquivoService : IInformacaoArquivoService
    {
        public IConfiguration Configuration { get; }

        private readonly IInformacaoArquivoRepository _repo;
        public InformacaoArquivoService(IInformacaoArquivoRepository repo, IConfiguration _conf)
        {
            _repo = repo;
            Configuration = _conf;
        }

        public InformacaoArquivo ConsultarInformacaoArquivo(Guid IdInformacaoArquivo, bool isThumb = false)
        {
            string storageConnectionString = Configuration.GetConnectionString("AzureConnection");
            InformacaoArquivo info = _repo.ConsultarInformacaoArquivo(IdInformacaoArquivo);

            CloudStorageAccount account;

            if (CloudStorageAccount.TryParse(storageConnectionString, out account))
            {
                CloudBlobClient serviceClient = account.CreateCloudBlobClient();

                var container = serviceClient.GetContainerReference(info.Container.ToLower());

                CloudBlockBlob blob;
                MemoryStream arquivo;

                blob = container.GetBlockBlobReference((isThumb ? string.Concat(info.Id.ToString(), "_thumb") : info.Id.ToString()));
                arquivo = new MemoryStream(blob.StreamWriteSizeInBytes);
                blob.DownloadToStreamAsync(arquivo).Wait();
                
                if (isThumb)
                    info.ConteudoThumb = arquivo.ToArray();
                else
                    info.Conteudo = arquivo.ToArray();
            }

            return info;
        }

        public InformacaoArquivo ConsultarMetadadoInformacaoArquivo(Guid IdInformacaoArquivo)
        {
            return _repo.ConsultarInformacaoArquivo(IdInformacaoArquivo);
        }

        public List<InformacaoArquivo> ConsultarInformacaoArquivos()
        {
            return _repo.ConsultarInformacaoArquivos();
        }

        public Guid CriarInformacaoArquivo(InformacaoArquivo inputs)
        {
            string storageConnectionString = Configuration.GetConnectionString("AzureConnection");
            inputs.Id = Guid.NewGuid();

            CloudStorageAccount account;

            if(CloudStorageAccount.TryParse(storageConnectionString, out account))
            {
                CloudBlobClient serviceClient = account.CreateCloudBlobClient();

                var container = serviceClient.GetContainerReference(inputs.Container.ToLower());
                container.CreateIfNotExistsAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference(inputs.Id.ToString());
                Stream arq = new MemoryStream(inputs.Conteudo);
                blob.UploadFromStreamAsync(arq).Wait();

                if(inputs.ConteudoThumb != null && inputs.ConteudoThumb.Length > 0)
                {
                    CloudBlockBlob blobThumb = container.GetBlockBlobReference(string.Concat(inputs.Id.ToString(), "_thumb"));
                    Stream arqThumb = new MemoryStream(inputs.ConteudoThumb);
                    blobThumb.UploadFromStreamAsync(arqThumb).Wait();
                }

                _repo.CriarInformacaoArquivo(inputs);

                return inputs.Id;
            }
            else
                throw new Exception("Problema ao recuperar a conta de armazenamento");

        }

        public void DeletarInformacaoArquivo(Guid IdInformacaoArquivo)
        {
            string storageConnectionString = Configuration.GetConnectionString("AzureConnection");
            InformacaoArquivo info = _repo.ConsultarInformacaoArquivo(IdInformacaoArquivo);

            CloudStorageAccount account;

            if (CloudStorageAccount.TryParse(storageConnectionString, out account))
            {
                CloudBlobClient serviceClient = account.CreateCloudBlobClient();

                var container = serviceClient.GetContainerReference(info.Container.ToLower());
                CloudBlockBlob blob = container.GetBlockBlobReference(info.Id.ToString());

                blob.DeleteIfExistsAsync().Wait();

                _repo.DeletarInformacaoArquivo(IdInformacaoArquivo);
            }
        }

        public void EditarInformacaoArquivo(InformacaoArquivo inputs)
        {
            _repo.EditarInformacaoArquivo(inputs);
        }

    }

}
