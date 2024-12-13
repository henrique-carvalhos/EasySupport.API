using EasySupport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EasySupport.Infrastructure.Persistence
{
    public class EasySupportDbContext : DbContext
    {
        public EasySupportDbContext(DbContextOptions<EasySupportDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<OriginService> OriginServices { get; set; }
        public DbSet<StatusTicket> StatusTickets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketInteraction> TicketInteractions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SolutionTicket> SolutionTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
