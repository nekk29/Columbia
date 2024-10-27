namespace Company.Product.Module.Dto.Action
{
    public class UpdateActionDto : ActionDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
