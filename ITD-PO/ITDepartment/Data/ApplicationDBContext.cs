using ITDepartment.Models;
using Microsoft.EntityFrameworkCore;

namespace ITDepartment.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }

}
