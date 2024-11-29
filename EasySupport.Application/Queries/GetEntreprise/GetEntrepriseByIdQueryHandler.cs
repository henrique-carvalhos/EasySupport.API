using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetEntreprise
{
    public class GetEntrepriseByIdQueryHandler : IRequestHandler<GetEntrepriseByIdQuery, ResultViewModel<EnterpriseViewModel>>
    {
        private readonly IEnterpriseRepository _repository;
        public GetEntrepriseByIdQueryHandler(IEnterpriseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<EnterpriseViewModel>> Handle(GetEntrepriseByIdQuery request, CancellationToken cancellationToken)
        {
            var enterprise = await _repository.GetByIdAsync(request.Id);

            if (enterprise is null)
            {
                return ResultViewModel<EnterpriseViewModel>.Error("Empresas não encontrada");
            }

            var model = EnterpriseViewModel.FromEntity(enterprise);

            return ResultViewModel<EnterpriseViewModel>.Success(model);
        }
    }
}
