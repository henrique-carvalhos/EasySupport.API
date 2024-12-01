using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllOriginService
{
    public class GetAllOriginServiceQueryHandler : IRequestHandler<GetAllOriginServiceQuery, ResultViewModel<List<OriginServiceViewModel>>>
    {
        private readonly IOriginServicesRepository _repository;
        public GetAllOriginServiceQueryHandler(IOriginServicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<OriginServiceViewModel>>> Handle(GetAllOriginServiceQuery request, CancellationToken cancellationToken)
        {
            var originServices = await _repository.GetAllAsync(request.Search);

            var model = originServices.Select(OriginServiceViewModel.FromEntity).ToList();

            return ResultViewModel<List<OriginServiceViewModel>>.Success(model);
        }
    }
}
