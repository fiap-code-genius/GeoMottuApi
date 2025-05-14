using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace GeoMottuApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService _service;

        public UsuarioController(IUsuarioApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um usuário", Description = "Endpoint destinado ao cadastro de um usuário e envio ao DB")]
        [Produces<UsuarioEntity>]
        public IActionResult Post([FromBody] UsuarioEntity usuario)
        {
            try
            {
                var objModel = _service.SalvarDadosUsuario(usuario);

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
        [SwaggerOperation(Summary = "Lista todos os usuários", Description = "Endpoint que devolve todos os funcionários cadastrados no banco")]
        [Produces<IEnumerable<UsuarioEntity>>]
        public IActionResult Get()
        {
            var objModel = _service.ObterTodosOsUsuarios();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um usuario por id", Description = "Endpoint que devolve um único usuário baseado em seu ID")]
        [Produces<MotoEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _service.ObterUsuarioPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("email/{email}")]
        [SwaggerOperation(Summary = "Busca um usuário pelo email", Description = "Endpoint destinado a busca de um único funcionário pelo seu email")]
        [Produces<UsuarioEntity>]
        public IActionResult GetPorEmail(string email)
        {
            var objModel = _service.ObterUsuarioPorEmail(email);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível buscar os dados");
        }

        [HttpPut("update/{id}")]
        [SwaggerOperation(Summary = "Atualização de usuários", Description = "Endpoint que tem como objetivo coletar um id e atualizar os dados do usuário que tem o mesmo id")]
        [Produces<MotoEntity>]
        public IActionResult Put(int id, [FromBody] UsuarioEntity entity)
        {
            try
            {
                var objModel = _service.EditarDadosUsuario(id, entity);

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
        [SwaggerOperation(Summary = "Deletar informações de usuário", Description = "Endpoint destinado a deletar informações de um id específico")]
        [Produces<MotoEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _service.DeletarUsuario(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
