using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GasProjectManager.Data
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions options):base(options) 
        {
        }
    }
}
