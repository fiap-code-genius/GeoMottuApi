using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Enums;

namespace GeoMottuApi.Application.Interfaces
{
    public interface IFilialApplicationService
    {
        IEnumerable<FilialEntity> ObterTodasAsFiliais();
        FilialEntity? ObterFilialPorId(int id);
        FilialEntity? SalvarDadosFilial(FilialEntity filial);
        FilialEntity? EditarDadosFilial(int id, FilialEntity filial);
        FilialEntity? DeletarFilial(int id);
        IEnumerable<FilialEntity?> ObterFiliaisPorPais(PaisesFiliais pais);
    }
}
