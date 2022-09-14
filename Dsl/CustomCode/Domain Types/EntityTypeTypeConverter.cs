using Columbia.Dsl.CustomCode.DomainTypes.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Columbia.Dsl.CustomCode.DomainTypes
{
    public class EntityTypeTypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var store = GetStore(context.Instance);
            var values = new List<string>();

            if (store != null)
                values.AddRange(store.ElementDirectory.FindElements<Entity>().Select(e => { return e.Name; }));

            values = values.OrderBy(x => x).ToList();

            return new StandardValuesCollection(values);
        }
    }
}
