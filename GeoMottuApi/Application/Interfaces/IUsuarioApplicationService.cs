using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        IEnumerable<UsuarioEntity> ObterTodosOsUsuarios();
        UsuarioEntity? ObterUsuarioPorId(int id);
        UsuarioEntity? SalvarDadosUsuario(UsuarioEntity usuario);
        UsuarioEntity? EditarDadosUsuario(int id, UsuarioEntity usuario);
        UsuarioEntity? DeletarUsuario(int id);
        UsuarioEntity? ObterUsuarioPorEmail(string email);
    }
}
