﻿namespace BusinessLogicLayer.DTO
{
    public class DpartmentDto
    {
        public int DeptId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; }
    }
}
