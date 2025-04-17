using DropdownDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DropdownDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Either make it nullable or use 'required' if using .NET 6+ with nullable enabled
        public DbSet<DesignationEntity> Designation { get; set; } = null!;
        public DbSet<EmployeeEntity> Employee { get; set; } = null!;
    }
}
