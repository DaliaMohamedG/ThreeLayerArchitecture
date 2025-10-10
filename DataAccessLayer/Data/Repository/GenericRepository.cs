using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Data.Repository
{
    public class GenericRepository<t>(ApplicationDbContext _dbContext) : IGenericRepository<t> where t : BaseEntity
    {
        public void Add(t entity)
        {
            _dbContext.Set<t>().Add(entity);//add locally
        }

        public IEnumerable<t> GetAll(bool withTracking = false)
        {
            if (withTracking) return _dbContext.Set<t>().ToList();
            else return _dbContext.Set<t>().AsNoTracking().ToList();
            //if (withTracking) return _dbContext.Departments.ToList();
            //else return _dbContext.Departments.AsNoTracking().ToList();
        }

        public t? GetById(int id)
        {
            //using ApplicationDbContext dbContext=new ApplicationDbContext(); //❌ this create dbcontext each time calling function any crud operation
            return _dbContext.Set<t>().Find(id);
        }

        public void Remove(t entity)
        {
            _dbContext.Set<t>().Remove(entity);
        }

        public void Update(t entity)
        {
            _dbContext.Set<t>().Update(entity);
           // return _dbContext.SaveChanges();//number of rows affected
        }
    }
}
