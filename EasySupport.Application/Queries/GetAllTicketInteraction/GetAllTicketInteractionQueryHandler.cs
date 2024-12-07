using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllTicketInteraction
{
    public class GetAllTicketInteractionQueryHandler : IRequestHandler<GetAllTicketInteractionQuery, ResultViewModel<List<TicketInteractionsViewModel>>>
    {
        private readonly ITicketInteractionRepository _repository;

        public GetAllTicketInteractionQueryHandler(ITicketInteractionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<TicketInteractionsViewModel>>> Handle(GetAllTicketInteractionQuery request, CancellationToken cancellationToken)
        {
            var interactions = await _repository.GetAllInteractionsAsync(request.TicketId);

            var model = interactions.Select(TicketInteractionsViewModel.FromEntity).ToList();

            return ResultViewModel<List<TicketInteractionsViewModel>>.Success(model);
        }
    }
}
