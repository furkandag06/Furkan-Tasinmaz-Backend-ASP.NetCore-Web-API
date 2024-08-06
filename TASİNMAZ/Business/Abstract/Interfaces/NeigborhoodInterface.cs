using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Entities.Concrete;

namespace TASİNMAZ.Business.Abstract.Interfaces
{
    public interface NeigborhoodInterface
    {
        Task<List<Neigborhood>> GetAll(); // Dönüş türü Task<List<Neigborhood>> olarak tanımlanmış
        Task<Neigborhood> GetByIdAsync(int id);
        Task<IEnumerable<Neigborhood>> GetByDistrictIdAsync(int districtId);
    }
}
