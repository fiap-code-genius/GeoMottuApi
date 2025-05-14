using GeoMottuApi.Domain.Entities;
using GeoMottuApi.Domain.Enums;

namespace GeoMottuApi.Application.Interfaces
{
    public interface IMotoApplicationService
    {
        IEnumerable<MotoEntity> ObterTodasAsMotos();
        MotoEntity? ObterMotoPorId(int id);
        MotoEntity? SalvarDadosMoto(MotoEntity moto);
        MotoEntity? EditarDadosMoto(int id, MotoEntity moto);
        MotoEntity? DeletarMoto(int id);
        IEnumerable<MotoEntity> ObterMotosPorModelo(ModeloMoto modelo);
    }
}
