using AutoMapper;
using $safesolutionname$.Domain.Commands.Base;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Repository.Abstractions;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Domain.Commands.Setting
{
    public class DeleteSettingCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        DeleteSettingCommandValidator validator,
        ISettingRepository settingRepository
    ) : CommandHandlerBase<DeleteSettingCommand>(unitOfWork, mapper, validator)
    {
        protected override bool UseTransaction => false;

        public override async Task<ResponseDto> HandleCommand(DeleteSettingCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();

            await settingRepository.DeleteAsync();

            response.AddOkResult(Resources.Common.DeleteSuccessMessage);

            return response;
        }
    }
}
