using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Entities.Concrete;

namespace TASİNMAZ.Business.Abstract.Interfaces
{
    public interface CityInterface
    {
        List<City> GetAll();
        Task<City> GetByIdAsync(int id);
    }
}
