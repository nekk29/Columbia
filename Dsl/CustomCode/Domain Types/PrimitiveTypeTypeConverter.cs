using Columbia.Dsl.CustomCode.Domain_Types.Base;
using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;

namespace Columbia.Dsl.CustomCode.DomainTypes
{
    public class PrimitiveTypeTypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            var values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.PrimitiveType_Boolean);
                values.Add(Resources.TypeConverters.PrimitiveType_Byte);
                values.Add(Resources.TypeConverters.PrimitiveType_Char);
                values.Add(Resources.TypeConverters.PrimitiveType_DateTime);
                values.Add(Resources.TypeConverters.PrimitiveType_Decimal);
                values.Add(Resources.TypeConverters.PrimitiveType_Double);
                values.Add(Resources.TypeConverters.PrimitiveType_Guid);
                values.Add(Resources.TypeConverters.PrimitiveType_Int16);
                values.Add(Resources.TypeConverters.PrimitiveType_Int32);
                values.Add(Resources.TypeConverters.PrimitiveType_Int64);
                values.Add(Resources.TypeConverters.PrimitiveType_SByte);
                values.Add(Resources.TypeConverters.PrimitiveType_Single);
                values.Add(Resources.TypeConverters.PrimitiveType_String);
                values.Add(Resources.TypeConverters.PrimitiveType_UInt16);
                values.Add(Resources.TypeConverters.PrimitiveType_UInt32);
                values.Add(Resources.TypeConverters.PrimitiveType_UInt64);
            }

            return new StandardValuesCollection(values);
        }
    }
}
