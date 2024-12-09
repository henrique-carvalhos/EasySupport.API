using EasySupport.Application.Models;
using EasySupport.Application.Notification.TicketCreated;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicket
{
    public class InsertTicketCommandHandler : IRequestHandler<InsertTicketCommand, ResultViewModel<int>>
    {
        private readonly ITicketRepository _repository;
        private readonly IMediator _mediator;
        public InsertTicketCommandHandler(ITicketRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = request.ToEntity();

            await _repository.AddAsync(ticket);

            var ticketResult = await _repository.GetByIdAsync(ticket.Id);

            var ticketCreated = new TicketCreatedNotification(
                ticketResult.Id,
                ticketResult.CreatedAt,
                ticketResult.Client.Name, 
                ticketResult.Client.Email,
                ticketResult.Category.Name, 
                ticketResult.Subcategory.Name,
                ticketResult.StatusTicket.Name,
                ticketResult.Priority.ToString(),
                ticketResult.Description);

            await _mediator.Publish(ticketCreated);

            return ResultViewModel<int>.Success(ticket.Id);
        }
    }
}
