using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetTicketById
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, ResultViewModel<TicketViewModel>>
    {
        private readonly ITicketRepository _repository;
        public GetTicketByIdQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<TicketViewModel>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.Id);

            if(ticket is null)
            {
                return ResultViewModel<TicketViewModel>.Error("Ticket não encontrado");
            }

            var model = TicketViewModel.FromEntity(ticket);

            return ResultViewModel<TicketViewModel>.Success(model);
        }
    }
}
