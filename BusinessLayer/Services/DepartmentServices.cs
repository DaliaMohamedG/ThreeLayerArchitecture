using BusinessLogicLayer.DTO.DepartmentDtos;
using BusinessLogicLayer.Factories;
using DataAccessLayer.Data.Repository;

namespace BusinessLogicLayer.Services
{
    public class DepartmentServices(IUnitOfWork unitOfWork) : IDepartmentServices
    {
        //private readonly IDepartmentReposatory _departmentReposatory;

        //// Constructor Injection
        //public DepartmentServices(IDepartmentReposatory departmentReposatory)
        //{
        //    _departmentReposatory = departmentReposatory;
        //}

        //methods => Repository
        //GetAll => id, code, name, description, DateOfCreation
        public IEnumerable<DpartmentDto> GetAllDepartments()
        {
            var departments = unitOfWork.departmentReposatory.GetAll();
            return departments.Select(d => d.toDepartmentDto());
        }

        // Get by id
        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = unitOfWork.departmentReposatory.GetById(id);
            return department is null ? null : department.ToDepartmentDetailsDto();
        }

        // Add
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            unitOfWork.departmentReposatory.Add(departmentDto.toEntity());
            return unitOfWork.SaveChanges();
        }

        // Update
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            unitOfWork.departmentReposatory.Update(departmentDto.toEntity());
            return unitOfWork.SaveChanges();
        }

        // Delete
        public bool DeleteDepartment(int id)
        {
            var department = unitOfWork.departmentReposatory.GetById(id);
            if (department is null) return false;

            unitOfWork.departmentReposatory.Remove(department);
            return unitOfWork.SaveChanges() > 0;
        }

        public DepartmentDetailsDto GetDepartmentyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
