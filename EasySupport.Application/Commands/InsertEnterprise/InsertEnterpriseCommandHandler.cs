using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertEnterprise
{
    public class InsertEnterpriseCommandHandler : IRequestHandler<InsertEnterpriseCommand, ResultViewModel<int>>
    {
        private readonly IEnterpriseRepository _repository;
        public InsertEnterpriseCommandHandler(IEnterpriseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var enterprise = request.ToEntity();

            await _repository.AddAsync(enterprise);

            return ResultViewModel<int>.Success(enterprise.Id);
        }
    }
}
