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
    public class PatioController : ControllerBase
    {
        private readonly IPatioApplicationService _service;

        public PatioController(IPatioApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um pátio", Description = "Endpoint destinado ao cadastro dos pátios das filiais da Mottu")]
        [Produces<PatioEntity>]
        public IActionResult Post([FromBody] PatioEntity entity)
        {
            try
            {
                var objModel = _service.SalvarDadosPatio(entity);

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
        [SwaggerOperation(Summary = "Lista de todos os pátios", Description = "Endpoint que busca todos os pátios cadastrados e exibe as informações para o usuário por um JSON")]
        [Produces<IEnumerable<PatioEntity>>]
        public IActionResult Get()
        {
            var objModel = _service.ObterTodosOsPatios();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um pátio pelo id", Description = "Este endpoint busca um pátio pelo seu id e exibe suas informações")]
        [Produces<PatioEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _service.ObterPatioPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("tipo/patio/{patio}")]
        [SwaggerOperation(Summary = "Busca os pátios pelo tipo", Description = "Endpoint feito com a finalidade de encontrar todos os pátios comum tipo específico")]
        [Produces<IEnumerable<PatioEntity>>]
        public IActionResult GetPorModelo(TipoPatio patio)
        {
            var objModel = _service.ObterPatiosPorTipo(patio);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível recuperar os dados");
        }

        [HttpPut("update/{id}")]
        [SwaggerOperation(Summary = "Atualização de pátio", Description = "Endpoint cuja finalidade é receber um id de um pátio e atualizar o mesmo com as informações novas")]
        [Produces<PatioEntity>]
        public IActionResult Put(int id, [FromBody] PatioEntity entity)
        {
            try
            {
                var objModel = _service.EditarDadosPatio(id, entity);

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
        [SwaggerOperation(Summary = "Deletar informações do pátio", Description = "Endpoint em que se coleta o id de um pátio e deleta as informações do mesmo com o id correspondente")]
        [Produces<PatioEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _service.DeletarPatio(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
