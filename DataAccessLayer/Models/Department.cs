using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

    }
}
