namespace BusinessLogicLayer.DTO
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } //user id
        public DateOnly? CreatedOn { get; set; }//the datetime of creating the record
        public int ModifiedBy { get; set; } //user id
        public DateOnly? ModifiedOn { get; set; }//the datetime of modifing the record
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Code = department.Code;
        //    Name = department.Name;
        //    Description = department.Description;
        //    CreatedBy = department.CreatedBy;
        //    IsDeleted = department.IsDeleted;
        //    ModifiedBy = department.ModifiedBy;
        //}
    }
}
