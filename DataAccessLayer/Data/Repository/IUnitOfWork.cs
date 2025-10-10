namespace DataAccessLayer.Data.Repository
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentReposatory departmentReposatory { get; }
        int SaveChanges();
    }
}
