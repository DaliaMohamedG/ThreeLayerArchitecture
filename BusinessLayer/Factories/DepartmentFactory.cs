using BusinessLogicLayer.DTO;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Factories
{
    internal static class DepartmentFactory
    {
        public static DpartmentDto toDepartmentDto(this Department d)
        {
            return new DpartmentDto()
            {
                DeptId = d.Id,
                Code = d.Code,
                Name = d.Name,
                Description = d.Description,
                DateOfCreation = d.CreatedOn.HasValue ? DateOnly.FromDateTime(d.CreatedOn.Value) : default
            };
        }
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                IsDeleted = department.IsDeleted,
                ModifiedBy = department.ModifiedBy,
                CreatedOn = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default,
                ModifiedOn = DateOnly.FromDateTime(department.ModifiedOn)
            };
        }
        public static Department toEntity(this CreateDepartmentDto dto)
        {
            return new Department()
            {
                Description = dto.Description,
                Name = dto.Name,
                Code = dto.Code,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department toEntity(this UpdatedDepartmentDto dto)
        {
            return new Department()
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
                Code = dto.Code,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
