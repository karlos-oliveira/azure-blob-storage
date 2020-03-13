using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicoBlob.Models;
using ServicoBlob.Services;

namespace ServicoBlob.Controllers
{

    [Route("api/v1/arquivos")]
    [ApiController]
    public class InformacaoArquivoController : ControllerBase
    {
        private readonly IInformacaoArquivoService _serv;

        public InformacaoArquivoController(IInformacaoArquivoService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        [RequestSizeLimit(52428800)]
        public ActionResult CriarInformacaoArquivo([FromBody] InformacaoArquivo inputs)
        {
            try
            {
                //inputs.IdConta = Request.ObterIdConta();
                inputs.IdUsuario = Request.ObterIdUsuario();

               var idNovoArquivo = _serv.CriarInformacaoArquivo(inputs);
                
                return Ok(idNovoArquivo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo arquivo: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idInformacaoArquivo}")]
        public ActionResult ConsultarInformacaoArquivo([FromRoute] Guid IdInformacaoArquivo)
        {
            try
            {
                var response = _serv.ConsultarInformacaoArquivo(IdInformacaoArquivo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o arquivo {IdInformacaoArquivo}: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idInformacaoArquivo}/thumbnail")]
        public ActionResult ConsultarInformacaoArquivoThumb([FromRoute] Guid IdInformacaoArquivo)
        {
            try
            {
                var response = _serv.ConsultarInformacaoArquivo(IdInformacaoArquivo, true);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o thumbnail do arquivo {IdInformacaoArquivo}: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("MultiplosArquivos")]
        [RequestSizeLimit(52428800)]
        public ActionResult MultiplosArquivos([FromBody] List<Guid> IdsArquivos)
        {
            try
            {
                var infos = new List<InformacaoArquivo>();

                //por razões de performance, no momento este método só trará os thumbnails
                //caso haja necessidade pode ser separado em 2 métodos um para thumb e outro para arquivos
                IdsArquivos.ForEach(id => infos.Add(_serv.ConsultarInformacaoArquivo(id, true)));

                return Ok(infos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar os thumbnails dos arquivos enviados: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idInformacaoArquivo}/metadados")]
        public ActionResult ConsultarMetadadoInformacaoArquivo([FromRoute] Guid IdInformacaoArquivo)
        {
            try
            {
                var response = _serv.ConsultarMetadadoInformacaoArquivo(IdInformacaoArquivo);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o arquivo {IdInformacaoArquivo}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarInformacaoArquivos()
        {
            try
            {
                var response = _serv.ConsultarInformacaoArquivos();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar os arquivos: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarInformacaoArquivo([FromBody] InformacaoArquivo inputs)
        {
            try
            {
                _serv.EditarInformacaoArquivo(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o arquivo {inputs.Id}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idInformacaoArquivo}")]
        public ActionResult DeletarInformacaoArquivo([FromRoute] Guid IdInformacaoArquivo)
        {
            try
            {
                //var IdConta = Request.ObterIdConta();
                _serv.DeletarInformacaoArquivo(IdInformacaoArquivo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o arquivo {IdInformacaoArquivo}: {ex.Message}");
            }
        }
    }

}