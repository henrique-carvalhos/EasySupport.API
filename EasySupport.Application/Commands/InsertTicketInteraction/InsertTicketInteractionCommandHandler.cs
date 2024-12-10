using EasySupport.Application.Models;
using EasySupport.Application.Notification.TicketInteractionCreated;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicketInteraction
{
    public class InsertTicketInteractionCommandHandler : IRequestHandler<InsertTicketInteractionCommand, ResultViewModel<int>>
    {
        private readonly ITicketInteractionRepository _repository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMediator _mediator;   
        public InsertTicketInteractionCommandHandler(ITicketInteractionRepository repository, ITicketRepository ticketRepository, IMediator mediator)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketInteractionCommand request, CancellationToken cancellationToken)
        {
            var interaction = request.ToEntity();

            await _repository.AddAsync(interaction);

            var ticketResult = await _ticketRepository.GetByIdAsync(interaction.TicketId);

            var ticket = new TicketInteractionNotification(
                interaction.Id,
                ticketResult.Id,
                ticketResult.Description,
                ticketResult.StatusTicket.Name,
                ticketResult.Category.Name,
                ticketResult.Subcategory.Name,
                interaction.Attendant.Id,
                interaction.Attendant.Name,
                interaction.Attendant.Email,
                ticketResult.Client.Name,
                ticketResult.Client.Email,
                interaction.Message,
                interaction.Attendant.Role,
                interaction.CreatedAt,
                ticketResult.CreatedAt);

            await _mediator.Publish(ticket);

            return ResultViewModel<int>.Success(interaction.Id);
        }
    }
}
