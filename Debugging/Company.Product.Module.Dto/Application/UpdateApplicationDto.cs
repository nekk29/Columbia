﻿namespace Company.Product.Module.Dto.Application
{
    public class UpdateApplicationDto : ApplicationDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
