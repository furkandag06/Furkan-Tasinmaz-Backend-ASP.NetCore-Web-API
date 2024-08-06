using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Entities.Concrete;
using TASİNMAZ.Entities.Concrete.Models;

namespace TASİNMAZ.Business.Abstract.Interfaces
{
    public interface tasinmazInterface
    {
        Task<tasinmaz> AddAsync(tasinmaz tasinmaz);
        Task<bool> DeleteAsync(int id);
        IEnumerable<tasinmaz> GetAll();
        tasinmaz GetById(int id);
        Task<tasinmaz> GetByIdAsync(int id);
        Task<tasinmaz> UpdateAsync(int id, tasinmaz tasinmaz);
        Task<IEnumerable<tasinmaz>> GetByUserIdAsync(int userId); // Eklenen metod
    }
}
