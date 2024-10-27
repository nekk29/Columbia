using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using $safesolutionname$.Common;
using $safesolutionname$.Entity;
using $safesolutionname$.Repository.Abstractions;
using $safesolutionname$.Repository.Abstractions.Security;
using $safesolutionname$.Repository.Base;

namespace $safesolutionname$.Repository
{
    public class SettingRepository(
        DbContext dbContext,
        IUserIdentity userIdentity,
        IConfiguration configuration
    ) : Repository<Setting>(dbContext, userIdentity), ISettingRepository
    {
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
                        var securityKey = configuration.GetValue<string>("SecurityOptions:SecurityKey");
                        try { return (T)Convert.ChangeType(Encrypter.Decrypt((value as string)!, securityKey!), typeof(T)); }
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
