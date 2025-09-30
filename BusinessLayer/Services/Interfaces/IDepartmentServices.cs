using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services.Interfaces
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