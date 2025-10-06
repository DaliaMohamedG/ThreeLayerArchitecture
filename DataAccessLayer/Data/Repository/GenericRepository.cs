using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Data.Repository
{
    public class GenericRepository<t>(ApplicationDbContext _dbContext) : IGenericRepository<t> where t : BaseEntity
    {
        public int Add(t entity)
        {
            _dbContext.Set<t>().Add(entity);//add locally
            return _dbContext.SaveChanges();
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

        public int Remove(t entity)
        {
            _dbContext.Set<t>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(t entity)
        {
            _dbContext.Set<t>().Update(entity);
            return _dbContext.SaveChanges();//number of rows affected
        }
    }
}
