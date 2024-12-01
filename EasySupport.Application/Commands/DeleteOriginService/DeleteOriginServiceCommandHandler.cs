using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteOriginService
{
    public class DeleteOriginServiceCommandHandler : IRequestHandler<DeleteOriginServiceCommand, ResultViewModel>
    {
        private readonly IOriginServicesRepository _repository;
        public DeleteOriginServiceCommandHandler(IOriginServicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteOriginServiceCommand request, CancellationToken cancellationToken)
        {
            var originService = await _repository.GetByIdAsync(request.Id);

            if(originService is null)
            {
                return ResultViewModel.Error("Origem de atendimento não encontrado");
            }

            originService.SetAsDeleted();
            await _repository.UpdateAsync(originService);

            return ResultViewModel.Success();
        }
    }
}
