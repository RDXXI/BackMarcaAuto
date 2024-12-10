using BackTest.Domain.Entities;
using BackTest.Domain.Interfaces;
using BackTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackTest.Infrastructure.Repositories
{
    public class MarcaAutoRepository : IMarcaAutoRepository
    {
        private readonly ApplicationDbContext _context;

        public MarcaAutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MarcaAuto>> GetAllAsync()
        {
            return await _context.MarcasAutos.ToListAsync();
        }

        public async Task AddAsync(MarcaAuto marcaAuto)
        {
            _context.MarcasAutos.Add(marcaAuto);
            await _context.SaveChangesAsync();
        }
        public async Task<MarcaAuto> GetByIdAsync(int id)
        {
            return await _context.MarcasAutos.FindAsync(id);
        }

        public async Task UpdateAsync(MarcaAuto marcaAuto)
        {
            _context.MarcasAutos.Update(marcaAuto);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var marcaAuto = await _context.MarcasAutos.FindAsync(id);
            if (marcaAuto != null)
            {
                _context.MarcasAutos.Remove(marcaAuto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
