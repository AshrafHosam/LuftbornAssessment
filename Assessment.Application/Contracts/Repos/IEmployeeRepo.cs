using Assessment.Domain.Entities;

namespace Assessment.Application.Contracts.Repos
{
    public interface IEmployeeRepo
    {
        Task<Guid> Add(Employee employee);
        Task<bool> Update(Employee employee);
        Task<bool> Delete(Guid id);
        Task<Employee> Get(Guid id);
        Task<List<Employee>> GetAll();
        Task<bool> EmployeeExist(Guid id);
    }
}
