using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence
{
    public class EasySupportDbContext : DbContext
    {
        public EasySupportDbContext(DbContextOptions<EasySupportDbContext> options) : base(options)
        {
            
        }
    }
}
