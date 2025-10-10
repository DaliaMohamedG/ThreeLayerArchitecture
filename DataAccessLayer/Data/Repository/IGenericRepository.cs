using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Data.Repository
{
    public interface IGenericRepository<t> where t : BaseEntity
    {
        void Add(t entity);//int Add(Department department);
        IEnumerable<t> GetAll(bool withTracking = false);
        t? GetById(int id);
        void Remove(t entity);
        void Update(t entity);
    }
}
