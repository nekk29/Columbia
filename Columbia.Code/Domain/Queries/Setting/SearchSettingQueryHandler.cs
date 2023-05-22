using AutoMapper;
using Microsoft.Extensions.Configuration;
using $safesolutionname$.Common;
using $safesolutionname$.Domain.Queries.Base;
using $safesolutionname$.Domain.Services.Setting;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.Setting;
using $safesolutionname$.Entity.Base;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Extensions;
using System.Linq.Expressions;

namespace $safesolutionname$.Domain.Queries.Setting
{
    public class SearchSettingQueryHandler : SearchQueryHandlerBase<SearchSettingQuery, SearchSettingFilterDto, SearchSettingDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Entity.Setting> _settingRepository;

        public SearchSettingQueryHandler(
            IMapper mapper,
            IConfiguration configuration,
            IRepository<Entity.Setting> settingRepository
        ) : base(mapper)
        {
            _configuration = configuration;
            _settingRepository = settingRepository;
        }

        protected override async Task<ResponseDto<SearchResultDto<SearchSettingDto>>> HandleQuery(SearchSettingQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<SearchSettingDto>>();
            var securityKey = _configuration.GetValue<string>("SecurityOptions:SecurityKey");

            Expression<Func<Entity.Setting, bool>> filter = x => true;

            var filters = request.SearchParams?.Filter;

            if (!string.IsNullOrEmpty(filters?.Query))
                filter = filter.And(x => x.Group.Contains(filters.Query) || x.Code.Contains(filters.Query) || x.Description.Contains(filters.Query));

            var sorts = new List<SortExpression<Entity.Setting>>();

            if (request.SearchParams?.Sort?.Any() == true)
            {
                request.SearchParams.Sort.ToList().ForEach(x =>
                {
                    var sort = IQueryableExtensions.GetSortExpression<Entity.Setting>(x.Direction, x.Property);
                    if (sort != null) sorts.Add(sort);
                });
            }
            else
            {
                sorts.Add(new SortExpression<Entity.Setting> { Direction = SortDirection.Asc, Property = x => x.Group });
                sorts.Add(new SortExpression<Entity.Setting> { Direction = SortDirection.Asc, Property = x => x.Code });
            }

            var settings = await _settingRepository.SearchByAsNoTrackingAsync(
                request.SearchParams?.Page?.Page ?? 1,
                request.SearchParams?.Page?.PageSize ?? 10,
                sorts,
                filter
            );

            var settingDtos = _mapper?.Map<IEnumerable<SearchSettingDto>>(settings.Items);

            settingDtos ??= new List<SearchSettingDto>();

            foreach (var settingDto in settingDtos ?? new List<SearchSettingDto>())
            {
                if (Constants.Settings.EncryptedSettings.Any(x => x.Group == settingDto.Group && x.Code == settingDto.Code))
                {
                    settingDto.Encrypted = true;
                    settingDto.Value = SettingService.HideValue(settingDto.Value, securityKey);
                }
            }

            var searchResult = new SearchResultDto<SearchSettingDto>(
                settingDtos!,
                settings.Total,
                request.SearchParams
            );

            response.UpdateData(searchResult);

            return await Task.FromResult(response);
        }
    }
}
