using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Interfaces;
using GeoMottuApi.Infrastructure.Data.AppData;

namespace GeoMottuApi.Infrastructure.Repositories
{
    public class PatioRepository : IPatioRepository
    {
        private readonly ApplicationContext _context;

        public PatioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public PatioEntity? DeletarPatio(int id)
        {
            var patio = _context.Patio.Find(id);

            if (patio is not null)
            {
                _context.Patio.Remove(patio);
                _context.SaveChanges();
                return patio;
            }

            return null;
        }

        public PatioEntity? EditarDadosPatio(int id, PatioEntity patio)
        {
            patio.Id = id;
            _context.Update(patio);
            _context.SaveChanges();

            return patio;
        }

        public PatioEntity? ObterPatioPorId(int id)
        {
            var patio = _context.Patio.Find(id);

            return patio;
        }

        public IEnumerable<PatioEntity> ObterTodosOsPatios()
        {
            var patios = _context.Patio.ToList();

            return patios;
        }

        public PatioEntity? SalvarDadosPatio(PatioEntity patio)
        {
            _context.Patio.Add(patio);
            _context.SaveChanges();

            return patio;
        }
    }
}
