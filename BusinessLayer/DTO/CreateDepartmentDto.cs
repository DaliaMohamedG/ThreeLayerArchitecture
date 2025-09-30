﻿namespace BusinessLogicLayer.DTO
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
