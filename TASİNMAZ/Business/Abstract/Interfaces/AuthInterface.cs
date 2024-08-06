using System.Threading.Tasks;
using TASİNMAZ.Entities.Concrete.Models;

namespace TASİNMAZ.Business.Abstract.Interfaces
{
    public interface AuthInterface
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string eMail, string password);
        Task<bool> UserExists(string eMail);
        Task<User> GetUserById(int id); // Yeni metod
        Task<bool> IsAdmin(string eMail);


    }

}
