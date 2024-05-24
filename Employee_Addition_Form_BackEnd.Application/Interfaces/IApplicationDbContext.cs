using Employee_Addition_Form_BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Addition_Form_BackEnd.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        int SaveChanges();
    }
}
