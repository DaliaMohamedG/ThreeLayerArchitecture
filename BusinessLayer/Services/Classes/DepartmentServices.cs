using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Factories;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Repository;

namespace BusinessLogicLayer.Services.Classes
{
    public class DepartmentServices(DepartmentReposatory departmentReposatory1) : IDepartmentServices
    {
        public readonly IDepartmentReposatory departmentReposatory1 = departmentReposatory1;

        //methods => Repository
        //GetAll => id, code, name, describtion, DateOfCreation, 
        public IEnumerable<DpartmentDto> GetAllDepartments()
        {
            //get all repo
            var departments = departmentReposatory1.GetAll();
            return departments.Select(d => d.toDepartmentDto());
        }
        //get by id
        public DepartmentDetailsDto GetDepartmentyId(int id)
        {
            var department = departmentReposatory1.GetById(id);
            //if (department is null) return null;
            //return department.ToDepartmentDetailsDto();
            return department is null ? null : department.ToDepartmentDetailsDto();
        }
        //add
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            return departmentReposatory1.Add(departmentDto.toEntity());
        }
        //update
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return departmentReposatory1.Update(departmentDto.toEntity());
        }
        //delete
        public bool DeleteDepartment(int id)
        {
            var department = departmentReposatory1.GetById(id);
            if (department is null) return false;
            int numOfRows = departmentReposatory1.Remove(department);
            return numOfRows > 0;
        }
    }
}
