using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Entities.Concrete.Models;

namespace TASİNMAZ.Business.Abstract.Interfaces
{
    public interface logInterface
    {
        Task<List<Log>> ListLog();
        Task<Log> GetLogById(int id);
        Task AddLog(Log log);
        Task UpdateLog(Log log);
        Task DeleteLog(int id);

        Task<IEnumerable<Log>> GetAllLogsAsync();
        Task<IEnumerable<Log>> SearchLogsAsync(string term);
    }
}
