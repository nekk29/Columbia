using AutoMapper;
using Company.Product.Module.Domain.Commands.Base;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Repository.Abstractions;
using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Domain.Commands.Setting
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
