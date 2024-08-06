using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.DataAccess.Conrete;
using TASİNMAZ.Entities.Concrete;

namespace TASİNMAZ.Business.Conrete.Services
{
    public class CityService : CityInterface
    {
        private AppDbContext _dbContext;

        public CityService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<City> GetAll()
        {
            return _dbContext.cities.ToList();
        }

        public City GetById(int id)
        {
            return _dbContext.cities.FirstOrDefault(city => city.Id == id);
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _dbContext.cities.FirstOrDefaultAsync(city => city.Id == id);
        }
    }
}

