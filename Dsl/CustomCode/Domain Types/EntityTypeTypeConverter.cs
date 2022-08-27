using Columbia.Dsl.CustomCode.Domain_Types.Base;
using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Columbia.Dsl.CustomCode.DomainTypes
{
    public class EntityTypeTypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            Store store = GetStore(context.Instance);
            List<string> values = new List<string>();

            if (store != null)
                values.AddRange(store.ElementDirectory.FindElements<Entity>().Select(e => { return e.Name; }));

            return new StandardValuesCollection(values);
        }
    }
}
