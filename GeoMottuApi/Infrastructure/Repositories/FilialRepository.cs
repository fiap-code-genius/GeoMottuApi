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
            var filial = _context.Filial.Find(id);

            if(filial is not null)
            {
                _context.Filial.Remove(filial);
                _context.SaveChanges();

                return filial;
            }

            return null;

        }

        public FilialEntity? EditarDadosFilial(int id, FilialEntity filial)
        {
            filial.Id = id;
            _context.Filial.Update(filial);
            _context.SaveChanges();

            return filial;

        }

        public FilialEntity? ObterFilialPorId(int id)
        {
            var filial = _context.Filial.Find(id);

            return filial;


        }

        public IEnumerable<FilialEntity> ObterTodasAsFiliais()
        {
            var filial = _context.Filial.ToList();

            return filial;

        }

        public FilialEntity? SalvarDadosFilial(FilialEntity filial)
        {
            _context.Filial.Add(filial);
            _context.SaveChanges();

            return filial;

        }
    }
}
