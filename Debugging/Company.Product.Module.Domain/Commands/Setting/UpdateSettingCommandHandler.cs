using AutoMapper;
using Company.Product.Module.Common;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Company.Product.Module.Domain.Commands.Setting
{
    public class UpdateSettingCommandHandler : CommandHandlerBase<UpdateSettingCommand, GetSettingDto>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private readonly IRepository<Entity.Setting> _settingRepository;

        public UpdateSettingCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMemoryCache memoryCache,
            IConfiguration configuration,
            UpdateSettingCommandValidator validator,
            IRepository<Entity.Setting> settingRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;
            _settingRepository = settingRepository;
        }

        public override async Task<ResponseDto<GetSettingDto>> HandleCommand(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSettingDto>();
            var securityKey = _configuration.GetValue<string>("SecurityOptions:SecurityKey");

            var setting = await _settingRepository.GetByAsync(x => x.Group == request.UpdateDto.Group && x.Code == request.UpdateDto.Code);
            if (setting != null)
            {
                setting.Value = request.UpdateDto.Value;

                if (Constants.Settings.EncryptedSettings.Any(x => x.Group == setting.Group && x.Code == setting.Code))
                    setting.Value = Encrypter.Encrypt(setting.Value, securityKey);

                await _settingRepository.UpdateAsync(setting);
                await _settingRepository.SaveAsync();

                /* Clean memory cache setting items
                _memoryCache.Remove(Constants.Cache.{CacheKey});
                */
            }

            var settingDto = _mapper?.Map<GetSettingDto>(setting);
            if (settingDto != null) response.UpdateData(settingDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
