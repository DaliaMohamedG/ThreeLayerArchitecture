using BusinessLogicLayer.DTO.DepartmentDtos;

namespace BusinessLogicLayer.Services
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreateDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DpartmentDto> GetAllDepartments();
        DepartmentDetailsDto GetDepartmentyId(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}