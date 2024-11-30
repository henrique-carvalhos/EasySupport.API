using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateEnterprise
{
    public class UpdateEnterpriseCommandHandler : IRequestHandler<UpdateEnterpriseCommand, ResultViewModel>
    {
        private readonly IEnterpriseRepository _repository;
        public UpdateEnterpriseCommandHandler(IEnterpriseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var enterprise = await _repository.GetByIdAsync(request.EnterpriseId);

            if (enterprise is null)
            {
                return ResultViewModel.Error("Empresa não encontrada");
            }

            enterprise.Update(request.Name);
            await _repository.UpdateAsync(enterprise);

            return ResultViewModel.Success();
        }
    }
}
