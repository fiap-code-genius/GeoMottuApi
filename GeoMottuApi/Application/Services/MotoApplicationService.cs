using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Enums;
using GeoMottuApi.Domain.Interfaces;

namespace GeoMottuApi.Application.Services
{
    public class MotoApplicationService : IMotoApplicationService
    {

        private readonly IMotoRepository _repository;

        public MotoApplicationService(IMotoRepository repository)
        {
            _repository = repository;
        }

        public MotoEntity? DeletarMoto(int id)
        {
            return _repository.DeletarMoto(id);
        }

        public MotoEntity? EditarDadosMoto(int id, MotoEntity moto)
        {
            return _repository.EditarDadosMoto(id, moto);
        }

        public MotoEntity? ObterMotoPorId(int id)
        {
            return _repository.ObterMotoPorId(id);
        }

        public IEnumerable<MotoEntity> ObterTodasAsMotos()
        {
            return _repository.ObterTodasAsMotos();
        }

        public MotoEntity? SalvarDadosMoto(MotoEntity moto)
        {
            return _repository.SalvarDadosMoto(moto);
        }

        public IEnumerable<MotoEntity> ObterMotosPorModelo(ModeloMoto modelo)
        {
            return _repository.ObterTodasAsMotos()
                              .Where(m => m.Modelo == modelo);
        }
    }
}
