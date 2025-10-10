using AutoMapper;
using BusinessLogicLayer.DTO.EmployeeDtos;
using BusinessLogicLayer.Services.AttachmentService;
using DataAccessLayer.Data.Repository;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper, IAttachmentService attachmentService) : IEmployeeServices
    {
        public int CreateEmployee(CreateEmployeeDto employee)
        {
            var emp = mapper.Map<CreateEmployeeDto, Employee>(employee);
            if (employee.Image is not null)
            {
                employee.ImageName = attachmentService.Upload(employee.Image, "Images");
            }
            unitOfWork.EmployeeRepository.Add(emp);
            return unitOfWork.SaveChanges();
        }
        public bool DeleteEmployee(int id)
        {
            //soft delete => update[is deleted true]
            var emp = unitOfWork.EmployeeRepository.GetById(id);
            if (emp is null) return false;
            emp.IsDeleted = true;
            unitOfWork.EmployeeRepository.Update(emp);
            return unitOfWork.SaveChanges() > 0 ? true : false;
        }
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking = false)
        {
            var emp = unitOfWork.EmployeeRepository.GetAll(WithTracking);
            //Map<source,destination>
            var EmpDto = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(emp);
            //var EmpDto = emp.Select(e => new EmployeeDto()
            //{
            //    Email = e.Email,
            //    Age = e.Age,
            //    Name = e.Name,
            //    Salary = e.Salary,
            //    IsActive = e.IsActive,
            //    Gender = e.gender.ToString(),
            //    EmployeeType = e.employeeType.ToString()
            //});
            return EmpDto;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var emp = unitOfWork.EmployeeRepository.GetById(id);
            return emp is null ? null : mapper.Map<Employee, EmployeeDetailsDto>(emp);
            //mapper.Map<EmployeeDetailsDto>(emp); 

            //new EmployeeDetailsDto()
            //{
            //    Email = emp.Email,
            //    Age = emp.Age,
            //    Name = emp.Name,
            //    Salary = emp.Salary,
            //    Address = emp.Address,
            //    PhoneNumber = emp.PhoneNumber,
            //    IsActive = emp.IsActive,
            //    Id = emp.Id,
            //    HiringDate = DateOnly.FromDateTime(emp.HiringDate),
            //    CreatedOn = emp.CreatedOn,
            //    ModifiedOn = emp.ModifiedOn,
            //    CreatedBy = 1,
            //    ModifiedBy = 1,
            //    EmployeeType = emp.employeeType.ToString(),
            //    Gender = emp.gender.ToString(),
            //};
        }

        public int UpdateEmployee(UpdateEmployeeDto employee)
        {
            unitOfWork.EmployeeRepository.Update(mapper.Map<UpdateEmployeeDto, Employee>(employee));
            return unitOfWork.SaveChanges();
        }
    }
}
