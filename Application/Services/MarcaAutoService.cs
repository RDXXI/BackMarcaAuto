using BackTest.Domain.Entities;
using BackTest.Domain.Interfaces;

namespace BackTest.Application.Services
{
    public class MarcaAutoService : IMarcaAutoService
    {
        private readonly IMarcaAutoRepository _marcaAutoRepository;

        public MarcaAutoService(IMarcaAutoRepository marcaAutoRepository)
        {
            _marcaAutoRepository = marcaAutoRepository;
        }

        public async Task<IEnumerable<MarcaAuto>> GetAllMarcasAsync()
        {
            return await _marcaAutoRepository.GetAllAsync();
        }

        public async Task<MarcaAuto> GetMarcaByIdAsync(int id)
        {
            return await _marcaAutoRepository.GetByIdAsync(id);
        }

        public async Task AddMarcaAsync(MarcaAuto marcaAuto)
        {
            await _marcaAutoRepository.AddAsync(marcaAuto);
        }
        public async Task UpdateMarcaAsync(MarcaAuto marcaAuto)
        {
            await _marcaAutoRepository.UpdateAsync(marcaAuto);
        }

        public async Task DeleteMarcaAsync(int id)
        {
            await _marcaAutoRepository.DeleteAsync(id);
        }
    }
}