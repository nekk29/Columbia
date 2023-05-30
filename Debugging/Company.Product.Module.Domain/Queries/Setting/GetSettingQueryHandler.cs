﻿using AutoMapper;
using Company.Product.Module.Common;
using Company.Product.Module.Domain.Queries.Base;
using Company.Product.Module.Domain.Services.Setting;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.Setting;
using Company.Product.Module.Repository.Abstractions.Base;
using Microsoft.Extensions.Configuration;

namespace Company.Product.Module.Domain.Queries.Setting
{
    public class GetSettingQueryHandler : QueryHandlerBase<GetSettingQuery, GetSettingDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Entity.Setting> _settingRepository;

        public GetSettingQueryHandler(
            IMapper mapper,
            IConfiguration configuration,
            IRepository<Entity.Setting> settingRepository
        ) : base(mapper)
        {
            _configuration = configuration;
            _settingRepository = settingRepository;
        }

        protected override async Task<ResponseDto<GetSettingDto>> HandleQuery(GetSettingQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetSettingDto>();
            var setting = await _settingRepository.GetByAsync(x => x.Group == request.Group && x.Code == request.Code);
            var settingDto = _mapper?.Map<GetSettingDto>(setting);

            if (settingDto != null)
            {
                if (Constants.Settings.EncryptedSettings.Any(x => x.Group == settingDto.Group && x.Code == settingDto.Code))
                {
                    var securityKey = _configuration.GetValue<string>("SecurityOptions:SecurityKey");

                    settingDto.Encrypted = true;
                    settingDto.Value = SettingService.HideValue(settingDto.Value, securityKey);
                }

                response.UpdateData(settingDto);
            }

            return await Task.FromResult(response);
        }
    }
}