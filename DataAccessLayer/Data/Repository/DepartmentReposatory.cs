using DataAccessLayer.Data.Contexts;

namespace DataAccessLayer.Data.Repository
{

    //controller (presentation layer) => service (BLL) => repository (DAL) => dbcontext (DAL) => database
    public class DepartmentReposatory(ApplicationDbContext _dbContext) : IDepartmentReposatory
    //✨primary constructor✨// ((remove constructor and proberity "dbcontext"))
    {
        //ApplicationDbContext dbContext=new ApplicationDbContext();
        //❌ this violates:
        //1-single responsibility=> this class for crud operation only.
        //if you change constructor type of ApplicationDbContext() from default to parameterized, then you need to update this class also.
        //2-Dependency Inversion

        /*Dependency Injection*/
        //✨1 injection object needed
        //private readonly ApplicationDbContext _dbContext;//inside scope
        //public ApplicationDbContext dbContext { get ;}

        // asj clr to create the obect from applicationdbcontext
        //public DepartmentReposatory(ApplicationDbContext context)
        //{
        //    _dbContext = context;
        //}
        //✨2 life time [memory]


        //.🔑 5 CRUD operations
        //get all
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking) return _dbContext.Departments.ToList();
            else return _dbContext.Departments.AsNoTracking().ToList();
        }
        //add
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);//add locally
            return _dbContext.SaveChanges();
        }
        //update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();//number of rows affected
        }
        //remove
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
        //get by id
        public Department? GetById(int id)
        {
            //using ApplicationDbContext dbContext=new ApplicationDbContext(); //❌ this create dbcontext each time calling function any crud operation
            var department = _dbContext.Departments.Find(id);
            return department;
        }

        /*
         * (Dependency Inversion Principle – DIP)و هدفه يقلل من الترابط القوي بين اجزاء البرنامج solid احد مبادئ  
         * :- high level modules mustn't depend on low level modules. high & low depend on abstruction.
         * High-level module: جزء فيه منطق العمل (Business Logic).
         * Low-level module: (جزء بيعمل التفاصيل (قواعد بيانات، رسائل، ملفات.
         * Abstraction: Interface أو Class مجرد.
         */
    }
}