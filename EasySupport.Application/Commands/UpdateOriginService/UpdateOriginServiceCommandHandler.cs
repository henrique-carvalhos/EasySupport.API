using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateOriginService
{
    public class UpdateOriginServiceCommandHandler : IRequestHandler<UpdateOriginServiceCommand, ResultViewModel>
    {
        private readonly IOriginServicesRepository _repository;
        public UpdateOriginServiceCommandHandler(IOriginServicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateOriginServiceCommand request, CancellationToken cancellationToken)
        {
            var originService = await _repository.GetByIdAsync(request.OriginServeceId);

            if(originService is null)
            {
                return ResultViewModel.Error("Origem de atendimento não encotrado");
            }

            originService.Update(request.Name);
            await _repository.UpdateAsync(originService);

            return ResultViewModel.Success();
        }
    }
}
