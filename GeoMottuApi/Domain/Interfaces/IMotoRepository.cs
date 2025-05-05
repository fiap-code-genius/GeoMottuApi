using GeoMottuApi.Domain.Entities;

namespace GeoMottuApi.Domain.Interfaces
{
    public interface IMotoRepository
    {
        IEnumerable<MotoEntity> ObterTodasAsMotos();
        MotoEntity? ObterMotoPorId(int id);
        MotoEntity? SalvarDadosMoto(MotoEntity moto);
        MotoEntity? EditarDadosMoto(int id, MotoEntity moto);
        MotoEntity? DeletarMoto(int id);
    }
}
