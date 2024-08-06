using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.DataAccess.Conrete;
using TASİNMAZ.Entities.Concrete;

namespace TASİNMAZ.Business.Concrete.Services
{
    public class NeigborhoodService : NeigborhoodInterface
    {
        private readonly AppDbContext _dbContext;

        public NeigborhoodService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Neigborhood>> GetAll() // Arayüzdeki metoda uygun şekilde implement edilmelidir
        {
            return await _dbContext.neigborhoods
                                   .Include(n => n.District)
                                   .ThenInclude(d => d.City) // Assuming District has a navigation property to City
                                   .ToListAsync();
        }

        public async Task<Neigborhood> GetByIdAsync(int id)
        {
            return await _dbContext.neigborhoods
                                   .Include(n => n.District)
                                   .ThenInclude(d => d.City) // Assuming District has a navigation property to City
                                   .FirstOrDefaultAsync(neigborhood => neigborhood.Id == id);
        }

        public async Task<IEnumerable<Neigborhood>> GetByDistrictIdAsync(int districtId)
        {
            return await _dbContext.neigborhoods
                                   .Include(n => n.District) // İlçeyi dahil et
                                   .ThenInclude(d => d.City)
                                   .Where(n => n.DistrictId == districtId)
                                   .ToListAsync();
        }
    }
}



