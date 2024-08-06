using Microsoft.EntityFrameworkCore;
using TASİNMAZ.Entities.Concrete;
using TASİNMAZ.Entities.Concrete.Models;


namespace TASİNMAZ.DataAccess.Conrete
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base (options)
        {
        
        }
        public DbSet<City> cities { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<Neigborhood> neigborhoods { get;  set; }
        public DbSet<tasinmaz> tasinmaz { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Log> Logs { get; set; }


    }
}
