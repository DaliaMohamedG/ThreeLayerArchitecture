using DataAccessLayer.Data.Contexts;

namespace DataAccessLayer.Data.Repository
{
    public class EmployeeRepository(ApplicationDbContext _dbContext) : GenericRepository<Employee>(_dbContext), IEmployeeRepository
    {

    }
}
