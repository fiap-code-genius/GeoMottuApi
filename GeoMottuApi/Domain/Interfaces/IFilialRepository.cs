using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Domain.Interfaces
{
    public interface IFilialRepository
    {
        IEnumerable<FilialEntity> ObterTodasAsFiliais();
        FilialEntity? ObterFilialPorId(int id);
        FilialEntity? SalvarDadosFilial(FilialEntity moto);
        FilialEntity? EditarDadosFilial(int id, FilialEntity moto);
        FilialEntity? DeletarFilial(int id);
    }
}
