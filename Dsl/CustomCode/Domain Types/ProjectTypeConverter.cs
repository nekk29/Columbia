using Columbia.Dsl.CustomCode.Domain_Types.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace Columbia.Dsl.CustomCode.DomainTypes
{
    public class ProjectTypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var values = new List<string>();
            return new StandardValuesCollection(values);
        }
    }
}
