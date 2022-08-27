using Microsoft.VisualStudio.Modeling;
using System.ComponentModel;

namespace Columbia.Dsl.CustomCode.Domain_Types.Base
{
    public class BaseTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            => true;

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            => true;

        public Store GetStore(object gridSelection)
        {
            ModelElement currentElement;

            if (gridSelection is object[] objects && objects.Length > 0)
                currentElement = objects[0] as ModelElement;
            else
                currentElement = gridSelection as ModelElement;

            return (currentElement == null) ? null : currentElement.Store;
        }
    }
}
