using Assessment.Application.Contracts.Repos;
using Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Persistence.Implementation.Repos
{
    internal class EmployeeRepo : IEmployeeRepo
    {
        private readonly AssessmentDbContext _context;

        public EmployeeRepo(AssessmentDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Employee employee)
        {
            var entity = _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            _context.Employees.Remove(new Employee { Id = id });

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EmployeeExist(Guid id)
            => await _context.Employees
            .AsNoTracking()
            .AnyAsync(x => x.Id == id);

        public async Task<Employee> Get(Guid id)
            => await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<List<Employee>> GetAll()
            => await _context.Employees
            .AsNoTracking()
            .ToListAsync();

        public async Task<bool> Update(Employee employee)
        {
            _context.Employees.Update(employee);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
