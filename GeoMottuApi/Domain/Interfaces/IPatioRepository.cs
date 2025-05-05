using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Domain.Interfaces
{
    public interface IPatioRepository
    {
        IEnumerable<PatioEntity> ObterTodosOsPatios();
        PatioEntity? ObterPatioPorId(int id);
        PatioEntity? SalvarDadosPatio(PatioEntity patio);
        PatioEntity? EditarDadosPatio(int id, PatioEntity patio);
        PatioEntity? DeletarPatio(int id);
    }
}
