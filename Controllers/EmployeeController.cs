using Microsoft.AspNetCore.Mvc;
using RepoTrialS10032023_1352.Models;
using RepoTrialS10032023_1352.Repositories;

namespace RepoTrialS10032023_1352.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class EmployeeController : Controller
    {

       
            public readonly IEmployeeRepository _repository;

            public EmployeeController(IEmployeeRepository repository)
            {
               _repository = repository;
            }
            
            [HttpGet]
            public List<Employee> GetStation(int id)
            {
                return _repository.findEmployeeById(id);
            }

            [HttpGet("TogetEMployeeByRole")]
            public Task<List<Employee>> Get(string role)
            {
                return _repository.findEmployeeByRole(role);
            }

            [HttpGet("GetAll")]

            public Task<List<Employee>> GetAllc()
            {
                return _repository.getAllEmployees();
            }

            [HttpDelete("FireEMployee")]
            public Task<List<Employee>>Delete(int id)
            {
             return   _repository.DeleteEmployee(id);
             
            }
            [HttpPost("ToEnrollEmployee")]
            public Task<List<Employee>> Post(Employee employee)
            {
               return _repository.AddEmployee(employee);
            }
            [HttpPut("ToUpdateEmployeeDetails")]
            public Task<List<Employee>> Put(int id ,Employee employee)
            {
              return  _repository.UpdateEmployee(id,employee);
            }


        }
    }
        
