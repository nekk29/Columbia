using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Dto.Setting;

namespace $safesolutionname$.Domain.Queries.Setting
{
    public class GetSettingQuery : QueryBase<GetSettingDto>
    {
        public GetSettingQuery(string group, string code)
        {
            Group = group;
            Code = code;
        }

        public string Group { get; set; }
        public string Code { get; set; }
    }
}
