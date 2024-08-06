using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.DataAccess.Conrete;
using TASİNMAZ.Entities.Concrete;

namespace TASİNMAZ.Business.Concrete.Services
{
    public class DistrictService : DistrictInterface
    {
        private readonly AppDbContext _context;

        public DistrictService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<District>> GetAll() // Arayüzdeki ile uyumlu
        {
            return await _context.districts
                .Include(d => d.City) // Şehri de dahil et
                .ToListAsync();
        }

        public async Task<District> GetByIdAsync(int id)
        {
            return await _context.districts
                .Include(d => d.City) // Şehri de dahil et
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<District>> GetByCityIdAsync(int cityId)
        {
            return await _context.districts
                .Include(d => d.City) // Şehri de dahil et
                .Where(d => d.CityId == cityId)
                .ToListAsync();
        }
    }
}
