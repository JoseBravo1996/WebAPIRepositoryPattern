using System.Linq;
using System.Threading.Tasks;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.paging;

namespace WebAPIRepositoryPattern.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DBContext dbContext): base(dbContext)
        {
        
        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public Employee GetEmployee(int id)
        {
            return FindByCondition(e => e.Id == id).FirstOrDefault();
        }

        public Task<PagedList<Employee>> GetEmployees(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<Employee>.GetPagedList(FindAll().OrderBy(s => s.Id), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
    }
}
