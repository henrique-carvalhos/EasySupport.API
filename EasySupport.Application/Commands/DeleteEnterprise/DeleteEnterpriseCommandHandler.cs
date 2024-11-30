using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteEnterprise
{
    public class DeleteEnterpriseCommandHandler : IRequestHandler<DeleteEnterpriseCommand, ResultViewModel>
    {
        private readonly IEnterpriseRepository _repository;
        public DeleteEnterpriseCommandHandler(IEnterpriseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var enterprise = await _repository.GetByIdAsync(request.Id);

            if(enterprise is null)
            {
                return ResultViewModel.Error("Empresa não encontrada");
            }

            enterprise.SetAsDeleted();
            await _repository.UpdateAsync(enterprise);

            return ResultViewModel.Success();   
        }
    }
}
