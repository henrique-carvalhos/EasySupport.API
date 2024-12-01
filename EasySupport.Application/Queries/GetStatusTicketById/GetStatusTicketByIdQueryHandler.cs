using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetStatusTicketById
{
    public class GetStatusTicketByIdQueryHandler : IRequestHandler<GetStatusTicketByIdQuery, ResultViewModel<StatusTicketViewModel>>
    {
        private readonly IStatusTicketRepository _repository;
        public GetStatusTicketByIdQueryHandler(IStatusTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<StatusTicketViewModel>> Handle(GetStatusTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetByIdAsync(request.Id);

            if(status is null)
            {
                return ResultViewModel<StatusTicketViewModel>.Error("Status do ticket não encontrado");
            }

            var model = StatusTicketViewModel.FromEntity(status);

            return ResultViewModel<StatusTicketViewModel>.Success(model);
        }
    }
}
