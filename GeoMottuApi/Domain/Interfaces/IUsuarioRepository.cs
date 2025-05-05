using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioEntity> ObterTodosOsUsuarios();
        UsuarioEntity? ObterUsuarioPorId(int id);
        UsuarioEntity? SalvarDadosUsuario(UsuarioEntity usuario);
        UsuarioEntity? EditarDadosUsuario(int id, UsuarioEntity usuario);
        UsuarioEntity? DeletarUsuario(int id);
    }
}
