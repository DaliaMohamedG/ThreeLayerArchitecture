using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Data.Repository
{
    public interface IGenericRepository<t> where t : BaseEntity
    {
        int Add(t entity);//int Add(Department department);
        IEnumerable<t> GetAll(bool withTracking = false);
        t? GetById(int id);
        int Remove(t entity);
        int Update(t entity);
    }
}
