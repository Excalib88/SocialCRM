using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialCRM.DAL.Contracts.Entities;

namespace SocialCRM.DAL.Implementations
{
    public class DataContext: DbContext
    {
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<LeadEntity> Leads { get; set; }
        public DbSet<LegalEntity> Legals { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}