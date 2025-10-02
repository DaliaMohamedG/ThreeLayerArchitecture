using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Factories;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Repository;

namespace BusinessLogicLayer.Services.Classes
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentReposatory _departmentReposatory;

        // Constructor Injection
        public DepartmentServices(IDepartmentReposatory departmentReposatory)
        {
            _departmentReposatory = departmentReposatory;
        }

        //methods => Repository
        //GetAll => id, code, name, description, DateOfCreation
        public IEnumerable<DpartmentDto> GetAllDepartments()
        {
            var departments = _departmentReposatory.GetAll();
            return departments.Select(d => d.toDepartmentDto());
        }

        // Get by id
        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _departmentReposatory.GetById(id);
            return department is null ? null : department.ToDepartmentDetailsDto();
        }

        // Add
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            return _departmentReposatory.Add(departmentDto.toEntity());
        }

        // Update
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentReposatory.Update(departmentDto.toEntity());
        }

        // Delete
        public bool DeleteDepartment(int id)
        {
            var department = _departmentReposatory.GetById(id);
            if (department is null) return false;

            int numOfRows = _departmentReposatory.Remove(department);
            return numOfRows > 0;
        }

        public DepartmentDetailsDto GetDepartmentyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
