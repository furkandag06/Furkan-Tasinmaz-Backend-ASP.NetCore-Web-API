using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Entities.Concrete.Models;

namespace TASİNMAZ.Business.Abstract.Interfaces
{
    public interface UserInterface
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}
