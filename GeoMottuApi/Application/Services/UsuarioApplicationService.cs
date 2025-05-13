using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Interfaces;

namespace GeoMottuApi.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioApplicationService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioEntity? DeletarUsuario(int id)
        {
            return _repository.DeletarUsuario(id);
        }

        public UsuarioEntity? EditarDadosUsuario(int id, UsuarioEntity usuario)
        {
            return _repository.EditarDadosUsuario(id, usuario);
        }

        public IEnumerable<UsuarioEntity> ObterTodosOsUsuarios()
        {
            return _repository.ObterTodosOsUsuarios();
        }

        public UsuarioEntity? ObterUsuarioPorId(int id)
        {
            return _repository.ObterUsuarioPorId(id);
        }

        public UsuarioEntity? SalvarDadosUsuario(UsuarioEntity usuario)
        {
            return _repository.SalvarDadosUsuario(usuario);
        }

        public UsuarioEntity? ObterUsuarioPorEmail(string email)
        {
            return _repository.ObterTodosOsUsuarios().Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
