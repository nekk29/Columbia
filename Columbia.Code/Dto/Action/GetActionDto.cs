namespace $safesolutionname$.Dto.Action
{
    public class GetActionDto : ActionDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
