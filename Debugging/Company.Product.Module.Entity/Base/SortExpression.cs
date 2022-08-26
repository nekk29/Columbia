using System.Linq.Expressions;

namespace Company.Product.Module.Entity.Base
{
    public class SortExpression<TEntity>
    {
        public SortDirection Direction { get; set; }
        public Expression<Func<TEntity, object>>? Property { get; set; }
    }
}
