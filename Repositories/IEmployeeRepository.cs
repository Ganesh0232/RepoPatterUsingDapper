using RepoTrialS10032023_1352.Models;

namespace RepoTrialS10032023_1352.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> getAllEmployees();
        public List<Employee> findEmployeeById(int id);

        public Task<List<Employee>> findEmployeeByRole(string role);

        public Task<List<Employee>> AddEmployee(Employee employee);

        public Task<List<Employee>> UpdateEmployee(int id, Employee employee);

        public Task<List<Employee>> DeleteEmployee(int id);

    }
}