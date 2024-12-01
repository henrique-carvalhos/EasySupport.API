using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertOriginService
{
    public class InsertOriginServiceCommandHandler : IRequestHandler<InsertOriginServiceCommand, ResultViewModel<int>>
    {
        private readonly IOriginServicesRepository _repository;
        public InsertOriginServiceCommandHandler(IOriginServicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertOriginServiceCommand request, CancellationToken cancellationToken)
        {
            var originService = request.ToEntity();

            await _repository.AddAsync(originService);

            return ResultViewModel<int>.Success(originService.Id);
        }
    }
}
