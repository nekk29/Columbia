﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using $safesolutionname$.Common;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Domain.Services.Setting;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;
using $safesolutionname$.Repository.Abstractions.Base;

namespace $safesolutionname$.Domain.Queries.Setting
{
    public class GetSettingQueryHandler(
        IMapper mapper,
        IConfiguration configuration,
        IRepository<Entity.Setting> settingRepository
    ) : QueryHandlerBase<GetSettingQuery, GetSettingDto>(mapper)
    {
        protected override async Task<ResponseDto<GetSettingDto>> HandleQuery(GetSettingQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSettingDto>();
            var setting = await settingRepository.GetByAsync(x => x.Group == request.Group && x.Code == request.Code);
            var settingDto = _mapper?.Map<GetSettingDto>(setting);

            if (settingDto != null)
            {
                if (Constants.Settings.EncryptedSettings.Any(x => x.Group == settingDto.Group && x.Code == settingDto.Code))
                {
                    var securityKey = configuration.GetValue<string>("SecurityOptions:SecurityKey");

                    settingDto.Encrypted = true;
                    settingDto.Value = SettingService.HideValue(settingDto.Value, securityKey!);
                }

                response.UpdateData(settingDto);
            }

            return await Task.FromResult(response);
        }
    }
}
