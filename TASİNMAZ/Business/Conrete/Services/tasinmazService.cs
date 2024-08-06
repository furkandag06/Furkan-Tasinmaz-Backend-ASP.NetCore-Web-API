using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.DataAccess.Conrete;
using TASİNMAZ.Entities.Concrete.Models;

namespace TASİNMAZ.Business.Concrete.Services
{
    public class TasinmazService : tasinmazInterface
    {
        private readonly AppDbContext _dbContext;

        public TasinmazService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<tasinmaz> AddAsync(tasinmaz tasinmaz)
        {
            await _dbContext.tasinmaz.AddAsync(tasinmaz);
            await _dbContext.SaveChangesAsync();
            return tasinmaz;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tasinmaz = await _dbContext.tasinmaz.FindAsync(id);
            if (tasinmaz == null)
                return false;

            _dbContext.tasinmaz.Remove(tasinmaz);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<tasinmaz> GetAll()
        {
            return _dbContext.tasinmaz
                             .Include(t => t.Neigborhood)
                             .ThenInclude(x => x.District)
                             .ThenInclude(l => l.City)
                             .Include(t => t.User) // Kullanıcı bilgisini de içeren
                             .ToList();
        }

        public tasinmaz GetById(int id)
        {
            return _dbContext.tasinmaz
                             .Include(t => t.Neigborhood)
                             .ThenInclude(x => x.District)
                             .ThenInclude(l => l.City)
                             .Include(t => t.User) // Kullanıcı bilgisini de içeren
                             .FirstOrDefault(t => t.Id == id);
        }

        public async Task<tasinmaz> GetByIdAsync(int id)
        {
            return await _dbContext.tasinmaz
                                   .Include(t => t.Neigborhood)
                                   .ThenInclude(x => x.District)
                                   .ThenInclude(l => l.City)
                                   .Include(t => t.User) // Kullanıcı bilgisini de içeren
                                   .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<tasinmaz> UpdateAsync(int id, tasinmaz tasinmaz)
        {
            var existingTasinmaz = await _dbContext.tasinmaz
                                                   .FirstOrDefaultAsync(t => t.Id == id);
            if (existingTasinmaz == null)
                return null;

            // Güncelleme işlemi yapılacak
            existingTasinmaz.NeigborhoodId = tasinmaz.NeigborhoodId;
            existingTasinmaz.Parcel = tasinmaz.Parcel;
            existingTasinmaz.CoordinateInformation = tasinmaz.CoordinateInformation;
            existingTasinmaz.Quality = tasinmaz.Quality;
            existingTasinmaz.Island = tasinmaz.Island;

            await _dbContext.SaveChangesAsync();
            return existingTasinmaz;
        }

        public async Task<IEnumerable<tasinmaz>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.tasinmaz
                                   .Where(t => t.UserId == userId)
                                   .Include(t => t.Neigborhood)
                                   .ThenInclude(x => x.District)
                                   .ThenInclude(l => l.City)
                                   .ToListAsync();
        }
    }
}
