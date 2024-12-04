using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllTicket
{
    public class GetAllTicketQueryHandler : IRequestHandler<GetAllTicketQuery, ResultViewModel<List<TicketViewModel>>>
    {
        private readonly ITicketRepository _repository;
        public GetAllTicketQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<TicketViewModel>>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _repository.GetAllAsync(request.Search);

            var model = tickets.Select(TicketViewModel.FromEntity).ToList();

            return ResultViewModel<List<TicketViewModel>>.Success(model);
        }
    }
}
