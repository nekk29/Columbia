using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Dto.Setting;

namespace Company.Product.Module.Domain.Queries.Setting
{
    public class GetSettingQuery(string group, string code) : QueryBase<GetSettingDto>
    {
        public string Group { get; set; } = group;
        public string Code { get; set; } = code;
    }
}
