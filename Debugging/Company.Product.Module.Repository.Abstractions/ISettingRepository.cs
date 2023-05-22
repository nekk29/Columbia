using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions.Base;

namespace Company.Product.Module.Repository.Abstractions
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<T> GetValue<T>(string group, string code);
        Task<IEnumerable<Setting>> List(string group);
        Task<IEnumerable<Setting>> List(params string[] codes);
    }
}
