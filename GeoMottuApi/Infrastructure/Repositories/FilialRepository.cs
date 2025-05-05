using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Interfaces;
using GeoMottuApi.Infrastructure.Data.AppData;

namespace GeoMottuApi.Infrastructure.Repositories
{
    public class FilialRepository : IFilialRepository
    {
        private readonly ApplicationContext _context;

        public FilialRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FilialEntity? DeletarFilial(int id)
        {
            var filial = _context.Filial
        }

        public FilialEntity? EditarDadosFilial(int id, FilialEntity moto)
        {
            throw new NotImplementedException();
        }

        public FilialEntity? ObterFilialPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilialEntity> ObterTodasAsFiliais()
        {
            throw new NotImplementedException();
        }

        public FilialEntity? SalvarDadosFilial(FilialEntity moto)
        {
            throw new NotImplementedException();
        }
    }
}
