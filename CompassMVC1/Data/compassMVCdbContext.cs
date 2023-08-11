using CompassMVC1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CompassMVC1.Data
{
    public class compassMVCdbContext : DbContext
    {
        public compassMVCdbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerModel> Customers { get; set; }
    }
}
