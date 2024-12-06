using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetTicketInteractionById
{
    public class GetTicketInteractionByIdQueryHandler : IRequestHandler<GetTicketInteractionByIdQuery, ResultViewModel<TicketInteractionsViewModel>>
    {
        private readonly ITicketInteractionRepository _repository;
        public GetTicketInteractionByIdQueryHandler(ITicketInteractionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<TicketInteractionsViewModel>> Handle(GetTicketInteractionByIdQuery request, CancellationToken cancellationToken)
        {
            var interaction = await _repository.GetByIdAsync(request.Id);

            if(interaction == null)
            {
                return ResultViewModel<TicketInteractionsViewModel>.Error("Interação não encontrada");
            }

            var model = TicketInteractionsViewModel.FromEntity(interaction);

            return ResultViewModel<TicketInteractionsViewModel>.Success(model);
        }
    }
}
