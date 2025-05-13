using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Application.Interfaces
{
    public interface IFilialApplicationService
    {
        IEnumerable<FilialEntity> ObterTodasAsFiliais();
        FilialEntity? ObterFilialPorId(int id);
        FilialEntity? SalvarDadosFilial(FilialEntity filial);
        FilialEntity? EditarDadosFilial(int id, FilialEntity filila);
        FilialEntity? DeletarFilial(int id);
    }
}
