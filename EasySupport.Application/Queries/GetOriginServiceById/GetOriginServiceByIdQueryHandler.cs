using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetOriginServiceById
{
    public class GetOriginServiceByIdQueryHandler : IRequestHandler<GetOriginServiceByIdQuery, ResultViewModel<OriginServiceViewModel>>
    {
        private readonly IOriginServicesRepository _repository;
        public GetOriginServiceByIdQueryHandler(IOriginServicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<OriginServiceViewModel>> Handle(GetOriginServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var origin = await _repository.GetByIdAsync(request.Id);

            if(origin is null)
            {
                return ResultViewModel<OriginServiceViewModel>.Error("Origem do atendimento não encotrado.");
            }

            var model = OriginServiceViewModel.FromEntity(origin);

            return ResultViewModel<OriginServiceViewModel>.Success(model);
        }
    }
}
