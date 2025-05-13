using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace GeoMottuApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        private readonly IMotoApplicationService _service;

        public MotoController(IMotoApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma moto", Description = "Endpoint destinado ao cadastro de motos da Mottu e realiza o commit do banco de dados")]
        [Produces<MotoEntity>]
        public IActionResult Post([FromBody] MotoEntity entity)
        {
            try
            {
                var objModel = _service.SalvarDadosMoto(entity);

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
        [SwaggerOperation(Summary = "Lista de todas as motos", Description = "Endpoint que busca todas as motos cadastradas no banco de dados e as exibe para o usuário")]
        [Produces<IEnumerable<MotoEntity>>]
        public IActionResult Get()
        {
            var objModel = _service.ObterTodasAsMotos();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }
    }
}
