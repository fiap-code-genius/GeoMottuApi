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

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca uma moto por id", Description = "Este endpoint busca uma moto pelo seu id correspondente e ao encontrar devolve um resultado único")]
        [Produces<MotoEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _service.ObterMotoPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("modelo/{modelo}")]
        [SwaggerOperation(Summary = "Busca moto pelo modelo", Description = "Endpoint feito com a finalidade de encontrar todas as motos que possuem o mesmo modelo do qual foi inserido")]
        [Produces<IEnumerable<MotoEntity>>]
        public IActionResult GetPorModelo(ModeloMoto modelo)
        {
            var objModel = _service.ObterMotosPorModelo(modelo);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível recuperar os dados");
        }

        [HttpPut("/update/{id}")]
        [SwaggerOperation(Summary = "Atualização de motos", Description = "Endpoint cuja finalidade é receber um id de uma moto e logo em seguida atualizar a moto do ID com o json entregue")]
        [Produces<MotoEntity>]
        public IActionResult Put(int id, [FromBody]MotoEntity entity)
        {
            try
            {
                var objModel = _service.EditarDadosMoto(id, entity);

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
        [SwaggerOperation(Summary = "Deletar informações", Description = "Endpoint em que se coleta o id de uma moto e deleta os dados da mesma")]
        [Produces<MotoEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _service.DeletarMoto(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
