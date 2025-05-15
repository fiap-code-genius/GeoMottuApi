using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace GeoMottuApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilialController : ControllerBase
    {
        private readonly IFilialApplicationService _service;

        public FilialController(IFilialApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma filial", Description = "Endpoint destinado ao cadastro das filiais da Mottu e seus países respectivos")]
        [Produces<FilialEntity>]
        public IActionResult Post([FromBody] FilialEntity entity)
        {
            try
            {
                var objModel = _service.SalvarDadosFilial(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista de todas as filiais", Description = "Endpoint que busca todas as filiais cadastrados no banco de dados e as devolve com todas as informações")]
        [Produces<IEnumerable<FilialEntity>>]
        public IActionResult Get()
        {
            var objModel = _service.ObterTodasAsFiliais();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca uma Filial pelo id", Description = "Este endpoint busca uma filial pelo seu id do banco de dados devolvendo os dados da filial correspondente")]
        [Produces<MotoEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _service.ObterFilialPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("pais/{pais}")]
        [SwaggerOperation(Summary = "Busca filiais pelo país", Description = "Endpoint feito com a finalidade de encontrar todas as filiais de um país específico(Brasil e México)")]
        [Produces<IEnumerable<MotoEntity>>]
        public IActionResult GetPorModelo(PaisesFiliais pais)
        {
            var objModel = _service.ObterFiliaisPorPais(pais);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível recuperar os dados");
        }

        [HttpPut("update/{id}")]
        [SwaggerOperation(Summary = "Atualização de filial", Description = "Endpoint cuja finalidade é receber um id de uma filial e atualizar a mesma con os dados que o usuário entregar")]
        [Produces<MotoEntity>]
        public IActionResult Put(int id, [FromBody] FilialEntity entity)
        {
            try
            {
                var objModel = _service.EditarDadosFilial(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpDelete("delete/{id}")]
        [SwaggerOperation(Summary = "Deletar informações da Filial", Description = "Endpoint em que se coleta o id de uma filial e deleta a correspondente")]
        [Produces<MotoEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _service.DeletarFilial(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
