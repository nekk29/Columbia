﻿namespace $safesolutionname$.Dto.Application
{
    public class GetApplicationDto : ApplicationDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
