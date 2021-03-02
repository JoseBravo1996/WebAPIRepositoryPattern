using System.Threading.Tasks;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.paging;

namespace WebAPIRepositoryPattern.Repository
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    { 
        Task<PagedList<Employee>> GetEmployees(PagingParameters pagingParameters);
        Employee GetEmployee(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
