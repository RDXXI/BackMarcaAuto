using BackTest.Domain.Entities;

namespace BackTest.Domain.Interfaces
{
    public interface IMarcaAutoRepository
    {
        Task<IEnumerable<MarcaAuto>> GetAllAsync();
        Task AddAsync(MarcaAuto marcaAuto);
        Task<MarcaAuto> GetByIdAsync(int id);
        Task UpdateAsync(MarcaAuto marcaAuto);
        Task DeleteAsync(int id);
    }
}
