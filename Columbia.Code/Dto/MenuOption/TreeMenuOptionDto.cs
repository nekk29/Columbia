﻿namespace $safesolutionname$.Dto.MenuOption
{
    public class TreeMenuOptionDto : MenuOptionDto
    {
        public IEnumerable<TreeMenuOptionDto> Children { get; set; } = null!;
    }
}