using BusinessLogicLayer.DTO.EmployeeDtos;

namespace BusinessLogicLayer.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking = false);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto employee);
        int UpdateEmployee(UpdateEmployeeDto employee);
        bool DeleteEmployee(int id);
    }
}
