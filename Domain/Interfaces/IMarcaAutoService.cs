using BackTest.Domain.Entities;

namespace BackTest.Domain.Interfaces
{
    public interface IMarcaAutoService
    {
        Task<IEnumerable<MarcaAuto>> GetAllMarcasAsync();
        Task<MarcaAuto> GetMarcaByIdAsync(int id);
        Task AddMarcaAsync(MarcaAuto marcaAuto);
        Task UpdateMarcaAsync(MarcaAuto marcaAuto);
        Task DeleteMarcaAsync(int id);
    }
}