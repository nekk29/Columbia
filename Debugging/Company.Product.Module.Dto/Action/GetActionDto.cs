namespace Company.Product.Module.Dto.Action
{
    public class GetActionDto : ActionDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
