using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllEnterprise
{
    public class GetAllEnterpriseQueryHandler : IRequestHandler<GetAllEnterpriseQuery, ResultViewModel<List<EnterpriseViewModel>>>
    {
        private readonly IEnterpriseRepository _repository;
        public GetAllEnterpriseQueryHandler(IEnterpriseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<EnterpriseViewModel>>> Handle(GetAllEnterpriseQuery request, CancellationToken cancellationToken)
        {
            var enterprises = await _repository.GetAllAsync(request.Search);

            var model = enterprises.Select(EnterpriseViewModel.FromEntity).ToList();

            return ResultViewModel<List<EnterpriseViewModel>>.Success(model);
        }
    }
}
