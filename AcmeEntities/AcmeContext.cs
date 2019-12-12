using AcmeEntities.Models;
using Microsoft.EntityFrameworkCore;


namespace AcmeEntities
{
    public partial class AcmeContext : DbContext
    {

        public AcmeContext(DbContextOptions options)
            : base(options)
        {
        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

    }
}
