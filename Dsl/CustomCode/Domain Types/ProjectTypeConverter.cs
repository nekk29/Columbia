using Columbia.Dsl.CustomCode.DomainTypes.Base;
using Columbia.Dsl.Utils;
using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Columbia.Dsl.CustomCode.DomainTypes
{
    public class ProjectTypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var values = new List<string>();

            var dte = context.GetService(typeof(_DTE)) as _DTE;
            if (dte == null)
                return new StandardValuesCollection(values);

            var solution = (Solution2)dte.Solution;
            if (solution == null)
                return new StandardValuesCollection(values);

            var projects = ProjectUtils.GetSolutionProjects(solution);

            values.AddRange(projects.Select(x => x.Name));

            return new StandardValuesCollection(values);
        }
    }
}
