using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.data
{
    public class OfficeDb: DbContext
    {
        public OfficeDb(DbContextOptions<OfficeDb> options) : base(options)
        {

        }
        public DbSet<Employee> Employees => Set<Employee>();
    }
}