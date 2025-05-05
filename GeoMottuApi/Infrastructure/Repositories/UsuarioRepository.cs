using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Interfaces;
using GeoMottuApi.Infrastructure.Data.AppData;

namespace GeoMottuApi.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UsuarioEntity? DeletarUsuario(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario is not null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
                return usuario;
            }

            return null;
        }

        public UsuarioEntity? EditarDadosUsuario(int id, UsuarioEntity usuario)
        {
            usuario.Id = id;
            _context.Usuario.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public IEnumerable<UsuarioEntity> ObterTodosOsUsuarios()
        {
            var usuarios = _context.Usuario.ToList();

            return usuarios;
        }

        public UsuarioEntity? ObterUsuarioPorId(int id)
        {
            var usuario = _context.Usuario.Find(id);

            return usuario;
        }

        public UsuarioEntity? SalvarDadosUsuario(UsuarioEntity usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
