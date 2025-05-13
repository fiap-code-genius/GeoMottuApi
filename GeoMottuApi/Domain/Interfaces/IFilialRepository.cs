using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Domain.Interfaces
{
    public interface IFilialRepository
    {
        IEnumerable<FilialEntity> ObterTodasAsFiliais();
        FilialEntity? ObterFilialPorId(int id);
        FilialEntity? SalvarDadosFilial(FilialEntity filial);
        FilialEntity? EditarDadosFilial(int id, FilialEntity filila);
        FilialEntity? DeletarFilial(int id);
    }
}
