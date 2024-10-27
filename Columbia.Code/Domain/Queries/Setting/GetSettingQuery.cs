using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Queries.Setting
{
    public class GetSettingQuery(string group, string code) : QueryBase<GetSettingDto>
    {
        public string Group { get; set; } = group;
        public string Code { get; set; } = code;
    }
}
