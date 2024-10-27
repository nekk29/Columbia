using AutoMapper;
using Company.Product.Module.Common;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using Company.Product.Module.Repository.Abstractions;
using Company.Product.Module.Repository.Abstractions.Transactions;
using Microsoft.Extensions.Configuration;

namespace Company.Product.Module.Domain.Commands.Setting
{
    public class UpdateSettingCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IConfiguration configuration,
        UpdateSettingCommandValidator validator,
        ISettingRepository settingRepository
    ) : CommandHandlerBase<UpdateSettingCommand, GetSettingDto>(unitOfWork, mapper, validator)
    {
        protected override bool UseTransaction => false;

        public override async Task<ResponseDto<GetSettingDto>> HandleCommand(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSettingDto>();
            var securityKey = configuration.GetValue<string>("SecurityOptions:SecurityKey");

            var setting = await settingRepository.GetByAsync(x => x.Group == request.UpdateDto.Group && x.Code == request.UpdateDto.Code);
            if (setting != null)
            {
                setting.Value = request.UpdateDto.Value;

                if (Constants.Settings.EncryptedSettings.Any(x => x.Group == setting.Group && x.Code == setting.Code))
                    setting.Value = Encrypter.Encrypt(setting.Value, securityKey!);

                await settingRepository.UpdateAsync(setting);

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
