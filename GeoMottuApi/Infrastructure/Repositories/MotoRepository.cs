using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Interfaces;
using GeoMottuApi.Infrastructure.Data.AppData;

namespace GeoMottuApi.Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationContext _context;

        public MotoRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public MotoEntity? DeletarMoto(int id)
        {
            var moto = _context.Moto.Find(id);

            if (moto is not null)
            {
                _context.Moto.Remove(moto);
                _context.SaveChanges();

                return moto;
            }

            return null;
        }

        public MotoEntity? EditarDadosMoto(int id, MotoEntity moto)
        {
            moto.Id = id;
            _context.Moto.Update(moto);
            _context.SaveChanges();

            return moto;
        }

        public MotoEntity? ObterMotoPorId(int id)
        {
            var moto = _context.Moto.Find(id);

            return moto;
        }

        public IEnumerable<MotoEntity> ObterTodasAsMotos()
        {
            var motos = _context.Moto.ToList();

            return motos;
        }

        public MotoEntity? SalvarDadosMoto(MotoEntity moto)
        {
            _context.Moto.Add(moto);
            _context.SaveChanges();

            return moto;
        }
    }
}
