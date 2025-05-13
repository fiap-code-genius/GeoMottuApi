using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Enums;
using GeoMottuApi.Domain.Interfaces;

namespace GeoMottuApi.Application.Services
{
    public class PatioApplicationService : IPatioApplicationService
    {
        private readonly IPatioRepository _repository;

        public PatioApplicationService(IPatioRepository repository)
        {
            _repository = repository;
        }

        public PatioEntity? DeletarPatio(int id)
        {
            return _repository.DeletarPatio(id);
        }

        public PatioEntity? EditarDadosPatio(int id, PatioEntity patio)
        {
            return _repository.EditarDadosPatio(id, patio);
        }

        public PatioEntity? ObterPatioPorId(int id)
        {
            return _repository.ObterPatioPorId(id);
        }

        public IEnumerable<PatioEntity> ObterTodosOsPatios()
        {
            return _repository.ObterTodosOsPatios();
        }

        public PatioEntity? SalvarDadosPatio(PatioEntity patio)
        {
            return _repository.SalvarDadosPatio(patio);
        }

        public IEnumerable<PatioEntity> ObterPatiosPorTipo(TipoPatio tipo)
        {
            return _repository.ObterTodosOsPatios().Where(p => p.TipoDoPatio == tipo);
        }
    }
}
