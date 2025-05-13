using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Application.Interfaces
{
    public interface IPatioApplicationService
    {
        IEnumerable<PatioEntity> ObterTodosOsPatios();
        PatioEntity? ObterPatioPorId(int id);
        PatioEntity? SalvarDadosPatio(PatioEntity patio);
        PatioEntity? EditarDadosPatio(int id, PatioEntity patio);
        PatioEntity? DeletarPatio(int id);
    }
}
