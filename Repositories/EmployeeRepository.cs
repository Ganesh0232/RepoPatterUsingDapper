using Dapper;
using RepoTrialS10032023_1352.Models;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace RepoTrialS10032023_1352.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly IDbConnection dbConnection;
        public EmployeeRepository(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultString"));
        }


        public async Task<List<Employee>> AddEmployee(Employee employee)
        {
            // using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            if (employee.Role == "front-end")
            {
                employee.RoleID = 1;

            }
            else if (employee.Role == "back-end")
            {
                employee.RoleID = 2;

            }
            else if (employee.Role == "full-stack")
            {
                employee.RoleID = 3;

            }

            var emp = dbConnection.Query("insert into EmployeeT (EmployeeName,RoleID) values (@EmployeeName,@RoleID)", employee);
          //  if(emp != null)
          //  {
            var employees = await dbConnection.QueryAsync<Employee>("select e.id,e.employeename,r.role,e.roleid\r\nfrom EmployeeT e\r\njoin EmployeeRoleT r\r\non e.RoleID=r.ID  where e.id=@id", new {id=employee.Id});
            return (employees.ToList());
          //  }
           
            

            //string sql = "Operations";
            //var parameters = new DynamicParameters();
            //     parameters.Add("@Option", 1);
            //parameters.Add("@Station_Id", employee.Id);
            //parameters.Add("@Station_name", employee.EmployeeName);
            //dbConnection.Query<Employee>(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Employee>>DeleteEmployee(int id)
        {
            var emp = dbConnection.Execute("delete from EmployeeT where id=@ID", new { id = id });

            var employees = await dbConnection.QueryAsync<Employee>("select e.id,e.employeename,r.role,e.roleid\r\nfrom EmployeeT e\r\njoin EmployeeRoleT r\r\non e.RoleID=r.ID  ");
            return (employees.ToList());
        }
        public List<Employee> findEmployeeById(int id)
        {
            //    return  dbConnection.Query<Employee>("select * from employeeT where id=@id", new {id=id}).ToList();
            string sql = "SelectAllEmployees";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            //  parameters.Add("@Option", 5);

            return dbConnection.Query<Employee>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
        }

      
        public async Task<List<Employee>> findEmployeeByRole(string role)
        {
            //  using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            //IEnumerable<EmpInf> employees = await SelectAllEmployees(connection);

            //var employees = await dbConnection.QueryAsync<Employee>("select * from EmployeeT e join EmployeeRoleT r on e.RoleID = r.ID");

            var employees = await dbConnection.QueryAsync<Employee>("select e.id,e.employeename,r.role,e.roleid\r\nfrom EmployeeT e\r\njoin EmployeeRoleT r\r\non e.RoleID=r.ID  where r.role=@role \r\n\r\n" , new {role=role});
            return (employees.ToList());
        }

        public async Task<List<Employee>> getAllEmployees()
        {
            //  using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            //IEnumerable<EmpInf> employees = await SelectAllEmployees(connection);

            //var employees = await dbConnection.QueryAsync<Employee>("select * from EmployeeT e join EmployeeRoleT r on e.RoleID = r.ID");

            var employees = await dbConnection.QueryAsync<Employee>("select e.id,e.employeename,r.role,e.roleid\r\nfrom EmployeeT e\r\njoin EmployeeRoleT r\r\non e.RoleID=r.ID\r\n\r\n");
            return (employees.ToList());
        }

        public async Task<List<Employee>> UpdateEmployee(int  id ,Employee employee)
        {
            var emp = await dbConnection.ExecuteAsync("update employeeT set EmployeeName=@EmployeeName ,@RoleID=RoleID where id=@Id ", employee);

            var employees = await dbConnection.QueryAsync<Employee>("select e.id,e.employeename,r.role,e.roleid\r\nfrom EmployeeT e\r\njoin EmployeeRoleT r\r\non e.RoleID=r.ID  ", new {ID = id});
            return (employees.ToList());
        }

    
    }
}
