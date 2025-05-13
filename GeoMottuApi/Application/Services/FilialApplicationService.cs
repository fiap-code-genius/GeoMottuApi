using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Enums;
using GeoMottuApi.Domain.Interfaces;

namespace GeoMottuApi.Application.Services
{
    public class FilialApplicationService : IFilialApplicationService
    {
        private readonly IFilialRepository _repository;

        public FilialApplicationService(IFilialRepository repository)
        {
            _repository = repository;
        }

        public FilialEntity? DeletarFilial(int id)
        {
            return _repository.DeletarFilial(id);
        }

        public FilialEntity? EditarDadosFilial(int id, FilialEntity filial)
        {
            return _repository.EditarDadosFilial(id, filial);
        }

        public FilialEntity? ObterFilialPorId(int id)
        {
            return _repository.ObterFilialPorId(id);
        }

        public IEnumerable<FilialEntity> ObterTodasAsFiliais()
        {
            return _repository.ObterTodasAsFiliais();
        }

        public FilialEntity? SalvarDadosFilial(FilialEntity filial)
        {
            return _repository.SalvarDadosFilial(filial);
        }

        public IEnumerable<FilialEntity> ObterFiliaisPorPais(PaisesFiliais pais)
        {
            return _repository.ObterTodasAsFiliais().Where(f => f.PaisFilial == pais);
        }
    }
}
