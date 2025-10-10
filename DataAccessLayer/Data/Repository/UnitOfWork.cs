using DataAccessLayer.Data.Contexts;

namespace DataAccessLayer.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentReposatory> _departmentReposatory;
        private readonly ApplicationDbContext _context;
        public UnitOfWork(IEmployeeRepository employeeRepository, IDepartmentReposatory departmentReposatory, ApplicationDbContext dbContext)
        {
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
            _departmentReposatory = new Lazy<IDepartmentReposatory>(() => new DepartmentReposatory(dbContext));
            _context = dbContext;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
        public IDepartmentReposatory departmentReposatory => _departmentReposatory.Value;
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
