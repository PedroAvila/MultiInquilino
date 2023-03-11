using Microsoft.EntityFrameworkCore;
using MultiInquilinoUnicaBaseDatos.Models;

namespace MultiInquilinoUnicaBaseDatos.Persistence
{
    public class TenantAdminDbContext : DbContext
    {
        public TenantAdminDbContext(DbContextOptions<TenantAdminDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Tenant> Tenants { get; set; }

    }
}
