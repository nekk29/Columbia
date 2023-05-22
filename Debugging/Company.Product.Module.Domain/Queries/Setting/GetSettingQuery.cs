using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Queries.Setting
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
