using Company.Product.Module.Common;
using Company.Product.Module.Entity;
using Company.Product.Module.Repository.Abstractions;
using Company.Product.Module.Repository.Abstractions.Security;
using Company.Product.Module.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Company.Product.Module.Repository
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly IConfiguration _configuration;

        public SettingRepository(
            DbContext dbContext,
            IUserIdentity userIdentity,
            IConfiguration configuration
        ) : base(dbContext, userIdentity)
        {
            _configuration = configuration;
        }

        public async Task<T> GetValue<T>(string group, string code)
        {
            var setting = await GetByAsNoTrackingAsync(x => x.Group == group && x.Code == code);
            if (setting?.Value != null)
            {
                try
                {
                    var value = (T)Convert.ChangeType(setting?.Value, typeof(T))!;

                    if (value != null && value.GetType() == typeof(string) &&
                        Constants.Settings.EncryptedSettings.Any(x => x.Group == group && x.Code == code))
                    {
                        var securityKey = _configuration.GetValue<string>("SecurityOptions:SecurityKey");
                        try { return (T)Convert.ChangeType(Encrypter.Decrypt(value as string, securityKey), typeof(T)); }
                        catch (Exception) { value = default!; }
                    }

                    return value;
                }
                catch (Exception)
                {
                    return default!;
                }
            }

            return default!;
        }

        public async Task<IEnumerable<Setting>> List(string group)
            => !string.IsNullOrEmpty(group) ? await FindByAsNoTrackingAsync(x => x.Group == group) : new List<Setting>();

        public async Task<IEnumerable<Setting>> List(params string[] codes)
            => codes != null ? await FindByAsNoTrackingAsync(x => codes.Contains(x.Code)) : new List<Setting>();
    }
}
