namespace BusinessLogicLayer.DTO.DepartmentDtos
{
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }

    }
}
